using UnityEngine;


namespace ToolBox
{
    internal sealed class EnableOnDisable : MonoBehaviour
    {
        [SerializeField] private GameObject[] enableOnDisable;


        private void OnDisable()
        {
            for (int i = 0; i < enableOnDisable.Length; i++)
            {
                var go = enableOnDisable[i];
                if (go)
                    go.SetActive(true);
            }
        }
    }
}