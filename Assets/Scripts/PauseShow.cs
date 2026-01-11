using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseShow : MonoBehaviour
{
    public InputActionReference pauseAction;
    public GameObject pausePanel;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (pauseAction.action.WasPerformedThisFrame())
        {
            if (pausePanel.activeSelf)
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}