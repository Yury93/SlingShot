using UnityEngine;

public class SlingShot : MonoBehaviour
{
    [SerializeField] private LineRenderer rope;
    [SerializeField] private BirdFactory birdFactory;
    private Bird bird;

    private float viewX;
    private float viewY;
    /// <summary>
    /// Скорость перемещения птички при прицеливании на клавиши направления
    /// </summary>
    [SerializeField] private float speedView;
    /// <summary>
    /// Сила натяжения резинки
    /// </summary>
    private float forceTension = 0.01f;
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
    private void Start()
    {
        bird = birdFactory.GetComponentInChildren<Bird>();
        startPositionBird = bird.transform.position;
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (forceTension < maxForceTension && forceTension != 0)
            {
                forceTension += Time.fixedDeltaTime;
            }
            else
            {
                forceTension = 0f;
            }
            viewX = Input.GetAxis("Horizontal") * speedView;
            viewY = Input.GetAxis("Vertical") * speedView;
            Mathf.Clamp(viewY, -3, 3);
            bird.transform.Translate(viewX * Time.fixedDeltaTime, viewY * Time.fixedDeltaTime, -forceTension * Time.fixedDeltaTime);
            
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
        }
    }
}