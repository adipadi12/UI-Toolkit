using System.Threading;
using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    private int hitCount = 0;
    void Update()
    {
        Color newColor = Random.ColorHSV();
        
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //gets mouse position by emitting ray
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) //checks if it hits a cube
            {
                hitCount++;
                
                MeshRenderer renderer = hit.collider.gameObject.GetComponent<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.material.color = newColor;
                    if (hitCount == 2)
                    {
                        Destroy(hit.collider.gameObject);
                        hitCount = 0;
                    }
                }
            }
        }
    }
}
