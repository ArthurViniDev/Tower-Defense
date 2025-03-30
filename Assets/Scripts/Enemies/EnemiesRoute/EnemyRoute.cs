using UnityEngine;
using System.Collections.Generic;

public class EnemyRoute : MonoBehaviour
{
    //[HideInInspector]
    public List<Transform> targetPoints = new List<Transform>();
    public static EnemyRoute EnemyRouteSingleton;

    private void Awake()
    {
        EnemyRouteSingleton = this;

        var transforms = gameObject.GetComponentsInChildren<Transform>();
        foreach (var transform in transforms)
        {
            if (transform == gameObject.transform)
                continue;
            targetPoints.Add(transform);
        }
    }
}
