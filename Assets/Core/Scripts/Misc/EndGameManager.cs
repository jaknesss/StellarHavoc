using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public GameObject endGamePanel;
    
    public void ActivateEndPanel() {
        endGamePanel.SetActive(true);
    }
    
}
