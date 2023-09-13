using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveIndex : MonoBehaviour
{
   
    public void OpenSceneIndex()
    {                
        SceneManager.LoadScene("IndexFinger");        
    }
    public void OpenSceneMiddle()
    {
        SceneManager.LoadScene("middleFinger");
    }
    public void OpenSceneRing()
    {
        SceneManager.LoadScene("ringFinger");
    }
    public void OpenSceneSmall()
    {
        SceneManager.LoadScene("smallFinger");
    }
    public void OpenSceneThumb()
    {
        SceneManager.LoadScene("thumbFinger");

    }
}
