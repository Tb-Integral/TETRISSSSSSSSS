using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int _score = 0;
    [SerializeField] TextMeshProUGUI _text;
    public void new_text(int digit)
    {
        _score += digit;
        _text.text = "Score: \n" + _score.ToString();
    }
}
