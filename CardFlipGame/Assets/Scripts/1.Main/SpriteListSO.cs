using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteListSO", menuName = "CardFlipGame/SpriteListSO")]
public class SpriteListSO : ScriptableObject
{
    //���� : ScriptableObject���� Static ������ �ᵵ �ǳ�?

    //1����
    //public List<Sprite> sprites;

    //2����
    public static List<Sprite> sprites;
}