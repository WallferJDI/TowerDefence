using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public GameObject turet;
    private Color startColor;
    private Renderer rend;
    private bool placeable = true;
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
        building();
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    void building()
    {
        if (placeable)
        {
            Instantiate(turet, gameObject.transform.position + new Vector3(0,0.5f,0), gameObject.transform.rotation);
            placeable = false;
            hoverColor = Color.red;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
