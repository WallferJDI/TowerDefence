using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turet : MonoBehaviour
{
    private Transform target;
    [Header("Attributes")]

    [SerializeField]
    private float range;
    [SerializeField]
    private float bulletRate = 1f;
    private float bulletCountDown = 1f;
    
    [Header("Setup Fields")]

    public GameObject bulletPrefab;
    public Transform firePoint;
    [SerializeField]
    private string enemyTag = "Enemy";
    public float rotationSpeed = 10f;
    public Transform partForRotation;

    

    void Start()
    {
        InvokeRepeating("searchTarget", 0f, 0.5f);
    }
    
     void Update()
    {
        LookAt();
        if (bulletCountDown <= 0f)
        {
            Shoot();
            bulletCountDown = 1f / bulletRate;
        }
        bulletCountDown -= Time.deltaTime;
    }
   
    void Shoot()
    {
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet Bullet = bulletGameObject.GetComponent<bullet>();
        if(Bullet != null)
            Bullet.Seek(target);
    }
    void LookAt()
    {
        if (target == null)
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partForRotation.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        partForRotation.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    
    void searchTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
            target = nearestEnemy.transform;
        else
            target = null;


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
