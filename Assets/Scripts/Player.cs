using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    public int health = 100;
    public float speed = 0.05f;
    public Text winText;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.2f);

    bool damaged;

    private void Start()
    {
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = (Input.GetAxis("Horizontal"));
        float moveVertical = (Input.GetAxis("Vertical"));

        transform.Translate(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);

        //When player runs out of health, destroy it and reload scene
        if (health <= 1)
        {
            Destroy(gameObject);
            //Instantiate(gameObject, GameObject.Find("RespawnPoint").transform.position, Quaternion.identity);
            Application.LoadLevel(Application.loadedLevel);
        }

        //Max health is 100
        if (health >= 100)
        {
            health = 100;
        }

        //Connects healthslider value to player health
        healthSlider.value = health;

        /*if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;*/
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered Danger Zone");

        //Small heart gives player 10 HP
        if (other.gameObject.CompareTag("HP"))
        {
            other.gameObject.SetActive(false);
            health += 10;
        }

        //Large heart gives player 20 health
        if (other.gameObject.CompareTag("HP+"))
        {
            other.gameObject.SetActive(false);
            health += 20;
        }
    }

    //decrease health in poison zone
    //slow down
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Losing Health");

        //Player loses health in poison zone
        if (gameObject.tag == "Player")
        {
            health -= 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Left the Danger Zone");
    }

    //destroys player when touching death pad
    private void OnCollisionEnter(Collision collision)
    {
        //Destroys player upon contact
        if (collision.collider.gameObject.tag == "Death")
        {
            Destroy(gameObject);
            Application.LoadLevel(Application.loadedLevel);
        }

        //Enemy deals 5 damage when touching
        if (collision.collider.gameObject.tag == "Roamer")
        {
            health -= 5;
            //Screens tints red when damaged
            damageImage.color = flashColour;
        }
        else
        {
            //Colour returns to clear
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        //Boss deals 10 damage when touching
        if (collision.collider.gameObject.tag == "Boss")
        {
            health -= 10;
            //Screens tints red when damaged
            damageImage.color = flashColour;
        }
        else
        {
            //Colour returns to clear
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        //When the player reaches the end, YOU WIN!!! text will appear
        if (collision.collider.gameObject.tag == "Finish")
        {
            winText.text = "YOU WIN!!!";
        }
    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "HP")
        {
            Destroy(hit.gameObject);
            health += 10;
        }

        if(hit.gameObject.tag == "HP+")
        {
            Destroy(hit.gameObject);
            health += 20;
        }
    }*/
}
