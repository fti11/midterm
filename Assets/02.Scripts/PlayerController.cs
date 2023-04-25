using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ������Ʈ�� ó���� ����
    [SerializeField]
    private Transform tr;

    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 200;
    [SerializeField] private float m_jumpForce = 4;

    public Transform hammerTransform; // ��ġ Transform

    // Start is called before the first frame update
    void Start()
    {
        // Transform ������Ʈ�� ������ ������ ����
        tr = GetComponent<Transform>();

        // ��ġ�� �÷��̾��� �����տ� ��ġ
        GameObject hammer = Instantiate(Resources.Load("Prefabs/Hammer")) as GameObject;
        hammer.transform.parent = transform.Find("WeaponHolder "); // �÷��̾� ������ ��ġ
        //hammer.transform.localPosition = new Vector3(0.2f, -0.2f, 0.5f); // ��ġ ��ġ ����
        //hammer.transform.localRotation = Quaternion.Euler(90f, 0f, 0f); // ��ġ ȸ�� ����
        hammerTransform = hammer.transform; // ��ġ Transform ����
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        float v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        float r = Input.GetAxis("Mouse X");

        Debug.Log("h=" + h);
        Debug.Log("v=" + v);

        // �����¿� �̵� ���� ���� ���
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        //Translate(�̵� ���� * �ӷ� * Time.deltaTime)
        tr.Translate(moveDir.normalized * Time.deltaTime * m_moveSpeed);

        tr.Rotate(Vector3.up * m_turnSpeed * Time.deltaTime * r);

        // ��ġ ȸ�� ó��
        hammerTransform.Rotate(Vector3.up, 100f * Time.deltaTime);
    }
}
