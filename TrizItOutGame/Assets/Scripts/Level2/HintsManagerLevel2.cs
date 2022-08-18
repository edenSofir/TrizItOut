using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HintsManagerLevel2 : MonoBehaviour
{
    private string m_CurrentHintKey = null;

    public GameObject m_HintWindow;
    public GameObject m_ShowHintBtn;
    public GameObject m_HintWindowText;
    public GameObject m_Inventory;

    private Dictionary<string, string> m_Hints = new Dictionary<string, string>();

    void Start()
    {
        fillHintsData();
    }

    private void fillHintsData()
    {
        m_Hints.Add("Reduction",
            string.Format("Triz Tip:Reduction {0}Try to remove objects if it turns out that they are not required",
            Environment.NewLine));
        m_Hints.Add("Universality",
             string.Format("Maybe the Universality princple is relvent here as well.");
        //m_Hints.Add("Universality",
          //string.Format(".");
    }

    public void OnClickShowHintBtn()
    {
        showHint();
    }

    private void Update()
    {
        findHint();
    }

    private void findHint()
    {
        InventoryManager inventoryManager = m_Inventory.GetComponent<InventoryManager>();

        if(true)
        {

        }
        else
        {
            m_CurrentHintKey = null;
            m_ShowHintBtn.SetActive(true);
        }

        if (m_CurrentHintKey != null)
        {
            m_ShowHintBtn.GetComponent<Image>().color = new Color32(207, 94, 40, 152);
        }
        else
        {
            m_ShowHintBtn.GetComponent<Image>().color = new Color32(56, 56, 56, 152);

        }
    }

    private void showHint()
    {
        if (m_CurrentHintKey != null)
        {
            m_ShowHintBtn.SetActive(false);
            m_HintWindow.SetActive(true);
            m_HintWindowText.SetActive(true);
            m_HintWindowText.GetComponent<TextMeshProUGUI>().text = m_Hints[m_CurrentHintKey];
        }
    }

    public void OnClickCloseHintWindow()
    {
        m_HintWindow.SetActive(false);
        m_ShowHintBtn.SetActive(true);
    }
}
