using UnityEngine;

public class WeaponTurret : BaseWeapon
{
    protected override void Shoot()
    {
        base.Shoot();
        WeaponAmmoBullet bullet = lastBullet.GetComponent<WeaponAmmoBullet>();

        if (!bullet)
            return;

        bullet.Seek(enemyTarget, damage);
    }
}
