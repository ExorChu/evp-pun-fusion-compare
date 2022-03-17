using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionSceneStartPosition : NetworkBehaviour
{

    [SerializeField] private Transform[] points;

    public void GetMySpawnPoint(out Vector3 pos, out Quaternion rot)
    {
        int p = Runner.LocalPlayer % points.Length;

        var point = points[p];

        pos = point.position;
        rot = point.rotation;
    }
}
