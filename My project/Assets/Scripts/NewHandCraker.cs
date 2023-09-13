using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHandCraker : MonoBehaviour
{

    public UDPReceive udpReceive;
    public GameObject ball;
    public float xchange = 1;
    public float ychange = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;

        

        if (!string.IsNullOrEmpty(data))
        {
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);
            print(data);


            string[] points = data.Split(',');
            


            float xx = ((-1*xchange) * float.Parse(points[9 * 3])/25250)+20 ; // 9 is the point of alla
            float yy = (ychange * float.Parse(points[9 * 3 + 1])/18400)-12 ;

            print(xx);
            print(yy);


            float xcordinate;
            float ycordinate;

            if((xx<=15 && xx >= -12) && (yy <= 15 && yy >= -15))
            {
                xcordinate = xx;
                ycordinate = yy;
            }
            else
            {
                xcordinate = 2;
                ycordinate = -1;

            }

            /*for (int i = 0; i < 21; i++)
            {
                float x = 7 - float.Parse(points[i * 3]) / 100;
                float y = float.Parse(points[i * 3 + 1]) / 100;
                float z = float.Parse(points[i * 3 + 2]) / 100;

                //ball.transform.localPosition = new Vector3(x, y, 0);
            }*/

           ball.transform.position = new Vector3(xcordinate, ycordinate, 0);
           //transform.position = new Vector3(xx, yy, 0);
        }
    }
}
