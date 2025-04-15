using UnityEngine;
using System.Collections.Generic;

public class EnemyRoute : MonoBehaviour
{
    //[HideInInspector]
    public List<Transform> targetPoints = new List<Transform>();
    public static EnemyRoute enemyRouteSingleton;

    private void Awake()
    {
        if (enemyRouteSingleton != null)
        {
            Debug.LogWarning("Multiple instances of EnemyRoute found. Destroying the new instance.");
            return;
        }
        enemyRouteSingleton = this;

        var transforms = gameObject.GetComponentsInChildren<Transform>();
        foreach (var transform in transforms)
        {
            if (transform == gameObject.transform)
                continue;
            targetPoints.Add(transform);
        }
    }
}