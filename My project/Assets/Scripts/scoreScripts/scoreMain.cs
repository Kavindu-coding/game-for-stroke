using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreMain : MonoBehaviour
{
    public static scoreMain Instance;
    public Web Web;
 
    void Start()
    {
        Instance = this;
        Web = GetComponent<Web>();
       
    }

}
