/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ブール値を二択で選択できることを示す属性

BinarySelectorAttribute.cs
────────────────────────────────────────
バージョン: 1.0.1
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace HW.BinarySelector
{
    /// <summary>
    /// ブール値を二択で選択できることを示す属性
    /// </summary>
    [Conditional("UNITY_EDITOR")]
    public sealed class BinarySelectorAttribute : PropertyAttribute
    {
        /// <summary>
        /// falseボタンにGUIContentを使用するか
        /// </summary>
        private readonly bool isUseFalseContent;
        /// <summary>
        /// trueボタンにGUIContentを使用するか
        /// </summary>
        private readonly bool isUseTrueContent;

        /// <summary>
        /// falseボタンの文字列
        /// </summary>
        private readonly string falseText;
        /// <summary>
        /// trueボタンの文字列
        /// </summary>
        private readonly string trueText;

        /// <summary>
        /// falseボタンのGUI
        /// </summary>
        private readonly GUIContent falseGUI;
        /// <summary>
        /// trueボタンのGUI
        /// </summary>
        private readonly GUIContent trueGUI;

        /// <summary>
        /// GUIContentを使用するか
        /// </summary>
        public bool IsUseFalseContent
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => isUseFalseContent;
        }

        /// <summary>
        /// trueボタンにGUIContentを使用するか
        /// </summary>
        public bool IsUseTrueContent
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => isUseTrueContent;
        }

        /// <summary>
        /// falseボタンのGUI
        /// </summary>
        public GUIContent FalseGUI
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => falseGUI;
        }

        /// <summary>
        /// trueボタンのGUI
        /// </summary>
        public GUIContent TrueGUI
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => trueGUI;
        }

        /// <summary>
        /// falseボタンの文字列
        /// </summary>
        public string FalseText
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => falseText;
        }

        /// <summary>
        /// trueボタンの文字列
        /// </summary>
        public string TrueText
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => trueText;
        }


        /// <summary>
        /// フィールドのブール値を二択で選択できるようにする属性
        /// </summary>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueText">trueボタンの文字列</param>
        public BinarySelectorAttribute(string falseText, string trueText)
        {
            // 表示名の文字列を設定する
            this.falseText = (string.IsNullOrWhiteSpace(falseText)) ? "false" : falseText;
            this.trueText = (string.IsNullOrWhiteSpace(trueText)) ? "true" : trueText;

            // GUIContentを使用しないことを設定する
            falseGUI = null;
            trueGUI = null;
            isUseFalseContent = false;
            isUseTrueContent = false;
        }

        /// <summary>
        /// フィールドのブール値を二択で選択できるようにする属性
        /// </summary>
        /// <param name="falseText">falseボタンの文字列</param>
        /// <param name="trueText">trueボタンの文字列</param>
        /// <param name="falseTooltip">falseボタンのツールチップ</param>
        /// <param name="trueTooltip">trueボタンのツールチップ</param>
        public BinarySelectorAttribute(string falseText, string trueText, string falseTooltip, string trueTooltip)
        {
            // ボタンの文字列が許容されないものである場合は既定の文字列を使用する
            if (string.IsNullOrWhiteSpace(falseText)) falseText = "false";
            if (string.IsNullOrWhiteSpace(trueText)) trueText = "true";

            bool isEmptyFalseTooltip = string.IsNullOrWhiteSpace(falseTooltip);
            bool isEmptyTrueTooltip = string.IsNullOrWhiteSpace(trueTooltip);
            if (isEmptyFalseTooltip && isEmptyTrueTooltip)
            {
                // 両方のボタンのtooltipの文字列が許容しないものである場合
                this.falseText = (!string.IsNullOrWhiteSpace(falseText)) ? falseText : "false";
                this.trueText = (!string.IsNullOrWhiteSpace(trueText)) ? trueText : "true";

                // GUIContentを使用しないことを設定する
                falseGUI = null;
                trueGUI = null;
                isUseFalseContent = false;
            }
            else
            {
                // いずれかのボタンのtooltipが許容するものである場合
                if (isEmptyFalseTooltip)
                {
                    // falseボタンのtooltipの文字列が許容しないものである場合
                    this.falseText = falseText;

                    // trueボタンではGUIContentを使用しないことを設定する
                    falseGUI = null;
                    isUseFalseContent = false;
                }
                else
                {
                    // falseボタンのtooltipの文字列が許容するものである場合
                    falseGUI = new(falseText, falseTooltip);

                    // falseボタンでは単独の文字列を使用しないことを設定する
                    this.falseText = null;
                    isUseFalseContent = true;
                }

                if (isEmptyTrueTooltip)
                {
                    // trueボタンのtooltipの文字列が許容しないものである場合
                    this.trueText = trueText;

                    // trueボタンではGUIContentを使用しないことを設定する
                    trueGUI = null;
                    isUseTrueContent = false;
                }
                else
                {
                    // trueボタンのtooltipの文字列が許容するものである場合
                    trueGUI = new(trueText, trueTooltip);

                    // trueボタンでは単独の文字列を使用しないことを設定する
                    this.trueText = null;
                    isUseTrueContent = true;
                }
            }
        }
    }
}
