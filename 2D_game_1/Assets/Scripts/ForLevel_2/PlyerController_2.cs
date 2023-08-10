using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlyerController_2 : MonoBehaviour
{
    private AudioSource auds;
    private Rigidbody2D rbody;
    public float speed=100 ;
    public float count;
    public TextMeshProUGUI countText;
  
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        auds = GetComponent<AudioSource>();
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        rbody.AddForce(new Vector2(horizontalInput, verticalInput)*speed);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("pickUp"))
        {
            Destroy(target.gameObject);
            countShow();
            auds.Play();
            Debug.Log("ghh");
        }
    }

    void countShow()
    {
        countText.text = count.ToString();
        count++;
        if (count == 21)
        {
            SceneManager.LoadScene("EndLevel");
        }

    }

}


