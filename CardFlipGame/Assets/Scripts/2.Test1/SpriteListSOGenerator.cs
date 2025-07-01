using UnityEngine;
using UnityEditor;
using System.IO;

public class SpriteListSOGenerator
{
    [MenuItem("CardFlipGame/Generate SpriteListSO from Images_1")]
    public static void GenerateSO()
    {
        // Resources ��� ����
        string resourcePath = "package/Images_1";
        Sprite[] sprites = Resources.LoadAll<Sprite>(resourcePath);

        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogWarning("Sprites not found in Resources/package/Images_1");
            return;
        }

        SpriteListSO so = ScriptableObject.CreateInstance<SpriteListSO>();
        so.sprites = new System.Collections.Generic.List<Sprite>(sprites);

        // SO ���� ���
        string assetPath = "Assets/Scripts/2.Test1/SpriteListSO.asset";
        AssetDatabase.CreateAsset(so, assetPath);
        AssetDatabase.SaveAssets();

        Debug.Log($"SpriteListSO ���� �Ϸ�! ({sprites.Length}�� Sprite ����)");
        Selection.activeObject = so;
    }
}