using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetLevel : MonoBehaviour
{
    public void retryIndex()
    {
        SceneManager.LoadScene("indexFinger");
    }
    public void retryMiddle()
    {
        SceneManager.LoadScene("middleFinger");
    }
    public void retryRing()
    {
        SceneManager.LoadScene("ringFInger");
    }
    public void retrySmall()
    {
        SceneManager.LoadScene("smallFinger");
    }
    public void retryThumb()
    {
        SceneManager.LoadScene("thumbFinger");
    }
}
