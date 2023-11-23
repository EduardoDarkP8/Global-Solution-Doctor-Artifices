using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public bool isWainting;
    public ClientStats stats;
    public ClientMovement move;
    public ClientListner listner;
    public GameObject fichaTempalte;
    GameObject fichaInstance;
    public GameManager gameManager;
    private bool[] activeCamps = new bool[7];
    void Start()
    {
        listner.onClientEnter += Listner_onClientEnter;

    }

    public void AddStats()
    {
        stats = ClientStats.CreateRandomClientStats();
        int n = 0;
        foreach (bool b in activeCamps)
        {
            int i = Random.Range(0, 3);
            if (i == 0)
            {
                activeCamps[n] = false;
            }
            else
            {
                activeCamps[n] = true;
            }
            n++;
        }
    }
    public void Listner_onClientEnter(Transform obj)
    {

        StartCoroutine(EnterRoom(obj));

    }
    public void GoToExames(bool[] newActives, float time)
    {
        StartCoroutine(GoToExamesAnim(newActives, time));
    }
    public void FinishAppointment()
    {
        StartCoroutine(FinishAppointmentAnim());
    }
    IEnumerator Wait(float i)
    {
        yield return new WaitForSeconds(i);
        isWainting = false;
    }
    IEnumerator EnterRoom(Transform obj)
    {
        move.MoveRoom(true);
        yield return new WaitForSeconds(move.animTime);
        fichaInstance = Instantiate(fichaTempalte, obj);
        Analyse analyse = fichaInstance.GetComponent<Analyse>();
        analyse.gm = gameManager;
        analyse.confirmButton.client = this;
        analyse.confirmButton.gameManager = gameManager;
        analyse.ficha.Show(stats, activeCamps);
        analyse.exames.client = this;
    }
    IEnumerator FinishAppointmentAnim()
    {
        move.MoveRoom(false);
        if (fichaInstance != null)
        {
            Destroy(fichaInstance);
        }
        yield return new WaitForSeconds(move.animTime);
        ConfirmedQueue.instance.confirmdClients.Add(this);
        QueryQueue.instance.waitingClients.Remove(this);
        QueryQueue.instance.ListUpdate();
        ConfirmedQueue.instance.confirmdClients.Remove(this);
        Destroy(gameObject);
    }
    IEnumerator GoToExamesAnim(bool[] newActives, float time)
    {
        move.MoveRoom(false);
        if (fichaInstance != null)
        {
            Destroy(fichaInstance);
        }
        yield return new WaitForSeconds(move.animTime);
        isWainting = true;
        int i = 0;
        foreach (bool b in newActives)
        {
            if (b)
            {
                activeCamps[i] = b;
            }
            i++;
        }
        StartCoroutine(Wait(time));
        ExamQueue.instance.waitingClients.Add(this);
        QueryQueue.instance.waitingClients.Remove(this);
        QueryQueue.instance.ListUpdate();
    }
}
