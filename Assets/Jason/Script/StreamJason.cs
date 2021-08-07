using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;//Io 代表 Input Output
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO.Compression;

public class StreamJason : MonoBehaviour
{
    /**
     * https://dotblogs.com.tw/kinanson/2017/06/03/142558#2
     * https://dotblogs.com.tw/kinanson/2017/06/03/142558#1
     Stream為抽象类
     提供 位元組序列的一般檢視 
    Byte = 位元組= 00000000、00000001 ~ 11111111，2^8(256)種狀態
     位元組序列指的是:
        位元組(Byte)物件都被儲存在其中,位元組按照一定的順序進行排序組成了位元組序列
    
    可以理解成Byte[] 且順序進行排序

    Stream 的抽象屬性和屬性方法
           1:  CanRead: 只讀屬性,判斷該流是否能夠讀取:

           2:  CanSeek: 只讀屬性,判斷該流是否支援跟蹤查詢

           3:  CanWrite: 只讀屬性,判斷當前流是否可寫

     void Flush():  當我們使用stream寫檔案時,資料流會先進入到緩衝區中,而不會立刻寫入檔案,當執行這個方法後,緩衝區的資料流會立即注入基礎流

     Position屬性:Position屬性只是標示了流中的一個位置

    stream 主要用法:
        StreadReader(讀取檔案內容)
        StreamWrite(寫入檔案內容)
        StringReader(讀取字串)
        StringWrite(寫入字串)
        FileStream
        DeflateStream(壓縮用，無法用winzip解壓縮)
        GZipStream 類別(壓縮用，可供winzip解壓縮)
        MemoryStream 內存Stream

    讀寫記憶體-MemoryStream類
        MemoryStream，有時候我們在處理資料的時候，就會產生所謂的Stream，但我們不想保存資料在實體位置的時候，就需要把資料暫存在memory裡面，等用戶端保存後此memory就要清空
        可用地方:將數據發送到網路之前的加密過程，將一個大檔案下載下來等等 ，使用,memary可以將 文件 分塊，文件中的bytes(資料) 可以存至內存，而不是一次將整個檔案加載到Ram
    */


    //using(類型= 區域變數){區域變數範圍}
    void Start()
    {
         
        //StreamReader(); 
         //StreamWriter();
        StringReader();
        //StringWriter();
        //FileStream();
        // MemoryStreamTest();
        //GZipStream();
        //MemoryStreamCreate();
        //ReadByte();

    }

    // Update is called once per frame
    void Update()
    {

    }
    #region StreamReader 方法
    void StreamReader()
    {
        string path = @"D:\texttest\texttest.txt"; //創建讀取文件的路徑
                                                       //文件流的讀
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
        //尋找路徑，打開方式，打開後操作（讀，寫），
        //使用using不用考慮是否關閉文件流，是否釋放資源，using裏面自動釋放資源
        {
            using (StreamReader sr = new StreamReader(fs, Encoding.Default))
            {
                //bool result = sr.EndOfStream;           //是否讀到文件末尾
                //Debug.Log(sr.ReadLine());       //只讀取文本文檔的第一行
                //Debug.Log(sr.ReadToEnd());      // 從頭到尾的讀取
                //從頭讀到末尾的另一種方法
                while (!sr.EndOfStream)                //判斷是否到文件流末尾
                {
                   Debug.Log(sr.ReadLine());  //如果沒有到末尾繼續讀
                }
            }
        }
        
    }
    #endregion
    #region StreamWriter 方法
    void StreamWriter()
    {
        ////取得C槽所有目錄夾的所有資料夾名稱
        //DirectoryInfo[] cDirs = new DirectoryInfo(@"D:\").GetDirectories();

        //// 寫進哪個目的地
        //using (StreamWriter sw = new StreamWriter(@"D:\texttest\texttest.txt"))//將所有名子寫入txt
        //{
        //    foreach (DirectoryInfo dir in cDirs)
        //    {
        //        sw.WriteLine(dir.Name);

        //    }
        //}


        //string line = "";
        //using (StreamReader sr = new StreamReader(@"D:\texttest\texttest.txt"))
        //{
        //    while ((line = sr.ReadLine()) != null)
        //    {
        //        Debug.Log(("StreamWriter : " + line));
        //    }
       // }
        //-----------------------------------------------------------------------------
        //文件流的寫
        string path = @"D:\texttest\texttest.txt";
        
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.Write))///存在stream後拿來寫
        {

            using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
            {
                sw.Write("哈哈哈");
            }
        }
        using (StreamWriter sw = new StreamWriter(path, true,Encoding.Default))//append 代表 要不要覆蓋整個文件
        {
            sw.Write("哈哈哈");
        }

    }
    #endregion
    #region StringReader 方法
    /// <summary>
    /// 在string 專案中有更詳細解釋
    /// </summary>
    async void StringReader()
    {
        string message = @"Characters in 1st line to read
            and 2nd line
            and the end";

        using (StringReader reader = new StringReader(message))
        {
            //string readText = await reader.ReadToEndAsync();//等待全部讀完 
            //Debug.Log(readText);
            int index = 0;
            Debug.Log(reader.ReadLine());
            while (reader.ReadLine() != null) {
                index++;
                Debug.Log(index); 
            }
            Debug.Log(reader.ReadLine());
        }

    }
    #endregion
    #region StringWriter 方法
    async void StringWriter()
    {
        string textReaderText = "資質低落的條件下，只能比別人更努力了";

        Debug.Log($"原本的字串:{textReaderText}");

        StringWriter strWriter = new StringWriter();
        StringReader strReader = new StringReader(textReaderText);
        string line = string.Empty;
        strWriter.Write("新進工程師 ");
        while ((line = strReader.ReadLine()) != null)
        {
            await strWriter.WriteAsync(line);

        }
        Debug.Log($"修改後的字串:{strWriter}");

    }
    #endregion

    #region FIleStream方法

    async void FileStream()
    {
        string path = @"D:\texttest\texttest.txt";
        if (File.Exists(path))//判斷有無此檔
        {
            File.Delete(path);//刪除某檔案
        }
        //創建檔
        using (FileStream fs = File.Create(path))
        {
            await AddText(fs, "Hello");//放入文字
            await AddText(fs, "This is some more text,");
            await AddText(fs, "\r\nand this is on a new line");
            await AddText(fs, "\r\n\r\nThe following is a subset of characters:\r\n");
        }
        using (FileStream fs = File.OpenRead(path))//開啟現有檔案來讀取
        {
            byte[] b = new byte[1024]; //這邊代表的是每行讀取的字元
            UTF8Encoding temp = new UTF8Encoding(true);
            while (fs.Read(b, 0, b.Length) > 0)//從資料流讀取位元組區塊，並將資料寫入指定緩衝區。
            {
                Debug.Log(temp.GetString(b));//取得字串
            }
        }
    }
    async Task AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        await fs.WriteAsync(info, 0, info.Length);//寫入
    }
    #endregion
    #region 壓縮檔
    void GZipStream() {
        //------------壓縮檔案
        string path = @"D:\ziptest\examplefile.gz";
        byte[] bytesToCompress = Encoding.UTF8.GetBytes("你好我叫Jason");//轉成byte[]
        foreach(var data in bytesToCompress)
            Debug.Log(data.ToString());
        using (FileStream fileToCompress = File.Create(path))
        {
            using (GZipStream compressionStream = new GZipStream(fileToCompress, CompressionMode.Compress))//壓縮
            {
                compressionStream.Write(bytesToCompress, 0, bytesToCompress.Length);
            }
        }
        //------------解壓縮檔案
        byte[] decompressedBytes = new byte[bytesToCompress.Length];
        using (FileStream fileToDecompress = File.OpenRead(path))
        {
            using (GZipStream decompressionStream = new GZipStream(fileToDecompress, CompressionMode.Decompress))//解壓縮
            {
                decompressionStream.Read(decompressedBytes, 0, bytesToCompress.Length);
            }
        }
        char[] charArray = new char[Encoding.UTF8.GetCharCount(decompressedBytes, 0, decompressedBytes.Length)];
        Encoding.UTF8.GetDecoder().GetChars(decompressedBytes, 0, decompressedBytes.Length, charArray, 0);
        string s = new string(charArray); 
        Debug.Log("存入字串為 :  " +s);

    }
    #endregion


    #region MemoryStreamTest 方法
    async void MemoryStreamTest()
    {
        string strtxt = "Hello my name is Jason";
        byte[] bytetxt = Encoding.UTF8.GetBytes(strtxt);//將文字轉成utf8編碼 
        MemoryStream memstream = new MemoryStream();//創建memary流
        Debug.Log($"memstream容量為 : {memstream.Capacity} , Position 為 { memstream.Position}");
        await Task.Run(() =>
        {
            memstream.Write(bytetxt, 0, bytetxt.Length);//寫入memary

        });

        Debug.Log("寫入完畢");
        Debug.Log($"memstream容量為 : {memstream.Capacity} , Position 為 { memstream.Position}");
        memstream.Seek(0, SeekOrigin.Begin);//重新定義position
        Debug.Log($"memstream容量為 : {memstream.Capacity} , Position 為 { memstream.Position}");

        byte[] byteArray = new byte[memstream.Length];
        int count = memstream.Read(byteArray, 0, byteArray.Length);
        Debug.Log(count);
        // Read the remaining bytes, byte by byte.
        while (count < memstream.Length)
        {
            byteArray[count++] = Convert.ToByte(memstream.ReadByte());
        }
        char[] charArray = new char[Encoding.UTF8.GetCharCount(byteArray, 0, count)];
        Encoding.UTF8.GetDecoder().GetChars(byteArray, 0, count, charArray, 0);
        string s = new string(charArray);
        Debug.Log(s);

        //Debug.Log("現在Stream.Postion在第{0}位置"+ memstream.Position); 
        //Debug.Log(memstream.CanRead);      //True  記憶體流可讀
        //Debug.Log(memstream.CanSeek);      //True  記憶體流支援查詢，指標移來移去的查詢
        //Debug.Log(memstream.CanTimeout);   //False 記憶體流不支援超時
        //Debug.Log(memstream.CanWrite);     //True  記憶體流可寫 
    }

    async void MemoryStreamCreate()//創建文件並寫入
    {
        string path = @"D:\texttest\MemoryStream.txt";
        if (!File.Exists(path))//判斷有無此檔
        { 
        string memString = "哈囉 我叫 Jason 此為MemoryStreamhk !!";
        // convert string to stream
        byte[] buffer = Encoding.UTF8.GetBytes(memString);
        MemoryStream ms = new MemoryStream(buffer);//跟底下差不多
       // MemoryStream ms = new MemoryStream(); 
        //ms.Write(buffer, 0, buffer.Length);
        //write to file
        FileStream file = File.Create(path);
        ms.WriteTo(file);
        file.Close();
        ms.Close();
        }
        //////////接收資料
        FileStream fs = File.OpenRead(path);
        MemoryStream GetmsStream = new MemoryStream();
        byte[] bytetxt = new byte[fs.Length];
        fs.CopyTo(GetmsStream);
        int count = GetmsStream.Read(bytetxt, 0, bytetxt.Length) ;
        Debug.Log(count);
        GetmsStream.Seek(0, SeekOrigin.Begin);//每次放完記得position設0
        fs.Close();
        await Task.Run(() =>
        {
            while (count < GetmsStream.Length)
            {
                bytetxt[count] = Convert.ToByte(GetmsStream.ReadByte());//GetmsStream.ReadByte( 讀每個數組
                count++;
            } 
        });
        char[] charArray = new char[Encoding.UTF8.GetCharCount(bytetxt, 0, count)];
        Encoding.UTF8.GetDecoder().GetChars(bytetxt, 0, count, charArray, 0);
        string s = new string(charArray);
        Debug.Log(s);
    }

    void MemoryStreamDownload() {
        MemoryStream stream = new MemoryStream();
      
    }
    #endregion
    void ReadByte() {
        string a = "Hellow world";
        byte[] GetDataByte = Encoding.UTF8.GetBytes(a);
        MemoryStream GetmsStream = new MemoryStream(GetDataByte);
        GetmsStream.Seek(0, SeekOrigin.Begin);
        Debug.Log("read 之前 : "+ GetmsStream.Length);
        for (int i = 0; i < GetmsStream.Length; i++) {
            Debug.Log("ReadByte : " + GetmsStream.ReadByte());
        } 
        // Debug.Log("ReadByte : " + GetmsStream.ReadByte());
        Debug.Log("read 之後 : " + GetmsStream.Length);
    }
}
