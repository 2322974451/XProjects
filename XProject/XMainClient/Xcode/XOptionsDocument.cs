

using KKSG;
using MiniJSON;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XOptionsDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("OptionsDocument");
        private XOptionsView _view = (XOptionsView)null;
        public static readonly int SIGHT_NUM = 3;
        public static readonly int MAGNIFICATION_MULTIPLE = 1000;
        private readonly int[] _QualityLevel = new int[3]
        {
      0,
      3,
      5
        };
        private Dictionary<XOptionsDefine, int> options = new Dictionary<XOptionsDefine, int>((IEqualityComparer<XOptionsDefine>)new XFastEnumIntEqualityComparer<XOptionsDefine>());
        private Dictionary<XOptionsDefine, float> floatOptions = new Dictionary<XOptionsDefine, float>((IEqualityComparer<XOptionsDefine>)new XFastEnumIntEqualityComparer<XOptionsDefine>());
        private Dictionary<XOptionsDefine, string> strOptions = new Dictionary<XOptionsDefine, string>((IEqualityComparer<XOptionsDefine>)new XFastEnumIntEqualityComparer<XOptionsDefine>());
        public static Dictionary<string, int> pushSettings = new Dictionary<string, int>();
        public static Dictionary<string, int> localPushSetting = new Dictionary<string, int>();
        public static PushSetting _pushSettingTable = new PushSetting();
        public static PushMessageTable _pushMessageTable = new PushMessageTable();
        public static List<PushSetting.RowData> _pushSetting1 = new List<PushSetting.RowData>();
        public static List<PushSetting.RowData> _pushSetting2 = new List<PushSetting.RowData>();
        public static XOptions _optionsTable = new XOptions();
        public static List<List<List<XOptions.RowData>>> optionsData = new List<List<List<XOptions.RowData>>>();
        public static Dictionary<XOptionsDefine, XOptionsDocument.OptionData> optionsDefault = new Dictionary<XOptionsDefine, XOptionsDocument.OptionData>((IEqualityComparer<XOptionsDefine>)new XFastEnumIntEqualityComparer<XOptionsDefine>());
        public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();
        public bool openVoice = true;
        public float voiceVolme = 1f;
        private float bgmVolme;
        private float mscVolme;
        public bool Flowerrain;
        private static XOptionsDocument.OptionData optionDefault = new XOptionsDocument.OptionData();
        private float lastSameScreenValue;
        private float lastSound = -1f;
        private float lastMusic = -1f;
        private float lastVoice = -1f;
        private bool openSound;
        private bool openMusic;

        public override uint ID => XOptionsDocument.uuID;

        public XOptionsView View
        {
            get => this._view;
            set => this._view = value;
        }

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            this.LoadSetting();
            this.RefreshLocalSettings();
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("push_local_clear", "");
        }

        public static void Execute(OnLoadedCallback callback = null)
        {
            XOptionsDocument.AsyncLoader.AddTask("Table/PushSetting", (CVSReader)XOptionsDocument._pushSettingTable);
            XOptionsDocument.AsyncLoader.AddTask("Table/PushMessage", (CVSReader)XOptionsDocument._pushMessageTable);
            XOptionsDocument.AsyncLoader.AddTask("Table/XOptions", (CVSReader)XOptionsDocument._optionsTable);
            XOptionsDocument.AsyncLoader.Execute(callback);
        }

        public static void OnTableLoaded()
        {
            XOptionsDocument.pushSettings.Clear();
            for (int index = 0; index < XOptionsDocument._pushSettingTable.Table.Length; ++index)
            {
                if (XOptionsDocument._pushSettingTable.Table[index].TimeOrSystem == 1U)
                    XOptionsDocument._pushSetting1.Add(XOptionsDocument._pushSettingTable.Table[index]);
                else if (XOptionsDocument._pushSettingTable.Table[index].TimeOrSystem == 2U)
                    XOptionsDocument._pushSetting2.Add(XOptionsDocument._pushSettingTable.Table[index]);
                string configKey = XOptionsDocument._pushSettingTable.Table[index].ConfigKey;
                XOptionsDocument.pushSettings.Add(configKey, 1);
            }
            XOptionsDocument.optionsData.Clear();
            for (int index1 = 0; index1 < XFastEnumIntEqualityComparer<OptionsBattleTab>.ToInt(OptionsBattleTab.OtherTab); ++index1)
            {
                XOptionsDocument.optionsData.Add(new List<List<XOptions.RowData>>());
                XOptions.RowData optionData = XOptionsDocument.GetOptionData((XOptionsDefine)(1101 + index1));
                if (optionData.OptionText != null)
                {
                    for (int index2 = 0; index2 < optionData.OptionText.Length; ++index2)
                        XOptionsDocument.optionsData[index1].Add(new List<XOptions.RowData>());
                }
                else
                    XOptionsDocument.optionsData[index1].Add(new List<XOptions.RowData>());
            }
            for (int index3 = 0; index3 < XOptionsDocument._optionsTable.Table.Length; ++index3)
            {
                int id = XOptionsDocument._optionsTable.Table[index3].ID;
                int num1 = XOptionsDocument._optionsTable.Table[index3].Classify[0];
                int num2 = XOptionsDocument._optionsTable.Table[index3].Classify[1];
                int type = XOptionsDocument._optionsTable.Table[index3].Type;
                int sort = XOptionsDocument._optionsTable.Table[index3].Sort;
                if (id > 0)
                {
                    XOptions.RowData rowData = XOptionsDocument._optionsTable.Table[index3];
                    if ((uint)rowData.ID > 0U)
                    {
                        XOptionsDocument.optionDefault.Init();
                        string[] strArray1 = rowData.Default.Split('|');
                        XOptionsDocument.optionDefault.NeedSight = strArray1.Length != 1;
                        for (int index4 = 0; index4 < XOptionsDocument.SIGHT_NUM; ++index4)
                        {
                            string[] strArray2 = (strArray1.Length != 1 ? strArray1[index4] : strArray1[0]).Split('=');
                            XOptionsDocument.optionDefault.NeedProfession[index4] = strArray2.Length != 1;
                            for (int index5 = 0; index5 < XGame.RoleCount; ++index5)
                            {
                                string str = strArray2.Length != 1 ? strArray2[index5] : strArray2[0];
                                XOptionsDocument.optionDefault.val[index4, index5] = str;
                            }
                        }
                        XOptionsDocument.optionsDefault.Add((XOptionsDefine)rowData.ID, XOptionsDocument.optionDefault);
                    }
                    if ((num1 != 0 || num2 != 0) && type != 0)
                    {
                        if (XOptionsDocument.optionsData.Count >= num1 && XOptionsDocument.optionsData[num1 - 1].Count >= num2)
                            XOptionsDocument.optionsData[num1 - 1][num2 - 1].Add(rowData);
                        else
                            XSingleton<XDebug>.singleton.AddErrorLog("XOptions Table Error! ID:" + (object)rowData.ID);
                    }
                }
            }
            for (int index6 = 0; index6 < XOptionsDocument.optionsData.Count; ++index6)
            {
                for (int index7 = 0; index7 < XOptionsDocument.optionsData[index6].Count; ++index7)
                    XOptionsDocument.optionsData[index6][index7].Sort(new Comparison<XOptions.RowData>(XOptionsDocument.SortCompare));
            }
        }

        public static XOptions.RowData GetOptionData(XOptionsDefine option) => XOptionsDocument.GetOptionData(XFastEnumIntEqualityComparer<XOptionsDefine>.ToInt(option));

        public static XOptions.RowData GetOptionData(int optionID) => XOptionsDocument._optionsTable.GetByID(optionID);

        private static int SortCompare(XOptions.RowData item1, XOptions.RowData item2)
        {
            int sort1 = item1.Sort;
            int sort2 = item2.Sort;
            return sort1 == sort2 ? -item1.ID.CompareTo(item2.ID) : -sort1.CompareTo(sort2);
        }

        public override void OnEnterSceneFinally()
        {
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
            if (sceneData != null && sceneData.ShieldSight != null)
            {
                for (int index = 0; index < sceneData.ShieldSight.Length; ++index)
                {
                    if ((int)sceneData.ShieldSight[index] == this.GetValue(XOptionsDefine.OD_VIEW))
                    {
                        this.SetDefaultSight(sceneData.ShieldSight);
                        break;
                    }
                }
            }
            this.SetBattleOptionValue();
            if (DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible())
                DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetView(XSingleton<XOperationData>.singleton.OperationMode);
            if (XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HORSE_RACE && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_WEEKEND4V4_HORSERACING)
                ;
        }

        private void SetDefaultSight(byte[] shieldSight)
        {
            for (XOperationMode en = XOperationMode.X25D; en <= XOperationMode.X3D_Free; ++en)
            {
                bool flag = true;
                for (int index = 0; index < shieldSight.Length; ++index)
                {
                    if ((XOperationMode)shieldSight[index] == en)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    this.SetValue(XOptionsDefine.OD_VIEW, XFastEnumIntEqualityComparer<XOperationMode>.ToInt(en));
                    XSingleton<XDebug>.singleton.AddGreenLog("Auto Change Sight:" + en.ToString());
                    return;
                }
            }
            XSingleton<XDebug>.singleton.AddErrorLog("No Default Sight");
        }

        public override void OnGamePause(bool pause)
        {
            XSingleton<XDebug>.singleton.AddLog("push_local_clear");
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("push_local_clear", "");
            if (pause)
            {
                DateTime now = DateTime.Now;
                int hour = now.Hour;
                int minute = now.Minute;
                int int32 = Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"));
                for (int index1 = 0; index1 < XOptionsDocument._pushMessageTable.Table.Length; ++index1)
                {
                    PushMessageTable.RowData row = XOptionsDocument._pushMessageTable.Table[index1];
                    if (row.IsCommonGlobal == 1U && this.IsPushOpen(row.Type))
                    {
                        if (row.WeekDay == null || row.WeekDay.Length == 0)
                        {
                            if ((long)row.Time[0] > (long)hour || (long)row.Time[0] == (long)hour && (long)row.Time[1] > (long)minute)
                                XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("push_local", this.MakeJson(row, now));
                            DateTime date1 = now.AddDays(1.0);
                            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("push_local", this.MakeJson(row, date1));
                            DateTime date2 = now.AddDays(2.0);
                            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("push_local", this.MakeJson(row, date2));
                        }
                        else
                        {
                            for (int index2 = 0; index2 < row.WeekDay.Length; ++index2)
                            {
                                if ((int)row.WeekDay[index2] == int32)
                                {
                                    if ((long)row.Time[0] > (long)hour || (long)row.Time[0] == (long)hour && (long)row.Time[1] > (long)minute)
                                        XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("push_local", this.MakeJson(row, now));
                                }
                                else if (row.WeekDay[index2] > (uint)int32)
                                {
                                    DateTime date = now.AddDays((double)((long)row.WeekDay[index2] - (long)int32));
                                    XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("push_local", this.MakeJson(row, date));
                                }
                            }
                        }
                    }
                }
            }
            base.OnGamePause(pause);
        }

        private string MakeJson(PushMessageTable.RowData row, DateTime date)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary["title"] = (object)row.Title;
            dictionary["content"] = (object)row.Content;
            dictionary["type"] = (object)1;
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                dictionary[nameof(date)] = (object)date.ToString("yyyy-MM-dd");
                dictionary["hour"] = row.Time[0] < 10U ? (object)("0" + row.Time[0].ToString()) : (object)row.Time[0].ToString();
                dictionary["min"] = row.Time[1] < 10U ? (object)("0" + row.Time[1].ToString()) : (object)row.Time[1].ToString();
            }
            else
            {
                dictionary[nameof(date)] = (object)date.ToString("yyyyMMdd");
                dictionary["hour"] = (object)row.Time[0];
                dictionary["min"] = (object)row.Time[1];
            }
            string log3 = Json.Serialize((object)dictionary);
            XSingleton<XDebug>.singleton.AddLog(Application.platform.ToString(), " => ", log3);
            return log3;
        }

        private bool IsPushOpen(uint type)
        {
            for (int index = 0; index < XOptionsDocument._pushSettingTable.Table.Length; ++index)
            {
                if ((int)XOptionsDocument._pushSettingTable.Table[index].Type == (int)type)
                    return XOptionsDocument.pushSettings[XOptionsDocument._pushSettingTable.Table[index].ConfigKey] == 1;
            }
            return true;
        }

        public void OnBlockOtherPlayers() => this.ProccessOption(XOptionsDefine.OD_BLOCKOTHERPLAYERS, this.GetValue(XOptionsDefine.OD_BLOCKOTHERPLAYERS));

        protected override void EventSubscribe()
        {
            base.EventSubscribe();
            this.RegisterEvent(XEventDefine.XEvent_AudioOperation, new XComponent.XEventHandler(this.OnChatVoiceHandled));
        }

        public void InitServerConfig(RoleConfig serverConfig)
        {
            if (serverConfig == null)
                return;
            if (serverConfig.type.Count != serverConfig.value.Count)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("serverConfig.type.Count != serverConfig.value.Count");
            }
            else
            {
                System.Type enumType = typeof(XOptionsDefine);
                for (int index = 0; index < serverConfig.type.Count; ++index)
                {
                    try
                    {
                        if (XOptionsDocument.pushSettings.ContainsKey(serverConfig.type[index]))
                        {
                            if (!XOptionsDocument.localPushSetting.ContainsKey(serverConfig.type[index]))
                                XOptionsDocument.pushSettings[serverConfig.type[index]] = int.Parse(serverConfig.value[index]);
                        }
                        else
                        {
                            XOptionsDefine xoptionsDefine = (XOptionsDefine)Enum.Parse(enumType, serverConfig.type[index]);
                            if (xoptionsDefine == XOptionsDefine.OD_TEAM_PASSWORD)
                            {
                                this.strOptions.Add(xoptionsDefine, serverConfig.value[index]);
                            }
                            else
                            {
                                XOptions.RowData optionData = XOptionsDocument.GetOptionData(xoptionsDefine);
                                if (optionData != null && (uint)optionData.Type > 0U)
                                {
                                    if (optionData.Type == 2)
                                    {
                                        float result;
                                        if (float.TryParse(serverConfig.value[index], out result))
                                            this.floatOptions[xoptionsDefine] = result;
                                        this.ProccessOption(xoptionsDefine, this.GetFloatValue(xoptionsDefine));
                                    }
                                    else
                                    {
                                        int result;
                                        if (int.TryParse(serverConfig.value[index], out result))
                                            this.options[xoptionsDefine] = result;
                                        this.ProccessOption(xoptionsDefine, this.GetValue(xoptionsDefine));
                                    }
                                }
                            }
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        XSingleton<XDebug>.singleton.AddGreenLog(string.Format("'{0}' is not a member of the XOptionsDefine enumeration.", (object)serverConfig.type[index]));
                    }
                }
            }
        }

        public void RefreshLocalSettings()
        {
            for (XOptionsDefine option = XOptionsDefine.OD_START; option != XOptionsDefine.OD_LOCALSETTING_END; ++option)
                this.ProccessOption(option, this.GetValue(option));
        }

        public void LoadSetting()
        {
            string path = Application.persistentDataPath + "/options.txt";
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                path = Application.dataPath + "/options.txt";
            this.options.Clear();
            if (!File.Exists(path))
                return;
            using (StreamReader streamReader = new StreamReader(path))
            {
                System.Type enumType = typeof(XOptionsDefine);
                string log2;
                while ((log2 = streamReader.ReadLine()) != null)
                {
                    string[] strArray = log2.Split(XGlobalConfig.SpaceSeparator);
                    if (strArray.Length != 2)
                    {
                        XSingleton<XDebug>.singleton.AddErrorLog("Option file format error: ", log2);
                    }
                    else
                    {
                        try
                        {
                            if (XOptionsDocument.pushSettings.ContainsKey(strArray[0]))
                            {
                                int num = int.Parse(strArray[1]);
                                XOptionsDocument.pushSettings[strArray[0]] = num;
                                XOptionsDocument.localPushSetting[strArray[0]] = num;
                            }
                            else
                                this.options.Add((XOptionsDefine)Enum.Parse(enumType, strArray[0]), int.Parse(strArray[1]));
                        }
                        catch (ArgumentException ex)
                        {
                            XSingleton<XDebug>.singleton.AddErrorLog(string.Format("'{0}' is not a member of the XOptionsDefine enumeration.", (object)strArray[0]));
                        }
                    }
                }
            }
        }

        public void SaveSetting()
        {
            try
            {
                string str = Application.persistentDataPath + "/options.txt";
                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                    str = Application.dataPath + "/options.txt";
                using (StreamWriter streamWriter = new StreamWriter(str))
                {
                    foreach (KeyValuePair<string, int> keyValuePair in XOptionsDocument.localPushSetting)
                    {
                        streamWriter.Write(keyValuePair.Key);
                        streamWriter.Write(' ');
                        streamWriter.WriteLine(keyValuePair.Value);
                    }
                    foreach (KeyValuePair<XOptionsDefine, int> option in this.options)
                    {
                        if (option.Key < XOptionsDefine.OD_LOCALSETTING_END)
                        {
                            streamWriter.Write((object)option.Key);
                            streamWriter.Write(' ');
                            streamWriter.WriteLine(option.Value);
                        }
                    }
                    foreach (KeyValuePair<XOptionsDefine, float> floatOption in this.floatOptions)
                    {
                        if (floatOption.Key < XOptionsDefine.OD_LOCALSETTING_END)
                        {
                            streamWriter.Write((object)floatOption.Key);
                            streamWriter.Write(' ');
                            streamWriter.WriteLine(floatOption.Value);
                        }
                    }
                    XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SetNoBackupFlag(str);
                }
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Save Setting Error");
            }
        }

        public void ReqSwitchAccount()
        {
            XSingleton<XClientNetwork>.singleton.Close();
            XSingleton<XLoginDocument>.singleton.AuthorizationSignOut();
        }

        public void ReqSwitchChar() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_ReturnToSelectRole());

        public void ReqCustomerService() => XSingleton<XDebug>.singleton.AddLog("CS coming soon!");

        public void OpenCustomerService()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    dictionary["url"] = XSingleton<XGlobalConfig>.singleton.GetValue("CustomerServiceSetApple");
                    dictionary["screendir"] = "SENSOR";
                    XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)dictionary));
                    break;
                case RuntimePlatform.Android:
                    dictionary["url"] = XSingleton<XGlobalConfig>.singleton.GetValue("CustomerServiceSetAndroid");
                    dictionary["screendir"] = "SENSOR";
                    XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)dictionary));
                    break;
                default:
                    XSingleton<XDebug>.singleton.AddGreenLog("CustomerService-Options");
                    break;
            }
        }

        public void OpenURL(string url) => Application.OpenURL(url);

        public override void Update(float fDeltaT)
        {
            base.Update(fDeltaT);
            if (DlgBase<XOptionsView, XOptionsBehaviour>.singleton.IsVisible() && this.View.CurrentTab == OptionsTab.OptionTab && (double)Math.Abs(this.lastSameScreenValue - this.View.uiBehaviour.m_SameScreenBar.value) > 1E-05)
            {
                this.lastSameScreenValue = this.View.uiBehaviour.m_SameScreenBar.value;
                this.View.SameScreenNumChange(this.lastSameScreenValue);
            }
            if (DlgBase<XOptionsView, XOptionsBehaviour>.singleton.IsVisible() && this.View.CurrentTab == OptionsTab.OptionTab && (double)Math.Abs(this.lastSound - this.View.uiBehaviour.m_SoundBar.value) > 1E-05)
            {
                this.lastSound = this.View.uiBehaviour.m_SoundBar.value;
                this.SetValue(XOptionsDefine.BA_SOUND, (int)((double)this.lastSound * 100.0));
                this.ProccessOption(XOptionsDefine.BA_SOUND, (int)((double)this.lastSound * 100.0));
            }
            if (DlgBase<XOptionsView, XOptionsBehaviour>.singleton.IsVisible() && this.View.CurrentTab == OptionsTab.OptionTab && (double)Math.Abs(this.lastMusic - this.View.uiBehaviour.m_MusicBar.value) > 1E-05)
            {
                this.lastMusic = this.View.uiBehaviour.m_MusicBar.value;
                this.SetValue(XOptionsDefine.BA_MUSIC, (int)((double)this.lastMusic * 100.0));
                this.ProccessOption(XOptionsDefine.BA_MUSIC, (int)((double)this.lastMusic * 100.0));
            }
            if (!DlgBase<XOptionsView, XOptionsBehaviour>.singleton.IsVisible() || this.View.CurrentTab != OptionsTab.OptionTab || (double)Math.Abs(this.lastVoice - this.View.uiBehaviour.m_VoiceBar.value) <= 1E-05)
                return;
            this.lastVoice = this.View.uiBehaviour.m_VoiceBar.value;
            this.SetValue(XOptionsDefine.BA_VOICE, (int)((double)this.lastVoice * 100.0));
            this.ProccessOption(XOptionsDefine.BA_VOICE, (int)((double)this.lastVoice * 100.0));
        }

        private PushSetting.RowData GetPushSettingRow(string option)
        {
            for (int index = 0; index < XOptionsDocument._pushSettingTable.Table.Length; ++index)
            {
                if (XOptionsDocument._pushSettingTable.Table[index].ConfigKey == option)
                    return XOptionsDocument._pushSettingTable.Table[index];
            }
            return (PushSetting.RowData)null;
        }

        public void SavePushValue(string option, int value)
        {
            if (XOptionsDocument.pushSettings.ContainsKey(option))
            {
                XOptionsDocument.pushSettings[option] = value;
                if (this.GetPushSettingRow(option).TimeOrSystem == 1U)
                    XOptionsDocument.localPushSetting[option] = value;
                else
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SetRoleConfig()
                    {
                        oArg = {
              type = option,
              value = value.ToString()
            }
                    });
            }
            else
                XSingleton<XDebug>.singleton.AddErrorLog("not push type ", option);
        }

        private void SaveToCloud(XOptionsDefine option, int value) => this.SaveToCloud(option, value.ToString());

        private void SaveToCloud(XOptionsDefine option, string value)
        {
            if (option <= XOptionsDefine.OD_LOCALSETTING_END)
                return;
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SetRoleConfig()
            {
                oArg = {
          type = option.ToString(),
          value = value
        }
            });
        }

        public bool SetValue(XOptionsDefine option, int value, bool isMustSave = false)
        {
            if (!isMustSave && this.GetValue(option) == value)
                return false;
            this.options[option] = value;
            this.ProccessOption(option, value);
            this.SaveToCloud(option, value);
            return true;
        }

        public bool SetSliderValue(XOptionsDefine option, float value)
        {
            if ((double)this.GetFloatValue(option) == (double)value)
                return false;
            this.floatOptions[option] = value;
            this.ProccessOption(option, value);
            this.SaveToCloud(option, value.ToString());
            return true;
        }

        public bool SetValue(XOptionsDefine option, string value)
        {
            if (this.GetStrValue(option) == value)
                return false;
            this.strOptions[option] = value;
            this.SaveToCloud(option, value);
            return true;
        }

        public int GetPushValue(string option) => XOptionsDocument.pushSettings.ContainsKey(option) ? XOptionsDocument.pushSettings[option] : 0;

        public int GetValue(XOptionsDefine option)
        {
            int num;
            return this.options.TryGetValue(option, out num) ? num : this.GetDefaultValue(option);
        }

        public float GetFloatValue(XOptionsDefine option)
        {
            float num;
            return this.floatOptions.TryGetValue(option, out num) ? num : this.GetDefaultFloatValue(option);
        }

        public string GetStrValue(XOptionsDefine option)
        {
            string str;
            return this.strOptions.TryGetValue(option, out str) ? str : this.GetDefaultStrValue(option);
        }

        private void ProccessOption(XOptionsDefine option, int value)
        {
            switch (option)
            {
                case XOptionsDefine.OD_SOUND:
                    this.openSound = value == 1;
                    this.SetBGMVolme(this.openSound ? ((double)this.lastSound == -1.0 ? 1f : this.lastSound) : 0.0f);
                    break;
                case XOptionsDefine.BA_SOUND:
                    if (!this.openSound)
                        break;
                    this.SetBGMVolme((float)value / 100f);
                    break;
                case XOptionsDefine.OD_MUSIC:
                    this.openMusic = value == 1;
                    this.SetMuscVolme(this.openMusic ? ((double)this.lastMusic == -1.0 ? 1f : this.lastMusic) : 0.0f);
                    break;
                case XOptionsDefine.BA_MUSIC:
                    if (!this.openMusic)
                        break;
                    this.SetMuscVolme((float)value / 100f);
                    break;
                case XOptionsDefine.OD_VOICE:
                    this.openVoice = value == 1;
                    this.SetVoiceVolme(this.openVoice ? ((double)this.lastVoice == -1.0 ? 1f : this.lastVoice) : 0.0f);
                    break;
                case XOptionsDefine.BA_VOICE:
                    if (!this.openVoice)
                        break;
                    this.SetVoiceVolme((float)value / 100f);
                    break;
                case XOptionsDefine.OD_VOLUME:
                    if (this.View == null)
                        break;
                    this.View.SetVolume(value);
                    break;
                case XOptionsDefine.OD_RADIO_WIFI:
                    XSingleton<XChatIFlyMgr>.singleton.SetChannelAutoPlay(ChatChannelType.ZeroChannel, value == 1);
                    break;
                case XOptionsDefine.OD_RADIO_TEAM:
                    XSingleton<XChatIFlyMgr>.singleton.SetChannelAutoPlay(ChatChannelType.Team, value == 1);
                    break;
                case XOptionsDefine.OD_RADIO_CAMP:
                    XSingleton<XChatIFlyMgr>.singleton.SetChannelAutoPlay(ChatChannelType.Camp, value == 1);
                    break;
                case XOptionsDefine.OD_RADIO_PRIVATE:
                    XSingleton<XChatIFlyMgr>.singleton.SetChannelAutoPlay(ChatChannelType.Friends, value == 1);
                    break;
                case XOptionsDefine.OD_RADIO_PUBLIC:
                    XSingleton<XChatIFlyMgr>.singleton.SetChannelAutoPlay(ChatChannelType.Guild, value == 1);
                    break;
                case XOptionsDefine.OD_RADIO_WORLD:
                    XSingleton<XChatIFlyMgr>.singleton.SetChannelAutoPlay(ChatChannelType.World, value == 1);
                    break;
                case XOptionsDefine.OD_RADIO_AUTO_PALY:
                    XSingleton<XChatIFlyMgr>.singleton.SetChannelAutoPlay(ChatChannelType.Curr, value == 1);
                    break;
                case XOptionsDefine.OD_QUALITY:
                    this._ProcessQuality(value);
                    break;
                case XOptionsDefine.OD_FLOWERRAIN:
                    this.Flowerrain = value == 1;
                    break;
                case XOptionsDefine.OD_SAMESCREENNUM:
                    XQualitySetting.SetVisibleRoleLevel(value);
                    break;
                case XOptionsDefine.OD_RADIO:
                    DlgBase<RadioDlg, RadioBehaviour>.singleton.Process(value == 1);
                    break;
                case XOptionsDefine.OD_SMOOTH:
                    XSingleton<XGameUI>.singleton.SetUIOptOption(false, value == 1, false);
                    break;
                case XOptionsDefine.OD_RESOLUTION:
                    XQualitySetting.SetResolution((XQualitySetting.EResolution)value);
                    break;
                case XOptionsDefine.OD_POWERSAVE:
                    this._ProcessPowerSave(value);
                    break;
                case XOptionsDefine.OD_NOTIFICATION:
                    this._ProcessNotification(value);
                    break;
                case XOptionsDefine.OD_BLOCKOTHERPLAYERS:
                    this._ProcessBlockOtherPlayers(value);
                    break;
                case XOptionsDefine.OD_Gyro:
                    XSingleton<XGyroscope>.singleton.Enabled = value == 1;
                    break;
                case XOptionsDefine.OD_Shield_Skill_Fx:
                    XSingleton<XInput>.singleton.UpdateShieldOperation();
                    break;
                case XOptionsDefine.OD_Shield_Summon:
                    XSingleton<XInput>.singleton.UpdateShieldOperation();
                    break;
                case XOptionsDefine.OD_Shield_My_Skill_Fx:
                    XSingleton<XInput>.singleton.UpdateShieldOperation();
                    break;
            }
        }

        private void ProccessOption(XOptionsDefine option, float value)
        {
        }

        private string GetDefaultStrValue(XOptionsDefine option) => string.Empty;

        private float GetDefaultFloatValue(XOptionsDefine option)
        {
            string configurationDefault = this.GetConfigurationDefault(option);
            return string.IsNullOrEmpty(configurationDefault) ? 0.0f : float.Parse(configurationDefault);
        }

        private int GetDefaultValue(XOptionsDefine option)
        {
            switch (option)
            {
                case XOptionsDefine.OD_QUALITY:
                    return XQualitySetting.GetDefaultQualityLevel();
                case XOptionsDefine.OD_FLOWERRAIN:
                    return XQualitySetting.GetDefaultQualityLevel() == XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt(XQualitySetting.ESetting.ELow) ? 0 : 1;
                case XOptionsDefine.OD_SAMESCREENNUM:
                    return XQualitySetting.GetDefalutVisibleRoleLevel();
                case XOptionsDefine.OD_RESOLUTION:
                    return XQualitySetting.GetDefalutResolution();
                case XOptionsDefine.OD_TAILCAMERA_SPEED:
                    return XSingleton<XEntityMgr>.singleton.Player != null ? XSingleton<XOperationData>.singleton.TailCameraSpeed : 50;
                default:
                    string configurationDefault = this.GetConfigurationDefault(option);
                    return string.IsNullOrEmpty(configurationDefault) ? 0 : int.Parse(configurationDefault);
            }
        }

        public bool IsShow3DTouch() => Application.platform == RuntimePlatform.IPhonePlayer && XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("Is_3DTouch_Supported", "");

        private void _ProcessPowerSave(int value)
        {
        }

        private void _ProcessNotification(int value) => XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SetPushStatus(true);

        private void _ProcessQuality(int value)
        {
            XQualitySetting.SetQuality(value);
            XQualitySetting.PostSetQuality();
            XQualitySetting.PostSetting();
        }

        private void _ProcessBlockOtherPlayers(int value)
        {
            if (XSingleton<XGame>.singleton.CurrentStage == null || XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall)
                return;
            XSingleton<XEntityMgr>.singleton.ToggleOtherPlayers(value == 1);
        }

        protected override void OnReconnected(XReconnectedEventArgs arg) => this.InitServerConfig(arg.PlayerInfo.config);

        private bool OnChatVoiceHandled(XEventArgs e)
        {
            if ((e as XAudioOperationArgs).IsAudioOn)
            {
                float volume = 1f;
                XApolloDocument specificDocument = XDocuments.GetSpecificDocument<XApolloDocument>(XApolloDocument.uuID);
                if (specificDocument != null && specificDocument.IsRealtimeVoiceOn)
                    volume = (float)XSingleton<XGlobalConfig>.singleton.GetInt("SetMusicVol") / 100f;
                XSingleton<XAudioMgr>.singleton.SetBusStatuMute("bus:/MainGroupControl", volume);
            }
            else
                XSingleton<XAudioMgr>.singleton.SetBusStatuMute("bus:/MainGroupControl", 0.0f);
            return true;
        }

        public void SetBGMVolme(float vol)
        {
            this.bgmVolme = Mathf.Clamp01(vol);
            XSingleton<XAudioMgr>.singleton.SetBGMVolme(this.bgmVolme);
        }

        public void SetMuscVolme(float vol)
        {
            this.mscVolme = Mathf.Clamp01(vol);
            XSingleton<XAudioMgr>.singleton.SetMscVolme(this.mscVolme);
        }

        public void SetVoiceVolme(float vol) => this.voiceVolme = vol;

        public string GetConfigurationDefault(XOptionsDefine option)
        {
            XOptionsDocument.OptionData optionData;
            if (!XOptionsDocument.optionsDefault.TryGetValue(option, out optionData))
                return (string)null;
            int num1 = optionData.NeedSight ? this.GetValue(XOptionsDefine.OD_VIEW) : 1;
            int num2;
            if (optionData.NeedProfession[num1 - 1])
            {
                if (XSingleton<XAttributeMgr>.singleton.XPlayerData == null)
                    return (string)null;
                num2 = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession) % 10;
            }
            else
                num2 = 1;
            return optionData.val[num1 - 1, num2 - 1];
        }

        public bool SetBattleOptionValue()
        {
            XSingleton<XDebug>.singleton.AddGreenLog("__RefreshBattleOptionValue");
            XOperationMode xoperationMode = (XOperationMode)this.GetValue(XOptionsDefine.OD_VIEW);
            XSingleton<XOperationData>.singleton.OperationMode = xoperationMode;
            XSingleton<XInput>.singleton.UpdateDefaultCameraOperationByScene();
            switch (xoperationMode)
            {
                case XOperationMode.X25D:
                    XSingleton<XOperationData>.singleton.TailCameraSpeed = (int)this.GetFloatValue(XOptionsDefine.OD_TailCameraSpeed25D);
                    XSingleton<XOperationData>.singleton.ManualCameraSpeedXInBattle = this.GetFloatValue(XOptionsDefine.OD_ManualCameraSpeedXInBattle25D);
                    break;
                case XOperationMode.X3D:
                    XSingleton<XOperationData>.singleton.TailCameraSpeed = (int)this.GetFloatValue(XOptionsDefine.OD_TailCameraSpeed3D);
                    XSingleton<XOperationData>.singleton.ManualCameraSpeedXInBattle = this.GetFloatValue(XOptionsDefine.OD_ManualCameraSpeedXInBattle3D);
                    if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall)
                    {
                        XSingleton<XOperationData>.singleton.AllowVertical = this.GetValue(XOptionsDefine.OD_Vertical3D) == 1;
                        break;
                    }
                    break;
                case XOperationMode.X3D_Free:
                    XSingleton<XOperationData>.singleton.TailCameraSpeed = (int)this.GetFloatValue(XOptionsDefine.OD_TailCameraSpeed3DFree);
                    XSingleton<XOperationData>.singleton.ManualCameraSpeedXInBattle = this.GetFloatValue(XOptionsDefine.OD_ManualCameraSpeedXInBattle3DFree);
                    if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall)
                        XSingleton<XOperationData>.singleton.AllowVertical = this.GetValue(XOptionsDefine.OD_Vertical3DFree) == 1;
                    XSingleton<XOperationData>.singleton.CameraDistance = this.GetFloatValue(XOptionsDefine.OD_Distance3DFree);
                    break;
            }
            XOperateMode xoperateMode = (XOperateMode)this.GetValue(XOptionsDefine.OD_OPERATE);
            int num = this.GetValue(XOptionsDefine.OD_OPERATE) - 1;
            XSingleton<XOperationData>.singleton.ManualCameraSpeedXInHall = this.GetFloatValue((XOptionsDefine)(2011 + num));
            XSingleton<XOperationData>.singleton.ManualCameraDampXInHall = this.GetFloatValue((XOptionsDefine)(2021 + num));
            XSingleton<XOperationData>.singleton.ManualCameraSpeedYInHall = this.GetFloatValue((XOptionsDefine)(2031 + num));
            XSingleton<XOperationData>.singleton.ManualCameraDampYInHall = this.GetFloatValue((XOptionsDefine)(2041 + num));
            XSingleton<XOperationData>.singleton.ManualCameraDampXInBattle = this.GetFloatValue((XOptionsDefine)(2051 + num));
            XSingleton<XOperationData>.singleton.ManualCameraSpeedYInBattle = this.GetFloatValue((XOptionsDefine)(2061 + num));
            XSingleton<XOperationData>.singleton.ManualCameraDampYInBattle = this.GetFloatValue((XOptionsDefine)(2071 + num));
            XSingleton<XOperationData>.singleton.RangeWeight = (int)this.GetFloatValue((XOptionsDefine)(2081 + num));
            XSingleton<XOperationData>.singleton.BossWeight = (int)this.GetFloatValue((XOptionsDefine)(2091 + num));
            XSingleton<XOperationData>.singleton.EliteWeight = (int)this.GetFloatValue((XOptionsDefine)(2101 + num));
            XSingleton<XOperationData>.singleton.EnemyWeight = (int)this.GetFloatValue((XOptionsDefine)(2111 + num));
            XSingleton<XOperationData>.singleton.PupetWeight = (int)this.GetFloatValue((XOptionsDefine)(2121 + num));
            XSingleton<XOperationData>.singleton.RoleWeight = (int)this.GetFloatValue((XOptionsDefine)(2131 + num));
            XSingleton<XOperationData>.singleton.ImmortalWeight = (int)this.GetFloatValue((XOptionsDefine)(2141 + num));
            XSingleton<XOperationData>.singleton.WithinScope = this.GetFloatValue((XOptionsDefine)(2151 + num));
            XSingleton<XOperationData>.singleton.WithinRange = this.GetFloatValue((XOptionsDefine)(2161 + num));
            XSingleton<XOperationData>.singleton.AssistAngle = this.GetFloatValue((XOptionsDefine)(2171 + num));
            XSingleton<XOperationData>.singleton.ProfRange = this.GetFloatValue((XOptionsDefine)(2181 + num));
            XSingleton<XOperationData>.singleton.ProfRangeLong = this.GetFloatValue((XOptionsDefine)(2191 + num));
            XSingleton<XOperationData>.singleton.ProfRangeAll = this.GetFloatValue((XOptionsDefine)(2201 + num));
            XSingleton<XOperationData>.singleton.ProfScope = (int)this.GetFloatValue((XOptionsDefine)(2221 + num));
            XSingleton<XOperationData>.singleton.CameraAdjustScope = (int)this.GetFloatValue((XOptionsDefine)(2211 + num));
            XSingleton<XInput>.singleton.UpdateOperationMode();
            XBattleSkillDocument specificDocument = XDocuments.GetSpecificDocument<XBattleSkillDocument>(XBattleSkillDocument.uuID);
            if (specificDocument.BattleView != null && specificDocument.BattleView.IsVisible())
                specificDocument.BattleView.OnSetOptionsValue();
            return true;
        }

        public struct OptionData
        {
            public string[,] val;
            public bool NeedSight;
            public bool[] NeedProfession;

            public void Init()
            {
                this.val = new string[XOptionsDocument.SIGHT_NUM, XGame.RoleCount];
                this.NeedProfession = new bool[XOptionsDocument.SIGHT_NUM];
            }
        }
    }
}
