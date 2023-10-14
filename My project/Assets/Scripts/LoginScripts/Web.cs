using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class Web : MonoBehaviour 
{
    // show items in unity
    public void ShowUserItems()
    {
        StartCoroutine(GetlItemsIDs(main.Instance.UserInfo.userID));
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
                main.Instance.UserInfo.setCredentials(username, password);
                main.Instance.UserInfo.SetID(www.downloadHandler.text);

                if (www.downloadHandler.text.Contains("Wrong credintials.") || www.downloadHandler.text.Contains("Username does not exits."))
                {
                    UnityEngine.Debug.Log("Try again");
                }
                else
                {
                    // if we logged in correctly
                    SceneManager.LoadScene("MainInterface");
                    main.Instance.UserProfile.SetActive(true);
                    //main.Instance.Login.gameObject.SetActive(false);
                }

                
            }
        }
    }

    public IEnumerator Register(string username, string initials, string age, string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("insertInitials", initials);
        form.AddField("insertAge", age);
        form.AddField("insertEmail", email);
        form.AddField("loginPassword", password);
        
        

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
                SceneManager.LoadScene("LoginUI");
            }
        }

    }

    public IEnumerator GetlItemsIDs(string userID)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/GameForStroke/GetlItemsIDs.php",form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                UnityEngine.Debug.Log(webRequest.error);
            }
            else
            {
                //show results as text
                UnityEngine.Debug.Log(webRequest.downloadHandler.text);
                string jsonArray = webRequest.downloadHandler.text;
                //call callback funtion to pass results
            }
        }
    }

    public IEnumerator Game1Score(string level, string score)
    {
        WWWForm form = new WWWForm();
        form.AddField("level", level);
        form.AddField("score", score);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/GameForStroke/Game1Score.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                UnityEngine.Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                UnityEngine.Debug.Log(responseText); // Log the response for debugging purposes

                // Parse the response to check for success or errors
                if (responseText.Contains("Score updated successfully"))
                {
                    UnityEngine.Debug.Log("Score updated successfully!");
                }
                else
                {
                    UnityEngine.Debug.Log("Error updating score: " + responseText);
                }
            }
        }
    }



}
