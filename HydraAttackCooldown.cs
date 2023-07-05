using UnityEngine;

[System.Serializable]
public class HydraAttackCooldown {
    #region Variables
    [SerializeField] private float cooldownTime;
    private float _nextAttackTime;

    #endregion

    public bool IsCoolingDown => Time.time < _nextAttackTime;
    public void StartCooldown() => _nextAttackTime = Time.time + cooldownTime;
}