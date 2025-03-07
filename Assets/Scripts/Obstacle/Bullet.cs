using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // 투사체 속도
    public float destroyTime = 5f; // 5초 뒤 삭제

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = transform.forward * speed; // 투사체를 앞쪽으로 이동
        }

        Destroy(gameObject, destroyTime); // 5초 뒤 삭제
    }
}