using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public GameObject reward;
    public Animator animator;
    IGameManager gameManager;
    
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Mgr").GetComponent<VideoPreparation>() as IGameManager;
        gameManager.OnGameStartHandler += HideReward;
        gameManager.OnGameRewardHandler += ShowReward;    
    }

    void HideReward()
    {
        reward.SetActive(false);
    }

    void ShowReward()
    {
        reward.SetActive(true);
        animator.Play("Rise");
    }
}
