using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class HoverSwitchObjects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<GameObject> secondObjects; // 第二个GameObject列表
    public List<GameObject> videoPlayersToPlay; // 要播放视频的 GameObject 列表

    void Start()
    {
        // 初始状态：隐藏所有第二个GameObjects
        SetSecondObjectsActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 鼠标悬停时：激活所有第二个GameObjects
        SetSecondObjectsActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 鼠标离开时：隐藏所有第二个GameObjects
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