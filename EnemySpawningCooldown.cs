using UnityEngine;

[System.Serializable]
public class EnemySpawingCooldown {
    #region Variables

    [SerializeField] private float cooldownTime;
    private float _nextSpawningTime;

    #endregion

    public bool IsCoolingDown => Time.time < _nextSpawningTime;
    public void StartCooldown() => _nextSpawningTime = Time.time + cooldownTime;
}