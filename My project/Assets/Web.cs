using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;



public class Web : MonoBehaviour 
{
    // Start is called before the first frame update
        void Start()
        {
        //StartCoroutine(GetDate());
        //StartCoroutine(GetUsers());
        //StartCoroutine(Login("testuser2", "23456"));
        StartCoroutine(Register("testuser3", "34567", "madhawipathum@gmail.com"));
        }

        IEnumerator GetDate()
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost/GameForStroke/GetDate.php"))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                if(webRequest.isNetworkError || webRequest.isHttpError)
                {
                    UnityEngine.Debug.Log(webRequest.error);
                }
else
                {
                    UnityEngine.Debug.Log(webRequest.downloadHandler.text);
                    byte[] results = webRequest.downloadHandler.data;
                }
            }
        }

    public IEnumerator GetUsers()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost/GameForStroke/GetUsers.php"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                UnityEngine.Debug.Log(webRequest.error);
            }
            else
            {
                UnityEngine.Debug.Log(webRequest.downloadHandler.text);
                byte[] results = webRequest.downloadHandler.data;
            }
        }
    }

    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/GameForStroke/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                UnityEngine.Debug.Log(www.error);
            }
            else
            {
                UnityEngine.Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator Register(string username, string password, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPassword", password);
        form.AddField("insertEmail", email);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/GameForStroke/Register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                UnityEngine.Debug.Log(www.error);
            }
            else
            {
                UnityEngine.Debug.Log(www.downloadHandler.text);
            }
        }
    }




}
