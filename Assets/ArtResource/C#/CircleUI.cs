using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CircleUI : MonoBehaviour
{
    [SerializeField] GameObject[] btns;

    VRRoomScenesManager loadManager;

    [SerializeField]GameObject hintText;
    TextMeshProUGUI hintContent;

    CanvasGroup canvasGroup;


    [SerializeField]float distance=0.15f;
    float angelZ =0;

    int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;

        loadManager = GameObject.Find("SceneManager").GetComponent<VRRoomScenesManager>();
        canvasGroup = hintText.GetComponent<CanvasGroup>();
        hintContent = hintText.GetComponentInChildren<TextMeshProUGUI>();


        float step = 360f / btns.Length;
        RectTransform rectTransform= GetComponent<RectTransform>(); ;
        Vector3 ca = rectTransform.rotation.eulerAngles;
        //Debug.Log("ca ==" + ca);

        for (int i = 0; i < btns.Length; i++)
        {


           Quaternion q = Quaternion.Euler(ca + new Vector3(0, 0, angelZ));
            Vector3 pos =rectTransform.position + q * rectTransform.forward*distance;
            GameObject btn = Instantiate(btns[i], pos, rectTransform.rotation, transform);







            if (i == 2)
            {
                if (sceneIndex != 0)
                {
                    btn.GetComponent<Button>().onClick.AddListener(delegate
                    {
                        loadManager.LoadVRroomScenes(0);
                    });
                }
                else
                {
                    btn.GetComponent<Button>().onClick.AddListener(delegate
                    {
                        DisplayHint("您已经在此场景中！");
                    });

                }

            }
            else if (i == 6)
            {
                if (sceneIndex != 1)
                {
                    btn.GetComponent<Button>().onClick.AddListener(delegate
                    {
                        loadManager.LoadVRroomScenes(1);
                    });
                }
                else
                {
                    btn.GetComponent<Button>().onClick.AddListener(delegate
                    {
                        DisplayHint("您已经在此场景中！");
                    });
                }

            }
            else
            {
                btn.GetComponent<Button>().onClick.AddListener(delegate
                {
                    DisplayHint("该功能还为开放！");

                });
            }

            angelZ += step;
           
            
        }

    }

    private void DisplayHint(string hint)
    {
        canvasGroup.alpha = 1f;
        hintContent.text = hint;
        StartCoroutine(FadesAlpha());
    }

    IEnumerator  FadesAlpha ()
    {
        yield return new WaitForSeconds(2f);
        canvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
