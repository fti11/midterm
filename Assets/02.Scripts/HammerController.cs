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
            Debug.Log("�ڽ��� �� �� �� ��������!");
            hitCount++;
        }
        else
        {
            Debug.Log("�ڽ��� �������ϴ�!");
            Destroy(gameObject);
        }
    }
}
