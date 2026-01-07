using TMPro;
using UnityEngine;

public class GoldCount : MonoBehaviour
{
    [SerializeField] private GoldSystemSO goldSystemSO;
    [SerializeField] private TextMeshProUGUI remainingGoldtext;

    private void Update()
    {
        RemainGold();
    }

    public void RemainGold()
    {
        remainingGoldtext.text = $"{goldSystemSO.Gold}";
    }
}
