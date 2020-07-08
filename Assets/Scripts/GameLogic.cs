using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameLogic : MonoBehaviour
{

   public float respawn_offset = 0.1f;
    public float respawn_height = 7f;
    public int Limiting_Score = 7;
    public GameObject MyBall;
    private Rigidbody2D rigidBody; 
    private bool Is_game_Over = false;

	private int score_left = 0;
	private int score_right = 0;
    public Text score_right_text;
    public Text score_left_text;
    public Text Winning_String;
    public Text Help_message;

    

    // Start is called before the first frame update
    void Start()
    {

        FindObjectOfType<AudioManager>().Play("bgmusic");

        rigidBody = GetComponent<Rigidbody2D> (); //getting the object with whom the script is associated
    }

    // Update is called once per frame
    void Update()
    {
        if(Limiting_Score == score_left || Limiting_Score == score_right)
        {
            if(Limiting_Score == score_left)
            {
                Winning_String.text = "Blue Wins !!";
            }
            else
            {
                Winning_String.text = "Red Wins !!";
            }

            Help_message.text = "Press 'r' to Restart";
            Is_game_Over = true;
            
        }


        if(Is_game_Over && Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Gameplay"); 
        }   
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(Is_game_Over == false)
        {


            if(other.collider.tag == "leftarea")
            {
                // handling scores
                score_right = score_right + 1;
                score_right_text.text = score_right.ToString();


                // changing position of ball to fall from above after ground touch
                MyBall.transform.position = new Vector3(-respawn_offset,respawn_height,0);

                // managing the ball velocity
                rigidBody.velocity = new Vector3(0,0,0);
            }

            else if(other.collider.tag == "rightarea")
            {
                score_left = score_left + 1;
                score_left_text.text = score_left.ToString();

                MyBall.transform.position = new Vector3(respawn_offset,respawn_height,0);
                rigidBody.velocity = new Vector3(0,0,0);
            }

            else if(other.collider.tag == "leftplayer" || other.collider.tag == "rightplayer")
            {
                FindObjectOfType<AudioManager>().Play("hit");
            }
    	
        }
    }
}
