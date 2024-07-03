using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject ImageCard;
    public GameObject[] options;
    public int Score = 0;
    public string FinishText;


    public int currentQuestionIndex = 0;

    public TextMeshProUGUI QuestionTxt;

    private void Start()
    {
        generateQuestion();
    }

    public void Correct()
    {
        Score++;
        QnA.RemoveAt(0);

        if (QnA.Count > 0)
        {
            generateQuestion();
        }
        else
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].SetActive(false);
            }
            QuestionTxt.text = FinishText + Score.ToString();
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = QnA[currentQuestionIndex].Answers[i];

            if (QnA[0].CorrectAnswerIndex == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        ImageCard.GetComponent<Image>().sprite = QnA[0].Image;
        QuestionTxt.text = QnA[0].Question;
    
        SetAnswers();

        //currentQuestionIndex++;
    }
}
