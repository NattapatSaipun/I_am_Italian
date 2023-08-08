using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkbox : MonoBehaviour
{
    public MissCheck missCheck;
    // Start is called before the first frame update
    void Start()
    {
      missCheck.totalMiss = 0;
      missCheck.missCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(missCheck.totalMiss);
    }
}
