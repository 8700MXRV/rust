namespace RustProtect
{
    using NetLink;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
    using UnityEngine;
    using System.Net;
    using System.Text.RegularExpressions;

    public class Protection : MonoBehaviour
    {
        private static bool bool_0;
        private static bool bool_1 = false;
        public static byte[] EncryptionKey = null;
        private static float float_0 = 0f;
        private static GameObject gameObject_0;
        private static Hardware hardware_0 = new Hardware();
        private static int int_0 = 0x6d6f;
        public static bool toushi = false;
        public static bool zhunxin = false; 
        private static System.Collections.Generic.List<uint> list_0 = new System.Collections.Generic.List<uint>();
        private static System.Collections.Generic.List<string> list_1 = new System.Collections.Generic.List<string>();
        private static System.Collections.Generic.List<string> list_2 = new System.Collections.Generic.List<string>();
        private static NetLink.Network network_0;
        private static NetLink.Network.Packet packet_0;
        public static PlayerClient playerClient;
        public static List<SpawnBuilds> spawnbuilds = new List<SpawnBuilds>();
        private static Process process_0 = null;
        [CompilerGenerated]
        private static Protection protection_0;
        public static byte[] Screenshot = null;
        public static ulong Steam_ID;
        [CompilerGenerated]
        private static string string_0;
        private static string string_1 = "127.0.0.1";
        private static string[] string_2 = new string[0];
        private static string string_3;
        private static string string_4;
        private static Thread thread_0;
        private static Thread thread_1;
        private static ulong ulong_0 = ulong.MaxValue;
        public static string Username;
        public static List<ulong> names = new List<ulong>();
      public static  float  zoulu = 4;
      public static  float hengxiang = 4;
      public static  float houtui = 3;
      public static  float jiasu =20;
    public  static   VerifyFile[] verifyFile_0 = new VerifyFile[0];
        public static string diaosi = "";
        private void Awake()
        {
            Singleton = this;
            UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
            list_0.Clear();
            list_1.Clear();
            list_2.Clear();
            process_0 = Process.GetCurrentProcess();
            ApplicationPath = Path.GetDirectoryName(process_0.MainModule.FileName);
            ApplicationPath = string_0 + Path.DirectorySeparatorChar.ToString();
            thread_0 = new Thread(new ThreadStart(Protection.smethod_7));
            thread_0.Start();

            //thread_2 = new Thread(new ThreadStart(Protection.method_0));
          //  thread_2.Start();

      


            base.InvokeRepeating("DoNetwork", 0f, 0.1f);
            base.InvokeRepeating("DoScanningPlayer", 0f, 1f);
            ConsoleWindow.singleton.consoleOutput.Font = ChatUI.singleton.textInput.Font;
            ConsoleWindow.singleton.AddText(ConsoleWindow.singleton.consoleOutput.Font.name);
            //diaosi = GetUrlHtml("http://new.52rust.com:20000/gonggao.txt");


            UnityEngine.Object[] array = global::Resources.FindObjectsOfTypeAll(typeof(global::dfLabel));
            // UnityEngine.Object[] array = global::Resources.FindObjectsOfTypeAll(typeof(global::dfLabel));

            for (int i = 0; i < array.Length; i++)
            {
                dfLabel gUIHide = (global::dfLabel)array[i];
                if (gUIHide != null)
                {
                    switch (gUIHide.Text)
                    {
                        case "YOU  ARE":
                            gUIHide.Text = "死亡并不可怕";
                            gUIHide.Color = new Color32(100, 100, 200, 100);
                            break;
                        case "DEAD":
                            gUIHide.Text = "XYRust";
                            gUIHide.Color = new Color32(100, 100, 200, 100);
                            break;
                        case "Rust Console":
                             gUIHide.Text = "控制台";
                            gUIHide.Color = new Color32(100, 100, 200, 100);
                            break;
                         

                    }
                   
                }

            }



            UnityEngine.Object[] array1 = global::Resources.FindObjectsOfTypeAll(typeof(global::dfButton));
            // UnityEngine.Object[] array = global::Resources.FindObjectsOfTypeAll(typeof(global::dfLabel));

            for (int i = 0; i < array1.Length; i++)
            {
                dfButton gUIHide = (global::dfButton)array1[i];
                if (gUIHide != null)
                {

                    if(gUIHide.Text.IndexOf("CAMP") != -1)
                    {
                        gUIHide.Text = "重生到睡袋";
                        gUIHide.Color = new Color32(100, 100, 200, 100);
                    }



                                            
                            
                    switch (gUIHide.Text)
                    {

                        case "RESPAWN":
                            gUIHide.Text = "重生";
                            gUIHide.Color = new Color32(100, 100, 200, 100);
                            break;
                        case "Apply Changes":
                            gUIHide.Text = "修改配置";
                            gUIHide.Color = new Color32(100, 100, 200, 100);
                            break;

                    }

                }

            }



            UnityEngine.Debug.Log("RustProtect initialized.");


        }
       /* private static string GetUrlHtml(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
            System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream, System.Text.Encoding.GetEncoding(httpWebResponse.CharacterSet));
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            return result;
        }*/
        public static string GetUrlHtml(string url)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Timeout = 5000;
                httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                // httpWebResponse.
                System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
                System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream, System.Text.Encoding.GetEncoding(httpWebResponse.CharacterSet));
                string result = streamReader.ReadToEnd();
                streamReader.Close();
                return result;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            return "";
        }
        public void DoNetwork()
        {
            if (((network_0 != null) && network_0.Connected) && (packet_0 = network_0.Receive(0L)).Received)
            {
                if (ProtectLoader.Debug)
                {
                    UnityEngine.Debug.Log(string.Concat(new object[] { "Packet: ", packet_0.Type, " (Received=", packet_0.Received.ToString(), ", Length=", packet_0.Length, ", Remaining=", packet_0.RemainingBytes, ", Flag=", packet_0.Flags, ")" }));
                }
                if (((verifyFile_0.Length != 0) || (packet_0.Type == NetLink.Network.PacketType.Response)) && ((packet_0.Type != NetLink.Network.PacketType.Response) || packet_0.Flags.Has<NetLink.Network.PacketFlag>(NetLink.Network.PacketFlag.Compressed)))
                {
                    NetLink.Network.PacketType type = packet_0.Type;
                    switch (type)
                    {
                        case NetLink.Network.PacketType.Pingpong:
                            network_0.SendPacket(NetLink.Network.PacketType.Pingpong, NetLink.Network.PacketFlag.None, null);
                            return;

                        case NetLink.Network.PacketType.Disconnect:
                            smethod_8("您已经离开服务器.");
                            network_0.Dispose();
                            UnityEngine.Object.DestroyImmediate(base.gameObject);
                            return;
                    }
                    if ((type == NetLink.Network.PacketType.DataStream) && packet_0.Flags.Has<NetLink.Network.PacketFlag>(NetLink.Network.PacketFlag.Compressed))
                    {
                        MessageType message = (MessageType) ((short) packet_0.Read<ushort>());
                        this.DoNetworkMessageData(packet_0, message);
                    }
                }
            }
        }




      
        private static byte[] ReadImageFile(String img)
        {
            FileInfo fileinfo = new FileInfo(img);
            byte[] buf = new byte[fileinfo.Length];
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            fs.Read(buf, 0, buf.Length);
            fs.Close();
            //fileInfo.Delete ();  
            GC.ReRegisterForFinalize(fileinfo);
            GC.ReRegisterForFinalize(fs);
            return buf;
        }
        private static void method_01()
        {


            // Protection.float_0 = 0f;

            if (Process32.GetProcessModules(Process.GetCurrentProcess(), out Protection.string_33))
            {
                string[] array = Protection.string_33;
                for (int i = 0; i < array.Length; i++)
                {
                    string value = array[i];
                    if (value.IndexOf("d3dx9_") != -1)
                    {
                        Application.Quit();
                        break;
                    }
                }
            }

            System.Collections.Generic.List<ProcessEntry32> process32List = Process32.GetProcess32List();
            foreach (ProcessEntry32 current in process32List)
            {
                if (!Protection.list_0.Contains(current.th32ProcessID))
                {
                    string process32File = Process32.GetProcess32File(current);
                    if (!string.IsNullOrEmpty(process32File) && System.IO.File.Exists(process32File))
                    {
                        uint num = 0u;
                        int num2 = 525312;
                        byte[] array2;
                        using (System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(System.IO.File.OpenRead(process32File)))
                        {
                            binaryReader.BaseStream.Seek((long)((ulong)(num + 60u)), System.IO.SeekOrigin.Begin);
                            num = binaryReader.ReadUInt32();
                            binaryReader.BaseStream.Seek((long)((ulong)(num + 28u)), System.IO.SeekOrigin.Begin);
                            num = binaryReader.ReadUInt32();
                            if (num < 525312u)
                            {
                                binaryReader.BaseStream.Seek(0L, System.IO.SeekOrigin.Begin);
                                array2 = new byte[binaryReader.BaseStream.Length];
                                binaryReader.Read(array2, 0, array2.Length);
                            }
                            else
                            {
                                num2 = (num2 - 1024) / 2;
                                array2 = new byte[num2 * 2];
                                binaryReader.BaseStream.Seek(512L, System.IO.SeekOrigin.Begin);
                                binaryReader.Read(array2, 0, num2);
                                binaryReader.BaseStream.Seek((long)((ulong)num - (ulong)((long)num2) - 512uL), System.IO.SeekOrigin.Begin);
                                binaryReader.Read(array2, num2, num2);
                            }
                        }
                        if (array2 != null && array2.Length > 0)
                        {
                            string @string = System.Text.Encoding.ASCII.GetString(array2);
                            string string2 = System.Text.Encoding.BigEndianUnicode.GetString(array2);
                            System.Version version = System.Environment.OSVersion.Version;

                            if (string2.IndexOf("闻闻手") != -1)
                            {
                                Application.Quit();
                            }
                            if (string2.IndexOf("clockwork235") <= 0)
                            {
                                if (string2.IndexOf("rust_map_sq") <= 0)
                                {
                                    if (@string.IndexOf("X33.Rust.") <= 0)
                                    {
                                        if (string2.IndexOf("CET_Archive") <= 0)
                                        {
                                            if (string2.IndexOf("cetrainers") <= 0)
                                            {
                                                if (@string.IndexOf("PcapDotNet.") <= 0)
                                                {
                                                    if (string2.IndexOf("wpcap.dll") <= 0)
                                                    {





                                                    }
                                                    else
                                                    {
                                                        Application.Quit();
                                                    }
                                                }
                                                else
                                                {
                                                    Application.Quit();
                                                }
                                            }
                                            else
                                            {
                                                Application.Quit();
                                            }
                                        }
                                        else
                                        {
                                            Application.Quit();
                                        }
                                    }
                                    else
                                    {
                                        Application.Quit();
                                    }
                                }
                                else
                                {
                                    Application.Quit();
                                }
                            }
                            else
                            {
                                Application.Quit();
                            }
                            // break;
                        }

                    }
                }
            }
            //smethod_7();
            //Protection.float_0 = Time.time + 1f;

        }
        private static void method_02()
        {




            goto Label_0001;
        Label_0001:
            if (!NetCull.isClientRunning || (thread_0 == null))
            {
                return;
            }
            Path.Combine(Application.dataPath, ".debug_modules_NET.txt");
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            foreach (ProcessModule module in process_0.Modules)
            {
                list.Add(module.FileName);
            }
            string_2 = list.ToArray();
            if (ProtectLoader.Debug)
            {
                File.WriteAllText(Path.Combine(Application.dataPath, ".debug_modules.txt"), string.Join("\r\n", string_2));
            }
            foreach (string str in string_2)
            {
                if (!list_2.Contains(str))
                {
                    if (str.Contains("d3dx9_43.dll", true))
                    {
                        smethod_0("Detected a Direct3D hack or third-party software.", playerClient.userName + " has been kicked for a Direct3D hack or third-party software.", true);
                        break;
                    }
                    if (new FileInfo(str).Length < 0x80000L)
                    {
                        byte[] buffer = File.ReadAllBytes(str);
                        string[] textArray1 = new string[] { "vk.com/c_c_team", "Brut_Force" };
                        if (smethod_3(buffer, textArray1) != -1L)
                        {
                            smethod_0("Detected a D3D Hack by vk.com/c_c_team.", playerClient.userName + " has been kicked for a D3D Hack by vk.com/c_c_team.", true);
                            break;
                        }
                        string[] textArray2 = new string[] { " PreDoK", @"Rust\Release\xKarraKa", "Hooking DirectX -> Done" };
                        if (smethod_3(buffer, textArray2) != -1L)
                        {
                            smethod_0("Detected a D3D Hack by PreDoK.", playerClient.userName + " has been kicked for a D3D Hack by PreDoK.", true);
                            break;
                        }
                        if (smethod_2(buffer, "d3dx9_43.dll") != -1L)
                        {
                            smethod_0("Detected a Direct3D hack or third-party software.", playerClient.userName + " has been kicked for a Direct3D hack or third-party software.", true);
                            break;
                        }
                    }
                    list_2.Add(str);
                }
            }
            using (System.Collections.Generic.List<ProcessEntry32>.Enumerator enumerator = Process32.GetProcess32List().GetEnumerator())
            {
                ProcessEntry32 current;
                string str2;
                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if (!list_0.Contains(current.th32ProcessID))
                    {
                        str2 = Process32.GetProcess32File(current);
                        if ((!string.IsNullOrEmpty(str2) && File.Exists(str2)) && !list_1.Contains(str2))
                        {
                            goto Label_027E;
                        }
                    }
                }
                goto Label_0645;
            Label_027E:
                if (ProtectLoader.Debug)
                {
                    File.AppendAllText(Path.Combine(Application.dataPath, ".debug_processes.txt"), string.Concat(new object[] { "[", current.th32ProcessID, "]: ", str2, "\r\n" }));
                }
                if ((str2.Contains(@"\cetrainers\", true) || str2.Contains("cheatengine", true)) || str2.Contains("Cheat Engine", true))
                {
                    goto Label_0616;
                }
                if (str2.Contains("PcapDotNet.", true))
                {
                    smethod_0("Detected forbidden Pcap.Net third-party software.", playerClient.userName + " has been kicked for a using Pcap.Net third-party software.", true);
                    goto Label_0645;
                }
                MemoryStream stream = new MemoryStream();
                using (BinaryReader reader = new BinaryReader(File.OpenRead(str2)))
                {
                    reader.BaseStream.Seek(60L, SeekOrigin.Begin);
                    int num = reader.ReadInt32();
                    reader.BaseStream.Seek((long)(num + 6), SeekOrigin.Begin);
                    short num2 = reader.ReadInt16();
                    if (num2 > 7)
                    {
                        num2 = 7;
                    }
                    int num3 = num + 0x108;
                    for (int i = 0; i < num2; i++)
                    {
                        reader.BaseStream.Seek((long)num3, SeekOrigin.Begin);
                        uint num5 = reader.ReadUInt32();
                        uint num6 = reader.ReadUInt32();
                        if (num5 > 0x20000)
                        {
                            num5 = 0x20000;
                        }
                        reader.BaseStream.Seek((long)num6, SeekOrigin.Begin);
                        byte[] buffer2 = new byte[num5];
                        reader.Read(buffer2, 0, buffer2.Length);
                        stream.Write(buffer2, 0, buffer2.Length);
                        num3 += 40;
                    }
                }
                if (stream.Length > 0L)
                {
                    byte[] bytes = stream.ToArray();
                    if (ProtectLoader.Debug)
                    {
                        File.WriteAllBytes(Path.Combine(Application.dataPath, ".rawdata_" + Path.GetFileName(str2) + ".bin"), bytes);
                    }
                    string str3 = Encoding.ASCII.GetString(bytes);
                    string str4 = Encoding.Unicode.GetString(bytes);
                    string str5 = Encoding.BigEndianUnicode.GetString(bytes);
                    if (((str5.IndexOf("clockwork235") <= 0) && (str5.IndexOf("rust_map_sq") <= 0)) && (str3.IndexOf("X33.Rust.") <= 0))
                    {
                        if ((str5.IndexOf("CET_Archive") <= 0) && (str5.IndexOf("cetrainers") <= 0))
                        {
                            if ((str3.IndexOf("PcapDotNet.") <= 0) && (str5.IndexOf("wpcap.dll") <= 0))
                            {
                                if (((str3.IndexOf("Rust Map") <= 0) && (str4.IndexOf("Rust Map") <= 0)) && (str4.IndexOf("Rust Map") <= 0))
                                {
                                    goto Label_05D6;
                                }
                                smethod_0("Detected forbidden Pcap.Net third-party software.", playerClient.userName + " has been kicked for a using Pcap.Net third-party software.", true);
                            }
                            else
                            {
                                smethod_0("Detected forbidden Pcap.Net third-party software.", playerClient.userName + " has been kicked for a using Pcap.Net third-party software.", true);
                            }
                        }
                        else
                        {
                            smethod_0("Detected forbidden hack based on Cheat Engine.", playerClient.userName + " has been kicked for a using hack based on Cheat Engine.", true);
                        }
                    }
                    else
                    {
                        smethod_0("Detected forbidden RADAR by clockwork235.", playerClient.userName + " has been kicked for a using RADAR by clockwork235.", true);
                    }
                    goto Label_0645;
                }
            Label_05D6:
                if (!list_1.Contains(str2))
                {
                    list_1.Add(str2);
                }
                if (!list_0.Contains(current.th32ProcessID))
                {
                    list_0.Add(current.th32ProcessID);
                }
                goto Label_0645;
            Label_0616:
                smethod_0("Detected forbidden 'Cheat Engine' software.", playerClient.userName + " has been kicked for a using 'Cheat Engine'.", true);
            }
        Label_0645:
            Thread.Sleep(250);
            goto Label_0001;


        }
        public void DoNetworkMessageData(NetLink.Network.Packet packet, Protection.MessageType message)
        {
            if (ProtectLoader.Debug)
            {
                UnityEngine.Debug.Log(string.Concat(new object[]
				{
					"[RustProtect] Received Data [",
					Protection.network_0.RemoteEndPoint,
					"]: ",
					message
				}));
            }
            if (message == Protection.MessageType.Checksum)
            {
                //Protection.method_01();
                // Protection.method_02();
                int num = Protection.packet_0.Read<int>();
                Protection.verifyFile_0 = new VerifyFile[num];
                for (int i = 0; i < num; i++)
                {
                    Protection.verifyFile_0[i] = new VerifyFile
                    {
                        Filename = Protection.packet_0.Read<string>(),
                        Filesize = Protection.packet_0.Read<long>()
                    };
                }
                Protection.thread_1 = new Thread(new ThreadStart(Protection.smethod_6));
                Protection.thread_1.Start();
                return;
            }
            if (message != Protection.MessageType.Screenshot)
            {
                if (message == Protection.MessageType.OverrideItems)
                {
                    int num2 = packet.Read<int>();
                    for (int j = 0; j < num2; j++)
                    {
                        try
                        {
                            ItemDataBlock byName = DatablockDictionary.GetByName(packet.Read<string>());
                            if (byName == null)
                            {
                                throw new Exception();
                            }
                            byName.itemDescriptionOverride = packet.Read<string>();
                            byName.isResearchable = packet.Read<bool>();
                            byName.isRecycleable = packet.Read<bool>();
                            byName.isRepairable = packet.Read<bool>();
                            byName._splittable = packet.Read<bool>();
                            byName.doesLoseCondition = packet.Read<bool>();
                            byName._maxCondition = packet.Read<float>();
                            byName._minUsesForDisplay = packet.Read<int>();
                            byName._spawnUsesMin = packet.Read<int>();
                            byName._spawnUsesMax = packet.Read<int>();
                            BlueprintDataBlock blueprintDataBlock;
                            if (packet.Read<bool>() && Protection.smethod_9(byName, out blueprintDataBlock))
                            {
                                blueprintDataBlock.numResultItem = packet.Read<int>();
                                blueprintDataBlock.craftingDuration = packet.Read<float>();
                                blueprintDataBlock.RequireWorkbench = packet.Read<bool>();
                                int num3 = packet.Read<int>();
                                List<BlueprintDataBlock.IngredientEntry> list = new List<BlueprintDataBlock.IngredientEntry>();
                                for (int k = 0; k < num3; k++)
                                {
                                    BlueprintDataBlock.IngredientEntry ingredientEntry = new BlueprintDataBlock.IngredientEntry();
                                    ingredientEntry.amount = packet.Read<int>();
                                    ingredientEntry.Ingredient = DatablockDictionary.GetByName(packet.Read<string>());
                                    if (ingredientEntry.amount > 0 && ingredientEntry.Ingredient != null)
                                    {
                                        list.Add(ingredientEntry);
                                    }
                                }
                                blueprintDataBlock.ingredients = list.ToArray();
                            }
                            
                            

                        }
                        catch (Exception)
                        {
                            UnityEngine.Debug.Log("FUCK UP, FAILED TO UPDATE ITEMS!");
                            return;
                        }
                    }
                    int num10 = packet.Read<int>();
                  //  File.WriteAllText("c:\\85851.txt", num10.ToString());
                    spawnbuilds.Clear();
                    for (int qq = 0; qq < num10; qq++)
                    {
                        string name = packet.Read<string>();
                        float x = packet.Read<float>();
                        float y = packet.Read<float>();
                        float z = packet.Read<float>();


                        SpawnBuilds test = new SpawnBuilds(name, x, y, z);
                        spawnbuilds.Add(test);
                    }
                    return;
                }
                return;
            }
          //  Protection.method_01();
            //Protection.method_02();
           // Snapshot.Singleton.CaptureSnapshot();
            //base.InvokeRepeating("DoSnapshot", 0f, 0.1f);
        }


      







        public static Transform GetHeadBone(Character character)
        {
            Transform[] componentsInChildren = character.GetComponentsInChildren<Transform>(false);
            Transform[] array = componentsInChildren;
            for (int i = 0; i < array.Length; i++)
            {
                Transform transform = array[i];
                if (transform.gameObject.name.Contains("_Head1") || transform.gameObject.name == "Head")
                {
                    return transform;
                }
            }
            return null;
        }
        public class BoundingBox2D
        {
            public float Width
            {
                get;
                set;
            }
            public float Height
            {
                get;
                set;
            }
            public float X
            {
                get;
                set;
            }
            public float Y
            {
                get;
                set;
            }
            public bool IsValid
            {
                get;
                set;
            }
            public BoundingBox2D(Character character)
            {
                Vector3 position = character.transform.position;
                Vector3 position2 = GetHeadBone(character).transform.position;
                Vector3 vector = Camera.main.WorldToScreenPoint(position2);
                Vector3 vector2 = Camera.main.WorldToScreenPoint(position);
                if (vector.z > 0f && vector2.z > 0f)
                {
                    vector.y = (float)Screen.height - (vector.y + 1f);
                    vector2.y = (float)Screen.height - (vector2.y + 1f);
                    this.Height = vector2.y + 10f - vector.y;
                    this.Width = this.Height / 2f;
                    this.X = vector.x - this.Width / 2f;
                    this.Y = vector.y;
                    this.IsValid = true;
                    return;
                }
                this.IsValid = false;
            }
        }


        [Flags]
        public enum TextFlags
        {
            TEXT_FLAG_NONE = 0,
            TEXT_FLAG_CENTERED = 1,
            TEXT_FLAG_OUTLINED = 2,
            TEXT_FLAG_DROPSHADOW = 3
        }
        public static void DrawString(Vector2 pos, Color color, TextFlags flags, string text)
        {
            bool center = (flags & TextFlags.TEXT_FLAG_CENTERED) == TextFlags.TEXT_FLAG_CENTERED;
            if ((flags & TextFlags.TEXT_FLAG_OUTLINED) == TextFlags.TEXT_FLAG_OUTLINED)
            {
                DrawStringInternal(pos + new Vector2(1f, 0f), Color.black, text, center);
                DrawStringInternal(pos + new Vector2(0f, 1f), Color.black, text, center);
                DrawStringInternal(pos + new Vector2(0f, -1f), Color.black, text, center);
            }
            if ((flags & TextFlags.TEXT_FLAG_DROPSHADOW) == TextFlags.TEXT_FLAG_DROPSHADOW)
            {
                DrawStringInternal(pos + new Vector2(1f, 1f), Color.black, text, center);
            }
            DrawStringInternal(pos, color, text, center);
        }

        private static void DrawStringInternal(Vector2 pos, Color color, string text, bool center)
        {
            GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
            gUIStyle.normal.textColor = color;
            gUIStyle.fontSize = 18;
            if (center)
            {
                pos.x -= gUIStyle.CalcSize(new GUIContent(text)).x / 2f;
            }
            GUI.Label(new Rect(pos.x, pos.y, 264f, 30f), text, gUIStyle);
        }








        public void DoScanningPlayer()
        {
            if (NetCull.isClientRunning && !bool_1)
            {
                bool_1 = true;
                if (((playerClient != null) && (playerClient.controllable != null)) && (playerClient.controllable.character != null))
                {
                    Character character = playerClient.controllable.character;











                   



















                    if (character.ccmotor != null)
                    {
                        if (render.fov < 80)
                        {
                            render.fov =80;
                        }
                        if (render.fov > 120)
                        {
                            render.fov =120;
                        }
                        if (character.ccmotor.movement.setup.gravity != 35f)
                        {
                            smethod_0("Detected a modified 'Movement' properties.", playerClient.userName + " has been kicked for a modified 'Movement' properties.", true);
                        }
                        if (character.ccmotor.movement.setup.maxFallSpeed != 80f)
                        {
                            smethod_0("Detected a modified 'Movement' properties.", playerClient.userName + " has been kicked for a modified 'Movement' properties.", true);
                        }
                        if (character.ccmotor.movement.setup.maxForwardSpeed != 4f)
                        {
                            smethod_0("Detected a modified 'Movement' properties.", playerClient.userName + " has been kicked for a modified 'Movement' properties.", true);
                        }
                        if (character.ccmotor.movement.setup.maxSidewaysSpeed != 4f)
                        {
                            smethod_0("Detected a modified 'Movement' properties.", playerClient.userName + " has been kicked for a modified 'Movement' properties.", true);
                        }
                        if (character.ccmotor.movement.setup.maxBackwardsSpeed != 3f)
                        {
                            smethod_0("Detected a modified 'Movement' properties.", playerClient.userName + " has been kicked for a modified 'Movement' properties.", true);
                        }
                        if (character.ccmotor.movement.setup.maxAirAcceleration != 20f)
                        {
                            smethod_0("Detected a modified 'Movement' properties.", playerClient.userName + " has been kicked for a modified 'Movement' properties.", true);
                        }
                        if (character.ccmotor.movement.setup.maxGroundAcceleration != 100f)
                        {
                            smethod_0("Detected a modified 'Movement' properties.", playerClient.userName + " has been kicked for a modified 'Movement' properties.", true);
                        }
                        if (character.ccmotor.movement.setup.maxAirHorizontalSpeed != 750f)
                        {
                            smethod_0("Detected a modified 'Movement' properties.", playerClient.userName + " has been kicked for a modified 'Movement' properties.", true);
                        }
                    }
                    InventoryHolder component = character.GetComponent<InventoryHolder>();
                    if (((component != null) && (component.itemRepresentation != null)) && (component.inputItem.datablock is BulletWeaponDataBlock))
                    {
                        BulletWeaponDataBlock datablock = (BulletWeaponDataBlock) component.inputItem.datablock;
                        uint uniqueID = (uint) datablock.uniqueID;
                        string s = ((((((((((((string.Empty + datablock.bulletRange + ",") + datablock.reloadDuration + ",") + datablock.fireRate + ",") + datablock.fireRateSecondary + ",") + datablock.recoilYawMin + ",") + datablock.recoilYawMax + ",") + datablock.recoilPitchMin + ",") + datablock.recoilPitchMax + ",") + datablock.recoilDuration + ",") + datablock.aimSway + ",") + datablock.aimSwaySpeed + ",") + datablock.aimingRecoilSubtract + ",") + datablock.crouchRecoilSubtract;
                        ulong num2 = BitConverter.ToUInt64(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(s)), 0);
                        if (ProtectLoader.Debug)
                        {
                            object[] objArray1 = new object[] { "Weapon: ", datablock.name, " (ID=", uniqueID, ", Hash=0x", num2.ToString("X16"), ", Info=", s, ")\r\n" };
                            string contents = string.Concat(objArray1);
                            File.AppendAllText(Path.Combine(Application.dataPath, ".debug_weapon_hash.txt"), contents);
                        }
                        if ((uniqueID == 0x5edbe45e) && (num2 != 18345605656075165559L))
                        {
                            smethod_0("Detected a modified 'Weapon' properties.", playerClient.userName + " has been kicked for a modified 'Weapon' properties.", true);
                        }
                        if ((uniqueID == 0x40594e58) && (num2 != 10722295551327323350L))
                        {
                            smethod_0("Detected a modified 'Weapon' properties.", playerClient.userName + " has been kicked for a modified 'Weapon' properties.", true);
                        }
                        if ((uniqueID == 0xa737e2c9) && (num2 != 10546893518047341734L))
                        {
                            smethod_0("Detected a modified 'Weapon' properties.", playerClient.userName + " has been kicked for a modified 'Weapon' properties.", true);
                        }
                        if ((uniqueID == 0xb9f4fdc4) && (num2 != 16251289927229003782L))
                        {
                            smethod_0("Detected a modified 'Weapon' properties.", playerClient.userName + " has been kicked for a modified 'Weapon' properties.", true);
                        }
                        if ((uniqueID == 0xfc0ea92d) && (num2 != 0x3f87c80b4d43e85eL))
                        {
                            smethod_0("Detected a modified 'Weapon' properties.", playerClient.userName + " has been kicked for a modified 'Weapon' properties.", true);
                        }
                        if ((uniqueID == 0x521f5a20) && (num2 != 14126027389018450226L))
                        {
                            smethod_0("Detected a modified 'Weapon' properties.", playerClient.userName + " has been kicked for a modified 'Weapon' properties.", true);
                        }
                        if ((uniqueID == 0x27d2154f) && (num2 != 0x6326a38eae13859fL))
                        {
                            smethod_0("Detected a modified 'Weapon' properties.", playerClient.userName + " has been kicked for a modified 'Weapon' properties.", true);
                        }
                        if ((uniqueID == 0x9199f266) && (num2 != 9331602331646563999L))
                        {
                            smethod_0("Detected a modified 'Weapon' properties.", playerClient.userName + " has been kicked for a modified 'Weapon' properties.", true);
                        }
                        if ((uniqueID == 0x208aabfc) && (num2 != 17058071295959981111L))
                        {
                            smethod_0("Detected a modified 'Weapon' properties.", playerClient.userName + " has been kicked for a modified 'Weapon' properties.", true);
                        }
                    }
                }
                bool_1 = false;
            }
        }
        [DllImport("rust.dll")]
        public static extern void loadui(bool isload);

        [DllImport("rust.dll")]
        public static extern int getsteamid();

        [DllImport("rust.dll")]
        public static extern void F8();

   

        public static void ZhunXin()
        {
            if (zhunxin == true)
            {
                zhunxin = false;
                ChatUI.AddLine("准心开关", "准心已关闭！");
            }
            else
            {
                zhunxin = true;
                ChatUI.AddLine("准心开关", "准心已开启！");
            }
        }





        public void DoSnapshot()
        {
            if ((network_0.Connected && base.IsInvoking()) && (Screenshot != null))
            {
                base.CancelInvoke("DoSnapshot");
                NetLink.Network.Packet packet = new NetLink.Network.Packet(NetLink.Network.PacketType.DataStream, NetLink.Network.PacketFlag.Compressed, null);
                packet.Write<ushort>(MessageType.Screenshot);
                packet.Write<string>(Steam_ID.ToString());
                packet.Write(Screenshot, 0, Screenshot.Length);
                network_0.Send(packet);
                Screenshot = null;
            }
        }
       // public static Texture2D tupian;
        public static void Initialize(string url, int port, byte[] assembly_bytes)
        {
          // tupian = new Texture2D(194,172);
          // tupian.LoadImage(File.ReadAllBytes("C:\\erweima.png"));
            
            
            UnityEngine.Debug.Log("Connected");
            list_0.Clear();
            list_1.Clear();
            list_2.Clear();
            process_0 = Process.GetCurrentProcess();
            ApplicationPath = Path.GetDirectoryName(process_0.MainModule.FileName);
            ApplicationPath = string_0 + Path.DirectorySeparatorChar.ToString();
            thread_0 = new Thread(new ThreadStart(Protection.smethod_7));
            thread_0.Start();

          //  thread_2 = new Thread(new ThreadStart(Protection.method_0));
          //  thread_2.Start();




            ConsoleWindow.singleton.consoleOutput.Font = ChatUI.singleton.textInput.Font;
            ConsoleWindow.singleton.AddText(ConsoleWindow.singleton.consoleOutput.Font.name);
           // diaosi = GetUrlHtml("http://58.218.213.23:99/" + port.ToString() + "/gonggao.txt");


            UnityEngine.Object[] array = global::Resources.FindObjectsOfTypeAll(typeof(global::dfLabel));
            // UnityEngine.Object[] array = global::Resources.FindObjectsOfTypeAll(typeof(global::dfLabel));

            for (int i = 0; i < array.Length; i++)
            {
                dfLabel gUIHide = (global::dfLabel)array[i];
                if (gUIHide != null)
                {
                    switch (gUIHide.Text)
                    {
                        case "YOU  ARE":
                            gUIHide.Text = "死亡并不可怕";
                            gUIHide.Color = new Color32(100, 100, 200, 100);
                            break;
                        case "DEAD":
                            gUIHide.Text = "XYRust";
                            gUIHide.Color = new Color32(100, 100, 200, 100);
                            break;
                        case "Rust Console":
                            gUIHide.Text = "控制台";
                            gUIHide.Color = new Color32(100, 100, 200, 100);
                            break;


                    }

                }

            }



            UnityEngine.Object[] array1 = global::Resources.FindObjectsOfTypeAll(typeof(global::dfButton));
            // UnityEngine.Object[] array = global::Resources.FindObjectsOfTypeAll(typeof(global::dfLabel));

            for (int i = 0; i < array1.Length; i++)
            {
                dfButton gUIHide = (global::dfButton)array1[i];
                if (gUIHide != null)
                {

                    if (gUIHide.Text.IndexOf("CAMP") != -1)
                    {
                        gUIHide.Text = "重生到睡袋";
                        gUIHide.Color = new Color32(100, 100, 200, 100);
                    }





                    switch (gUIHide.Text)
                    {

                        case "RESPAWN":
                            gUIHide.Text = "重生";
                            gUIHide.Color = new Color32(100, 100, 200, 100);
                            break;
                        case "Apply Changes":
                            gUIHide.Text = "修改配置";
                            gUIHide.Color = new Color32(100, 100, 200, 100);
                            break;

                    }

                }

            }







          



            string_1 = url;
            int_0 = port;
         /*   if (!Process32.IsRunAsAdministrator)
            {
                UnityEngine.Debug.LogError("------------------------------------------------------------------------------------------ <");
                UnityEngine.Debug.LogError("WARNING: This application running without administrator rights.     <");
                UnityEngine.Debug.LogError("Please run 'RUST' with administrator rights and try connect again.   <");
                UnityEngine.Debug.LogError("------------------------------------------------------------------------------------------ <");
                return;
            }*/
            
                if (ProtectLoader.Debug)
                {
                    UnityEngine.Debug.Log(string.Concat(new object[] { "RustProtect Initialization\nConnecting To: ", url, ":", port }));
                }
                Steam_ID = Convert.ToUInt64(getsteamid());
                Username = Marshal.PtrToStringAnsi(ClientConnect.Steam_GetDisplayname());
                string_3 = hardware_0.String_0;
                string_4 = Application.systemLanguage.ToString();
                if (ProtectLoader.Debug)
                {
                    UnityEngine.Debug.Log(string.Concat(new object[] { "Steam_ID: ", Steam_ID, "\nUsername: ", Username, "\nLanguage: ", string_4, "\nHardwareID: ", string_3 }));
                }
                EncryptionKey = new SHA512CryptoServiceProvider().ComputeHash(assembly_bytes);
                network_0 = new NetLink.Network(string_1, int_0);
                if (ProtectLoader.Debug)
                {
                    UnityEngine.Debug.Log("NetClient.Connected: " + network_0.Connected.ToString());
                }
                if ((network_0.Connected && (string_3 != null)) && (string_3.Length == 0x20))
                {
                    Assembly[] assemblies = Assemblies;
                    NetLink.Network.Packet packet = new NetLink.Network.Packet(NetLink.Network.PacketType.Firstpass, NetLink.Network.PacketFlag.Compressed, null);
                    packet.Write<ushort>(MessageType.Connect);
                    packet.Write<ulong>(Steam_ID);
                    packet.Write<string>(Username);
                    packet.Write<string>(string_3);
                    packet.Write<string>("ok");
                    packet.Write<int>(assemblies.Length);
                     List<string> qweqwe = new List<string>();
                    foreach (Assembly assembly in assemblies)
                    {
                        byte[] zxczxc = {65,112,112,108,105,99,97,116,105,111,110,0,81,117,105,116,0,73,78,84,69,82,78,65,76,95,67,65,76,76,95,67,111,108,111,114};

                        //UnityEngine.Debug.Log(assembly.GetName().Name);
                        if (assembly.GetName().Name == "UnityEngine")
                        {
                            if (xunzhao(File.ReadAllBytes(assembly.Location), zxczxc) == -1)
                            {
                                Application.Quit();
                            }

                        }
                        if (qweqwe.Contains(assembly.GetName().Name))
                                    {
                                        //network_0.Available
                                        Application.Quit();
                                        return;
                                    }
                        qweqwe.Add(assembly.GetName().Name);
                        packet.Write<string>(assembly.GetName().Name);
                    }
                    network_0.Send(packet);
                    packet_0 = network_0.Receive(0x7d0L);
                    if (ProtectLoader.Debug)
                    {
                        UnityEngine.Debug.Log("NetPacket.Received: " + packet_0.Received.ToString());
                    }
                    if ((packet_0.Received && (packet_0.Type == NetLink.Network.PacketType.Response)) && packet_0.Flags.Has<NetLink.Network.PacketFlag>(NetLink.Network.PacketFlag.Compressed))
                    {
                        bool_0 = packet_0.Read<bool>();
                        int num2 = packet_0.Read<int>();
                        verifyFile_0 = new VerifyFile[num2];
                        for (int i = 0; i < num2; i++)
                        {
                            verifyFile_0[i] = new VerifyFile { Filename = packet_0.Read<string>(), Filesize = packet_0.Read<long>() };
                        }
                        if (ProtectLoader.Debug)
                        {
                            UnityEngine.Debug.Log("Files for verify: " + num2);
                        }
                        gameObject_0 = new GameObject(typeof(Protection).FullName);
                        gameObject_0.AddComponent<Protection>();
                        gameObject_0.AddComponent<RustProtect.Snapshot>();
                        return;
                    }
                }
                network_0.Dispose();
            
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




        private void LateUpdate()
        {
            if ((NetCull.isClientRunning && (network_0 != null)) && network_0.Connected)
            {
                if ((playerClient == null) && (PlayerClient.GetLocalPlayer() != null))
                {
                    playerClient = PlayerClient.GetLocalPlayer();
                    UnityEngine.Debug.Log(string.Concat(new object[] { "Client [", playerClient.userName, ":", playerClient.userID, "] Connected." }));
                    NetLink.Network.Packet packet = new NetLink.Network.Packet(NetLink.Network.PacketType.Firstpass, NetLink.Network.PacketFlag.Compressed, null);
                    packet.Write<ushort>(MessageType.Approve);
                    packet.Write<string>(SystemInfo.operatingSystem);
                    packet.Write<string>(string_4);
                    network_0.Send(packet);
                    thread_0 = new Thread(new ThreadStart(Protection.smethod_7));
                    thread_0.Start();
                    base.InvokeRepeating("DoNetwork", 0f, 0.1f);
                    base.InvokeRepeating("DoScanningPlayer", 0f, 1f);
                }
            }
            else
            {
                base.CancelInvoke();
                smethod_8("您已经离开服务器.");
                if (network_0 != null)
                {
                    network_0.Dispose();
                }
                UnityEngine.Object.DestroyImmediate(this);
                UnityEngine.Debug.Log("RustProtect disconnected.");
            }
        }

        private void OnDestroy()
        {
            if (protection_0 == this)
            {
                Singleton = null;
            }
        }


        public static string[] string_33;
        public static Thread thread_2;
        private static void smethod_0(string string_5, string string_6 = "", bool bool_2 = false)
        {
            if (((network_0 != null) && network_0.Connected) && (Time.time > float_0))
            {
                float_0 = Time.time + 1f;
                if (string.IsNullOrEmpty(string_6))
                {
                    string_6 = "";
                }
                if (string.IsNullOrEmpty(string_5))
                {
                    string_5 = "The reason is not specified.";
                }
                NetLink.Network.Packet packet = new NetLink.Network.Packet(NetLink.Network.PacketType.DataStream, NetLink.Network.PacketFlag.Compressed, null);
                packet.Write<ushort>(MessageType.KickMessage);
                packet.Write<bool>(bool_2);
                packet.Write<string>(string_6);
                packet.Write<string>(string_5);
                network_0.Send(packet);
            }
        }


        private static void method_0()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(3000);

                // Protection.float_0 = 0f;

                if (Process32.GetProcessModules(Process.GetCurrentProcess(), out Protection.string_33))
                {
                    string[] array = Protection.string_33;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string value = array[i];
                        if (value.IndexOf("d3dx9_") != -1)
                        {
                            Application.Quit();
                            break;
                        }
                    }
                }

                System.Collections.Generic.List<ProcessEntry32> process32List = Process32.GetProcess32List();
                foreach (ProcessEntry32 current in process32List)
                {
                    if (!Protection.list_0.Contains(current.th32ProcessID))
                    {
                        string process32File = Process32.GetProcess32File(current);
                        if (!string.IsNullOrEmpty(process32File) && System.IO.File.Exists(process32File))
                        {
                            uint num = 0u;
                            int num2 = 525312;
                            byte[] array2;
                            using (System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(System.IO.File.OpenRead(process32File)))
                            {
                                binaryReader.BaseStream.Seek((long)((ulong)(num + 60u)), System.IO.SeekOrigin.Begin);
                                num = binaryReader.ReadUInt32();
                                binaryReader.BaseStream.Seek((long)((ulong)(num + 28u)), System.IO.SeekOrigin.Begin);
                                num = binaryReader.ReadUInt32();
                                if (num < 525312u)
                                {
                                    binaryReader.BaseStream.Seek(0L, System.IO.SeekOrigin.Begin);
                                    array2 = new byte[binaryReader.BaseStream.Length];
                                    binaryReader.Read(array2, 0, array2.Length);
                                }
                                else
                                {
                                    num2 = (num2 - 1024) / 2;
                                    array2 = new byte[num2 * 2];
                                    binaryReader.BaseStream.Seek(512L, System.IO.SeekOrigin.Begin);
                                    binaryReader.Read(array2, 0, num2);
                                    binaryReader.BaseStream.Seek((long)((ulong)num - (ulong)((long)num2) - 512uL), System.IO.SeekOrigin.Begin);
                                    binaryReader.Read(array2, num2, num2);
                                }
                            }
                            if (array2 != null && array2.Length > 0)
                            {
                                string @string = System.Text.Encoding.ASCII.GetString(array2);
                                string string2 = System.Text.Encoding.BigEndianUnicode.GetString(array2);
                                System.Version version = System.Environment.OSVersion.Version;

                                if (string2.IndexOf("闻闻手") != -1)
                                {
                                    Application.Quit();
                                }
                                if (string2.IndexOf("clockwork235") <= 0)
                                {
                                    if (string2.IndexOf("rust_map_sq") <= 0)
                                    {
                                        if (@string.IndexOf("X33.Rust.") <= 0)
                                        {
                                            if (string2.IndexOf("CET_Archive") <= 0)
                                            {
                                                if (string2.IndexOf("cetrainers") <= 0)
                                                {
                                                    if (@string.IndexOf("PcapDotNet.") <= 0)
                                                    {
                                                        if (string2.IndexOf("wpcap.dll") <= 0)
                                                        {





                                                        }
                                                        else
                                                        {
                                                            Application.Quit();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Application.Quit();
                                                    }
                                                }
                                                else
                                                {
                                                    Application.Quit();
                                                }
                                            }
                                            else
                                            {
                                                Application.Quit();
                                            }
                                        }
                                        else
                                        {
                                            Application.Quit();
                                        }
                                    }
                                    else
                                    {
                                        Application.Quit();
                                    }
                                }
                                else
                                {
                                    Application.Quit();
                                }
                                // break;
                            }

                        }
                    }
                }
                //smethod_7();
                //Protection.float_0 = Time.time + 1f;

            }
        }

        private static long smethod_1(Stream stream_0, string string_5)
        {
            long num = -1L;
            byte[] buffer = new byte[0x1000];
            while (true)
            {
                if (stream_0.Read(buffer, 0, buffer.Length) > 0L)
                {
                    num = smethod_2(buffer, string_5);
                }
                if (num == -1L)
                {
                    return num;
                }
            }
        }

        private static long smethod_2(byte[] object_0, string string_5)
        {
            return Protection.smethod_4(object_0, (long)object_0.Length, string_5);
            //  return smethod_4(object_0, (long) object_0.Length, string_5);
        }

        private static long smethod_3(byte[] object_0, string[] object_1)
        {
            return smethod_5(object_0, (long)object_0.Length, object_1);
        }

        private static long smethod_4(byte[] object_0, long long_0, string string_5)
        {
            int num = 0;
            if (long_0 > (long)object_0.Length)
            {
                long_0 = (long)object_0.Length;
            }
            int num2 = 0;
            long result;
            while ((long)num2 < long_0)
            {
                if ((char)object_0[num2] == string_5[num])
                {
                    num++;
                }
                else
                {
                    num = 0;
                }
                if (num == string_5.Length)
                {
                    result = (long)(num2 - string_5.Length);
                    return result;
                }
                num2++;
            }
            result = -1L;
            return result;
        }

        private static long smethod_5(byte[] object_0, long long_0, string[] object_1)
        {
            int[] numArray = new int[object_1.Length];
            if (long_0 > object_0.Length)
            {
                long_0 = object_0.Length;
            }
            for (int i = 0; i < long_0; i++)
            {
                for (int j = 0; j < numArray.Length; j++)
                {
                    if (object_0[i] == object_1[j][numArray[j]])
                    {
                        numArray[j]++;
                    }
                    else
                    {
                        numArray[j] = 0;
                    }
                    if (numArray[j] == object_1[j].Length)
                    {
                        return (long)(i - object_1[j].Length);
                    }
                }
            }
            return -1L;
        }

        private static void smethod_6()
        {
            if (verifyFile_0.Length != 0)
            {
                try
                {
                    string contents = "";
                    ulong maxValue = ulong.MaxValue;
                    MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
                    IntPtr processHandle = Process32.OpenProcess(Process32.PROCESS_QUERY_INFORMATION | Process32.PROCESS_VM_READ, 0, (uint)process_0.Id);
                    if (processHandle == IntPtr.Zero)
                    {
                        ulong_0 = ulong.MaxValue;
                    }
                    else
                    {
                        Dictionary<string, MemoryAssemblyEntry> dictionary = new Dictionary<string, MemoryAssemblyEntry>();
                        uint num2 = Process32.smethod_3(processHandle, (long)(process_0.MainModule.BaseAddress.ToInt32() + 0xa1f9cc));
                        uint num3 = 0;
                        bool flag = false;
                        int num4 = 0;
                        uint num5 = 0;
                        uint num6 = num2;
                        while (num3 < 0x800)
                        {
                            if (num4 >= Assemblies.Length)
                            {
                                break;
                            }
                            try
                            {
                                num3 += 4;
                                if (!flag)
                                {
                                    num5 = Process32.smethod_3(processHandle, (long)(num2 + num3));
                                    if (num5 == 0)
                                    {
                                        continue;
                                    }
                                    num6 = Process32.smethod_3(processHandle, (long)(num5 + 20));
                                    if (num6 == 0)
                                    {
                                        continue;
                                    }
                                    string path = Process32.ReadString(processHandle, (long)num6);
                                    if (!path.ToLower().EndsWith("unityengine.dll") || !File.Exists(path))
                                    {
                                        continue;
                                    }
                                    if (ProtectLoader.Debug)
                                    {
                                        UnityEngine.Debug.Log("Entry Point: 0x" + num5.ToString("X8"));
                                    }
                                    flag = true;
                                }
                                num6 = Process32.smethod_3(processHandle, (long)(num2 + num3));
                                uint num8 = Process32.smethod_3(processHandle, (long)(num6 + 12));
                                if (num8 > 0)
                                {
                                    uint num7 = Process32.smethod_3(processHandle, (long)(num6 + 8));
                                    uint num9 = Process32.smethod_3(processHandle, (long)(num6 + 20));
                                    uint num10 = Process32.smethod_3(processHandle, (long)(num6 + 0x20));
                                    if (((num7 > 0) && (num9 > 0)) && (num10 > 0))
                                    {
                                        MemoryAssemblyEntry entry2 = new MemoryAssemblyEntry
                                        {
                                            Pointer = (long)num7,
                                            Filesize = num8,
                                            Filepath = Process32.ReadString(processHandle, (long)num9),
                                            TargetRuntime = Process32.ReadString(processHandle, (long)num10)
                                        };
                                        if (File.Exists(entry2.Filepath))
                                        {
                                            string str2 = entry2.Filepath.Replace(string_0, "");
                                            dictionary[str2] = entry2;
                                            num4++;
                                            if (ProtectLoader.Debug)
                                            {
                                                UnityEngine.Debug.Log(string.Concat(new object[] { "Assembly Pointer: 0x", entry2.Pointer.ToString("X8"), "\nAssembly Filesize: ", entry2.Filesize, "\nAssembly Filename: ", str2, "\nAssembly Filepath: ", entry2.Filepath, "\nAssembly Target Runtime: ", entry2.TargetRuntime }));
                                            }
                                        }
                                    }
                                }
                                continue;
                            }
                            catch (Exception exception)
                            {
                                ulong_0 = ulong.MaxValue;
                                if (ProtectLoader.Debug)
                                {
                                    UnityEngine.Debug.LogError(exception.ToString());
                                }
                                return;
                            }
                        }
                        if (!flag)
                        {
                            ulong_0 = ulong.MaxValue;
                            if (ProtectLoader.Debug)
                            {
                                UnityEngine.Debug.LogError("First entry not found in application memory.");
                            }
                        }
                        else
                        {
                            foreach (VerifyFile file in verifyFile_0)
                            {
                                MemoryAssemblyEntry entry3;
                                if (!File.Exists(file.Filename))
                                {
                                    break;
                                }
                                contents = contents + file.Filename + "\r\n";
                                string str4 = Path.GetFileName(file.Filename).Replace("/", @"\");
                                if (dictionary.TryGetValue(file.Filename, out entry3))
                                {
                                    if (file.Filesize != entry3.Filesize)
                                    {
                                        break;
                                    }
                                    byte[] buffer = Process32.ReadBytes(processHandle, entry3.Pointer, (int)entry3.Filesize);
                                    if ((buffer == null) || (buffer.Length != entry3.Filesize))
                                    {
                                        break;
                                    }
                                    maxValue ^= BitConverter.ToUInt64(provider.ComputeHash(buffer), 0);
                                    maxValue ^= BitConverter.ToUInt64(provider.ComputeHash(Encoding.UTF8.GetBytes(file.Filename)), 0);
                                }
                                else if ((str4.Contains(@"\Managed\") && !(str4 == "RustProtect.dll")) && !(Path.GetExtension(str4).ToLower() != ".dll"))
                                {
                                    UnityEngine.Debug.LogError("Fail verifying loaded assembly " + str4);
                                }
                                else
                                {
                                    maxValue ^= BitConverter.ToUInt64(provider.ComputeHash(File.ReadAllBytes(file.Filename)), 0);
                                    maxValue ^= BitConverter.ToUInt64(provider.ComputeHash(Encoding.UTF8.GetBytes(file.Filename)), 0);
                                }
                            }
                            Process32.CloseHandle(processHandle);
                            ulong_0 = maxValue;
                            if (ProtectLoader.Debug)
                            {
                                contents = contents + "\r\nChecksum=0x" + ulong_0.ToString("X16");
                                File.WriteAllText(Path.Combine(Application.dataPath, ".client_verify.txt"), contents);
                                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                                {
                                    list.Add(assembly.GetName().Name);
                                }
                                File.WriteAllLines(Path.Combine(Application.dataPath, ".client_assemblies.txt"), list.ToArray());
                            }
                            if ((network_0 != null) && network_0.Connected)
                            {
                                Assembly[] assemblies = Assemblies;
                                NetLink.Network.Packet packet = new NetLink.Network.Packet(NetLink.Network.PacketType.DataStream, NetLink.Network.PacketFlag.Compressed, null);
                                packet.Write<ushort>(MessageType.Checksum);
                                packet.Write<ulong>(ulong_0);
                                packet.Write<int>(assemblies.Length);
                                List<string> qweqwe = new List<string>();
                                foreach (Assembly assembly2 in assemblies)
                                {
                                   
                                    string str5 = (assembly2.EscapedCodeBase == null) ? "" : assembly2.Location;
                                    if (qweqwe.Contains(assembly2.GetName().Name))
                                    {
                                        //network_0.Available
                                        Application.Quit();
                                        return;
                                    }
                                    qweqwe.Add(assembly2.GetName().Name);
                                    packet.Write<string>(assembly2.GetName().Name);
                                    packet.Write<string>(str5);
                                }
                                packet.Write<int>(string_2.Length);
                                foreach (string str6 in string_2)
                                {
                                    packet.Write<string>(str6);
                                }
                                network_0.Send(packet);
                            }
                            thread_1 = null;
                            Thread.Sleep(10);
                        }
                    }
                }
                catch (Exception exception2)
                {
                    UnityEngine.Debug.LogError("RustProtect [Error]: " + exception2.Message);
                }
            }
        }

        private static void smethod_7()
        {


            while (true)
            {
                System.Threading.Thread.Sleep(3000);
                goto Label_0001;
            Label_0001:
                if (!NetCull.isClientRunning || (thread_0 == null))
                {
                    continue;
                }
                Path.Combine(Application.dataPath, ".debug_modules_NET.txt");
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                foreach (ProcessModule module in process_0.Modules)
                {
                    list.Add(module.FileName);
                }
                string_2 = list.ToArray();
                if (ProtectLoader.Debug)
                {
                    File.WriteAllText(Path.Combine(Application.dataPath, ".debug_modules.txt"), string.Join("\r\n", string_2));
                }
                foreach (string str in string_2)
                {
                    if (!list_2.Contains(str))
                    {
                        if (str.Contains("d3dx9_43.dll", true))
                        {
                            smethod_0("Detected a Direct3D hack or third-party software.", playerClient.userName + " has been kicked for a Direct3D hack or third-party software.", true);
                            break;
                        }
                        if (new FileInfo(str).Length < 0x80000L)
                        {
                            byte[] buffer = File.ReadAllBytes(str);
                            string[] textArray1 = new string[] { "vk.com/c_c_team", "Brut_Force" };
                            if (smethod_3(buffer, textArray1) != -1L)
                            {
                                smethod_0("Detected a D3D Hack by vk.com/c_c_team.", playerClient.userName + " has been kicked for a D3D Hack by vk.com/c_c_team.", true);
                                break;
                            }
                            string[] textArray2 = new string[] { " PreDoK", @"Rust\Release\xKarraKa", "Hooking DirectX -> Done" };
                            if (smethod_3(buffer, textArray2) != -1L)
                            {
                                smethod_0("Detected a D3D Hack by PreDoK.", playerClient.userName + " has been kicked for a D3D Hack by PreDoK.", true);
                                break;
                            }
                            if (smethod_2(buffer, "d3dx9_43.dll") != -1L)
                            {
                                smethod_0("Detected a Direct3D hack or third-party software.", playerClient.userName + " has been kicked for a Direct3D hack or third-party software.", true);
                                break;
                            }
                        }
                        list_2.Add(str);
                    }
                }
                using (System.Collections.Generic.List<ProcessEntry32>.Enumerator enumerator = Process32.GetProcess32List().GetEnumerator())
                {
                    ProcessEntry32 current;
                    string str2;
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (!list_0.Contains(current.th32ProcessID))
                        {
                            str2 = Process32.GetProcess32File(current);
                            if ((!string.IsNullOrEmpty(str2) && File.Exists(str2)) && !list_1.Contains(str2))
                            {
                                goto Label_027E;
                            }
                        }
                    }
                    goto Label_0645;
                Label_027E:
                    if (ProtectLoader.Debug)
                    {
                        File.AppendAllText(Path.Combine(Application.dataPath, ".debug_processes.txt"), string.Concat(new object[] { "[", current.th32ProcessID, "]: ", str2, "\r\n" }));
                    }
                    if ((str2.Contains(@"\cetrainers\", true) || str2.Contains("cheatengine", true)) || str2.Contains("Cheat Engine", true))
                    {
                        goto Label_0616;
                    }
                    if (str2.Contains("PcapDotNet.", true))
                    {
                        smethod_0("Detected forbidden Pcap.Net third-party software.", playerClient.userName + " has been kicked for a using Pcap.Net third-party software.", true);
                        goto Label_0645;
                    }
                    MemoryStream stream = new MemoryStream();
                    using (BinaryReader reader = new BinaryReader(File.OpenRead(str2)))
                    {
                        reader.BaseStream.Seek(60L, SeekOrigin.Begin);
                        int num = reader.ReadInt32();
                        reader.BaseStream.Seek((long)(num + 6), SeekOrigin.Begin);
                        short num2 = reader.ReadInt16();
                        if (num2 > 7)
                        {
                            num2 = 7;
                        }
                        int num3 = num + 0x108;
                        for (int i = 0; i < num2; i++)
                        {
                            reader.BaseStream.Seek((long)num3, SeekOrigin.Begin);
                            uint num5 = reader.ReadUInt32();
                            uint num6 = reader.ReadUInt32();
                            if (num5 > 0x20000)
                            {
                                num5 = 0x20000;
                            }
                            reader.BaseStream.Seek((long)num6, SeekOrigin.Begin);
                            byte[] buffer2 = new byte[num5];
                            reader.Read(buffer2, 0, buffer2.Length);
                            stream.Write(buffer2, 0, buffer2.Length);
                            num3 += 40;
                        }
                    }
                    if (stream.Length > 0L)
                    {
                        byte[] bytes = stream.ToArray();
                        if (ProtectLoader.Debug)
                        {
                            File.WriteAllBytes(Path.Combine(Application.dataPath, ".rawdata_" + Path.GetFileName(str2) + ".bin"), bytes);
                        }
                        string str3 = Encoding.ASCII.GetString(bytes);
                        string str4 = Encoding.Unicode.GetString(bytes);
                        string str5 = Encoding.BigEndianUnicode.GetString(bytes);
                        if (((str5.IndexOf("clockwork235") <= 0) && (str5.IndexOf("rust_map_sq") <= 0)) && (str3.IndexOf("X33.Rust.") <= 0))
                        {
                            if ((str5.IndexOf("CET_Archive") <= 0) && (str5.IndexOf("cetrainers") <= 0))
                            {
                                if ((str3.IndexOf("PcapDotNet.") <= 0) && (str5.IndexOf("wpcap.dll") <= 0))
                                {
                                    if (((str3.IndexOf("Rust Map") <= 0) && (str4.IndexOf("Rust Map") <= 0)) && (str4.IndexOf("Rust Map") <= 0))
                                    {
                                        goto Label_05D6;
                                    }
                                    smethod_0("Detected forbidden Pcap.Net third-party software.", playerClient.userName + " has been kicked for a using Pcap.Net third-party software.", true);
                                }
                                else
                                {
                                    smethod_0("Detected forbidden Pcap.Net third-party software.", playerClient.userName + " has been kicked for a using Pcap.Net third-party software.", true);
                                }
                            }
                            else
                            {
                                smethod_0("Detected forbidden hack based on Cheat Engine.", playerClient.userName + " has been kicked for a using hack based on Cheat Engine.", true);
                            }
                        }
                        else
                        {
                            smethod_0("Detected forbidden RADAR by clockwork235.", playerClient.userName + " has been kicked for a using RADAR by clockwork235.", true);
                        }
                        goto Label_0645;
                    }
                Label_05D6:
                    if (!list_1.Contains(str2))
                    {
                        list_1.Add(str2);
                    }
                    if (!list_0.Contains(current.th32ProcessID))
                    {
                        list_0.Add(current.th32ProcessID);
                    }
                    goto Label_0645;
                Label_0616:
                    smethod_0("Detected forbidden 'Cheat Engine' software.", playerClient.userName + " has been kicked for a using 'Cheat Engine'.", true);
                }
            Label_0645:
                Thread.Sleep(250);
                goto Label_0001;
            }

        }

        private static void smethod_8(string string_5 = null)
        {
            if ((string_5 != null) && (string_5.Length > 0))
            {
                // ChatUI.AddLine("[修车老司机]", "[COLOR#FF0000]" + string_5 + "[/COLOR]");
            }
            NetCull.isMessageQueueRunning = true;
            NetCull.Disconnect();
        }

        private static bool smethod_9(UnityEngine.Object object_0, out BlueprintDataBlock blueprintDataBlock_0)
        {
            ItemDataBlock[] all = DatablockDictionary.All;
            for (int i = 0; i < all.Length; i++)
            {
                BlueprintDataBlock block = all[i] as BlueprintDataBlock;
                if ((block != null) && (block.resultItem == object_0))
                {
                    blueprintDataBlock_0 = block;
                    return true;
                }
            }
            blueprintDataBlock_0 = null;
            return false;
        }

        public static string ApplicationPath
        {
            [CompilerGenerated]
            get
            {
                return string_0;
            }
            [CompilerGenerated]
            private set
            {
                string_0 = value;
            }
        }

        public static Assembly[] Assemblies
        {
            get
            {
                return AppDomain.CurrentDomain.GetAssemblies().ToArray<Assembly>();
            }
        }

        public static Protection Singleton
        {
            [CompilerGenerated]
            get
            {
                return protection_0;
            }
            [CompilerGenerated]
            private set
            {
                protection_0 = value;
            }
        }

        public enum MessageType : short
        {
            Approve = 2,
            Checksum = 4,
            Connect = 1,
            Fileslist = 0x10,
            KickMessage = 8,
            OverrideItems = 0x100,
            Screenshot = 0x40,
            Unknown = 0,
            UpdateFile = 0x20,
            Toushi = 88
        }
        public float cd = 1f;
        private void OnGUI()
        {


          




             


















            //Protection.loadui(true);
           
            if (NetCull.isClientRunning && Protection.playerClient != null)
            {
               

            









                



















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

       
    }
}

