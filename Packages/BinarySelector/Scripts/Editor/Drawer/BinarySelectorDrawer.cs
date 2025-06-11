/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
[BinarySelector]の二択選択コントロールを適用するクラス

BinarySelectorDrawer.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using HW.BinarySelector.Editor.GUIs;
using UnityEditor;
using UnityEngine;

namespace HW.BinarySelector.Editor.Drawer
{
    /// <summary>
    /// [BinarySelector]の二択選択コントロールを適用するクラス
    /// </summary>
    [CustomPropertyDrawer(typeof(BinarySelectorAttribute))]
    internal sealed class BinarySelectorDrawer : PropertyDrawer
    {
        /// <summary>
        /// プロパティを描画する
        /// </summary>
        /// <param name="position">プロパティの範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">ラベル</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.Boolean &&
                (attribute is BinarySelectorAttribute selector))
            {
                // プロパティがbool型の場合は二択選択GUIを描画する
                bool isFalseGUI = selector.IsUseFalseContent;
                bool isTrueGUI = selector.IsUseTrueContent;
                if (isFalseGUI && isTrueGUI)
                {
                    // 両方のボタンがGUIContentを使用する場合
                    BinarySelectorGUI.BinarySelectField(position, property, label, selector.FalseGUI, selector.TrueGUI);
                }
                else if (isFalseGUI)
                {
                    // falseボタンのみGUIContentを使用する場合
                    BinarySelectorGUI.BinarySelectField(position, property, label, selector.FalseGUI, selector.TrueText);
                }
                else if (isTrueGUI)
                {
                    // trueボタンのみGUIContentを使用する場合
                    BinarySelectorGUI.BinarySelectField(position, property, label, selector.FalseText, selector.TrueGUI);
                }
                else
                {
                    // 両方とも文字列を使用する場合
                    BinarySelectorGUI.BinarySelectField(position, property, label, selector.FalseText, selector.TrueText);
                }
            }
            else
            {
                // プロパティがbool型ではない場合はプロパティのみ描画する
                EditorGUI.PropertyField(position, property, label, true);
            }
        }

        /// <summary>
        /// プロパティの高さを取得する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">ラベル</param>
        /// <returns>プロパティの高さ</returns>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            // プロパティの高さを取得する
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}
