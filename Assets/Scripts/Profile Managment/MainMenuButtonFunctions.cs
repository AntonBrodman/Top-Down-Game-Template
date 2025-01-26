using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class MainMenuButtonFunctions : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject characterCreation;
    public GameObject profileSelection;
    public GameObject profileCard;
    public GameObject profileGrid;
    public static int selectedProfileId;
    //[SerializeField]
    //public ProfileInformation selectedProfile;

    //public ProfileInformation selectedProfile;
    public void LoadGame()
    {
        if(selectedProfileId != 0)
        {
            SceneManager.LoadScene("GameScene");

        }
    }
    public void SelectProfile()
    {
        print(gameObject);


    }
    public void NewProfile()
    {
        print("Create new profile");
        titleScreen.SetActive(false);
        characterCreation.SetActive(true);

    }
    public void ExitGame()
    {
        print("Exiting Game");
        Application.Quit();
    }
    public void Return()
    {
        titleScreen.SetActive(true);
        characterCreation.SetActive(false);
    }
    public void ReturnFromSelection()
    {
        titleScreen.SetActive(true);
        profileSelection.SetActive(false);
    }
    public void RenderProfiles()
    {
        titleScreen.SetActive(false);
        profileSelection.SetActive(true);
        string folderPath = Path.Combine(Application.dataPath, "Profiles");
        string[] files = Directory.GetFiles(folderPath, "*.json");

        foreach (string file in files)
        {
            // Read the content of each file
            string json = File.ReadAllText(file);
            AddProfilePanel(json);

            //Debug.Log($"Contents of {file}: {json}");

        }
    }
    public void AddProfilePanel(string profileInfo)
    {
        //print("added Profile panel");
        GameObject newPanel = Instantiate(profileCard, profileGrid.transform);
        TextMeshProUGUI panelText = newPanel.GetComponentInChildren<TextMeshProUGUI>();
        ProfileInformation g = JsonUtility.FromJson<ProfileInformation>(profileInfo);
        newPanel.name = g.id.ToString();

        if (panelText != null)
        {
            panelText.text = g.profileName;
        }
    }
    public void setProfileId(int profileId)
    {
        selectedProfileId = profileId;
    }
}
