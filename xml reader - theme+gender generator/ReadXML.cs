using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class ReadXML : MonoBehaviour
{
    public TextAsset GameAsset;

    List<Dictionary<string, string>> bd = new List<Dictionary<string, string>>();
    Dictionary<string, string> generos;
    Dictionary<string, string> temas;

    int i = 0;
    int j = 0;

    void Start()
    {
        LoadXML();
    }

    public void LoadXML()
    {
        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.LoadXml(GameAsset.text); // load the file.

        XmlNodeList bancoDeGeneros = xmlDoc.GetElementsByTagName("Genero"); // array of the level nodes.
        XmlNodeList bancoDeTemas = xmlDoc.GetElementsByTagName("Tema");

        generos = new Dictionary<string, string>();
        temas = new Dictionary<string, string>();

        i = 0;

        foreach (XmlNode genero in bancoDeGeneros)
        {
            generos.Add(i.ToString(), genero.InnerText);
            bd.Add(generos);
            i++;
        }

        j = 0; ;
        foreach (XmlNode tema in bancoDeTemas)
        {
            temas.Add(j.ToString(), tema.InnerText);
            bd.Add(temas);
            j++;
        }

    }

    public string ReturnGenere()
    {
        return generos[Random.RandomRange(0, i).ToString()].ToString();
    }

    public string ReturnTheme()
    {
        return temas[Random.RandomRange(0, j).ToString()].ToString();
    }
}
