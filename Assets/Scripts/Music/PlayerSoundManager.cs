using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] RandomSound pickaxeSound;
    [SerializeField] RandomSound tombSound;
    [SerializeField] RandomSound rockFallSound;
    [SerializeField] RandomSound scratchingSound;

    public void PlayPickSound()
    {
        pickaxeSound.PlayRandomSound();
    }

    public void PlayTombFallingSound()
    {
        tombSound.PlayRandomSound();
    }

    public void PlayRockFallSound()
    {
        rockFallSound.PlayRandomSound();
    }

    public void PlayScrachingSound()
    {
        scratchingSound.PlayRandomSound();
    }
}
