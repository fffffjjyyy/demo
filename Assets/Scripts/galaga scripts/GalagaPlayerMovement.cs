using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalagaPlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 5;
    public GameObject bullet;


    public bool Invincible = false;
    public float PowerUpTimer = 0;
    public bool PierceBullet = false;

    public Image[] Lives;
    public int lifecount = 3;
    public float shootTimer = 0;
    public float shootWait = 1;
    // Update is called once per frame
    void Update()
    {
        PowerUpTimer += Time.deltaTime;
        if(PowerUpTimer > 10f)
        {
            Invincible = false;
            PierceBullet = false;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        shootTimer += Time.deltaTime;

        if(Input.GetKey(KeyCode.Space) && shootTimer > shootWait)
        {
            shootTimer = 0;
            Instantiate(bullet, transform.position + new Vector3(-0.025f, 0.5f, 0), Quaternion.identity);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 7f), Mathf.Clamp(transform.position.y, -4f, 4f), 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Enemy") && Invincible == false)
        {
            lifecount -= 1;
            if (lifecount <= 0)
            {
                lifecount = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            Lives[lifecount].enabled = false;
        }
       if(other.gameObject.CompareTag("PowerUp1"))
        {
            Invincible = true;
            PowerUpTimer = 0;
        }
            if (other.gameObject.CompareTag("PowerUp2"))
            {
            PierceBullet = true;
            PowerUpTimer = 0;
        }
        
    }
}
