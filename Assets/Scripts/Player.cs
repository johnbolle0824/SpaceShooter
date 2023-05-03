using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    float _speed, _boostedSpeed;
    [SerializeField]
    float xBounds, topBounds, bottomBounds;
    [SerializeField]
    float fireRate = 0.15f;
    float _canFire = 0.0f;

    public int health = 3;

    int _score;

    private UIManager _uiManager;
        
    bool isTripleShotActive = false;
    bool isSpeedIncreased = false;
    [SerializeField]
    bool isShieldActive = false;

    SpawnManager spawnManager;

    [SerializeField] GameObject laserPrefab, tripleShot, shieldPowerUp;
    [SerializeField] Transform laserSpawnPos;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("UIManager is NULL!");
        }

        if(spawnManager == null )
        {
            Debug.LogError("Spawn Manager is NULL!");
        }
        
        transform.position = Vector3.zero;

        _score = 0;
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckBounds();
        Shooting();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = new Vector3(horizontalInput, verticalInput);

        if (isSpeedIncreased == false)
        {
            transform.Translate(inputDirection * _speed * Time.deltaTime);
        }
        else if (isSpeedIncreased == true)
        {
            transform.Translate(inputDirection * _boostedSpeed * Time.deltaTime);
        }

        if(verticalInput > 0f)
        {
            anim.Play("player_up");
        }
        if (verticalInput < 0f)
        {
            anim.Play("player_down");
        }
        if (verticalInput ==  0f)
        {
            anim.Play("player_idle");
        }
    }

    void CheckBounds()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.25f, 9.25f),
            Mathf.Clamp(transform.position.y, bottomBounds, topBounds), transform.position.z);
    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > _canFire)
        {
            _canFire = Time.time + fireRate;

            if (isTripleShotActive == true)
            {                
                Instantiate(tripleShot, laserSpawnPos.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(laserPrefab, laserSpawnPos.transform.position, Quaternion.identity);
            }
        }       
    }

    public void Damage()
    {
        if(isShieldActive == true)
        {
            isShieldActive = false;

            shieldPowerUp.SetActive(false);

            return;
        }

        health--;

        _uiManager.UpdateHealth(health);

        if ( health < 1 )
        {
            spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);            
        }
    }

    public void TripleShot()
    {
        isTripleShotActive = true;

        StartCoroutine(TripleShotPowerDown(5));
    }

    IEnumerator TripleShotPowerDown(float powerDuration)
    {
        yield return new WaitForSeconds(powerDuration);

        isTripleShotActive = false;
    }

    public void SpeedBoost()
    {
        Debug.Log("Increased Speed!");
        isSpeedIncreased = true;

        StartCoroutine(ResetSpeed(5f));
    }

    IEnumerator ResetSpeed(float  powerDuration)
    {
        yield return new WaitForSeconds(powerDuration);

        isSpeedIncreased = false;
    }

    public void ShieldPower()
    {
        isShieldActive = true;

        shieldPowerUp.SetActive(true);
    }

    // method to add 10 to score
    // tell UI to update score
    public void ScoreModifier(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);

        Debug.Log($"Score { _score}");
    }

    void ResetLevel()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
                        
        }
    }
}





