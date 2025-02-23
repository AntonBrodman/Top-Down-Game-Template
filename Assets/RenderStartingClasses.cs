using UnityEngine;
using UnityEngine.UI; // Import UI namespace
using TMPro;
using UnityEngine.SceneManagement;

public class RenderStartingClasses : MonoBehaviour
{
    public StartingClass[] startingClasses;
    public GameObject startingClassCard;
    public Transform startingClassGrid;
    public static string selectedClass;
    void Start()
    {
        foreach (var startingClass in startingClasses)
        {
            AddStartingClassCard(startingClass);
        }
    }

    public void AddStartingClassCard(StartingClass startingClass)
    {
        GameObject newClassCard = Instantiate(startingClassCard, startingClassGrid);
        newClassCard.name = startingClass.name + " Card";

        // Get all TextMeshProUGUI elements and set their values
        TextMeshProUGUI[] textElements = newClassCard.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textElement in textElements)
        {
            switch (textElement.name)
            {
                case "Class Name":
                    textElement.text = startingClass.name;
                    break;
                case "HealthValue":
                    textElement.text = startingClass.Health.ToString();
                    break;
                case "StaminaValue":
                    textElement.text = startingClass.Stamina.ToString();
                    break;
                case "StrenghtValue":
                    textElement.text = startingClass.Strenght.ToString();
                    break;
                case "SkillValue":
                    textElement.text = startingClass.Skill.ToString();
                    break;
                case "ArcaneValue":
                    textElement.text = startingClass.Arcane.ToString();
                    break;
            }
        }

        // Add a Button component if not already present
        Button button = newClassCard.GetComponent<Button>();
        if (button == null)
        {
            button = newClassCard.AddComponent<Button>();
        }

        // Add the click event listener
        button.onClick.AddListener(() => OnCardClicked(startingClass));
    }

    void OnCardClicked(StartingClass clickedClass)
    {
        selectedClass = clickedClass.name;
        LoadGameScene();
    }
    void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
