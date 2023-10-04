using Game;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.InputSystem;

public class AnimationWait : CustomYieldInstruction
{
    private Animation a;

    public AnimationWait(Animation a)
    {
        this.a = a;

        if (a.clip.isLooping) throw new System.Exception();

        a.Play();
    }

    public override bool keepWaiting => a.isPlaying;
}

public static class AnimationExtension
{
    public static AnimationWait PlayAndWaitCompletion(this Animation @this)
        => new AnimationWait(@this);
}



public class PlayerBrain : MonoBehaviour
{
    [SerializeField, BoxGroup("Dependencies")] EntityMovement _movement;
    [SerializeField, BoxGroup("Dependencies")] PlayerController _playerController;

    [SerializeField, BoxGroup("Input")] InputActionProperty _moveInput;
    [SerializeField, BoxGroup("Input")] InputActionProperty _attackInput;
    [SerializeField, BoxGroup("Input")] InputActionProperty _dashInput;
    [SerializeField, BoxGroup("Input")] InputActionProperty _runInput;


    private void Start()
    {
        // Move
        _moveInput.action.started += UpdateMove;
        _moveInput.action.performed += UpdateMove;
        _moveInput.action.canceled += StopMove;
        // Attack
        //_attackInput.action.started += Attack;
        //Dash
        _dashInput.action.performed += EnterDash;
        _runInput.action.started += UpdateRun;
        _runInput.action.performed += UpdateRun;
        _runInput.action.canceled += StopRun;
    }




    void run()
    {
        var speedbase = 10;
        var armurespeed = 1.3;
        var coffeefactor = 1.2f;


        var s = speedbase * armurespeed * coffeefactor;
    }



    Coroutine _maCoroutine;

    

    public void RunCoucou()
    {
        if (_maCoroutine != null) return;

        int i = 10;
        _maCoroutine = StartCoroutine(coucouRoutine());
        IEnumerator coucouRoutine()
        {
            Animation a = GetComponent<Animation>();
            yield return new AnimationWait(a);
            yield return a.PlayAndWaitCompletion();

            var wait = new WaitForSeconds(10f);
            i++;
            yield return wait;
            i++;
            yield return wait;
            i++;
            yield return wait;

            _maCoroutine = null;
            yield break;
        }
    }

    private void OnDestroy()
    {
        // Move
        _moveInput.action.started -= UpdateMove;
        _moveInput.action.performed -= UpdateMove;
        _moveInput.action.canceled -= StopMove;
        _dashInput.action.performed -= EnterDash;
        _runInput.action.started -= UpdateRun;
        _runInput.action.performed -= UpdateRun;
        _runInput.action.canceled -= StopRun;
    }


    private void UpdateMove(InputAction.CallbackContext obj)
    {
        //_playerController.InputMoving = obj.ReadValue<Vector2>() != Vector2.zero ? true : false;
        if (!_movement.CanMove) return;

        _playerController.IsMoving = true;

        _playerController.Move = obj.ReadValue<Vector2>();
        //_movement.Move(_playerController.Move);
    }
    private void StopMove(InputAction.CallbackContext obj)
    {
        //_movement.Move(Vector2.zero);
        _playerController.IsMoving = false;
    }

    private void EnterDash(InputAction.CallbackContext obj)
    {
        //_movement.Move(Vector2.zero);
        if (!_playerController.CanDash) return;
        _playerController.IsMoving = false;
        _playerController.StateMachine.SwitchState(_playerController.DashState);
    }

    private void UpdateRun(InputAction.CallbackContext obj)
    {
        if (!_movement.CanMove || !_playerController.IsMoving) return;
        _playerController.StateMachine.SwitchState(_playerController.RunState);
    }
    private void StopRun(InputAction.CallbackContext obj)
    {
        if (_playerController.CurrentState == _playerController.DashState) return;
        _playerController.StateMachine.SwitchState(_playerController.WalkState);
    }
}
