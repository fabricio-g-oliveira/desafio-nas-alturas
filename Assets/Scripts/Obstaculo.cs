using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    [SerializeField]
    private float variacaoDaPosicaoY;
    private Vector3 posicaoDoAviao;
    private Pontuacao pontuacao;
    private bool pontuei;

    private void Awake()
    {
        this.transform.Translate(Vector3.up * Random.Range(- this.variacaoDaPosicaoY, this.variacaoDaPosicaoY));
    }

    private void Start()
    {
        this.posicaoDoAviao = GameObject.FindObjectOfType<Aviao>().transform.position;
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    private void Update()
    {
        this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime);

        if(!this.pontuei && this.transform.position.x < this.posicaoDoAviao.x)
        {
            this.pontuacao.AdicionarPontos();
            this.pontuei = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D barreira)
    {
        this.Destruir();
    }

    public void Destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}
