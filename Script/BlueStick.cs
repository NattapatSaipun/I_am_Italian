using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueStick : MonoBehaviour
{
    public LayerMask layer;
    public int score = 0;
    public RedStick redStick;
    public Hpbar hpbar;
    public Combo combo;
    public int total;
   // private Vector3 previousPos;

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit,1, layer))
        {
            Destroy(hit.transform.gameObject);
            
            score++;
            combo.comboCount++;
            hpbar.isHit = true;           
        }
        // previousPos = transform.position;
        total = redStick.score + score;
    }
}
