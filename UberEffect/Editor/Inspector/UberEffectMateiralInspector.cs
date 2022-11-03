using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UberEffect
{
    public class UberEffectMateiralInspector : ShaderGUI
    {
        #region MaterialProperties

        private MaterialProperty[] m_allProperties;
        private MaterialEditor m_materialEditor;
        private MaterialProperty _TintColor;
        private MaterialProperty _MainTex;
        private MaterialProperty _MainTexTimeUVX;
        private MaterialProperty _MainTexTimeUVY;
        private MaterialProperty _MainTexOffsetCoordX;
        private MaterialProperty _MainTexOffsetCoordY;
        private MaterialProperty _MainTexSlantPowerX;
        private MaterialProperty _MainTexSlantPowerY;
        private MaterialProperty _MainTexOverallAlpha;
        private MaterialProperty _MainTexOverallAlphaCoord;
        
        private MaterialProperty _MaskTex;
        private MaterialProperty _MaskTexOffsetCoordX;
        private MaterialProperty _MaskTexOffsetCoordY;
        private MaterialProperty _MaskTexColorBlend;
        private MaterialProperty _MaskTexColorBlendCoord;
        
        private MaterialProperty _DissolveMap;
        private MaterialProperty _DissolveTimeUVX;
        private MaterialProperty _DissolveTimeUVY;
        private MaterialProperty _DissolveTexOffsetCoordX;
        private MaterialProperty _DissolveTexOffsetCoordY;
        private MaterialProperty _DissolveProgress;
        private MaterialProperty _DissolveSharpness;
        private MaterialProperty _DissolveProgressCoord;
        private MaterialProperty _UseDirectionalDissolve ;
        private MaterialProperty _DissolveDirParam ;
        private MaterialProperty _DissolveDirSoftness ;

        private MaterialProperty _FlowMap;
        private MaterialProperty _FlowTimeUVX;
        private MaterialProperty _FlowTimeUVY;
        private MaterialProperty _FlowTexOffsetCoordX;
        private MaterialProperty _FlowTexOffsetCoordY;
        private MaterialProperty _FlowIntensity;
        private MaterialProperty _FlowIntensityCoord;
        private MaterialProperty _FlowLerpMainCoord;
        private MaterialProperty _FlowLerpMaskCoord;
        private MaterialProperty _FlowLerpDissolveCoord;
        
        private MaterialProperty _EmissionColor;
        private MaterialProperty _EmissionColorBlend;
        private MaterialProperty _EmissionColorBlendCoord;
        private MaterialProperty _EmissionIntensity;
        private MaterialProperty _EmissionIntensityCoord;
        private MaterialProperty _EmissionDissolveFactor;
        private MaterialProperty _EmissionDissolveProgress;
        private MaterialProperty _EmissionDissolveProgressCoord;
        private MaterialProperty _EmissionDissolveSharpness;
        
        private MaterialProperty _VertDisplaceMap;
        private MaterialProperty _VertDisplaceTexOffsetCoordX;
        private MaterialProperty _VertDisplaceTexOffsetCoordY;
        private MaterialProperty _VertDisplaceIntensity;
        private MaterialProperty _VertDisplaceIntensityCoord;
        private MaterialProperty _VertDisplaceDir;
        private MaterialProperty _VertDisplaceSharpen;
        
        private MaterialProperty _RimColor;
        private MaterialProperty _RimThreshold;
        private MaterialProperty _RimSmoothness;
        private MaterialProperty _RimIntensity;
        private MaterialProperty _RimIntensityCoord;
        private MaterialProperty _RimBlendMode;
        private MaterialProperty _RimIntersectLength;
        private MaterialProperty _RimAlphaWithFactor;
        private MaterialProperty _RimAlphaWithFactorCoord;
        private MaterialProperty _Cull;
        private MaterialProperty _SrcBlend;
        private MaterialProperty _DstBlend;
        private MaterialProperty _ZWrite;
        private MaterialProperty _AlphaClipCutoff;
        private MaterialProperty _SoftParticleIntensity;
        private MaterialProperty _NdotLParam;
        private MaterialProperty _DiffuseFactor;
        private MaterialProperty _TestParam;

        private MaterialProperty _EnableMaskTex;
        private MaterialProperty _EnableDissolve;
        private MaterialProperty _EnableFlowMap;
        private MaterialProperty _EnableVertexDisplacement;
        private MaterialProperty _EnableApplyMaskToDisplacement;
        private MaterialProperty _EnableAlphaClip;
        private MaterialProperty _EnableSoftParticle;
        private MaterialProperty _EnableSceneLighting;
        private MaterialProperty _EnableRim;
        #endregion

        #region MaterialPropertiesFunctions

        void SetProperties(MaterialProperty[] properties)
        {
            m_allProperties = properties;
            _TintColor = FindProperty(UberEffectPropertyNames.TintColor);
            _MainTex = FindProperty(UberEffectPropertyNames.MainTex);
            _MainTexTimeUVX = FindProperty(UberEffectPropertyNames.MainTexTimeUVX);
            _MainTexTimeUVY = FindProperty(UberEffectPropertyNames.MainTexTimeUVY);
            _MainTexOffsetCoordX = FindProperty(UberEffectPropertyNames.MainTexOffsetCoordX);
            _MainTexOffsetCoordY = FindProperty(UberEffectPropertyNames.MainTexOffsetCoordY);
            _MainTexSlantPowerX = FindProperty(UberEffectPropertyNames.MainTexSlantPowerX);
            _MainTexSlantPowerY = FindProperty(UberEffectPropertyNames.MainTexSlantPowerY);
            _MainTexOverallAlpha = FindProperty(UberEffectPropertyNames.MainTexOverallAlpha);
            _MainTexOverallAlphaCoord = FindProperty(UberEffectPropertyNames.MainTexOverallAlphaCoord);
            _MaskTex = FindProperty(UberEffectPropertyNames.MaskTex);
            _MaskTexOffsetCoordX = FindProperty(UberEffectPropertyNames.MaskTexOffsetCoordX);
            _MaskTexOffsetCoordY = FindProperty(UberEffectPropertyNames.MaskTexOffsetCoordY);
            _MaskTexColorBlend = FindProperty(UberEffectPropertyNames.MaskTexColorBlend);
            _MaskTexColorBlendCoord = FindProperty(UberEffectPropertyNames.MaskTexColorBlendCoord);
            _DissolveMap = FindProperty(UberEffectPropertyNames.DissolveMap);
            _DissolveTimeUVX = FindProperty(UberEffectPropertyNames.DissolveTimeUVX);
            _DissolveTimeUVY = FindProperty(UberEffectPropertyNames.DissolveTimeUVY);
            _DissolveTexOffsetCoordX = FindProperty(UberEffectPropertyNames.DissolveTexOffsetCoordX);
            _DissolveTexOffsetCoordY = FindProperty(UberEffectPropertyNames.DissolveTexOffsetCoordY);
            _DissolveProgress = FindProperty(UberEffectPropertyNames.DissolveProgress);
            _DissolveSharpness = FindProperty(UberEffectPropertyNames.DissolveSharpness);
            _DissolveProgressCoord = FindProperty(UberEffectPropertyNames.DissolveProgressCoord);
            _UseDirectionalDissolve = FindProperty(UberEffectPropertyNames.UseDirectionalDissolve);
            _DissolveDirParam = FindProperty(UberEffectPropertyNames.DissolveDirParam);
            _DissolveDirSoftness = FindProperty(UberEffectPropertyNames.DissolveDirSoftness);
            _FlowMap = FindProperty(UberEffectPropertyNames.FlowMap);
            _FlowTimeUVX = FindProperty(UberEffectPropertyNames.FlowTimeUVX);
            _FlowTimeUVY = FindProperty(UberEffectPropertyNames.FlowTimeUVY);
            _FlowTexOffsetCoordX = FindProperty(UberEffectPropertyNames.FlowTexOffsetCoordX);
            _FlowTexOffsetCoordY = FindProperty(UberEffectPropertyNames.FlowTexOffsetCoordY);
            _FlowIntensity = FindProperty(UberEffectPropertyNames.FlowIntensity);
            _FlowIntensityCoord = FindProperty(UberEffectPropertyNames.FlowIntensityCoord);
            _FlowLerpMainCoord = FindProperty(UberEffectPropertyNames.FlowLerpMainCoord);
            _FlowLerpMaskCoord = FindProperty(UberEffectPropertyNames.FlowLerpMaskCoord);
            _FlowLerpDissolveCoord = FindProperty(UberEffectPropertyNames.FlowLerpDissolveCoord);
            _EmissionColor = FindProperty(UberEffectPropertyNames.EmissionColor);
            _EmissionColorBlend = FindProperty(UberEffectPropertyNames.EmissionColorBlend);
            _EmissionColorBlendCoord = FindProperty(UberEffectPropertyNames.EmissionColorBlendCoord);
            _EmissionIntensity = FindProperty(UberEffectPropertyNames.EmissionIntensity);
            _EmissionIntensityCoord = FindProperty(UberEffectPropertyNames.EmissionIntensityCoord);
            _EmissionDissolveFactor = FindProperty(UberEffectPropertyNames.EmissionDissolveFactor);
            _EmissionDissolveProgress = FindProperty(UberEffectPropertyNames.EmissionDissolveProgress);
            _EmissionDissolveProgressCoord = FindProperty(UberEffectPropertyNames.EmissionDissolveProgressCoord);
            _EmissionDissolveSharpness = FindProperty(UberEffectPropertyNames.EmissionDissolveSharpness);
            _EnableVertexDisplacement = FindProperty(UberEffectPropertyNames.EnableVertexDisplacement);
            _VertDisplaceMap = FindProperty(UberEffectPropertyNames.VertDisplaceMap);
            _VertDisplaceTexOffsetCoordX = FindProperty(UberEffectPropertyNames.VertDisplaceTexOffsetCoordX);
            _VertDisplaceTexOffsetCoordY = FindProperty(UberEffectPropertyNames.VertDisplaceTexOffsetCoordY);
            _VertDisplaceIntensity = FindProperty(UberEffectPropertyNames.VertDisplaceIntensity);
            _VertDisplaceIntensityCoord = FindProperty(UberEffectPropertyNames.VertDisplaceIntensityCoord);
            _VertDisplaceDir = FindProperty(UberEffectPropertyNames.VertDisplaceDir);
            _VertDisplaceSharpen = FindProperty(UberEffectPropertyNames.VertDisplaceSharpen);
            _RimColor = FindProperty(UberEffectPropertyNames.RimColor);
            _RimThreshold = FindProperty(UberEffectPropertyNames.RimThreshold);
            _RimSmoothness = FindProperty(UberEffectPropertyNames.RimSmoothness);
            _RimIntensity = FindProperty(UberEffectPropertyNames.RimIntensity);
            _RimIntensityCoord = FindProperty(UberEffectPropertyNames.RimIntensityCoord);
            _RimBlendMode = FindProperty(UberEffectPropertyNames.RimBlendMode);
            _RimIntersectLength = FindProperty(UberEffectPropertyNames.RimIntersectLength);
            _RimAlphaWithFactor = FindProperty(UberEffectPropertyNames.RimAlphaWithFactor);
            _RimAlphaWithFactorCoord = FindProperty(UberEffectPropertyNames.RimAlphaWithFactorCoord);
            _Cull = FindProperty(UberEffectPropertyNames.Cull);
            _SrcBlend = FindProperty(UberEffectPropertyNames.SrcBlend);
            _DstBlend = FindProperty(UberEffectPropertyNames.DstBlend);
            _ZWrite = FindProperty(UberEffectPropertyNames.ZWrite);
            _AlphaClipCutoff = FindProperty(UberEffectPropertyNames.AlphaClipCutoff);
            _SoftParticleIntensity = FindProperty(UberEffectPropertyNames.SoftParticleIntensity);
            _NdotLParam = FindProperty(UberEffectPropertyNames.NdotLParam);
            _DiffuseFactor = FindProperty(UberEffectPropertyNames.DiffuseFactor);
            _TestParam = FindProperty(UberEffectPropertyNames.TestParam);
            
            _EnableMaskTex = FindProperty(UberEffectPropertyNames.EnableMaskTex);
            _EnableDissolve = FindProperty(UberEffectPropertyNames.EnableDissolve);
            _EnableFlowMap = FindProperty(UberEffectPropertyNames.EnableFlowMap);
            _EnableVertexDisplacement = FindProperty(UberEffectPropertyNames.EnableVertexDisplacement);
            _EnableApplyMaskToDisplacement = FindProperty(UberEffectPropertyNames.EnableApplyMaskToDisplacement);
            _EnableAlphaClip = FindProperty(UberEffectPropertyNames.EnableAlphaClip);
            _EnableSoftParticle = FindProperty(UberEffectPropertyNames.EnableSoftParticle);
            _EnableSceneLighting = FindProperty(UberEffectPropertyNames.EnableSceneLighting);
            _EnableRim = FindProperty(UberEffectPropertyNames.EnableRim);
        }

        public MaterialProperty FindProperty(string name)
        {
            return ShaderGUI.FindProperty(name, m_allProperties, false);
        }

        #endregion

        Dictionary<string, foldoutGroupState> m_foldoutGroup = new Dictionary<string, foldoutGroupState>();
        private bool m_foldoutInited = false;

        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material material = materialEditor.target as Material;
            m_materialEditor = materialEditor;
            SetProperties(properties);
            InitFoldoutGroup();
            // base.OnGUI(materialEditor,properties);
            MaterialEditorUtility.TransparentSwitchButtonDraw(_SrcBlend, _DstBlend, _ZWrite);
            EditorGUILayout.LabelField("切换材质球渲染属性(不透明会写入深度 透明度只能用于alphaclip");
            MaterialEditorUtility.DrawEnumProperty<CullMode>(m_materialEditor,"剔除选项",_Cull);
            foreach (var group in m_foldoutGroup)
            {
                foldoutGroupState groupState = group.Value;
                using (var foldoutScope = new MaterialEditorUtility.FoldoutHeaderScope(groupState, group.Key))
                {
                    // bool result = MaterialEditorUtility.Foldout(groupState,group.Key,material);

                    if (foldoutScope.Foldout)
                    {
                        if (groupState.drawAction != null)
                        {

                            groupState.drawAction();

                        }

                    }
                    
                    groupState.display = foldoutScope.Foldout;
                    if (groupState.haveKeyword)
                    {
                        MaterialEditorUtility.SetKeyword(material,groupState.keywordName,groupState.keywordProperty.floatValue > 0);

                    }
                }
            }
        }

        void InitFoldoutGroup()
        {
            if (m_foldoutInited) return;

            m_foldoutGroup["MainTex"] = new foldoutGroupState()
            {
                display = true, haveKeyword = false, keywordName = "",
                drawAction = DrawMainTexProperties
                
            };
            m_foldoutGroup["MaskTex"] = new foldoutGroupState()
            {
                display = false, haveKeyword = true, keywordName = "MASKTEX_ENABLED",keywordProperty = _EnableMaskTex,
                drawAction = DrawMaskTexProperties
            };
            
            m_foldoutGroup["DissolveMap"] = new foldoutGroupState()
            {
                display = false, haveKeyword = true, keywordName = "DISSOLVE_ENABLED",keywordProperty = _EnableDissolve,
                drawAction = DrawDissolveProperties
            };
            m_foldoutGroup["FlowMap"] = new foldoutGroupState()
            {
                display = false, haveKeyword = true, keywordName = "FLOWMAP_ENABLED",keywordProperty = _EnableFlowMap,
                drawAction = DrawFlowMapProperties
            };
            m_foldoutGroup["Emission"] = new foldoutGroupState()
            {
                display = false, haveKeyword = false, keywordName = "",
                drawAction = DrawEmissionProperties
            };
            m_foldoutGroup["Rim"] = new foldoutGroupState()
            {
                display = false, haveKeyword = true, keywordName = "RIM_EFFECT_ENABLED",keywordProperty = _EnableRim,
                drawAction = DrawRimProperties
            };
            m_foldoutGroup["VertDisplacement"] = new foldoutGroupState()
            {
                display = false, haveKeyword = true, keywordName = "VERTEX_DISPLACEMENT_ENABLED",keywordProperty = _EnableVertexDisplacement,
                drawAction = DrawVertDisplacementProperties
            };

            m_foldoutGroup["AlphaClip"] = new foldoutGroupState()
            {
                display = false, haveKeyword = true, keywordName = "ALPHA_CLIP_ENABLED",keywordProperty = _EnableAlphaClip,
                drawAction = DrawAlphaClipProperties
            };
            m_foldoutGroup["SoftParicle"] = new foldoutGroupState()
            {
                display = false, haveKeyword = true, keywordName = "SOFT_PARTICLES_ENABLED",keywordProperty = _EnableSoftParticle,
                drawAction = DrawSoftPariclesProperties
            };
            m_foldoutGroup["SceneLighting"] = new foldoutGroupState()
            {
                display = false, haveKeyword = true, keywordName = "SCENE_LIGHTING_ENABLED",keywordProperty = _EnableSceneLighting,
                drawAction = DrawSceneLightingProperties
            };
            SetFoldoutStateKeyword();
            m_foldoutInited = true;
        }

        void SetFoldoutStateKeyword()
        {
            foreach (var group in m_foldoutGroup)
            {
                foldoutGroupState groupState = group.Value;
                if (groupState.haveKeyword)
                {
                    groupState.enableKeyword = groupState.keywordProperty.floatValue > 0;
                    if (!m_foldoutInited)
                    {
                        groupState.display = groupState.enableKeyword;
                    }
                }
            }
        }
        void DrawMainTexProperties()
        {
            m_materialEditor.ShaderProperty(_TintColor,"Tint Color");
            MaterialEditorUtility.DrawTexture(m_materialEditor, _MainTex, true, _MainTexOffsetCoordX, _MainTexOffsetCoordY, _MainTexTimeUVX, _MainTexTimeUVY);
            MaterialEditorUtility.DrawPropertyAndCustomCoord(m_materialEditor,"主贴图总体透明度(alpha)",_MainTexOverallAlpha,_MainTexOverallAlphaCoord);
            m_materialEditor.ShaderProperty(_MainTexSlantPowerX,"主贴图X方向拉伸程度");
            m_materialEditor.ShaderProperty(_MainTexSlantPowerY,"主贴图Y方向拉伸程度");
        }

        void DrawMaskTexProperties()
        {
            MaterialEditorUtility.DrawTexture(m_materialEditor, _MaskTex, true,_MaskTexOffsetCoordX,_MaskTexOffsetCoordY);
            MaterialEditorUtility.DrawPropertyAndCustomCoord(m_materialEditor,"Mask贴图混合程度",_MaskTexColorBlend,_MaskTexColorBlendCoord);
        }

        void DrawDissolveProperties()
        {
            MaterialEditorUtility.DrawTexture(m_materialEditor,_DissolveMap,true,_DissolveTexOffsetCoordX,_DissolveTexOffsetCoordY,_DissolveTimeUVX,_DissolveTimeUVY);
            m_materialEditor.ShaderProperty(_DissolveSharpness,"溶解图边缘硬度");
            MaterialEditorUtility.DrawPropertyAndCustomCoord(m_materialEditor,"溶解进度",_DissolveProgress,_DissolveProgressCoord);
            m_materialEditor.ShaderProperty(_UseDirectionalDissolve,"是否使用方向溶解");
            EditorGUILayout.LabelField("方向参数 X=正X强度 Y=正Y强度");
            m_materialEditor.ShaderProperty(_DissolveDirParam,"Z=负X强度 W=负Y强度");
            m_materialEditor.ShaderProperty(_DissolveDirSoftness,"方向溶解边缘软度");
        }

        void DrawFlowMapProperties()
        {
            MaterialEditorUtility.DrawTexture(m_materialEditor,_FlowMap,true,_FlowTexOffsetCoordX,_FlowTexOffsetCoordY,_FlowTimeUVX,_FlowTimeUVY);
            EditorGUILayout.LabelField("UV偏移强度 X=主贴图 Y=遮罩贴图 Z=溶解图");
            MaterialEditorUtility.DrawPropertyAndCustomCoord(m_materialEditor,"",_FlowIntensity,_FlowIntensityCoord);
            MaterialEditorUtility.DrawEnumProperty<ECustomCoord>(m_materialEditor,"UV置换 主贴图程度Coord",_FlowLerpMainCoord);
            MaterialEditorUtility.DrawEnumProperty<ECustomCoord>(m_materialEditor,"UV置换 遮罩贴图程度Coord",_FlowLerpMaskCoord);
            MaterialEditorUtility.DrawEnumProperty<ECustomCoord>(m_materialEditor,"UV置换 溶解图程度Coord",_FlowLerpDissolveCoord);
        }

        void DrawRimProperties()
        {
            m_materialEditor.ShaderProperty(_RimColor,"轮廓光颜色");
            m_materialEditor.ShaderProperty(_RimThreshold,"轮廓光阈值");
            m_materialEditor.ShaderProperty(_RimSmoothness,"轮廓光柔滑程度");
            MaterialEditorUtility.DrawPropertyAndCustomCoord(m_materialEditor,"轮廓光强度",_RimIntensity,_RimIntensityCoord);
            MaterialEditorUtility.DrawPropertyAndCustomCoord(m_materialEditor,"轮廓alpha系数",_RimAlphaWithFactor,_RimAlphaWithFactorCoord);
            EditorGUILayout.LabelField("深度检测的边缘光需要开启软粒子才生效");
            m_materialEditor.ShaderProperty(_RimIntersectLength,"深度边缘光长度");
            m_materialEditor.ShaderProperty(_RimBlendMode,"轮廓光混合模式");
        }
        void DrawEmissionProperties()
        {
            m_materialEditor.ShaderProperty(_EmissionColor,"发光颜色");
            // MaterialEditorUtility.DrawProperty(m_materialEditor, "发光颜色", _EmissionColor);
            MaterialEditorUtility.DrawPropertyAndCustomCoord(m_materialEditor,"发光颜色与原色混合程度",_EmissionColorBlend,_EmissionColorBlendCoord);
            MaterialEditorUtility.DrawPropertyAndCustomCoord(m_materialEditor,"发光强度",_EmissionIntensity,_EmissionIntensityCoord);
            EditorGUILayout.LabelField("发光使用溶解遮罩");
            m_materialEditor.ShaderProperty(_EmissionDissolveFactor,"溶解遮罩混合程度");
            MaterialEditorUtility.DrawPropertyAndCustomCoord(m_materialEditor,"发光溶解进度",_EmissionDissolveProgress,_EmissionDissolveProgressCoord);
            m_materialEditor.ShaderProperty(_EmissionDissolveSharpness,"发光溶解边缘硬度");

        }

        void DrawVertDisplacementProperties()
        {
            MaterialEditorUtility.DrawTexture(m_materialEditor,_VertDisplaceMap,true,_VertDisplaceTexOffsetCoordX,_VertDisplaceTexOffsetCoordY);
            MaterialEditorUtility.DrawPropertyAndCustomCoord(m_materialEditor,"顶点偏移强度",_VertDisplaceIntensity,_VertDisplaceIntensityCoord);
            m_materialEditor.ShaderProperty(_VertDisplaceDir, "偏移方向");
            m_materialEditor.ShaderProperty(_VertDisplaceSharpen, "顶点偏移锋利程度");
            m_materialEditor.ShaderProperty(_EnableApplyMaskToDisplacement, "是否运用遮罩图于顶点偏移");
            
        }

        void DrawAlphaClipProperties()
        {
            EditorGUILayout.LabelField("AlphaClip用于不透明时的剔除 可配合dissolve使用");
            m_materialEditor.ShaderProperty(_AlphaClipCutoff, "AlphaClip阈值");
        }

        void DrawSoftPariclesProperties()
        {
            m_materialEditor.ShaderProperty(_SoftParticleIntensity, "软粒子渐隐强度");

        }

        void DrawSceneLightingProperties()
        {
            m_materialEditor.ShaderProperty(_NdotLParam,"法线影响漫反射程度");
            m_materialEditor.ShaderProperty(_DiffuseFactor,"接受漫反射程度");
        }
    }
}