using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
  
    bool isMute;
public void Mute (){
    isMute = ! isMute;
    AudioListener.volume =  isMute ? 0 : 1;
}
}
