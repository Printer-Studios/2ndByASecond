using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseShow : MonoBehaviour
{
    public InputActionReference pauseAction;
    public GameObject pausePanel;
    public ObstacleMap obstacleMap;

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
                foreach (GameObject obj in obstacleMap.obstaclesMap)
                {
                    obj.SetActive(true);
                }
                Time.timeScale = 1;
            }
            else
            {
                pausePanel.SetActive(true);
                foreach (GameObject obj in obstacleMap.obstaclesMap)
                {
                    obj.SetActive(false);
                }
                Time.timeScale = 0;
            }
            
        }
    }
}