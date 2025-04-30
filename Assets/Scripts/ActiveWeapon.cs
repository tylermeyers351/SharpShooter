using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    
    
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;

    float cooldownTimer;
    float currentTime;

    const string SHOOT_STRING = "Shoot";
    
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        cooldownTimer = weaponSO.FireRate;
        currentTime = cooldownTimer;
    }

    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        HandleShoot();
    }

    void HandleShoot()
    {
        if (currentTime < cooldownTimer) return;

        if (!starterAssetsInputs.shoot) return;
        
        currentWeapon.Shoot(weaponSO);
        animator.Play(SHOOT_STRING, 0, 0f);
        currentTime = 0;
        
        starterAssetsInputs.ShootInput(false);
    }
}
