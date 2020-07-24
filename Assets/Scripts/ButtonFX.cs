using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
   public AudioSource myFx;
   public AudioClip hoverFX;
   public AudioClip clicFx;
   
   public void HoverSound()
   {
       myFx.PlayOneShot (hoverFX);
   }


   public void ClickSound()
   {
       myFx.PlayOneShot (clicFx);
   }
}