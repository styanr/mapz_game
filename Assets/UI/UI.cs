using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    VisualElement root;
    private Label ScoreLabel;
    private Label AmmoLabel;
    private PlayerSingleton _playerSingleton;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        ScoreLabel = root.Q<Label>("Score");
        AmmoLabel = root.Q<Label>("Ammo");
    }
    
    public void UpdateScore()
    {
        //ScoreLabel.text = "Score: " + score.ToString();
    }
    
    public void UpdateAmmo(int ammo)
    {
        AmmoLabel.text = "Ammo: " + ammo.ToString();
    }
}
