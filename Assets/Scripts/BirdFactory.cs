using UnityEngine;

public class BirdFactory : Factory<Bird>
{
    private void Update()
    {
        if(!Prefab)
        {
            GetNewInstance();
        }
    }
}
