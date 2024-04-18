using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _lives = 3;
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _speedMultiplier = 2.0f;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _tripleShotPrefab;
    [SerializeField] private GameObject _shieldPrefab;

    private float _canFire = -1f;
    private bool _isTrippleShotActive = false;
    private bool _isShieldActive = false;
    SpawnManager _spawnManager;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _shieldPrefab.SetActive(false);

        if (_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is null");
        }

    }

    void Update()
    {
        CalculateMovement();

        if ((Input.GetKeyDown(KeyCode.Space)) && (Time.time > _canFire))
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new(horizontalInput, verticalInput, 0);

        transform.Translate(_speed * Time.deltaTime * direction);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        if (_isTrippleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
    }

    public void Damage()
    {
        if (_isShieldActive == true)
        {
            _isShieldActive = false;
            _shieldPrefab.SetActive(false);
            return;
        }

        _lives -= 1;
        if (_lives <= 0)
        {
            _spawnManager.onPlayerDeath();
            Destroy(gameObject);
        }

    }

    public void TripleShotActive()
    {
        _isTrippleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        while (_isTrippleShotActive)
        {
            yield return new WaitForSeconds(5.0f);
            _isTrippleShotActive = false;
        }
    }

    public void SpeedPowerupActive()
    {
        StartCoroutine(SpeedPowerDowmRoutine());
        _speed *= _speedMultiplier;
    }

    IEnumerator SpeedPowerDowmRoutine()
    {

        yield return new WaitForSeconds(5.0f);
        _speed /= _speedMultiplier;

    }

    public void ShieldPowerupActive()
    {
        _isShieldActive = true;
        _shieldPrefab.SetActive(true);
    }
}
