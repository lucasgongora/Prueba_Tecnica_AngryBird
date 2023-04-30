using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] private bool animationScore100;
    [SerializeField] private float resistance;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private GameObject scoreAnimationPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > resistance)
        {
            if (explosionPrefab != null)
            {
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                GameObject score = Instantiate(scoreAnimationPrefab, transform.position, Quaternion.identity);
                Destroy(explosion, 1.5f);
                Destroy(score, 1.5f);
                if (animationScore100)
                {
                    ScoreManager.instance.AddScore100();
                }
                else
                {
                    ScoreManager.instance.AddScore500();
                }
            }
            Destroy(gameObject, 0.1f);
        }
        else
        {
            resistance -= collision.relativeVelocity.magnitude;
        }

    }
}
