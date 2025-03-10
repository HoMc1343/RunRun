using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    public PortalDoor portalDoor;
    private int coinCount = 0; // 인식된 코인 개수
    private List<GameObject> coinBox = new List<GameObject>(); // 해당 구역 코인 리스트

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinBox.Add(other.gameObject); // 코인 오브젝트 추가
            coinCount++;

            if (portalDoor != null)
            {
                portalDoor.AddCoin(); // 코인 개수 업데이트
            }

            if (coinCount >= portalDoor.requiredCoins) // 조건 충족 시 코인 제거
            {
                portalDoor.CheckAndOpenDoor(coinCount);

                foreach (GameObject coin in coinBox)
                {
                    Destroy(coin);
                }

                coinCount = 0;
                coinBox.Clear();
            }
        }
    }
}