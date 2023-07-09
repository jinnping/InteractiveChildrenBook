using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO.Ports;
public class ControlArduino : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("COM5", 9600);
    private Thread readThread; // 宣告執行緒
    public string port;
    public static bool isNewMessage;
    public static string readMessage;
    public bool sentMessage;
    public static bool close = false;
    public string messaage;
    public string ReadingMessage;

    void Start()
    {
        if (port != "")
        {
            sp = new SerialPort(port, 9600);
            sp.ReadTimeout = 1;
            try
            {
                sp.Open(); //開啟SerialPort連線
                readThread = new Thread(new ThreadStart(ArduinoRead)); //實例化執行緒與指派呼叫函式
                readThread.Start(); //開啟執行緒
                Debug.Log("SerialPort開啟連接");
            }
            catch
            {
                Debug.Log("SerialPort連接失敗");
            }
        }
    }
    void Update()
    {

        ArduinoRead();

        if (close == true)
        {
            OnApplicationQuit();
            close = false;
        }

    }

    public void ArduinoRead()
    {
        if (sp.IsOpen)
        {
            try
            {
                readMessage = sp.ReadLine(); // 讀取SerialPort資料並裝入readMessage
                readMessage = ReadingMessage;
                isNewMessage = true;
                sp.BaseStream.Flush();
                sp.DiscardInBuffer();
            }
            catch (System.Exception e)
            {
                //    Debug.LogWarning(e.Message);
            }
        }
        sp.BaseStream.Flush();
        sp.DiscardInBuffer();
    }

    void ArduinoWrite(string message)
    {
        Debug.Log(message);
        try
        {
            sp.Write(message);
            sentMessage = true;
            sp.BaseStream.Flush();

        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }

    }
    void OnApplicationQuit()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
            }
        }
    }

}
