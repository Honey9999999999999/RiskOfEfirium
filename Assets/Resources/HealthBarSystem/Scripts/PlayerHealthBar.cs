using Architecture;
using Assets.Scripts.Entities;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform mask;
    [SerializeField] private RectTransform filler;

    [SerializeField] private float offset;

    private EntityHealth _health;

    private float _startRect;
    private float _endRect;

    void Start()
    {
        Game.OnGameInitialized += Initialize;
    }

    private void Initialize()
    {
        _health = Game.GetInteractor<PlayerInteractor>().Player.health;

        _startRect = filler.rect.width;
        _endRect = filler.rect.width + mask.rect.width - offset;

        _health.OnHealthDamaged += UpdateBar;
        _health.OnHealthRestore += UpdateBar;

        _health.OnHealthDown += Death;

        UpdateBar();
    }

    private void UpdateBar()
    {
        Vector2 fillerRect = new(
            Mathf.Lerp(_startRect, _endRect, _health.Health / _health.MaxHealth),
            filler.rect.height
            );
        filler.sizeDelta = fillerRect;
    }

    private void Death()
    {
        _health.OnHealthDamaged -= UpdateBar;
        _health.OnHealthRestore -= UpdateBar;
    }
}
