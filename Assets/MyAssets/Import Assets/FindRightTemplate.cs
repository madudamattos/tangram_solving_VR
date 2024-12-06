using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRightTemplate : MonoBehaviour
{
    private GameObject templatePiece;
    private Material currentMaterial;
    private Rigidbody rb;

    [SerializeField] Material highlightMaterial;

    string pieceName;
    string templateName = "";

    // Start is called before the first frame update
    void Start()
    {
        GetTemplate();

        rb = this.GetComponent<Rigidbody>();
    }

    void GetTemplate()
    {
        string pieceNumber;
        pieceName = this.gameObject.name;
        
        pieceNumber = pieceName.Substring((pieceName.Length - 3), 3);
        templateName = "Gabarito" + "." + pieceNumber;

        templatePiece = GameObject.Find(templateName);
    }

    public void HighLightTemplate()
    {
        Renderer templateRenderer = templatePiece.GetComponent<Renderer>();
        currentMaterial = templateRenderer.material;
        templateRenderer.material = highlightMaterial;
 
    }

    public void ChangeBackMaterial()
    {
        Renderer templateRenderer = templatePiece.GetComponent<Renderer>();
        templateRenderer.material = currentMaterial;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == templateName)
        {
            if (!rb.isKinematic)
            {
                this.transform.position = templatePiece.transform.position;
                this.transform.rotation = templatePiece.transform.rotation;
                rb.isKinematic = true;
            }

            if (rb.isKinematic)
            {
                templatePiece.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            

        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == templateName)
        {
            rb.isKinematic = false;
            templatePiece.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }


    /*
    void OnTriggerStay(Collider col)
    {
        if(!rb.isKinematic)
        {
            templatePiece.gameObject.SetActive(true);
        }
    }
    */

}
