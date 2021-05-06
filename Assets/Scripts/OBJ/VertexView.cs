using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class VertexView : MonoBehaviour
{
    public static VertexView startVertex;
    public static VertexView destinationVertex;

    public Material defaultMaterial;
    public Material startMaterial;
    public Material destinationMaterial;
    public Material pathMaterial;

    [HideInInspector]
    public TestNode testNode;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(MouseOver)
            {
                print("Start: " + name);
                if(destinationVertex==this)
                {
                    destinationVertex.meshRenderer.material = defaultMaterial;
                    destinationVertex = null;
                }
                
                if(startVertex!=null)
                {
                    startVertex.meshRenderer.material = defaultMaterial;
                }

                startVertex = this;
                meshRenderer.material = startMaterial;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (MouseOver)
            {
                print("Destination: " + name);
                if(startVertex==this)
                {
                    startVertex.meshRenderer.material = defaultMaterial;
                    startVertex = null;
                }

                if (destinationVertex != null)
                {
                    destinationVertex.meshRenderer.material = defaultMaterial;
                }

                destinationVertex = this;
                meshRenderer.material = destinationMaterial;
            }
        }
    }

    public Material material
    {
        get
        {
            return meshRenderer.material;
        }
        set
        {
            meshRenderer.material = value;
        }
    }

    public void SetAsPath()
    {
        if (startVertex == this || destinationVertex == this) return;

        meshRenderer.material = pathMaterial;
    }


    private bool MouseOver
    {
        get
        {
            Ray ray = PathfindingDemoCameraManager.pathfindingCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject == gameObject) return true;
            }
            return false;
        }
    }
}
