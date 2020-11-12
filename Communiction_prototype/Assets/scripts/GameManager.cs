using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    question[] _questions = null;
    public question[] Questions { get { return _questions; } }
    private List<int> answeredquestions = new List<int>();
    private int score;

    void display()
    {

    }
}
