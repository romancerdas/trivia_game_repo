using UnityEngine;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance;

    [System.Serializable]
    public class QuestionData
    {
        public string question;
        public string correctAnswer;
        public List<string> wrongAnswers;
    }

    private List<QuestionData> allQuestions = new List<QuestionData>();
    private List<QuestionData> unusedQuestions = new List<QuestionData>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        InitializeQuestions();
        ResetQuestionCycle();
    }

    private void InitializeQuestions()
    {
        allQuestions = new List<QuestionData>
        {
            new QuestionData { question = "What is 12 multiplied by 12?", correctAnswer = "144", wrongAnswers = new List<string> { "124", "154", "130", "142" } },
            new QuestionData { question = "What is the square root of 81?", correctAnswer = "9", wrongAnswers = new List<string> { "6", "8", "12", "7" } },
            new QuestionData { question = "Approximate value of Pi to two decimals?", correctAnswer = "3.14", wrongAnswers = new List<string> { "3.12", "3.18", "3.21", "3.04" } },
            new QuestionData { question = "Which shape is the opposite of convex?", correctAnswer = "Concave", wrongAnswers = new List<string> { "Linear", "Angular", "Flat", "Curved" } },
            new QuestionData { question = "What is 2 raised to the power of 5?", correctAnswer = "32", wrongAnswers = new List<string> { "16", "64", "24", "36" } },
            new QuestionData { question = "What element is first on the periodic table?", correctAnswer = "Hydrogen", wrongAnswers = new List<string> { "Helium", "Oxygen", "Carbon", "Nitrogen" } },
            new QuestionData { question = "What does the formula H2O stand for?", correctAnswer = "Water", wrongAnswers = new List<string> { "Salt", "Hydrogen", "Oxygen", "Acid" } },
            new QuestionData { question = "What is the capital city of Egypt?", correctAnswer = "Cairo", wrongAnswers = new List<string> { "Lagos", "Algiers", "Nairobi", "Tripoli" } },
            new QuestionData { question = "Who is credited with inventing the light bulb?", correctAnswer = "Edison", wrongAnswers = new List<string> { "Tesla", "Newton", "Einstein", "Franklin" } },
            new QuestionData { question = "Which planet is third from the Sun?", correctAnswer = "Earth", wrongAnswers = new List<string> { "Mars", "Venus", "Mercury", "Jupiter" } },
            new QuestionData { question = "What is the fastest land animal?", correctAnswer = "Cheetah", wrongAnswers = new List<string> { "Lion", "Horse", "Jaguar", "Antelope" } },
            new QuestionData { question = "What is the hardest natural material?", correctAnswer = "Diamond", wrongAnswers = new List<string> { "Quartz", "Granite", "Topaz", "Steel" } },
            new QuestionData { question = "Which blood cells defend the body from infection?", correctAnswer = "White", wrongAnswers = new List<string> { "Red", "Blue", "Green", "Plasma" } },
            new QuestionData { question = "What is the chemical symbol for gold?", correctAnswer = "Au", wrongAnswers = new List<string> { "Ag", "Gd", "Go", "Pt" } },
            new QuestionData { question = "What is the speed of light in m/s?", correctAnswer = "299792458", wrongAnswers = new List<string> { "300000", "150000000", "299000000", "250000000" } },
            new QuestionData { question = "What is the smallest bone in the human body?", correctAnswer = "Stapes", wrongAnswers = new List<string> { "Femur", "Tibia", "Ulna", "Phalanx" } },
            new QuestionData { question = "What is the binary representation of 10?", correctAnswer = "1010", wrongAnswers = new List<string> { "1100", "1001", "1110", "1000" } },
            new QuestionData { question = "Which planet is the heaviest in the solar system?", correctAnswer = "Jupiter", wrongAnswers = new List<string> { "Saturn", "Neptune", "Earth", "Uranus" } },
            new QuestionData { question = "What famous equation did Einstein develop?", correctAnswer = "E = mc²", wrongAnswers = new List<string> { "E = mgh", "E = mv²", "E = pV", "E = c²m" } },
            new QuestionData { question = "What is the sine of 90 degrees?", correctAnswer = "1", wrongAnswers = new List<string> { "0", "-1", "0.5", "0.707" } },
            new QuestionData { question = "What is the Roman numeral for 100?", correctAnswer = "C", wrongAnswers = new List<string> { "D", "X", "L", "M" } },
            new QuestionData { question = "How many DNA bases exist in humans?", correctAnswer = "4", wrongAnswers = new List<string> { "3", "2", "5", "6" } },
            new QuestionData { question = "What is the boiling point of water in Celsius?", correctAnswer = "100", wrongAnswers = new List<string> { "90", "80", "110", "120" } },
            new QuestionData { question = "Who was the first U.S. President?", correctAnswer = "Washington", wrongAnswers = new List<string> { "Lincoln", "Adams", "Jefferson", "Franklin" } }
        };
    }

    private void ResetQuestionCycle()
    {
        unusedQuestions = new List<QuestionData>(allQuestions);
    }

    public QuestionData GetRandomQuestion()
    {
        if (unusedQuestions.Count == 0)
        {
            ResetQuestionCycle();
        }

        int index = Random.Range(0, unusedQuestions.Count);
        var selected = unusedQuestions[index];
        unusedQuestions.RemoveAt(index);
        return selected;
    }
}
