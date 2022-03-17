using ControlFreak2;
using EVP;
using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.FusionNetwork.Shared
{
    public struct VInput : INetworkInput
    {
        public float steer;
        public float throttle;
        public float brake;
    }

    public class FusionVehicle : NetworkBehaviour, INetworkRunnerCallbacks
    {
        private VehicleController vController;

        void Awake()
        {
            vController = GetComponent<VehicleController>();
        }
        public override void Spawned()
        {
            Runner.AddCallbacks(this);
            DontDestroyOnLoad(gameObject);            
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            var vInput = new VInput();

            float v = CF2Input.GetAxis("Vertical");

            vInput.steer = CF2Input.GetAxis("Horizontal");
            vInput.throttle = v > 0 ? v : 0;
            vInput.brake = v < 0 ? -v : 0;

            input.Set(vInput);
        }

        public override void FixedUpdateNetwork()
        {
            if(GetInput(out VInput input))
            {
                vController.steerInput = input.steer;
                vController.throttleInput = input.throttle;
                vController.brakeInput = input.brake;

                vController.ManualFixedUpdate(Runner.DeltaTime);
            }
        }

        public override void Render()
        {
            vController.ManualVisualUpdate();
        }

        #region INetworkRunnerCallbacks
        public void OnConnectedToServer(NetworkRunner runner)
        {
           
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
           
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
           
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
           
        }

        public void OnDisconnectedFromServer(NetworkRunner runner)
        {
           
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
           
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
           
        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
           
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
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

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
           
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
           
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
           
        }
        #endregion
    }
}

