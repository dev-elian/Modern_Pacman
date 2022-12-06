using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] MeshRenderer _rend;
    [SerializeField] Material _eatableMaterial;
    [SerializeField] Material _nonEatableMaterial;

    void Start() {
        GameManager.instance.onGetSpecialCoin += ChangeColor;
    }

    void OnDisable() {
        GameManager.instance.onGetSpecialCoin -= ChangeColor;
    }

    void ChangeColor(bool specialCoinActive){
        if (specialCoinActive){
            _rend.material = _eatableMaterial;
            return;
        }
        _rend.material = _nonEatableMaterial;
    }
}
