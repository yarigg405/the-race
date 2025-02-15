using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace Yrr.Utils
{
    internal sealed class DoWithDelay : MonoBehaviour
    {
        [SerializeField] private float delay;
        [SerializeField] private bool startOnEnabled;
        [SerializeField] private UnityEvent onTimerEnd;

        private void OnEnable()
        {
            if (startOnEnabled)
            {
                StartTimer();
            }
        }

        public void StartTimer()
        {
            StopAllCoroutines();
            StartCoroutine(LogicCoroutine());
        }

        private IEnumerator LogicCoroutine()
        {
            yield return new WaitForSeconds(delay);
            onTimerEnd?.Invoke();
        }
    }
}
