using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set;}

    public AudioSource shootingChannel;

    public AudioSource emptyMagazineSoundRevolver;

    public AudioSource reloadingSoundRevolver;
    public AudioSource reloadingSoundAk47;

    public AudioClip M16Shot;
    public AudioClip P1911Shot;

    private void Awake()
    {   
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    
    }


    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.PistolRevolver:
                shootingChannel.PlayOneShot(P1911Shot);
                break;
            case WeaponModel.AK47:
                shootingChannel.PlayOneShot(M16Shot);
                break;
        
        }
    }

    public void PlayReloadingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.PistolRevolver:
                reloadingSoundRevolver.Play();
                break;
            case WeaponModel.AK47:
                reloadingSoundAk47.Play();
                break;
        
        }
    }


}
