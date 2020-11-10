using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class network : NetworkManager
{
    [SerializeField]
      private playerspawnsystem spawn;
   // [SerializeField] private GameObject playerspawnsystem = null;
    // public static event Action<NetworkConnection> OnServerReadied;
    public static event Action<NetworkConnection> OnServerReadied;
 
    public override void OnStartClient()
    {
       
    }
    public override void OnStartHost()
    {
      
    }
    public override void OnServerSceneChanged(string sceneName)
    {
        Debug.Log("switched");
        if (sceneName.StartsWith("Scene_Map"))
        {
         //   GameObject playerspawnsysteminstance = Instantiate(playerspawnsystem);
          //  NetworkServer.Spawn(playerspawnsysteminstance);
        }
        base.OnServerSceneChanged(sceneName);
    }
    public override void OnServerReady(NetworkConnection conn)
    {
        base.OnServerReady(conn);

        OnServerReadied?.Invoke(conn);
    }

}