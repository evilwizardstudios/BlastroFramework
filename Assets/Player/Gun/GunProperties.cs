using System;
using UnityEngine;
using System.Collections;

// a gear heirarchy should calculate GunProperties & ProjectileProperties objects
[Serializable]
public class GunProperties
{
    public ProjectileProperties Projectile;

    // graphical
    public GameObject GunModel;
    public GameObject ReticleModel;
    
    // aim
    public bool CanAim;                 //if not, use strafe mechanics TODO
    public float AimSpeed;
    public float ZoomDistance;
    public float Spread;
    public float FocusSpeed;       //time in aim to 100% accurate shot

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