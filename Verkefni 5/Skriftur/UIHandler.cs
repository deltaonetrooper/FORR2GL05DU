using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    private VisualElement m_Healthbar; // Tilvísun í heilsustiku í UI
    public static UIHandler instance { get; private set; } // Singleton – veitir aðgang að UIHandler utan frá

    // Breytur fyrir samræðu glugga
    public float displayTime = 4.0f; // Hversu lengi samræðuglugginn birtist
    private VisualElement m_NonPlayerDialogue; // UI-element fyrir NPC samræður
    private float m_TimerDisplay; // Teljari sem heldur utan um hvenær samræðuglugginn á að hverfa

    // Kallað þegar leikhluturinn er hlaðinn (t.d. þegar senan byrjar)
    private void Awake()
    {
        instance = this; // Setur þessa tilvísun sem aðgengilega öðrum
    }

    // Keyrist við ræsingu – eftir að Awake hefur keyrt
    private void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>(); // Sækir UI Document á þessum leikhlut
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar"); // Finnur heilsustikuna með nafni
        SetHealthValue(1.0f); // Byrjar með 100% heilsu

        m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialog"); // Finnur samræðu UI-element
        m_NonPlayerDialogue.style.display = DisplayStyle.None; // Byrjar ósýnilegt
        m_TimerDisplay = -1.0f; // Neikvætt svo það byrjar ekki að telja niður
    }

    // Keyrist á hverjum ramma
    private void Update()
    {
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime; // Lækkar tímann
            if (m_TimerDisplay < 0)
            {
                m_NonPlayerDialogue.style.display = DisplayStyle.None; // Felur samræðugluggann þegar tími er úti
            }
        }
    }

    // Uppfærir breidd heilsustikunnar (í prósentum)
    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }

    // Sýnir samræðugluggann og byrjar tímateljarann
    public void DisplayDialogue()
    {
        m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
        m_TimerDisplay = displayTime;
    }
}
