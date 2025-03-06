using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float rotationSpeed = 1f; // 旋转速度

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}
