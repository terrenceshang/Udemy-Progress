using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);

        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.TripleShotActive();
            }

            Destroy(gameObject);
        }
    }

}
