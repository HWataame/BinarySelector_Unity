/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
二択選択コントロールを描画するクラス

BinarySelectorGUI.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace HW.BinarySelector.Editor.GUIs
{
    /// <summary>
    /// 二択選択コントロールを描画するクラス
    /// </summary>
    public static class BinarySelectorGUI
    {
        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(Rect rect,
            bool value, string falseText, string trueText)
        {
            var buttonGUI = GUI.skin.button;
            var originalBackgroundColor = GUI.backgroundColor;

            // 値が複数で異なるか取得する
            bool isDifferent = EditorGUI.showMixedValue;

            // インデントの影響を無効化する
            var originalIndent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // falseボタンの範囲を計算する
            Rect currentRect = rect;
            currentRect.width /= 2;
            currentRect.height = EditorGUIUtility.singleLineHeight;
            currentRect = EditorGUI.IndentedRect(currentRect);
            if (isDifferent || value)
            {
                // falseボタンを描画する
                if (GUI.Toggle(currentRect, false, falseText, buttonGUI))
                {
                    // falseボタンが押された場合は値をfalseにする
                    value = false;
                }
            }
            else
            {
                // ダミーのfalseボタンを描画する
                GUI.backgroundColor = new(0.6f, 1f, 1f);
                EditorGUI.LabelField(currentRect, falseText, buttonGUI);
            }

            // trueボタンの範囲を計算する
            currentRect.xMin = currentRect.xMax;
            currentRect.xMax = rect.xMax;
            if (isDifferent || !value)
            {
                // trueボタンを描画する
                GUI.backgroundColor = originalBackgroundColor;
                if (GUI.Toggle(currentRect, false, trueText, buttonGUI))
                {
                    // trueボタンが押された場合は値をtrueにする
                    value = true;
                }
            }
            else
            {
                // ダミーのtrueボタンを描画する
                GUI.backgroundColor = new(0.6f, 1f, 1f);
                EditorGUI.LabelField(currentRect, trueText, buttonGUI);
                GUI.backgroundColor = originalBackgroundColor;
            }

            // インデントを戻す
            EditorGUI.indentLevel = originalIndent;

            return value;
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="labelText">左側のラベルの文字列</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(Rect rect,
            bool value, string labelText, string falseText, string trueText)
        {
            Rect currentRect = rect;
            if (!string.IsNullOrEmpty(labelText))
            {
                // ラベルの文字列が有効である場合はラベルを描画する
                currentRect.width = EditorGUIUtility.labelWidth;
                EditorGUI.LabelField(currentRect, labelText);

                // false／trueボタンの範囲を計算する
                currentRect.xMin = rect.x + EditorGUIUtility.labelWidth + 2;
                currentRect.xMax = rect.xMax;
            }

            // 二択ボタンを描画する
            return BinarySelectField(currentRect, value, falseText, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(Rect rect,
            bool value, GUIContent label, string falseText, string trueText)
        {
            Rect currentRect = rect;
            if (label != null && !string.IsNullOrEmpty(label.text))
            {
                // ラベルとその文字列が有効である場合はラベルを描画する
                currentRect.width = EditorGUIUtility.labelWidth;
                EditorGUI.LabelField(currentRect, label);

                // false／trueボタンの範囲を計算する
                currentRect.xMin = rect.x + EditorGUIUtility.labelWidth + 2;
                currentRect.xMax = rect.xMax;
            }

            // 二択ボタンを描画する
            return BinarySelectField(currentRect, value, falseText, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueText">trueボタンの文字列</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(Rect rect,
            SerializedProperty property, GUIContent label, string falseText, string trueText)
        {
            if (property.propertyType == SerializedPropertyType.Boolean)
            {
                // プロパティがbool型の場合
                using (new EditorGUI.PropertyScope(rect, label, property))
                {
                    // 値が混ざっているフラグをバックアップしてプロパティから設定する
                    bool originalMixed = EditorGUI.showMixedValue;
                    EditorGUI.showMixedValue = property.hasMultipleDifferentValues;

                    using (var change = new EditorGUI.ChangeCheckScope())
                    {
                        bool value = property.boolValue;

                        // 二択選択コントロールを描画する
                        value = BinarySelectField(
                            rect, property.boolValue, label, falseText, trueText);

                        // 変更された場合は変更を反映する
                        if (change.changed) property.boolValue = value;
                    }

                    // 値が混ざっているフラグを復元する
                    EditorGUI.showMixedValue = originalMixed;
                }
            }
            else
            {
                // プロパティがbool型ではない場合はプロパティのみ描画する
                EditorGUI.PropertyField(rect, property, label, true);
            }
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueText">trueボタンの文字列</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(Rect rect,
            SerializedProperty property, string falseText, string trueText)
        {
            // 二択選択コントロールを描画する
            BinarySelectField(rect, property, null, falseText, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(Rect rect,
            bool value, string falseText, GUIContent trueLabel)
        {
            var buttonGUI = GUI.skin.button;
            var originalBackgroundColor = GUI.backgroundColor;

            // 値が複数で異なるか取得する
            bool isDifferent = EditorGUI.showMixedValue;

            // インデントの影響を無効化する
            var originalIndent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // falseボタンの範囲を計算する
            Rect currentRect = rect;
            currentRect.width /= 2;
            currentRect.height = EditorGUIUtility.singleLineHeight;
            currentRect = EditorGUI.IndentedRect(currentRect);
            if (isDifferent || value)
            {
                // falseボタンを描画する
                if (GUI.Toggle(currentRect, false, falseText, buttonGUI))
                {
                    // falseボタンが押された場合は値をfalseにする
                    value = false;
                }
            }
            else
            {
                // ダミーのfalseボタンを描画する
                GUI.backgroundColor = new(0.6f, 1f, 1f);
                EditorGUI.LabelField(currentRect, falseText, buttonGUI);
            }

            // trueボタンの範囲を計算する
            currentRect.xMin = currentRect.xMax;
            currentRect.xMax = rect.xMax;
            if (isDifferent || !value)
            {
                // trueボタンを描画する
                GUI.backgroundColor = originalBackgroundColor;
                if (GUI.Toggle(currentRect, false, trueLabel, buttonGUI))
                {
                    // trueボタンが押された場合は値をtrueにする
                    value = true;
                }
            }
            else
            {
                // ダミーのtrueボタンを描画する
                GUI.backgroundColor = new(0.6f, 1f, 1f);
                EditorGUI.LabelField(currentRect, trueLabel, buttonGUI);
                GUI.backgroundColor = originalBackgroundColor;
            }

            // インデントを戻す
            EditorGUI.indentLevel = originalIndent;

            return value;
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="labelText">左側のラベルの文字列</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(Rect rect,
            bool value, string labelText, string falseText, GUIContent trueLabel)
        {
            Rect currentRect = rect;
            if (!string.IsNullOrEmpty(labelText))
            {
                // ラベルの文字列が有効である場合はラベルを描画する
                currentRect.width = EditorGUIUtility.labelWidth;
                EditorGUI.LabelField(currentRect, labelText);

                // false／trueボタンの範囲を計算する
                currentRect.xMin = rect.x + EditorGUIUtility.labelWidth + 2;
                currentRect.xMax = rect.xMax;
            }

            // 二択ボタンを描画する
            return BinarySelectField(currentRect, value, falseText, trueLabel);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(Rect rect,
            bool value, GUIContent label, string falseText, GUIContent trueLabel)
        {
            Rect currentRect = rect;
            if (label != null && !string.IsNullOrEmpty(label.text))
            {
                // ラベルとその文字列が有効である場合はラベルを描画する
                currentRect.width = EditorGUIUtility.labelWidth;
                EditorGUI.LabelField(currentRect, label);

                // false／trueボタンの範囲を計算する
                currentRect.xMin = rect.x + EditorGUIUtility.labelWidth + 2;
                currentRect.xMax = rect.xMax;
            }

            // 二択ボタンを描画する
            return BinarySelectField(currentRect, value, falseText, trueLabel);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(Rect rect,
            SerializedProperty property, GUIContent label, string falseText, GUIContent trueLabel)
        {
            if (property.propertyType == SerializedPropertyType.Boolean)
            {
                // プロパティがbool型の場合
                using (new EditorGUI.PropertyScope(rect, label, property))
                {
                    // 値が混ざっているフラグをバックアップしてプロパティから設定する
                    bool originalMixed = EditorGUI.showMixedValue;
                    EditorGUI.showMixedValue = property.hasMultipleDifferentValues;

                    using (var change = new EditorGUI.ChangeCheckScope())
                    {
                        bool value = property.boolValue;

                        // 二択選択コントロールを描画する
                        value = BinarySelectField(
                            rect, property.boolValue, label, falseText, trueLabel);

                        // 変更された場合は変更を反映する
                        if (change.changed) property.boolValue = value;
                    }

                    // 値が混ざっているフラグを復元する
                    EditorGUI.showMixedValue = originalMixed;
                }
            }
            else
            {
                // プロパティがbool型ではない場合はプロパティのみ描画する
                EditorGUI.PropertyField(rect, property, label, true);
            }
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(Rect rect,
            SerializedProperty property, string falseText, GUIContent trueLabel)
        {
            // 二択選択コントロールを描画する
            BinarySelectField(rect, property, null, falseText, trueLabel);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(Rect rect,
            bool value, GUIContent falseLabel, string trueText)
        {
            var buttonGUI = GUI.skin.button;
            var originalBackgroundColor = GUI.backgroundColor;

            // 値が複数で異なるか取得する
            bool isDifferent = EditorGUI.showMixedValue;

            // インデントの影響を無効化する
            var originalIndent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // falseボタンの範囲を計算する
            Rect currentRect = rect;
            currentRect.width /= 2;
            currentRect.height = EditorGUIUtility.singleLineHeight;
            currentRect = EditorGUI.IndentedRect(currentRect);
            if (isDifferent || value)
            {
                // falseボタンを描画する
                if (GUI.Toggle(currentRect, false, falseLabel, buttonGUI))
                {
                    // falseボタンが押された場合は値をfalseにする
                    value = false;
                }
            }
            else
            {
                // ダミーのfalseボタンを描画する
                GUI.backgroundColor = new(0.6f, 1f, 1f);
                EditorGUI.LabelField(currentRect, falseLabel, buttonGUI);
            }

            // trueボタンの範囲を計算する
            currentRect.xMin = currentRect.xMax;
            currentRect.xMax = rect.xMax;
            if (isDifferent || !value)
            {
                // trueボタンを描画する
                GUI.backgroundColor = originalBackgroundColor;
                if (GUI.Toggle(currentRect, false, trueText, buttonGUI))
                {
                    // trueボタンが押された場合は値をtrueにする
                    value = true;
                }
            }
            else
            {
                // ダミーのtrueボタンを描画する
                GUI.backgroundColor = new(0.6f, 1f, 1f);
                EditorGUI.LabelField(currentRect, trueText, buttonGUI);
                GUI.backgroundColor = originalBackgroundColor;
            }

            // インデントを戻す
            EditorGUI.indentLevel = originalIndent;

            return value;
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="labelText">左側のラベルの文字列</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(Rect rect,
            bool value, string labelText, GUIContent falseLabel, string trueText)
        {
            Rect currentRect = rect;
            if (!string.IsNullOrEmpty(labelText))
            {
                // ラベルの文字列が有効である場合はラベルを描画する
                currentRect.width = EditorGUIUtility.labelWidth;
                EditorGUI.LabelField(currentRect, labelText);

                // false／trueボタンの範囲を計算する
                currentRect.xMin = rect.x + EditorGUIUtility.labelWidth + 2;
                currentRect.xMax = rect.xMax;
            }

            // 二択ボタンを描画する
            return BinarySelectField(currentRect, value, falseLabel, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(Rect rect,
            bool value, GUIContent label, GUIContent falseLabel, string trueText)
        {
            Rect currentRect = rect;
            if (label != null && !string.IsNullOrEmpty(label.text))
            {
                // ラベルとその文字列が有効である場合はラベルを描画する
                currentRect.width = EditorGUIUtility.labelWidth;
                EditorGUI.LabelField(currentRect, label);

                // false／trueボタンの範囲を計算する
                currentRect.xMin = rect.x + EditorGUIUtility.labelWidth + 2;
                currentRect.xMax = rect.xMax;
            }

            // 二択ボタンを描画する
            return BinarySelectField(currentRect, value, falseLabel, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンの文字列</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(Rect rect,
            SerializedProperty property, GUIContent label, GUIContent falseLabel, string trueText)
        {
            if (property.propertyType == SerializedPropertyType.Boolean)
            {
                // プロパティがbool型の場合
                using (new EditorGUI.PropertyScope(rect, label, property))
                {
                    // 値が混ざっているフラグをバックアップしてプロパティから設定する
                    bool originalMixed = EditorGUI.showMixedValue;
                    EditorGUI.showMixedValue = property.hasMultipleDifferentValues;

                    using (var change = new EditorGUI.ChangeCheckScope())
                    {
                        bool value = property.boolValue;

                        // 二択選択コントロールを描画する
                        value = BinarySelectField(
                            rect, property.boolValue, label, falseLabel, trueText);

                        // 変更された場合は変更を反映する
                        if (change.changed) property.boolValue = value;
                    }

                    // 値が混ざっているフラグを復元する
                    EditorGUI.showMixedValue = originalMixed;
                }
            }
            else
            {
                // プロパティがbool型ではない場合はプロパティのみ描画する
                EditorGUI.PropertyField(rect, property, label, true);
            }
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンの文字列</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(Rect rect,
            SerializedProperty property, GUIContent falseLabel, string trueText)
        {
            // 二択選択コントロールを描画する
            BinarySelectField(rect, property, null, falseLabel, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="falseText">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンのラベル</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(Rect rect,
            bool value, GUIContent falseLabel, GUIContent trueLabel)
        {
            var buttonGUI = GUI.skin.button;
            var originalBackgroundColor = GUI.backgroundColor;

            // 値が複数で異なるか取得する
            bool isDifferent = EditorGUI.showMixedValue;

            // インデントの影響を無効化する
            var originalIndent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // falseボタンの範囲を計算する
            Rect currentRect = rect;
            currentRect.width /= 2;
            currentRect.height = EditorGUIUtility.singleLineHeight;
            currentRect = EditorGUI.IndentedRect(currentRect);
            if (isDifferent || value)
            {
                // falseボタンを描画する
                if (GUI.Toggle(currentRect, false, falseLabel, buttonGUI))
                {
                    // falseボタンが押された場合は値をfalseにする
                    value = false;
                }
            }
            else
            {
                // ダミーのfalseボタンを描画する
                GUI.backgroundColor = new(0.6f, 1f, 1f);
                EditorGUI.LabelField(currentRect, falseLabel, buttonGUI);
            }

            // trueボタンの範囲を計算する
            currentRect.xMin = currentRect.xMax;
            currentRect.xMax = rect.xMax;
            if (isDifferent || !value)
            {
                // trueボタンを描画する
                GUI.backgroundColor = originalBackgroundColor;
                if (GUI.Toggle(currentRect, false, trueLabel, buttonGUI))
                {
                    // trueボタンが押された場合は値をtrueにする
                    value = true;
                }
            }
            else
            {
                // ダミーのtrueボタンを描画する
                GUI.backgroundColor = new(0.6f, 1f, 1f);
                EditorGUI.LabelField(currentRect, trueLabel, buttonGUI);
                GUI.backgroundColor = originalBackgroundColor;
            }

            // インデントを戻す
            EditorGUI.indentLevel = originalIndent;

            return value;
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseText">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンのラベル</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(Rect rect,
            bool value, GUIContent label, GUIContent falseLabel, GUIContent trueLabel)
        {
            Rect currentRect = rect;
            if (label != null && !string.IsNullOrEmpty(label.text))
            {
                // ラベルとその文字列が有効である場合はラベルを描画する
                currentRect.width = EditorGUIUtility.labelWidth;
                EditorGUI.LabelField(currentRect, label);

                // false／trueボタンの範囲を計算する
                currentRect.xMin = rect.x + EditorGUIUtility.labelWidth + 2;
                currentRect.xMax = rect.xMax;
            }

            // 二択ボタンを描画する
            return BinarySelectField(currentRect, value, falseLabel, trueLabel);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(Rect rect,
            SerializedProperty property, GUIContent label, GUIContent falseLabel, GUIContent trueLabel)
        {
            if (property.propertyType == SerializedPropertyType.Boolean)
            {
                // プロパティがbool型の場合
                using (new EditorGUI.PropertyScope(rect, label, property))
                {
                    // 値が混ざっているフラグをバックアップしてプロパティから設定する
                    bool originalMixed = EditorGUI.showMixedValue;
                    EditorGUI.showMixedValue = property.hasMultipleDifferentValues;

                    using (var change = new EditorGUI.ChangeCheckScope())
                    {
                        bool value = property.boolValue;

                        // 二択選択コントロールを描画する
                        value = BinarySelectField(
                            rect, property.boolValue, label, falseLabel, trueLabel);

                        // 変更された場合は変更を反映する
                        if (change.changed) property.boolValue = value;
                    }

                    // 値が混ざっているフラグを復元する
                    EditorGUI.showMixedValue = originalMixed;
                }
            }
            else
            {
                // プロパティがbool型ではない場合はプロパティのみ描画する
                EditorGUI.PropertyField(rect, property, label, true);
            }
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="rect">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(Rect rect,
            SerializedProperty property, GUIContent falseLabel, GUIContent trueLabel)
        {
            BinarySelectField(rect, property, null, falseLabel, trueLabel);
        }
    }
}
