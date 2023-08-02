using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CommanVariables;

public class GameManager : SingletonCreator<GameManager>
{
    [SerializeField] PanelBase[] panelBase;
    public static event Action OnStartGame; //Her zaman eventi tanýmladýðýn yerde Invokela.

    private void Start()
    {
        
        SetPanel(PanelTypes.Start);        
    }
    private void OnEnable()
    {
        PlayerHealth.OnPlayerDied += PlayerHealth_OnPlayerDied;
    }

  
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDied -= PlayerHealth_OnPlayerDied;
    }
    private void PlayerHealth_OnPlayerDied()
    {
        SetPanel(PanelTypes.Faild);
    }

    public void StartGame()
    {
        OnStartGame?.Invoke();
        DisableAllPanels();
      
    }

    void SetPanel(PanelTypes panelType)
    {
        DisableAllPanels();
        panelBase[(int)panelType].gameObject.SetActive(true);
    }

    private void DisableAllPanels()
    {
        foreach (var panel in panelBase)
        {
            panel.gameObject.SetActive(false);
        }
    }
   


}
