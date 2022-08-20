using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip s_ButtonSound, s_WorngPasswordSound,
                            s_CorrectPasswordSound, s_SwitchSound,
                            s_SpraySound, s_DoorOpenSound,
                            s_TakeItemSound, s_DrawerSound,
                            s_KattleBoilSound, s_MoveBigPotSound,
                            s_ElectricFallSound, s_PiggyBankBreakSound,
                            s_ScrewOpenSound, s_QuizCorrectAnswerSound, s_QuizWrongAnswerSound;

    public static AudioSource audioSource;

    public const string k_ButtonSoundName = "buttonSound";
    public const string k_WorngPasswordSoundName = "worngPasswordSound";
    public const string k_CorrectPasswordSoundName = "correctPasswordSound";
    public const string k_SwitchSoundName = "switchSound";
    public const string k_SpraySoundName = "spraySound";
    public const string k_DoorOpenSoundName = "doorOpenSound";
    public const string k_TakeItemSoundName = "takeItemSound";
    public const string k_DrawerSoundName = "drawerSound";
    public const string k_KattleBoilSoundName = "kattleBoilSound";
    public const string k_MoveBigPotSoundName = "moveBigPotSound";
    public const string k_ElectricFallSoundName = "electricFallSound";
    public const string k_PiggyBankBreakSoundName = "piggyBankBreakSound";
    public const string k_ScrewOpenSoundName = "screwOpenSound";
    public const string k_QuizCorrectAnswerSoundName = "quizCorrectAnswerSound";
    public const string k_QuizWrongAnswerSoundName = "quizWrongAnswerSound";

    public static readonly string sr_SoundPath = "Sounds/";

    public static bool s_IsMuted = false;

    void Start()
    {
        s_ButtonSound = Resources.Load<AudioClip>(sr_SoundPath + k_ButtonSoundName);
        s_WorngPasswordSound = Resources.Load<AudioClip>(sr_SoundPath + k_WorngPasswordSoundName);
        s_CorrectPasswordSound = Resources.Load<AudioClip>(sr_SoundPath + k_CorrectPasswordSoundName);
        s_SwitchSound = Resources.Load<AudioClip>(sr_SoundPath + k_SwitchSoundName);
        s_SpraySound = Resources.Load<AudioClip>(sr_SoundPath + k_SpraySoundName);
        s_DoorOpenSound = Resources.Load<AudioClip>(sr_SoundPath + k_DoorOpenSoundName);
        s_TakeItemSound = Resources.Load<AudioClip>(sr_SoundPath + k_TakeItemSoundName);
        s_DrawerSound = Resources.Load<AudioClip>(sr_SoundPath + k_DrawerSoundName);
        s_KattleBoilSound = Resources.Load<AudioClip>(sr_SoundPath + k_KattleBoilSoundName);
        s_MoveBigPotSound = Resources.Load<AudioClip>(sr_SoundPath + k_MoveBigPotSoundName);
        s_ElectricFallSound = Resources.Load<AudioClip>(sr_SoundPath + k_ElectricFallSoundName);
        s_PiggyBankBreakSound = Resources.Load<AudioClip>(sr_SoundPath + k_PiggyBankBreakSoundName);
        s_ScrewOpenSound = Resources.Load<AudioClip>(sr_SoundPath + k_ScrewOpenSoundName);

        s_QuizCorrectAnswerSound = Resources.Load<AudioClip>(sr_SoundPath + k_QuizCorrectAnswerSoundName);
        s_QuizWrongAnswerSound = Resources.Load<AudioClip>(sr_SoundPath + k_QuizWrongAnswerSoundName);

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string i_Clip)
    {
        if(!s_IsMuted)
        {
            switch (i_Clip)
            {
                case k_ButtonSoundName:
                    {
                        audioSource.PlayOneShot(s_ButtonSound);
                        break;
                    }
                case k_WorngPasswordSoundName:
                    {
                        audioSource.PlayOneShot(s_WorngPasswordSound);
                        break;
                    }
                case k_CorrectPasswordSoundName:
                    {
                        audioSource.PlayOneShot(s_CorrectPasswordSound);
                        break;
                    }
                case k_SwitchSoundName:
                    {
                        audioSource.PlayOneShot(s_SwitchSound);
                        break;
                    }
                case k_SpraySoundName:
                    {
                        audioSource.PlayOneShot(s_SpraySound);
                        break;
                    }
                case k_DoorOpenSoundName:
                    {
                        audioSource.PlayOneShot(s_DoorOpenSound);
                        break;
                    }
                case k_TakeItemSoundName:
                    {
                        audioSource.PlayOneShot(s_TakeItemSound);
                        break;
                    }
                case k_DrawerSoundName:
                    {
                        audioSource.PlayOneShot(s_DrawerSound);
                        break;
                    }
                case k_KattleBoilSoundName:
                    {
                        audioSource.PlayOneShot(s_KattleBoilSound);
                        break;
                    }
                case k_MoveBigPotSoundName:
                    {
                        audioSource.PlayOneShot(s_MoveBigPotSound);
                        break;
                    }
                case k_ElectricFallSoundName:
                    {
                        audioSource.PlayOneShot(s_ElectricFallSound);
                        break;
                    }
                case k_PiggyBankBreakSoundName:
                    {
                        audioSource.PlayOneShot(s_PiggyBankBreakSound);
                        break;
                    }
                case k_ScrewOpenSoundName:
                    {
                        audioSource.PlayOneShot(s_ScrewOpenSound);
                        break;
                    }
                case k_QuizCorrectAnswerSoundName:
                    {
                        audioSource.PlayOneShot(s_QuizCorrectAnswerSound);
                        break;
                    }
                case k_QuizWrongAnswerSoundName:
                    {
                        audioSource.PlayOneShot(s_QuizWrongAnswerSound);
                        break;
                    }
            }
        }
    }
}
