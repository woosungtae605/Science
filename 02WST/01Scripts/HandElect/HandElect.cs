using UnityEngine;

public class HandElect : MonoBehaviour
{
    public InputReaderSO readerSO;
    public GoldSystemSO goldSystemSO;

    private float _desireAngle;
    private float lastRotate;

    [Header("Reward")]
    [SerializeField] private float coinsPerDegree = 0f;
    [SerializeField] private float minDeltaDeg = 0.2f;

    public void AnimWeapon(Vector2 pointerPos)
    {
        Vector2 dir = pointerPos - (Vector2)transform.position;
        _desireAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, _desireAngle+80);

        float delta = Mathf.DeltaAngle(lastRotate, _desireAngle);
        if (Mathf.Abs(delta) >= minDeltaDeg)
        {
            goldSystemSO.ChangeGold((decimal)coinsPerDegree, GoldChangeType.Increase);
        }

        lastRotate = _desireAngle;
    }

    private void Update()
    {
        AnimWeapon(readerSO.mousePos);
    }

    public void UpgradeHandleElect(float value)
    {
        coinsPerDegree += value;
    }

}
