using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AsyncSceneLoader : MonoBehaviour
{
    // �� Unity Inspector ��������ó�������
    [Header("���ó�������")]
    public string sceneName;
    public float progress;

    void Start()
    {
        // ��ʼʱ���첽���س���
        LoadSceneAsync();
    }


    // �첽���س����ķ���
    public void LoadSceneAsync()
    {
        // ��鳡�������Ƿ�Ϊ��
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("��������Ϊ�գ����� Inspector ��������ó������ƣ�");
            return;
        }

        // ����Э�̼��س���
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    // Э��ʵ���첽����
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        // ��ʼ�첽���س���
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // ��ֹ������ɺ������л�����
        operation.allowSceneActivation = false;

        // ������δ���ʱ������������ؽ���
        while (!operation.isDone)
        {
            // ��ȡ���ؽ��ȣ���Χ�� 0 �� 1
            progress = Mathf.Clamp01(operation.progress / 0.9f);

            // ������ȵ�����̨
            Debug.Log($"���ؽ���: {progress * 100:F0}%");

            // ������ؽ��ȴﵽ 90%��0.9�����ȴ��û���������
            if (operation.progress >= 0.9f)
            {
                Debug.Log("������ɣ��ȴ������...");

                // ģ�ⰴ�¿ո�������
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    operation.allowSceneActivation = true;
                }
            }

            // �ȴ���һ֡�ټ���
            yield return null;
        }
    }
}