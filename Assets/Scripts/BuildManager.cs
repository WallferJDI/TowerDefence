using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    
    [SerializeField]
    private GameObject turetPrefab;
    private void Awake()
    {
        if (instance != null) { 
            Debug.LogError("Build Manager Eror");
            return;
        }
        instance = this;

    }
   
    [SerializeField]
    private GameObject standartTuret;
    private void Start()
    {
        turetPrefab = standartTuret;
    }
    public GameObject GetTurretToBuild()
    {
        return turetPrefab;
    }
}
