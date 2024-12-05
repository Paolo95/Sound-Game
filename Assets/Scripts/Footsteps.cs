using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Footsteps : MonoBehaviour
{
    public AudioSource footsteps;

    [SerializeField]
    InputManager inputManager;
    void Awake()
    {
    
    }

    void Update()
    {
      
        if(inputManager.playerInput.OnFoot.Movement.ReadValue<Vector2>().x !=0 || inputManager.playerInput.OnFoot.Movement.ReadValue<Vector2>().y !=0)
        {
            footsteps.enabled = true;

        }else
        {
            footsteps.enabled = false;
        }
    }
}
