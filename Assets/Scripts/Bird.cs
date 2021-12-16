using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody ribody;
    /// <summary>
    /// Максимальная скорость которую можно набрать
    /// </summary>
    [SerializeField] private float maxSpeed;
    [SerializeField]private float speed = 3.5f;
    private GameObject factoryBird;
    /// <summary>
    /// Рассчёт траектории
    /// </summary>
    [SerializeField]private TrailRenderer trailRender;
    private GameObject trailGo;
    [SerializeField] private Rigidbody rbTrail;
    private void Start()
    {

        gameObject.GetComponent<Bird>().enabled = true;
        ribody = GetComponent<Rigidbody>();
        ribody.isKinematic = true;

        rbTrail = GetComponentInChildren<Rigidbody>();
        rbTrail.isKinematic = true;
        trailRender = GetComponentInChildren<TrailRenderer>();
        trailGo = GetComponentInChildren<TrailRenderer>().gameObject;


        factoryBird = gameObject.GetComponentInParent<BirdFactory>().gameObject;
    }
    void Update()
    {
        if (rbTrail == null)
        {
            Start();

        }
            if (Application.platform == RuntimePlatform.Android)
            {
            if (Input.GetMouseButton(0))
            {
                if (speed <= maxSpeed)
                {
                    speed += Time.deltaTime;
                }

                rbTrail.isKinematic = false;
                Vector3 dir = rbTrail.transform.position - gameObject.transform.position;
                rbTrail.AddForce(dir * speed, ForceMode.Impulse);
            }
            if (Input.GetMouseButtonUp(0))
            {
                ribody.isKinematic = false;
                Vector3 dir = factoryBird.transform.position - gameObject.transform.position;
                ribody.AddForce(dir * speed, ForceMode.Impulse);
            }
            }
            else
            {
            if (Input.GetKey(KeyCode.Space))
            {
                if (speed <= maxSpeed)
                {
                    speed += Time.deltaTime;
                }
                rbTrail.isKinematic = false;
                Vector3 dir = rbTrail.transform.position - gameObject.transform.position;
                rbTrail.AddForce(dir * speed, ForceMode.Impulse);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ribody.isKinematic = false;
                Vector3 dir = factoryBird.transform.position - gameObject.transform.position;
                ribody.AddForce(dir * speed, ForceMode.Impulse);
            }
        }
    }
}
