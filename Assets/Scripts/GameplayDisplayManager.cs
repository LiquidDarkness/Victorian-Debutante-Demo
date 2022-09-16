using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

// TODO: najprawdopodobniej powinien wywp³ywaæ te¿ endingi.
public class GameplayDisplayManager : MonoBehaviour
{
    public DecisionAnimation decisionAnimation;
    public AfterChoiceAnimation afterChoiceAnimation;
    public Button continueButton;
    public TextInstantiator textInstantiator;
    public StoryManager storyManager;
    public StoryPivot storyPivot;
    public StoryDisplayer storyDisplayer;
    public ImageTransitioner imageTransitioner;
    public MusicSwitcher musicSwitcher;
    public Text continueText;
    public Image continueArrow;

    public void Start()
    {
        imageTransitioner.FirstSprite = storyManager.currentStory.StoryImage;
        continueButton.interactable = false;
        continueText.enabled = false;
        continueArrow.enabled = false;
        foreach (var choiceButton in textInstantiator.buttons)
        {
            choiceButton.OnChosen += HandleChoiceMade;
        }
        continueButton.onClick.AddListener(HandleContinueButtonClicked);
        storyPivot.Init();
    }
    public void HandleChoiceMade(int index)
    {
        List<Story.PointsData> choiceEndingsData = storyManager.currentStory.pivotsData[index].pointsData;
        foreach (var item in choiceEndingsData)
        {
            storyPivot.AddEndingPoints(item.points, item.story);
        }
        decisionAnimation.ChooseDecision(index);
        afterChoiceAnimation.PerformAnimation();
        storyDisplayer.DisplayResponseText(storyManager.currentStory.GetResult(index));
        continueButton.interactable = true;
        continueText.enabled = true;
        continueArrow.enabled = true;
    }

    private void HandleContinueButtonClicked()
    {
        continueButton.interactable = false;
        continueText.enabled = false;
        continueArrow.enabled = false;
        storyDisplayer.DisplayResponseText(null);
        StartCoroutine(SwitchingStoryRoutine(storyManager.currentStory));
    }

    IEnumerator IntroMusicRoutine(float introDuration)
    {
        float musicEndTime = Time.realtimeSinceStartup + introDuration;
        yield return new WaitForSecondsRealtime(introDuration);
    }

    IEnumerator SwitchingStoryRoutine(Story story)
    {
        imageTransitioner.StartLineAnimation(storyManager.currentStory.StoryImage);
        if (storyManager.currentStory.introStoryMusic != null)
        {
            musicSwitcher.SwitchAudio(story.introStoryMusic);
            yield return IntroMusicRoutine(story.introStoryMusic.length);
        }

        musicSwitcher.SwitchAudio(story.storyMusicLoop);
        
    }
}

// TODO: responseLoaded bool doesn't do the job: the button is still interactable when it shouldn't be.
// To, co siê dzieje na scenie potrzebuje swojej klasy, która bêdzie tym wszystkim zarz¹dzaæ (GameplayDisplayManager, AnimationManager, ???)
// Dziêki temu, bêdzie mo¿na wo³aæ rownie¿ SetupForDisplay i RestoreDecisions z poziomu kodu.
// TODO: disabln¹æ buttonek do przechodzenia do nastêpnej story do momentu podjêcia decyzji (do klasy wy¿ej)