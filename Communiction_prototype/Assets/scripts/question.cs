using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct answer
{
    [SerializeField] private string _info;
    public string Info { get { return _info; } }

    [SerializeField] private bool _iscorrect;
    public bool iscorrect { get { return _iscorrect; } }
}
public class question : ScriptableObject
{
    [SerializeField] private string _info = string.Empty;
    public string Info { get { return _info; } }

    [SerializeField] answer[] _answer = null;
    public answer[] Answer { get { return _answer; } }

    //parameters

    [SerializeField] private bool _usetimer = false;
    public bool Usetimer { get { return _usetimer; } }

    [SerializeField] private int _timer = 0;
    public int Timer { get { return _timer; } }

    [SerializeField] private int _addscore = 10;
    public int AddScore { get { return _addscore; } }

    public List<int> GetcorrectAnswers()
    {
        List<int> correctanwsers = new List<int>();
        for (int i = 0; i < Answer.Length; i++)
        {
            if (Answer[i].iscorrect)
            {
                correctanwsers.Add(i);
            }
        }
        return correctanwsers;
    }
    
}
