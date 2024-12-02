using UnityEngine;

public class ProgressBarMover : MonoBehaviour
{
    // 公开的 GameObject，用于拖入带有 AsyncSceneLoader 脚本的物体
    public GameObject asyncLoaderObject;

    // 移动的最大范围（X 轴）
    public float maxMoveDistance = 500f;

    // 移动速度
    public float moveSpeed = 5f;

    // RectTransform 组件（当前物体）
    private RectTransform rectTransform;

    // 引用 AsyncSceneLoader 脚本
    private AsyncSceneLoader asyncSceneLoader;

    // 当前 X 轴位置
    private float currentX;

    void Start()
    {
        // 获取挂载该脚本的物体的 RectTransform
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("当前物体上没有 RectTransform 组件！");
            return;
        }

        // 检查是否设置了 asyncLoaderObject
        if (asyncLoaderObject == null)
        {
            Debug.LogError("AsyncLoaderObject 没有设置，请在 Inspector 面板中拖入一个带有 AsyncSceneLoader 脚本的物体！");
            return;
        }

        // 获取 AsyncSceneLoader 脚本
        asyncSceneLoader = asyncLoaderObject.GetComponent<AsyncSceneLoader>();
        if (asyncSceneLoader == null)
        {
            Debug.LogError($"在 {asyncLoaderObject.name} 上找不到 AsyncSceneLoader 脚本！");
            return;
        }

        currentX = 0f;
    }

    void Update()
    {
        // 检查是否成功获取了 AsyncSceneLoader 脚本
        if (asyncSceneLoader == null) return;

        // 直接访问 AsyncSceneLoader 中的 progress 属性
        float progress = asyncSceneLoader.progress;

        // 计算新的目标 X 轴位置
        float targetX = progress * maxMoveDistance;

        // 使用 Vector3.Lerp 进行平滑移动
        currentX = Mathf.Lerp(currentX, targetX, Time.deltaTime * moveSpeed);

        // 更新 RectTransform 的位置
        Vector3 newPosition = rectTransform.anchoredPosition;
        newPosition.x = currentX; // 修改 X 轴位置
        rectTransform.anchoredPosition = newPosition;
    }
}