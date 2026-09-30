using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed = 6f;

    public int points = 100;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
        if (transform.position.x < -10) 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {          
            Destroy(gameObject);
        }
    }
}
