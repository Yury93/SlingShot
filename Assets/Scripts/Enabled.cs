using System.Collections;
using UnityEngine;

public class Enabled : MonoBehaviour
{
    private SlingShot slingShot;
    private void Start()
    {
        slingShot = GetComponent<SlingShot>();
    }
}
