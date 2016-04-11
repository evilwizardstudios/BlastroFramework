using UnityEngine;

public class ProjectileProperties
{
    public GameObject ProjectileModel;

    // projectile physics
    public bool ConstantSpeed;
    public float LaunchSpeed;
    public bool Gravity;
    public bool PiercesEnemies;

    // enemy effects
    public float DirectHitDamage;
    public float CritChance;
    public float CritDamageModifier;
    public float EnemyKnockBack;

    // splash effects
    public bool BounceCount;
    public GameObject Explosion;
    public float ExplosionGrowthRate;
    public float ExplosionTime;
    public float ExplosionKnockback;


}