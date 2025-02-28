using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using TMPro;

public class GameTests
{
    private GameManager gameManager;

    [SetUp]
    public void Setup()
    {
        GameObject gameObject = new GameObject();
        gameManager = gameObject.AddComponent<GameManager>();
        gameManager.Start();
    }

    [Test]
    public void CheckFirstQuestionIsDisplayed()
    {
        Assert.IsNotNull(gameManager.questionTexts[0].text);
    }

    public IEnumerator AnswerButtonWorks()
    {
        yield return null;
        gameManager.CheckAnswer(2); // Simula respuesta correcta

        Assert.AreEqual("¡Correcto!", gameManager.feedbackTexts[0].text);
    }
}
