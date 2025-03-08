using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron : MonoBehaviour
{
    public GameObject projectilePrefab; // 투사체 프리팹
    public Transform firePoint; // 발사 위치
    public float rotationSpeed = 5f; // 회전 속도
    public float fireRate = 2f; // 발사 간격 (2초)

    private Transform player;
    private bool isPlayerInRange = false; // 플레이어 감지 여부

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform; // 플레이어의 위치 인식
        StartCoroutine(FireRoutine()); // 2초마다 발사 시도
    }

    private void Update()
    {
        if (isPlayerInRange && player != null)
        {
            LookAtPlayer();
        }
    }

    private void LookAtPlayer() // Dron의 정면이 플레이어를 향하도록 함
    {
        Vector3 direction = (player.position - transform.position).normalized; // 방향 설정
        Quaternion lookRotation = Quaternion.LookRotation(direction); // 회전값 설정
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed); // 회전
    }

    private IEnumerator FireRoutine() // fireRate에서 설정한 값만큼 쿨타임
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            if (isPlayerInRange) Fire();
        }
    }

    private void Fire()
    {
        if (projectilePrefab == null || firePoint == null) return;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation); // 투사체 생성
        Rigidbody rb = projectile.GetComponent<Rigidbody>(); // 물리 적용
        if (rb != null)
        {
            rb.velocity = firePoint.forward * 20f; // 투사체 발사 속도
        }
    }

    private void OnTriggerEnter(Collider other) // 플레이어 감지
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) // 플레이어 나감
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}