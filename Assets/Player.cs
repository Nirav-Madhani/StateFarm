using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> questions;
    public int curr = 0;
    public int health = 0, money = 0 ;
    public Image questionPanel;
    public Animator uiA;
    public Text label;
    int sh, sm;
    void Start()
    {
       
        //moveToTarget();
    }
    public void Next()
    {
        curr++;
    }
    public void setQuestion(int q)
    {
        curr = q;
        
        var questionPool = FindObjectOfType<QuestionPool>();
        var len = questionPool.questions[curr].answers.Count;

        questionPool.Q.text = questionPool.questions[curr].prompt;
        questionPool.o1.text = questionPool.questions[curr].answers[0].text;
        questionPool.o2.text = questionPool.questions[curr].answers[1].text;
        if (len > 2)
        {
            questionPool.o3.gameObject.SetActive(true);
            questionPool.o3.text = questionPool.questions[curr].answers[2].text;
        }
        else
            questionPool.o3.gameObject.SetActive(false);
        if (len > 3)
        {
            questionPool.o4.gameObject.SetActive(true);
            questionPool.o4.text = questionPool.questions[curr].answers[3].text;
        }
        else
        questionPool.o4.gameObject.SetActive(false);
        moveToTarget();
    }
    public void moveToTarget()
    {
        GetComponent<NavMeshAgent>().destination =  questions[curr].position;
    }
    public void setInitials()
    {
        sh = health;
        sm = money;
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Respawn")
        {
            var questionPool = FindObjectOfType<QuestionPool>();
            questionPanel.gameObject.SetActive(true);
            questionPool.panelAppear();
            uiA.SetTrigger("Appear");
        }
        else if (other.gameObject.tag == "Finish")
        {
            showResult();
        }
    }
    public Text resultBest, resultMy;
    public void showResult()
    {
        dashboard.SetActive(true);
        var questionPool = FindObjectOfType<QuestionPool>();
        string bt = "";
        foreach(string s in questionPool.answers)
        {
            bt += s + "\n";
        }
        resultMy.text = string.Format("Health: {0} \nMoney: {1}\nSteps: \n{2}",health,money,bt);
        resultBest.text = string.Format("Health: {0} \nMoney: {1}\nSteps: \nYes\nComprehensive ", sh-100, sm-130);
    }
    public GameObject dashboard;
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            questionPanel.gameObject.SetActive(false);            
        }
       
    }
    void OnCollisionEnter(Collision c)
    {
        var questionPool = FindObjectOfType<QuestionPool>();
        questionPool.hitCow();
    }
    public void Update()
    {
        label.text = string.Format("Health : {0} \nMoney : {1}", health, money);
    }
}
