using UnityEngine;

public class WeaponTurret : BaseWeapon
{
    [SerializeField] private Transform firePointRight;
    [SerializeField] private Transform firePointLeft;
    private bool usedRightFirePoint = false;
    protected override void Shoot()
    {
        Transform selectedFirePoint = usedRightFirePoint ? firePointRight : firePointLeft;
        lastBullet = Instantiate(bulletPrefab, selectedFirePoint.position, selectedFirePoint.rotation);
        WeaponAmmoBullet bullet = lastBullet.GetComponent<WeaponAmmoBullet>();

        if (!bullet)
            return;

        bullet.Seek(enemyTarget, damage);
        usedRightFirePoint = !usedRightFirePoint;
    }
}
