using UnityEngine;

[CreateAssetMenu(fileName = "Goods", menuName = "WSTSO/GoodsSO")]
public class GoodsSO : ScriptableObject
{
    public Sprite goodsSprite;
    public string description;
    public int[] upgradePrice;
    public int upgradeCount;
}
