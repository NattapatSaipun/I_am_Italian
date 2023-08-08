using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    [SerializeField]
    public float hpPoint;
    public float curHealt;
    public float maxHealth;
    public bool isHit = false;


    public Image healtbar;
    public Combo combo;
    
    
    private int curMiss;
    private int damage = 5;
    private int recovery = 1;


    public MissCheck missCheck;

    private void Start()
    {
        curHealt = maxHealth;
        curMiss = missCheck.totalMiss;
        hpPoint = curHealt;
       
    }

    private void Update()
    {
        if (missCheck.getDamage)
        { 
            curMiss = missCheck.totalMiss;
            combo.comboCount = 0;
            if (curMiss == 1) 
            { 
                curHealt -= damage;
                healtbar.fillAmount = curHealt / maxHealth;
                hpPoint = curHealt;
                
                missCheck.totalMiss = 0;
            }
            
            if(curMiss>1)
            {
                damage = 10;
                if(damage == 10)
                {
                    curHealt -= damage;
                    healtbar.fillAmount = curHealt / maxHealth;
                
                    
                    hpPoint = curHealt;
                    missCheck.totalMiss = 0;
                    damage = 5;
                }
                
            }
            missCheck.getDamage = false;
        }
        if(isHit)
        {
            curHealt += recovery;
            healtbar.fillAmount = curHealt / maxHealth;
            hpPoint = curHealt;
            isHit = false;
        }
        if(curHealt>maxHealth)
        {
            curHealt = maxHealth;
            hpPoint = curHealt;
        }

        

    }
}
