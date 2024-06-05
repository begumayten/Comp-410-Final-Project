using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlText : MonoBehaviour
{
    [SerializeField] public TMP_Text text;
    [SerializeField] private GameObject[] Runes;
    [SerializeField] private float displayDuration = 3f; // Duration to display the text

    void Start()
    {
        // Set indexes for each RuneStone
        for (int i = 0; i < Runes.Length; i++)
        {
            RuneStone runeStone = Runes[i].GetComponent<RuneStone>();
            if (runeStone != null)
            {
                runeStone.SetRuneIndex(i);
            }
            else
            {
                Debug.LogError("RuneStone component not found on GameObject " + Runes[i].name);
            }
        }
    }

    void Update()
    {

    }

    public void UpdateText(int runeIndex)
    {
        switch (runeIndex)
        {
            case 0:
                text.text = "Welcome, traveler. This forest holds the remnants of an ancient realm. Your journey begins here, where the lines between past and present blur. Listen closely to the whispers of the stones; they will guide you.";
                break;
            case 1:
                text.text = "Long ago, these lands were ruled by a noble king who protected his people from the darkness. His kingdom flourished with harmony and light, but shadows lurked at the edges, waiting for their moment.";
                break;
            case 2:
                text.text = "Despite the king's efforts, the darkness grew stronger. A great battle ensued, and the kingdom fell into ruin. The king, in his final moments, cast a spell to seal away the darkness, sacrificing himself to save his people.";
                break;
            case 3:
                text.text = "A hero emerged from the shadows, seeking to restore the kingdom's glory. With unwavering resolve, the hero ventured into the heart of the darkness, but their fate remains unknown. Some say the hero's spirit still wanders these woods, guarding the secrets of the past.";
                break;
            case 4:
                text.text = "You have come far, traveler. The hero's spirit guides you now. The darkness that once threatened this land was not destroyed, only dormant. Your journey is to awaken the light within and dispel the shadows forever. You are the chosen one to complete what the hero began.";
                break;
            case 5:
                text.text = "The time has come. With each step you have taken, the light within you has grown stronger. Now, stand tall and let the light guide you. The kingdom's future rests in your hands. Remember, the darkness can only thrive if we forget the light. Go forth and restore the realm to its former glory.";
                StartCoroutine(DisplayAdditionalTextAfterDelay("Congratulations! You have restored the light and brought peace to the kingdom. Your journey has ended, but the story of the realm will live on through your actions. Thank you for playing.", 5f)); // Display additional text after 5 seconds
                break;
            default:
                text.text = "Unknown Rune";
                break;
        }

        StartCoroutine(ClearTextAfterDelay(displayDuration));
    }

    private IEnumerator DisplayAdditionalTextAfterDelay(string additionalText, float delay)
    {
        yield return new WaitForSeconds(delay);
        text.text = additionalText;
        StartCoroutine(ClearTextAfterDelay(displayDuration)); // Clear the text after displayDuration seconds
    }

    private IEnumerator ClearTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        text.text = ""; // Clear the text
    }

}