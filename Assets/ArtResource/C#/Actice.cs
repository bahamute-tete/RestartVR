using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actice : MonoBehaviour
{

    [SerializeField] GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activated()
    {
        gameObject.GetComponent<Renderer>().sharedMaterial.color = Color.green;
    }

    public void Deactived()
    {
        gameObject.GetComponent<Renderer>().sharedMaterial.color = Color.red;
    }
}
