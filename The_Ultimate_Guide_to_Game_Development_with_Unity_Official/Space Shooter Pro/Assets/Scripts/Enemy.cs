using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4.0f;

    private Player _player;

    void Start()
    {
        transform.position = new Vector3(UnityEngine.Random.Range(-8, 8), 7, 0);
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);
        if (transform.position.y < -5f)
        {
            float randomX = UnityEngine.Random.Range(-11, 11);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Laser"))
        {
            if (_player != null)
            {
                _player.IncrementScore(10);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
