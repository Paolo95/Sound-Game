using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;
﻿using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    private EventInstance playerFootsteps;

    [SerializeField] private float speed;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        playerFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.playerFootsteps);
    }

    private void Update()
    {
        _characterController.Move(_direction * speed * Time.deltaTime);

        UpdateSound();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    private void UpdateSound()
    {
        if(_input.x != 0 || _input.y != 0)
        {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);
            if(playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                playerFootsteps.start();
            }
        }
        else
            {
                playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
            }
    }
}
