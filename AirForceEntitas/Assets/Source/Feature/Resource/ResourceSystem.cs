using UnityEngine;
using System.Collections;

public class ResourceSystem : Feature
{
    public ResourceSystem(Contexts contexts, Services services)
    {
        Add(new ResourcesSystem(contexts, services));
        Add(new DestroySystem(contexts, services));
    }
}
