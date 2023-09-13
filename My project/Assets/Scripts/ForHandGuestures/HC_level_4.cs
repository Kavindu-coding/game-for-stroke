using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HC_level_4 : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject player;
    private PlayerControlthree playerController;

    void Start()
    {
        playerController = player.GetComponent<PlayerControlthree>();
    }

    void Update()
    {


        string data = udpReceive.data;

        if (!string.IsNullOrEmpty(data))
        {
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);

            string[] points = data.Split(',');

            /*for (int i = 0; i < 21; i++)
            {
                float x = 7 - float.Parse(points[i * 3]) / 100;
                float y = float.Parse(points[i * 3 + 1]) / 100;
                float z = float.Parse(points[i * 3 + 2]) / 100;

                //ball.transform.localPosition = new Vector3(x, y, 0);
            }*/

            int initialHandCoordinate_z = -150;
            int initialHandCoordinate_x = 800;

            int middlefingeTopYcoor = int.Parse(points[12 * 3 + 1]);
            int middlefingeBottomYcoor = int.Parse(points[8 * 3 + 1]);
            int middleFingerDiferr = middlefingeTopYcoor - middlefingeBottomYcoor;

            int HandCoordinate_z = int.Parse(points[8 * 3 + 2]);
            int HandCoordinate_x = int.Parse(points[8 * 3]);

            print(middlefingeTopYcoor);
            print(middlefingeBottomYcoor);
            print(middleFingerDiferr);


            int Z_CoorDifference = HandCoordinate_z - initialHandCoordinate_z;
            int X_CoorDifference = HandCoordinate_x - initialHandCoordinate_x;
            //print(HandCoordinate_z);


            if ((Z_CoorDifference < -5) && (Z_CoorDifference > -300))
            {
                playerController.movement(1);
            }

            if ((Z_CoorDifference > 0) && (Z_CoorDifference < 400))
            {
                playerController.movement(2);
            }
            if ((X_CoorDifference < 500) && (X_CoorDifference > 50))
            {
                playerController.movement(3);
            }

            if ((X_CoorDifference < 40) && (X_CoorDifference > -300))
            {
                playerController.movement(4);
            }
            if ((middleFingerDiferr < 20) && (middleFingerDiferr > -25))
            {
                playerController.movement(5);
            }

        }
    }
}
