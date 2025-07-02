using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic; // List를 사용하려고

public class SpriteListSOGenerator
{
    [MenuItem("CardFlipGame/Generate SpriteListSO from Images_1")] //상단 메뉴에 추가
    public static void GenerateSO()
    {
        string assetPath = "Assets/Scripts/2.Test1/SpriteListSO.asset";
        SpriteListSO so = AssetDatabase.LoadAssetAtPath<SpriteListSO>(assetPath);

        // Resources 경로 기준
        string resourcePath = "package/Images_1";
        Sprite[] sprites = Resources.LoadAll<Sprite>(resourcePath);

        if (so == null) //SO파일이 없다면 생성
        {
            so = ScriptableObject.CreateInstance<SpriteListSO>();
            AssetDatabase.CreateAsset(so, assetPath);//괄호안에는 생성될 오브젝트와 경로 + 파일명을 넣음 ex) "Assets/Resources/SpriteListSO.asset"
        }

        so.sprites = new List<Sprite>(sprites);

        EditorUtility.SetDirty(so); //유니티에게 이 오브젝트가 변경되었다는 것을 알려줌
        AssetDatabase.SaveAssets(); //에셋을 저장함

        Debug.Log("스프라이트 " + sprites.Length + " 개 등록완료");
        Selection.activeObject = so; //Project 창에서 생성된 SO를 선택
    }
}