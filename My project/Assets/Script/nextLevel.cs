using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void nextGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        //SceneManager.LoadScene("new 11_7 1");
    }
}
