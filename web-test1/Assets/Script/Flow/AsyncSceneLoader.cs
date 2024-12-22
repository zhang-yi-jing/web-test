using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AsyncSceneLoader : MonoBehaviour
{
    // 在 Unity Inspector 面板中设置场景名称
    [Header("配置场景名称")]
    public string sceneName;
    public float progress;

    private AsyncOperation operation; // 将操作移到此处以便在整个类中使用

    void Start()
    {
        // 开始时就异步加载场景
        LoadSceneAsync();
    }

    // 异步加载场景的方法
    public void LoadSceneAsync()
    {
        // 检查场景名称是否为空
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("场景名称为空，请在 Inspector 面板中设置场景名称！");
            return;
        }

        // 启动协程加载场景
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    // 协程实现异步加载
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        // 开始异步加载场景
        operation = SceneManager.LoadSceneAsync(sceneName);

        // 防止加载完成后立即切换场景
        operation.allowSceneActivation = false;

        // 当加载未完成时，不断输出加载进度
        while (!operation.isDone)
        {
            // 获取加载进度，范围是 0 到 1
            progress = Mathf.Clamp01(operation.progress / 0.9f);

            // 输出进度到控制台
            Debug.Log($"加载进度: {progress * 100:F0}%");

            yield return null;
        }
    }

    // 外部调用方法，激活场景加载
    public void ActivateScene()
    {
        if (operation != null)
        {
            operation.allowSceneActivation = true;
        }
    }
}