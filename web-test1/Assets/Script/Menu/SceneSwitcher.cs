using UnityEngine;
using UnityEngine.SceneManagement; // 引用场景管理命名空间

public class SceneSwitcher : MonoBehaviour
{
    // 按钮点击事件
    public void OnButtonClick()
    {
        // 获取当前场景的索引
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 计算下一个场景的索引
        int nextSceneIndex = currentSceneIndex + 1;

        // 检查是否有下一个场景
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // 加载下一个场景
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // 如果没有下一个场景，可以加载第一个场景或者显示一个消息
            Debug.Log("没有更多的场景了！");
            // SceneManager.LoadScene(0); // 也可以选择重新加载第一个场景
        }
    }
}