using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] private float resistance;
    [SerializeField] private GameObject explosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > resistance)
        {
            if (explosionPrefab != null)
            {
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(explosion, 3);
            }
            Destroy(gameObject, 0.1f);
        }
        else
        {
            resistance -= collision.relativeVelocity.magnitude;
        }
    }
}
