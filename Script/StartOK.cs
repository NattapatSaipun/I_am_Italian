using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartOK : MonoBehaviour
{
    public UDPReceive4 uDPReceive4;
    public GameObject no;
    public GameObject ok;
    public GameObject cavasUI;
    public Text title;
    bool start = false;
    public bool failed = false;
    public Hpbar hpbar;
    public AudioSource audioSource;
   

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        ok.SetActive(false);
      
       
    }

    // Update is called once per frame
    void Update()
    {
        string data = uDPReceive4.data;
       if(data == "OK")
        {
            ok.SetActive (true);
            no.SetActive(false);
            start = true;
        }
       if(start)
        {
            cavasUI.SetActive(false);
            Time.timeScale = 1;
            

        }

       if(hpbar.hpPoint <= 0)
        {

            Time.timeScale = 0;
            ok.SetActive(false);
            no.SetActive(false);
            cavasUI.SetActive(true);
            title.text = "Mission Failed";
            audioSource.Stop();
            failed = true;
        }
       
    }
}
