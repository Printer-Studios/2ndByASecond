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

    [field: Header("countdown321")]

    [field: SerializeField] public EventReference Countdown321 { get; private set; }

    [field: Header("Banana Marrana")]

    [field: SerializeField] public EventReference Banana { get; private set; }

    [field: Header("Nitro")]

    [field: SerializeField] public EventReference Nitro { get; private set; }

    [field: Header("PresentacioCoche1")]

    [field: SerializeField] public EventReference PresentacioCoche1 { get; private set; }

    [field: Header("PresentacioBebe")]

    [field: SerializeField] public EventReference PresentacioBebe { get; private set; }

    [field: Header("PresentacioBici")]

    [field: SerializeField] public EventReference PresentacioBici { get; private set; }

    [field: Header("PresentacioCoche2")]

    [field: SerializeField] public EventReference PresentacioCoche2 { get; private set; }

    [field: Header("PresentacioWhatsapp")]

    [field: SerializeField] public EventReference PresentacioWhatsapp{ get; private set; }

    [field: Header("Wosh Proba")]

    [field: SerializeField] public EventReference woshProba { get; private set; }

    [field: Header("BackGroundCarretera")]

    [field: SerializeField] public EventReference BackGroundCarretera { get; private set; }
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
