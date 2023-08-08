using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lp : MonoBehaviour
{
    public Text lp;
    public Hpbar hpbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lp.text = (hpbar.hpPoint).ToString();
        if(hpbar.hpPoint <= 0)
        {
            lp.text = (0).ToString();
        }
        else lp.text = (hpbar.hpPoint).ToString();
    }
}
