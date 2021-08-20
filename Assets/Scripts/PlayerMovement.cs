using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isSpeedPowerupActive = false;
    public bool canTripleShot = false;
    public bool isShieldActive = false;
    [SerializeField]
    private float playerMoveSpeed;
    private float horizontalInput;
    private float verticalInput;
    public float fireRate = 0.25f;
    public float canFire = 0;
    public int playerLives = 3;
    public GameObject laserPrefab, tripleLaserPrefab;
    public GameObject explosion;
    public GameObject shieldGameObject;
    private UIManager uiManager;
    private GameManager gameManager;
    private SpawnManager spawnManager;
    private AudioSource audioSource;
    private AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        if (uiManager != null)
        {
            uiManager.UpdateLives(playerLives);
        }
        if (spawnManager != null)
        {
            spawnManager.StartCoroutineFunctions();
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (Time.time > canFire)
        {
            //if triple shot is true shoot three lasers,if not one laser
            if (canTripleShot == true)
            {
                Instantiate(tripleLaserPrefab, transform.position+new Vector3(0,4,0) , Quaternion.identity);//center
                //audioSource.clip = audioClip[1];
                canFire = Time.time + fireRate;
            }
            else
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                //audioSource.clip = audioClip[0];
                canFire = Time.time + fireRate;
            }
        }
    }
    private void playerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //if speed powerup enabled then move 2x faster the normal speed
        //else normal speed
        if (isSpeedPowerupActive == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * playerMoveSpeed *2.0f* horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * playerMoveSpeed *2.0f* verticalInput);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * playerMoveSpeed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * playerMoveSpeed * verticalInput);
        }

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
    
    public void TripleShotPowerUp()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDown());
    }
    //method to enable speed power up and power down
    public void SpeedPowerUpOn()
    {
        isSpeedPowerupActive = true;
        StartCoroutine(SpeedPowerDown());
    }
    public void EnableShieldPowerUp()
    {
        isShieldActive = true;
        shieldGameObject.SetActive(true);
    }
    public IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }
    public IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedPowerupActive = false;
    }
    public void Damage()
    {
        //subtract one live from the player lives
        //if lives<1 then destroy player
        //if player has shields do no damage else damage
        if ((isShieldActive == true))
        {
            isShieldActive = false;
            shieldGameObject.SetActive(false);
            return;
        }
        else
        {
            playerLives--;
            uiManager.UpdateLives(playerLives);
            if (playerLives < 1)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                gameManager.gameOver = true;
                uiManager.ShowGameOverScreen();
                Destroy(this.gameObject);
            }
        }
    }
}
