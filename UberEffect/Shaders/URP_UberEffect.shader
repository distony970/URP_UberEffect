Shader "Distony/URP/UberEffect"
{
    Properties
    {
        _TintColor("Tint Color", Color) = (1,1,1,1)
        _MainTex ("Main Texture", 2D) = "white" {}
        _MainTexTimeUVX("_MainTexTimeUVX",float) = 0
        _MainTexTimeUVY("_MainTexTimeUVY",float) = 0
        _MainTexSlantPowerX("_MainTexSlantPowerX",float) = 0
        _MainTexSlantPowerY("_MainTexSlantPowerY",float) = 0
        [Enum(UberEffect.ECustomCoord)]_MainTexOffsetCoordX ("_MainTexOffsetCoordX",float) = 0
        [Enum(UberEffect.ECustomCoord)]_MainTexOffsetCoordY ("_MainTexOffsetCoordY",float) = 0
        _MainTexOverallAlpha ("_MainTexOverallAlpha",float) = 1
        [Enum(UberEffect.ECustomCoord)]_MainTexOverallAlphaCoord ("_MainTexOverallAlphaCoord",float) = 0
        [Space(40)]

        [Toggle(MASKTEX_ENABLED)]_EnableMaskTex("_EnableMaskTex",float) = 0
        _MaskTex ("Mask Texture", 2D) = "white" {}
        [Enum(UberEffect.ECustomCoord)]_MaskTexOffsetCoordX ("_MaskTexOffsetCoordX",float) = 0
        [Enum(UberEffect.ECustomCoord)]_MaskTexOffsetCoordY ("_MaskTexOffsetCoordY",float) = 0
        _MaskTexColorBlend("_MaskTexColorBlend",Range(0,1)) = 1
        [Enum(UberEffect.ECustomCoord)]_MaskTexColorBlendCoord("_MaskTexColorBlendCoord",float) = 0
        [Space(40)]

        [Toggle(DISSOLVE_ENABLED)]_EnableDissolve("_EnableDissolve",float) = 0
        _DissolveMap("Dissolve Texture",2D) = "white" {}
        _DissolveTimeUVX("_DissolveTimeUVX",float) = 0
        _DissolveTimeUVY("_DissolveTimeUVY",float) = 0
        [Enum(UberEffect.ECustomCoord)]_DissolveTexOffsetCoordX ("_DissolveTexOffsetCoordX",float) = 0
        [Enum(UberEffect.ECustomCoord)]_DissolveTexOffsetCoordY ("_DissolveTexOffsetCoordY",float) = 0

        _DissolveProgress("_DissolveProgress",Range(0,1)) = 0
        _DissolveSharpness("_DissolveSharpness",Range(0,1)) = 0
        [Enum(UberEffect.ECustomCoord)]_DissolveProgressCoord("_DissolveProgressCoord",float) = 0
        [Enum(On,1,Off,0)]_UseDirectionalDissolve("_UseDirectionalDissolve",float) = 0
        _DissolveDirParam("_DissolveDirParam",vector) = (1,0,0,0)
        _DissolveDirSoftness("_DissolveDirSoftness",Range(0,1)) = 0.01
        
//        _DissolveEdgeColor("_DissolveEdgeColor", Color) = (1,1,1,1)
//        _DissolveEdgeIntensity("_DissolveEdgeIntensity", float) = 5
//        [Enum(UberEffect.ECustomCoord)]_DissolveEdgeIntensityCoord("_DissolveEdgeIntensityCoord", float) = 5
//        _DissolveEdge("_DissolveEdge", Range(0,1)) = 0
        [Space(40)]

        [Toggle(FLOWMAP_ENABLED)]_EnableFlowMap("_EnableFlowMap",float) = 0
        _FlowMap("Flow Map",2D) = "white" {}
        _FlowTimeUVX("_FlowTimeUVX",float) = 0
        _FlowTimeUVY("_FlowTimeUVY",float) = 0
        [Enum(UberEffect.ECustomCoord)]_FlowTexOffsetCoordX ("_FlowTexOffsetCoordX",float) = 0
        [Enum(UberEffect.ECustomCoord)]_FlowTexOffsetCoordY ("_FlowTexOffsetCoordY",float) = 0
        _FlowIntensity("_FlowIntensity",Vector) = (1,1,1,1)
        [Enum(UberEffect.ECustomCoord)]_FlowIntensityCoord("_FlowIntensityCoord",float) = 0
        [Enum(UberEffect.ECustomCoord)]_FlowLerpMainCoord("_FlowLerpMainCoord",float) = 0
        [Enum(UberEffect.ECustomCoord)]_FlowLerpMaskCoord("_FlowLerpMaskCoord",float) = 0
        [Enum(UberEffect.ECustomCoord)]_FlowLerpDissolveCoord("_FlowLerpDissolveCoord",float) = 0
        [Space(40)]
        
        _EmissionColor("_EmissionColor",color) = (.5,.5,.5,1)
        _EmissionColorBlend("_EmissionColorBlend",Range(0,1)) = 1
        [Enum(UberEffect.ECustomCoord)]_EmissionColorBlendCoord("_EmissionColorBlendCoord",float) = 0
        _EmissionIntensity("_EmissionIntensity",float) = 0
        [Enum(UberEffect.ECustomCoord)]_EmissionIntensityCoord("_EmissionIntensityCoord",float) = 0
        //dissolve mask for emission
        _EmissionDissolveFactor("_EmissionDissolveFactor",Range(0,1)) = 0
        _EmissionDissolveProgress("_EmissionDissolveProgress",Range(0,1)) = 0
        [Enum(UberEffect.ECustomCoord)]_EmissionDissolveProgressCoord("_EmissionDissolveProgressCoord",Range(0,1)) = 0
        _EmissionDissolveSharpness("_EmissionDissolveSharpness",Range(0,1)) = 0
        [Space(40)]
        
        [Toggle(RIM_EFFECT_ENABLED)]_EnableRim("Enable Rim",float) = 0
        _RimColor("_RimColor",color) = (0,0,0,1)
        _RimThreshold("_RimThreshold",Range(0,1)) = 0.6
        _RimSmoothness("_RimSmoothness",Range(0,5)) = 0.15
        _RimIntensity("_RimIntensity",Range(0,10)) = 0
        [Enum(UberEffect.ECustomCoord)]_RimIntensityCoord("_RimIntensityCoord",float) = 0
        _RimAlphaWithFactor("_RimAlphaWithFactor",Range(0,1)) = 0
        [Enum(UberEffect.ECustomCoord)]_RimAlphaWithFactorCoord("_RimAlphaWithFactorCoord",float) = 0
        _RimIntersectLength("_RimIntersectLength",Range(0,1)) = 0.1
        [Enum(Multiply,1,Add,0)]_RimBlendMode("_RimBlendMode",int) = 0
        [Space(40)]
        
        [Toggle(VERTEX_DISPLACEMENT_ENABLED)]_EnableVertexDisplacement("_EnableVertexDisplacement",float) = 0
        _VertDisplaceMap("VertDisplace Map",2D) = "white" {}
        [Enum(UberEffect.ECustomCoord)]_VertDisplaceTexOffsetCoordX ("_VertDisplaceTexOffsetCoordX",float) = 0
        [Enum(UberEffect.ECustomCoord)]_VertDisplaceTexOffsetCoordY ("_VertDisplaceTexOffsetCoordY",float) = 0
        _VertDisplaceIntensity("_VertDisplaceIntensity",float) = 1
        [Enum(UberEffect.ECustomCoord)]_VertDisplaceIntensityCoord("_VertDisplaceIntensityCoord",float) = 0
        _VertDisplaceDir("_VertDisplaceDir",Vector) = (1,1,1,1)
        _VertDisplaceSharpen("_VertDisplaceSharpen",float) = 1
        [Toggle(MASK_VERTEX_ENABLE)]_EnableApplyMaskToDisplacement("Apply Mask To Displacement?",float) = 0
        [Space(40)]

        [Enum(UnityEngine.Rendering.CullMode)]_Cull("Cull", Float) = 2.0
        [Enum(UnityEngine.Rendering.BlendMode)]_SrcBlend("Blend Src", Float) = 5
        [Enum(UnityEngine.Rendering.BlendMode)]_DstBlend("Blend Dst", Float) = 10
        [Enum(On,1,Off,0)]_ZWrite("ZWrite", Float) = 0
        [Space(40)]

        [Toggle(ALPHA_CLIP_ENABLED)]_EnableAlphaClip("Enable Alpha Clip",float) = 0
        _AlphaClipCutoff("_AlphaClipCutoff",Range(0,1)) = 0.5
        [Space(30)]

        [Toggle(SOFT_PARTICLES_ENABLED)]_EnableSoftParticle("Enable Soft Particle",float) = 0
        _SoftParticleIntensity("_SoftParticleIntensity",Range(0,1)) = 0
        [Space(30)]
        
        [Toggle(SCENE_LIGHTING_ENABLED)]_EnableSceneLighting("Enable Scene Lighting",float) = 0
        _NdotLParam("NdotL param",Range(0,1)) = 1
        _DiffuseFactor("Diffuse Factor",Range(0,1)) = 1
        [Space(30)]
        
        [PerRendererData]_CustomTweenColor("_CustomTweenColor",color) = (1,1,1,1)
        [PerRendererData]_CustomTweenCoord1("_CustomTweenCoord1",Vector) = (0,0,0,0)
        [PerRendererData]_CustomTweenCoord2("_CustomTweenCoord2",Vector) = (0,0,0,0)
        [PerRendererData]_RuntimeControlAlpha("_RuntimeControlAlpha",Range(0,1)) = 1
        
        _TestParam("_TestParam",float) = 1
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent" "Queue" = "Transparent"
        }

        Pass
        {
            Blend [_SrcBlend] [_DstBlend]
            ZWrite[_ZWrite]
            Cull[_Cull]
            ColorMask RGB
            Lighting Off
            ZTest LEqual
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma shader_feature _ _MAIN_LIGHT_SHADOWS
            #pragma shader_feature _ _MAIN_LIGHT_SHADOWS_CASCADE
            
            #pragma shader_feature_local _ MASK_VERTEX_ENABLE
            #pragma shader_feature_local _ SOFT_PARTICLES_ENABLED
            #pragma shader_feature_local _ DISSOLVE_ENABLED
            #pragma shader_feature_local _ FLOWMAP_ENABLED
            #pragma shader_feature_local _ MASKTEX_ENABLED
            #pragma shader_feature_local _ VERTEX_DISPLACEMENT_ENABLED
            #pragma shader_feature_local _ ALPHA_CLIP_ENABLED
            #pragma shader_feature_local _ SCENE_LIGHTING_ENABLED
            #pragma shader_feature_local _ RIM_EFFECT_ENABLED
            #pragma multi_compile _ CUSTOM_TWEEN_SYSTEM
            #pragma multi_compile_fog

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Effect_CustomCoord.hlsl"

            // #if defined(UNITY_PROCEDURAL_INSTANCING_ENABLED) && !defined(SHADER_TARGET_SURFACE_ANALYSIS)
                // #define UBER_EFFECT_PARTICLE_INSTANCING_ENABLED
            // #endif

            // struct DefaultParticleInstanceData
            // {
            //     float3x4 transform;
            //     uint color;
            //     float4 customCoord1;
            //     float4 customCoord2;
            // };
            //
            // StructuredBuffer<DefaultParticleInstanceData> unity_ParticleInstanceData;
            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float4 mainAndMaskUV : TEXCOORD0;
                float4 flowAndDissolveUV : TEXCOORD1;
                float4 vertColor : TEXCOORD2;
                float2 originalUV : TEXCOORD3;
                INPUT_CUSTOM_COORD(4, 5)
                #if defined(SCENE_LIGHTING_ENABLED) || defined(RIM_EFFECT_ENABLED)
                    float3 normalWS : TEXCOORD6;
                    float4 positionWSandFogFactor : TEXCOORD7;
                #endif
                
                #if defined(SOFT_PARTICLES_ENABLED)
                    float4 projectedPosition : TEXCOORD8;
                #endif
                
                // UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Attributes
            {
                float4 positionOS : POSITION;
                float4 color : COLOR;
                float3 normalOS : NORMAL;
                INPUT_CUSTOM_COORD(1, 2)
                float2 uv : TEXCOORD0;
                // UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            sampler2D _MainTex;
            sampler2D _MaskTex;
            sampler2D _DissolveMap;
            sampler2D _FlowMap;
            sampler2D _VertDisplaceMap;

            CBUFFER_START(UnityPerMaterial)
            float4 _MainTex_ST;
            float4 _MaskTex_ST;
            float4 _DissolveMap_ST;
            float4 _FlowMap_ST;
            float4 _VertDisplaceMap_ST;

            half4 _TintColor;
            half _MainTexOffsetCoordX;
            half _MainTexOffsetCoordY;
            half _MainTexSlantPowerX;
            half _MainTexSlantPowerY;
            half _MainTexTimeUVX;
            half _MainTexTimeUVY;
            half _MainTexOverallAlpha;
            half _MainTexOverallAlphaCoord;
            
            half _MaskTexColorBlend;
            half _MaskTexColorBlendCoord;
            half _MaskTexOffsetCoordY;
            half _MaskTexOffsetCoordX;

            half _DissolveTimeUVX;
            half _DissolveTimeUVY;
            half _DissolveTexOffsetCoordX;
            half _DissolveTexOffsetCoordY;
            half _DissolveProgress;
            half _DissolveProgressCoord;
            half _DissolveSharpness;
            half _DissolveSoftness;
            half4 _DissolveDirParam;
            half _UseDirectionalDissolve;
            half _DissolveDirSoftness;
            half4 _DissolveEdgeColor;
            half _DissolveEdgeIntensity;
            half _DissolveEdge;
            half _DissolveEdgeIntensityCoord;
            
            half _FlowTimeUVX;
            half _FlowTimeUVY;
            half _FlowTexOffsetCoordX;
            half _FlowTexOffsetCoordY;
            half4 _FlowIntensity;
            half _FlowIntensityCoord;
            half _FlowLerpMainCoord;
            half _FlowLerpMaskCoord;
            half _FlowLerpDissolveCoord;

            half4 _EmissionColor;
            half _EmissionIntensity;
            half _EmissionIntensityCoord;
            half _EmissionColorBlend;
            half _EmissionColorBlendCoord;
            half _EmissionDissolveFactor;
            half _EmissionDissolveProgress;
            half _EmissionDissolveProgressCoord;
            half _EmissionDissolveSharpness;

            half _VertDisplaceTexOffsetCoordX;
            half _VertDisplaceTexOffsetCoordY;
            half _VertDisplaceIntensity;
            half _VertDisplaceIntensityCoord;
            half _VertDisplaceSharpen;
            half3 _VertDisplaceDir;

            half4 _RimColor;
            half _RimThreshold;
            half _RimSmoothness;
            half _RimIntensity;
            half _RimBlendMode;
            half _RimIntersectLength;
            half _RimAlphaWithFactor;
            half _RimIntensityCoord;
            half _RimAlphaWithFactorCoord;
            // half _EnableAlphaClip;
            half _AlphaClipCutoff;

            half _SoftParticleIntensity;
            
            half _NdotLParam;
            half _DiffuseFactor;
            
            half4 _CustomTweenColor;
            half4 _CustomTweenCoord1;
            half4 _CustomTweenCoord2;
            half _TestParam;
            half _RuntimeControlAlpha;

            CBUFFER_END

            // Returns the soft particles value.
            float SoftParticles(float4 projection, half intensity)
            {
                float2 depthTextureUv = UnityStereoTransformScreenSpaceTex(projection.xy / projection.w);
                float sceneDepthCS = SAMPLE_TEXTURE2D_X(_CameraDepthTexture, sampler_CameraDepthTexture, depthTextureUv).r;
                float sceneDepth = LinearEyeDepth(sceneDepthCS, _ZBufferParams);
                float depth = LinearEyeDepth(projection.z / projection.w, _ZBufferParams);
                half inverseIntensity = 1.0 / intensity;
                return saturate((sceneDepth - depth) * inverseIntensity);
            }

            float GetDepthDelta(float4 projection)
            {
                float2 depthTextureUv = UnityStereoTransformScreenSpaceTex(projection.xy / projection.w);
                float sceneDepthCS = SAMPLE_TEXTURE2D_X(_CameraDepthTexture, sampler_CameraDepthTexture, depthTextureUv).r;
                float sceneDepth = LinearEyeDepth(sceneDepthCS, _ZBufferParams);
                float depth = LinearEyeDepth(projection.z / projection.w, _ZBufferParams);
                return sceneDepth - depth;
            }
            
            half3 GetEffectRimColor(in half NdotV)
            {
                half rimFactor = saturate((1-NdotV));
                half smoothWidthLeft = _RimSmoothness * (1-_RimThreshold);
                half smoothWidthRight = _RimSmoothness * _RimThreshold;
                half rimSize = smoothstep(_RimThreshold-smoothWidthLeft,_RimThreshold+smoothWidthRight,rimFactor);
                // half rimSize = smoothstep(_RimThreshold-_RimSmoothness,_RimThreshold+_RimSmoothness,rimFactor);
                return rimSize * _RimColor.rgb * _RimIntensity;
            }
            
            half GetRimFactor(in half NdotV)
            {
                half rimFactor = saturate((1-NdotV));
                half smoothWidthLeft = _RimSmoothness * (1-_RimThreshold);
                half smoothWidthRight = _RimSmoothness * _RimThreshold;
                half rimSize = smoothstep(_RimThreshold-smoothWidthLeft,_RimThreshold+smoothWidthRight,rimFactor);
                // half rimSize = smoothstep(_RimThreshold-_RimSmoothness,_RimThreshold+_RimSmoothness,rimFactor);
                return rimSize;
            }
            Varyings vert(Attributes input)
            {
                Varyings output;
                // UNITY_SETUP_INSTANCE_ID(input);
                // UNITY_TRANSFER_INSTANCE_ID(input, output);
                SETUP_CUSTOM_COORD(input,_CustomTweenCoord1,_CustomTweenCoord2);
                TRANSFER_CUSTOM_COORD(input, output)

                float3 positionOS = input.positionOS.xyz;
                input.uv += half2(input.uv.y * _MainTexSlantPowerX,input.uv.x * _MainTexSlantPowerY);
                output.mainAndMaskUV.xy = TRANSFORM_TEX(input.uv, _MainTex);
                output.mainAndMaskUV.zw = TRANSFORM_TEX(input.uv, _MaskTex);
                output.flowAndDissolveUV.xy = TRANSFORM_TEX(input.uv, _FlowMap);
                output.flowAndDissolveUV.zw = TRANSFORM_TEX(input.uv, _DissolveMap);

                float2 mainUVOffset;
                float2 maskUVOffset;
                float2 dissolveUVoffset;
                float2 flowMapUVOffset;

                mainUVOffset.x = GET_CUSTOM_COORD(_MainTexOffsetCoordX);
                mainUVOffset.y = GET_CUSTOM_COORD(_MainTexOffsetCoordY);

                maskUVOffset.x = GET_CUSTOM_COORD(_MaskTexOffsetCoordX);
                maskUVOffset.y = GET_CUSTOM_COORD(_MaskTexOffsetCoordY);

                dissolveUVoffset.x = GET_CUSTOM_COORD(_DissolveTexOffsetCoordX);
                dissolveUVoffset.y = GET_CUSTOM_COORD(_DissolveTexOffsetCoordY);

                flowMapUVOffset.x = GET_CUSTOM_COORD(_FlowTexOffsetCoordX);
                flowMapUVOffset.y = GET_CUSTOM_COORD(_FlowTexOffsetCoordY);

                output.originalUV = input.uv;
                output.mainAndMaskUV.xy += mainUVOffset + frac(_Time.x * float2(_MainTexTimeUVX,_MainTexTimeUVY));
                output.mainAndMaskUV.zw += maskUVOffset;
                output.flowAndDissolveUV.xy += flowMapUVOffset + frac(_Time.x * float2(_FlowTimeUVX,_FlowTimeUVY));
                output.flowAndDissolveUV.zw += dissolveUVoffset + frac(_Time.x * float2(_DissolveTimeUVX,_DissolveTimeUVY));

                //vert displacement
                #if defined(VERTEX_DISPLACEMENT_ENABLED)
                    half2 vertDisplaceUV = TRANSFORM_TEX(input.uv, _VertDisplaceMap);
                    float2 vertDisplaceUVOffset;
                    vertDisplaceUVOffset.x = GET_CUSTOM_COORD(_VertDisplaceTexOffsetCoordX);
                    vertDisplaceUVOffset.y = GET_CUSTOM_COORD(_VertDisplaceTexOffsetCoordY);
                    vertDisplaceUV += vertDisplaceUVOffset;
                    half4 vertDisplaceMapCol = tex2Dlod(_VertDisplaceMap, float4(vertDisplaceUV, 0, 0));
    
                #if defined(MASK_VERTEX_ENABLE) && defined(MASKTEX_ENABLED)
                        half4 maskCol = tex2Dlod(_MaskTex, half4(output.mainAndMaskUV.zw, 0, 0));
                        vertDisplaceMapCol *= maskCol;
                #endif
    
                    half sharpenDisplaceCol = max(pow(saturate(vertDisplaceMapCol.r), _VertDisplaceSharpen),0);
                    half vertDisplaceIntensity = _VertDisplaceIntensity + GET_CUSTOM_COORD(_VertDisplaceIntensityCoord);
                    float3 vertNormalOffset = _VertDisplaceDir * input.normalOS * vertDisplaceIntensity * sharpenDisplaceCol;
                    positionOS += vertNormalOffset;
                #endif
                output.positionCS = TransformObjectToHClip(positionOS);
                output.vertColor = input.color * _CustomTweenColor;
                #if defined(SOFT_PARTICLES_ENABLED)
                    output.projectedPosition = ComputeScreenPos(output.positionCS);
                #endif
                #if defined(SCENE_LIGHTING_ENABLED) || defined(RIM_EFFECT_ENABLED)
                    output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                    output.positionWSandFogFactor.xyz = TransformObjectToWorld(input.positionOS.xyz);
                    half fogFactor = ComputeFogFactor(output.positionCS.z);
                    output.positionWSandFogFactor.w = fogFactor;
                #endif

                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                SETUP_CUSTOM_COORD(input,_CustomTweenCoord1,_CustomTweenCoord2)
                half4 outputColor;

                //flow map
                #if defined(FLOWMAP_ENABLED)
                    half4 flowIntensity = _FlowIntensityCoord > 0?_FlowIntensity * GET_CUSTOM_COORD(_FlowIntensityCoord) : _FlowIntensity;
                    half4 flowCol = tex2D(_FlowMap, input.flowAndDissolveUV.xy);
                    half2 flowUVOffset = (flowCol.rg * 2 - 1);
                    input.mainAndMaskUV.xy += flowUVOffset * flowIntensity.x;
                    input.mainAndMaskUV.xy = lerp(input.mainAndMaskUV.xy,flowCol.rg,GET_CUSTOM_COORD(_FlowLerpMainCoord));
                    #if defined(MASKTEX_ENABLED)
                        input.mainAndMaskUV.zw += flowUVOffset * flowIntensity.y;
                        input.mainAndMaskUV.zw = lerp(input.mainAndMaskUV.zw,flowCol.rg,GET_CUSTOM_COORD(_FlowLerpMaskCoord));
                    #endif
                    #if defined(DISSOLVE_ENABLED)
                        input.flowAndDissolveUV.zw += flowUVOffset * flowIntensity.z;
                        input.flowAndDissolveUV.zw = lerp(input.flowAndDissolveUV.zw,flowCol.rg,GET_CUSTOM_COORD(_FlowLerpDissolveCoord));
                    #endif
                #endif

                half4 mainCol = tex2D(_MainTex, input.mainAndMaskUV.xy);
                outputColor = mainCol * _TintColor * input.vertColor;
                outputColor *= _MainTexOverallAlpha + GET_CUSTOM_COORD(_MainTexOverallAlphaCoord);
                //MaskTex
                #if defined(MASKTEX_ENABLED)
                    half4 maskCol = tex2D(_MaskTex, input.mainAndMaskUV.zw);
                    half4 maskBlendCol = lerp(1,maskCol,saturate(_MaskTexColorBlend + GET_CUSTOM_COORD(_MaskTexColorBlendCoord)));
                    outputColor *= maskBlendCol;
                #endif

                //PreDefine Emission
                half emissionIntensity = _EmissionIntensity + GET_CUSTOM_COORD(_EmissionIntensityCoord);
                half3 emissionColor = lerp(outputColor.rgb, _EmissionColor.rgb, saturate(_EmissionColorBlend + GET_CUSTOM_COORD(_EmissionColorBlendCoord)));

                //dissolve
                #if defined(DISSOLVE_ENABLED)
                    half4 dissolveMapCol = tex2D(_DissolveMap,input.flowAndDissolveUV.zw);
                    half dissolveProgress = _DissolveProgress + GET_CUSTOM_COORD(_DissolveProgressCoord);

                    [branch] if (_UseDirectionalDissolve)
                    {
                        half directional = dot(input.originalUV.xy,_DissolveDirParam.xy) + dot(1-input.originalUV.xy,_DissolveDirParam.zw);
                        half dirAlpha = smoothstep(dissolveProgress-_DissolveDirSoftness,dissolveProgress+_DissolveDirSoftness,directional);
                        dissolveMapCol.r = dissolveMapCol.r + dirAlpha;
                    }
                    
                    half dissolveWidth = lerp(0.5,0.001,_DissolveSharpness);
                    half transitionProgress = lerp(-dissolveWidth, 1.0 + dissolveWidth, dissolveProgress);
                    half transitionAlpha = smoothstep(transitionProgress - dissolveWidth, transitionProgress + dissolveWidth, dissolveMapCol.r);
                
                    outputColor.a *= transitionAlpha;

                    [branch] if (_EmissionDissolveFactor>0)
                    {
                        half emissionDissolveWidth = lerp(0.5,0.001,_EmissionDissolveSharpness);
                        half emissionDissolveProgress = lerp(-dissolveWidth, 1.0 + dissolveWidth, _EmissionDissolveProgress + GET_CUSTOM_COORD(_EmissionDissolveProgressCoord));
                        half emissionDissolveAlpha = smoothstep(emissionDissolveProgress - emissionDissolveWidth, emissionDissolveProgress + emissionDissolveWidth, dissolveMapCol.r);
                        emissionIntensity *= lerp(1,saturate(1-emissionDissolveAlpha),_EmissionDissolveFactor);
                    }

                #endif

                //alpha clip
                #if defined(ALPHA_CLIP_ENABLED)
                    clip(outputColor.a - _AlphaClipCutoff);
                #endif

                //scene lighting
                #if defined(SCENE_LIGHTING_ENABLED)
                    [branch] if(_DiffuseFactor>0)
                    {
                        Light mainLight = GetMainLight(TransformWorldToShadowCoord(input.positionWSandFogFactor.xyz));
                        float3 L = normalize(mainLight.direction);
                        half NdotL = saturate(dot(L, input.normalWS) * _NdotLParam + (1 - _NdotLParam));
                        half3 radiance = mainLight.color * NdotL * mainLight.shadowAttenuation * mainLight.distanceAttenuation;
                        float3 irradianceSH = SampleSH(input.normalWS);
                        outputColor.rgb = outputColor.rgb * lerp(1,(radiance + irradianceSH),_DiffuseFactor);
                        outputColor.rgb = MixFog(outputColor.rgb, input.positionWSandFogFactor.w);

                    }
                #endif

                //emission
                outputColor.rgb += emissionColor * emissionIntensity;


                float depthDelta = 0;
                //soft particle
                #if defined(SOFT_PARTICLES_ENABLED)
                    depthDelta = GetDepthDelta(input.projectedPosition);
                    float soft = saturate(depthDelta * rcp(_SoftParticleIntensity));
                    outputColor.a *= soft;
                #endif

                //rim Effect
                #if defined(RIM_EFFECT_ENABLED)
                float3 viewDirWS = normalize(_WorldSpaceCameraPos - input.positionWSandFogFactor.xyz);
                half NdotV = dot(viewDirWS,input.normalWS);
                half rimFactor = GetRimFactor(NdotV);
                half intersect = 0;
                if(depthDelta)
                {
                    intersect = saturate((_RimIntersectLength-depthDelta));
                    rimFactor = max(rimFactor,intersect);
                }
                half3 rimColor = rimFactor * (_RimIntensity + GET_CUSTOM_COORD(_RimIntensityCoord)) * _RimColor.rgb;
                if (_RimBlendMode)
                { 
                    outputColor.rgb *= rimColor;
                }
                else
                {
                    outputColor.rgb += rimColor;
                }
                outputColor.a = lerp(outputColor.a,outputColor.a * saturate(rimFactor),saturate(_RimAlphaWithFactor + GET_CUSTOM_COORD(_RimAlphaWithFactorCoord)));
                #endif
                
                outputColor.rgb = max(outputColor.rgb,0);
                outputColor.a = saturate(outputColor.a * _RuntimeControlAlpha);
                return outputColor;
            }
            ENDHLSL
        }
        
    }
    CustomEditor "UberEffect.UberEffectMateiralInspector"
}