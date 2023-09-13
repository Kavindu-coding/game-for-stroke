using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float moveingSpeed = 1;
    private int count;
    public TMP_Text countText;
    public TMP_Text wintext;
    public Transform respawnPoint;
    public float delayBeforeLoading = 2.0f; // Adjust the delay time as needed

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        wintext.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("fails");
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        /*if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("space press");
            //rb.AddForce(Vector3.right * movespeed, ForceMode.Impulse);
            rb.AddForce(Vector3.forward * 2, ForceMode.Impulse);
            Debug.Log("space pressed");

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("space press");
            //rb.AddForce(Vector3.right * movespeed, ForceMode.Impulse);
            rb.AddForce(Vector3.back * 2, ForceMode.Impulse);
            Debug.Log("space pressed");

        }*/


    }  // for testing

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
            StartCoroutine(LoadSceneWithDelay());
        }
    }

    IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoading);
        SceneManager.LoadScene("New Scene");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }

    // for hand movements
    public void movement(int num)
    {
        if (num == 1)
        {            
            rb.AddForce(Vector3.forward * moveingSpeed, ForceMode.Impulse);
            Debug.Log("forward");
        }
        if (num == 2)
        {          
            rb.AddForce(Vector3.back * moveingSpeed, ForceMode.Impulse);
            Debug.Log("back");
        }
        if (num == 3)
        {
            rb.AddForce(Vector3.left * moveingSpeed, ForceMode.Impulse);
            Debug.Log("left");
        }
        if (num == 4)
        {
            rb.AddForce(Vector3.right * moveingSpeed, ForceMode.Impulse);
            Debug.Log("right");
        }
    }

}
