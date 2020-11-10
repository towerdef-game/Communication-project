using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenu : MonoBehaviour
{
    [SerializeField] private networkblah networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingpagepanel = null;

    public void hostlobby()
    {
        networkManager.StartHost();
        landingpagepanel.SetActive(false);
    }
}
