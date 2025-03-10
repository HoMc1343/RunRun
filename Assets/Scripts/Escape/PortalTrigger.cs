using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    public PortalDoor portalDoor;
    private int coinCount = 0; // 현재 코인 개수

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++; // 코인 개수 증가

            if (portalDoor != null)
            {
                portalDoor.AddCoin(); // 코인 추가
                portalDoor.CheckAndOpenDoor(coinCount); // 문 개방 확인
            }
        }
    }
}