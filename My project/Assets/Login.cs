using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Login : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;
    public Button createNewUser;

    void Start()
    {
        loginButton.onClick.AddListener(() => {
            StartCoroutine(main.Instance.Web.Login(usernameInput.text, passwordInput.text)) ;
        });

        createNewUser.onClick.AddListener(() =>
        {

        });
        
    }

   
}
