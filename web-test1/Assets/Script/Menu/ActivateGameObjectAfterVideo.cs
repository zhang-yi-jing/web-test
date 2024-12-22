using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActivateHideAndPlayAfterVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer; // 视频播放器组件
    public List<GameObject> objectsToActivate; // 要激活的游戏物体列表
    public List<GameObject> objectsToHide; // 要隐藏的游戏物体列表
    public List<GameObject> videoPlayersToPlay; // 要播放视频的 GameObject 列表

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd; // 注册视频播放完成事件
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (vp == videoPlayer)
        {
            // 激活指定的游戏物体
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }

            foreach (GameObject videoPlayerObject in videoPlayersToPlay)
            {
                VideoPlayer player = videoPlayerObject.GetComponent<VideoPlayer>();
                if (player != null)
                {
                    player.Play();
                }
            }

            // 隐藏游戏物体列表中的所有游戏物体
            foreach (GameObject obj in objectsToHide)
            {
                obj.SetActive(false);
            }

            // 播放视频

        }
    }
}