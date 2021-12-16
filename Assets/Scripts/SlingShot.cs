using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enabled))]
public class SlingShot : MonoBehaviour
{
    [SerializeField] private LineRenderer rope;
    [SerializeField] private BirdFactory birdFactory;
    [SerializeField] private Bird bird;

    private float viewX;
    private float viewY;
    /// <summary>
    /// Скорость перемещения птички при прицеливании на клавиши направления
    /// </summary>
    [SerializeField] private float speedView;
    /// <summary>
    /// Сила натяжения резинки
    /// </summary>
    [SerializeField] private float forceTension = 0.01f;
    [SerializeField] private float maxForceTension;

    /// <summary>
    /// Начальная позиция птички
    /// </summary>
    private Vector3 startPositionBird;

    /// <summary>
    /// Кэшированное прицеливание
    /// </summary>
    private Vector3 lookTrack;
    public Vector3 LookTrack => lookTrack;
    /// <summary>
    /// Можно ли стрелять
    /// </summary>
    private bool Shoot = true;

    private void Start()
    {
        bird = birdFactory.GetComponentInChildren<Bird>();
        startPositionBird = bird.transform.position;
    }
    private void Update()
    {
        if(!bird)
        {
            bird = birdFactory.Prefab;
            forceTension = 0.01f;
        }
        if (Input.GetKey(KeyCode.Space) && Shoot == true)
        {
            if (forceTension < maxForceTension && forceTension != 0)
            {
                forceTension += Time.deltaTime;
            }
            else
            {
                forceTension = 0f;
            }
            
            viewX = Input.GetAxis("Horizontal") * speedView;
            viewY = Input.GetAxis("Vertical") * speedView;
            Mathf.Clamp(viewY, -3, 3);
            bird.transform.Translate(viewX * Time.deltaTime, viewY * Time.deltaTime, -forceTension * Time.deltaTime);
            
            rope.SetPosition(1, new Vector3(bird.transform.position.x + 0.6f, bird.transform.position.y, bird.transform.position.z - 0.35f));
            rope.SetPosition(2, new Vector3(bird.transform.position.x, bird.transform.position.y, bird.transform.position.z - 0.7f));
            rope.SetPosition(3, new Vector3(bird.transform.position.x - 0.6f, bird.transform.position.y, bird.transform.position.z - 0.35f));
            
            bird.transform.LookAt(new Vector3(startPositionBird.x, bird.transform.position.y, startPositionBird.z));
            lookTrack = new Vector3(startPositionBird.x, bird.transform.position.y, startPositionBird.z);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            rope.SetPosition(1, birdFactory.transform.position);
            rope.SetPosition(2, birdFactory.transform.position);
            rope.SetPosition(3, birdFactory.transform.position);
            Shoot = false;
            StartCoroutine(corBoolShit());
        }
    }
    /// <summary>
    /// bool Shoot = true
    /// </summary>
    /// <returns></returns>
    IEnumerator corBoolShit()
    {
        yield return new WaitForSeconds(3.5f);
        Shoot = true;
    }
}