using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


public class CreateProfile : MonoBehaviour
{
    public TMP_InputField inputField;
    public ProfilePreset preset;

    private void Start()
    {
        GameObject inputObject = GameObject.Find("Profile Name");

        inputField = inputObject.GetComponent<TMP_InputField>();



    }

    public void CrateProfileClass()
    {
        if (inputField.text == string.Empty)
        {
            Debug.Log("Missing Name");

        }
        else
        {
            ProfileInformation profile = new ProfileInformation();
            profile.profileName = inputField.text;
            //profile.id;
            profile.health = preset.health;
            profile.stamina = preset.stamina;
            profile.strength = preset.strength;
            string folderPath = Path.Combine(Application.dataPath, "Profiles");
            string filePath = Path.Combine(folderPath, $"{profile.profileName}.json");
            int fileCount = 0;

            Debug.Log(fileCount);//amount of files

            string[] files = Directory.GetFiles(folderPath, "*.json");

            foreach (string file in files)
            {
                fileCount++;
                print(file);
            }
            profile.id = fileCount + 1;
            print(fileCount);
            // recalculate all ids

            string json = JsonUtility.ToJson(profile);


            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(json);
            }


        }

    }
    public void DeleteClass()
    {

    }
}
