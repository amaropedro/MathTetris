using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private bool isEnabled = true;
    public TextMeshProUGUI text;

    private void Start()
    {
        operador = UnityEngine.Random.Range(1, 5);
        resultado = ExpressionControler._instance.chooseRandomResult();

        ExpressionControler._instance.removeFromList(resultado);
        Debug.Log("Peça grande remove: " + resultado);

        //eu n inclui nenhuma operação com 0 ou 1 nos operadores
        generateEquasion(operador);

        text.text = operando1.ToString()+ "\n" + operacao +"\n" + operando2.ToString() ;
    }

    void Update()
    {
        if (isEnabled)
        {
            RaycastHit2D down_hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
            RaycastHit2D right_hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);
            RaycastHit2D left_hit = Physics2D.Raycast(transform.position, Vector2.left, 1f);

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
                    isEnabled = false;
 
                    GameObject obj = down_hit.collider.gameObject;
                    if (obj.CompareTag("SmallBlock") && (resultado == obj.GetComponent<Smalltetrisblock>().result))
                    {
                        
                        if(operador == 1 || operador == 2)
                        {
                            Main_Game_Screen.ScoreValue += 70;
                        }
                        else
                        {
                            Main_Game_Screen.ScoreValue += 100;
                        }
                        Destroy(obj);
                        if (ExpressionControler._instance.results.Count == 0)
                        {
                            StartCoroutine(SpawnAndDestroyCoroutine(50));
                        }
                        else
                        {
                            Spawner._instance.SpawnPiece();
                            Destroy(gameObject);
                        }
                    }
                    else
                    {
                        if (operador == 1 || operador == 2)
                        {
                            Main_Game_Screen.ScoreValue -= 35;
                            if (Main_Game_Screen.ScoreValue < 0)
                            {
                                Main_Game_Screen.ScoreValue = 0;
                            }
                        }
                        else
                        {
                            Main_Game_Screen.ScoreValue -= 50;
                            if (Main_Game_Screen.ScoreValue < 0)
                            {
                                Main_Game_Screen.ScoreValue = 0;
                            }
                        }
                        ExpressionControler._instance.addToList(resultado);
                        Debug.Log("Peça errou. add: " + resultado);
                        StartCoroutine(SpawnAndDestroyCoroutine(50));                          
                    }
                }
            }
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponentInChildren<Canvas>().enabled = false;
        }
    }

    IEnumerator SpawnAndDestroyCoroutine(int chance)
    {
        Spawner._instance.SpawnSmallPieces(chance);
        yield return new WaitForSeconds(1.5f);
        Spawner._instance.SpawnPiece();
        Destroy(gameObject);
    }

    void generateEquasion(int op)
    {
        switch (op)
        {
            case 1:
                operacao = '+';

                operando1 = UnityEngine.Random.Range(1, resultado);
                operando2 = resultado - operando1;
                break;
            case 2:
                if(resultado <= 97)
                {
                    operacao = '-';

                    operando1 = UnityEngine.Random.Range(resultado + 2, 100);
                    operando2 = operando1 - resultado;
                }
                else
                {
                    generateEquasion(1);
                }
                
                break;
            case 3:
                operacao = 'x';

                List<(int, int)> values = new List<(int, int)>();

                for (int i = 2; i < resultado; i++)
                {
                    if (resultado % i == 0)
                    {
                        operando1 = i;
                        operando2 = resultado / i;
                        values.Add((operando1, operando2));
                    }
                }

                if (values.Count > 0)
                {
                    choice = UnityEngine.Random.Range(0, values.Count);

                    operando1 = values[choice].Item1;
                    operando2 = values[choice].Item2;
                }
                else
                {
                    generateEquasion(UnityEngine.Random.Range(1, 3));
                }

                break;
            case 4:
                operacao = '/';

                List<(int, int)> valuesDivision = new List<(int, int)>();

                for (int a = 30; a > 0; a--)
                {
                    for (int b = 2; b < a; b++)
                    {
                        if ((a % b) == 0 && (a / b) == resultado)
                        {
                            valuesDivision.Add((a, b));
                            print(a + " / "+ b + " = " + resultado);
                        }
                    }
                }

                if (valuesDivision.Count > 0)
                {
                    choice = UnityEngine.Random.Range(0, valuesDivision.Count);

                    operando1 = valuesDivision[choice].Item1;
                    operando2 = valuesDivision[choice].Item2;
                }
                else
                {
                    generateEquasion(UnityEngine.Random.Range(1, 4));
                }

                break;
            default:
                break;
        }
    }
}
