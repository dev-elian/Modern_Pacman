using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInput playerInput;
    InputMaster controls;

    [SerializeField] float _speed=5;
    [SerializeField] LayerMask layerMask;

    Vector3 direction = Vector3.zero;
    Vector3 nextDirection;
    Rigidbody _rig;

    void Awake() {
        _rig = GetComponent<Rigidbody>();
    }

    void OnEnable() {
        controls = new InputMaster();
        controls.Player.Movement.performed += val => Move(val.ReadValue<Vector2>());
        controls.Enable();
    }
    
    void OnDisable() {
        controls.Disable();
    }

    void Move(Vector2 direction){
        nextDirection = new Vector3(direction.x, 0, direction.y);
    }

    void Update(){
         RaycastHit hit;
        if (Physics.BoxCast(transform.position, Vector3.one*0.25f,  nextDirection, out hit, transform.rotation,1.5f, layerMask)){
            Debug.Log("xd"+hit.collider.gameObject.name);
            return;
        }
        direction = nextDirection;
    }

    void FixedUpdate() {
        Vector3 position = _rig.position;
        Vector3 traslation = direction * _speed * Time.fixedDeltaTime;
        _rig.MovePosition(position + traslation);
    }


}
