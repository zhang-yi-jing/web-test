using UnityEngine;

public class HideAfterDelay : MonoBehaviour
{
    public float number;
    // �� Start �����п�ʼ��ʱ
    void Start()
    {
        Invoke("HideObject", number); // ��3������ HideObject ����
    }

    // ���ص�ǰ GameObject
    void HideObject()
    {
        gameObject.SetActive(false); // ���ص�ǰ GameObject
    }
}