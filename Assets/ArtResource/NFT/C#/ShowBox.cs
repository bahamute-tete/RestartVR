using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ShowBox : MonoBehaviour
{
    public ShowBoxAssets ShowBoxAssets;
    public int ItemID;
   
    [SerializeField] Transform anchorPoint;
    [SerializeField] GameObject[] emitLinePoints;
    

    [SerializeField] float lineThickness;

    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemPrice;
    // Start is called before the first frame update
    void Start()
    {
       

        int Index = Array.FindIndex(ShowBoxAssets.showBoxes, (x => x.ItemID == ItemID));



     
        GameObject obj = Instantiate(ShowBoxAssets.showBoxes[Index].contentItem, anchorPoint.transform.position, anchorPoint.transform.rotation, anchorPoint);

        for (int i = 0; i < emitLinePoints.Length; i++)
        {
            emitLinePoints[i].GetComponent<BasePointConnect>().lineColor = ShowBoxAssets.showBoxes[Index].boxLightColor;
            emitLinePoints[i].GetComponent<BasePointConnect>().lineWidth = lineThickness;

        }


        itemName.text= ShowBoxAssets.showBoxes[Index].ItemName;
        itemPrice.text = "  €º€:"+ ShowBoxAssets.showBoxes[Index].ItemPrice+ "£§";

        itemName.color = itemPrice.color = ShowBoxAssets.showBoxes[Index].boxLightColor;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
