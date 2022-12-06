using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}

    [SerializeField] float _timeForSpecialCoin = 10;
    public float _timerSpecialCoin = 10;//**
    int _score=0;
    bool _canEatGhost = false;

    public int score {get=>_score;}
    public bool canEatGhost {get => _canEatGhost;}

    public Action<int> onScoreChange;
    public Action<bool> onGetSpecialCoin;

    void Awake() {
        instance  = this;
    }

    public void StartGame(){
        _score =0;
    }

    public void AddScore(){
        _score++;
        if (onScoreChange != null)
            onScoreChange(score);
    }

    public void SpecialCoinGot(){
        _timerSpecialCoin = _timeForSpecialCoin;
        if (!canEatGhost)
            StartCoroutine(EatGhostEnabled());
    }
    IEnumerator EatGhostEnabled(){
        _canEatGhost = true;
        if (onGetSpecialCoin != null)
            onGetSpecialCoin(_canEatGhost);
        while (_timerSpecialCoin>0){
            _timeForSpecialCoin-=0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        _canEatGhost = false;
        if (onGetSpecialCoin != null)
            onGetSpecialCoin(_canEatGhost);
    }
}
