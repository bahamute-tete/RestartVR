using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ShowBoxAssets : ScriptableObject
{
    [Serializable]
    public struct ShowBox
    {
        public int ItemID;
        public GameObject contentItem;
        public Color boxLightColor;
        public string ItemName;
        public string ItemPrice;
    }
    public ShowBox[] showBoxes;
}


