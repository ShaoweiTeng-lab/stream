using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


using System.Net.Http.Headers;
using System.Net.Mime;
using System.Web;

using System.Net;
using System.Threading.Tasks;
using System.Net.Http;

public class HttpDownload : MonoBehaviour
{
    string path = @"D:\texttest\JasonGet.png";
    // Start is called before the first frame update
    void Start()
    {

        save_file_from_url(path, "https://image.api.playstation.com/vulcan/img/rnd/202010/2621/KvgbdmY6MvPdLaa3dyVNGOw1.png");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public async void save_file_from_url(string file_name, string url)
    {
         await DownloadRequest(file_name, url); 
    }

    public static async Task DownloadRequest(string file_name, string url)
    {
        try
        {
            HttpClient client = new HttpClient();
            byte[] content;
            HttpResponseMessage response =  await client.GetAsync(url);



            Stream stream = await response.Content.ReadAsStreamAsync();

            using (BinaryReader br = new BinaryReader(stream))
            {
                content = br.ReadBytes((int)stream.Length);
                br.Close();
            }
            response.Dispose();//ÄÀ©ñ

            FileStream fs = new FileStream(file_name, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(content);

            }
            finally
            {
                fs.Close();
                bw.Close();
            }


        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex);
        }

        Debug.Log("¤U¸ü§¹²¦ : " + file_name);
    }
}
