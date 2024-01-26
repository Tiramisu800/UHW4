using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AchievementSystem : MonoBehaviour
{
    [SerializeField] private GameObject _killStrikeWindow;
    [SerializeField] private GameObject _killMegaStrikeWindow;
    [SerializeField] private GameObject _cashWindowI;
    [SerializeField] private GameObject _cashWindowII;
    [SerializeField] private GameObject _cashWindowIII;
    [SerializeField] private GameObject _cashWindow0;
    [SerializeField] private GameObject _defebceWindowI;
    [SerializeField] private GameObject _defebceWindowII;
    
    private void OnEnable()
    {
        EnemyManager.OnEnemyStriked += enemyKillStrike;
        EnemyManager.OnEnemyMegaStriked += enemyMegaKillStrike;
        GameMenager.OnCashI += CashI;
        GameMenager.OnCashII += CashII;
        GameMenager.OnCashIII += CashIII;
        GameMenager.OnCash0 += Cash0;
        GameMenager.OnDefenceI += DefenceI;
        GameMenager.OnDefenceII += DefenceII;
    }

    private void OnDisable()
    {
        EnemyManager.OnEnemyStriked -= enemyKillStrike;
        EnemyManager.OnEnemyMegaStriked -= enemyMegaKillStrike;
        GameMenager.OnCashI -= CashI;
        GameMenager.OnCashII -= CashII;
        GameMenager.OnCashIII -= CashIII;
        GameMenager.OnCash0 -= Cash0;
        GameMenager.OnDefenceI -= DefenceI;
        GameMenager.OnDefenceII -= DefenceII;
    }

    private void enemyKillStrike()
    {
        _killStrikeWindow.SetActive(true);
    }
    private void enemyMegaKillStrike()
    {
        _killMegaStrikeWindow.SetActive(true);
    }
    private void CashI()
    {
        _cashWindowI.SetActive(true);
    }
    private void CashII()
    {
        _cashWindowII.SetActive(true);
    }
    private void CashIII()
    {
        _cashWindowIII.SetActive(true);
    }
    private void Cash0()
    {
        _cashWindow0.SetActive(true);
    }
    private void DefenceI() {
        _defebceWindowI.SetActive(true);
    }
    private void DefenceII()
    {
        _defebceWindowII.SetActive(true);
    }
}
