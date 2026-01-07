using UnityEngine;

public class HandElectSetActive : MonoBehaviour
{
    [SerializeField] private GameObject handElect;

    private void Awake()
    {
        handElect.SetActive(false);
    }
    public void SlectSetActive(bool value)
    {
        handElect.SetActive(value);
    }
}
