using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

public class TestScript : MonoBehaviour
{
    public int randomQuestion { get; set; }
    public bool stopTestWrongAnswer { get; set; }
    public bool endTest { get; set; }
    private float trueAnswers { get; set; }
    private float NumberOfQuestions { get; set; }
    public Slider testProgressBar;
    public Button answerButtonA;
    public Button answerButtonB;
    public Button answerButtonC;
    public Button answerButtonD;
    public Button backButton;
    public Text buttonText;
    public GameObject panel;
    public QuestionList[] questions;
    public Text[] answersText;
    public Text questionText;
    public Button startButton;
    public List<object> questionList;
    public QuestionList currentQuestion;
    [SerializeField] private string sceneToLoad;
    

    private void Start()
    {
        NumberOfQuestions = 10;
        trueAnswers = 0;
        testProgressBar.value = CalculateTestprogress();
        stopTestWrongAnswer = false;
        endTest = false;

        testProgressBar.gameObject.SetActive(false);
        answerButtonA.gameObject.SetActive(false);
        answerButtonB.gameObject.SetActive(false);
        answerButtonC.gameObject.SetActive(false);
        answerButtonD.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }

    public void StartButton()
    {
        questionList = new List<object>(questions);
        testProgressBar.gameObject.SetActive(true);
        answerButtonA.gameObject.SetActive(true);
        answerButtonB.gameObject.SetActive(true);
        answerButtonC.gameObject.SetActive(true);
        answerButtonD.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        QuestionGenerate();
    }

    public void BackButton()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitFromTestButton()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuestionGenerate()
    {
        startButton.gameObject.SetActive(false);
        if (questionList.Count > 0)
        {
            randomQuestion = UnityEngine.Random.Range(0, questionList.Count);
            currentQuestion = questionList[randomQuestion] as QuestionList;
            questionText.text = currentQuestion.question;

            List<string> answers = new List<string>(currentQuestion.answers);

            for (int i = 0; i < currentQuestion.answers.Length; i++)
            {
                int rand = UnityEngine.Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
        }
        else
        {
            Debug.Log("End of test!");
        }
    }

    public void AnswersButtons(int index)
    {
        if (answersText[index].text.ToString() == currentQuestion.answers[0])
        {
            //Тут має бути анімація, коли чєл відповідає правильно
            trueAnswers++;
            Debug.Log("True answers: " + trueAnswers);
            if (trueAnswers == 10)
            {
                endTest = true;
            }
        }
        else
        {
            //Тут має бути анімація, коли чєл відповідає неправильно
            stopTestWrongAnswer = true;
        }

        questionList.RemoveAt(randomQuestion);
        QuestionGenerate();
    }

    private void Update()
    {
        testProgressBar.value = CalculateTestprogress();
        if (stopTestWrongAnswer)
        {
            testProgressBar.gameObject.SetActive(false);
            answerButtonA.gameObject.SetActive(false);
            answerButtonB.gameObject.SetActive(false);
            answerButtonC.gameObject.SetActive(false);
            answerButtonD.gameObject.SetActive(false);
            questionText.gameObject.SetActive(false);
            backButton.gameObject.SetActive(false);
            panel.gameObject.SetActive(true);
        }

        if (endTest)
        {
            testProgressBar.gameObject.SetActive(false);
            answerButtonA.gameObject.SetActive(false);
            answerButtonB.gameObject.SetActive(false);
            answerButtonC.gameObject.SetActive(false);
            answerButtonD.gameObject.SetActive(false);
            questionText.gameObject.SetActive(false);
            backButton.gameObject.SetActive(false);
            panel.gameObject.SetActive(true);
            panel.GetComponent<Image>().color = Color.green;
            buttonText.text = "To menu";
        }
    }

    public float CalculateTestprogress()
    {
        return trueAnswers / NumberOfQuestions;
    }
}

[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[2];
}