using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteListSO", menuName = "CardFlipGame/SpriteListSO")]
public class SpriteListSO : ScriptableObject
{
    //주제 : ScriptableObject에서 Static 변수를 써도 되나?

    //1번안
    //public List<Sprite> sprites;

    //2번안
    public static List<Sprite> sprites;
}