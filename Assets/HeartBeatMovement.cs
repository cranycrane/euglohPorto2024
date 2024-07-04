using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class BoxMovementOnHandDistance : MonoBehaviour
{
    public GameObject leftHand; 
    public GameObject rightHand; 
    public float activationDistance = 0.5f; 
    public float beatInterval = 0.6f;
    public float moveDistance = 1.0f;
    public float moveDuration = 0.3f;
    public TextMeshProUGUI timerText;

    private Renderer boxRenderer;
    private Color originalColor;

    private Vector3 startPosition;
    private bool isMoving = false;
    private bool timerStarted = false;
    private bool showFinalTime = false;
    private float countdownTime = 10f;
    private float timeInArea = 0f;
    private float finalTimeDisplayDuration = 10f; 
    private float finalTimeDisplayTime = 0f;
    private Sequence heartbeatSequence;

    void Start()
    {
        boxRenderer = GetComponent<Renderer>();
        originalColor = boxRenderer.material.color;
        startPosition = transform.position;
        heartbeatSequence = DOTween.Sequence();
        heartbeatSequence.Append(transform.DOMove(startPosition + transform.up * moveDistance, moveDuration).SetEase(Ease.InOutSine));
        heartbeatSequence.Append(transform.DOMove(startPosition, moveDuration).SetEase(Ease.InOutSine));
        heartbeatSequence.SetLoops(-1, LoopType.Restart);
        heartbeatSequence.SetDelay(beatInterval - moveDuration * 2);
        heartbeatSequence.Pause();
        UpdateTimerText(countdownTime);
    }

    void Update()
    {
        float distanceToLeftHand = Vector3.Distance(transform.position, leftHand.transform.position);
        float distanceToRightHand = Vector3.Distance(transform.position, rightHand.transform.position);

        if (showFinalTime)
        {
            finalTimeDisplayTime += Time.deltaTime;
            if (finalTimeDisplayTime >= finalTimeDisplayDuration)
            {
                showFinalTime = false;
                timerText.text = ""; 
            }
            return; 
        }

        if (timerStarted && countdownTime <= 0f)
        {
            timerStarted = false;
            isMoving = false;
            boxRenderer.material.color = originalColor;
            heartbeatSequence.Pause();
            ShowFinalTime();
            return; 
        }

        if (distanceToLeftHand < activationDistance && distanceToRightHand < activationDistance)
        {
            if (!isMoving)
            {
                isMoving = true;
                heartbeatSequence.Play();
                // change color to red
                boxRenderer.material.color = new Color(1, 0, 0, 0.5f); ;
                timeInArea = 0f;
                if (!timerStarted)
                {
                    timerStarted = true;
                    countdownTime = 10f; 
                }
            }
            else
            {
                timeInArea += Time.deltaTime;
                UpdateTimerText(countdownTime);
            }
        }

        if (timerStarted && countdownTime > 0f)
        {
            countdownTime -= Time.deltaTime;
            UpdateTimerText(countdownTime);
        }
    }

    void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        timerText.text = string.Format("Time left: {0:00}:{1:00}", minutes, seconds);
    }

    void ShowFinalTime()
    {
        showFinalTime = true;
        finalTimeDisplayTime = 0f;
        int minutes = Mathf.FloorToInt(timeInArea / 60F);
        int seconds = Mathf.FloorToInt(timeInArea % 60F);
        timerText.text = string.Format("Total time in area: {0:00}:{1:00}", minutes, seconds);
    }
}
