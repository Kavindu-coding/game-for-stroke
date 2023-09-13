using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Controls : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text flagText;
    // Start is called before the first frame update
    public float speed;
    private int count = 0;
    public Transform respawnPoint;


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        flagText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(transform.position.y < -10)
        {
            Respawn();
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);

            count++;
            SetCountText() ;
        }
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Respawn() ;
        }
    }

    void SetCountText()
    {
        countText.text = "Score : " + count.ToString();

        if (count >= 12)
        {
            flagText.gameObject.SetActive(true);
        }
    }


    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }
}
