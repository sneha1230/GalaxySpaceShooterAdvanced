using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourAI : MonoBehaviour
{
    public float enemySpeed;// a variable to enemy speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
        //when enemy off the screen on the bottom he needs to respawn with new random x position
        if (transform.position.y < -6.0f)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 6.0f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            if (collision.transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            //need to damage the player
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
    }
}
