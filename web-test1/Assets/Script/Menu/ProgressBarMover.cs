using UnityEngine;

public class ProgressBarMover : MonoBehaviour
{
    // ������ GameObject������������� AsyncSceneLoader �ű�������
    public GameObject asyncLoaderObject;

    // �ƶ������Χ��X �ᣩ
    public float maxMoveDistance = 500f;

    // �ƶ��ٶ�
    public float moveSpeed = 5f;

    // RectTransform �������ǰ���壩
    private RectTransform rectTransform;

    // ���� AsyncSceneLoader �ű�
    private AsyncSceneLoader asyncSceneLoader;

    // ��ǰ X ��λ��
    private float currentX;

    void Start()
    {
        // ��ȡ���ظýű�������� RectTransform
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("��ǰ������û�� RectTransform �����");
            return;
        }

        // ����Ƿ������� asyncLoaderObject
        if (asyncLoaderObject == null)
        {
            Debug.LogError("AsyncLoaderObject û�����ã����� Inspector ���������һ������ AsyncSceneLoader �ű������壡");
            return;
        }

        // ��ȡ AsyncSceneLoader �ű�
        asyncSceneLoader = asyncLoaderObject.GetComponent<AsyncSceneLoader>();
        if (asyncSceneLoader == null)
        {
            Debug.LogError($"�� {asyncLoaderObject.name} ���Ҳ��� AsyncSceneLoader �ű���");
            return;
        }

        currentX = 0f;
    }

    void Update()
    {
        // ����Ƿ�ɹ���ȡ�� AsyncSceneLoader �ű�
        if (asyncSceneLoader == null) return;

        // ֱ�ӷ��� AsyncSceneLoader �е� progress ����
        float progress = asyncSceneLoader.progress;

        // �����µ�Ŀ�� X ��λ��
        float targetX = progress * maxMoveDistance;

        // ʹ�� Vector3.Lerp ����ƽ���ƶ�
        currentX = Mathf.Lerp(currentX, targetX, Time.deltaTime * moveSpeed);

        // ���� RectTransform ��λ��
        Vector3 newPosition = rectTransform.anchoredPosition;
        newPosition.x = currentX; // �޸� X ��λ��
        rectTransform.anchoredPosition = newPosition;
    }
}