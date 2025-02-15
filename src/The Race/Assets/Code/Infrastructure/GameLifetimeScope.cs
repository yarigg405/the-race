using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace TheRaceGame.Infrastructure
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private List<ScriptableObjectInstaller> _scriptableObjectInstallers = new();
        [SerializeField] private List<MonoInstaller> _monoInstallers = new();

        protected override void Configure(IContainerBuilder builder)
        {
            for (int i = 0; i < _scriptableObjectInstallers.Count; i++)
            {
                var installer = _scriptableObjectInstallers[i];
                installer.Install(builder);
            }

            for (int i = 0; i < _monoInstallers.Count; i++)
            {
                var installer = _monoInstallers[i];
                installer.Install(builder);
            }
        }
    }
}
