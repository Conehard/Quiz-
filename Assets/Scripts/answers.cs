using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class answers : MonoBehaviour {

	private int themeID;
	public Text pergunta;
	public Text respostaA;
	public Text respostaB;
	public Text respostaC;
	public Text respostaD;
	public Text inforespostas;
	public string[] perguntas;
	public string[] alternativaA;
	public string[] alternativaB;
	public string[] alternativaC;
	public string[] alternativaD;
	public string[] corretas;
	private int idPergunta;
	private float acertos;
	private float questoes;
	private float media;
	private int notaFinal;
	public GameObject voltarTemas;
	public GameObject voltarHome;

	// Use this for initialization
	void Start () {
		themeID = PlayerPrefs.GetInt("themeID");
		idPergunta = 0;
		questoes = perguntas.Length;
		pergunta.text = perguntas [idPergunta];
		respostaA.text = alternativaA [idPergunta];
		respostaB.text = alternativaB [idPergunta];
		respostaC.text = alternativaC [idPergunta];
		respostaD.text = alternativaD [idPergunta];
	}
	// Update is called once per frame
	void Update () {
		inforespostas.text = "Respondendo "+(idPergunta+1).ToString() + " de " + questoes.ToString ();
	}

	public void resposta(string alternativa){
		if(alternativa == "A"){
			if(alternativaA [idPergunta] == corretas[idPergunta]){
				acertos+= 1;
			}
		}else if(alternativa == "B"){
			if(alternativaB[idPergunta] == corretas[idPergunta]){
				acertos+= 1;
			}
		}else if(alternativa == "C"){
			if(alternativaC[idPergunta] == corretas[idPergunta]){
				acertos+= 1;
			}
		}else if(alternativa == "D"){
			if(alternativaD[idPergunta] == corretas[idPergunta]){
				acertos+= 1;
			}
		}
		print (acertos);
		voltarHome.SetActive (false);
		voltarTemas.SetActive (false);
		next();
	}
	void next(){
		idPergunta++;
		if (idPergunta <= (questoes - 1)) {
			pergunta.text = perguntas [idPergunta];
			respostaA.text = alternativaA [idPergunta];
			respostaB.text = alternativaB [idPergunta];
			respostaC.text = alternativaC [idPergunta];
			respostaD.text = alternativaD [idPergunta];
		}else{
			media = 10 * (acertos/questoes);
			notaFinal = Mathf.RoundToInt(media);
			if(notaFinal > PlayerPrefs.GetInt("notaFinal"+themeID.ToString())){
				PlayerPrefs.SetInt("notaFinal"+themeID.ToString(), notaFinal);
				PlayerPrefs.SetInt("acertos"+themeID.ToString(), (int) acertos);
			}
			PlayerPrefs.SetInt("notaFinalTemp"+themeID.ToString(), notaFinal);
			PlayerPrefs.SetInt("acertosTemp"+themeID.ToString(), (int) acertos);
			Application.LoadLevel("nota");
		}
	}
}
