using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class tetrisblock : MonoBehaviour
{
    private int operando1;
    private int operando2;
    private char operacao;
    private int operador;
    private int resultado;

    private int choice;

    public float fallspeed = 2.0f;
    private float falltimer;
    private float currentfallspeed;
    private bool enable = true;
    public TextMeshProUGUI text;

    private void Start()
    {
        operador = UnityEngine.Random.Range(1, 4);
        resultado = ExpressionControler._instance.chooseRandomResult();


        //Debug.Log("Remove atual para proxima nn ser chamada com o mesmo valor: " + resultado);
        ExpressionControler._instance.removeFromList(resultado);
        

        switch (operador)
        {
            case 1:
                operacao = '+';

                operando1 = UnityEngine.Random.Range(0, resultado); 
                operando2 = resultado-operando1;
                break;
            case 2:
                operacao = '-';

                operando1 = UnityEngine.Random.Range(resultado, 100); 
                operando2 = operando1-resultado;
                break;
            case 3:
                operacao = 'x';

                List<(int,int)> values = new List<(int,int)> ();

                for(int i = 0; ++i <= resultado;)
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

                operando2 = UnityEngine.Random.Range(1, 30);
                operando1 = resultado * operando2;
                break;
            default:
                break;
        }
        //Debug.Log(resultado);

        text.text = operando1.ToString()+ "\n" + operacao +"\n" + operando2.ToString() ;
    }

    void Update()
    {
        if (enable)
        {
            RaycastHit2D down_hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1f);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down), Color.blue, 1f);
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
                        //if (up_hit.collider.CompareTag("SmallBlock"))
                        GameObject obj = down_hit.collider.gameObject;
                        if (obj.CompareTag("SmallBlock"))
                        {
                            //Debug.Log("AQUIIII");
                            if (resultado == obj.GetComponent<Smalltetrisblock>().result)
                            {
                                Destroy(obj);
                            }
                            
                        }
                        else
                        {
                            StartCoroutine(SpawnCoroutine(20));

                            //Debug.Log("Errou, adiciona novamente o resultado para as possibilidades: " + resultado);
                            ExpressionControler._instance.addToList(resultado);
                            
                        }
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
