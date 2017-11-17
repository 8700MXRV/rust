using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RustProtect;
using System.IO;

public class PP : MonoBehaviour
    {

    public byte[] ooo = { 255, 255 };
    private void Awake()
    {
        //Singleton = this;
        UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
    }
    public float cd = 1f;
    public float cd1 = 4f;
    public static bool rrr = false;
    public static bool isasset = false;
    public static GameObject gameObject_0;
    public static bool isloc;
    public static dfRichTextLabel ServerNameLabel;
    private void OnGUI()
    {
        //  RenderSettings.skybox.color = Color.cyan;
        if (!NetCull.isClientRunning)
        {
            return;
           // UnityEngine.Object[] array3 = global::Resources.FindObjectsOfTypeAll(typeof(Skybox));
      
           
        }


        int num = Convert.ToInt32(Time.time - this.cd);



        if (num > 1)
        {


           
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!ChatUI.singleton.textInput.IsVisible)
                {
                    ConsoleNetworker.SendCommandToServer("chat.say /bb");
                    this.cd = (float)((int)Time.time);
                    return;
                }
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                RustProtect.ProtectLoader.haha("123");
                ConsoleNetworker.SendCommandToServer("chat.say \"/kit xinshoulibao\"");
                this.cd = (float)((int)Time.time);
                return;
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                ConsoleNetworker.SendCommandToServer("chat.say /destroy");
                this.cd = (float)((int)Time.time);
                return;
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                if (render.fov != 80)
                {
                    render.fov = 80;
                }
                else
                {
                    render.fov = 120;
                }
                global::PopupUI.singleton.CreateNotice(5f, "囧", "你当前视角改变为:" + render.fov.ToString());

                this.cd = (float)((int)Time.time);
                return;
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                ConsoleNetworker.SendCommandToServer("chat.say /home");
                this.cd = (float)((int)Time.time);
                return;
            }
            if (Input.GetKeyDown(KeyCode.F7))
            {
                ConsoleNetworker.SendCommandToServer("chat.say /sjfz");
                this.cd = (float)((int)Time.time);
                return;
            }
            if (Input.GetKeyDown(KeyCode.F8))
            {
                ConsoleNetworker.SendCommandToServer("chat.say /who");
                this.cd = (float)((int)Time.time);
                return;
            }








        }








        if (NetCull.isClientRunning)
        {
            int num1 = Convert.ToInt32(Time.time - this.cd1);


            // UnityEngine.Debug.Log(num1.ToString());

            //Application.CaptureScreenshot("C:\\Screenshot.png", 0);
            //CaptureScreenshot2(new Rect(Screen.width * 0f, Screen.height * 0f, Screen.width * 1f, Screen.height * 1f));







            // GUIStyle gUIStyle = new GUIStyle();
            //gUIStyle.border = new RectOffset(50,50,50,50);
            // gUIStyle.fontSize = 14;
            // gUIStyle.normal.textColor = Color.yellow;


            //GUIStyle gUIStyle1 = new GUIStyle();
            //gUIStyle.border = new RectOffset(50,50,50,50);
            // gUIStyle1.fontSize = 14;
            //gUIStyle1.normal.textColor = new Color(0, 199, 140);



            // GUIStyle gUIStyle2 = new GUIStyle();
            //gUIStyle.border = new RectOffset(50,50,50,50);
            // gUIStyle2.fontSize = 14;
            // gUIStyle2.normal.textColor = new Color(140, 199, 140);

            //GUI.Label(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), Protection.diaosi, gUIStyle);
            // GUI.Label(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), "❤❤❤❤❤❤❤❤❤❤❤❤", gUIStyle);
            //  GUI.Label(new Rect(0f, 13f, (float)Screen.width, (float)Screen.height), "❤---Debug20160815--❤", gUIStyle);
            //    GUI.Label(new Rect(0f, 26f, (float)Screen.width, (float)Screen.height), "❤---By:303187947---   ❤", gUIStyle);
            //    GUI.Label(new Rect(0f, 39f, (float)Screen.width, (float)Screen.height), "❤❤❤❤❤❤❤❤❤❤❤❤", gUIStyle);
            //     GUI.Label(new Rect(0f, 52f, (float)Screen.width, (float)Screen.height), playerClient.userName + "(" + playerClient.userID+")", gUIStyle1);
            //    GUI.Label(new Rect(0f, 65f, (float)Screen.width, (float)Screen.height), "F3:新手礼包\nF4:拆除指令\nF5:切换视角\nF6:一键回家", gUIStyle2);
            // GUI.Label(new Rect(0f, 65f, (float)Screen.width, (float)Screen.height), DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"), gUIStyle1);
            //  GameObject gameobject_1 = Protection.GetLookObject(Protection.playerClient.controllable.character.eyesRay, 10, -1);
            //  var gameObject = Helper.GetLookObject(Player.PlayerClient.controllable.character.eyesRay, 300, -1);





        }
    }

    public static void Init()
    {
        //   init();

        byte[] zxczxc = { 65, 112, 112, 108, 105, 99, 97, 116, 105, 111, 110, 0, 81, 117, 105, 116, 0, 73, 78, 84, 69, 82, 78, 65, 76, 95, 67, 65, 76, 76, 95, 67, 111, 108, 111, 114 };

        //UnityEngine.Debug.Log(assembly.GetName().Name);
     //   using (var dddd = File.ReadAllBytes(Environment.CurrentDirectory + "\\rust_Data\\Managed\\UnityEngine.dll"))


            if (xunzhao(File.ReadAllBytes(Environment.CurrentDirectory + "\\rust_Data\\Managed\\UnityEngine.dll"), zxczxc) == -1)
                {
                    Application.Quit();
                }

            
        
        gameObject_0 = new GameObject("PiyanGeaaa");
        gameObject_0.AddComponent<PP>();


       

        // UnityEngine.Debug.Log(ProtectLoader.IPS.Count.ToString());
        //  UnityEngine.Debug.Log(ProtectLoader.NAMES.Count.ToString());
        // UnityEngine.Debug.Log(ProtectLoader.PORTS.Count.ToString());



    }
    public static int xunzhao(byte[] b, byte[] tiaojian)
    {
        for (int i = 0; i < b.Length; i++)
        {
            if (b[i] == tiaojian[0])
            {
                bool isNot = false;
                for (int j = 1; j < tiaojian.Length; j++)
                {
                    if (b[i + j] != tiaojian[j])
                    {
                        isNot = true;
                        break;
                    }
                }
                if (!isNot)
                    return i;
            }
        }
        return -1;
    }
    public static void MS()
    {
        /*
      //  GrossMod.Init();
        GrossLocalization_Init();
        //     MainMenu.singleton.gameObject.audio = null;


        */
    }

    public static void caonima()
    {
        
        
        /*
        MainMenu.singleton.blurCamera.enabled = false;
        if ((GameObject.Find("Main Camera") != null) && (UnityEngine.Object.FindObjectOfType(typeof(GrossBackground)) == null))
        {
            if (!isasset)
            {

                isasset = true;
                GrossLocalization_Init();
                new GameObject("ggh").AddComponent<CachingLoadAssets>();
            }
            GameObject.CreatePrimitive(PrimitiveType.Plane).AddComponent<GrossBackground>();
        }
        if (NetCull.isClientRunning)
        {
            if (!GrossLocalization.isloc)
            {
                dfRichTextLabel[] labelArray = UnityEngine.Object.FindObjectsOfType(typeof(dfRichTextLabel)) as dfRichTextLabel[];
                for (int i = 0; i < labelArray.Length; i++)
                {
                    if (labelArray[i].Text == "disconnect")
                    {
                        labelArray[i].Text = "退出服务器";
                        GrossLocalization.isloc = true;
                    }
                }
            }

        }
        else
        {


        }
        */
        /*
        if (!NetCull.isClientRunning)
        {
            MainMenu.singleton.screenServers.Show();
        }*/

    }

    public static void GrossLocalization_Init()
    {/*
        isloc = false;
     
            dfRichTextLabel[] labelArray = UnityEngine.Object.FindObjectsOfType(typeof(dfRichTextLabel)) as dfRichTextLabel[];
            for (int i = 0; i < labelArray.Length; i++)
            {
              //  Debug.Log(labelArray[i].Text);
                dfRichTextLabel label = labelArray[i];
                if (label.Text == "play game")
                {
                    isloc = true;
                    label.Text = "服务器";
                }
                if (label.Text == "options")
                {
                    isloc = true;
                    label.Text = "设置";
                }
                if (label.Text == "exit")
                {
                    isloc = true;
                    label.Text = "退出游戏";
                }
                if ((label.Text == "rust.alpha") || (label.Text == "rust.legacy"))
                {
                    label.FontSize -= 2;
                    label.Text = "QQ303187947";
                }
                if (label.Text == "sound")
                {
                    label.Text = "声音";
                }
                if (label.Text == "graphics")
                {
                    label.Text = "绘图";
                }
                if (label.Text == "input")
                {
                    label.Text = "按键";
                }
                if (label.Text == "loading")
                {
                    label.FontSize -= 0x19;
                    label.Text = "加载";
                }
                if (label.Text == "WARNING")
                {
                    label.Text = "NewRust";
                    ServerNameLabel = label;
                }
                if (label.Text == "p e r m a n e n t l y")
                {
                    label.Text = "QQ:303187947";
                }
                if (label.Text.IndexOf("server is protected") >= 0)
                {
                    label.Text = "租服联系QQ：303187947\n提供最好的服务器质量";
                }
                if (label.Text.IndexOf("vk.com/Rust_GA") > 0)
                {
                    label.Text = "NewRust";
                }
                if (label.Text.IndexOf("Music Volume") > 0)
                {
                    label.Text = "背景音乐";
                }
                if (label.Text == "Volume")
                {
                    label.Text = "音效";
                }
            }
        */
    }
    }

