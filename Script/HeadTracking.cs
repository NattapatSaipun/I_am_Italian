using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeadTracking : MonoBehaviour
{
    public UDPReceive uDPReceive;
    public GameObject cameraObject;
    public GameObject box;
    List<float> xList = new List<float>();
    List<float> yList = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = uDPReceive.data;// Get Data

        // (remove first data.Length, remove 1 value);
        data = data.Remove(0, 1);


        //(remove last data.Length, remove 1 value); data.Length count from 0,1,2,3.....
        data = data.Remove(data.Length-1,1);


        // remove ',' and make points[] for 2 part of data (x,y);
        string[] points = data.Split(','); 


        float x = (float.Parse(points[0])-720)/100;//decode for unity position x
        float y = (float.Parse(points[1])-480)/100;//decode for unity position y

        // Smoot Detection
        //step1 : add x and y to xList and yList
        xList.Add(x);
        yList.Add(y);

        //step2 : Count xList and yList for make if Conditional 
        if (xList.Count > 50)
        {
            xList.RemoveAt(0);// remove first value for looping Conditional
        }
        if(yList.Count > 50)
        {
            yList.RemoveAt(0);// remove first value for looping Conditional
        }

        //step3 : Average all value in xList and yList for smoot position
        float xAverage = Queryable.Average(xList.AsQueryable());
        float yAverage = Queryable.Average(yList.AsQueryable());

        Vector3 cameraPos = cameraObject.transform.localPosition;
        Vector3 cameraRot = cameraObject.transform.eulerAngles;
        Vector3 boxPos = box.transform.localPosition;


        //step4 : put it in Object position
        cameraObject.transform.localPosition = new Vector3(boxPos.x - xAverage, 1.9f- yAverage, cameraPos.z);
        cameraObject.transform.eulerAngles = new Vector3(0- yAverage * 10, xAverage * 10f, 0);
        
    }
}
