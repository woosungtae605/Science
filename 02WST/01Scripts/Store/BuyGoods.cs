using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;


public class BuyGoods : MonoBehaviour
{
    [Header("SO")]
    [SerializeField] GoodsSO goodsSO;
    [SerializeField] GoldSystemSO goldSystemSO;

    [Header("PutObject")]
    [SerializeField] Image goods_icon;
    [SerializeField] TextMeshProUGUI goods_price;
    [SerializeField] TextMeshProUGUI goods_description;

    [Header("Buy Exception bool")]
    private bool canBuy = false;
    private bool canUpgrade = false;

    [Header("UpgradeType")]
    [SerializeField] private float amount;
    [SerializeField] private UpgradeType type;

    public UnityEvent<float, UpgradeType> unityEvent;


    private void Awake()
    {
        ResetUpgrade();
        Initialized();
    }
    private void Initialized()
    {
        goods_icon.sprite = goodsSO.goodsSprite;
        goods_description.text = goodsSO.description;
        goods_price.text = $"{goodsSO.upgradePrice[goodsSO.upgradeCount]}";
    }

    private void ResetUpgrade() => goodsSO.upgradeCount = 0;

    IEnumerator MoneyLack()
    {
        if (!canBuy)
        {
            canBuy = true;
            goods_price.text = $"money is not enough";
            yield return new WaitForSeconds(0.7f);
            goods_price.text = $"{goodsSO.upgradePrice[goodsSO.upgradeCount]}";
            canBuy = false;
        }
    }
    public void ClickBuy()
    {
        if (goodsSO.upgradePrice.Length - 1 <= goodsSO.upgradeCount)
        {
            goods_price.text = "already have it";
        }
        else if (goldSystemSO.Gold >= goodsSO.upgradePrice[goodsSO.upgradeCount])
        {
            goldSystemSO.ChangeGold(goodsSO.upgradePrice[goodsSO.upgradeCount], GoldChangeType.Decrease);
            unityEvent?.Invoke(amount, type);
            goodsSO.upgradeCount++;
            Initialized();
        }
        else
        {
            StartCoroutine(MoneyLack());
        }
    }

}
