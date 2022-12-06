using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Score : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI _tmpro;
    void OnEnable() {
        GameManager.instance.onScoreChange += SetScoreUI;
    }

    void OnDisable() {
        GameManager.instance.onScoreChange -= SetScoreUI;
    }

    void SetScoreUI(int score){
        _tmpro.text = "Score: "+score;
    }
}
