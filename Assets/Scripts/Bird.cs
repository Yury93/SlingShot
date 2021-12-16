using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody ribody;
    /// <summary>
    /// ������������ �������� ������� ����� �������
    /// </summary>
    [SerializeField] private float maxSpeed;
    [SerializeField]private float speed = 3.5f;
    private GameObject factoryBird;
    private void Start()
    {
        gameObject.GetComponent<Bird>().enabled = true;
        ribody = GetComponent<Rigidbody>();
        ribody.isKinematic = true;
        factoryBird = gameObject.GetComponentInParent<BirdFactory>().gameObject;
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetMouseButton(0))
            {
                if (speed <= maxSpeed)
                {
                    speed += Time.deltaTime;
                }
            }
            if (Input.GetMouseButton(0))
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
