using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagColliderAdd : MonoBehaviour
{
    Cloth flag;
   
    [SerializeField]
    GameObject[] bullets;

    // Start is called before the first frame update
    private void OnEnable()
    {
       
      
    }

    private void OnDisable()
    {
       
    }
    private void Awake()
    {
        flag = GetComponent<Cloth>();
        
    }

    // Update is called once per frame
    void Update()
    {
    

        bullets = GameObject.FindGameObjectsWithTag("Bullet");


        CapsuleCollider[] capsuleColliders = new CapsuleCollider[bullets.Length];


        for (int i = 0; i < bullets.Length; i++)
        {
            capsuleColliders[i] = bullets[i].GetComponent<CapsuleCollider>();
        }

        flag.capsuleColliders = capsuleColliders;

     
    }



}
