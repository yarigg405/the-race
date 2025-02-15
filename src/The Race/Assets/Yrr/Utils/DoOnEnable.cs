using UnityEngine;
using UnityEngine.Events;


namespace Yrr.Utils
{
    internal sealed class DoOnEnable : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnable;

        private void OnEnable()
        {
            onEnable?.Invoke();
        }
    }
}
