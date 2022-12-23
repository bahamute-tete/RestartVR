using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunController : MonoBehaviour
{
    public delegate void GunControllerDelegate();
    public event GunControllerDelegate OnTriggerFire;

    public delegate void SelectThisGun();
    public event SelectThisGun OnSelected;

    public delegate void UnSelectThisGun();
    public event UnSelectThisGun OnUnSelected;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform emitePoint;
    [SerializeField] float Speed=40f;
    XRGrabInteractable xRGrabInteractable;
    public bool isSelected=false;

    public List<GameObject> bullets= new List<GameObject>();  
    // Start is called before the first frame update


    void Start()
    {
         xRGrabInteractable = GetComponent<XRGrabInteractable>();
         xRGrabInteractable.activated.AddListener(FireBullet);
        


    }

    private void UnSelectGun(HoverExitEventArgs arg0)
    {
        isSelected = false;
      
    }

    private void SelectGun(HoverEnterEventArgs arg0)
    {
        isSelected = true;
     
    }

    private void FireBullet(ActivateEventArgs arg0)
    {
        
        GameObject spawnBullet = Instantiate(bullet, emitePoint.position, emitePoint.rotation);
        spawnBullet.GetComponent<Rigidbody>().velocity = emitePoint.forward * Speed;
      
        Destroy(spawnBullet, 3f);
      
      
    }



    // Update is called once per frame
    void Update()
    {
       
    }
}
