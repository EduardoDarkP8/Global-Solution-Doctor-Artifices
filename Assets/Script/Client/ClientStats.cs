using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientStats
{
    public string name;
    public int age;
    public string gender;
    public string diseaseName;
    public float zMolecula;
    public float xHormom;
    public float yLipidio;
    public float cardiacFrequency;
    public float corporalGases;
    public float press;
    public float glicose;
    public string[] symptoms;
    public ClientStats(){}
    public ClientStats(string diseaseName, float zMolecula, float xHormom, float yLipidio, float cardiacFrequency, 
                       float corporalGases, float press, float glicose, string[] symptoms) 
    {
        this.gender = ClientStatsConst.GENDERS[Random.Range(0, ClientStatsConst.GENDERS.Length)];
		if (this.gender == ClientStatsConst.GENDERS[1])
		{
            this.name = ClientStatsConst.MASCULINENAMES[Random.Range(0, ClientStatsConst.MASCULINENAMES.Length)];
        }
		else 
        {
             this.name = ClientStatsConst.FEMININENAMES[Random.Range(0, ClientStatsConst.FEMININENAMES.Length)];
        }
        age = Random.Range(22, 60);
        this.diseaseName = diseaseName;
        this.zMolecula = zMolecula;
        this.xHormom = xHormom;
        this.yLipidio = yLipidio;
        this.cardiacFrequency = cardiacFrequency;
        this.corporalGases = corporalGases;
        this.press = press;
        this.glicose = glicose;
        this.symptoms = symptoms;
    }
    public static ClientStats CreatClientStats(int diseaseIndex) 
    {
        ClientStats cs = new ClientStats();
		switch (diseaseIndex) 
        {
            case 0: cs = new ClientStats(
                //Nome da doença
                ClientStatsConst.DISEASENAMES[0],
                //Molecula Z
                Random.Range(7, 15),
                //Hormonio X
                Random.Range(7f, 15f),
                //Lipidio Y
                Random.Range(10000, 12000),
                //Frequencia Cardiaca
                Random.Range(90, 110),
                //Gases Corporais
                Random.Range(12f, 30f),
                //Pressão
                Random.Range(0.5f, 1.3f),
                //Glicose
                Random.Range(70, 100),
                //Sintomas
                new string[] { ClientStatsConst.SYMPTOMS[7], ClientStatsConst.SYMPTOMS[8]}
                );break;
            
            case 1: cs = new ClientStats(
                //Nome da doença
                ClientStatsConst.DISEASENAMES[1],
                //Molecula Z
                Random.Range(8, 15),
                //Hormonio X
                Random.Range(1f, 7f),
                //Lipidio Y
                Random.Range(10000, 12000),
                //Frequencia Cardiaca
                Random.Range(50, 90),
                //Gases Corporais
                Random.Range(12f, 30f),
                //Pressão
                Random.Range(1.3f, 1.8f),
                //Glicose
                Random.Range(50, 70),
                //Sintomas
                new string[] { ClientStatsConst.SYMPTOMS[7], ClientStatsConst.SYMPTOMS[8] }
                ); break;
            case 2: cs = new ClientStats(
                //Nome da doença
                ClientStatsConst.DISEASENAMES[2],
                //Molecula Z
                Random.Range(4, 6),
                //Hormonio X
                Random.Range(7f, 15f),
                //Lipidio Y
                Random.Range(5000, 10000),
                //Frequencia Cardiaca
                Random.Range(25, 50),
                //Gases Corporais
                Random.Range(15f, 30f),
                //Pressão
                Random.Range(1.8f, 2.8f),
                //Glicose
                Random.Range(100, 350),
                //Sintomas
                new string[] { ClientStatsConst.SYMPTOMS[5] }
                ); break;
            case 3: cs = new ClientStats(
                //Nome da doença
                ClientStatsConst.DISEASENAMES[2],
                //Molecula Z
                Random.Range(4, 6),
                //Hormonio X
                Random.Range(15f, 30f),
                //Lipidio Y
                Random.Range(5000, 10000),
                //Frequencia Cardiaca
                Random.Range(25, 50),
                //Gases Corporais
                Random.Range(15f, 30f),
                //Pressão
                Random.Range(1.3f, 1.8f),
                //Glicose
                Random.Range(100, 350),
                //Sintomas
                new string[] { ClientStatsConst.SYMPTOMS[5] }
                ); break;
        }
        return cs;
    }
}

public class ClientStatsConst
{
    public static string[] DISEASENAMES = { "Doença1", "Doença2", "Doença3", "Doença4" };
    
    public static string[] FEMININENAMES = { "Roberta", "Luiza", "Cleide" };

    public static string[] GENDERS = { "Feminino", "Masculino" };

    public static string[] MASCULINENAMES = { "Carlos", "Pedro", "Wagner" };
   
    public static string[] SYMPTOMS = {"Febre","Dor de Cabeça", "Dores pelo Corpo", "Dor nas Costas", "Fraqueza", "Diarreia", "Gases", 
                                       "Náusea", "Vômito", "Desmaio", "Falta de Ar", "Inchaço"};
}
