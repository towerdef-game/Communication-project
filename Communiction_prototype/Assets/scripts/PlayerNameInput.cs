using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private InputField nameInput = null;
    [SerializeField] private Button continuebutton = null;

    public static string displayname { get; private set; }

    private const string playerPrefsNameKey = "playerName";

    private void Start() => SetupInputField();
    // Start is called before the first frame update
    private void SetupInputField()
    {
        if(!PlayerPrefs.HasKey(playerPrefsNameKey)) { return; }

        string defaultName = PlayerPrefs.GetString(playerPrefsNameKey);
        nameInput.text = defaultName;

        SetPlayerName(defaultName);
    }
    public void SetPlayerName(string name)
    {
        continuebutton.interactable = !string.IsNullOrEmpty(name);
    }

  public void SavePlayerName()
    {
        displayname = nameInput.text;
        PlayerPrefs.SetString(playerPrefsNameKey, displayname);
    }
}
