using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string targetScene;
    public string portalTag;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SavePortalData(transform.position, portalTag);
            GameManager.Instance.SetDefaultSpawnPosition(targetScene);
            SceneController.Instance.UsePortal(targetScene, GameManager.Instance.spawnPosition, portalTag);
        }
    }
}
