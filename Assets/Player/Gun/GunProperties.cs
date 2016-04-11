using UnityEngine;
using System.Collections;

// a gear heirarchy should calculate GunProperties & ProjectileProperties objects

public class GunProperties
{
    public ProjectileProperties Projectile;

    // graphical
    public GameObject GunModel;
    public GameObject ReticleModel;
    
    // aim
    public float AimSpeed;
    public float ZoomDistance;
    public float Accuracy;
    public float AimAccuracyTime; //time in aim to 100% accurate shot

    // ammo
    public int ClipSize;
    public int AmmoPerShot;
    public float RateOfFire;
    public float ReloadTime;
    
    // player effects
    public float Recoil;
    
}

public enum ProjectileType
{
    Bullet,
    Pulse,
    Beam,
    Hitscan,
    Rocket,
    Grenade,
    Mine
}