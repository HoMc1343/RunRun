using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float knockbackForce = 300f; // 밀려나는 힘
    public float lifetime = 5f; // 5초 후 삭제

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>(); // 플레이어의 Rigidbody

            if (playerRb != null)
            {
                Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized; // 드론과 플레이어의 위치 차이를 계산하여 반동 방향 설정
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse); // 넉백 적용
            }
        }
    }
}