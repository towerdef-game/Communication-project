using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class join : MonoBehaviour
{
    [SerializeField] private networkblah networkmanager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingpagepannel = null;
    [SerializeField] private InputField ipaddressInputField = null;
    [SerializeField] private Button joinbutton = null;

    private void OnEnable()
    {
        networkblah.OnClientConnected += HandleClientConnected;
        networkblah.OnClientDisconnected += HandleClientDisconnected;

    }
    private void OnDisable()
    {
        networkblah.OnClientConnected -= HandleClientConnected;
        networkblah.OnClientDisconnected += HandleClientDisconnected;
    }

    public void JoinLobby()
    {
        string ipaddress = ipaddressInputField.text;
        networkmanager.networkAddress = ipaddress;
        networkmanager.StartClient();
        joinbutton.interactable = false;
    }

    private void HandleClientConnected()
    {
        joinbutton.interactable = true;

        gameObject.SetActive(false);
        landingpagepannel.SetActive(false);
    }
    private void HandleClientDisconnected()
    {
       joinbutton.interactable = true;
    }
}
