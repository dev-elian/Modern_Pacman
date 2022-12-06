using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsDetectable : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        GameManager.instance.AddScore();
        if (other.tag == Tags.SpecialCoin)
            GameManager.instance.SpecialCoinGot();
    }
}
