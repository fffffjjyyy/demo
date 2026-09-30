using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;
    public int scoreVal = 0;
    float bulletCooldownSet = 0f;
    float bulletCooldownTimer = 0f;
    public GameObject bullet;
    public TextMeshProUGUI ScoreBox;
    // Update is called once per frame
    void Update()
    {
        bulletCooldownTimer += Time.deltaTime;
        if(Input.GetKey(KeyCode.Space) && bulletCooldownTimer > 1.5f)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            bulletCooldownTimer = bulletCooldownSet;
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4f, 3.4f), transform.position.z);
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (collision.GetComponent<ProjectileMove>() != null)
            {
                scoreVal += collision.GetComponent<ProjectileMove>().points;
                ScoreBox.text = "Score:" + scoreVal;
            }
           // Destroy(gameObject);
        }
    }
}
