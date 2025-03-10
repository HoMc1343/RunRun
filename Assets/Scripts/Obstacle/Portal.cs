using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Renderer portalRenderer;
    private float lightingPortal = 1f; // 발광 강도
    private bool lighting = true; // 발광
    private float lightingSpeed = 2f; // 발광 속도

    public string targetScene; // 포탈이 향할 씬
    public string portalTag; // 현재 포탈 위치
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SavePortalData(transform.position, portalTag);
            GameManager.Instance.SetDefaultSpawnPosition(targetScene);
            SceneController.Instance.UsePortal(targetScene, GameManager.Instance.spawnPosition, portalTag);
        }
    }

    void Update()
    {
        if (lighting)
            lightingPortal += Time.deltaTime * lightingSpeed; // 증가
        else
            lightingPortal -= Time.deltaTime * lightingSpeed; // 감소

        if (lightingPortal >= 1.5f) lighting = false; // 1.5 도달 시 감소
        else if (lightingPortal <= 0.1f) lighting = true; // 0.1 도달 시 증가

        portalRenderer.material.SetColor("_EmissionColor", Color.white * lightingPortal); // 녹색 발광
    }
}
