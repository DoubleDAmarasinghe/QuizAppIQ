using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.SimpleLocalization;

public class QuizGenerator : MonoBehaviour
{
    [SerializeField]
    private TMP_Text questionText;
    [SerializeField]
    private Button[] answerButtons;
    [SerializeField]
    private TMP_Text questionNumberText;
    [SerializeField]
    private GameObject correctPannel;
    [SerializeField]
    private GameObject inCorrectPannel;
    [SerializeField]
    private GameObject gameEndPannel;

    private Animator correctPannelAnim;
    private Animator inCorrectPannelAnim;
    private Animator gameEndPannelAnim;


    
    [SerializeField]
    private string[] questions;

    private SoundManager soundManager;

    private string[][] answers = {
        new string[] { "Question1Answer1", "Question1Answer2", "Question1Answer3", "Question1Answer4" },
        new string[] { "Question2Answer1", "Question2Answer2", "Question2Answer3", "Question2Answer4" },
        new string[] { "Question3Answer1", "Question3Answer2", "Question3Answer3", "Question3Answer4" },
        new string[] { "Question4Answer1", "Question4Answer2", "Question4Answer3", "Question4Answer4" },
        new string[] { "Question5Answer1", "Question5Answer2", "Question5Answer3", "Question5Answer4" },
        new string[] { "Question6Answer1", "Question6Answer2", "Question6Answer3", "Question6Answer4" },
        new string[] { "Question7Answer1", "Question7Answer2", "Question7Answer3", "Question7Answer4" },
        new string[] { "Question8Answer1", "Question8Answer2", "Question8Answer3", "Question8Answer4" },
        new string[] { "Question9Answer1", "Question9Answer2", "Question9Answer3", "Question9Answer4" },
        new string[] { "Question10Answer1", "Question10Answer2", "Question10Answer3", "Question10Answer4" },
        // Add more answers here...
    };

    private int[] correctAnswers = {0,0,0,0,0,0,0,0,0,0};

    private bool[] questionShown;
    private int numQuestions;
    private int score = 0;
    private int currentQuestionIndex = -1;
    private int questionNumber = 1;

    void Start()
    {
        soundManager = GameObject.FindObjectOfType<SoundManager>();

        correctPannelAnim = correctPannel.GetComponent<Animator>();
        inCorrectPannelAnim = inCorrectPannel.GetComponent<Animator>();
        gameEndPannelAnim = gameEndPannel.GetComponent<Animator>();

        numQuestions = questions.Length;
        questionShown = new bool[numQuestions];
        questionNumberText.text = "#" + questionNumber.ToString();
        for (int i = 0; i < numQuestions; i++)
        {
            questionShown[i] = false;
        }
        NextQuestion();
    }

    public void SelectAnswer(int index)
    {
        if (correctAnswers[currentQuestionIndex] == index)
        { 
           score++;
           questionNumber++;
           correctPannelAnim.Play("CorrectPannelUp");
           soundManager.PlayAudioContainer("Correct");
           
           //NextQuestion();
        }
        else
        {
            Debug.Log("Incorrect answer, try again.");
            inCorrectPannelAnim.Play("InCorrectPannelUp");
            soundManager.PlayAudioContainer("Incorrect");
        }
    }

    public void GetNextQuizButton()
    {   
        correctPannelAnim.Play("CorrectPannelDown");
        NextQuestion();
        
        
    }

    public void ReTryButton()
    {
        Debug.Log("ffffffffffffffffff");
        inCorrectPannelAnim.Play("InCorrectAnswerDown");
        
    }

    private int GetNextQuestionIndex()
    {
        List<int> unusedQuestions = new List<int>();
        for (int i = 0; i < numQuestions; i++)
        {
            if (!questionShown[i])
            {
                unusedQuestions.Add(i);
            }
        }
        if (unusedQuestions.Count == 0)
        {
            return -1;
        }
        int randomIndex = Random.Range(0, unusedQuestions.Count);
        int nextQuestionIndex = unusedQuestions[randomIndex];
        questionShown[nextQuestionIndex] = true;
        return nextQuestionIndex;
    }

    private void NextQuestion()
    {
        currentQuestionIndex = GetNextQuestionIndex();
        if (currentQuestionIndex == -1)
        {
            gameEndPannelAnim.Play("GameEndUp");
            Debug.Log("Game finished");
            return;
        }
        //questionText.text = questions[currentQuestionIndex];
        questionText.text = LocalizationManager.Localize(questions[currentQuestionIndex]);
        questionText.GetComponent<LocalizedText>().LocalizationKey = questions[currentQuestionIndex];
        questionNumberText.text = "#" + questionNumber.ToString();
        Debug.Log(currentQuestionIndex);
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = LocalizationManager.Localize(answers[currentQuestionIndex][i]);
        }
    }
}
