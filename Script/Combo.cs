using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{
    public GameObject combo;
    public Text comboText;
    public int comboCount = 0;

    public int maxCombo;
    // Start is called before the first frame update
    void Start()
    {
        combo.SetActive(false);
        maxCombo = comboCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(comboCount>1)
        {
            combo.SetActive(true);
            comboText.text = "Combo"+"\n"+"X"+comboCount.ToString();
            if(maxCombo<=comboCount)
            {
                maxCombo = comboCount;
            }
        }
        else
        {
            combo.SetActive(false);
        }
        
    }
}
