using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
	public TextMesh loading;
	public TextMesh countdown;
	public TextMesh chrono;

	public Text FPS;

	private bool pres,feu;
	public float compteur = 3;
	private float chronometre = 0.0f;

	// Start is called before the first frame update
	void Start()
	{
		loading.text="Chargement.";
		countdown.text = "";
		chrono.text = "";

		pres = false;
		feu = false;
	}

	void updateLoading(){
		int t = (int)Time.time;
		if(!pres){
			//"animation" du chargement
			if(t%3==0)
				loading.text="Chargement.";

			if(t%3==1)
				loading.text="Chargement..";

			if(t%3==2)
				loading.text="Chargement...";

			if(FPS.text != "0.0 FPS"){
				//début du compte a rebourd
				pres = true;
				loading.text = "";
			}
		}
		else{
			if(!GameObject.Find("4_RWrist")){
				loading.text="placer vous bien en face de votre caméra";
				loading.fontSize = 100;
			}
			else
				loading.text="";
		}
			
	}

	void updateCountdown(){
		if(pres){
	    	compteur-=Time.deltaTime;
	    	countdown.text = ((int)compteur+1).ToString();

	    	if(compteur <= 0){
	    		feu = true;
	    		countdown.text = "ramez !";
	    	}
	    	if(compteur <= -0.5){
	    		countdown.text = "";
	    	}
		}
	}

	string Temps(float t,string separateur){
		string minute,seconde,decim;
		string retour = "";
		int sec = (int) t;
		int dec = (int) ((t-sec)*100.0);
		int min = (int) sec/60;

		minute = min.ToString();
		seconde = (sec%60).ToString();
		decim = dec.ToString();
		if(dec<10)
			decim = "0"+decim;
		if(min>0){
			retour = minute+separateur;
			if((sec%60)<10)
				seconde = "0"+seconde;
		}

		return retour+seconde+separateur+decim;
	}

	void updateChrono(){
		if(feu){
			chronometre += Time.deltaTime;
    		chrono.text = Temps(chronometre,":");
		}
	}

	// Update is called once per frame
	void Update()
	{
		updateCountdown();
		updateChrono();
		updateLoading();
	}
}
