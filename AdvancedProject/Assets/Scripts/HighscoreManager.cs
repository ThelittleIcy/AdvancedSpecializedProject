using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    private static HighscoreManager _instance;
    public static HighscoreManager Instance { get => _instance;}

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        PlayerPrefs.GetInt("PlayerWins", m_playerWinCount.Value);
        PlayerPrefs.GetInt("KIWins", m_KIWinCount.Value);

        m_playerText.text = m_playerWinCount.Value.ToString();
        m_KIText.text = m_KIWinCount.Value.ToString();
    }

    [SerializeField]
    private ScriptableInt m_playerWinCount;
    [SerializeField]
    private ScriptableInt m_KIWinCount;

    [SerializeField]
    private TMP_Text m_playerText;
    [SerializeField]
    private TMP_Text m_KIText;
    [ContextMenu("PlayerWon")]
    public void AddPlayerWin()
    {
        m_playerWinCount.Value++;
        PlayerPrefs.SetInt("PlayerWins", m_playerWinCount.Value);
        m_playerText.text = m_playerWinCount.Value.ToString();
    }
    [ContextMenu("KIWon")]
    public void AddKIWin()
    {
        m_KIWinCount.Value++;
        PlayerPrefs.SetInt("KIWins", m_KIWinCount.Value);
        m_KIText.text = m_KIWinCount.Value.ToString();
    }

}
