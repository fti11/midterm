using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 컴포넌트를 처리할 변수
    [SerializeField]
    private Transform tr;

    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 200;
    [SerializeField] private float m_jumpForce = 4;

    public Transform hammerTransform; // 망치 Transform

    // Start is called before the first frame update
    void Start()
    {
        // Transform 컴포넌트를 추출해 변수에 대입
        tr = GetComponent<Transform>();

        // 망치를 플레이어의 오른손에 배치
        GameObject hammer = Instantiate(Resources.Load("Prefabs/Hammer")) as GameObject;
        hammer.transform.parent = transform.Find("WeaponHolder "); // 플레이어 오른손 위치
        //hammer.transform.localPosition = new Vector3(0.2f, -0.2f, 0.5f); // 망치 위치 조정
        //hammer.transform.localRotation = Quaternion.Euler(90f, 0f, 0f); // 망치 회전 조정
        hammerTransform = hammer.transform; // 망치 Transform 저장
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        float v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        float r = Input.GetAxis("Mouse X");

        Debug.Log("h=" + h);
        Debug.Log("v=" + v);

        // 전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        //Translate(이동 방향 * 속력 * Time.deltaTime)
        tr.Translate(moveDir.normalized * Time.deltaTime * m_moveSpeed);

        tr.Rotate(Vector3.up * m_turnSpeed * Time.deltaTime * r);

        // 망치 회전 처리
        hammerTransform.Rotate(Vector3.up, 100f * Time.deltaTime);
    }
}
