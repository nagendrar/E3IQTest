using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    //int buttoncount;
    public void OnButton()
    {
        GameObject buttonPrefab = (GameObject)Resources.Load("Card");
        GameObject button = Instantiate(buttonPrefab);

        var panel = GameObject.Find("Content");
        button.transform.position = panel.transform.position;
        button.GetComponent<RectTransform>().SetParent(panel.transform);
        button.layer = 5;
        //buttoncount++;
        //if(buttoncount % 3 == 0)
        //{
            //panel.GetComponent<RectTransform>().sizeDelta += new Vector2(0, panel.GetComponent<GridLayoutGroup>().cellSize.y + panel.GetComponent<GridLayoutGroup>().spacing.y);
        //}
        button.GetComponent<Button>().onClick.AddListener((() => OnButtonClick("Module")));
    }

    public void OnButtonClick(string s)
    {
        Debug.Log(s);
    }
}
