using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace UberEffect
{
    public class foldoutGroupState
    {
        public bool display = false;
        public bool haveKeyword = false;
        public string keywordName = "";
        public bool enableKeyword = false;
        public MaterialProperty keywordProperty;
        public Action drawAction;
    }
    
    public class MaterialEditorUtility
    {
        public class ResetIndentLevelScope : GUI.Scope
        {
            private readonly int _indentLevel;

            public ResetIndentLevelScope()
            {
                _indentLevel = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 0;
            }

            protected override void CloseScope()
            {
                EditorGUI.indentLevel = _indentLevel;
            }
        }
        public class FoldoutHeaderScope : GUI.Scope
        {
            private static GUIStyle _textStyle;
            private static Color TextColor => EditorStyles.label.normal.textColor;

            public FoldoutHeaderScope(foldoutGroupState groupState, string text)
            {
                Foldout = groupState.display;
                var style = new GUIStyle("ShurikenModuleTitle"); // BG
                style.font = EditorStyles.boldLabel.font;
                style.fontSize = EditorStyles.boldLabel.fontSize + 3;
                // style.border = new RectOffset(15, 7, 4, 4);
                style.fixedHeight = 30;
                EditorGUILayout.BeginVertical(style);
                var rect = EditorGUILayout.GetControlRect();
                var iconRect = rect;
                var height = iconRect.height;
                iconRect.width = 12;
                iconRect.height = 9;
                iconRect.y += (height - iconRect.height) / 2;

                var buttonRect = rect;
                buttonRect.y -= EditorGUIUtility.standardVerticalSpacing;
                buttonRect.height += EditorGUIUtility.standardVerticalSpacing * 2.0f;

                var textRect = rect;
                textRect.xMin += 17;
                
                if (groupState.haveKeyword)
                {
                    var toggleResult = GUI.Toggle(iconRect, groupState.keywordProperty.floatValue>0, "");
                    groupState.keywordProperty.floatValue = toggleResult ? 1 : 0;
                }
                // GUI.DrawTexture(iconRect,Texture2D.grayTexture,ScaleMode.ScaleToFit);

                // var iconImage = foldout ? GetFoldoutTrueIcon() : GetFoldoutFalseIcon();
                // GUI.DrawTexture(iconRect, iconImage, ScaleMode.ScaleToFit);
                if (_textStyle == null)
                {
                    _textStyle = new GUIStyle
                    {
                        padding = new RectOffset(0, 0, 2, 0),
                        normal =
                        {
                            textColor = TextColor
                        },
                        fontStyle = FontStyle.Bold
                    };
                }

                GUI.Label(textRect, text, _textStyle);
                if (GUI.Button(buttonRect, string.Empty, _textStyle))
                {
                    Foldout = !Foldout;
                }

                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical();
                if (Foldout)
                {
                    GUILayout.Space(6);
                }
            }

            public bool Foldout { get; }

            protected override void CloseScope()
            {
                // When not in foldout state, this space must be greater than or equal to 12 because the display will collapse.
                var space = Foldout ? 6 : 12;
                GUILayout.Space(space);
                EditorGUILayout.EndVertical();
            }
        }
        
        private static void DrawProperty(string label, Action<Rect> drawContents)
        {
            var fullRect = EditorGUILayout.GetControlRect();
            var contentsRect = EditorGUI.PrefixLabel(fullRect, new GUIContent(label));
            contentsRect.xMin -= 2;

            using (new ResetIndentLevelScope())
            {
                drawContents.Invoke(contentsRect);
            }
        }

        public static void DrawEnumProperty<T>(MaterialEditor editor, string label, MaterialProperty property)
            where T : Enum
        {
            DrawProperty(label, rect => { DrawEnumContentsProperty<T>(editor, rect, property); });
        }

        public static void DrawPropertyAndCustomCoord(MaterialEditor editor, string label, MaterialProperty property,
            MaterialProperty coordProperty)
        {
            var fullRect = EditorGUILayout.GetControlRect();
            var contentsRect = fullRect;
            contentsRect.xMin += EditorGUIUtility.labelWidth;
            var propertyRect = fullRect;
            propertyRect.xMax -= contentsRect.width / 2;
            var coordRect = contentsRect;
            coordRect.width -= contentsRect.width / 2;
            coordRect.x += contentsRect.width / 2;

            editor.ShaderProperty(propertyRect, property, label);

            using (new ResetIndentLevelScope())
            {
                var coord = (ECustomCoord)coordProperty.floatValue;
                using (var ccs = new EditorGUI.ChangeCheckScope())
                {
                    EditorGUI.showMixedValue = coordProperty.hasMixedValue;
                    coord = (ECustomCoord)EditorGUI.EnumPopup(coordRect, coord);
                    EditorGUI.showMixedValue = false;

                    if (ccs.changed)
                    {
                        editor.RegisterPropertyChangeUndo(coordProperty.name);
                        coordProperty.floatValue = (int)coord;
                    }
                }
            }
        }

        public static void DrawTexture(MaterialEditor editor, MaterialProperty textureProperty, bool drawTilingAndOffset)
        {
            DrawTexture(editor, textureProperty, drawTilingAndOffset, null, null, null, null);
        }

        public static void DrawTexture(MaterialEditor editor, MaterialProperty textureProperty,
            bool drawTilingAndOffset,
            MaterialProperty offsetCoordXProperty, MaterialProperty offsetCoordYProperty)
        {
            DrawTexture(editor, textureProperty, drawTilingAndOffset, offsetCoordXProperty, offsetCoordYProperty, null, null);
        }

        public static void DrawTexture(MaterialEditor editor, MaterialProperty textureProperty,
            bool drawTilingAndOffset,
            MaterialProperty offsetCoordXProperty, MaterialProperty offsetCoordYProperty,
            MaterialProperty timeOffsetXProperty, MaterialProperty timeOffsetYProperty)
        {
            var propertyCount = 0;
            if (drawTilingAndOffset)
            {
                propertyCount += 2;
            }

            var useOffsetCoord = offsetCoordXProperty != null && offsetCoordYProperty != null;
            if (useOffsetCoord)
            {
                propertyCount += 1;
            }

            var useTimeOffset = timeOffsetXProperty != null && timeOffsetYProperty != null;
            if (useTimeOffset)
            {
                propertyCount += 1;
            }

            var contentsHeight = propertyCount * EditorGUIUtility.singleLineHeight +
                                 (propertyCount - 2) * EditorGUIUtility.standardVerticalSpacing;
            var fullHeight = Mathf.Max(contentsHeight + 8, 64);
            fullHeight += EditorGUIUtility.standardVerticalSpacing;

            var fullRect = EditorGUILayout.GetControlRect(false, fullHeight);

            var innerRect = fullRect;
            innerRect = EditorGUI.IndentedRect(innerRect);
            innerRect.height -= 8;
            innerRect.y += 4;

            var textureRect = innerRect;
            textureRect.height = 56;
            textureRect.width = textureRect.height;
            textureRect.y += (innerRect.height - textureRect.height) / 2;

            var contentsRect = fullRect;
            contentsRect = EditorGUI.IndentedRect(contentsRect);
            contentsRect.height = contentsHeight;
            contentsRect.y += (fullHeight - contentsHeight) / 2;
            contentsRect.xMin += textureRect.width + 4;

            var labelRect = contentsRect;
            labelRect.height = EditorGUIUtility.singleLineHeight;
            labelRect.xMax -= fullRect.width - EditorGUIUtility.labelWidth;

            var propertyRect = contentsRect;
            propertyRect.height = EditorGUIUtility.singleLineHeight;
            propertyRect.xMin += labelRect.width;

            // Draw properties.
            // Texture
            using (new ResetIndentLevelScope())
            {
                Type textureType;
                switch (textureProperty.textureDimension)
                {
                    case TextureDimension.Unknown:
                    case TextureDimension.None:
                    case TextureDimension.Any:
                        textureType = typeof(Texture);
                        break;
                    case TextureDimension.Tex2D:
                    case TextureDimension.Cube:
                        textureType = typeof(Texture2D);
                        break;
                    case TextureDimension.Tex3D:
                        textureType = typeof(Texture3D);
                        break;
                    case TextureDimension.Tex2DArray:
                    case TextureDimension.CubeArray:
                        textureType = typeof(Texture2DArray);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
                {
                    var texture = (Texture)EditorGUI.ObjectField(textureRect, textureProperty.textureValue, textureType,
                        false);
                    if (changeCheckScope.changed)
                    {
                        editor.RegisterPropertyChangeUndo(textureProperty.name);
                        textureProperty.textureValue = texture;
                    }
                }

                // Labels
                if (drawTilingAndOffset)
                {
                    GUI.Label(labelRect, "Tiling");
                    labelRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                    GUI.Label(labelRect, "Offset");
                }

                if (useOffsetCoord)
                {
                    labelRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                    GUI.Label(labelRect, "Offset Coords");
                }

                if (useTimeOffset)
                {
                    labelRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                    GUI.Label(labelRect, "Time UV");
                }

                // Tiling & Offsets
                if (drawTilingAndOffset)
                {
                    using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
                    {
                        var textureScaleAndOffset = textureProperty.textureScaleAndOffset;
                        var tiling = new Vector2(textureScaleAndOffset.x, textureScaleAndOffset.y);
                        var offset = new Vector2(textureScaleAndOffset.z, textureScaleAndOffset.w);
                        tiling = EditorGUI.Vector2Field(propertyRect, string.Empty, tiling);
                        propertyRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                        offset = EditorGUI.Vector2Field(propertyRect, string.Empty, offset);
                        if (changeCheckScope.changed)
                        {
                            textureScaleAndOffset = new Vector4(tiling.x, tiling.y, offset.x, offset.y);
                            editor.RegisterPropertyChangeUndo(textureProperty.name);
                            textureProperty.textureScaleAndOffset = textureScaleAndOffset;
                        }
                    }
                }

                // Offset Coords
                if (useOffsetCoord)
                {
                    propertyRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                    var xRect = propertyRect;
                    xRect.width /= 2;
                    var xPropertyRect = xRect;
                    xPropertyRect.xMin += 12;
                    EditorGUI.LabelField(xRect, new GUIContent("X"));
                    DrawEnumContentsProperty<ECustomCoord>(editor, xPropertyRect, offsetCoordXProperty);

                    var yRect = xRect;
                    yRect.x += yRect.width + 2;
                    yRect.xMax -= 2;
                    var yPropertyRect = yRect;
                    yPropertyRect.xMin += 12;
                    EditorGUI.LabelField(yRect, new GUIContent("Y"));
                    DrawEnumContentsProperty<ECustomCoord>(editor, yPropertyRect, offsetCoordYProperty);
                }

                if (useTimeOffset)
                {
                    using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
                    {
                        propertyRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                        var timeUV = new Vector2(timeOffsetXProperty.floatValue, timeOffsetYProperty.floatValue);
                        var timeUVGUI = EditorGUI.Vector2Field(propertyRect, string.Empty, timeUV);
                        if (changeCheckScope.changed)
                        {
                            timeOffsetXProperty.floatValue = timeUVGUI.x;
                            timeOffsetYProperty.floatValue = timeUVGUI.y;
                            editor.RegisterPropertyChangeUndo(textureProperty.name);
                        }
                    }
                }
            }
        }

        public static void DrawTwoFloatProperties(string title, MaterialProperty prop1, string prop1Label,
            MaterialProperty prop2, string prop2Label, MaterialEditor materialEditor, float propLabelWidth = 30f)
        {
            EditorGUI.showMixedValue = prop1.hasMixedValue || prop2.hasMixedValue;
            var rect = EditorGUILayout.GetControlRect();
            EditorGUI.PrefixLabel(rect, new GUIContent(title));
            var indent = EditorGUI.indentLevel;
            var labelWidth = EditorGUIUtility.labelWidth;
            EditorGUI.indentLevel = 0;

            using (var ccs = new EditorGUI.ChangeCheckScope())
            {
                EditorGUIUtility.labelWidth = propLabelWidth;
                var prop1Rect = new Rect(rect.x + labelWidth, rect.y, (rect.width - labelWidth) * 0.5f,
                    EditorGUIUtility.singleLineHeight);
                var prop1Value = EditorGUI.FloatField(prop1Rect, prop1Label, prop1.floatValue);

                var prop2Rect = new Rect(prop1Rect.x + prop1Rect.width, rect.y,
                    prop1Rect.width, EditorGUIUtility.singleLineHeight);
                prop2Rect.xMin += 4;
                var prop2Value = EditorGUI.FloatField(prop2Rect, prop2Label, prop2.floatValue);
                EditorGUIUtility.labelWidth = labelWidth;

                if (ccs.changed)
                {
                    materialEditor.RegisterPropertyChangeUndo(title);
                    prop1.floatValue = prop1Value;
                    prop2.floatValue = prop2Value;
                }
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.showMixedValue = false;
        }


        private static void DrawEnumContentsProperty<T>(MaterialEditor editor, Rect rect, MaterialProperty property)
            where T : Enum
        {
            var value = (T)Enum.ToObject(typeof(T), (int)property.floatValue);
            using (var ccs = new EditorGUI.ChangeCheckScope())
            {
                EditorGUI.showMixedValue = property.hasMixedValue;

                var intValue = Convert.ToInt32(EditorGUI.EnumPopup(rect, value));
                EditorGUI.showMixedValue = false;

                if (ccs.changed)
                {
                    editor.RegisterPropertyChangeUndo(property.name);
                    property.floatValue = intValue;
                }
            }
        }

        public static void TransparentSwitchButtonDraw(MaterialProperty srcBlend, MaterialProperty dstBlend, MaterialProperty zWrite)
        {
            if (srcBlend == null || dstBlend == null || zWrite == null)
                return;
            if (srcBlend.type != MaterialProperty.PropType.Float || dstBlend.type != MaterialProperty.PropType.Float
                                                                 || zWrite.type != MaterialProperty.PropType.Float)
                return;

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("不透明"))
            {
                srcBlend.floatValue = (int)BlendMode.One;
                dstBlend.floatValue = (int)BlendMode.Zero;
                zWrite.floatValue = 1;
                foreach (Material m in srcBlend.targets)
                {
                    m.renderQueue = 2000;
                }
            }

            if (GUILayout.Button("AlphaBlend"))
            {
                srcBlend.floatValue = (int)BlendMode.SrcAlpha;
                dstBlend.floatValue = (int)BlendMode.OneMinusSrcAlpha;
                zWrite.floatValue = 0;
                foreach (Material m in srcBlend.targets)
                {
                    m.renderQueue = 3000;
                }
            }

            if (GUILayout.Button("Additive"))
            {
                srcBlend.floatValue = (int)BlendMode.SrcAlpha;
                dstBlend.floatValue = (int)BlendMode.One;
                zWrite.floatValue = 0;
                foreach (Material m in srcBlend.targets)
                {
                    m.renderQueue = 3000;
                }
            }

            EditorGUILayout.EndHorizontal();
        }

        public static void SetKeyword(Material material, string keyword, bool state)
        {
            if (state)
            {
                material.EnableKeyword(keyword);
            }
            else
            {
                material.DisableKeyword(keyword);
            }
        }
    }
}