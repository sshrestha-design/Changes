﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
      public CharacterController2D controller;

        public float runSpeed = 40f;

        float horizontalMove = 0f;
        bool jump = false;
        bool crouch = false;

         // Update is called once per frame
         void Update () {

                 horizontalMove =  SimpleInput.GetAxisRaw("Horizontal") * runSpeed;

                 if (SimpleInput.GetButtonDown("Jump"))
                 {
                       jump = true;
                 }
                 
                 if (SimpleInput.GetButtonDown("Crouch"))
                 {
                       crouch = true;
                 } else if (SimpleInput.GetButtonUp("Crouch"))
                 {
 crouch = false;
                 }

          }
          
          void FixedUpdate ()
          {
                   // Move our character
                   controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
                   jump = false;
          }
    
}
