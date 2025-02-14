using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ProfileManager : MonoBehaviour
{
    public GameObject Player;

    public ProfileInformation currentProfile;
    ProfileInformation profile = new ProfileInformation();
    public int selectedId;
    public PlayerStats stats;
    public int maxProfiles;
    public PlayerHealth health;

    void Start()
    {

        selectedId = MainMenuButtonFunctions.selectedProfileId;

        //profile.profileName = "Player1";

        print(selectedId);
        if(selectedId != 0)
        {
            LoadData(selectedId);

        }
        //Player = GameObject.FindGameObjectWithTag("Player");
        //profileInformation = ProfileInformation.Instance;
    }

    public void SaveData()
    {
        if (selectedId != 0)
        {

            currentProfile.lastLocation = Player.transform.position;


            string folderPath = Path.Combine(Application.dataPath, "Profiles");
            string[] files = Directory.GetFiles(folderPath, "*.json");
            string json = File.ReadAllText(files[selectedId - 1]);
            string filePath = files[selectedId - 1];

            //rewrite saved data


            profile = JsonUtility.FromJson<ProfileInformation>(json);
            print(health.health);
            profile.currentHealth = health.health;
            profile.lastLocation = Player.transform.position;
            print(profile.id);
            string updatedJson = JsonUtility.ToJson(profile, true);

            // Save back to the file
            File.WriteAllText(filePath, updatedJson);
        }

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
        print(currentProfile.lastLocation);
        print("current health: "+currentProfile.currentHealth);
        Player.transform.position = currentProfile.lastLocation;
        stats.Health = currentProfile.health;
        health.health = currentProfile.currentHealth;
        stats.Stamina = currentProfile.stamina;
        // load to heatlh, stamina
        // load position of player
        // load inventory lists to item holder
    }
    public void AvailebleId()
    {
        Debug.Log("return availeble id");
    }
}
