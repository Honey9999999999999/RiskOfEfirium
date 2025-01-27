using Architecture;
using Assets.Resources.Entities.Scripts;
using UnityEngine;

namespace Assets.Resources.PlayerUI.Scripts
{
    public class OxygenBar : MonoBehaviour
    {
        [SerializeField] private RectTransform mask;
        [SerializeField] private RectTransform filler;

        [SerializeField] private float offset;

        private EntityOxygen entityOxygen;

        private float _startRect;
        private float _endRect;

        void Start()
        {
            Game.AddTask(Initialize);
        }

        private void Initialize()
        {
            Player player = Game.GetInteractor<PlayerInteractor>().Player;
            entityOxygen = player.EntityOxygen;

            _startRect = filler.rect.width;
            _endRect = filler.rect.width + mask.rect.width - offset;

            entityOxygen.OnOxygenRestore += UpdateBar;
            entityOxygen.OnOxygenDamaged += UpdateBar;

            player.OnEntityDeath += Death;

            UpdateBar();            
        }

        private void UpdateBar()
        {
            Vector2 fillerRect = new(
                Mathf.Lerp(_startRect, _endRect, entityOxygen.CurrentOxygen / entityOxygen.MaxOxygen),
                filler.rect.height
                );
            filler.sizeDelta = fillerRect;
        }

        private void Death()
        {
            entityOxygen.OnOxygenRestore -= UpdateBar;
            entityOxygen.OnOxygenDamaged -= UpdateBar;
        }
    }
}