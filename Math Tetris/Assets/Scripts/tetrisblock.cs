using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class tetrisblock : MonoBehaviour
{
    int operando1;
    int operando2;
    char operacao;
    int aux;
    public float fallspeed = 2.0f;
    private float falltimer;
    private float currentfallspeed;
    private bool enable = true;
    public TextMeshProUGUI text;
    Expression_Control expression_Control;

    private void Start()
    {
        int aux = UnityEngine.Random.Range(1, 4);
        //int aux = 3;
        /*int[] resultados = new int[200];
        int resultado = UnityEngine.Random.Range(0, 200);

        for (int i = 0; i < resultados.Length; i++)
        {
            resultados[i] = i + 1;
        }*/
        int resultado;


        switch (aux)
        {
            case 1:
                operacao = '+';

                resultado = UnityEngine.Random.Range(0, 100);
                Debug.Log(resultado);

                operando1 = UnityEngine.Random.Range(0, resultado); 
                operando2 = resultado-operando1;
                break;
            case 2:
                operacao = '-';

                resultado = UnityEngine.Random.Range(0, 100);
                Debug.Log(resultado);

                operando1 = UnityEngine.Random.Range(resultado, 100); 
                operando2 = operando1-resultado;
                break;
            case 3:
                operacao = 'x';

                int choice;
                resultado = UnityEngine.Random.Range(0, 100);
                Debug.Log(resultado);

                List<(int,int)> values = new List<(int,int)> ();

                for(int i = 0; ++i <= resultado;)//coloquei <= diferente de amaro
                {
                    if (resultado % i == 0)
                    {
                        operando1 = i;
                        operando2 = resultado / i;
                        values.Add((operando1, operando2));
                    }
                }
                if (resultado == 0)
                {
                    values.Add((0, 0));
                }
                choice = UnityEngine.Random.Range(0, values.Count);
                operando1 = values[choice].Item1; 
                operando2 = values[choice].Item2;
                break;
            case 4:
                operacao = '/';

                resultado = UnityEngine.Random.Range(0, 100);
                Debug.Log(resultado);

                operando2 = UnityEngine.Random.Range(1, 30);
                operando1 = resultado * operando2;
                break;
            default:
                break;
        }


        text.text = operando1.ToString()+ "\n" + operacao +"\n" + operando2.ToString() ;
    }


    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            RaycastHit2D down_hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1f);
            RaycastHit2D right_hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1f);
            RaycastHit2D left_hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1f);

            if (Input.GetKeyDown(KeyCode.LeftArrow) && !left_hit)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && !right_hit)
            {
                transform.position += new Vector3(1, 0, 0);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                currentfallspeed = fallspeed / 20;
            }
            else
            {
                currentfallspeed = fallspeed;
            }


            if ((Time.time - falltimer) > currentfallspeed)
            {
                if (!down_hit)
                {
                    transform.position += new Vector3(0, -1, 0);
                    falltimer = Time.time;
                }
                else
                {
                    enable = false;
                    if (transform.position.y >= 18.5f)
                    {
                        //game over
                        print("game over");
                    }
                    else
                    {
                        //checar se for a pe�a correta, se n�o for
                        StartCoroutine(SpawnCoroutine(20));
                        Spawner._instance.SpawnPiece();
                        Destroy(gameObject);
                    }
                }
            }

        }
    }

    IEnumerator SpawnCoroutine(int chance)
    {
        Spawner._instance.SpawnSmallPieces(chance);
        //esse wait n�o est� funcionando
        yield return new WaitForSeconds(2.5f);
        print("hello");
    }

}
