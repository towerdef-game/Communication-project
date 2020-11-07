using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    //  question[] _questions = null;
    //  public question[] Questions { get { return _questions; } }
    //  private List<int> answeredquestions = new List<int>();
    //   private int currentQuestion = 0;
    //  private int score;

    //  void Display()
    //  {

    // }
    public questions2[] questions;
    private static List<questions2> unanswered;

    private questions2 currentword;

    [SerializeField]
    private Text spelling;

    [SerializeField]
    private float timebeweenquestions = 1f;
    void Start()
    {
       if(unanswered == null || unanswered.Count == 0)
        {
            unanswered = questions.ToList<questions2>();
        }
        randomword();
        Debug.Log(currentword.word + "is" + currentword.iscorrect);
    }

    void randomword()
    {
        int randomquestionindex = Random.Range(0, unanswered.Count);
        currentword = unanswered[randomquestionindex];

     spelling.text = currentword.word;

        
    }
    IEnumerator transitiontonextquestion()
    {
        unanswered.Remove(currentword);

        yield return new WaitForSeconds(timebeweenquestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Userselectright()
    {
        if (currentword.iscorrect)
        {
            Debug.Log("correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
       StartCoroutine (transitiontonextquestion());
    }
    public void UserselectWrong()
    {
        if (!currentword.iscorrect)
        {
            Debug.Log("correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
        StartCoroutine(transitiontonextquestion());
    }

}
