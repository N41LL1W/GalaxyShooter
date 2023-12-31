using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShot = false;
    public bool isSpeedBoostActive = false;
    public bool isShieldActive = false;

    public int lives = 3;

    [SerializeField]
    private GameObject _explosionPrefabs;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private GameObject _shieldGameobject;

    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    [SerializeField]
    private float _speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //current pos = new positon
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();   
        }
    }

    private void Shoot()
    {
        //Triple Shot
        if (Time.time > _canFire && canTripleShot == true)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            _canFire = Time.time + _fireRate;
        }

        //Simple Shot
        else if (Time.time > _canFire)
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            _canFire = Time.time + _fireRate;
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vertivcalInput = Input.GetAxis("Vertical");

        if (isSpeedBoostActive == true)
        {
            transform.Translate(Vector3.right * _speed * 1.5f * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * 1.5f * vertivcalInput * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * vertivcalInput * Time.deltaTime);
        }

        //if player on the y is greater than 0
        // set player position on the Y to 0

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        //if player position on the x is greater than 9.5
        //position on the x needs to be -9.5
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        if (isShieldActive == true)
        {
            isShieldActive = false;
            _shieldGameobject.SetActive(false);
            return;
        }

        lives--;

        if (lives < 1)
        {
            Instantiate(_explosionPrefabs, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void TripleShotPowerupOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void SpeedPowerupOn()
    {
        isSpeedBoostActive = true;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    public void EnableShields()
    {
        isShieldActive = true;
        _shieldGameobject.SetActive(true);
        //StartCoroutine(SpeedPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        canTripleShot = false;
    }

    public IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        isSpeedBoostActive = false;
    }
}
