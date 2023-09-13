using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Rotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 100);
    }
}
