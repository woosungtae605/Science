using Unity.VisualScripting;
using UnityEngine;

public class StoreExit_Enter : MonoBehaviour
{
    [SerializeField] private GameObject storePanel;
    [SerializeField] private GameObject storeEnterBTN;
    [SerializeField] private GameObject storeEnter2BTN;

    private void Awake()
    {
        SetStoreExitEnter(false);
    }

    public void SetStoreExitEnter(bool value)
    {
        storeEnterBTN.SetActive(!value);
        storeEnter2BTN.SetActive(!value);
        storePanel.SetActive(value);
    }
}
