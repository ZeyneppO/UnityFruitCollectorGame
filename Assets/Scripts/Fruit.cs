using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int fruitID; // 0 = Peach, 1 = Pear, 2 = Pom
    public float speed = 10f;  

    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -3.5f)
        {
            Destroy(this.gameObject); 
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            player.AddScore(10);

            Destroy(this.gameObject); 
        }
    }
}
