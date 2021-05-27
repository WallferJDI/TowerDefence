using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    private GameObject turet;

    public Vector3 positionOffset;
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
      
    }
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        
    }
    private void OnMouseDown()
    {
        if (turet != null)
        {
            Debug.LogError("You CANT build here");
        }

            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
           turet = (GameObject) Instantiate(turretToBuild, gameObject.transform.position + positionOffset, gameObject.transform.rotation);
            hoverColor = Color.red;
        
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
