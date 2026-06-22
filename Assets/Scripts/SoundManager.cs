using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _UIbuttonSound;

    private EventBus BUS;


    public void Initialize(EventBus bus)
    {
        BUS = bus;
        BUS.OnButtonPressed += OnButtonPressed;
    }

    private void OnButtonPressed(ButtonActions a)
    {
        _UIbuttonSound.PlayOneShot(_UIbuttonSound.clip);
    }
}
