using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class ActivateObjects : MonoBehaviour
{
    public Transform tangramRefPosition;

    public GameObject tangram;

    Vector3 anchorCenter;
    Quaternion anchorRotation;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitializeAfterSceneLoad());
    }

    IEnumerator InitializeAfterSceneLoad()
    {
        yield return new WaitForSeconds(1f);
        InitializeObjects();
    }

    void InitializeObjects()
    {
        var rooms = MRUK.Instance.GetCurrentRoom().GetRoomAnchors();

        foreach (var anchor in rooms)
        {
            if (anchor.gameObject.name == "TABLE")
            {
                anchorCenter = anchor.GetAnchorCenter();
                anchorRotation = anchor.transform.rotation;

                this.transform.position = anchorCenter;
                this.transform.rotation = anchorRotation;
                InitializeSceneObjects();

                break;
            }
        }


    }

    void InitializeSceneObjects()
    {
        // Adjust the pieces to the right position

        tangram.transform.position = new Vector3(tangramRefPosition.position.x, tangramRefPosition.position.y + 0.1f, tangramRefPosition.position.z);
        //tangram.transform.rotation = anchorRotation;   

        int pieces = tangram.transform.childCount;

        for(int i = 0; i< pieces; i++)
        {
            tangram.transform.GetChild(i).gameObject.SetActive(true);
        }

    }

}
