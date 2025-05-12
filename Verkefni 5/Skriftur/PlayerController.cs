using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    private VisualElement m_Healthbar; // Heilbrigðisstika (heilsa leikmanns)
    public static UIHandler instance { get; private set; } // Singleton-tilvísun í þennan UIHandler

    // Breytur fyrir samræðu-glugga
    public float displayTime = 4.0f; // Tímalengd sem samræðuglugginn birtist
    private VisualElement m_NonPlayerDialogue; // Samræðuglugginn sjálfur (fyrir NPC)
    private float m_TimerDisplay; // Teljari fyrir birtingartíma samræðuglugga

    // Awake er kallað þegar hluturinn er fyrst hlaðinn (þegar senan byrjar)
    private void Awake()
    {
        instance = this; // Setur instance tilvísun í þennan hlut
    }

    // Start er kallað áður en fyrsta rammauppfærsla á sér stað
    private void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>(); // Nær í UI skjalið
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar"); // Finnur heilbrigðisstikuna
        SetHealthValue(1.0f); // Stillir heilsu á 100%

        m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialog"); // Finnur samræðugluggann
        m_NonPlayerDialogue.style.display = DisplayStyle.None; // Byrjar með gluggann falinn
        m_TimerDisplay = -1.0f; // Ekki tilbúinn til að telja niður ennþá
    }

    // Uppfært á hverjum ramma
    private void Update()
    {
        if (m_TimerDisplay > 0) // Ef glugginn á að birtast
        {
            m_TimerDisplay -= Time.deltaTime; // Telur niður tímann
            if (m_TimerDisplay < 0)
            {
                m_NonPlayerDialogue.style.display = DisplayStyle.None; // Felur gluggann þegar tíminn er búinn
            }
        }
    }

    // Stillir breidd heilsustiku í samræmi við prósentu
    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }

    // Birtir samræðugluggann og endurstillir teljara
    public void DisplayDialogue()
    {
        m_NonPlayerDialogue.style.display = DisplayStyle.Flex; // Sýnir gluggann
        m_TimerDisplay = displayTime; // Stillir tímann sem glugginn birtist
    }
}
