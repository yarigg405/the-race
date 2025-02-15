using UnityEngine;


namespace Yrr.Utils
{
    internal sealed class DisableOnDisable : MonoBehaviour
    {
        [SerializeField] private GameObject[] disableOnDisable;


        private void OnDisable()
        {
            for (int i = 0; i < disableOnDisable.Length; i++)
            {
                var go = disableOnDisable[i];
                if (go)
                    go.SetActive(false);
            }
        }
    }
}