using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject panelRegistro;
    public GameObject panelNivel1; // Nuevo panel agregado
    public GameObject[] panelesJuego;

    void Start()
    {
        ShowPanel(mainPanel);
    }

    public void ShowPanel(GameObject panelToShow)
    {
        // Desactivar todos los paneles
        mainPanel.SetActive(false);
        panelRegistro.SetActive(false);
        panelNivel1.SetActive(false);
        //panelJuegoFrutas1.SetActive(false); // Desactivar el nuevo panel

        foreach (var panel in panelesJuego)
        {
            panel.SetActive(false);
        }

        // Activar el panel solicitado
        panelToShow.SetActive(true);
    }
}
