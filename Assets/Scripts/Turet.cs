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

    public GameObject turetUp;
    void Start()
    {
        InvokeRepeating("searchTarget", 0f, 0.5f);
    }
    void searchTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
         foreach(GameObject enemy in enemies)
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
     void Update()
    {
        if (target == null)
            return;


        //turetUp.transform.LookAt(target);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
