using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommunicationManagerLevel2 : MonoBehaviour
{
    public GameObject m_CommunicationWindow;
    public GameObject m_CommunicationText;
    public TextWriter m_TextWriter;

    void Start()
    {
        GameObject.Find("Razers_Zoom").GetComponent<FanRazersManager>().RazersClickedAndStillSpinning += OnRazersClickedAndStillSpinning;
        GameObject.Find("Broken_Fan").GetComponent<BrokenFanManager>().BrokenFanClickedWithoutScrews += OnBrokenFanClickedWithoutScrews;
    }

    private void OnBrokenFanClickedWithoutScrews()
    {
        ShowMsg("You need screws to hang the fan.");
    }

    private void OnRazersClickedAndStillSpinning()
    {
        ShowMsg("You can't take the note without stopping the fan.");
    }

    public void ShowMsg(string i_Msg)
    {
        StartCoroutine(ShowMsgEnumerator(i_Msg));
    }

    IEnumerator ShowMsgEnumerator(string i_Msg)
    {
        m_CommunicationWindow.SetActive(true);
        m_CommunicationText.SetActive(true);
        m_TextWriter.AddWriter(m_CommunicationText.GetComponent<TextMeshProUGUI>(), i_Msg, 0.05f);
        yield return new WaitForSeconds(4);
        m_CommunicationWindow.SetActive(false);
        m_CommunicationText.SetActive(false);
        m_CommunicationText.GetComponent<TextMeshProUGUI>().text = string.Empty;
    }
}
