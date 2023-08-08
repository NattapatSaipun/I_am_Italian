using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LetfHand : MonoBehaviour
{
    public UDPReceive2 uDPReceive2;
    public GameObject letfHand;
    List<float> xList = new List<float>();
    List<float> yList = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = uDPReceive2.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);

        string[] points = data.Split(',');

        //print(points[0]);

        float x = (float.Parse(points[0]) - 720) / 100;
        float y = (float.Parse(points[1]) - 480) / 100;
        xList.Add(x);
        yList.Add(y);

        if (xList.Count > 5)
        {
            xList.RemoveAt(0);
        }
        if (yList.Count > 5)
        {
            yList.RemoveAt(0);
        }

        float xAverage = Queryable.Average(xList.AsQueryable());
        float yAverage = Queryable.Average(yList.AsQueryable());

        Vector3 letfPos = letfHand.transform.localPosition;
        Vector3 letfRot = letfHand.transform.eulerAngles;


        letfHand.transform.localPosition = new Vector3(19.8f - xAverage, 1.443f - yAverage, 13.85f);
        letfHand.transform.eulerAngles = new Vector3(-55.663f, 0, 0);
    }
}
