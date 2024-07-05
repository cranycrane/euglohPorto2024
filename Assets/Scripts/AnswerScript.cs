using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public UnityEvent onButtonPressed;
    public UnityEvent onButtonReleased;
    public ParticleSystem particleSystem;
    private bool isPressed = false;

    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTERED");
        if (other.CompareTag("GameController") && !isPressed)
        {
            isPressed = true;
            particleSystem.Play();
            onButtonPressed.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameController") && isPressed)
        {
            particleSystem.Stop();
            isPressed = false;
            onButtonReleased.Invoke();
        }
    }
    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct answer");
            quizManager.Correct();
            animator.SetTrigger("Kill");
        }
        else
        {
            Debug.Log("NOT CORRECT");
            quizManager.InCorrect();
        }

    }
}
