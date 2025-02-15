using UnityEngine;


namespace Yrr.Utils
{
    internal sealed class EnableOnEnable : MonoBehaviour
    {
        [SerializeField] private GameObject[] enableOnEnable;


        private void OnEnable()
        {
            for (int i = 0; i < enableOnEnable.Length; i++)
            {
                var go = enableOnEnable[i];
                if (go)
                    go.SetActive(true);
            }
        }
    }
}
