using UnityEngine;

public abstract class BaseTower : MonoBehaviour
{
    protected GameObject Target;

    [Header("Base Tower Attributes")]
    public int price = 50;
    public int refundValue = 25;

    [Header("Base Tower Buffs")]
    public int damageBuff;
    public int rangeBuff;
    public int attackRateBuff;

    public void Initialize(int c_damageBuff, int c_rangeBuff, int c_attackRateBuff)
    {
        damageBuff = c_damageBuff;
        rangeBuff = c_rangeBuff;
        attackRateBuff = c_attackRateBuff;
    }

    public void BuyTower()
    {

    }
}
