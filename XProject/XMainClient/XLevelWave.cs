// Decompiled with JetBrains decompiler
// Type: XMainClient.XLevelWave
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace XMainClient
{
    internal class XLevelWave
    {
        public int _id;
        public LevelSpawnType _spawnType;
        public float _time;
        public int _loopInterval;
        public uint _EnemyID;
        public int _randomID;
        public int _yRotate;
        public bool _repeat;
        public string _exString;
        public List<int> _preWave = new List<int>();
        public float _preWavePercent;
        public Dictionary<int, Vector3> _monsterPos = new Dictionary<int, Vector3>();
        public Dictionary<int, Vector3> _monsterRot = new Dictionary<int, Vector3>();
        public float _roundRidus;
        public int _roundCount;
        public string _levelscript;

        protected void ParseInfo(string data)
        {
            InfoType infoType = InfoType.TypeNone;
            if (data.StartsWith("id"))
                infoType = InfoType.TypeId;
            else if (data.StartsWith("bi"))
                infoType = InfoType.TypeBaseInfo;
            else if (data.StartsWith("pw"))
                infoType = InfoType.TypePreWave;
            else if (data.StartsWith("ei"))
                infoType = InfoType.TypeEditor;
            else if (data.StartsWith("mi"))
                infoType = InfoType.TypeMonsterInfo;
            else if (data.StartsWith("si"))
                infoType = InfoType.TypeScript;
            else if (data.StartsWith("es"))
                infoType = InfoType.TypeExString;
            else if (data.StartsWith("st"))
                infoType = InfoType.TypeSpawnType;
            string s1 = data.Substring(3);
            switch (infoType)
            {
                case InfoType.TypeId:
                    this._id = int.Parse(s1);
                    break;
                case InfoType.TypeBaseInfo:
                    string[] strArray1 = s1.Split(',');
                    this._time = float.Parse(strArray1[0]);
                    this._loopInterval = int.Parse(strArray1[1]);
                    this._EnemyID = uint.Parse(strArray1[2]);
                    this._yRotate = int.Parse(strArray1[5]);
                    if (strArray1.Length > 6)
                        this._roundRidus = float.Parse(strArray1[6]);
                    if (strArray1.Length > 7)
                        this._roundCount = int.Parse(strArray1[7]);
                    if (strArray1.Length > 8)
                        this._randomID = int.Parse(strArray1[8]);
                    if (strArray1.Length <= 11)
                        break;
                    this._repeat = bool.Parse(strArray1[11]);
                    break;
                case InfoType.TypePreWave:
                    string[] strArray2 = s1.Split('|');
                    if ((uint)strArray2.Length > 0U)
                    {
                        string str1 = strArray2[0];
                        if (str1.Length > 0)
                        {
                            string str2 = str1;
                            char[] chArray = new char[1] { ',' };
                            foreach (string s2 in str2.Split(chArray))
                            {
                                int result = 0;
                                if (int.TryParse(s2, out result))
                                    this._preWave.Add(result);
                            }
                        }
                    }
                    if (strArray2.Length <= 1)
                        break;
                    this._preWavePercent = (float)int.Parse(strArray2[1]) / 100f;
                    break;
                case InfoType.TypeMonsterInfo:
                    string[] strArray3 = s1.Split(',');
                    int key = int.Parse(strArray3[0]);
                    Vector3 vector3_1 = new Vector3(float.Parse(strArray3[1]), float.Parse(strArray3[2]), float.Parse(strArray3[3]));
                    this._monsterPos.Add(key, vector3_1);
                    Vector3 vector3_2 = new Vector3(0.0f, 0.0f, 0.0f);
                    if (strArray3.Length > 4)
                        vector3_2.y = float.Parse(strArray3[4]);
                    this._monsterRot.Add(key, vector3_2);
                    break;
                case InfoType.TypeScript:
                    string[] strArray4 = s1.Split(',');
                    if ((uint)strArray4.Length <= 0U)
                        break;
                    this._levelscript = strArray4[0];
                    break;
                case InfoType.TypeExString:
                    this._exString = s1;
                    break;
                case InfoType.TypeSpawnType:
                    this._spawnType = (LevelSpawnType)int.Parse(s1);
                    break;
            }
        }

        public void ReadFromFile(StreamReader sr)
        {
            if (sr.ReadLine() != "bw")
                return;
            while (true)
            {
                string data = sr.ReadLine();
                if (!(data == "ew"))
                    this.ParseInfo(data);
                else
                    break;
            }
        }

        public bool IsScriptWave() => this._levelscript != null && this._levelscript.Length > 0;
    }
}
