using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4.0f;

    void Start()
    {
        transform.position = new Vector3(UnityEngine.Random.Range(-8, 8), 7, 0);
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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
