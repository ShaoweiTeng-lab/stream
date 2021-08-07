using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
public class Jaosndirectory : MonoBehaviour
{
    /*
     https://www.youtube.com/watch?v=9mUuJIKq40M 
     string[] dir =Directory.GetDirectories(path);//取得該路徑下的資料夾路徑+名稱
     DirectoryInfo[] cDirs =    new DirectoryInfo(path).GetDirectories();//取得資料夾 名稱
     */
    string path = @"D:\texttest";
    // Start is called before the first frame update
    void Start()
    {
        ShowDirectory();
        //GetDirectoryFiles();
        //CreateFiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 取得資料夾名稱方法
    /// </summary>
    void ShowDirectory() {
        //----------------------------------------------取得資料夾 名稱
        //DirectoryInfo[] cDirs = new DirectoryInfo(path).GetDirectories();//取得資料夾 名稱

        //foreach (DirectoryInfo dirget in cDirs)
        //{
        //    Debug.Log(dirget.GetFiles(path));//資料夾名稱

        //}
        //------------------------------/取得該路徑下的資料夾路徑

        string[] dir = Directory.GetDirectories(path);//取得該路徑下的資料夾路徑+名稱
        //foreach (var dirget in dir)
        //{
        //    Debug.Log(dirget);//取得資料夾資料夾路徑+名稱

        //}
        foreach (string dirget in dir)
        {
            // Debug.Log(Path.GetFileName(dirget));//取得資料夾名稱+副檔名
            // Debug.Log(Path.GetFileNameWithoutExtension(dirget));//取得資料夾名稱 -副檔名
            //Debug.Log(Path.GetFullPath(dirget));//取得該路徑下的資料夾路徑

            var fileinfo = new FileInfo(dirget);
            Debug.Log($"{Path.GetFileName(dirget)} :  {fileinfo.Length} bytes");//取得該文件長度
        }
        //-----------------------------------------------------------------------------------------------------------------

        //---------------------------------取得該路徑下的資料夾 及所有子資料夾--------------
        //string[] dir = Directory.GetDirectories(path,"*",SearchOption.AllDirectories);
        //foreach (var data in dir)
        //{
        //    Debug.Log(data);

        //}
        //---------------------------------取得該路徑下的資料夾(符合該名稱)-------------
        //DirectoryInfo[] cDirs = new DirectoryInfo(path).GetDirectories("abc");
        //foreach (DirectoryInfo dirget in cDirs)
        //{
        //    Debug.Log(dirget.Name);

        //}
        //---------------------------------取得該路徑下的資料夾  及所有子資料夾-------------
        //DirectoryInfo[] cDirs = new DirectoryInfo(path).GetDirectories("*", SearchOption.AllDirectories); 
        //foreach (DirectoryInfo dirget in cDirs)
        //{
        //    Debug.Log(dirget.Name);

        //}
    }
    /// <summary>
    /// 取得資料夾底下之文件方法
    /// </summary>
    void GetDirectoryFiles() {
        //---------------------------------取得該路徑下所有文件  (包含子資料夾)--------------
        //string [] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories); // 取得 路徑+名稱
        //foreach (var data in files)
        //{
        //    Debug.Log(data);

        //}
        FileInfo [] files = new DirectoryInfo(path).GetFiles("*", SearchOption.AllDirectories);// 取得 名稱
        foreach (var data in files)
        {
            Debug.Log(data.Name);

        }

        //---------------------------------取得該路徑下所有文件(不包含子資料夾)--------------
        //var files = new DirectoryInfo(path).GetFiles("*", SearchOption.TopDirectoryOnly);
        //foreach (var data in files)
        //{
        //    Debug.Log(data.Name);

        //}
    }


    void CreateFiles() {
        string NewDirectoryPath= @"D:\texttest\JasonNewDirectory\";
        FileInfo fileInfo = new FileInfo(NewDirectoryPath);
        if (!fileInfo.Directory.Exists)
        {   Debug.Log("JasonNewDirectory    exists");
            Directory.CreateDirectory(fileInfo.Directory.FullName);
        }

    }
}
