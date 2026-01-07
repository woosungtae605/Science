using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Goods : MonoBehaviour
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
    public UnityEvent unityEvent2; // jihoo use this


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

    IEnumerator UpgradeFullCoroutine()
    {
        if(!canUpgrade)
        {
            canUpgrade = true;
            goods_price.text = $"최대 레벨입니다.";
            yield return new WaitForSeconds(0.7f);
            goods_price.text = $"{goodsSO.upgradePrice[goodsSO.upgradeCount]}";
            canUpgrade = false;
        }
    }

    IEnumerator MoneyLack()
    {
        if(!canBuy)
        {
            canBuy = true;
            goods_price.text = $"돈이 부족합니다";
            yield return new WaitForSeconds(0.7f);
            goods_price.text = $"{goodsSO.upgradePrice[goodsSO.upgradeCount]}";
            canBuy = false;
        }
    }
    public void ClickBuy()
    {
        if(goodsSO.upgradePrice.Length-1 < goodsSO.upgradeCount)
        {
            StartCoroutine(UpgradeFullCoroutine());
        }
        else if(goldSystemSO.Gold >= goodsSO.upgradePrice[goodsSO.upgradeCount])
        {
            goldSystemSO.ChangeGold(goodsSO.upgradePrice[goodsSO.upgradeCount], GoldChangeType.Decrease);
            unityEvent?.Invoke(amount, type);
            unityEvent2?.Invoke(); // jihoo use this;
            goodsSO.upgradeCount++;
            Initialized();
        }
        else
        {
            StartCoroutine(MoneyLack());
        }
    }

    // 머신 쪽 스크립트
    
}
