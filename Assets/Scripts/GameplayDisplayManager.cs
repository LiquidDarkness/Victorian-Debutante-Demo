using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameplayDisplayManager : MonoBehaviour
{
    public DecisionAnimation decisionAnimation;
    public AfterChoiceAnimation afterChoiceAnimation;
    public Button continueButton;
    public Button afterEndingButton;
    public TextInstantiator textInstantiator;
    public StoryManager storyManager;
    public StoryPivot storyPivot;
    public StoryDisplayer storyDisplayer;
    public ImageTransitioner imageTransitioner;
    public TransitionAnimationAlternative transitionAnimation;
    public MusicSwitcher musicSwitcher;
    public Text continueText;
    public Image continueArrow;
    public CanvasGroup choiceGroup;

    public void Start()
    {
        //imageTransitioner.FirstSprite = storyManager.currentStory.StoryImage;
        transitionAnimation.FirstSprite = storyManager.currentStory.StoryImage;
        continueButton.interactable = false;
        SetEndingButtonVisibility();
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
        choiceGroup.interactable = false;
        continueButton.interactable = true;
        continueText.enabled = true;
        continueArrow.enabled = true;
    }

    private void HandleContinueButtonClicked()
    {
        SetEndingButtonVisibility();
        continueButton.interactable = false;
        continueText.enabled = false;
        continueArrow.enabled = false;
        choiceGroup.interactable = true;
        storyDisplayer.DisplayResponseText(null);
        SteamAchievements.StoriesReadCounter();
        StartCoroutine(SwitchingStoryRoutine(storyManager.currentStory));
    }

    IEnumerator IntroMusicRoutine(float introDuration)
    {
        float musicEndTime = Time.realtimeSinceStartup + introDuration;
        yield return new WaitForSecondsRealtime(introDuration);
    }

    IEnumerator SwitchingStoryRoutine(Story story)
    {
        //imageTransitioner.StartLineAnimation(storyManager.currentStory.StoryImage);
        transitionAnimation.StartChosenAnimationStyle(story.StoryImage);
        if (story.introStoryMusic != null)
        {
            musicSwitcher.SwitchAudio(story.introStoryMusic);
            yield return IntroMusicRoutine(story.introStoryMusic.length);
        }

        musicSwitcher.SwitchAudio(story.storyMusicLoop);
        
    }

    void SetEndingButtonVisibility()
    {
        afterEndingButton.interactable = storyManager.currentStory.name.Contains("ending");
    }
}