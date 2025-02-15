using UnityEngine;
using VContainer;


namespace TheRaceGame.Infrastructure
{
    internal abstract class MonoInstaller : MonoBehaviour
    {
        public abstract void Install(IContainerBuilder builder);
    }
}
