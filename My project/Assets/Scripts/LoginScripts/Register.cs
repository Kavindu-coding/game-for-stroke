using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField usernameInput;
    public InputField userInitialsInput;
    public InputField userAgeInput;
    public InputField emailInput;
    public InputField passwordInput;
    public Button submitButton;
    
    void Start()
    {
        submitButton.onClick.AddListener(() => {
            StartCoroutine(main.Instance.Web.Register(usernameInput.text, userInitialsInput.text, userAgeInput.text, emailInput.text , passwordInput.text));
        });
    }

   
}
