using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject hitVFXPrefab;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int damage = 1;

    StarterAssetsInputs starterAssetsInputs;

    const string SHOOT_STRING = "Shoot";
    
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();    
    }

    void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;
        
        muzzleFlash.Play();
        animator.Play(SHOOT_STRING, 0, 0f);
        starterAssetsInputs.ShootInput(false);
        
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {   
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damage);

            Instantiate(hitVFXPrefab, hit.point, Quaternion.identity);
        }
    }
}
