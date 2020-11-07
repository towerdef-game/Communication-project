using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anwserdata : MonoBehaviour
{

    [Header("UI Elements")]
    [SerializeField] Text infotextobject;
    [SerializeField] Image toggle;

    [Header("textures")]
    [SerializeField] Sprite unchecktoggle;
    [SerializeField] Sprite checktoggle;

    private int _anwserIndex = -1;
    public int AnswerIndex { get { return _anwserIndex; } }
}
