using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleShot : MonoBehaviour
{
    [SerializeField]
    private float trippleshotPowerup = 3.0f;
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
                player.TripleShotPowerUp();
            }
            Destroy(this.gameObject);
        }
    }
}
