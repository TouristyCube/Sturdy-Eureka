using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text livesText;
    public Text winText;
    public Text loseText;
    
    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetCountText ();
        SetlivesText();
        

        
    }

   void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {


        other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();


        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetlivesText();
        }
     }
 
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            SceneManager.LoadScene ("Level2"); 
        }

        
        else if (count == 11)
        {
            winText.text = "You win! Game created by Derron DeJesus!";
        }
    }
    void SetlivesText()
    {
        livesText.text = "lives: " + lives.ToString();
        if (lives == 0)

        {
            Destroy(this);
               loseText.text = "You Lose!";
        }
    }
      
}
