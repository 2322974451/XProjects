

using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
    public class XMeshPartList
    {
        public static byte NormalPart = 1;
        public static byte OnePart = 3;
        public static byte CutoutPart = 7;
        public static byte ReplacePart = 8;
        public static byte ReplaceTex = 16;
        public static byte ShareTex = 32;
        public string[] partSuffix = new string[9];
        public string[] proPrefix = (string[])null;
        public string sharedPrefix = (string)null;
        public Dictionary<uint, byte> meshPartsInfo = (Dictionary<uint, byte>)null;
        public Dictionary<uint, string> replaceMeshPartsInfo = (Dictionary<uint, string>)null;
        public Dictionary<uint, string> replaceTexPartsInfo = (Dictionary<uint, string>)null;

        public static byte ConvertType(byte type)
        {
            switch (type)
            {
                case 1:
                    return 3;
                case 3:
                    return 3;
                case 7:
                    return 7;
                default:
                    return 3;
            }
        }

        public bool GetMeshInfo(
          string location,
          int professionType,
          int part,
          string srcDir,
          out byte partType,
          ref string meshLocation,
          ref string texLocation)
        {
            partType = (byte)0;
            uint key = XSingleton<XCommon>.singleton.XHash(location);
            if (!this.meshPartsInfo.TryGetValue(key, out partType))
                return false;
            if ((int)partType > (int)XMeshPartList.CutoutPart)
            {
                if (((uint)partType & (uint)XMeshPartList.ReplacePart) > 0U)
                {
                    partType &= (byte)~XMeshPartList.ReplacePart;
                    if (this.replaceMeshPartsInfo.TryGetValue(key, out meshLocation))
                    {
                        string str1 = this.proPrefix[professionType];
                        string str2 = this.partSuffix[part];
                        meshLocation = string.Format("Equipments/{0}/{1}{2}", (object)meshLocation, (object)str1, (object)str2);
                        key = XSingleton<XCommon>.singleton.XHash(meshLocation);
                    }
                }
                if (((uint)partType & (uint)XMeshPartList.ReplaceTex) > 0U)
                {
                    partType &= (byte)~XMeshPartList.ReplaceTex;
                    if (this.replaceTexPartsInfo.TryGetValue(key, out texLocation))
                        texLocation = !texLocation.StartsWith("/") ? string.Format("Equipments/Player/{0}", (object)texLocation) : (!string.IsNullOrEmpty(srcDir) ? (!srcDir.StartsWith("/") ? string.Format("Equipments/{0}{1}", (object)srcDir, (object)texLocation) : string.Format("Equipments{0}{1}", (object)srcDir, (object)texLocation)) : (string)null);
                }
                else if (((uint)partType & (uint)XMeshPartList.ShareTex) > 0U)
                {
                    partType &= (byte)~XMeshPartList.ShareTex;
                    if (this.proPrefix != null && professionType < this.proPrefix.Length)
                    {
                        string oldValue = this.proPrefix[professionType];
                        texLocation = location.Replace(oldValue, this.sharedPrefix);
                    }
                }
            }
            return true;
        }

        public void Load()
        {
            if (this.meshPartsInfo != null)
                this.meshPartsInfo.Clear();
            if (this.replaceMeshPartsInfo != null)
                this.replaceMeshPartsInfo.Clear();
            XBinaryReader reader = XSingleton<XResourceLoaderMgr>.singleton.ReadBinary("Equipments/equipmentInfo", ".bytes", true);
            if (reader != null)
            {
                try
                {
                    int length1 = reader.ReadInt32();
                    this.proPrefix = new string[length1];
                    for (int index = 0; index < length1; ++index)
                        this.proPrefix[index] = reader.ReadString();
                    int num1 = reader.ReadInt32();
                    for (int index = 0; index < num1; ++index)
                    {
                        if (index < this.partSuffix.Length)
                            this.partSuffix[index] = reader.ReadString();
                    }
                    this.sharedPrefix = reader.ReadString();
                    int length2 = reader.ReadInt32();
                    string[] strArray = new string[length2];
                    for (int index = 0; index < length2; ++index)
                        strArray[index] = reader.ReadString();
                    int capacity1 = reader.ReadInt32();
                    if (this.meshPartsInfo == null)
                        this.meshPartsInfo = new Dictionary<uint, byte>(capacity1);
                    for (int index = 0; index < capacity1; ++index)
                        this.meshPartsInfo[reader.ReadUInt32()] = reader.ReadByte();
                    int capacity2 = reader.ReadInt32();
                    if (this.replaceMeshPartsInfo == null)
                        this.replaceMeshPartsInfo = new Dictionary<uint, string>(capacity2);
                    for (int index = 0; index < capacity2; ++index)
                    {
                        uint key = reader.ReadUInt32();
                        ushort num2 = reader.ReadUInt16();
                        string str = strArray[(int)num2];
                        this.replaceMeshPartsInfo[key] = str;
                    }
                    int capacity3 = reader.ReadInt32();
                    if (this.replaceTexPartsInfo == null)
                        this.replaceTexPartsInfo = new Dictionary<uint, string>(capacity3);
                    for (int index = 0; index < capacity3; ++index)
                    {
                        uint key = reader.ReadUInt32();
                        ushort num3 = reader.ReadUInt16();
                        string str = strArray[(int)num3];
                        this.replaceTexPartsInfo[key] = str;
                    }
                }
                catch (Exception ex)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog(ex.Message);
                }
            }
            XSingleton<XResourceLoaderMgr>.singleton.ClearBinary(reader, true);
        }
    }
}
