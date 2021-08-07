using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
public class Jaosndirectory : MonoBehaviour
{
    /*
     https://www.youtube.com/watch?v=9mUuJIKq40M 
     string[] dir =Directory.GetDirectories(path);//���o�Ӹ��|�U����Ƨ����|+�W��
     DirectoryInfo[] cDirs =    new DirectoryInfo(path).GetDirectories();//���o��Ƨ� �W��
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
    /// ���o��Ƨ��W�٤�k
    /// </summary>
    void ShowDirectory() {
        //----------------------------------------------���o��Ƨ� �W��
        //DirectoryInfo[] cDirs = new DirectoryInfo(path).GetDirectories();//���o��Ƨ� �W��

        //foreach (DirectoryInfo dirget in cDirs)
        //{
        //    Debug.Log(dirget.GetFiles(path));//��Ƨ��W��

        //}
        //------------------------------/���o�Ӹ��|�U����Ƨ����|

        string[] dir = Directory.GetDirectories(path);//���o�Ӹ��|�U����Ƨ����|+�W��
        //foreach (var dirget in dir)
        //{
        //    Debug.Log(dirget);//���o��Ƨ���Ƨ����|+�W��

        //}
        foreach (string dirget in dir)
        {
            // Debug.Log(Path.GetFileName(dirget));//���o��Ƨ��W��+���ɦW
            // Debug.Log(Path.GetFileNameWithoutExtension(dirget));//���o��Ƨ��W�� -���ɦW
            //Debug.Log(Path.GetFullPath(dirget));//���o�Ӹ��|�U����Ƨ����|

            var fileinfo = new FileInfo(dirget);
            Debug.Log($"{Path.GetFileName(dirget)} :  {fileinfo.Length} bytes");//���o�Ӥ�����
        }
        //-----------------------------------------------------------------------------------------------------------------

        //---------------------------------���o�Ӹ��|�U����Ƨ� �ΩҦ��l��Ƨ�--------------
        //string[] dir = Directory.GetDirectories(path,"*",SearchOption.AllDirectories);
        //foreach (var data in dir)
        //{
        //    Debug.Log(data);

        //}
        //---------------------------------���o�Ӹ��|�U����Ƨ�(�ŦX�ӦW��)-------------
        //DirectoryInfo[] cDirs = new DirectoryInfo(path).GetDirectories("abc");
        //foreach (DirectoryInfo dirget in cDirs)
        //{
        //    Debug.Log(dirget.Name);

        //}
        //---------------------------------���o�Ӹ��|�U����Ƨ�  �ΩҦ��l��Ƨ�-------------
        //DirectoryInfo[] cDirs = new DirectoryInfo(path).GetDirectories("*", SearchOption.AllDirectories); 
        //foreach (DirectoryInfo dirget in cDirs)
        //{
        //    Debug.Log(dirget.Name);

        //}
    }
    /// <summary>
    /// ���o��Ƨ����U������k
    /// </summary>
    void GetDirectoryFiles() {
        //---------------------------------���o�Ӹ��|�U�Ҧ����  (�]�t�l��Ƨ�)--------------
        //string [] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories); // ���o ���|+�W��
        //foreach (var data in files)
        //{
        //    Debug.Log(data);

        //}
        FileInfo [] files = new DirectoryInfo(path).GetFiles("*", SearchOption.AllDirectories);// ���o �W��
        foreach (var data in files)
        {
            Debug.Log(data.Name);

        }

        //---------------------------------���o�Ӹ��|�U�Ҧ����(���]�t�l��Ƨ�)--------------
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
