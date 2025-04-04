public class WeaponCannon : BaseWeapon
{
    protected override void Shoot()
    {
        base.Shoot();
        if(!LastBullet)
            return;
        LastBullet.GetComponent<BaseBullet>().Seek(enemyTarget, damage);
    }
}
