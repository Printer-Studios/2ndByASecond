using UnityEngine;

public class CarChooser : MonoBehaviour
{
    public void ChooseSprite(int carNum)
    {
        if (carNum == 0)
        {
            AudioManager.instance.PlayerOneShot(FMODEvents.instance.PresentacioCoche2, this.transform.position);
        }
        else if (carNum == 1)
        {
            AudioManager.instance.PlayerOneShot(FMODEvents.instance.PresentacioBebe, this.transform.position);
        }
        else if (carNum == 2)
        {
            AudioManager.instance.PlayerOneShot(FMODEvents.instance.PresentacioBici, this.transform.position);
        }
        else if (carNum == 3)
        {
            AudioManager.instance.PlayerOneShot(FMODEvents.instance.PresentacioCoche1, this.transform.position);
        }
        else if (carNum == 4)
        {
            AudioManager.instance.PlayerOneShot(FMODEvents.instance.PresentacioWhatsapp, this.transform.position);
        }
            PlayerPrefs.SetInt("PlayerSprite", carNum);
    }
}
