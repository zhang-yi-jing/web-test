using UnityEngine;
using UnityEngine.EventSystems;

public class SimulateMouseClick : MonoBehaviour
{
    void Start()
    {
        // 创建一个模拟的 PointerEventData
        PointerEventData pointerData = new PointerEventData(EventSystem.current);

        // 设置点击位置为屏幕中心
        pointerData.position = new Vector2(Screen.width / 2, Screen.height / 2);

        // 模拟鼠标左键按下事件
        pointerData.button = PointerEventData.InputButton.Left;
        ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, pointerData, ExecuteEvents.pointerDownHandler);

        // 模拟鼠标左键抬起事件
        ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, pointerData, ExecuteEvents.pointerUpHandler);
        Debug.Log(1);
    }
}