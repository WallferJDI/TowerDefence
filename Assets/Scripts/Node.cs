using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    private bool placeable = true;

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
        if (placeable)
        {

            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            Instantiate(turretToBuild, gameObject.transform.position + positionOffset, gameObject.transform.rotation);
            placeable = false;
            hoverColor = Color.red;
        }
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
