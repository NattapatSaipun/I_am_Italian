using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedStick : MonoBehaviour
{
    public LayerMask layer;
    public Hpbar hpbar;
    public int score = 0;
    public Combo combo;
    // private Vector3 previousPos;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            Destroy(hit.transform.gameObject);

            score++;
            combo.comboCount++;
            hpbar.isHit = true;
        }
        // previousPos = transform.position;
    }
}
