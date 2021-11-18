using UnityEngine;

[RequireComponent(typeof(SlingShot))]
public class Trajectory : MonoBehaviour
{
    /// <summary>
    /// Частичка траектории
    /// </summary>
    [SerializeField] private GameObject trackPrefab;
    /// <summary>
    /// Откуда мы будем мерить траекторию
    /// </summary>
    [SerializeField] private Transform bird;
    private SlingShot slingShot;

    private Vector3 lookTrack;

    private void Start()
    {
        slingShot = gameObject.GetComponent<SlingShot>(); 
    }
    private void Update()
    {
        lookTrack = slingShot.LookTrack;
        //trackPrefab = Instantiate( )
        //TODO: Создание объекта иммитируещего траекторию полёта
    }
}
