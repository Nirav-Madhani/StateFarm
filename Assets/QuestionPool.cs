using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Answer {
    public int nextQuestion;
    public string text;
    public int health;
    public int money;
}
[System.Serializable]
public  class Question
{
    public string prompt;
    public List<Answer> answers; 
}

public class QuestionPool : MonoBehaviour
{

    // Start is called before the first frame update
    public Text Q, o1, o2, o3, o4;
    public List<Question> questions;
    public Player player;
    public AudioClip buttonClick;
    public AudioClip appear;
    public AudioClip cow;
    AudioSource source;
    public List<GameObject> panels;
    public List<string> answers;
    
    public void selectAnswer(int i)
    {
        player.health += questions[player.curr].answers[i].health;
        player.money += questions[player.curr].answers[i].money;
        answers.Add(questions[player.curr].answers[i].text);
        player.setQuestion(questions[player.curr].answers[i].nextQuestion);       
        source.clip = buttonClick;
        source.Play();
        player.uiA.SetTrigger("Disappear");        
    }
    // Update is called once per frame
    public void panelAppear()
    {
        source.clip = appear;
        source.Play();
    }
    public void nextPanel(int i)
    {
        if(i>=0)
            panels[i].SetActive(false);
        panels[i + 1].SetActive(true);
    }
    public void addHealth(int i)
    {
        player.health += i;
    }
    public void addMoney(int i)
    {
        player.money += i;
    }
    public void hitCow()
    {
        source.clip = cow;
        source.Play();
    }
    public void goBack()
    {
        SceneManager.LoadScene(0);
    }
    void Start()
    {
        source = GetComponent<AudioSource>();    
    }
}
