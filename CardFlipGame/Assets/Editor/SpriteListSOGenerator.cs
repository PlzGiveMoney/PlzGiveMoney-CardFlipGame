using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic; // List�� ����Ϸ���

public class SpriteListSOGenerator
{
    [MenuItem("CardFlipGame/Generate SpriteListSO from Images_1")] //��� �޴��� �߰�
    public static void GenerateSO()
    {
        string assetPath = "Assets/Scripts/1.Main/SpriteListSO.asset";
        SpriteListSO so = AssetDatabase.LoadAssetAtPath<SpriteListSO>(assetPath);

        // Resources ��� ����
        string resourcePath = "package/Images_1";
        Sprite[] sprites = Resources.LoadAll<Sprite>(resourcePath);

        if (so == null) //SO������ ���ٸ� ����
        {
            so = ScriptableObject.CreateInstance<SpriteListSO>();
            AssetDatabase.CreateAsset(so, assetPath);//��ȣ�ȿ��� ������ ������Ʈ�� ��� + ���ϸ��� ���� ex) "Assets/Resources/SpriteListSO.asset"
        }

        so.sprites = new List<Sprite>(sprites);

        EditorUtility.SetDirty(so); //����Ƽ���� �� ������Ʈ�� ����Ǿ��ٴ� ���� �˷���
        AssetDatabase.SaveAssets(); //������ ������

        Debug.Log("��������Ʈ " + sprites.Length + " �� ��ϿϷ�");
        Selection.activeObject = so; //Project â���� ������ SO�� ����
    }
}