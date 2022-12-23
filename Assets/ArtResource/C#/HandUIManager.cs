using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class HandUIManager : MonoBehaviour
{
    Quaternion deviceRot= Quaternion.identity;
    bool priButton = false;

    [SerializeField]CanvasGroup canvasGroup;
    [SerializeField]XRRayInteractor rayInteractorL;
     XRInteractorLineVisual xRInteractorLineVisualL;

    [SerializeField] XRRayInteractor rayInteractorR;
    XRInteractorLineVisual xRInteractorLineVisualR;


    [SerializeField] XRDirectInteractor directInteractorL;



    RaycastHit hit;





    // Start is called before the first frame update
    void Start()
    {
        xRInteractorLineVisualL = rayInteractorL.GetComponent<XRInteractorLineVisual>();
        xRInteractorLineVisualR = rayInteractorR.GetComponent<XRInteractorLineVisual>();

       

    }

    private void SetInteractorLineColorAlpha(XRInteractorLineVisual LineVisual,float startAlpha,float endAlpha)
    {
        GradientAlphaKey gradientAlphaKey0 = new GradientAlphaKey { alpha = startAlpha, time = 0f };
        GradientAlphaKey gradientAlphaKey1 = new GradientAlphaKey { alpha = endAlpha, time = 1f };

        GradientColorKey gradientColorKey0 = new GradientColorKey { color = Color.white, time = 0f };
        GradientColorKey gradientColorKey1 = new GradientColorKey { color = Color.white, time = 1f };

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2] { gradientAlphaKey0, gradientAlphaKey1 };
        GradientColorKey[] colorKeys = new GradientColorKey[2] { gradientColorKey0, gradientColorKey1 };

        LineVisual.invalidColorGradient.SetKeys(colorKeys, alphaKeys);
    }

    // Update is called once per frame
    void Update()
    {
        //InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.deviceRotation, out deviceRot);

        //InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.triggerButton, out priButton);


        //if (rayInteractorR.TryGetCurrent3DRaycastHit(out hit))
        //{
        //}



        float uiViewAngle = Vector3.Dot(transform.up,Camera.main.transform.forward);
        if (uiViewAngle > 0.8f && uiViewAngle <= 1.0f)
        {
            float t  = remap(0.8f,1f,0f,1f, uiViewAngle);
            canvasGroup.alpha = t;
            rayInteractorL.enableUIInteraction = false;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            SetInteractorLineColorAlpha(xRInteractorLineVisualL,0,0);
        }
        else
        {
            canvasGroup.alpha = 0f;
            rayInteractorL.enableUIInteraction = true;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            SetInteractorLineColorAlpha(xRInteractorLineVisualL,100f/255f,0f);
        }

      
       
    }


    float remap01(float a, float b, float t)
    {
        return (t - a) / (b - a);
    }

    float remap(float a, float b, float c, float d, float t)
    {
        return remap01(a, b, t) * (d - c) + c;
    }
}
