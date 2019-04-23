using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private float velocidadeAtual;
    public float velocidadeMaxima = 3f;

    public float aceleracaoInicial = 0.2f;
    public float aceleracao = 0.01f;
    public float desaceleracao = 0.07f;

    public float velociadeRotacao = 130f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 rotacao = Vector3.up * velociadeRotacao * Time.deltaTime * h;

        float v = Input.GetAxisRaw("Vertical");

        if (velocidadeAtual > 0)
        {
            transform.Rotate(rotacao);
        }

        velocidadeAtual = Mathf.Clamp(velocidadeAtual, 0, velocidadeMaxima);

        if (v != 0 && velocidadeAtual < velocidadeMaxima)
        {
            velocidadeAtual += velocidadeAtual == 0f ? aceleracaoInicial : aceleracao;
        }
        else if (v == 0 && velocidadeAtual > 0)
        {
            velocidadeAtual -= desaceleracao;
        }

        transform.Translate(velocidadeAtual * Time.deltaTime * Vector3.forward);

        float valorAnimacao = Mathf.Clamp(velocidadeAtual / velocidadeMaxima, 0f, 1f);
        animator.SetFloat("Speed", valorAnimacao);
    }
}