using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody ribody;
    /// <summary>
    /// ћаксимальна€ скорость которую можно набрать
    /// </summary>
    [SerializeField] private float maxSpeed;
    private float speed;
    private GameObject factoryBird;
    private void Start()
    {
        ribody.isKinematic = true;
        factoryBird = gameObject.GetComponentInParent<BirdFactory>().gameObject;
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if (speed <= maxSpeed)
            {
                speed += Time.fixedDeltaTime;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            ribody.isKinematic = false;
            Vector3 dir = factoryBird.transform.position - gameObject.transform.position;
            ribody.AddForce(dir * speed, ForceMode.Impulse);
        }
    }
}
