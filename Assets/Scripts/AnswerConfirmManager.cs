using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerConfirmManager : MonoBehaviour
{

    [HideInInspector]
    private bool lockAnswer1;
    [HideInInspector]
    private bool lockAnswer2;
    [HideInInspector]
    private bool lockAnswer3;
    [HideInInspector]
    private bool lockAnswer4;

    [SerializeField]
    private Button answer1;
    [SerializeField]
    private Button answer2;
    [SerializeField]
    private Button answer3;
    [SerializeField]
    private Button answer4;

    private QuizGenerator quizGenerator;
    // Start is called before the first frame update

    private void Start()
    {
        quizGenerator = GameObject.FindObjectOfType<QuizGenerator>();
    }

    public void LockAnswer(int lockNumber)
    {
        switch (lockNumber)
        {
            case 0:
                lockAnswer1 = true;
                lockAnswer2 = false;
                lockAnswer3 = false;
                lockAnswer4 = false;

                answer2.interactable = false;
                answer3.interactable = false;
                answer4.interactable = false;
                break;

            case 1:
                lockAnswer2 = true;
                lockAnswer1 = false;
                lockAnswer3 = false;
                lockAnswer4 = false;

                answer1.interactable = false;
                answer3.interactable = false;
                answer4.interactable = false;
                break;

            case 2:
                lockAnswer3 = true;
                lockAnswer1 = false;
                lockAnswer2 = false;
                lockAnswer4 = false;

                answer2.interactable = false;
                answer1.interactable = false;
                answer4.interactable = false;
                break;

            case 3:
                lockAnswer4 = true;
                lockAnswer1 = false;
                lockAnswer2 = false;
                lockAnswer3 = false;

                answer2.interactable = false;
                answer3.interactable = false;
                answer1.interactable = false;
                break;
        }
    }

    public void CheckAnswer()
    {
        if (lockAnswer1)
        {
            quizGenerator.SelectAnswer(0);
            SetAnswersInteractable();
        }

        else if (lockAnswer2)
        {
            quizGenerator.SelectAnswer(1);
            SetAnswersInteractable();
        }

        else if (lockAnswer3)
        {
            quizGenerator.SelectAnswer(2);
            SetAnswersInteractable();
        }

        else if (lockAnswer4)
        {
            quizGenerator.SelectAnswer(3);
            SetAnswersInteractable();
        }
    }

    public void SetAnswersInteractable()
    {
        answer1.interactable = true;
        answer2.interactable = true;
        answer3.interactable = true;
        answer4.interactable = true;
    }
}
