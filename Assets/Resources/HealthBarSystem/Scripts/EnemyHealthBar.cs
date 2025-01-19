using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Entities;
using CoroutineManager;
using MyTimer;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private LivingEntity entity;
        [SerializeField] private CustomImageFiller filler;
        [SerializeField] private CustomImageFiller fillerBack;

        [SerializeField] private float delayTimeToHiding = 2;
        [SerializeField] private float hideTime = 1;
        [SerializeField] private float backFillerCooldownTime = 1;
        [SerializeField] private float backFillerPushTime = 1;
        [SerializeField] private List<Image> hidingElements;

        private Camera mainCamera;
        private EntityHealth health;

        private Timer timerToHide;
        private Timer hidingTimer;
        private Timer timerBackFillerCooldown;
        private Timer timerBackFillerPush;


        public void Start()
        {
            mainCamera = Camera.main;

            timerToHide = new();
            hidingTimer = new();
            timerBackFillerCooldown = new();
            timerBackFillerPush = new();

            timerToHide.OnStoped += () => Coroutines.StartRoutine(Hide());
            hidingTimer.OnStoped += () => SetStateBar(false);
            timerBackFillerCooldown.OnStoped += () => Coroutines.StartRoutine(PushInBackFiller());

            health = entity.health;
            health.OnHealthRestore += UpdateBar;
            health.OnHealthRestore += EqualizeToFiller;
            health.OnHealthDamaged += UpdateBar;
            health.OnHealthDown += ResetAll;
            health.OnHealthRestored += () => timerToHide.Start(delayTimeToHiding);

            SetCurrentFillAmount();
            EqualizeToFiller();
            SetStateBar(false);
        }

        private void LateUpdate()
        {
            if (mainCamera != null)
            {
                transform.LookAt(transform.position + mainCamera.transform.forward);
            }
        }


        private void EqualizeToFiller() => fillerBack.FillAmount = filler.FillAmount;

        private void UpdateBar()
        {
            SetStateBar(true);

            timerToHide.Reset();
            timerBackFillerPush.Reset();
            hidingTimer.Reset();
            RestoreTranparency();

            SetCurrentFillAmount();

            timerBackFillerCooldown.Start(backFillerCooldownTime);
        }

        private IEnumerator Hide()
        {
            hidingTimer.Start(hideTime);

            while (hidingTimer.IsStarted)
            {
                foreach (var element in hidingElements)
                {
                    element.color = new Color(element.color.r, element.color.g, element.color.b, hidingTimer.GetValue() / hideTime);
                }

                yield return null;
            }

            RestoreTranparency();
        }

        private void SetStateBar(bool isOpen) => gameObject.SetActive(isOpen);

        private void RestoreTranparency()
        {
            foreach (var element in hidingElements)
            {
                element.color = new Color(element.color.r, element.color.g, element.color.b, 1);
            }
        }

        private void SetCurrentFillAmount() => filler.FillAmount = health.Health / health.MaxHealth;

        private IEnumerator PushInBackFiller()
        {
            float amountFiller = filler.FillAmount;
            float amountBackFiller = fillerBack.FillAmount;
            timerBackFillerPush.Start(backFillerPushTime);

            while (timerBackFillerPush.IsStarted)
            {
                fillerBack.FillAmount = Mathf.Lerp(amountFiller, amountBackFiller, timerBackFillerPush.GetValue() / backFillerPushTime);

                yield return null;
            }
        }

        private void ResetAll()
        {
            timerBackFillerCooldown.Reset();
            timerBackFillerPush.Reset();
            hidingTimer.Reset();
            timerToHide.Reset();

            timerToHide.OnStoped -= () => Coroutines.StartRoutine(Hide());
            hidingTimer.OnStoped -= () => SetStateBar(false);
            timerBackFillerCooldown.OnStoped -= () => Coroutines.StartRoutine(PushInBackFiller());

            health.OnHealthRestore -= UpdateBar;
            health.OnHealthRestore -= EqualizeToFiller;
            health.OnHealthDamaged -= UpdateBar;
            health.OnHealthDown -= ResetAll;
            health.OnHealthRestored -= () => timerToHide.Start(delayTimeToHiding);
        }
    }
}
