using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{
    public TMP_Text LevelText;
    public int EnemyLevel = 1;
    public static int GlobalLevel;
    private PlayerController _playerController;
    public AudioClip audioClip;
    

    private GameManager _gameManager;
    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        EnemyLevel = Random.Range(_playerController.playerLevel * _gameManager.EnemiesCount, GlobalLevel);
        GlobalLevel += EnemyLevel;

        _gameManager.EnemiesCount++;
        LevelText.text = EnemyLevel.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy gets triggered");
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(_gameManager.defeatUI);
        }
        Destroy(collision.gameObject);
        if (_playerController.playerLevel >= EnemyLevel)
        {
            Destroy(gameObject);
            _playerController.playerLevel += EnemyLevel;
            _gameManager.EnemiesCount--;
        }
    }
}