using UnityEngine;

public class RotateLeftRight : MonoBehaviour
{
    public float rotationSpeed = 50f; // 旋转速度
    public float rotationRange = 30f; // 旋转范围

    private bool rotateClockwise = true; // 是否顺时针旋转
    private Quaternion startRotation;
    private Quaternion targetRotation;

    void Start()
    {
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0, 0, startRotation.eulerAngles.z + rotationRange);
    }

    void Update()
    {
        if (rotateClockwise)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1)
            {
                rotateClockwise = false;
                targetRotation = startRotation;
            }
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1)
            {
                rotateClockwise = true;
                targetRotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + rotationRange);
            }
        }
    }
}