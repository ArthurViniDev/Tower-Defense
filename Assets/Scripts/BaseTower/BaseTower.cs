using System;
using UnityEngine;

public abstract class BaseTower : MonoBehaviour
{
    public float damage;
    public float attackSpeed;
    public float range;
    public int price;

    protected GameObject Target;

    public void SetTarget(GameObject newTarget)
    {
        Target = newTarget;
    }

    protected abstract void Attack();
}
