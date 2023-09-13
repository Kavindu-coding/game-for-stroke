using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backMainmenue : MonoBehaviour
{
    public void back()
    {
        SceneManager.LoadScene("first_page");
    }
}
