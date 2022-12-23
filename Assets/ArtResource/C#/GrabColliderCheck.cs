using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabColliderCheck : MonoBehaviour
{

    public delegate void GrabColliderCheckDelegate(Collision collision);
    public event GrabColliderCheckDelegate OnGrabCheck;


    XRGrabInteractable grabInteractable;
    [SerializeField] XROrigin xROrgin;

    bool isSelect = false;
    // Start is called before the first frame update
    void Start()
    {
        xROrgin = GameObject.Find("XR Origin").GetComponent<XROrigin>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.white);

    }

    // Update is called once per frame
    void Update()
    {
        if (isSelect)
        {
            GrapDistanceCheck();
        }
    }

    private void GrapDistanceCheck()
    {
      
        Vector3 worldPos = gameObject.transform.position;
        Vector3 CenterPos = xROrgin.Camera.transform.position;
        Vector3 v = worldPos - CenterPos;
        float distanceH = new Vector2(v.x, v.z).magnitude;

        //Debug.Log($"distanceH =={distanceH}");
        if (distanceH <= 0.25f)
        {
            grabInteractable.movementType = XRBaseInteractable.MovementType.VelocityTracking;
        }
        else
        {
            grabInteractable.movementType = XRBaseInteractable.MovementType.Instantaneous;
        }
    }




    public void ColliderCheckSelect()
    {
        isSelect = true;
        Debug.Log(isSelect);
    }

    public void ColliderCheckDeSelect()
    {
        isSelect = false;
        Debug.Log(isSelect);
    }


}
