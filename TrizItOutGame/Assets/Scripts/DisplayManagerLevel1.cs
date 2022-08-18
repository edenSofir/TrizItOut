using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayManagerLevel1 : MonoBehaviour
{
    public GameObject m_Missions;
    public int m_CurrentWall;
    public int m_PreviousWall;
    public GameObject m_furniture1;
    public GameObject m_interactables1;
    public GameObject m_furniture2;
    public GameObject m_interactables2;
    public GameObject[] UiRenderObject;
    public GameObject m_DarkMode;
    public GameObject m_ComputerCable;
    public Sprite m_TornComputerCableSprite;
    private GameObject m_CanvasOfSafeBoxCode;
    public GameObject m_ComputerCableHolder;
    public GameObject m_FuzeHolder;
    private bool m_FuzeIsSpawned = false;
    public bool m_ComputerCableIsSpawned = false;
    private const string k_BackgroundPath = "Sprites/Level1/Main_Backgrounds/Background";

    public enum State
    {
        normal, zoom, busy
    };

    public State m_CurrentState { get; set; }
    
    public State CurrentState
    {
        get
        {
            return m_CurrentState;
        }
        set
        {
            m_CurrentState = value;
        }
    }

    public int CurrentWall
    {
        get { return m_CurrentWall; }
        set
        {
            if (value == 3)
            {
                m_CurrentWall = 1;
            }
            else if (value == 0)
            {
                m_CurrentWall = 2;
            }
            else
            {
                m_CurrentWall = value;
            }
        }
    }

    void Start()
    {
        m_PreviousWall = 0;
        m_CurrentWall = 1;
        CurrentState = State.normal;
        m_DarkMode.SetActive(false);
        RenderUI();
        StartCoroutine(WaitBeforeDarkMode(2));

        m_ComputerCableHolder.GetComponent<PlaceHolder>().OnPrefabSpawned += OnComputerCableSpawned;
        m_FuzeHolder.GetComponent<PlaceHolder>().OnPrefabSpawned += OnFuzeSpawned;
    }

    public void OnFuzeSpawned()
    {
        m_FuzeIsSpawned = true;
    }

    public void OnComputerCableSpawned()
    {
        m_ComputerCableIsSpawned = true;

        GameObject computerCable = GameObject.Find("/furniture1/Computer_Cable");

        if(computerCable == null)
        {
            Debug.Log("computerCable is null.");
        }
        else
        {
            computerCable.GetComponent<PickUpItem>().OnPickUp += OnComputerCablePickedUp;
        }
    }

    private void OnComputerCablePickedUp()
    {
        m_ComputerCableIsSpawned = false;
    }

    void Update()
    {
        if (m_CurrentWall != m_PreviousWall)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(k_BackgroundPath + CurrentWall.ToString());
        }

        m_PreviousWall = CurrentWall;

        showRelevantPickUpItems();
        showRelevantInteractableItems();

        if (CurrentState == State.normal)
        {
            m_Missions.GetComponent<MissionsManager>().TurnOff();
        }
        else
        {
            m_Missions.SetActive(true);
            string missionName = GetComponent<SpriteRenderer>().sprite.name;
           
            m_Missions.GetComponent<MissionsManager>().ActiveRelevantMission(missionName);
        }

        CheckIfFinishedLevel();
    }

    private void showRelevantInteractableItems()
    {
        if (m_CurrentWall == 1)
        {
            m_interactables2.SetActive(false);
            if (CurrentState == State.normal)
            {
                m_interactables1.SetActive(true);
            }
            else
            {
                m_interactables1.SetActive(false);
            }
        }
        else if (m_CurrentWall == 2)
        {
            m_interactables1.SetActive(false);
            if (CurrentState == State.normal)
            {
                m_interactables2.SetActive(true);
            }
            else
            {
                m_interactables2.SetActive(false);
            }
        }

    }

    private void showRelevantPickUpItems()
    {
        if (m_CurrentWall == 1)
        {
            m_furniture2.SetActive(false);
            if (CurrentState == State.normal)
            {
                m_furniture1.SetActive(true);
            }
            else
            {
                m_furniture1.SetActive(false);
            }
        }

        else if (m_CurrentWall == 2)
        {
            m_furniture1.SetActive(false);
            if (CurrentState == State.normal)
            {
                m_furniture2.SetActive(true);
            }
            else
            {
                m_furniture2.SetActive(false);
            }
        }
    }

    void RenderUI()
    {
        for (int i = 0; i < UiRenderObject.Length; i++)
        {
            UiRenderObject[i].SetActive(false);
        }
    }

    public void ChangeToNormalBackgroundAfterReturnFromZoom()
    {
        CurrentState = DisplayManagerLevel1.State.normal;
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(k_BackgroundPath + CurrentWall.ToString());
    }

    IEnumerator WaitBeforeDarkMode(int sec)
    {
        yield return new WaitForSeconds(sec);
        SoundManager.PlaySound(SoundManager.k_ElectricFallSoundName);
        m_ComputerCable.GetComponent<SpriteRenderer>().sprite = m_TornComputerCableSprite;
        m_DarkMode.SetActive(true);
    }

    public void CheckIfFinishedLevel()
    {
        if(m_FuzeIsSpawned && m_ComputerCableIsSpawned)
        {
            SceneManager.LoadScene("Level2_Scene");
        }
    }
}
