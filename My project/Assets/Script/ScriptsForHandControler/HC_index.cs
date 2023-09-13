using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HC_index : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject player;
    private PlayerController playerController;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        string data = udpReceive.data;

        if (!string.IsNullOrEmpty(data))
        {
            Debug.Log("code workingggggggggggggggg");
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);

            string[] points = data.Split(',');

            int IndexFingerTopCoordinate = int.Parse(points[8 * 3 + 1]);
            int IndexFingerBottomCoordinate = int.Parse(points[5 * 3 + 1]);

            int CoorDifference = IndexFingerTopCoordinate - IndexFingerBottomCoordinate;

            bool autoPressButton = false;// Check if autoPressButton is true and trigger the jump

            if (CoorDifference > 50)
            {
                autoPressButton = true;
            }
            else
            {
                autoPressButton = false;
            }

            Debug.Log(CoorDifference);
            
            if (autoPressButton)
            {
                playerController.Jump();
               


            }
            
        }
    }
}