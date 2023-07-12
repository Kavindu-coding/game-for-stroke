using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Difficultybutton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    private GameManager gameManager;
    public float difficulty;
    //private GameManager
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetDifficulty()
    {
       // Debug.Log(button.gameObject.name + "was clicked");
        gameManager.StartGame(difficulty);
    }
}
