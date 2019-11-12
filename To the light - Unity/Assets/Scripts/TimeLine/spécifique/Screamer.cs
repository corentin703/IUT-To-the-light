using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Image))]
public class Screamer : MonoBehaviour, Interface_TL_Events
{
    public struct ScreamSprite
    {
        public Sprite sprite;
        public bool HasBeenShowed;

        public ScreamSprite(Sprite sprite)
        {
            this.sprite = sprite;
            HasBeenShowed = false;
        }
    }

    [SerializeField]
    private List<Sprite> lSprites = new List<Sprite>();

    // Statique afin d'avoir accès au contenu aux différentes périodes
    private static List<Sprite> m_lSprites;
    private static bool m_isLastSprite = false;

    private CanvasGroup m_canvasGroup;
    private Image m_image;

    public float DebutEventTL = 10;
    public bool Periodique = true;
    public float Periode = 5;
    public float DureeEventTL = 1;
    public float MaxDureeEventTL = 90;

    public void Awake()
    {
        if (m_lSprites == null || m_lSprites.Count == 0)
        {
            if (lSprites.Count == 0)
                throw new NotImplementedException();

            m_lSprites = new List<Sprite>(lSprites);
        }
                
        m_image = this.gameObject.GetComponent<Image>();

        //m_image.enabled = false;

        m_canvasGroup = GetComponent<CanvasGroup>();
        // Correctif pour le bogue où le screamer reste affiché
        m_canvasGroup.alpha = 0f;
    }

    public void stop_TL_Event()
    {
        m_canvasGroup.alpha = 0f;
        //m_image.enabled = false;

        _MGR_Son_Musique.Instance.PlaySound("Heart");

        Destroy(this);
    }

    public float getDuration_TL_Event()
    {
        if (!m_image || m_lSprites.Count == 0)
            throw new NotImplementedException();

        return DureeEventTL;
    }

    public float getStartTime_TL_Event()
    {
        return DebutEventTL;
    }
    public float getStopTime_TL_Event()
    {
        return DebutEventTL + MaxDureeEventTL;
    }

    public bool isPausable_TL_Event()
    {
        return false;
    }
    public bool isPerdiodic_TL_Event(out float period)
    {
        period = Periode;
        return Periodique;
    }

    public bool isRandomizable_TL_Event()
    {
        return false;
    }


    public void pause_TL_Event()
    {
        return;
    }

    public void randomize_TL_Event()
    {
        return;
    }

    public void restart_TL_Event()
    {
        return;
    }

    public void start_TL_Event()
    {
        if (!m_image || m_lSprites.Count == 0) 
            throw new NotImplementedException();
        
        for (int i = 0; i < m_lSprites.Count - 1; ++i)
        {
            if (!m_image.sprite || m_isLastSprite)
            {
                m_image.sprite = m_lSprites[i];
                m_isLastSprite = false;
            }
            else if (m_lSprites[i] == m_image.sprite)
            {
                m_image.sprite = m_lSprites[i + 1];

                if ((i + 2) == m_lSprites.Count)
                    m_isLastSprite = true;

                break;
            }
        }

        m_canvasGroup.alpha = 1f;
        //m_image.enabled = true;
        _MGR_Son_Musique.Instance.PlaySound("Screamer");
    }

    public void TL_ChronoArrete()
    {
        return;
    }

    public void TL_ChronoDemarre()
    {
        return;
    }

    public void TL_ChronoEnPause()
    {
        return;
    }
    public void TL_ChronoReprise()
    {
        return;
    }
}
