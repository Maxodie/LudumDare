using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] RandomSound pickaxeSound;
    [SerializeField] RandomSound tombSound;

    public void PlayPickSound()
    {
        pickaxeSound.PlayRandomSound();
    }

    public void PlayTombFallingSound()
    {
        tombSound.PlayRandomSound();
    }
}
