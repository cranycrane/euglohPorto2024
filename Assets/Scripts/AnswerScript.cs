using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public void Answer()
    {
        if(isCorrect)
        {
            quizManager.Score++;
            Debug.Log("Correct answer");
        }
        else
        {
            Debug.Log("NOT CORRECT");
        }

        quizManager.Next();


    }
}
