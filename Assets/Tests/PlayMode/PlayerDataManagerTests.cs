using NUnit.Framework;
using UnityEngine;

public class PlayerDataManagerTests
{
    private PlayerDataManager playerDataManager;

    [SetUp]
    public void Setup()
    {
        GameObject playerDataObject = new GameObject("PlayerDataManagerTest");
        playerDataManager = playerDataObject.AddComponent<PlayerDataManager>();
    }

    [Test]
    public void SavePlayerName_SavesCorrectly()
    {
        // Simular que el jugador escribe un nombre
        string testName = "JugadorPrueba";
        PlayerPrefs.SetString("PlayerName", testName);
        PlayerPrefs.Save();

        // Leer el nombre guardado
        string savedName = PlayerPrefs.GetString("PlayerName");

        // Verificar que el nombre guardado es el correcto
        Assert.AreEqual(testName, savedName, "El nombre del jugador no se guardó correctamente.");
    }
}
