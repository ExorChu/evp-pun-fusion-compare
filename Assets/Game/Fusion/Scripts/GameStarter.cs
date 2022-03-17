using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.FusionNetwork.Shared
{
    using TMPro;

    public class GameStarter : MonoBehaviour, INetworkRunnerCallbacks
    {
        [SerializeField] private NetworkRunner runner;
        [SerializeField] private GameObject uiObject;

        public TextMeshProUGUI text;
        public TMP_InputField roomNameField;
        public Button buttonEnter;

        void Awake()
        {
            buttonEnter.onClick.AddListener(JoinGame);
        }

        public void JoinGame()
        {
            runner.AddCallbacks(this);
            string roomName = roomNameField.text;

            Debug.LogError("Join game!!!");

            runner.StartGame(new StartGameArgs
            {
                GameMode = GameMode.Shared,
                SessionName = String.IsNullOrEmpty(roomName) ? null : roomName,
                SceneObjectProvider = runner.GetComponent<INetworkSceneObjectProvider>(),
                Scene = 1
            }).ContinueWith(t =>
            {
                Debug.Log("Start game!? " + t.Result.Ok + " " + t.Result.ShutdownReason);
                if(t.Result.Ok)
                {
                    text.text = "Connected";
                }
                else
                {
                    text.text = t.Result.ShutdownReason.ToString();
                }                
            });
        }

        void OnEnable()
        {
            runner.AddCallbacks(this);
        }

        void OnDisable()
        {
            runner.RemoveCallbacks(this);
        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
            
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
            
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
            
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
            Destroy(gameObject);
        }

        public void OnDisconnectedFromServer(NetworkRunner runner)
        {
            
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
            
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
            
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
            
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
            
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
            
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
            
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
        {
            
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
            
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
            
        }
    }
}
