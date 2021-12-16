using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public delegate void DelegateDestroy();
    public event DelegateDestroy OnDestroy;
    private void OnCollisionEnter(Collision collision)
    {
        var c = collision.gameObject.GetComponent<Bird>();
        if (c)
        {
            Destroy(c.gameObject);
            OnDestroy();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
