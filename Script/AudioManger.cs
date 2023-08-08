using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public AudioSource audioSource;
    public UDPReceive4 uDPReceive4;
    public StartOK startOK;
    public GameObject complete;
    bool m_IsPlaying = false;

    public GameObject spanw;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Stop();
        complete.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        string data = uDPReceive4.data;
        if (data == "OK" && !m_IsPlaying)
        {
            audioSource.Play();
            m_IsPlaying = true;
        }
        if(!audioSource.isPlaying && m_IsPlaying)
            {
                spanw.SetActive(false);
            }
         if(!audioSource.isPlaying && m_IsPlaying && !startOK.failed)
        {
            spanw.SetActive(false);
            complete.SetActive(true);

        }
    }   
}
