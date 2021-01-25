using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    private bool special;
    public GameObject basicMenu;
    public GameObject specialMenu;
    public GameObject winMenu;

    private string moveSelected;
    private string pcMoveSelected;

    private List<string> moves = new List<string> { "Rock", "Paper", "Scissors" };
    private List<string> win = new List<string>();

    public Sprite Rock;
    public Sprite Paper;
    public Sprite Scissors;
    public Sprite Lizard;
    public Sprite Spock;
    private List<Sprite> Icons = new List<Sprite>();

    public Image PlayerMove;
    public Image PCMove;

    public Text OutputText;

    public Text PlayerScoreText;
    public Text PCScoreText;

    private int playerScore = 0;
    private int pcScore = 0;

    public AudioManager audioManager;

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        SetScore();
        this.special = (PlayerPrefs.GetInt("Mode") == 1);

        this.Icons = new List<Sprite> { Rock, Paper, Scissors };

        if (special)
        {
            moves.Add("Lizard"); moves.Add("Spock");
            basicMenu.SetActive(false);
            specialMenu.SetActive(true);
            this.win = new List<string> { "Lizard", "Rock", "Paper", "Spock", "Scissors",
                                          "Scissors", "Spock", "Lizard", "Paper", "Rock" };

            Icons.Add(Lizard); Icons.Add(Spock);
        }
        else
        {
            this.win = new List<string> { "Scissors", "Rock", "Paper" };
        }
    }

    public void ButtonPressed(string buttonName)
    {
        this.moveSelected = buttonName;
        Debug.Log(moveSelected);
        CheckWinner();
    }

    public void GetRandomMove()
    {
        this.pcMoveSelected = moves[Random.Range(0,moves.Count)];
        Debug.Log(pcMoveSelected);
    }

    public void CheckWinner()
    {
        GetRandomMove();
        if (!IsDraw())
        {
            if (win[GetIndex(moveSelected)].Equals(pcMoveSelected))
            {
                DisplayOutput("You win");
                FindObjectOfType<AudioManager>().Play("Correct");
                playerScore++;
            }
            else
            {
                if (special)
                {
                    if (win[GetIndex(moveSelected)+5].Equals(pcMoveSelected))
                    {
                        DisplayOutput("You win");
                        FindObjectOfType<AudioManager>().Play("Correct");
                        playerScore++;
                    }
                }
                DisplayOutput("You loose");
                FindObjectOfType<AudioManager>().Play("Life_Lost");
                pcScore++;
            }
        }
        else
        {
            DisplayOutput("Draw");
        }
    }

    public bool IsDraw() {
        return moveSelected.Equals(pcMoveSelected);
    }

    public int GetIndex(string moveInput)
    {
        int i;
        for (i = 0; i < moves.Count; i++)
        {
            if (moveInput.Equals(moves[i]))
            {
                break;
            }
        }
        return i; 
    }

    public void SetScore()
    {
        PlayerScoreText.text = "Your Score : " + playerScore;
        PCScoreText.text = "PC's Score : " + pcScore;
    }

    public void DisplayOutput(string text)
    {
        SetScore();
        winMenu.SetActive(true);
        if (special)
        {
            specialMenu.SetActive(false);
        }
        else
        {
            basicMenu.SetActive(false);
        }

        PlayerMove.sprite = Icons[GetIndex(moveSelected)];
        PCMove.sprite = Icons[GetIndex(pcMoveSelected)];
        OutputText.text = text;
        StartCoroutine(Reset());
    }


    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);
        winMenu.SetActive(false);
        basicMenu.SetActive(true);
        StartGame();
    }
}
