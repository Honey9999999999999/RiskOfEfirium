using Assets.Scripts.Entities;
using CoroutineManager;
using MyTimer;
using System.Collections;
using System.Collections.Generic;
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

        private Timer timerToHiding;
        private Timer timerToHide;
        private Timer timerBackFillerCooldown;
        private Timer timerBackFillerPush;


        public void Start()
        {
            health = entity.health;
            health.OnHealthRestored += UpdateBar;
            health.OnHealthRestored += EqualizeToFiller;
            health.OnHealthDamaged += UpdateBar;
            health.OnHealthDown += ResetAll;

            mainCamera = Camera.main;

            timerToHiding = new();
            timerToHide = new();
            timerBackFillerCooldown = new();
            timerBackFillerPush = new();

            timerToHiding.OnStoped += () => Coroutines.StartRoutine(Hide());
            timerToHide.OnStoped += ()=> SetStateBar(false);
            timerBackFillerCooldown.OnStoped += ()=> Coroutines.StartRoutine(PushInBackFiller());

            SetCurrentFillAmount();
            EqualizeToFiller();
            SetStateBar(false);
        }

        private void EqualizeToFiller() => fillerBack.FillAmount = filler.FillAmount;

        private void UpdateBar()
        {
            SetStateBar(true);

            if (timerToHiding.isStarted)
            {
                timerToHiding.Reset();
            }

            if (timerToHide.isStarted)
            {
                timerToHide.Reset();
                RestoreTranparency();
            }

            if (timerBackFillerPush.isStarted)
            {
                timerBackFillerPush.Reset();
            }

            SetCurrentFillAmount();

            timerBackFillerCooldown.Start(backFillerCooldownTime);
            timerToHiding.Start(delayTimeToHiding);
        }

        private IEnumerator Hide()
        {
            if (health.IsMaxHealth)
            {
                timerToHide.Start(hideTime);

                while (timerToHide.isStarted)
                {
                    foreach (var element in hidingElements)
                    {
                        element.color = new Color(element.color.r, element.color.g, element.color.b, timerToHide.GetValue() / hideTime);
                    }

                    yield return null;
                }

                RestoreTranparency();
            }
        }

        private void SetStateBar(bool isOpen)
        {
            gameObject.SetActive(isOpen || !health.IsMaxHealth);
        }        

        private void RestoreTranparency()
        {
            foreach (var element in hidingElements)
            {
                element.color = new Color(element.color.r, element.color.g, element.color.b, 1);
            }
        }

        private void SetCurrentFillAmount()
        {
            filler.FillAmount = health.Health / health.MaxHealth;
        }

        private IEnumerator PushInBackFiller()
        {
            float amountFiller = filler.FillAmount;
            float amountBackFiller = fillerBack.FillAmount;
            timerBackFillerPush.Start(backFillerPushTime);

            while (timerBackFillerPush.isStarted)
            {
                fillerBack.FillAmount = Mathf.Lerp(amountFiller, amountBackFiller, timerBackFillerPush.GetValue() / backFillerPushTime);

                yield return null;
            }
        }

        private void ResetAll()
        {
            timerBackFillerCooldown.Reset();
            timerBackFillerPush.Reset();
            timerToHide.Reset();
            timerToHiding.Reset();

            health.OnHealthRestored -= UpdateBar;
            health.OnHealthRestored -= EqualizeToFiller;
            health.OnHealthDamaged  -= UpdateBar;
            health.OnHealthDown     -= ResetAll;
        }

        private void LateUpdate()
        {
            if (mainCamera != null)
            {
                transform.LookAt(transform.position + mainCamera.transform.forward);
            }
        }
    }
}
