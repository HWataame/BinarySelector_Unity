/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
自動レイアウトを適用した二択選択コントロールを描画するクラス

BinarySelectorGUILayout.cs
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
    /// 自動レイアウトを適用した二択選択コントロールを描画するクラス
    /// </summary>
    public static class BinarySelectorGUILayout
    {
        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(bool value,
            string falseText, string trueText, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            return BinarySelectorGUI.BinarySelectField(rect, value, falseText, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="labelText">左側のラベルの文字列</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(bool value,
            string labelText, string falseText, string trueText, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            return BinarySelectorGUI.BinarySelectField(rect, value, labelText, falseText, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(bool value,
            GUIContent label, string falseText, string trueText, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            return BinarySelectorGUI.BinarySelectField(rect, value, label, falseText, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(SerializedProperty property,
            GUIContent label, string falseText, string trueText, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            BinarySelectorGUI.BinarySelectField(rect, property, label, falseText, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(SerializedProperty property,
            string falseText, string trueText, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            BinarySelectorGUI.BinarySelectField(rect, property, falseText, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(bool value,
            string falseText, GUIContent trueLabel, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            return BinarySelectorGUI.BinarySelectField(rect, value, falseText, trueLabel);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="labelText">左側のラベルの文字列</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(bool value,
            string labelText, string falseText, GUIContent trueLabel, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            return BinarySelectorGUI.BinarySelectField(rect, value, labelText, falseText, trueLabel);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(bool value,
            GUIContent label, string falseText, GUIContent trueLabel, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            return BinarySelectorGUI.BinarySelectField(rect, value, label, falseText, trueLabel);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(SerializedProperty property,
            GUIContent label, string falseText, GUIContent trueLabel, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            BinarySelectorGUI.BinarySelectField(rect, property, label, falseText, trueLabel);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(SerializedProperty property,
            string falseText, GUIContent trueLabel, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            BinarySelectorGUI.BinarySelectField(rect, property, falseText, trueLabel);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(bool value,
            GUIContent falseLabel, string trueText, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            return BinarySelectorGUI.BinarySelectField(rect, value, falseLabel, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="labelText">左側のラベルの文字列</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(bool value,
            string labelText, GUIContent falseLabel, string trueText, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            return BinarySelectorGUI.BinarySelectField(rect, value, labelText, falseLabel, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(bool value,
            GUIContent label, GUIContent falseLabel, string trueText, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            return BinarySelectorGUI.BinarySelectField(rect, value, label, falseLabel, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(SerializedProperty property,
            GUIContent label, GUIContent falseLabel, string trueText, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            BinarySelectorGUI.BinarySelectField(rect, property, label, falseLabel, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(SerializedProperty property,
            GUIContent falseLabel, string trueText, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            BinarySelectorGUI.BinarySelectField(rect, property, falseLabel, trueText);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="falseText">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンのラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(bool value,
            GUIContent falseLabel, GUIContent trueLabel, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(false, options);
            return BinarySelectorGUI.BinarySelectField(rect, value, falseLabel, trueLabel);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="value">変更前の値</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseText">falseボタンのラベル</param>
        /// <param name="trueText">trueボタンのラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        /// <returns>変更後の値</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BinarySelectField(bool value,
            GUIContent label, GUIContent falseLabel, GUIContent trueLabel, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            return BinarySelectorGUI.BinarySelectField(rect, value, label, falseLabel, trueLabel);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">左側のラベル</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(SerializedProperty property,
            GUIContent label, GUIContent falseLabel, GUIContent trueLabel, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            BinarySelectorGUI.BinarySelectField(rect, property, label, falseLabel, trueLabel);
        }

        /// <summary>
        /// ブール値を二択で選択するコントロールを描画する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="falseLabel">falseボタンのラベル</param>
        /// <param name="trueLabel">trueボタンのラベル</param>
        /// <param name="options">自動レイアウトのオプション</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BinarySelectField(SerializedProperty property,
            GUIContent falseLabel, GUIContent trueLabel, params GUILayoutOption[] options)
        {
            // 二択選択コントロールを描画する
            var rect = EditorGUILayout.GetControlRect(true, options);
            BinarySelectorGUI.BinarySelectField(rect, property, falseLabel, trueLabel);
        }
    }
}
