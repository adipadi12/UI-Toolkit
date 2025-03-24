using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Button cubeButton;
    [SerializeField] private GameObject cubeSpawnerEmpty;
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private Button restartButton;
    [SerializeField] private List<GameObject> cubeList;
    private int counter = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestroyAfter30Secs());
    }
    IEnumerator DestroyAfter30Secs()
    {
        yield return new WaitForSeconds(30);
        OnClickRestartButton();
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnClickButton()
    {
        Vector3 transformCube = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
        counterText.text = counter.ToString();

        GameObject newCube = Instantiate(cubePrefab, transformCube, Quaternion.identity, cubeSpawnerEmpty.transform);
        //newCube;
        counter++;
        cubeList.Add(newCube);
    }

    public void OnClickRestartButton()
    {
        counter = 0;
        counterText.text = counter.ToString();
        // cubeList = GameObject.FindGameObjectsWithTag("Cube");
        //if (cubeList == null)
        //    cubeList = GameObject.FindGameObjectsWithTag("Cube");

        //foreach (GameObject cube in cubeList)
        //{
        //    Destroy(cube);
        //    Debug.Log("Cube Destroyed");
        //}
        for (int i = 0; i < cubeList.Count; i++)
        {
            Destroy(cubeList[i]);
        }
        cubeList.Clear();
        //OnClickButton();
    }

    
}
