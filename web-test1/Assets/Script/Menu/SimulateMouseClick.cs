using UnityEngine;
using UnityEngine.EventSystems;

public class SimulateMouseClick : MonoBehaviour
{
    void Start()
    {
        // ����һ��ģ��� PointerEventData
        PointerEventData pointerData = new PointerEventData(EventSystem.current);

        // ���õ��λ��Ϊ��Ļ����
        pointerData.position = new Vector2(Screen.width / 2, Screen.height / 2);

        // ģ�������������¼�
        pointerData.button = PointerEventData.InputButton.Left;
        ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, pointerData, ExecuteEvents.pointerDownHandler);

        // ģ��������̧���¼�
        ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, pointerData, ExecuteEvents.pointerUpHandler);
        Debug.Log(1);
    }
}