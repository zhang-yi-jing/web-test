using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _img; // 用于显示滚动图像的RawImage组件
    [SerializeField] private float _x = 0f;  // 横向滚动速度
    [SerializeField] private float _y = 0f;  // 纵向滚动速度

    void Update()
    {
        // 更新图像的UV坐标以实现滚动效果
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }
}