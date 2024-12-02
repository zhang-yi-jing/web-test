using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _img; // ������ʾ����ͼ���RawImage���
    [SerializeField] private float _x = 0f;  // ��������ٶ�
    [SerializeField] private float _y = 0f;  // ��������ٶ�

    void Update()
    {
        // ����ͼ���UV������ʵ�ֹ���Ч��
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }
}