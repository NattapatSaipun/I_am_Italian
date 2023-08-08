using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MissCheck missCheck;
    
    public GameObject blues;
    public LayerMask layer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * 20;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            Debug.Log("hit");
            missCheck.totalMiss++;
            missCheck.missCount++;
            missCheck.getDamage = true;
            Destroy(blues);
            

            
            
        }
        
    }
    
}
