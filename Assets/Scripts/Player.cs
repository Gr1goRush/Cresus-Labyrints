using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject character; // Персонаж
    public float speed; // Скорость перемещения
    bool up,down,right,left = false;
    [SerializeField]Image Timer;
    float timer = 20;
    float Score = 1000;
   [SerializeField] Text ScoreText;
    bool win= false ;
    [SerializeField] GameObject FinishSkrin,Menu;
    [SerializeField] Text timerText;
    [SerializeField] Text AnalizText,FinalScore,BestScore;    
    // Use this for initialization
    void Start()
    {
        BestScore.text = "Best Score  " + PlayerPrefs.GetInt("BestScore");
        win = true;
        Menu.SetActive(true);
        FinishSkrin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!win)
        {
            ScoreScropt();
            MovMent();
            TimerScropt();
        }
       
    }
    public void TimerScropt()
    {
        timer -= Time.deltaTime;
        Timer.fillAmount = timer/20;
        timerText.text = (int)timer+" sec";
        if (timer<=0)
        {
            Lose();
        }
    }
    public void ScoreScropt()
    {
        
        ScoreText.text = "Score " + (int)Score; 
    }
    public void Lose()
    {
        win = true;
        FinishSkrin.SetActive(true);
        AnalizText.text= "Game Over";
        FinalScore.text = "Score   0";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall"&&Score>100)
        {
            Score -= 100;
        }
        if (collision.gameObject.tag == "finish")
        {
            win = true;
            Score += timer * UnityEngine.Random.Range(40,70);
            ScoreText.text = "Score " + (int)Score;
            FinishSkrin.SetActive(true);
            AnalizText.text = "You Win";
            FinalScore.text = "Score  "+(int)Score;
            if (Score > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore",(int)Score);
            }
        }
    }
   
    
    public void ToMenu()
    {
        BestScore.text = "Score  " + PlayerPrefs.GetInt("BestScore");
        win = true;
        Menu.SetActive(true);
        FinishSkrin.SetActive(false);
        Onul();
    }
    public void MenuExit()
    {
        Menu.SetActive(false);
        win = false;
        FinishSkrin.SetActive(false);
        Onul();
    }

    public void MovMent()
    {
        if (down)
        {
            character.transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (right)
        {
            character.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (left)
        {
            character.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (up)
        {
            character.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
    public void Onul()
    {
        transform.position = new Vector3(-1.5f, 1.3f, 0);
        timer = 20;
        Score = 1000;
    }
    public void Return()
    {
        Menu.SetActive(false);
        win = false;
        FinishSkrin.SetActive(false);
        Onul();
    }
    public void Exit()
    {
        Application.Quit();

    }

    public void TransformDown()
    {
        down = true;
    }
    public void TransformDownUP()
    {
        down = false;
    }
    public void TransformUp()
    {
        up = true;
    }
    public void TransformUpUP()
    {
        up = false;
    }
    public void Transformright()
    {
        right = true;
    }
    public void TransformrightUP()
    {
        right = false;
    }
    public void Transformleft()
    {
        left = true;
    }
    public void TransformleftUP()
    {
        left = false;
    }
}