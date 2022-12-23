using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



using UnityEngine.XR;

using UnityEngine.XR.Interaction.Toolkit;


public class PictureManager : MonoBehaviour
{
    public delegate void ChangeScorllBar();
    public event ChangeScorllBar OnChangeScorllbarValue;


    [SerializeField] Canvas canvas;
    [SerializeField]GameObject DisplayPannel;
    [SerializeField] Scrollbar scrolbar;
    [SerializeField] GameObject authorPannel;


    Vector2 primary2DAxisValue_R, primary2DAxisValue_L;
    bool triggerButtonValue_R, triggerButtonValue_L;
    bool gripButtonValue_R, gripButtonValue_L;

    ActionBasedController rController;
    ActionBasedController lController;

    private void Awake()
    {
        
        canvas.worldCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        rController = GameObject.Find("RightHand (Teleport Locomotion)").GetComponent<ActionBasedController>();
        lController = GameObject.Find("LeftHand (Smooth locomotion)").GetComponent<ActionBasedController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        DisplayPannel.SetActive(false);
        authorPannel.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
      
        InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonValue_R);
        InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.gripButton, out gripButtonValue_R);

        InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonValue_L);
        InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.gripButton, out gripButtonValue_L);

        if (DisplayPannel.activeSelf && gripButtonValue_R)
        {

            if (triggerButtonValue_R == false)
            {
                rController.enableInputActions = false;
                lController.enableInputActions = false;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxisValue_R);
                scrolbar.value += primary2DAxisValue_R.y * 0.01f;
                scrolbar.value = Mathf.Clamp01(scrolbar.value);
            }


        }
        else
        if (DisplayPannel.activeSelf && gripButtonValue_L)
        {
            if (triggerButtonValue_L == false)
            {
                lController.enableInputActions = false;
                rController.enableInputActions = false;
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxisValue_L);
                scrolbar.value += primary2DAxisValue_L.y * 0.01f;
                scrolbar.value = Mathf.Clamp01(scrolbar.value);
            }
        }
        else
        {
            lController.enableInputActions = true;
            rController.enableInputActions = true;
        }
    }



    public void  ShowIntroPannel()
    {
        DisplayPannel.SetActive(true);
        authorPannel.SetActive(true);
    }


    public void HideIntroPannel()
    {
        DisplayPannel.SetActive(false);
        authorPannel.SetActive(false);
    }



}
