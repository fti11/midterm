using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
   private int hitCount = 0;

    private void OnMouseDown()
    {
        if (hitCount < 5)
        {
            Debug.Log("박스를 한 번 더 때리세요!");
            hitCount++;
        }
        else
        {
            Debug.Log("박스가 터졌습니다!");
            Destroy(gameObject);
        }
    }
}
