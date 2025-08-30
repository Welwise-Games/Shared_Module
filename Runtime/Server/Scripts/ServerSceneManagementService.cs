using System;
using FishNet.Connection;
using FishNet.Managing.Scened;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using WelwiseHubExampleModule.Runtime.Shared.Scripts.Holders;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

namespace WelwiseSharedModule.Runtime.Server.Scripts
{
    public class ServerSceneManagementService
    {
        public event Action<NetworkConnection, Scene> LoadedSceneClient;

        public void TryInvokingClientLoadedScene(ClientPresenceChangeEventArgs args)
        {
            if (args.Added)
                LoadedSceneClient?.Invoke(args.Connection, args.Scene);
        }

        public SceneLoadData GetNewLoadedStackingScene()
        {
            var scene = SceneManager.LoadScene(ScenesNames.Game,
                new LoadSceneParameters(LoadSceneMode.Additive, LocalPhysicsMode.Physics3D));

            return new SceneLoadData(scene)
                { Options = new LoadOptions { LocalPhysics = LocalPhysicsMode.Physics3D, AllowStacking = true} };
        }
    }
}