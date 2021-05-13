using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turet : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    private float range;
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
       

        //turetUp.transform.LookAt(target);
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
