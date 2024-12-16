using Project.Configs.Game;
using Project.Spawner;
using Project.Systems.Data;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Infrastructure
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<CardSpawner>(Lifetime.Singleton);
            builder.Register<GameStateHandler>(Lifetime.Singleton);
            builder.Register<StartScreenHandler>(Lifetime.Singleton);
            builder.Register<GameplayUIHandler>(Lifetime.Singleton);
            builder.Register<LevelDataProvider>(Lifetime.Singleton);
            builder.RegisterInstance(ScriptableObject.CreateInstance<GameConfig>());
        }
    }
}