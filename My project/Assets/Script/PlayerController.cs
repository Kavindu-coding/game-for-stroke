using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody playerRb;
    public float gravityModifier =7;
    public float jumpForce = 1500;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionPartical;
    public ParticleSystem dirtPartical;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;


   
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver == false)
        {
            Debug.Log("Juming using the space");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtPartical.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)


    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtPartical.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            
            //Debug.Log("Game Over ! ");

            //SceneManager.LoadScene("Fail");

            ////
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionPartical.Play();
            dirtPartical.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);

            gameOver = true;
            Physics.gravity /= gravityModifier;
            SceneManager.LoadScene("Fail");   //score sending
        }

    }

    public void Jump()
    {
        if (isOnGround && !gameOver)
        {
            Debug.Log("Juming");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtPartical.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }
}
