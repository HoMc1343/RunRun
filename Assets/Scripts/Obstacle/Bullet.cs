using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float knockbackForce = 100f; // 밀려나는 힘
    public float lifetime = 5f; // 5초 후 삭제

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized;
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}