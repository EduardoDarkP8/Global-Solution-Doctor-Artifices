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
    public static ClientStats CreateClientStats(int diseaseIndex) 
    {
        ClientStats cs = new ClientStats(
                //Nome da doença
                ClientStatsConst.DISEASENAMES[diseaseIndex],
                //Molecula Z
                Random.Range(ClientStatsConst.ZMOLEC[diseaseIndex].min, ClientStatsConst.ZMOLEC[diseaseIndex].max),
                //Hormonio X
                Random.Range(ClientStatsConst.XHORMONIO[diseaseIndex].min, ClientStatsConst.XHORMONIO[diseaseIndex].max),
                //Lipidio Y
                Random.Range(ClientStatsConst.YLIPIDIO[diseaseIndex].min, ClientStatsConst.YLIPIDIO[diseaseIndex].max),
                //Frequencia Cardiaca
                Random.Range(ClientStatsConst.CARDIACFRENQUENCY[diseaseIndex].min, ClientStatsConst.CARDIACFRENQUENCY[diseaseIndex].max),
                //Gases Corporais
                Random.Range(ClientStatsConst.GASES[diseaseIndex].min, ClientStatsConst.GASES[diseaseIndex].max),
                //Pressão
                Random.Range(ClientStatsConst.PRESS[diseaseIndex].min, ClientStatsConst.PRESS[diseaseIndex].max),
                //Glicose
                Random.Range(ClientStatsConst.GLICOSE[diseaseIndex].min, ClientStatsConst.GLICOSE[diseaseIndex].max),
                //Sintomas
                new string[] { ClientStatsConst.DISEASESSYMPTOMS[diseaseIndex].sin1, ClientStatsConst.DISEASESSYMPTOMS[diseaseIndex].sin2, ClientStatsConst.DISEASESSYMPTOMS[diseaseIndex].sin3}
                );
            

        return cs;
    }

    public static ClientStats CreateRandomClientStats() 
    {
        return CreateClientStats(Random.Range(0, ClientStatsConst.DISEASENAMES.Length));
    }
}

public class ClientStatsConst
{
    public static string[] SYMPTOMS = {"Febre","Dor de Cabeça", "Dores pelo Corpo", "Dor nas Costas", "Fraqueza", "Diarreia", "Gases",
                                       "Náusea", "Vômito", "Desmaio", "Falta de Ar", "Inchaço"};

    public static string[] DISEASENAMES = { "Doença 1", "Doença 2", "Doença 3", "Doença 4" };

    public static (int min, int max)[] ZMOLEC = {(7,15),(8,15),(4,6),(4,6)};

    public static (float min, float max)[] XHORMONIO = { (7f, 15f), (1f, 7f), (7f, 15f), (1, 15f) };

    public static (int min, int max)[] YLIPIDIO = {(10000, 12000), (10000, 12000), (5000, 10000), (5000, 10000)};

    public static (int min, int max)[] CARDIACFRENQUENCY = { (90, 110), (50, 90), (25, 50), (25, 50) };

    public static (float min, float max)[] GASES = { (12f, 30f), (12f, 30f), (15f, 30f), (15f, 30f) };

    public static (float min, float max)[] PRESS = { (0.5f, 1.3f), (1.3f, 1.8f), (1.8f, 2.8f), (1.3f, 1.8f) };

    public static (int min, int max)[] GLICOSE = { (70, 100), (50, 70), (100, 350), (100, 350) };

	public static (string sin1, string sin2, string sin3)[] DISEASESSYMPTOMS = { (SYMPTOMS[7], SYMPTOMS[8], null), (SYMPTOMS[7], SYMPTOMS[8], null), (SYMPTOMS[5], null, null), (SYMPTOMS[5], null, null) };


    public static string[] FEMININENAMES = { "Roberta", "Luiza", "Cleide" };

    public static string[] GENDERS = { "Feminino", "Masculino" };

    public static string[] MASCULINENAMES = { "Carlos", "Pedro", "Wagner" };
   
   
}
