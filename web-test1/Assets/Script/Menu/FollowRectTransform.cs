using UnityEngine;

public class FollowRectTransform : MonoBehaviour
{
    // 目标物体的 RectTransform 组件
    public RectTransform targetRectTransform;

    // 上一帧目标物体的位置
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
            // 计算目标物体的位移
            Vector3 targetDeltaPosition = targetRectTransform.position - previousTargetPosition;

            // 将位移应用到挂载该脚本的物体上
            transform.position += targetDeltaPosition;

            // 更新上一帧的目标物体位置
            previousTargetPosition = targetRectTransform.position;
        }
    }
}