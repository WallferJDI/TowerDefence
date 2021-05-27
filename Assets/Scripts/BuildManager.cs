using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    
  
    private GameObject turetPrefab;
    private void Awake()
    {
        if (instance != null) { 
            Debug.LogError("Build Manager Eror");
            return;
        }
        instance = this;

    }
   
    
    public GameObject standartTuret;
    private void Start()
    {
        turetPrefab = standartTuret;
    }
    public GameObject GetTurretToBuild()
    {
        return turetPrefab;
    }
}
