using UnityEngine;

public class HideAfterDelay : MonoBehaviour
{
    public float number;
    // 在 Start 方法中开始计时
    void Start()
    {
        Invoke("HideObject", number); // 在3秒后调用 HideObject 方法
    }

    // 隐藏当前 GameObject
    void HideObject()
    {
        gameObject.SetActive(false); // 隐藏当前 GameObject
    }
}