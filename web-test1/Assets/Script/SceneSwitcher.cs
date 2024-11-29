using UnityEngine;
using UnityEngine.SceneManagement; // ���ó������������ռ�

public class SceneSwitcher : MonoBehaviour
{
    // ��ť����¼�
    public void OnButtonClick()
    {
        // ��ȡ��ǰ����������
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ������һ������������
        int nextSceneIndex = currentSceneIndex + 1;

        // ����Ƿ�����һ������
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // ������һ������
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // ���û����һ�����������Լ��ص�һ������������ʾһ����Ϣ
            Debug.Log("û�и���ĳ����ˣ�");
            // SceneManager.LoadScene(0); // Ҳ����ѡ�����¼��ص�һ������
        }
    }
}