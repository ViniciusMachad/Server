using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ApiClient : MonoBehaviour
{
    const string baseUrl = "http://localhost:55614/API";


    public Text Nome;
    public Text Idade;
    public Text Genero;
    public Text Peso;
    public Text Altura;
    // Use this for initialization
    void Start()
    {
        //StartCoroutine(PostItemApiAsync());
        StartCoroutine(GetItensApiAsync());

    }

    //private IEnumerator PostItemApiAsync()
    //{
    //    WWWForm form = new WWWForm();

    //    form.AddField("Nome", "ItemFromUnity 2");
    //    form.AddField("Descricao", "Item enviado por POST para Unity3d (2)");
    //    form.AddField("DanoMaximo", "50");
    //    form.AddField("Raridade", "9");
    //    form.AddField("TipoItemID", "1");

    //    using (UnityWebRequest request = UnityWebRequest.Post(baseUrl + "/Itens", form))
    //    {
    //        // obsoleto (Unity 2017.1)
    //        yield return request.Send();

    //        // (Unity 2017.2)
    //        // yield return request.SendWebRequest();


    //        if (request.isNetworkError || request.isHttpError)
    //        {
    //            Debug.Log(request.error);
    //        }
    //        else
    //        {
    //            Debug.Log("Envio do item efetuado com sucesso");
    //        }

    //    }
    //}

    IEnumerator GetItensApiAsync()
    {
        UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Modelos");

        // obsoleto (Unity 2017.1)
        yield return request.Send();

        // (Unity 2017.2)
        // yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string response = request.downloadHandler.text;
            //Debug.Log(response);

            //byte[] bytes = request.downloadHandler.data;

            Modelos[] itens = JsonHelper.getJsonArray<Modelos>(response);

            foreach (Modelos i in itens)
            {
                ImprimirItem(i);
            }




        }
    }
    private void ImprimirItem(Modelos i)
    {
        Debug.Log("======= Dados Objeto ==========");

        Debug.Log("Id: " + i.ModelosID);
        Debug.Log("Nome: " + i.Nome);
        Debug.Log("Descrição: " + i.Idade);
        Debug.Log("Dano Máximo: " + i.genero);
        Debug.Log("Raridade: " + i.Peso);
        Debug.Log("TipoItemID: " + i.Altura);

        Nome.text = "Nome: " + i.Nome;
        Idade.text = "Idade: " + i.Idade;
        Genero.text = "Genero: " + i.genero;
        Peso.text = "Peso: " + i.Peso;
        Altura.text = "Altura: " + i.Altura;
    }
}
