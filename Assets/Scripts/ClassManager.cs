using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ClassManager : MonoBehaviour
{
    [SerializeField] private ClassData[] allclassData;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text [] allScoreText;
    [SerializeField] private GameObject allScore;

    [SerializeField] private Animator classTextAnim;

    [SerializeField] private GameObject movil;
    [SerializeField] private Text classText1;
    [SerializeField] private Text scoreText1;
    [SerializeField] private Text classText2;
    [SerializeField] private Text scoreText2;
    [SerializeField] private Text classText3;
    [SerializeField] private Text scoreText3;

    private int index1;
    private int index2;

    private void Start()
    {
        for (int i = 0 ; i < allclassData.Length; i++)
        {
            allclassData[i].Score = 0;
        }
    }

    public void OnClickCard(ClassData classData)
    {
        classData.Score += 10;
        Debug.Log(classData.ClassName);
        Debug.Log(classData.Score);
        allScoreText[classData.Index].text = classData.Score.ToString();
    
        scoreText.text = 10 + " + " + classData.ClassName  ;
        classTextAnim.SetInteger("onClass", 1);
        StartCoroutine(StopAnim());
    }

    public void OnClickShowScore()
    {
        allScore.gameObject.SetActive(true);
    }

    public void ExitShowScore()
    {
        allScore.gameObject.SetActive(false);
    }

    private IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(1f);
        classTextAnim.SetInteger("onClass", 0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LeadingClass()
    {
        int max = 0;
        int max1 = 0;
        int max2 = 0;

        string maxName = "";
        string maxName1 = "";
        string maxName2 = "";

        for (int i = 0; i < allclassData.Length; i++)
        {
    
            if(allclassData[i].Score > max )
            {
                max = allclassData[i].Score;
                maxName = allclassData[i].ClassName;
                index1 = i;
            }

        }

        for (int i = 0; i < allclassData.Length; i++)
        {

            if (allclassData[i].Score > max1 && i != index1)
            {
                max1 = allclassData[i].Score;
                maxName1 = allclassData[i].ClassName;
                index2 = i;
            }
        }

        for (int i = 0; i < allclassData.Length; i++)
        {

            if (allclassData[i].Score > max2 && i != index1 && i != index2)
            {
                max2 = allclassData[i].Score;
                maxName2 = allclassData[i].ClassName;
            }
        }


        Debug.Log(maxName + " score" + max);
        Debug.Log(maxName1 + " score" + max1);
        Debug.Log(maxName2 + " score" + max2);

        //gameManager.Movil(maxName, max);
        classText1.text = maxName;
        scoreText1.text = max.ToString();
        classText2.text = maxName1;
        scoreText2.text = max1.ToString();
        classText3.text = maxName2;
        scoreText3.text = max2.ToString();

        scoreText.gameObject.SetActive(false);
        movil.gameObject.SetActive(true);
    }

    public void ExitLeadingClass()
    {
        movil.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
}
