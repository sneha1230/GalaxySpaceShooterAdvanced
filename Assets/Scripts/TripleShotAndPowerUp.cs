using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotAndPowerUp : MonoBehaviour
{
    [SerializeField]
    private float trippleshotPowerup = 3.0f;
    [SerializeField]
    private int powerUpID;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * trippleshotPowerup);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Collided With:"+collision.name);
        //acess the player and make tripple shot to true
        if (collision.tag == "Player")
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                if (powerUpID == 0)
                {
                    player.TripleShotPowerUp();
                }
                else if (powerUpID == 1)
                {
                    //enable speed powerup
                    player.SpeedPowerUpOn();
                }
                else if (powerUpID == 2)
                {
                    //enable shields
                    player.EnableShieldPowerUp();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
