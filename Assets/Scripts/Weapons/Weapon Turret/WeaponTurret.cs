using UnityEngine;

public class WeaponTurret : BaseWeapon
{
    [SerializeField] private Transform firePointRight;
    [SerializeField] private Transform firePointLeft;
    private bool _usedRightFirePoint = false;
    protected override void Shoot()
    {
        Transform selectedFirePoint = _usedRightFirePoint ? firePointRight : firePointLeft;
        LastBullet = Instantiate(bulletPrefab, selectedFirePoint.position, selectedFirePoint.rotation);
        WeaponAmmoBullet bullet = LastBullet.GetComponent<WeaponAmmoBullet>();

        if (!bullet) return;

        bullet.Seek(this, enemyTarget, damage);
        _usedRightFirePoint = !_usedRightFirePoint;
    }
}
