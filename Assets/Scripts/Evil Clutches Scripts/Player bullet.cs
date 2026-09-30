using UnityEngine;

public class Playerbullet : MonoBehaviour
{
    float speed = 6f;
    PlayerMovement Player;

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            if (other.GetComponent<ProjectileMove>() != null)
            {
                Player.scoreVal += other.GetComponent<ProjectileMove>().points;
                Player.ScoreBox.text = "Score:" + Player.scoreVal;
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}