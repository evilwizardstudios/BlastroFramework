//Loot heirarchy should create this

public class PlayerProperties
{
    //ATTRIBUTES
    // Health
    public float MaxHealth;
    public float HealthRegeneration;
    public float HealthPickupMod;

    public float MaxArmor;
    public float ArmorRegeneration;
    public float ArmorPickupMod;
    
    public float MaxShield;
    public float ShieldRegeneration;
    public float ShieldRegenDelay;

    // Resistances
    public float HackResist;

    // Exploration
    public float LightRadius;
    public float SecretDetectionRange;
    public float SecretDetectionStrength;
    public float EnemyDetectionRange;
    public float EnemyDetectionStrength; // to beat enemy stealth values
    public float AnalysisRating; // examining artifacts &c
    public float CryptographyRating; // hacking, unlocking

    // Loot & Exp
    public float Magicfind;
    public float RPfind;        // RP used to unlock & upgrade tech
    public float Creditfind;    // Credits used to requisition materials, upgrades
    public float ExpBonus;

    // MOVEMENT
    // Ground
    public float SneakSpeed; //used for stealth
    public float SneakSoundRadius;

    public float WalkSpeed;
    public float WalkSoundRadius; //used for AI detection

    public float RunSpeed;
    public float RunDelay; //full xinput for seconds
    public float RunSoundRadius;

    // Air
    public int Multijump;
    public float JumpPower;
    public float JumpBonus;
    public float GravityModifier;

    // Recovery
    public float HitRecovery; //hitstun
    public bool InvincibleDuringRecovery;
    public float KnockdownThreshold; //damage before knockdown
    public float KnockdownResistance; //vs knockdown attacks
    public float KnockdownRecoveryTime;
    public bool AllowQuickRecovery;
    public float QuickRecoveryWindow; //duration of quick recovery window

    // Camera and reticle
    public float CameraOffset;
    public float LookSpeed;

    // Slipping & Friction
    public float SlipThreshold;
    public float SlipSpeedModifier;
    public float SlipAngle;

}