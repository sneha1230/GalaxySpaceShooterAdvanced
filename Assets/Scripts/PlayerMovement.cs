using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerMoveSpeed;
    private float horizontalInput;
    private float verticalInput;
    public GameObject laserPrefab;
    public float fireRate = 0.25f;
    public float canFire = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButton(0))
        {
            if (Time.time > canFire)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                canFire = Time.time + fireRate;
            }
        }
    }
    private void playerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * playerMoveSpeed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * playerMoveSpeed * verticalInput);

        //player bounds for y direction
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.1f, 0);
        }

        //player bounds for x direction
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }
}
