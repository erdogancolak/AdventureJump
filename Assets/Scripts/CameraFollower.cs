using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CameraFollower : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private Transform target;
    [SerializeField] private Text scoreText;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = new Vector3(target.position.x,target.position.y,target.position.z - 10);
        scoreText.text = Platforms.score.ToString();   
    }

    public void menuSceneButton()
    {
        SceneManager.LoadScene(0);
    }
}
