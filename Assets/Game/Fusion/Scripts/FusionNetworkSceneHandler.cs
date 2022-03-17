using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.FusionNetwork.Shared
{
    using Fusion;
    using UnityEngine.SceneManagement;

    public class FusionNetworkSceneHandler : NetworkSceneManagerBase
    {
        [ScenePath]
        public string mainScene;
        

        protected override IEnumerator SwitchScene(SceneRef prevScene, SceneRef newScene, FinishedLoadingDelegate finished)
        {
            var opt = SceneManager.LoadSceneAsync(mainScene, LoadSceneMode.Single);
            Debug.Log("Load main scene!");
            yield return opt;

            //
            var rootObjs = SceneManager.GetActiveScene().GetRootGameObjects();

            List<NetworkObject> networkObjects = new List<NetworkObject>();

            foreach(var o in rootObjs)
            {
                var nos = o.GetComponentsInChildren<NetworkObject>(true);
                if(nos.Length > 0)
                {
                    networkObjects.AddRange(nos);
                }
            }

            //Runner.RegisterUniqueObjects(networkObjects);

            finished?.Invoke(networkObjects);
        }
    }
}
