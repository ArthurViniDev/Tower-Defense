using UnityEngine;

public class WeaponAmmoBullet : BaseBullet
{
    protected override void Update()
    {
        transform.LookAt(target);
        base.Update();
    }
}
