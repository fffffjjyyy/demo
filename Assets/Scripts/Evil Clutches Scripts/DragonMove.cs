using UnityEngine;

public class DragonMove : MonoBehaviour
{
    public float speed = 5f;

    private float ratWait = 1f, fireballWait = 2f;

    private float ratTimer = 0, fireballTimer = 0;

    public GameObject Rat;
    public GameObject Fireball;
    public bool goingUp = true;

    // Update is called once per frame
    void Update()
    {
        ratTimer += Time.deltaTime;
        fireballTimer += Time.deltaTime;
          transform.Translate(transform.up * speed * Time.deltaTime);
     
        if(transform.position.y > 3.4 && goingUp == true)
        {
            goingUp = false;
            speed *= -1;
        }
        if (transform.position.y < -4 && goingUp == false)
        {
            goingUp = true;
            speed *= -1;
        }
        if(ratTimer > ratWait)
        {
            Instantiate(Rat, transform.position, Quaternion.identity);
            ratTimer = 0;
            ratWait = Random.Range(1f, 2f);
        }
        if (fireballTimer > fireballWait)
        {
            Instantiate(Fireball, transform.position, Quaternion.identity);
            fireballTimer = 0;
            fireballWait = Random.Range(2f, 3f);
        }
    }
}
