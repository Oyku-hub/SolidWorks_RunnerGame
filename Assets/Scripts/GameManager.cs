using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CommanVariables;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameManager : SingletonCreator<GameManager>
{
    [SerializeField] PanelBase[] panelBase;
    public static event Action OnStartGame; //Her zaman eventi tanýmladýðýn yerde Invokela.
   [SerializeField] private Image healthFill;
    private PlayerHealth playerHealth;
    [SerializeField] TextMeshProUGUI textScore;
    private int currentScore=0;

    private void Start()
    {
        SetPanel(PanelTypes.Start);  
        playerHealth= GetComponent<PlayerHealth>();
    }
    private void OnEnable()
    {
        PlayerHealth.OnPlayerDied += PlayerHealth_OnPlayerDied;
        BaseObstacle.OnHit += OnHit;
        BaseCollectable.OnCollected += BaseCollectable_OnCollected;
        healthFill.fillAmount= 1;
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDied -= PlayerHealth_OnPlayerDied;
        BaseObstacle.OnHit -= OnHit;
        BaseCollectable.OnCollected += BaseCollectable_OnCollected;

    }

    private void BaseCollectable_OnCollected()
    {
        currentScore += 10;
        textScore.text=currentScore.ToString();
    }

    
    private void OnHit(float damage)
    {
        float fillAmount=playerHealth.GetCurrentHealth()/playerHealth.GetMaxHealth();
        healthFill.DOFillAmount(fillAmount,.5f);

    }
    private void PlayerHealth_OnPlayerDied()
    {
        SetPanel(PanelTypes.Faild);
    }

    public void StartGame()
    {
        OnStartGame?.Invoke();
        SetPanel(PanelTypes.InGame);
      
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
