using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float fireRate = 2f;

    PlayerHealth player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(fireRoutine());
    }   

    void Update()
    {
        turretHead.LookAt(playerTargetPoint.position);
    }

    IEnumerator fireRoutine()
    {
        while(player)
        {
            yield return new WaitForSeconds(fireRate);
            Instantiate(projectilePrefab, projectileSpawnPoint.position, turretHead.rotation);
        }
    }
}
