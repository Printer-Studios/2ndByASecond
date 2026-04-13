using UnityEngine;

public class SelectorManager : MonoBehaviour
{
    public void Select(int index)
    {
        PlayerPrefs.SetInt("PlayerSprite", index);
    }
}
