using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] RandomSound pickaxeSound;

    public void PlayPickSound()
    {
        pickaxeSound.PlayRandomSound();
    }
}
