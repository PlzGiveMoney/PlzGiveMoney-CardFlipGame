using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteListSO", menuName = "CardFlipGame/SpriteListSO")]
public class SpriteListSO : ScriptableObject
{
    public List<Sprite> sprites;
}