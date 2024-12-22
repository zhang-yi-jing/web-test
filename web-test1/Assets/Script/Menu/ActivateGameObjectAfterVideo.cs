using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActivateHideAndPlayAfterVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer; // ��Ƶ���������
    public List<GameObject> objectsToActivate; // Ҫ�������Ϸ�����б�
    public List<GameObject> objectsToHide; // Ҫ���ص���Ϸ�����б�
    public List<GameObject> videoPlayersToPlay; // Ҫ������Ƶ�� GameObject �б�

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd; // ע����Ƶ��������¼�
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (vp == videoPlayer)
        {
            // ����ָ������Ϸ����
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

            // ������Ϸ�����б��е�������Ϸ����
            foreach (GameObject obj in objectsToHide)
            {
                obj.SetActive(false);
            }

            // ������Ƶ

        }
    }
}