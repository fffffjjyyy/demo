using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed = 4f;
    public bool pierce;

    public bool shield;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GalagaPlayer"))
        {
            Destroy(gameObject);
        }
    }
}
