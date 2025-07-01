# BinarySelector
![トップ画像](https://github.com/user-attachments/assets/19ea8e7c-1ba7-4399-adb5-bfa0ae16e6da)

## 概要 / Overview
エディター上にbool値を二択で選択できるようにするGUIコントロールとシリアル化対象のフィールド用の属性を追加します / Add a GUI control to allow two choices of bool values on the editor and an attribute for the serialized field

## 使用方法 / Usage
### bool型のフィールドに適用する / Apply BinarySelector to serialized boolean field
`[BinarySelector]`属性をシリアル化されるbool型のフィールドに付与すると、そのフィールドが二択で選択するGUIコントロールで描画されます / 
Add `[BinarySelector]` to serialized bool field, inspector of the field changes to two-options GUI

#### ツールチップなし版 / No tooltip(s) version
![属性の説明1](https://github.com/user-attachments/assets/3bfbba78-7a2a-4e0a-af41-32e8e4eb669a)
```csharp
[SerializeField][BinarySelector("False button text", "True button text")]
private bool booleanField;
```

#### ツールチップあり版 / With tooltip(s) version
![属性の説明2](https://github.com/user-attachments/assets/66166c17-5a6f-458b-a860-0651c25fbabb)
```csharp
[SerializeField][BinarySelector("False button text", "True button text", "False button tooltip", "True button tooltip")]
private bool booleanField;
```

ツールチップに`null`を指定することで、片方だけツールチップなしにすることもできます / 
Set to `null` to only one side tooltip parameter, will `null` side tooltip is disabled
```csharp
[SerializeField][BinarySelector("False button text", "True button text", "False button tooltip", null)]
private bool booleanField;
```

### 二択選択GUIコントロールを任意のEditorWindowやInspectorに描画する / Use BinarySelector to EditorWindow or Custom Inspector
![直接描画の説明1](https://github.com/user-attachments/assets/05617b8b-70ec-48cd-a14c-4e4390f2a483)
```csharp
string labelText = "Left label";
string falseText = "False button";
string trueText = "True button";
bool result = BinarySelectorGUILayout.BinarySelectField(input, labelText, falseText, trueText);
```
|           | 説明                | Description                    |
| --------- | ------------------- | ------------------------------ |
| input     | 入力値(変更前の値)  | Input (before changeing) value |
| labelText | (任意)左側の文字列  | (Optional) Left Label Text     |
| falseText | falseボタンの文字列 | False button text              |
| trueText  | trueボタンの文字列  | True button text               |
| result    | 結果の値            | Result value                   |

この方法でも各文字列に`GUIContent`が使えます / 
Can also use `GUIContent` for each string this way


## 導入方法 / English "How to introduction" is below this
1. Gitをインストールする
2. 追加したいプロジェクトを開き、Package Managerを開く
3. 以下の文字列をコピー、またはこのページ上部の「<> Code」からClone URLをコピーする

    https://github.com/HWataame/BinarySelector_Unity.git
4. 「Package Manager」ウィンドウの左上の「＋」ボタンをクリックし、「Install package from git URL...」を選択する

    ![導入方法2](https://github.com/user-attachments/assets/45fa456d-75ca-4189-b993-9819242bf05e)
5. 入力欄に手順2でコピーしたURLを貼り付け、「Install」ボタンを押す

    ![導入方法3](https://github.com/user-attachments/assets/a08ad672-85c7-4f65-ac54-debce69e09d2)
6. (必要に応じて)Assembly Definition Assetの管理下のコードで利用する場合、
- `[BinarySelector]`を使う場合は`HW.BinarySelector`をAssembly Definition Referencesに追加し、

    ![アセンブリ参照1](https://github.com/user-attachments/assets/f2cb6fe2-fd7f-4f3f-a8ad-bee07b989c11)
- GUIパーツを直接使う場合は`HW.BinarySelector.Editor`をAssembly Definition Referencesに追加する

    ![アセンブリ参照2](https://github.com/user-attachments/assets/3b479aea-8007-4a19-9f66-b2bd2d24b242)

## How to introduction / 日本語の「導入方法」は上にあります
1. Install Git to your computer.
2. Open Package Manager in the Unity project to which you want to add this feature.
3. Copy the following string, or copy the Clone URL from "<> Code" at the top of this page

    https://github.com/HWataame/BinarySelector_Unity.git
4. Click the "+" button in the "Package Manager" window and select "Install package from git URL...".

    ![導入方法2](https://github.com/user-attachments/assets/45fa456d-75ca-4189-b993-9819242bf05e)
5. Paste the URL copied in Step 2 into the input field and press the "Install" button.

    ![導入方法3](https://github.com/user-attachments/assets/a08ad672-85c7-4f65-ac54-debce69e09d2)
6. (If necessary) For use in code under the control of Assembly Definition Asset...
- If you wanna use `[BinarySelector]`, add `HW.BinarySelector` to "Assembly Definition References" in your Assembly Definition Asset.

    ![アセンブリ参照1](https://github.com/user-attachments/assets/f2cb6fe2-fd7f-4f3f-a8ad-bee07b989c11)
- If you wanna use BinarySelector GUI directly, add `HW.BinarySelector.Editor` to "Assembly Definition References" in your Assembly Definition Asset.

    ![アセンブリ参照2](https://github.com/user-attachments/assets/3b479aea-8007-4a19-9f66-b2bd2d24b242)

## ライセンス / License
MITライセンスです / Using "MIT license"

[LISENCE](/LICENSE)
