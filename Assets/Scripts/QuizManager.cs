using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public int QuestionsCount;
    public GameObject ImageCard;
    public GameObject[] options;
    public int Score = 0;
    public string FinishText;

    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    public int currentQuestionIndex = 0;

    public TextMeshProUGUI QuestionTxt;

    private void Start()
    {
        QuestionsCount = QnA.Count;
        GenerateQuestion();
    }

    public void Correct()
    {
        audioSource.clip = correctSound;
        audioSource.Play();
        Score++;
        Next();
    }

    public void InCorrect()
    {
        audioSource.clip = wrongSound;
        audioSource.Play();
        Next();
    }

    public void Next()
    {
        QnA.RemoveAt(0);
        GenerateQuestion();
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

    public void GenerateQuestion()
    {
        if (QnA.Count <= 0)
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].SetActive(false);
            }
            QuestionTxt.text = FinishText + Score.ToString() + "/" + QuestionsCount;
            return;
        }

        ImageCard.GetComponent<Image>().sprite = QnA[0].Image;
        QuestionTxt.text = QnA[0].Question;
    
        SetAnswers();
    }
}
