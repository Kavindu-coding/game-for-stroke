using UnityEngine;

public class userInfo : MonoBehaviour
{

    public string userID { get; private set; }
    public string userName;
    public string password;
    public string level;
    

    public void setCredentials(string username, string userPassword)
    {
        userName = username;
        password = userPassword;
    }

    public void SetID(string id)
    {
        userID = id;
    }



}
