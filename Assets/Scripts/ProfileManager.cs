using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ProfileManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public ProfileInformation currentProfile;
    ProfileInformation profile = new ProfileInformation();
    public int selectedId;
    public PlayerStats stats;

    void Start()
    {
        selectedId = MainMenuButtonFunctions.selectedProfileId;

        //profile.profileName = "Player1";

        print(selectedId);
        if(selectedId != 0)
        {
            LoadData(selectedId);

        }
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //profileInformation = ProfileInformation.Instance;
    }

    public void SaveData()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadData(int profileId)
    {
        string folderPath = Path.Combine(Application.dataPath, "Profiles");

        string[] files = Directory.GetFiles(folderPath, "*.json");
        //ProfileInformation g = JsonUtility.FromJson<ProfileInformation>(files[profileId - 1]);
        // directory
        

    string json = File.ReadAllText(files[profileId - 1]);
        profile = JsonUtility.FromJson<ProfileInformation>(json);
        currentProfile = profile;
        print(currentProfile.health);
        stats.Health = currentProfile.health;
        stats.Stamina = currentProfile.stamina;
        // load to heatlh, stamina
        // load position of player
        // load inventory lists to item holder
    }
    public void UptadeData()
    {
        // update stats on leveling up ...
    }
}
