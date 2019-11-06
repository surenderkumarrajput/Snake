using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 direction;
    private int life = 3;
    public int score;
    public float speed=0f;
    private float width, Playerscale;
    public GameObject tailpre,heart1,heart2,heart3,GameoverUI,Gameoverelements;
    public Foodspawn foodremove;
    public static List<GameObject> Tail = new List<GameObject>(); 
    public Powerups p;
    public Text scoretext,gameovertext,highscore;
    // Start is called before the first frame update
    void Start()
    {
        Playerscale = transform.localScale.x;
        direction = Vector3.left;
        var sprite = GetComponent<SpriteRenderer>().sprite;
        width = (sprite.rect.width)*Playerscale / sprite.pixelsPerUnit;
        InvokeRepeating("Move", 0, 0.127f);
        highscore.text = PlayerPrefs.GetInt("highscore", 0).ToString();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Health"))
        {
            if(life<3)
            {
                life++;
                score += 50;
                FindObjectOfType<AudioManager>().Play("Powers");
                Destroy(collision.gameObject);
            }
            else
            {
                score += 50;
                FindObjectOfType<AudioManager>().Play("Powers");
                Destroy(collision.gameObject);
           }
        }
       else if (collision.gameObject.CompareTag("speed"))
        {
            if (speed < 4)
            {
                speed = speed + 0.1f;
                Invoke("DecreaseSpeed", 5);
            }
            score += 50;
            FindObjectOfType<AudioManager>().Play("Powers");
            Destroy(collision.gameObject);
        }
       else if (collision.gameObject.CompareTag("destroy"))
        {
            
            if (life >0 )
            {                
                life--;
                FindObjectOfType<AudioManager>().Play("Colliding");
                transform.position = new Vector3(0,0);
               
            }
            else if(life==0)
            {
                FindObjectOfType<AudioManager>().Play("Die");
                Destroy(gameObject);
                Time.timeScale = 0f;
                Gameoverelements.SetActive(false);
                GameoverUI.SetActive(true);
                
            }
        }
        if (PlayerPrefs.GetInt("highscore", 0) < score)
        {

            PlayerPrefs.SetInt("highscore", score);
            highscore.text = score.ToString();

        }

    }
    void DecreaseSpeed()
    {
       
            speed = speed - 0.1f;
        
    }
   void Move()
    {

        for (int k = 0; k < speed; k++)
        {

            var prevPosition = transform.position;
            var currentpos = prevPosition + (direction * width);
            transform.position = currentpos;

            for (int j = 0; j < Tail.Count; j++)
            {

                var temp = prevPosition;
                prevPosition = Tail[j].transform.position;
                Tail[j].transform.position = temp;
               

            }

        }
    }



    // Update is called once per frame
    void Update()
    {
        
        Heart();
        scoretext.text = score.ToString();
        gameovertext.text = score.ToString();
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector3.right;
            transform.localScale = new Vector2(-Playerscale, Playerscale);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector3.left;
            transform.localScale = new Vector2(Playerscale, Playerscale);
            transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector3.down;
            var factor = transform.localScale.x / Mathf.Abs(transform.localScale.x);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90 * factor));

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3.up;
            var factor = transform.localScale.x / Mathf.Abs(transform.localScale.x);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270 * factor));
        }
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.CompareTag("Food"))
            {
            foodremove.Removefood(collision.gameObject);
                var prevPosition = transform.position;
                var tail = Instantiate(tailpre) as GameObject;
            score += 10;
            transform.position = collision.gameObject.transform.position;
            FindObjectOfType<AudioManager>().Play("Eat");
            Destroy(collision.gameObject);
                tail.transform.position = prevPosition;
                Tail.Insert(0, tail);
            
            }
        
    }
    void Heart()
    {
        if(life==3)
        {
            heart3.SetActive(true);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }
        if(life==2)
        {
            heart2.SetActive(true);
            heart1.SetActive(true);
            heart3.SetActive(false);
        }
        if(life==1)
        {
            heart1.SetActive(true);
            heart3.SetActive(false);
            heart2.SetActive(false);
        }
        if(life==0)
        {
            heart1.SetActive(false);
            heart3.SetActive(false);
            heart2.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        Tail.Clear();
    }
}
