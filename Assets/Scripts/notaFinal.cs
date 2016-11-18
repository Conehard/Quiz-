using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class notaFinal : MonoBehaviour {

	private int themeID;
	public Text txtNota;
	public Text txtInfo;
	public Text txtRecord;
	public GameObject emoteTriste;
	public GameObject emoteFeliz;
	private int final;
	private int acertos;
	private int record;

	// Use this for initialization
	void Start () {

		themeID = PlayerPrefs.GetInt("themeID");
		final = PlayerPrefs.GetInt("notaFinalTemp"+themeID.ToString());
		acertos = PlayerPrefs.GetInt("acertosTemp"+themeID.ToString());
		record = PlayerPrefs.GetInt("notaFinal"+themeID.ToString());
		txtNota.text = final.ToString();
		txtInfo.text = "Você acertou "+acertos.ToString()+" de 6 perguntas";
		txtRecord.text = record.ToString(); 

		if (final<6){
			emoteTriste.SetActive(true);
		}else if(final>=6){
			emoteFeliz.SetActive(true);
		}
	}

}
