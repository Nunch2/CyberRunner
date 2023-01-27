using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int EnemyLevel = 1;
    public int GlobalLevel;
    private PlayerController _playerController;
    

    private GameManager _gameManager;
    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        GlobalLevel = _playerController.playerLevel;
        EnemyLevel = Random.Range(_playerController.playerLevel * _gameManager.EnemiesCount, GlobalLevel);
        GlobalLevel += EnemyLevel;

        _gameManager.EnemiesCount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy gets triggered");
        Destroy(collision.gameObject);
        Destroy(gameObject);
        if (_playerController.playerLevel >= EnemyLevel)
        {
            
            _playerController.playerLevel += EnemyLevel;
            _gameManager.EnemiesCount--;
        }
    }
}