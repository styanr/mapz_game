using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    private UIDocument _uiDocument;
    private Button _playButton;
    private Button _optionsButton;
    private Button _quitButton;
    private Button _saveButton;
    private Slider _volumeSlider;
    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        _playButton = _uiDocument.rootVisualElement.Q<Button>("PlayButton");
        _optionsButton = _uiDocument.rootVisualElement.Q<Button>("OptionsButton");
        _quitButton = _uiDocument.rootVisualElement.Q<Button>("QuitButton");
        _saveButton = _uiDocument.rootVisualElement.Q<Button>("SaveButton");
        _volumeSlider = _uiDocument.rootVisualElement.Q<Slider>("VolumeSlider");
        
        _playButton.clicked += OnPlayButtonClicked;
        _optionsButton.clicked += OnOptionsButtonClicked;
        _quitButton.clicked += OnQuitButtonClicked;
        _saveButton.clicked += OnSaveButtonClicked;
    }
    
    private void Start()
    {
        AudioManager.Instance.SetVolume(0.1f);
        AudioManager.Instance.PlayMusic("MainMenu");
    }
    
    public void OnPlayButtonClicked()
    {
        AudioManager.Instance.Pause();
        SceneManager.LoadScene("Game");
        AudioManager.Instance.PlayMusic("undertale");
    }
    
    public void OnOptionsButtonClicked()
    {
        _uiDocument.rootVisualElement.Q<VisualElement>("MainMenuButtons").style.display = DisplayStyle.None;
        _uiDocument.rootVisualElement.Q<VisualElement>("OptionsMenuButtons").style.display = DisplayStyle.Flex;
        _volumeSlider.value = AudioManager.Instance.GetVolume();
    }

    public void OnSaveButtonClicked()
    {
        float volume = _volumeSlider.value;
        AudioManager.Instance.SetVolume(volume);
        _uiDocument.rootVisualElement.Q<VisualElement>("MainMenuButtons").style.display = DisplayStyle.Flex;
        _uiDocument.rootVisualElement.Q<VisualElement>("OptionsMenuButtons").style.display = DisplayStyle.None;
    }
    public void OnQuitButtonClicked()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
}
