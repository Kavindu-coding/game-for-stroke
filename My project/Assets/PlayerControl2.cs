using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl2 : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int count;
    public TMP_Text countText;
    public TMP_Text wintext;
    public Transform respawnPoint;
    //public MenuController menuController;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        wintext.gameObject.SetActive(false);

    }

    /* private void Update()
     {
         if(transform.position.y < -10)
         {
             Respawn();
         }
     } */
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = " Score : " + count.ToString();

        if (count >= 12)
        {
            wintext.gameObject.SetActive(true);
            SceneManager.LoadScene("Level 1");
            // menuController.WinGame();
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Respawn ();
       //EndGame();
    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }*/


}
