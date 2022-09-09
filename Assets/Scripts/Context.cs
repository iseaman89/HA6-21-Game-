using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Context : MonoInstaller
{
    [SerializeField] private Deck deck;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    public override void InstallBindings()
    {
        Container.Bind<Deck>().FromInstance(deck).AsSingle();
        Container.Bind<Player>().FromInstance(player).AsSingle();
        Container.Bind<Enemy>().FromInstance(enemy).AsSingle();
    }
}
