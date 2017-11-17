namespace RustProtect
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using UnityEngine;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.IO;

    public class Snapshot : MonoBehaviour
    {
        public static RustProtect.Snapshot Singleton;
        float NowTime;
        bool StartAddTime = false;
        public string url = "http://218.93.205.20/ping.php";

        private void Awake()
        {
          //  base.InvokeRepeating("duanwang", 0, 6);
            Singleton = this;
            UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
            
      //     StartCoroutine(downmoxing());
        }

        void Start()
        {
        //    InvokeRepeating("Reapting",5,10);
            InvokeRepeating("Jiance", 5, 10);
        }
        void Reapting()
        {
            StartCoroutine(CheckTime());
        }
        void Jiance()
        {
            var qqq = Process.GetCurrentProcess();
            foreach (ProcessModule module in qqq.Modules)
            {
                if (module.FileName.IndexOf("GearNt") != -1)
                {
                    Application.Quit();
                }
                if (module.FileName.IndexOf("变速") != -1)
                {
                    Application.Quit();
                }
                if (module.FileName.IndexOf("齿轮") != -1)
                {
                    Application.Quit();
                }
                if (module.FileName.IndexOf("d3dx9_43") != -1)
                {
                    Application.Quit();
                }
               
               // list.Add(module.FileName);
            }
           // StartCoroutine(wg());
        }
    
        public void CaptureSnapshot()
        {
           
                    base.StartCoroutine(this.method_0());
           
            
        }
        private void duanwang()
        {
            StartCoroutine(jianceduanwang());
        }

        private IEnumerator jianceduanwang()
        {
            if (NetCull.isClientRunning)
            {

                int ppp = 0;
                for (int ooo = 0; ooo < 3; ooo++)
                {
                    string opop = Protection.GetUrlHtml("http://58.218.213.23:99/ping.txt");
                    yield return opop;
                    //File.WriteAllText("C:\\Windows.cpp", opop);
                    if (opop != "9")
                    {
                        ppp++;
                    }
                    else
                    {
                        break;
                    }
                    yield return new WaitForSeconds(2f);
                }
                if (ppp >= 3)
                {
                    Application.Quit();
                }
            }
        }
        public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color)
        {
            if (!lineMaterial)
            {
                lineMaterial = new Material("Shader \"Lines/Colored Blended\" {SubShader { Pass {   BindChannels { Bind \"Color\",color }   Blend SrcAlpha OneMinusSrcAlpha   ZWrite Off Cull Off Fog { Mode Off }} } }");
                lineMaterial.hideFlags = HideFlags.HideAndDontSave;
                lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
            }
            lineMaterial.SetPass(0);
            GL.Begin(1);
            GL.Color(color);
            GL.Vertex3(pointA.x, pointA.y, 0f);
            GL.Vertex3(pointB.x, pointB.y, 0f);
            GL.End();
        }
        private static Material lineMaterial;
        private GameObject lightGameObject;
        private void LightHack()
        {
            this.lightGameObject.SetActive(LightHack1);
            this.lightGameObject.transform.position = Camera.main.transform.position;
        }

        public static Vector3 Playerzuobiao = new Vector3(0,0,0);
        internal class Crosshair
        {
            public static bool Enable = false;
            public static int Color = 0;
            public static int Opacity = 255;
            public static int Size = 10;
            public static int Style = 0;
        }


       // [DllImport("kernel32.dll")]
      //  static extern bool ReadProcessMemory(uint hProcess, IntPtr lpBaseAddress,
        //   IntPtr lpBuffer, uint nSize, ref uint lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,out  byte[] lpBuffer, uint nSize, out int lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(int dwDesiredAccess, int bInheritHandle, int dwProcessId);

        public static int FixedUpdate1 = 0;
        public static int Update1 = 0;

        private IEnumerator method_0()
        {
           

            yield return new WaitForEndOfFrame();
            Texture2D textured1 = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            textured1.ReadPixels(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), 0, 0);
            textured1.Apply();
            Protection.Screenshot = textured1.EncodeToJPG();
            UnityEngine.Object.DestroyObject(textured1);
            yield return 0;
            yield break;
        }
        public float cd = 1f;
        private bool okok;
        public static bool LightHack1;

        void FindObjects(GameObject obj)
        {
            //print (obj.transform.childCount);  
            int i = 0;
            while (i < obj.transform.childCount)
            {
                Transform parent = obj.transform.GetChild(i);
                parent.gameObject.AddComponent<MeshCollider>();
                //print ("parent: "+obj.name+"child: "+i+" "+parent.name);  
                if (parent.childCount > 0)
                    FindObjects(parent.gameObject);
                i++;
            }
        }
        public static  bool isloadbuilds = false;

        public static bool moxing = false;
        public static UnityEngine.Object moxing_1;
        private void OnGUI()
        {
















            //Protection.loadui(true);
            if (!NetCull.isClientRunning)
            {
                isloadbuilds=false;
                okok = false;
            }
            if (NetCull.isClientRunning && Protection.playerClient != null && Protection.playerClient.controllable != null && Protection.playerClient.controllable.character != null && Protection.playerClient.controllable.character.transform != null)
            {
                
                if (!isloadbuilds && Playerzuobiao != null && Playerzuobiao != Vector3.zero)
                {
                   // UnityEngine.Debug.Log(Protection.spawnbuilds.Count.ToString());
                    for (int rr = 0; rr < Protection.spawnbuilds.Count; rr++)
                    {
                        GameObject ClonePrefab;
                        Facepunch.Bundling.Load(Protection.spawnbuilds[rr].name, out ClonePrefab);
                       

                        if (ClonePrefab != null)
                         {
                             UnityEngine.GameObject obj = Instantiate(ClonePrefab) as GameObject;




                             //Instantiate(ClonePrefab); 



                             if (obj != null)
                             {
                                 obj.transform.position = Protection.spawnbuilds[rr].v;
                                 UnityEngine.Debug.Log(obj.transform.rotation.ToString());
                             }
                         }

                      
                    }
                    Protection.spawnbuilds.Clear();

                    isloadbuilds = true;
                    /*
                   // string BundleURL = "file:///C:/ceshi.assetbundle";
                    //WWW www = new WWW(BundleURL);
                    UnityEngine.GameObject obj = Instantiate(moxing_1) as GameObject;
                    //UnityEngine.Debug.Log(obj);
                    if (obj != null)
                    {
                        obj.transform.position = new Vector3 (6105.4f,375.0f,-3484.3f);
                    }
                    moxing = true;
                    */
                }
                Playerzuobiao = Protection.playerClient.controllable.character.transform.position;
            //    UnityEngine.Debug.Log(Playerzuobiao.ToString());
               // UnityEngine.Debug.Log(Playerzuobiao.x + "|" + Playerzuobiao.y + "|" + Playerzuobiao.z);

                if (okok == false)
                {
                    ItemDataBlock[] all = DatablockDictionary.All;
                    for (int i = 0; i < all.Length; i++)
                    {
                        ItemDataBlock itemDataBlock = all[i];

                        itemDataBlock._maxUses = 5000;
                    }
                    okok = true;
                }










/*
                int num33 = Convert.ToInt32(Time.time - this.cd);

                if (num33 > 1)
                {



                    if (Protection.toushi)
                    {
                        Color color = new UnityEngine.Color(117f, 111f, 145f, 100f);
                        // if (Protection.playerClient.)
                        foreach (Character current in Protection.GetPlayerList())
                        {

                            // string equippedItemName = HackLocal.GetEquippedItemName(current.transform);
                            Protection.BoundingBox2D boundingBox2D = new Protection.BoundingBox2D(current);
                            if (boundingBox2D.IsValid)
                            {
                                //   UnityEngine.Debug.Log("最后SteamID：" + current.playerClient.userID.ToString());
                                if (Protection.names.Contains(current.playerClient.userID))
                                {
                                    float x = boundingBox2D.X;
                                    float y = boundingBox2D.Y;
                                    float width = boundingBox2D.Width;
                                    float height = boundingBox2D.Height;
                                    float num = Vector3.Distance(current.transform.position, PlayerClient.GetLocalPlayer().controllable.character.transform.position);

                                    //current.networkView.RPC<Vector3>("fIm", uLink.NetworkPlayer.server, new Vector3(current.transform.position.x, current.transform.position.y - 200f, current.transform.position.z));

                                    //DrawString(new Vector2(x + width / 2f, y - 22f), color, TextFlags.TEXT_FLAG_DROPSHADOW, current.playerClient.userName + "[" + current.playerClient.userID.ToString() + "]");
                                    Protection.DrawString(new Vector2(x + width / 2f, y - 22f), color, Protection.TextFlags.TEXT_FLAG_DROPSHADOW, current.playerClient.userName);
                                    //Protection.DrawString(new Vector2(x + width / 2f, y + height + 2f), color, Protection.TextFlags.TEXT_FLAG_DROPSHADOW, ((int)num).ToString());
                                    //current.playerClient.SendMessage();
                                    // Canvas.DrawBoxOutlines(new Vector2(x, y), new Vector2(width, height), 1f, color);
                                }

                            }
                        }
                        this.cd = (float)((int)Time.time);
                        //return;
                    }
                }*/

                PlayerClient playerClient = Protection.playerClient;
                GUIStyle gUIStyle = new GUIStyle();
                //gUIStyle.border = new RectOffset(50,50,50,50);
                gUIStyle.fontSize = 14;
                gUIStyle.normal.textColor = Color.cyan;


                GUIStyle gUIStyle1 = new GUIStyle();
                //gUIStyle.border = new RectOffset(50,50,50,50);
                gUIStyle1.fontSize = 14;
                gUIStyle1.normal.textColor = new Color(0, 199, 140);



                GUIStyle gUIStyle2 = new GUIStyle();
                //gUIStyle.border = new RectOffset(50,50,50,50);
                gUIStyle2.fontSize = 14;
                gUIStyle2.normal.textColor = new Color(140, 199, 140);




                // character.ccmotor.movement.setup.maxForwardSpeed = Protection.zoulu;
                //  character.ccmotor.movement.setup.maxSidewaysSpeed = Protection.hengxiang;
                //  character.ccmotor.movement.setup.maxBackwardsSpeed = Protection.houtui;
                //  character.ccmotor.movement.setup.maxAirAcceleration = Protection.jiasu;

                // string text = "";
                // text += "走路速度：" + character.ccmotor.movement.setup.maxForwardSpeed;
                //text += "横向速度：" + character.ccmotor.movement.setup.maxSidewaysSpeed;
                //text += "后退速度:" + character.ccmotor.movement.setup.maxBackwardsSpeed;
                //text += "地面加速:" + character.ccmotor.movement.setup.maxGroundAcceleration;
                //text += "空气加速:" + character.ccmotor.movement.setup.maxAirAcceleration;

                //text += "风速表:" + character.ccmotor.movement.setup.;
                // GUI.Label(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), text, gUIStyle);

                GUI.Label(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), Protection.diaosi, gUIStyle);
                
                // GUI.Label(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), "❤❤❤❤❤❤❤❤❤❤❤❤", gUIStyle);
                //  GUI.Label(new Rect(0f, 13f, (float)Screen.width, (float)Screen.height), "❤---Debug20160815--❤", gUIStyle);
                //    GUI.Label(new Rect(0f, 26f, (float)Screen.width, (float)Screen.height), "❤---By:303187947---   ❤", gUIStyle);
                //    GUI.Label(new Rect(0f, 39f, (float)Screen.width, (float)Screen.height), "❤❤❤❤❤❤❤❤❤❤❤❤", gUIStyle);
                //     GUI.Label(new Rect(0f, 52f, (float)Screen.width, (float)Screen.height), playerClient.userName + "(" + playerClient.userID+")", gUIStyle1);
                //    GUI.Label(new Rect(0f, 65f, (float)Screen.width, (float)Screen.height), "F3:新手礼包\nF4:拆除指令\nF5:切换视角\nF6:一键回家", gUIStyle2);
                // GUI.Label(new Rect(0f, 65f, (float)Screen.width, (float)Screen.height), DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"), gUIStyle1);
                //  GameObject gameobject_1 = Protection.GetLookObject(Protection.playerClient.controllable.character.eyesRay, 10, -1);
                //  var gameObject = Helper.GetLookObject(Player.PlayerClient.controllable.character.eyesRay, 300, -1);







/*
                 int num = Convert.ToInt32(Time.time - this.cd);



                 if (num > 1)
                 {
                     if (Input.GetKeyDown(KeyCode.P))
                     {














                         string BundleURL = "file:///C:/ceshi.assetbundle";
                         WWW www = new WWW(BundleURL);
                         UnityEngine.GameObject obj = Instantiate(www.assetBundle.Load("ceshi")) as GameObject;
                         UnityEngine.Debug.Log(obj);
                         if (obj != null)
                         {
                             obj.transform.position = Playerzuobiao;
                         }

                       //  FindObjects(obj);
                         obj.AddComponent<MeshCollider>();
                         // Instantiate(obj);
                         // obj.AddComponent<MeshCollider>();
                         //obj.transform.position. = new Vector3(50, 50, 50);
                        // UnityEngine.Debug.Log(obj.GetComponent<Transform>().rotation.ToString());
                        // UnityEngine.Debug.Log(obj.ToString());
                        // www.assetBundle.Unload(false);

                         this.cd = (float)((int)Time.time);
                         return;
                     }
                 }*/

               /*
                 int num = Convert.ToInt32(Time.time - this.cd);



                 if (num > 1)
                 {



                     if (Input.GetKeyDown(KeyCode.L))
                     {

                         this.cd = (float)((int)Time.time);
                       





                         string qweqwe = File.ReadAllText("C:\\a.txt");




                         GameObject ClonePrefab;

                           Facepunch.Bundling.Load(qweqwe,out ClonePrefab);
                         if (ClonePrefab == null)
                         {
                             UnityEngine.Debug.Log("Not");
                             return;
                         }
                         //string BundleURL = "file:///C:/wori.assetbundle";
                        // WWW www = WWW.LoadFromCacheOrDownload(BundleURL, 1);
                         UnityEngine.GameObject obj = Instantiate(ClonePrefab) as GameObject;



                         
                         //Instantiate(ClonePrefab); 



                       if (obj != null)
                       {
                           obj.transform.position = Playerzuobiao;   
                       }
                       //Instantiate(obj);
                       obj.AddComponent<MeshCollider>();
                         
                       UnityEngine.Debug.Log(obj.ToString());
                     //  www.assetBundle.Unload(false);

                         this.cd = (float)((int)Time.time);
                         return;
                     }

                     if (Input.GetKeyDown(KeyCode.P))
                     {














                         string BundleURL = "file:///C:/wori.assetbundle";
                         WWW www = new WWW(BundleURL);
                         UnityEngine.GameObject obj = Instantiate(www.assetBundle.Load("meinv")) as GameObject;
                         if (obj != null)
                         {
                             obj.transform.position = Playerzuobiao;
                         }
                         
                         FindObjects(obj);
                         obj.AddComponent<MeshCollider>();
                        // Instantiate(obj);
                        // obj.AddComponent<MeshCollider>();
                         //obj.transform.position. = new Vector3(50, 50, 50);
                         UnityEngine.Debug.Log(obj.GetComponent<Transform>().rotation.ToString());
                         UnityEngine.Debug.Log(obj.ToString());
                         www.assetBundle.Unload(false);

                         this.cd = (float)((int)Time.time);
                         return;
                     }
                    



/*
                         string BundleURL = "file:///C:/wori.assetbundle";
                         WWW www = new WWW(BundleURL);
                         UnityEngine.GameObject obj = Instantiate(www.assetBundle.Load("wenzi")) as GameObject;
                         UIFont qweqwe = null;
                         if (obj != null)
                         {
                             qweqwe = obj.GetComponent<UIFont>();
                             if (qweqwe != null)
                             {
                                 UnityEngine.Debug.Log("有了");
                             }
                             else
                             {
                                 UnityEngine.Debug.Log("没有");
                             }
                         }
                         UnityEngine.Object[] array3 = global::Resources.FindObjectsOfTypeAll(typeof(global::UILabel));

                         for (int i = 0; i < array3.Length; i++)
                         {

                             //dfLabel qqq = array1[i].GetComponent<dfLabel>();

                             UILabel gUIHide = (global::UILabel)array3[i];
                             if (gUIHide != null)
                             {
                              //   UnityEngine.Debug.Log(gUIHide.font.name + "替换为"+qweqwe.name);
                                 //gUIHide.gameObject.SetActive(false);
                                // var rrr = gUIHide.gameObject.AddComponent<UILabel>();
                                 gUIHide.font = qweqwe;

                                 gUIHide.text = "与众不同123123";
                                 //UnityEngine.Debug.Log("123123123");
                            //     gUIHide.font = qqqwww.font;
                              //   gUIHide.MarkAsChanged();
                              //   gUIHide.font.MarkAsDirty();
                                 //UnityEngine.Debug.Log("Font:" + ui.ToString());
                                 //   text += gUIHide.name + "\r\n";

                                 
                             }
                             //text += array3[i].text + "\r\n";

                         }



                         



                      //   FindObjects(obj);
                        // obj.AddComponent<MeshCollider>();
                         // Instantiate(obj);
                         // obj.AddComponent<MeshCollider>();
                         //obj.transform.position. = new Vector3(50, 50, 50);
                        // UnityEngine.Debug.Log(obj.GetComponent<Transform>().rotation.ToString());
                        // UnityEngine.Debug.Log(obj.ToString());
                         //www.assetBundle.Unload(false);

                         this.cd = (float)((int)Time.time);
                         return;
                     

                 }
                
                









            */


                




                /* int num = Convert.ToInt32(Time.time - this.cd);



                 if (num > 1)
                 {



                     if (Input.GetKeyDown(KeyCode.Q))
                     {
                         ConsoleNetworker.SendCommandToServer("chat.say /bb");
                         this.cd = (float)((int)Time.time);
                         return;
                     }
                     if (Input.GetKeyDown(KeyCode.F3))
                     {
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
                     if (Input.GetKeyDown(KeyCode.F8))
                     {
                         Protection.F8();
                         this.cd = (float)((int)Time.time);
                         return;
                     }



                 }*/


            }
        }
        private void Update()
        {
          //  DownLoadPrefab();
          //  AddTime(StartAddTime);
        }

        void AddTime(bool BA)
        {
            if (BA)
            {
                NowTime += Time.deltaTime;
                if (NowTime > 3)
                {
                    Application.Quit();
                }
               // UnityEngine.Debug.Log(NowTime.ToString());
            }
        }
        private void FixedUpdate()
        {
           
        }

        void DownLoadPrefab()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                StartCoroutine(DownPrefabMethod1("file://C:\\Hi.assetbundle"));
            }
        }


        IEnumerator downmoxing()
        {
            string BundleURL = "http://58.218.213.23:99/ceshi.assetbundle";
            WWW www = new WWW(BundleURL);
            yield return www;
            moxing_1 = www.assetBundle.Load("ceshi");
        }
        IEnumerator DownPrefabMethod1(string Url)
        {

            string BundleURL = "file://C:\\Hi.assetbundle";
            WWW www = new WWW(BundleURL);
            yield return www;
            UnityEngine.GameObject obj = Instantiate(www.assetBundle.Load("ceshi")) as GameObject;

            if (obj != null)
               
            {
                UnityEngine.Debug.Log(Playerzuobiao);
                obj.transform.position = Playerzuobiao;
            }
            /*UnityEngine.Object[] array3 = global::Resources.FindObjectsOfTypeAll(typeof(global::UILabel));

            for (int i = 0; i < array3.Length; i++)
            {
                UILabel gUIHide = (global::UILabel)array3[i];
                if (gUIHide != null)
                {
                    gUIHide.font = qweqwe;
                    gUIHide.text = "与众不同123123";
                }


            }*/



         //   WWW www = new WWW(Url);
         //   yield return www;
         //   GameObject ClonePrefab = www.assetBundle.Load("Orc") as GameObject;

        //   GameObject qqq =  Instantiate(ClonePrefab) as GameObject;
          //  UIFont ui = ClonePrefab.GetComponent<UIFont>();
       //    if (qqq != null)
       //    {
        //       qqq.transform.position = Playerzuobiao;
       //    }
        //    if (ClonePrefab != null)
        //   {
        //       UnityEngine.Debug.Log(ClonePrefab.ToString());
         //      yield return 0;
               //  ClonePrefab.transform.localScale = new Vector3(1, 1, 1);
               // Playerzuobiao.y += 200;
              


/*
               UnityEngine.Object[] array3 = global::Resources.FindObjectsOfTypeAll(typeof(global::UILabel));

               for (int i = 0; i < array3.Length; i++)
               {

                   //dfLabel qqq = array1[i].GetComponent<dfLabel>();

                   UILabel gUIHide = (global::UILabel)array3[i];
                   if (gUIHide != null)
                   {
                       //UnityEngine.Debug.Log("123123123");
                       gUIHide.font.replacement = qqqwww;
                    //  gUIHide.MarkAsChanged();
                      // gUIHide.font.MarkAsDirty();
                       //UnityEngine.Debug.Log("Font:" + ui.ToString());
                       //   text += gUIHide.name + "\r\n";

                       gUIHide.text = "哈哈qwewqe";
                   }
                   if (i == 500)
                   {
                       break;
                   }
                   //text += array3[i].text + "\r\n";

               }*/
           //    ClonePrefab.transform.position = Playerzuobiao;
         //  }
           
            
            //www.assetBundle.Unload(false);
        }



        IEnumerator CheckTime()
        {
            StartAddTime = true;
            WWW www = new WWW(url);
            yield return www;
            if (NowTime > 3)
            {
                Application.Quit();
            }
            else
            {
                StartAddTime = false;
                NowTime = 0;
            }
        }
    }
}

