using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteListSO", menuName = "CardFlipGame/SpriteListSO")]
public class SpriteListSO : ScriptableObject
{
    public List<Sprite> sprites;
}