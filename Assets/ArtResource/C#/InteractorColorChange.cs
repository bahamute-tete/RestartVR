using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorColorChange :MonoBehaviour
{
    [SerializeField] Color ColHoverExit = Color.white;
    [SerializeField] Color ColHoverEnter = Color.red;
    [SerializeField] Color ColSelectExit = Color.white;
    [SerializeField] Color ColSelectEnter = Color.red;
    MeshRenderer meshRender;
    MaterialPropertyBlock block;
    static int ColorID = Shader.PropertyToID("_BaseColor");

    private void Start()
    {
        block = new MaterialPropertyBlock();
        meshRender = GetComponent<MeshRenderer>();
    }

    public void ColorChangeHoverEnter()
    {
        block.SetColor(ColorID, ColHoverEnter);
        meshRender.SetPropertyBlock(block);
    }


    public void ColorChangeHoverExit()
    {
        block.SetColor(ColorID, ColHoverExit);
        meshRender.SetPropertyBlock(block);
    }

    public void ColorChangeSelectEnter()
    {
        block.SetColor(ColorID, ColSelectEnter);
        meshRender.SetPropertyBlock(block);
    }


    public void ColorChangeSelectExit()
    {
        block.SetColor(ColorID, ColSelectExit);
        meshRender.SetPropertyBlock(block);
    }
}
