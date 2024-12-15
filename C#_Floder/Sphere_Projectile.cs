using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sphere_Projectile : MonoBehaviour
{
    public GameObject piace;
    public int MinPiaceCount = 3;
    public int MaxPiaceCount = 8;
    
    
    private void OnTriggerEnter(Collider other)
    {
        
        Vector3 hitDirection = GetComponent<Rigidbody>().velocity * -1 ;

        int count = Random.Range(MinPiaceCount, MaxPiaceCount + 1);

        for (int i = 0; i < count; ++i)
        {
            Vector3 randomDiretion = Random.insideUnitSphere;
            Vector3 lastDiretion = Quaternion.LookRotation(randomDiretion) 
                                   * hitDirection;
        
            GameObject instance = Instantiate(piace, transform.position,
                Quaternion.LookRotation(lastDiretion));

            instance.GetComponent<Rigidbody>().AddForce(lastDiretion, ForceMode.Impulse);
            Destroy(this.gameObject);
        }
        
       
    }
}
