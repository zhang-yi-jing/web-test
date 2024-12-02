using UnityEngine;

public class FollowRectTransform : MonoBehaviour
{
    // Ŀ������� RectTransform ���
    public RectTransform targetRectTransform;

    // ��һ֡Ŀ�������λ��
    private Vector3 previousTargetPosition;

    void Start()
    {
        if (targetRectTransform != null)
        {
            previousTargetPosition = targetRectTransform.position;
        }
    }

    void Update()
    {
        if (targetRectTransform != null)
        {
            // ����Ŀ�������λ��
            Vector3 targetDeltaPosition = targetRectTransform.position - previousTargetPosition;

            // ��λ��Ӧ�õ����ظýű���������
            transform.position += targetDeltaPosition;

            // ������һ֡��Ŀ������λ��
            previousTargetPosition = targetRectTransform.position;
        }
    }
}