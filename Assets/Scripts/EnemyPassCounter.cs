using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPassCounter : MonoBehaviour
{
    [SerializeField] private GameObject _loseContainer;
    
    private void OnTriggerEnter(Collider other)
    {
        
        other.gameObject.SetActive(false);
        _loseContainer.SetActive(true);
        Debug.Log("Touched");

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}