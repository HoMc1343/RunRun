using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string targetScene; // 이동할 씬
    public string portalTag;   // 포탈 태그
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneController.Instance.UsePortal(targetScene, transform.position + new Vector3(0, -4f, 0), portalTag);
        }
    }
}
