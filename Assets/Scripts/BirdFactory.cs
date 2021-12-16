using UnityEngine;

public class BirdFactory : Factory<Bird>
{
    [SerializeField] private Destructible destrFloor;
   
    private void Start()
    {
        destrFloor.OnDestroy += InstanceBird;
    }
    private void InstanceBird()
    {
            GetNewInstance();
    }

}
