using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Missions : MonoBehaviour
{
    [Header ("")]
    [SerializeField] private List<Mission> _mission; 

    private int _currentMission;

    [Header("UI")]
    [SerializeField] private Button _goNextPointButton;

    private Player_Movement _player_Movement;


    private void Start()
    {
        _player_Movement = FindObjectOfType<Player_Movement>();

        _mission[_currentMission].Kills = 0;
        _mission[_currentMission].OnChecked();
    }


    public void OnKill()
    {
        _mission[_currentMission].Kills++;
        _mission[_currentMission].OnChecked();

        if (_mission[_currentMission].IsFinished == true)
        {
            _mission[_currentMission].Kills = 0;

            if (_currentMission != _mission.Count)
            {
                _currentMission++;

                _goNextPointButton.gameObject.SetActive(true);
            }
            else if (_currentMission == _mission.Count)
            {
                
            }
        }
    }
}