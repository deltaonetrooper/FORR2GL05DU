using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Sér um notendaviðmótið (UI) eins og heilsumæli og samræðu-glugga
public class UIHandler : MonoBehaviour
{
    private VisualElement m_Healthbar; // Vísar í heilsu-stikuna í UI
    public static UIHandler instance { get; private set; } // Singleton til að hafa aðgang að UIHandler hvar sem er

    // Breytur fyrir samræðu-glugga (dialogue UI)
    public float displayTime = 4.0f; // Hversu lengi glugginn er sýnilegur
    private VisualElement m_NonPlayerDialogue; // Vísar í bakgrunn samræðu-gluggans
    private float m_TimerDisplay; // Telur niður tímann sem glugginn er sýnilegur

    // Kallað þegar hluturinn (script) er hlaðinn, áður en leikurinn byrjar
    private void Awake()
    {
        instance = this; // Setur sjálfan sig sem eina tilvikið af UIHandler
    }

    // Kallað áður en fyrsta ramman (frame) keyrir
    private void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();

        // Nær í UI element sem heitir "HealthBar"
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1.0f); // Byrjar með fulla heilsu

        // Nær í samræðu-gluggann ("Background")
        m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("Background");
        m_NonPlayerDialogue.style.display = DisplayStyle.None; // Byrjar ósýnilegur
        m_TimerDisplay = -1.0f; // Tíminn í neikvætt svo hann byrji ekki
    }

    // Uppfært í hverri ramma
    private void Update()
    {
        // Ef tíminn er yfir 0, teljum við niður
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;
            if (m_TimerDisplay < 0)
            {
                // Fela samræðu-gluggann þegar tíminn rennur út
                m_NonPlayerDialogue.style.display = DisplayStyle.None;
            }
        }
    }

    // Uppfærir breidd heilsu-stikunnar samkvæmt hlutfalli (0.0 - 1.0)
    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }

    // Sýnir samræðu-gluggann og endurstillir tímann
    public void DisplayDialogue()
    {
        m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
        m_TimerDisplay = displayTime;
    }
}
