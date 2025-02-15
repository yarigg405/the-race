using UnityEngine;
using VContainer;


namespace TheRaceGame.Infrastructure
{
    internal abstract class ScriptableObjectInstaller : ScriptableObject
    {
        public abstract void Install(IContainerBuilder builder);
    }
}
