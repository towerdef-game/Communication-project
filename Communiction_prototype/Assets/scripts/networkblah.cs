
using System;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections.Generic;

public class networkblah : NetworkManager
{
    [SerializeField] private int minplayers = 2;
    [Scene] [SerializeField] private string menuScene = string.Empty;

    [Header("room")]
    [SerializeField] private tombdiverlobby roomPlayer = null;

    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;

    public List <tombdiverlobby> RoomPlayers { get; } = new List<tombdiverlobby>();
    public override void OnStartServer() => spawnPrefabs = Resources.LoadAll<GameObject>("spawnablePrefabs").ToList();
     

    public override void OnStartClient()
    {
        var spawnablePrefabs = Resources.LoadAll<GameObject>("spawnablePrefabs");
        foreach(var prefab in spawnPrefabs)
        {
            ClientScene.RegisterPrefab(prefab);
        }
    }
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        OnClientConnected?.Invoke();
    }
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
        OnClientDisconnected?.Invoke();
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        if(conn.identity != null)
        {
            var player = conn.identity.GetComponent<tombdiverlobby>();
            RoomPlayers.Remove(player);

            Notifyplayersofreadystate();
        }
        base.OnServerDisconnect(conn);
    }
    public override void OnServerConnect(NetworkConnection conn)
    {
        if(numPlayers >= maxConnections)
        {
            conn.Disconnect();
        }
        if (SceneManager.GetActiveScene().path != menuScene){
            conn.Disconnect();
            return;
        }
       
    }
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        if(SceneManager.GetActiveScene().path == menuScene)
        {
            bool isleader = RoomPlayers.Count == 0;

            tombdiverlobby roomPlayerIntance = Instantiate(roomPlayer);

            roomPlayerIntance.IsLeader = isleader;
            NetworkServer.AddPlayerForConnection(conn, roomPlayerIntance.gameObject);
        }
        
    }
    public override void OnStopServer()
    {
        RoomPlayers.Clear();
    }

    public void Notifyplayersofreadystate()
    {
        foreach (var player in RoomPlayers)
        {
            player.HandleReadyToStart(IsReadyToStart());
        }
    }

    private bool IsReadyToStart()
    {
        if(numPlayers < minplayers) { return false; }

        foreach(var player in RoomPlayers)
        {
            if (!player.IsReady) { return false; }
        }
        return true;
    }
  
}