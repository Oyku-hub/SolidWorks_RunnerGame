using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CommanVariables;

public class GameManager : SingletonCreator<GameManager>
{
    [SerializeField] PanelBase[] panelBase;
    public static event Action OnStartGame;

    private void Start()
    {
        
        SetPanel(PanelTypes.Start);        
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
