using UnityEngine;

/// <summary>
/// custom Tween System
/// use this script with UberEffect anim the custom coord
/// </summary>
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class ObjectTween : MonoBehaviour
{
    public bool uberShader = true;
    public float tweenTime;
    public bool tweenLoop;
    [Header("Scale")] public bool enableScaleTween;
    public float startScale = 1;
    public AnimationCurve scaleOverTime;

    [Header("Rotation")] public bool enableRotationTween;

    public Vector3 startRotation = Vector3.zero;
    public Vector3 rotationSpeed;

    [Header("Color")] public bool enableColorTween;
    [GradientUsage(true)] public Gradient colorOverTime;
    [GradientUsage(true)] public Gradient emissionColorOverTime;

    [Header("CustomTweenCoord")] public bool enableCustomTweenCoord;
    [Header("TweenCoord1")] public AnimationCurve tweenCoord1X;
    public AnimationCurve tweenCoord1Y;
    public AnimationCurve tweenCoord1Z;
    public AnimationCurve tweenCoord1W;
    [Header("TweenCoord2")] public AnimationCurve tweenCoord2X;
    public AnimationCurve tweenCoord2Y;
    public AnimationCurve tweenCoord2Z;
    public AnimationCurve tweenCoord2W;


    private float m_lifetimer;
    private float m_looptimer;
    private MaterialPropertyBlock m_mpb;
    private Renderer m_renderer;
    private MeshFilter m_meshFilter;
    private int m_loopCount;

    private static readonly int TWEEN_COLOR_PROPERTY = Shader.PropertyToID("_CustomTweenColor");
    private static readonly int TWEEN_COORD1_PROPERTY = Shader.PropertyToID("_CustomTweenCoord1");
    private static readonly int TWEEN_COORD2_PROPERTY = Shader.PropertyToID("_CustomTweenCoord2");
    private static readonly int TWEEN_EMISSION_COLOR_PROPERTY = Shader.PropertyToID("_EmissionColor");
    private static readonly string CUSTOM_TWEEN_KEYWORD = "CUSTOM_TWEEN_SYSTEM";
    
    // Use for partilceAdd
    private static readonly int TWEEN_COLOR_PROPERTY_NONUBER = Shader.PropertyToID("_TintColor");

    private Vector4 dataCoord1, dataCoord2;
    private void OnEnable()
    {
        ResetLoop();
        if (m_mpb == null)
        {
            m_mpb = new MaterialPropertyBlock();
        }


        m_renderer = GetComponent<Renderer>();
        m_meshFilter = GetComponent<MeshFilter>();
        if (enableCustomTweenCoord)
        {
            if (m_renderer.material)
            {
                m_renderer.material.EnableKeyword(CUSTOM_TWEEN_KEYWORD);
            }
        }

        transform.rotation = Quaternion.Euler(startRotation);
        transform.localScale = Vector3.one * startScale;

    }

    void Update()
    {
        m_lifetimer += Time.deltaTime;
        m_looptimer = m_lifetimer % tweenTime;

        if (!tweenLoop && m_lifetimer > tweenTime)
        {
            return;
        }

        int loop = (int)(m_lifetimer / tweenTime);
        if (loop > m_loopCount)
        {
            m_loopCount = loop;
            ResetParam();
            if (loop > 5) //avoid precision lost
            {
                ResetLoop();
            }
        }
        m_renderer.GetPropertyBlock(m_mpb);
        float percent = Mathf.Clamp01(m_looptimer / Mathf.Max(tweenTime, 0.01f));
        ApplyScaleTween(percent);
        ApplyRotationTween(percent);
        ApplyColorTween(percent);
        ApplyCustomTweenCoord(percent);
        m_renderer.SetPropertyBlock(m_mpb);
    }

    void ApplyScaleTween(float percent)
    {
        if (!enableScaleTween) return;
        float scale = scaleOverTime.Evaluate(percent);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void ApplyRotationTween(float percent)
    {
        if (!enableRotationTween) return;
        transform.Rotate(rotationSpeed, Space.Self);
    }

    void ApplyColorTween(float percent)
    {
        if (!enableColorTween) return;
        if (uberShader)
        {
            m_mpb.SetColor(TWEEN_COLOR_PROPERTY, colorOverTime.Evaluate(percent));
            m_mpb.SetColor(TWEEN_EMISSION_COLOR_PROPERTY, emissionColorOverTime.Evaluate(percent));
        }
        else
        {
            m_mpb.SetColor(TWEEN_COLOR_PROPERTY_NONUBER, emissionColorOverTime.Evaluate(percent));
        }
    }

    void ApplyCustomTweenCoord(float percent)
    {
        if (!enableCustomTweenCoord) return;
        dataCoord1.x = tweenCoord1X.Evaluate(percent);
        dataCoord1.y = tweenCoord1Y.Evaluate(percent);
        dataCoord1.z = tweenCoord1Z.Evaluate(percent);
        dataCoord1.w = tweenCoord1W.Evaluate(percent);

        dataCoord2.x = tweenCoord2X.Evaluate(percent);
        dataCoord2.y = tweenCoord2Y.Evaluate(percent);
        dataCoord2.z = tweenCoord2Z.Evaluate(percent);
        dataCoord2.w = tweenCoord2W.Evaluate(percent);

        m_mpb.SetVector(TWEEN_COORD1_PROPERTY, dataCoord1);
        m_mpb.SetVector(TWEEN_COORD2_PROPERTY, dataCoord2);
    }

    void ResetParam()
    {
        
    }

    void ResetLoop()
    {
        m_lifetimer = 0;
        m_looptimer = 0;
        m_loopCount = 0;
    }

    public void ChangeMesh(Mesh mesh)
    {
        m_meshFilter.mesh = mesh;
    }
}