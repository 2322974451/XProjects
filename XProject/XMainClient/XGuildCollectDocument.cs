// Decompiled with JetBrains decompiler
// Type: XMainClient.XGuildCollectDocument
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XGuildCollectDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildCollectDocument");
        public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();
        private static GuildCampPartyReward _rewardReader = new GuildCampPartyReward();
        private bool _activityState = false;
        private bool _lotteryMachineState = false;
        public List<uint> NpcPool = new List<uint>();
        public List<uint> LotteryMachineList = new List<uint>();
        public Dictionary<uint, uint> NpcIndex = new Dictionary<uint, uint>();
        public List<CollectNpcInfo> NpcList = new List<CollectNpcInfo>();
        private int _npcMaxShowNum;
        private CollectNpcRefreshMode _npcRefreshMode;
        private uint _lastMeetLotteryUid;
        private float _lotteryWaitTime;
        private string _lotteryProcessText;
        private string _lotteryProcessTips;
        private uint _lastSendNpcID = 0;
        private float _lastSendNpcTime;
        public Dictionary<uint, int> CollectUseDict = new Dictionary<uint, int>();
        public bool MainInterfaceBtnState = false;
        public List<XFx> _fxList = new List<XFx>();
        private static readonly string m_fxPath = "Effects/FX_Particle/Scene/Lzg_scene/rwts_05";
        public double SignTime;
        public uint LeftTime;
        private int SUMMONLEFTTIME = 300;
        private string NORMALNAME = "";
        private string SPECIALNAME = "";
        private uint _hallTimeToken;
        private LinkedList<ParabolaFx> _lotteryFxLink = new LinkedList<ParabolaFx>();
        private XFx _lotteryBoxFx;
        private static readonly string LotteryFlyFXPATH = "Effects/FX_Particle/UIfx/UI_ghpd_rabbit_Clip02";
        private static readonly string LotteryBoxFXPATH = "Effects/FX_Particle/UIfx/UI_ghpd_rabbit_Clip01";
        public Dictionary<uint, LotteryCD> LotteryCDInfo = new Dictionary<uint, LotteryCD>();
        public int LotteryTimes = 3;
        public float GuildCollecLotteryCD = 120f;

        public override uint ID => XGuildCollectDocument.uuID;

        public GuildCampPartyReward RewardReader => XGuildCollectDocument._rewardReader;

        public bool ActivityState => this._activityState;

        public static void Execute(OnLoadedCallback callback = null)
        {
            XGuildCollectDocument.AsyncLoader.AddTask("Table/GuildCampPartyReward", (CVSReader)XGuildCollectDocument._rewardReader);
            XGuildCollectDocument.AsyncLoader.Execute(callback);
        }

        protected override void EventSubscribe() => base.EventSubscribe();

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            this._activityState = false;
            this._lotteryMachineState = false;
        }

        public override void OnEnterSceneFinally()
        {
            base.OnEnterSceneFinally();
            if (XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_GUILD_HALL)
                return;
            this._lotteryWaitTime = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GuildCollecLotteryWaitTime"));
            this._lotteryProcessText = XStringDefineProxy.GetString("GuildCollectProcessText");
            this._lotteryProcessTips = XStringDefineProxy.GetString("GuildCollectProcessTips");
            this.LotteryTimes = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GuildCollecLotteryTimes"));
            this.GuildCollecLotteryCD = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GuildCollecLotteryCD"));
            List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("GuildCollectNpcShowNum");
            int index = XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt((XQualitySetting.ESetting)XQualitySetting.GetQuality());
            if (index > intList.Count - 1)
                index = intList.Count - 1;
            this._npcMaxShowNum = intList[index];
            this._npcRefreshMode = XSingleton<XGlobalConfig>.singleton.GetValue("GuildCollectNpcRefreshMode") == "0" ? CollectNpcRefreshMode.Random : CollectNpcRefreshMode.Distance;
            this.NpcIndex.Clear();
            this.NpcList.Clear();
            this.NpcPool.Clear();
            this.LotteryMachineList.Clear();
            if (this._activityState)
            {
                this.RefreshTime();
                this.InitNpcList();
                if (this._lotteryMachineState)
                    this.SetLotteryMachineState(true, true);
            }
            this.SetMainInterfaceBtnState(false);
        }

        public int CheckLotteryCD(uint uid)
        {
            LotteryCD lotteryCd;
            if (this.LotteryCDInfo.TryGetValue(uid, out lotteryCd))
            {
                if (lotteryCd.Times < this.LotteryTimes)
                {
                    ++lotteryCd.Times;
                    return -1;
                }
                int num = (int)((double)Time.time - (double)lotteryCd.LastLotteryTime - (double)this.GuildCollecLotteryCD);
                if (num < 0)
                    return -num;
                lotteryCd.Times = 1;
                lotteryCd.LastLotteryTime = Time.time;
                return -1;
            }
            this.LotteryCDInfo[uid] = new LotteryCD()
            {
                Times = 1,
                LastLotteryTime = Time.time
            };
            return -1;
        }

        public void SetActivityState(bool state)
        {
            if (this._activityState == state)
                return;
            this._activityState = state;
            XSingleton<XDebug>.singleton.AddGreenLog("set guildcollect state = ", state.ToString());
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GUILD_HALL)
            {
                if (this._activityState)
                {
                    this.RefreshTime();
                    this.InitNpcList();
                }
                else
                {
                    foreach (KeyValuePair<uint, uint> keyValuePair in this.NpcIndex)
                        XSingleton<XEntityMgr>.singleton.DestroyNpc(keyValuePair.Value);
                    for (int index = 0; index < this.NpcPool.Count; ++index)
                        XSingleton<XEntityMgr>.singleton.DestroyNpc(this.NpcPool[index]);
                    this.NpcIndex.Clear();
                    this.NpcList.Clear();
                    this.NpcPool.Clear();
                }
            }
            if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible())
                DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnGuildSysChange();
        }

        public void InitNpcList()
        {
            int npcMaxShowNum = this._npcMaxShowNum;
            this.NORMALNAME = XStringDefineProxy.GetString("GuildCollectSummonNormal");
            this.SPECIALNAME = XStringDefineProxy.GetString("GuildCollectSummonSpecial");
            uint num = 101;
            while (true)
            {
                XNpcInfo.RowData byNpcid = XSingleton<XEntityMgr>.singleton.NpcInfo.GetByNPCID(num);
                if (byNpcid != null && byNpcid.NPCType == 4U)
                {
                    XSingleton<XEntityMgr>.singleton.CreateNpc(num, true).EngineObject.Position = XGameUI.Far_Far_Away;
                    this.NpcPool.Add(num);
                    --npcMaxShowNum;
                    if (npcMaxShowNum > 0)
                        ++num;
                    else
                        goto label_1;
                }
                else
                    break;
            }
            return;
        label_1:;
        }

        public void SyncNpcList(List<GuildCampSpriteInfo> list)
        {
            HashSet<uint> uintSet = new HashSet<uint>();
            for (int index = 0; index < list.Count; ++index)
                uintSet.Add(list[index].sprite_id);
            for (int index = this.NpcList.Count - 1; index >= 0; --index)
            {
                if (uintSet.Contains(this.NpcList[index].id))
                {
                    uintSet.Remove(this.NpcList[index].id);
                }
                else
                {
                    this.SetNpcInValid(index);
                    this.NpcList.RemoveAt(index);
                }
            }
            bool flag = false;
            for (int index = 0; index < list.Count; ++index)
            {
                if (uintSet.Contains(list[index].sprite_id))
                {
                    flag = true;
                    Vector3 _pos = new Vector3((float)(list[index].position >> 16) / 100f, 0.0f, (float)(list[index].position & (int)ushort.MaxValue) / 100f);
                    string _name = string.IsNullOrEmpty(list[index].summoner) ? this.NORMALNAME : string.Format("{0}{1}", (object)list[index].summoner, (object)this.SPECIALNAME);
                    this.NpcList.Add(new CollectNpcInfo(list[index].sprite_id, _pos, _name));
                }
            }
            if (flag)
                this.SortNpcByMode(this._npcRefreshMode);
            this.DealWithNpcList();
        }

        public void OnMeetNpc(uint uid)
        {
            if (this.NpcIndex.ContainsValue(uid))
            {
                foreach (KeyValuePair<uint, uint> keyValuePair in this.NpcIndex)
                {
                    if ((int)keyValuePair.Value == (int)uid)
                    {
                        if ((int)this._lastSendNpcID == (int)keyValuePair.Key && (double)Time.time < (double)this._lastSendNpcTime)
                            return;
                        XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_GetGuildCamPartyRandItem()
                        {
                            oArg = {
                query_type = 2U,
                npc_id = keyValuePair.Key
              }
                        });
                        this._lastSendNpcTime = Time.time + 0.5f;
                        return;
                    }
                }
            }
            XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_GUILDACMPPATY_SPRITE_ONTEXIST);
        }

        public void OnMeetLottery(uint uid)
        {
            if (DlgBase<GuildInheritProcessDlg, GuildInheritProcessBehaviour>.singleton.IsVisible())
                return;
            int num1 = this.CheckLotteryCD(uid);
            if (num1 != -1)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("GuildCollectLotteryCDTips"), (object)num1), "fece00");
            }
            else
            {
                this._lastMeetLotteryUid = uid;
                DlgBase<GuildInheritProcessDlg, GuildInheritProcessBehaviour>.singleton.ShowProcess(this._lotteryWaitTime, this._lotteryProcessText, this._lotteryProcessTips, new GuildInheritProcessDlg.OnSliderProcessEnd(this.QueryLottery));
                this.SetMoveState(false);
                XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(uid);
                if (npc == null)
                    return;
                npc.ShowUp();
                if (npc != null)
                    XSingleton<XAudioMgr>.singleton.PlaySound((XObject)npc, AudioChannel.Motion, "Audio/UI/UI_rabbit");
                int num2 = (int)XSingleton<XTimerMgr>.singleton.SetTimer(float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GuildCollecBoxFxTime")), new XTimerMgr.ElapsedEventHandler(this.DelayCreateLotteryBoxFx), (object)uid);
                string[] strArray1 = XSingleton<XGlobalConfig>.singleton.GetValue("GuildCollecLotteryFxNum").Split('=');
                if (strArray1.Length < 2)
                    return;
                int num3 = XSingleton<XCommon>.singleton.RandomInt(int.Parse(strArray1[0]), int.Parse(strArray1[1]) + 1);
                string[] strArray2 = XSingleton<XGlobalConfig>.singleton.GetValue("GuildCollecLotteryFxProduce").Split('=');
                float min = float.Parse(strArray2[0]);
                float max = float.Parse(strArray2[1]);
                for (int index = 0; index < num3; ++index)
                {
                    int num4 = (int)XSingleton<XTimerMgr>.singleton.SetTimer(XSingleton<XCommon>.singleton.RandomFloat(min, max), new XTimerMgr.ElapsedEventHandler(this.DelayCreateLotteryFlyFx), (object)uid);
                }
            }
        }

        public void DelayCreateLotteryBoxFx(object o)
        {
            XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc((uint)o);
            if (npc == null)
                return;
            if (this._lotteryBoxFx != null)
                XSingleton<XFxMgr>.singleton.DestroyFx(this._lotteryBoxFx);
            this._lotteryBoxFx = XSingleton<XFxMgr>.singleton.CreateFx(XGuildCollectDocument.LotteryBoxFXPATH);
            this._lotteryBoxFx.Play(npc.EngineObject.Position, Quaternion.identity, Vector3.one);
        }

        public void DelayCreateLotteryFlyFx(object o)
        {
            XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc((uint)o);
            if (npc == null || XSingleton<XEntityMgr>.singleton.Player == null)
                return;
            this.CreatLotteryFx(npc.EngineObject.Position, XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position + new Vector3(0.0f, 0.3f));
        }

        public void QueryLottery()
        {
            this.SetMoveState(true);
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_GetGuildCamPartyRandItem()
            {
                oArg = {
          query_type = 1U,
          npc_id = this._lastMeetLotteryUid
        }
            });
        }

        public void SetMoveState(bool state)
        {
            if (XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.Nav != null)
            {
                XSingleton<XEntityMgr>.singleton.Player.Nav.Interrupt();
                XSingleton<XEntityMgr>.singleton.Player.Nav.Enabled = state;
            }
            XSingleton<XInput>.singleton.Freezed = !state;
        }

        public void DealWithNpcList()
        {
            if (this._npcRefreshMode == CollectNpcRefreshMode.Distance)
                this.NpcList.Sort(new Comparison<CollectNpcInfo>(this.Compare));
            int npcMaxShowNum = this._npcMaxShowNum;
            for (int index = 0; index < this.NpcList.Count; ++index)
            {
                if (this.NpcIndex.ContainsKey(this.NpcList[index].id))
                    --npcMaxShowNum;
            }
            if (npcMaxShowNum <= 0)
                return;
            for (int index = 0; index < this.NpcList.Count; ++index)
            {
                if (!this.NpcList[index].use && !this.NpcIndex.ContainsKey(this.NpcList[index].id))
                {
                    this.CreateNpc(this.NpcList[index].pos, this.NpcList[index].id, this.NpcList[index].name);
                    --npcMaxShowNum;
                    if (npcMaxShowNum <= 0)
                        break;
                }
            }
        }

        private int Compare(CollectNpcInfo x, CollectNpcInfo y) => (int)x.id == (int)y.id ? 0 : ((double)Vector3.Distance(x.pos, XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position) > (double)Vector3.Distance(y.pos, XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position) ? 1 : -1);

        public void SortNpcByMode(CollectNpcRefreshMode mode)
        {
            if (mode == CollectNpcRefreshMode.Distance)
                this.NpcList.Sort(new Comparison<CollectNpcInfo>(this.Compare));
            else
                XSingleton<UiUtility>.singleton.Shuffle<CollectNpcInfo>(ref this.NpcList);
        }

        public void SetNpcInValid(int index)
        {
            uint uid = 0;
            if (!this.NpcIndex.TryGetValue(this.NpcList[index].id, out uid))
                return;
            this.ReturnPool(uid);
            this.NpcIndex.Remove(this.NpcList[index].id);
            if (XSingleton<XInput>.singleton.LastNpc != null && (int)XSingleton<XInput>.singleton.LastNpc.TypeID == (int)uid)
            {
                if (XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.Nav != null)
                    XSingleton<XEntityMgr>.singleton.Player.Nav.Interrupt();
                XSingleton<XInput>.singleton.LastNpc = (XEntity)null;
            }
        }

        public void ReturnPool(uint uid)
        {
            XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(uid);
            if (npc == null)
                return;
            npc.EngineObject.Position = XGameUI.Far_Far_Away;
            this.NpcPool.Add(uid);
        }

        public void CreateNpc(Vector3 pos, uint npcID, string name)
        {
            if (this.NpcPool.Count == 0)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Get guildcollect Npc by pool error! It's a empty pool.");
            }
            else
            {
                int index = this.NpcPool.Count - 1;
                uint id = this.NpcPool[index];
                this.NpcPool.RemoveAt(index);
                XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(id);
                if (npc == null)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("create npc by pool error. id = ", id.ToString());
                }
                else
                {
                    if (npc.BillBoard != null)
                        npc.BillBoard.OnGuildCollectNpcNameChange(name);
                    npc.EngineObject.Position = pos;
                    npc.EngineObject.LocalEulerAngles = new Vector3(0.0f, XSingleton<XCommon>.singleton.RandomFloat(-180f, 180f), 0.0f);
                    this.NpcIndex[npcID] = id;
                }
            }
        }

        public void SetLotteryMachineState(bool state, bool force = false)
        {
            if (XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_GUILD_HALL || !force && state == this._lotteryMachineState)
                return;
            this._lotteryMachineState = state;
            if (this._lotteryMachineState)
            {
                uint num = 100;
                while (true)
                {
                    XNpcInfo.RowData byNpcid = XSingleton<XEntityMgr>.singleton.NpcInfo.GetByNPCID(num);
                    if (byNpcid != null && byNpcid.NPCType == 5U)
                    {
                        XNpc npc = XSingleton<XEntityMgr>.singleton.CreateNpc(num, true);
                        this.LotteryMachineList.Add(num);
                        XFx fx = XSingleton<XFxMgr>.singleton.CreateFx(XGuildCollectDocument.m_fxPath);
                        if (fx != null && npc != null)
                        {
                            this._fxList.Add(fx);
                            fx.Play(npc.EngineObject, new Vector3(-0.05f, npc.Height + 0.6f, 0.0f), Vector3.one);
                        }
                        --num;
                    }
                    else
                        break;
                }
            }
            else
            {
                for (int index = 0; index < this.LotteryMachineList.Count; ++index)
                    XSingleton<XEntityMgr>.singleton.DestroyNpc(this.LotteryMachineList[index]);
                for (int index = 0; index < this._fxList.Count; ++index)
                {
                    if (this._fxList[index] != null)
                        XSingleton<XFxMgr>.singleton.DestroyFx(this._fxList[index]);
                }
                this._fxList.Clear();
                this.LotteryMachineList.Clear();
            }
        }

        public override void OnLeaveScene()
        {
            base.OnLeaveScene();
            this.NpcIndex.Clear();
            this.NpcList.Clear();
            this.NpcPool.Clear();
            this.LotteryMachineList.Clear();
            for (int index = 0; index < this._fxList.Count; ++index)
            {
                if (this._fxList[index] != null)
                    XSingleton<XFxMgr>.singleton.DestroyFx(this._fxList[index]);
            }
            this._fxList.Clear();
            if ((uint)this._lotteryFxLink.Count > 0U)
            {
                LinkedListNode<ParabolaFx> next;
                for (LinkedListNode<ParabolaFx> node = this._lotteryFxLink.First; node != null; node = next)
                {
                    next = node.Next;
                    node.Value.Destroy();
                    this._lotteryFxLink.Remove(node);
                }
                XSingleton<XDebug>.singleton.AddGreenLog("Clear guildcollect fx link, cout = ", this._lotteryFxLink.Count.ToString());
            }
            if (this._lotteryBoxFx == null)
                return;
            XSingleton<XFxMgr>.singleton.DestroyFx(this._lotteryBoxFx);
            this._lotteryBoxFx = (XFx)null;
        }

        public void SetMainInterfaceBtnState(bool state)
        {
            this.MainInterfaceBtnState = state;
            DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildCollectMainInterface);
        }

        public void QuerySummon()
        {
            SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("GuildCampSummonSpiritCost", false);
            XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<UiUtility>.singleton.ReplaceReturn(string.Format(XStringDefineProxy.GetString("GuildCollectSummonTips"), (object)XLabelSymbolHelper.FormatSmallIcon(sequenceList[0, 0]), (object)sequenceList[0, 1])), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnSummonSure));
        }

        public bool OnSummonSure(IXUIButton btn)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_GuildPartySummonSpirit());
            return true;
        }

        public void QueryGetRewardCount() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_GetGuildPartyReceiveInfo());

        public void OnUseCountGet(List<MapIntItem> list)
        {
            this.CollectUseDict.Clear();
            for (int index = 0; index < list.Count; ++index)
                this.CollectUseDict[(uint)list[index].key] = (int)list[index].value;
            if (!DlgBase<GuildCollectRewardDlg, GuildCollectRewardBehaviour>.singleton.IsVisible())
                return;
            DlgBase<GuildCollectRewardDlg, GuildCollectRewardBehaviour>.singleton.Refresh();
        }

        public void QueryGetReward(uint id) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_GetGuildCampPartyReward()
        {
            oArg = {
        reward_id = id
      }
        });

        protected override void OnReconnected(XReconnectedEventArgs arg)
        {
        }

        public void CreatLotteryFx(Vector3 startPos, Vector3 endPos)
        {
            string[] strArray1 = XSingleton<XGlobalConfig>.singleton.GetValue("GuildCollecLotteryFxDuration").Split('=');
            if (strArray1.Length < 2)
                return;
            float duration = XSingleton<XCommon>.singleton.RandomFloat(float.Parse(strArray1[0]), float.Parse(strArray1[1]));
            string[] strArray2 = XSingleton<XGlobalConfig>.singleton.GetValue("GuildCollecLotteryFxSpeed").Split('=');
            if (strArray2.Length < 2)
                return;
            float speedY = XSingleton<XCommon>.singleton.RandomFloat(float.Parse(strArray2[0]), float.Parse(strArray2[1]));
            this._lotteryFxLink.AddLast(new ParabolaFx(XGuildCollectDocument.LotteryFlyFXPATH, duration, speedY, startPos, endPos));
        }

        public override void Update(float fDeltaT)
        {
            base.Update(fDeltaT);
            if (!this._activityState || this._lotteryFxLink.Count == 0)
                return;
            LinkedListNode<ParabolaFx> next;
            for (LinkedListNode<ParabolaFx> node = this._lotteryFxLink.First; node != null; node = next)
            {
                next = node.Next;
                if (!node.Value.Update())
                    this._lotteryFxLink.Remove(node);
            }
        }

        public void SetTime(uint leftTime)
        {
            this.SignTime = XSingleton<UiUtility>.singleton.GetMachineTime();
            this.LeftTime = leftTime;
            this.SUMMONLEFTTIME = XSingleton<XGlobalConfig>.singleton.GetInt("GuildCampSummonSpiritTime");
        }

        public void RefreshTime(object o = null)
        {
            int time = (int)this.LeftTime - (int)(XSingleton<UiUtility>.singleton.GetMachineTime() - this.SignTime);
            int summonTime = time - this.SUMMONLEFTTIME;
            if (time < 0)
                time = 0;
            if (summonTime < 0)
                summonTime = 0;
            if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible())
                DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshGuildCollectTime(time, summonTime);
            if (DlgBase<GuildCollectRewardDlg, GuildCollectRewardBehaviour>.singleton.IsVisible())
                DlgBase<GuildCollectRewardDlg, GuildCollectRewardBehaviour>.singleton.RefreshTime(time);
            this._hallTimeToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.RefreshTime), (object)null);
        }
    }
}
