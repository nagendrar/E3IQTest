using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SearchField : MonoBehaviour
{
    public string[] StringList;

    public InputField IF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    GameObject ContentPanel;
    public void IFSearch()
    {
        ContentPanel = GameObject.Find("ScrollView").GetComponentInChildren<GridLayoutGroup>().gameObject;

        for (int i = 0; i < ContentPanel.transform.childCount; i++)
        {
            Destroy(ContentPanel.transform.GetChild(i).gameObject);
        }

        if (IF.text.Length != 0)
        {
            foreach (var factMessage in StringList)
            {
                bool contains = factMessage.IndexOf(IF.text, StringComparison.CurrentCultureIgnoreCase) >= 0;

                if (contains)
                {
                    GameObject Card = (GameObject)Resources.Load("searchitem");
                    var button = Instantiate(Card, transform.position, transform.rotation);

                    button.GetComponent<RectTransform>().SetParent(ContentPanel.transform);
                    button.transform.localScale = new Vector3(1, 1, 1);
                    button.transform.GetChild(0).GetComponent<Text>().text = factMessage;
                    button.GetComponent<Button>().onClick.AddListener(() => btnDownload_Click(factMessage));
                }
            }
        }
    }

    public void btnDownload_Click(string m)
    {
        SceneManager.LoadScene(m);
    }
}
