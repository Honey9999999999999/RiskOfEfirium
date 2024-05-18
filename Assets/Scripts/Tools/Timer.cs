using CoroutineManager;
using System;
using System.Collections;
using UnityEngine;

namespace MyTimer
{
    public class Timer
    {
        public event Action OnStarted;
        public event Action OnStoped;

        private float counter;
        private Coroutine routine;

        public bool isStarted => counter > 0;

        public void Start(float sec) 
        {
            routine = Coroutines.StartRoutine(StartTimerRoutine(sec));

            OnStarted?.Invoke();
        }        
        public void Reset() 
        {
            if(routine != null)
            {
                Coroutines.StopRoutine(routine);
                counter = 0;
            }
        }
        private void Stop() 
        {
            counter = 0;
            OnStoped?.Invoke();
        }

        private IEnumerator StartTimerRoutine(float sec)
        {
            counter = sec;

            while (isStarted)
            {
                yield return null;
                counter -= Time.deltaTime;
            }

            Stop();
        }
    }
}
