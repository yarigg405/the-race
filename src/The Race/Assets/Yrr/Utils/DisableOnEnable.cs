using UnityEngine;


namespace Yrr.Utils
{
    internal sealed class DisableOnEnable : MonoBehaviour
    {
        [SerializeField] private GameObject[] disableOnEnable;


        private void OnEnable()
        {
            for (int i = 0; i < disableOnEnable.Length; i++)
            {
                var go = disableOnEnable[i];
                if (go)
                    go.SetActive(false);
            }
        }
    }
}