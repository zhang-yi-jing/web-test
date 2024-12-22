using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class HoverSwitchObjects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<GameObject> secondObjects; // �ڶ���GameObject�б�
    public List<GameObject> videoPlayersToPlay; // Ҫ������Ƶ�� GameObject �б�

    void Start()
    {
        // ��ʼ״̬���������еڶ���GameObjects
        SetSecondObjectsActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // �����ͣʱ���������еڶ���GameObjects
        SetSecondObjectsActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ����뿪ʱ���������еڶ���GameObjects
        SetSecondObjectsActive(false);
    }

    private void SetSecondObjectsActive(bool active)
    {
        foreach (GameObject videoPlayerObject in videoPlayersToPlay)
        {
            VideoPlayer player = videoPlayerObject.GetComponent<VideoPlayer>();
            if (player != null)
            {
                player.Play();
            }
        }

        foreach (GameObject obj in secondObjects)
        {
            obj.SetActive(active);
        }

        
    }


}