using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private Score scoreComponent;

    private int _enemiesCount = 0;
    public int EnemiesCount
    {
        get
        {
            return _enemiesCount;
        }
        set
        {
            _enemiesCount = value;
            CheckEnemiesCountLeft();
            scoreComponent.UpdateScore(_enemiesCount);
        }
    }

    private void Awake()
    {
        scoreComponent = FindObjectOfType<Score>();
    }

    //public int GetAnimalCount()
    //{
    //    return _animalsCount;
    //}

    //public void SetAnimalCount(int newAnimalCount)
    //{
    //    _animalsCount = newAnimalCount;
    //    CheckAnimalsCountLeft();
    //}

    private void CheckEnemiesCountLeft()
    {
        if (_enemiesCount <= 0)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        Debug.Log("LoadNextScene");
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
}