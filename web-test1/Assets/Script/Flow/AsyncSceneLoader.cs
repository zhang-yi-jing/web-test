using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AsyncSceneLoader : MonoBehaviour
{
    // 在 Unity Inspector 面板中设置场景名称
    [Header("配置场景名称")]
    public string sceneName;
    public float progress;

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
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // 防止加载完成后立即切换场景
        operation.allowSceneActivation = false;

        // 当加载未完成时，不断输出加载进度
        while (!operation.isDone)
        {
            // 获取加载进度，范围是 0 到 1
            progress = Mathf.Clamp01(operation.progress / 0.9f);

            // 输出进度到控制台
            Debug.Log($"加载进度: {progress * 100:F0}%");

            // 如果加载进度达到 90%（0.9），等待用户触发继续
            if (operation.progress >= 0.9f)
            {
                Debug.Log("加载完成，等待激活场景...");

                // 模拟按下空格键激活场景
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    operation.allowSceneActivation = true;
                }
            }

            // 等待下一帧再继续
            yield return null;
        }
    }
}