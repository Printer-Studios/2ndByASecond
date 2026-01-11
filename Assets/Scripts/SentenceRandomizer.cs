using TMPro;
using UnityEngine;

public class SentenceRandomizer : MonoBehaviour
{
    public string[] sentences;
    public TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = sentences[Random.Range(0, sentences.Length)];
    }
}
