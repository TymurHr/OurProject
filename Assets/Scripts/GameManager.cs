using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public EventBus ACTIONBUS {get; private set;}

    [SerializeField] private SaveManager SaveMen;
    [SerializeField] private SoundManager SOUNDMAN;


    [SerializeField] private WEaponCatalog _catalog;
    public WEaponCatalog GetWEaponCatalog => _catalog;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
        Instance = this;

        ACTIONBUS =  new EventBus();

        SOUNDMAN.Initialize(ACTIONBUS);
 

        ACTIONBUS.OnButtonPressed += LoadGameState;

        SceneManager.LoadScene(SceneConst.MainMenuScene);
    }


    private void LoadGameState(ButtonActions pressedButton)
    {
        switch(pressedButton)
        {
            case ButtonActions.Start:
                SceneManager.LoadScene(SceneConst.GameScene);
                break;
            case ButtonActions.MainMenu:
                SceneManager.LoadScene(SceneConst.MainMenuScene);
                break;
            case ButtonActions.Exit:
                Application.Quit();
                break;
            
            default:
                return;
        }
    }


    
}
