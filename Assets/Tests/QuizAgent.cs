using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using TMPro;

public class QuizAgent : Agent
{
    private GameManager gameManager;

    public override void Initialize()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Observa el índice de la pregunta actual
        sensor.AddObservation(gameManager.currentPanelIndex);

        // Observa el texto de la pregunta (como un número ID)
        sensor.AddObservation(gameManager.questionTexts[gameManager.currentPanelIndex].text.GetHashCode());
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int selectedAnswer = Mathf.FloorToInt(actions.DiscreteActions[0]);

        // Simula la elección de respuesta del jugador
        gameManager.CheckAnswer(selectedAnswer);

        // Recompensa si la respuesta es correcta
        if (gameManager.feedbackTexts[gameManager.currentPanelIndex].text == "¡Correcto!")
        {
            SetReward(1f);
        }
        else
        {
            SetReward(-0.5f);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = Random.Range(0, 3); // Selección aleatoria entre 0 y 2
    }

}
