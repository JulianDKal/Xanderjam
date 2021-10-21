using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlassManager : MonoBehaviour
{
    private FMOD.Studio.EventInstance gameMusicInstance;
    private FMOD.Studio.EventInstance wonInstance;
    private FMOD.Studio.EventInstance lossInstance;

    public void GameWonSounds()
    {
        gameMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        gameMusicInstance.release();
        wonInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Victory");
        wonInstance.start();
        wonInstance.release();
    }

    public void GameLostSounds()
    {
        gameMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        gameMusicInstance.release();
        lossInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Loss");
        lossInstance.start();
        lossInstance.release();
    }

    private void Start() {
        gameMusicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Gameplay Music");
        gameMusicInstance.start();
        Game_Manager.onGameOver += GameWonSounds;
    }
}
