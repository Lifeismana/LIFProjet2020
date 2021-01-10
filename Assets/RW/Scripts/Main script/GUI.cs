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

    // Update is called once per frame
    void Update()
    {
    	int t = (int)Time.time;
    	if(feu){
    		string separateur = ":";
    		chronometre+=Time.deltaTime;
    		int unite = (int)chronometre;
    		int decim = (int)((chronometre-unite)*100.0);
    		if(decim<10){
    			separateur+="0";
    		}
    		chrono.text = unite.ToString()+separateur+decim.ToString();
    	}
    	if(pres){
	    	if(!GameObject.Find("4_RWrist")){
	    		loading.text="placer vous bien devant la caméra";
	    	}
	    	if(compteur<=0 && !feu){
	    		feu = true;
	    		loading.text = "ramez !";
	    		countdown.text = "";
	    	}
	    	if(!feu){
	    		compteur-=Time.deltaTime;
	    		countdown.text = ((int)compteur+1).ToString();
	    	}
	   }
	    else{
	    	if(FPS.text != "0.0 FPS"){
	    		//début du compte a rebourd
	    		pres = true;
	    		loading.text="Chargement.";
	    	}
	    	else{
	    		//"animation" du chargement
	    		if(t%3==0){
	    			loading.text="Chargement.";
	    		}
	    		if(t%3==1){
	    			loading.text="Chargement..";
	    		}
	    		if(t%3==2){
	    			loading.text="Chargement...";
	    		}
	    	}
	   }
    }
}
