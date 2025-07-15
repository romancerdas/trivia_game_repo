using UnityEngine;
using TMPro;

public class questionSelect : MonoBehaviour
{
    public TextMeshProUGUI topBarLabel;
    public TextMeshPro answer1, answer2, answer3;
    public GameObject barrier1, barrier2, barrier3;

    void Start()
    {
        ShowNewQuestion();
    }

    public void ShowNewQuestion()
    {
        var qa = QuestionManager.Instance.GetRandomQuestion();

        topBarLabel.text = qa.question;

        string[] answers = new string[3];
        int correctIndex = Random.Range(0, 3);
        answers[correctIndex] = qa.correctAnswer;

        int wrongAnswerIndex = 0;
        for (int i = 0; i < 3; i++)
        {
            if (i != correctIndex)
            {
                answers[i] = qa.wrongAnswers[wrongAnswerIndex++];
            }
        }

        answer1.text = answers[0];
        answer2.text = answers[1];
        answer3.text = answers[2];

        barrier1.tag = (correctIndex == 0) ? "Correct" : "Wrong";
        barrier2.tag = (correctIndex == 1) ? "Correct" : "Wrong";
        barrier3.tag = (correctIndex == 2) ? "Correct" : "Wrong";

        barrier1.GetComponent<Trigger>().isCorrect = (correctIndex == 0);
        barrier2.GetComponent<Trigger>().isCorrect = (correctIndex == 1);
        barrier3.GetComponent<Trigger>().isCorrect = (correctIndex == 2);

        ColorizeBarrier(barrier1);
        ColorizeBarrier(barrier2);
        ColorizeBarrier(barrier3);
    }

    void ColorizeBarrier(GameObject barrier)
    {
        var renderer = barrier.GetComponent<Renderer>();
        var trigger = barrier.GetComponent<Trigger>();

        if (renderer != null && trigger != null)
        {
            renderer.material.color = trigger.isCorrect ? Color.green : Color.red;
        }
    }
}
