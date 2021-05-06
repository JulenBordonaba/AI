using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public static List<Entity> activeEntities = new List<Entity>();

    private void OnEnable()
    {
        activeEntities.Add(this);
    }
    
    private void OnDisable()
    {
        activeEntities.Remove(this);
    }
    
}
