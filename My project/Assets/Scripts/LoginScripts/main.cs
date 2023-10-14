using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public static main Instance;
    public Web Web;
    public userInfo UserInfo;
    public Login Login;
    public GameObject UserProfile;
    void Start()
    {
       Instance = this;
       Web = GetComponent<Web>();
       UserInfo = GetComponent<userInfo>();
    }

}
