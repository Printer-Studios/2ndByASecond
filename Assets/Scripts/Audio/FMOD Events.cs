using UnityEngine;
using FMODUnity;
public class FMODEvents : MonoBehaviour
{

    [field: Header("Musica Menu")]

    [field: SerializeField] public EventReference MusicaMenu { get; private set; }

    [field: Header("Musica Carrera")]

    [field: SerializeField] public EventReference MusicaCarrera { get; private set; }

    [field: Header("Musica Derrota")]

    [field: SerializeField] public EventReference MusicaDerrota { get; private set; }

    [field: Header("Musica Victoria")]

    [field: SerializeField] public EventReference MusicaVictoria { get; private set; }

    [field: Header("Wosh Proba")]

    [field: SerializeField] public EventReference woshProba { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static FMODEvents instance { get; private set; }

    public void Awake()
    {
        if (instance == null)
        {
            Debug.LogError("Found more than one FMODEvents in the scene.");
        }
        instance = this;
    }

}
