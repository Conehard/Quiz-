using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class themesCommands : MonoBehaviour {

	public string[] themeName;
	private int 	themeID;
	public int		NumeroQuestoes;

	// Use this for initialization
	void Start () {
		themeID = 0;
	}

	public void selecioneTema(int i){
		themeID = i;
		PlayerPrefs.SetInt("themeID", themeID);
		Application.LoadLevel ("tema"+themeID.ToString());
	}


}
