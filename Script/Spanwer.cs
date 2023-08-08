using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanwer : MonoBehaviour
{
    public GameObject[] cubeRed;
    public GameObject[] cubeBlue;
    public Transform[] pointRed;
    public Transform[] pointBlue;
    public float beat;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        beat = (60 / beat) * 2;
        Debug.Log(beat);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>beat)
        {
            GameObject cubeR = Instantiate(cubeRed[Random.Range(0, 4)], pointRed[Random.Range(0,2)]);
            GameObject cubeB = Instantiate(cubeBlue[Random.Range(0, 4)], pointBlue[Random.Range(0, 2)]);
            cubeR.transform.localPosition = Vector3.zero;
            cubeB.transform.localPosition = Vector3.zero;
            timer -= beat;
           
        }
        timer += Time.deltaTime; 
    }
}
