using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseShow : MonoBehaviour
{
    public InputActionReference pauseAction;
    public GameObject pausePanel;
    public ObstacleMap obstacleMap;
    public GameObject[] objectsToDeactivate;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (pauseAction.action.WasPerformedThisFrame())
        {
            if (pausePanel.activeSelf) // DESPAUSAR
            {
                pausePanel.SetActive(false);
                foreach (GameObject obj in obstacleMap.obstaclesMap)
                {
                    obj.SetActive(true);
                }
                foreach (GameObject obj in objectsToDeactivate)
                {
                    obj.SetActive(true);
                }
                Time.timeScale = 1;
            }
            else // PAUSAR
            {
                pausePanel.SetActive(true);
                foreach (GameObject obj in obstacleMap.obstaclesMap)
                {
                    obj.SetActive(false);
                }

                foreach (GameObject obj in objectsToDeactivate)
                {
                    obj.SetActive(false);
                }
                Time.timeScale = 0;
            }
            
        }
        
        
    }

    public void ContinueButton()
    {
        if (pausePanel.activeSelf) // DESPAUSAR
        {
            pausePanel.SetActive(false);
            foreach (GameObject obj in obstacleMap.obstaclesMap)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in objectsToDeactivate)
            {
                obj.SetActive(true);
            }
            Time.timeScale = 1;
        }
    }
    
    
}