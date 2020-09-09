using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UnZipFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    static async void UnZipFileToDirectory()
    {
        await Task.Run(() => Allocate());
    }

    static void Allocate()
    {

    }
}
