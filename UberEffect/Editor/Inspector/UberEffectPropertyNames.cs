namespace UberEffect
{
    public class UberEffectPropertyNames
    {
        public const string TintColor = "_TintColor";
        public const string MainTex = "_MainTex";
        public const string MainTexTimeUVX = "_MainTexTimeUVX";
        public const string MainTexTimeUVY = "_MainTexTimeUVY";
        public const string MainTexSlantPowerX = "_MainTexSlantPowerX";
        public const string MainTexSlantPowerY = "_MainTexSlantPowerY";
        public const string MainTexOffsetCoordX = "_MainTexOffsetCoordX";
        public const string MainTexOffsetCoordY = "_MainTexOffsetCoordY";
        public const string MainTexOverallAlpha = "_MainTexOverallAlpha";
        public const string MainTexOverallAlphaCoord = "_MainTexOverallAlphaCoord";
        
        public const string MaskTex = "_MaskTex";
        public const string MaskTexOffsetCoordX = "_MaskTexOffsetCoordX";
        public const string MaskTexOffsetCoordY = "_MaskTexOffsetCoordY";
        public const string MaskTexColorBlend = "_MaskTexColorBlend";
        public const string MaskTexColorBlendCoord = "_MaskTexColorBlendCoord";
        
        public const string DissolveMap = "_DissolveMap";
        public const string DissolveTimeUVX = "_DissolveTimeUVX";
        public const string DissolveTimeUVY = "_DissolveTimeUVY";
        public const string DissolveTexOffsetCoordX = "_DissolveTexOffsetCoordX";
        public const string DissolveTexOffsetCoordY = "_DissolveTexOffsetCoordY";
        public const string DissolveProgress = "_DissolveProgress";
        public const string DissolveSharpness = "_DissolveSharpness";
        public const string DissolveProgressCoord = "_DissolveProgressCoord";
        public const string UseDirectionalDissolve = "_UseDirectionalDissolve";
        public const string DissolveDirParam = "_DissolveDirParam";
        public const string DissolveDirSoftness = "_DissolveDirSoftness";

        public const string FlowMap = "_FlowMap";
        public const string FlowTimeUVX = "_FlowTimeUVX";
        public const string FlowTimeUVY = "_FlowTimeUVY";
        public const string FlowTexOffsetCoordX = "_FlowTexOffsetCoordX";
        public const string FlowTexOffsetCoordY = "_FlowTexOffsetCoordY";
        public const string FlowIntensity = "_FlowIntensity";
        public const string FlowIntensityCoord = "_FlowIntensityCoord";
        public const string FlowLerpMainCoord = "_FlowLerpMainCoord";
        public const string FlowLerpMaskCoord = "_FlowLerpMaskCoord";
        public const string FlowLerpDissolveCoord = "_FlowLerpDissolveCoord";
        
        public const string EmissionColor = "_EmissionColor";
        public const string EmissionColorBlend = "_EmissionColorBlend";
        public const string EmissionColorBlendCoord = "_EmissionColorBlendCoord";
        public const string EmissionIntensity = "_EmissionIntensity";
        public const string EmissionIntensityCoord = "_EmissionIntensityCoord";
        public const string EmissionDissolveFactor = "_EmissionDissolveFactor";
        public const string EmissionDissolveProgress = "_EmissionDissolveProgress";
        public const string EmissionDissolveProgressCoord = "_EmissionDissolveProgressCoord";
        public const string EmissionDissolveSharpness = "_EmissionDissolveSharpness";
        
        public const string VertDisplaceMap = "_VertDisplaceMap";
        public const string VertDisplaceTexOffsetCoordX = "_VertDisplaceTexOffsetCoordX";
        public const string VertDisplaceTexOffsetCoordY = "_VertDisplaceTexOffsetCoordY";
        public const string VertDisplaceIntensity = "_VertDisplaceIntensity";
        public const string VertDisplaceIntensityCoord = "_VertDisplaceIntensityCoord";
        public const string VertDisplaceDir = "_VertDisplaceDir";
        public const string VertDisplaceSharpen = "_VertDisplaceSharpen";
        
        public const string RimColor = "_RimColor";
        public const string RimThreshold = "_RimThreshold";
        public const string RimSmoothness = "_RimSmoothness";
        public const string RimIntensity = "_RimIntensity";
        public const string RimIntensityCoord = "_RimIntensityCoord";
        public const string RimAlphaWithFactor = "_RimAlphaWithFactor";
        public const string RimAlphaWithFactorCoord = "_RimAlphaWithFactorCoord";
        public const string RimIntersectLength = "_RimIntersectLength";
        public const string RimBlendMode = "_RimBlendMode";
        
        public const string Cull = "_Cull";
        public const string SrcBlend = "_SrcBlend";
        public const string DstBlend = "_DstBlend";
        public const string ZWrite = "_ZWrite";
        
        public const string AlphaClipCutoff = "_AlphaClipCutoff";
        public const string SoftParticleIntensity = "_SoftParticleIntensity";
        
        public const string NdotLParam = "_NdotLParam";
        public const string DiffuseFactor = "_DiffuseFactor";
        
        public const string TestParam = "_TestParam";
        
        public const string EnableMaskTex = "_EnableMaskTex";
        public const string EnableDissolve = "_EnableDissolve";
        public const string EnableFlowMap = "_EnableFlowMap";
        public const string EnableVertexDisplacement = "_EnableVertexDisplacement";
        public const string EnableApplyMaskToDisplacement = "_EnableApplyMaskToDisplacement";
        public const string EnableAlphaClip = "_EnableAlphaClip";
        public const string EnableSoftParticle = "_EnableSoftParticle";
        public const string EnableSceneLighting = "_EnableSceneLighting";
        public const string EnableRim = "_EnableRim";


    }
}