using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Data.Common;
using System.Threading.Tasks;

public class SaveManager : MonoBehaviour
{
    private string _filePath;
    private const string _saveName = "/SavefileForGTA6.json";

    public SaveFile _currentSave {get; private set;}

    private EventBus _bus;

    private void Awake()
    {
        _filePath = Application.persistentDataPath + _saveName;

        _currentSave = LOadGameData();


            for (int i = 0; i < 10; i++)
            {
                var stats = new CreatureStats();
                stats._creatureCoins = i;
                _currentSave._playerStats.Add(stats);
            }

        SaveDataMEthod(_currentSave);
    }

    public void Initialize(EventBus bus)
    {
        _bus = bus;
    }


    private void SaveDataMEthod(SaveFile data)
    {
        var json = JsonUtility.ToJson(data, true);

        using (var writer = new StreamWriter(_filePath))
        {
            writer.WriteLine(json);
        }
        Debug.Log("finished saving");
    }

    private SaveFile LOadGameData()
    {
        var data = new SaveFile();
        if (File.Exists(_filePath))
        {
            Debug.Log("data found");
            using (var reader = new StreamReader(_filePath))
            {
                var json = reader.ReadToEnd();
                
                data = JsonUtility.FromJson<SaveFile>(json);
            }
        }
        else
        {
            Debug.LogError("data not found");
        }
        return data;
    }


}
