using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using Mirror;

public class steamlobby : MonoBehaviour
{
    [SerializeField] private GameObject buttons = null;
    protected Callback<LobbyCreated_t> lobbycreated;
    protected Callback<GameLobbyJoinRequested_t> gamelobbyjoinrequested;
    protected Callback<LobbyEnter_t> lobbyentered;
    private network networkmanager;
   // private playerspawnsystem spawn;
    private const string Hostaddresskey = "HostAddress";
    public void Start()
    {
     //   spawn = GetComponent<playerspawnsystem>();
        networkmanager = GetComponent<network>();
        if(!SteamManager.Initialized) { return; }
        lobbycreated = Callback<LobbyCreated_t>.Create(OnlobbyCreated);
        gamelobbyjoinrequested = Callback<GameLobbyJoinRequested_t>.Create(OnGameLobbyJoinRequested);
        lobbyentered = Callback<LobbyEnter_t>.Create(OnLobbyEntered);
    }
    public void HostLobby()
    {
        buttons.SetActive(false);

        SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypeFriendsOnly,networkmanager.maxConnections);
    }
    private void OnlobbyCreated(LobbyCreated_t callback)
    {
         if(callback.m_eResult != EResult.k_EResultOK)
        {
            buttons.SetActive(true);
            return;
        }
        networkmanager.StartHost();
       // spawn.spawnplayerone();
        SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), Hostaddresskey, SteamUser.GetSteamID().ToString());
    }
    private void OnGameLobbyJoinRequested(GameLobbyJoinRequested_t callback)
    {
        SteamMatchmaking.JoinLobby(callback.m_steamIDLobby);
    }
    private void OnLobbyEntered( LobbyEnter_t callback)
    {
      if (NetworkServer.active) { return; }

      string hostaddress = SteamMatchmaking.GetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), Hostaddresskey);

        networkmanager.networkAddress = hostaddress;
        networkmanager.StartClient();
       // spawn.spawnplayertwo();
        buttons.SetActive(false);
    }
}
