using UnityEditor.U2D.Sprites;
using UnityEngine;

public class BulletShip : MonoBehaviour
{
    public float speed = 3;

    public GameObject Bullet;
    public GameObject explosion;
    public float BulletTimer = 0, BulletWait = 3;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);

        BulletTimer += Time.deltaTime;
        if(BulletTimer > BulletWait)
        {
            BulletTimer = 0;
            Instantiate(Bullet, transform.position - new Vector3(-0.025f, 0.5f, 0), Quaternion.identity);
        }
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet") || other.gameObject.CompareTag("GalagaPlayer"))
        {
            if (other.gameObject.CompareTag("PlayerBullet"))
            {
                GalagaPlayerMovement Player = GameObject.Find("Player").GetComponent<GalagaPlayerMovement>();
                if (Player.PierceBullet == false)
                {
                    Destroy(other.gameObject);
                }

            }
            GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(temp, 1f);
            Destroy(gameObject);
        }
    }
}

