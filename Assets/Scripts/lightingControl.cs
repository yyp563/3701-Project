using UnityEngine;

public class LightingSettingsManager : MonoBehaviour
{
    [Header("调整 Lighting Settings -> Environment -> Intensity Multiplier")]
    [Range(0f, 2f)] // 设置滑动条范围
    [SerializeField]
    public float intensityMultiplier = 1f;

    void Start()
    {
        // 初始化 Lighting 的 Intensity Multiplier
        RenderSettings.reflectionIntensity = intensityMultiplier;
    }

    void Update()
    {
        // 在运行时动态修改 Lighting Intensity
        RenderSettings.reflectionIntensity = intensityMultiplier;
    }
}