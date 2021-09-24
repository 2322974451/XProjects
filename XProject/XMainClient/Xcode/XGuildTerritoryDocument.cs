using KKSG;
using System;
using System.Collections.Generic;
using System.Text;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XGuildTerritoryDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash(nameof(XGuildTerritoryDocument));
        public static readonly uint GAME_INFO = 1;
        public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();
        private static FightDesignation mGuildDestination = new FightDesignation();
        public static GuildTransfer mGuildTransfer = new GuildTransfer();
        public static TerritoryBattle mGuildTerritoryList = new TerritoryBattle();
        public static TerritoryRewd mTerritoryRewd = new TerritoryRewd();
        public XFx[] fxJvDians = new XFx[9];
        public Vector3[] fxJvPos = new Vector3[3];
        private float lastShowInfoTime;
        public Queue<XBattleCaptainPVPDocument.KillInfo> qInfo = new Queue<XBattleCaptainPVPDocument.KillInfo>();
        public uint mapid = 0;
        public List<GCFJvDianInfo> jvdians = new List<GCFJvDianInfo>();
        public List<GCFGuild> guilds = new List<GCFGuild>();
        public List<GCFRoleBrief> roles = new List<GCFRoleBrief>();
        public List<GCFBattleField> fields = new List<GCFBattleField>();
        public List<ItemBrief> rwds = new List<ItemBrief>();
        public GCFRoleBrief mmyinfo = new GCFRoleBrief();
        public uint feats = 0;
        public GCFGuildBrief winguild;
        public uint ready_lefttime = 0;
        public uint fight_lefttime = 0;
        public uint territoryid = 0;
        public bool myPostion = true;
        private uint[] maptoken = new uint[3];
        private string[] fxs = new string[3]
        {
      "Effects/FX_Particle/UIfx/UI_xdtts_white",
      "Effects/FX_Particle/UIfx/UI_xdtts_bule",
      "Effects/FX_Particle/UIfx/UI_xdtts_red"
        };
        private Dictionary<uint, CityData> mCityDataDic = new Dictionary<uint, CityData>();
        private List<CityData> mCityDataList = new List<CityData>();
        private List<GuildTerrChallInfo> mGuildTerrChall = new List<GuildTerrChallInfo>();
        private List<GuildTerritoryAllianceInfo> mGuildTerritoryAllianceList = new List<GuildTerritoryAllianceInfo>();
        private uint mHaveTerritoryCount = 0;
        private XGuildTerritoryDocument.GuildTerritoryStyle mCurTerritoryStyle = XGuildTerritoryDocument.GuildTerritoryStyle.NONE;
        public ulong Allianceid = 0;
        public GUILDTERRTYPE CurrentType = GUILDTERRTYPE.TERR_NOT_OPEN;
        public uint SelfGuildTerritoryID = 0;
        public uint SelfTargetTerritoryID = 0;
        public List<GuildTerrAllianceInfo> guildAllianceInfos;
        public bool mShowMessage = true;
        public bool mShowMessageIcon = false;
        public ulong SelfAllianceID = 0;
        public uint CurrentTerritoryID = 0;
        public uint EnterBattleTime = 0;

        public override uint ID => XGuildTerritoryDocument.uuID;

        protected override void OnReconnected(XReconnectedEventArgs arg)
        {
            if (!DlgBase<GuildTerritoryReportDlg, GuildTerritoryBahaviour>.singleton.IsVisible())
                return;
            this.SendGCFCommonReq(GCFReqType.GCF_FIGHT_REPORT);
        }

        public static void Execute(OnLoadedCallback callback = null)
        {
            XGuildTerritoryDocument.AsyncLoader.AddTask("Table/TerritoryBattleDesignation", (CVSReader)XGuildTerritoryDocument.mGuildDestination);
            XGuildTerritoryDocument.AsyncLoader.AddTask("Table/TerritoryBattleTransfer", (CVSReader)XGuildTerritoryDocument.mGuildTransfer);
            XGuildTerritoryDocument.AsyncLoader.AddTask("Table/territorybattle", (CVSReader)XGuildTerritoryDocument.mGuildTerritoryList);
            XGuildTerritoryDocument.AsyncLoader.AddTask("Table/TerritoryRewd", (CVSReader)XGuildTerritoryDocument.mTerritoryRewd);
            XGuildTerritoryDocument.AsyncLoader.Execute(callback);
        }

        public static void OnLoadcallback()
        {
        }

        public override void OnEnterScene()
        {
            base.OnEnterScene();
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL)
			{
                GuildMiniReportHandler.msgs.Clear();
            }
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_WAIT)
			{
                XSingleton<GuildPassMgr>.singleton.InitBoard();
            }
            if (XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_CASTLE_FIGHT)
			{
                return;
            }
            for (int index = 0; index < this.fxJvDians.Length; ++index)
            {
                this.fxJvDians[index] = index % 3 != 0 ? (index % 3 != 1 ? XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/Roles/Lzg_Ty/Ty_ldzd_fanwei_blue") : XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/Roles/Lzg_Ty/Ty_ldzd_fanwei_red")) : XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/Roles/Lzg_Ty/Ty_ldzd_fanwei_grey");
                if (index / 3 == 0)
                {
                    List<float> floatList = XSingleton<XGlobalConfig>.singleton.GetFloatList("GuildTerritoryUpPos");
                    Vector3 position = new Vector3(floatList[0], floatList[1], floatList[2]);
                    float num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("TerritoryBattleUpRadius")) * float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("TerritoryBattleClientRadiusK"));
                    this.fxJvDians[index].Play(position, Quaternion.identity, new Vector3(num, 1f, num));
                    this.fxJvPos[0] = position;
                }
                else if (index / 3 == 1)
                {
                    List<float> floatList = XSingleton<XGlobalConfig>.singleton.GetFloatList("GuildTerritoryMidPos");
                    Vector3 position = new Vector3(floatList[0], floatList[1], floatList[2]);
                    float num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("TerritoryBattleMidRadius")) * float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("TerritoryBattleClientRadiusK"));
                    this.fxJvDians[index].Play(position, Quaternion.identity, new Vector3(num, 1f, num));
                    this.fxJvPos[1] = position;
                }
                else
                {
                    List<float> floatList = XSingleton<XGlobalConfig>.singleton.GetFloatList("GuildTerritoryBtmPos");
                    Vector3 position = new Vector3(floatList[0], floatList[1], floatList[2]);
                    float num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("TerritoryBattleBtmRadius")) * float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("TerritoryBattleClientRadiusK"));
                    this.fxJvDians[index].Play(position, Quaternion.identity, new Vector3(num, 1f, num));
                    this.fxJvPos[2] = position;
                }
            }
        }

        public override void OnEnterSceneFinally()
        {
            base.OnEnterSceneFinally();
            this.CheckJvDianState();
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_WAIT && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible())
                DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetVisible(false);
            if (Process_RpcC2G_DoEnterScene.runstate <= 0U || XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_CASTLE_WAIT && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_CASTLE_FIGHT)
                return;
            XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
            if (specificDocument != null)
            {
                if (DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded())
                {
                    DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.ResetPressState();
                    DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisiblePure(false);
                    DlgBase<RadioBattleDlg, RadioBattleBahaviour>.singleton.Show(false);
                    DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetFakeHide(true);
                }
                specificDocument.ShowLevelReward();
            }
        }

        public override void OnLeaveScene()
        {
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_WAIT)
            {
                XSingleton<GuildPassMgr>.singleton.ClearAll();
                if (DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible())
                    DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetVisible(true);
            }
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_FIGHT)
            {
                for (int index = 0; index < this.fxJvDians.Length; ++index)
                {
                    if (this.fxJvDians[index] != null)
                        XSingleton<XFxMgr>.singleton.DestroyFx(this.fxJvDians[index]);
                    this.fxJvDians[index] = (XFx)null;
                }
                XBattleDocument.DelMiniMapFx(this.maptoken[0]);
                XBattleDocument.DelMiniMapFx(this.maptoken[1]);
                XBattleDocument.DelMiniMapFx(this.maptoken[2]);
            }
            base.OnLeaveScene();
        }

        public override void OnDetachFromHost()
        {
            this.jvdians.Clear();
            this.roles.Clear();
            this.guilds.Clear();
            this.rwds.Clear();
            base.OnDetachFromHost();
        }

        public override void PostUpdate(float fDeltaT)
        {
            base.PostUpdate(fDeltaT);
            if (Time.frameCount % 60 == 0)
            {
                if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_WAIT)
                {
                    this.SendGCFReadysInfo();
                    this.SendGFCFightInfo();
                }
                else if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_FIGHT)
                    this.SendGFCFightInfo();
            }
            if ((double)Time.time <= (double)this.lastShowInfoTime + 10.0)
                return;
            if ((uint)this.qInfo.Count > 0U)
                this.qInfo.Clear();
            if (DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_miniReportHandler != null)
                DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_miniReportHandler.ShowBuffs();
        }

        public FightDesignation.RowData GetDesignation(uint hit)
        {
            FightDesignation.RowData[] table = XGuildTerritoryDocument.mGuildDestination.Table;
            for (int index = table.Length - 1; index >= 0; --index)
            {
                if (table[index].ID <= hit)
                    return table[index];
            }
            return (FightDesignation.RowData)null;
        }

        public void ActiveJvDian(GCFJvDianType type, int index)
        {
            switch (type)
            {
                case GCFJvDianType.GCF_JUDIAN_UP:
                    if (this.fxJvDians[0] == null || this.fxJvDians[1] == null || this.fxJvDians[2] == null)
                        break;
                    this.fxJvDians[0].SetActive(index == 0);
                    this.fxJvDians[1].SetActive(index == 1);
                    this.fxJvDians[2].SetActive(index == 2);
                    break;
                case GCFJvDianType.GCF_JUDIAN_MID:
                    if (this.fxJvDians[3] == null || this.fxJvDians[4] == null || this.fxJvDians[5] == null)
                        break;
                    this.fxJvDians[3].SetActive(index == 0);
                    this.fxJvDians[4].SetActive(index == 1);
                    this.fxJvDians[5].SetActive(index == 2);
                    break;
                default:
                    if (this.fxJvDians[6] != null && this.fxJvDians[7] != null && this.fxJvDians[8] != null)
                    {
                        this.fxJvDians[6].SetActive(index == 0);
                        this.fxJvDians[7].SetActive(index == 1);
                        this.fxJvDians[8].SetActive(index == 2);
                    }
                    break;
            }
        }

        public void SendGCFEnterin(int index)
        {
            this.mapid = XGuildTerritoryDocument.mGuildTransfer.GetByid((uint)index).sceneid;
            this.SendGCFCommonReq(GCFReqType.GCF_JOIN_FIGHT_SCENE);
        }

        public void SendWaitScene(uint tid)
        {
            this.territoryid = tid;
            this.SendGCFCommonReq(GCFReqType.GCF_JOIN_READY_SCENE);
        }

        public void SendGCFCommonReq(GCFReqType type) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GCFCommonReq()
        {
            oArg = {
        mapid = this.mapid,
        reqtype = type,
        territoryid = this.territoryid
      }
        });

        public void RespGCFCommon(GCFReqType type, GCFCommonRes res)
        {
            this.jvdians = res.jvdians;
            this.guilds.Clear();
            for (int index = 0; index < res.guilds.Count; ++index)
            {
                GCFGuild gcfGuild = new GCFGuild()
                {
                    brief = res.guilds[index]
                };
                gcfGuild.groupScore = this.GetGroupPoint(res.guilds, gcfGuild.brief.group);
                this.guilds.Add(gcfGuild);
            }
            this.roles = res.roles;
            this.rwds = res.rewards;
            this.fields = res.fields;
            this.mmyinfo = res.myinfo;
            if (this.mmyinfo != null)
                this.feats = this.mmyinfo.feats;
            this.territoryid = res.territoryid;
            this.winguild = res.winguild;
            switch (type)
            {
                case GCFReqType.GCF_FIGHT_REPORT:
                    if (!DlgBase<GuildTerritoryReportDlg, GuildTerritoryBahaviour>.singleton.IsVisible())
                        break;
                    DlgBase<GuildTerritoryReportDlg, GuildTerritoryBahaviour>.singleton.RefreshAll();
                    break;
                case GCFReqType.GCF_FIGHT_RESULT:
                    LevelRewardTerritoryHandler territoryHandler = DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.GetTerritoryHandler();
                    if (territoryHandler != null)
                    {
                        territoryHandler.RefreshAll();
                        break;
                    }
                    XSingleton<XDebug>.singleton.AddErrorLog("level reward is nil");
                    break;
            }
        }

        public void SendGCFReadysInfo() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GCFReadysInfoReq());

        public void RespGCFReadysInfo(GCFReadyInfoRes ores)
        {
            this.ready_lefttime = ores.lefttime;
            if (DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible() && !XSingleton<GuildPassMgr>.singleton.isOpen && this.ready_lefttime > 0U)
                DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(this.ready_lefttime);
            XSingleton<GuildPassMgr>.singleton.UpdateInfo(ores.allinfo);
        }

        public void SendGFCFightInfo() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GCFFightInfoReqC2M());

        public void RespGCFFightInfo(GCFFightInfoRes res)
        {
            this.fight_lefttime = res.lefttime;
            if (DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible() && XSingleton<GuildPassMgr>.singleton.isOpen && this.fight_lefttime > 0U)
                DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(this.fight_lefttime);
            XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
            this.guilds.Clear();
            for (int index = 0; index < res.guilds.Count; ++index)
            {
                GCFGuild gcfGuild = new GCFGuild()
                {
                    brief = res.guilds[index]
                };
                gcfGuild.groupScore = this.GetGroupPoint(res.guilds, gcfGuild.brief.group);
                gcfGuild.isPartern = res.guilds[index].group == res.mygroup;
                if ((long)gcfGuild.brief.guildid == (long)specificDocument.UID)
                    this.myPostion = gcfGuild.isPartern;
                this.guilds.Add(gcfGuild);
            }
            this.jvdians = res.JvDians;
            this.guilds.Sort(new Comparison<GCFGuild>(this.SortGuildsInfo));
            DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_miniRankHandler?.RefreshAll();
            this.CheckJvDianState();
            DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_miniReportHandler?.RefreshMyInfo(res.myinfo);
        }

        private uint GetGroupPoint(List<GCFGuildBrief> guilds, int group)
        {
            uint num = 0;
            for (int index = 0; index < guilds.Count; ++index)
            {
                if (guilds[index].group == group)
                    num += guilds[index].point;
            }
            return num;
        }

        private int SortGuildsInfo(GCFGuild x, GCFGuild y) => (int)x.groupScore != (int)y.groupScore ? (int)y.groupScore - (int)x.groupScore : (int)y.brief.point - (int)x.brief.point;

        public void OnFeatsChange(uint feat) => this.feats = feat;

        public void OnZhanLingNotify(GCFZhanLingPara data)
        {
            GCFZhanLingType zltype = data.zltype;
            XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(data.roleID);
            if (entity == null || entity.Attributes == null)
                return;
            XTerritoryComponent xcomponent = entity.GetXComponent(XTerritoryComponent.uuID) as XTerritoryComponent;
            switch (zltype)
            {
                case GCFZhanLingType.GCFZL_BEGIN:
                    xcomponent.ToStart();
                    break;
                case GCFZhanLingType.GCFZL_BREAK:
                    xcomponent.Interupt();
                    break;
                case GCFZhanLingType.GCFZL_END:
                    xcomponent.Success();
                    break;
            }
        }

        public void ModifyMinimapState(GCFJvDianType type1, int index2)
        {
            Vector3 fxJvPo = this.fxJvPos[XFastEnumIntEqualityComparer<GCFJvDianType>.ToInt(type1) - 1];
            string fx = this.fxs[index2];
            if (type1 == GCFJvDianType.GCF_JUDIAN_UP)
            {
                XBattleDocument.DelMiniMapFx(this.maptoken[0]);
                this.maptoken[0] = XBattleDocument.AddMiniMapFx(fxJvPo, fx);
            }
            else if (type1 == GCFJvDianType.GCF_JUDIAN_MID)
            {
                XBattleDocument.DelMiniMapFx(this.maptoken[1]);
                this.maptoken[1] = XBattleDocument.AddMiniMapFx(fxJvPo, fx);
            }
            else
            {
                XBattleDocument.DelMiniMapFx(this.maptoken[2]);
                this.maptoken[2] = XBattleDocument.AddMiniMapFx(fxJvPo, fx);
            }
        }

        public void OnGCFSynG2CNtf(GCFG2CSynPara data)
        {
            DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_miniReportHandler?.Push(data.type, data);
            if (data.type != GCFG2CSynType.GCF_G2C_SYN_KILL_COUNT)
                return;
            XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(data.roleid);
            if (entity != null && entity.BillBoard != null)
                entity.BillBoard.OnFightDesignationInfoChange(data.killcount);
        }

        public void ReceiveBattleSkill(PvpBattleKill battleSkillInfo)
        {
            if (XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_CASTLE_FIGHT)
                return;
            GVGBattleSkill battleSkill = new GVGBattleSkill();
            battleSkill.killerID = battleSkillInfo.killID;
            battleSkill.deadID = battleSkillInfo.deadID;
            battleSkill.contiKillCount = battleSkillInfo.contiKillCount;
            XEntity entityConsiderDeath1 = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(battleSkill.killerID);
            XEntity entityConsiderDeath2 = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(battleSkill.deadID);
            if (entityConsiderDeath1 == null || entityConsiderDeath2 == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("entity id: " + (object)battleSkill.killerID, " dead id: " + (object)battleSkill.deadID);
            }
            else
            {
                battleSkill.killerName = entityConsiderDeath1.Name;
                battleSkill.deadName = entityConsiderDeath2.Name;
                bool flag = XSingleton<XEntityMgr>.singleton.IsAlly(entityConsiderDeath1);
                battleSkill.killerPosition = this.myPostion ? flag : !flag;
                DlgBase<BattleContiDlg, BattleContiBehaviour>.singleton.AddBattleSkill(battleSkill);
                XSingleton<XDebug>.singleton.AddGreenLog(string.Format("ReceiveBattleSkill:{0} --- ,{1} ,.... {2}", (object)battleSkill.killerName, (object)battleSkill.deadName, (object)battleSkill.contiKillCount));
            }
        }

        private void CheckJvDianState()
        {
            if (XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_CASTLE_FIGHT)
                return;
            for (int index = 0; index < this.jvdians.Count; ++index)
            {
                if (string.IsNullOrEmpty(this.jvdians[index].guildname))
                {
                    this.ActiveJvDian(this.jvdians[index].type, 0);
                    this.ModifyMinimapState(this.jvdians[index].type, 0);
                }
                else
                {
                    this.ActiveJvDian(this.jvdians[index].type, this.IsPartener(this.jvdians[index].guildname) ? 2 : 1);
                    this.ModifyMinimapState(this.jvdians[index].type, this.IsPartener(this.jvdians[index].guildname) ? 1 : 2);
                }
            }
        }

        private bool IsPartener(string guildname)
        {
            for (int index = 0; index < this.guilds.Count; ++index)
            {
                if (this.guilds[index].brief.guildname == guildname)
                    return this.guilds[index].isPartern;
            }
            return false;
        }

        public void OnAddBuff(ulong roleID, uint doodadID)
        {
            BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)doodadID, 1);
            string str = string.Empty;
            if (buffData == null)
                XSingleton<XDebug>.singleton.AddErrorLog(string.Format("GuildTerritory: Buff data not found: [{0} {1}]", (object)doodadID, (object)1));
            else
                str = buffData.BuffName;
            XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roleID);
            if (entity == null)
            {
                XSingleton<XDebug>.singleton.AddWarningLog("entity is null");
            }
            else
            {
                string name = entity.Name;
                StringBuilder stringBuilder = new StringBuilder();
                bool flag = false;
                for (int index = 0; index < str.Length; ++index)
                {
                    if (str[index] == '[')
                        flag = true;
                    if (str[index] == ')')
                        flag = false;
                    if (flag)
                        stringBuilder.Append(str[index]);
                    if (str[index] == '(')
                        flag = true;
                    if (str[index] == ']')
                        flag = false;
                }
                this.AddBuffInfo(name, stringBuilder.ToString());
            }
        }

        private void AddBuffInfo(string left, string right)
        {
            this.lastShowInfoTime = Time.time;
            this.qInfo.Enqueue(new XBattleCaptainPVPDocument.KillInfo()
            {
                KillName = left,
                DeadName = right
            });
            if ((long)this.qInfo.Count > (long)XGuildTerritoryDocument.GAME_INFO)
                this.qInfo.Dequeue();
            if (!DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible() || DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_miniReportHandler == null)
                return;
            DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_miniReportHandler.ShowBuffs();
        }

        public uint bHavaTerritoryRecCount
        {
            set
            {
                this.mHaveTerritoryCount = value;
                DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildTerritoryAllianceInterface);
            }
            get => this.mHaveTerritoryCount;
        }

        public XGuildTerritoryDocument.GuildTerritoryStyle TerritoryStyle
        {
            set
            {
                this.mCurTerritoryStyle = value;
                DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildTerritoryIconInterface);
                this.RefreshGuildTerritoryInfo();
            }
            get => this.mCurTerritoryStyle;
        }

        public bool bHavaShowMessageIcon
        {
            set
            {
                this.mShowMessageIcon = value;
                DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildTerritoryMessageInterface);
            }
            get => this.mShowMessageIcon;
        }

        public void OnClickTerritoryIcon()
        {
            switch (this.TerritoryStyle)
            {
                case XGuildTerritoryDocument.GuildTerritoryStyle.INFORM:
                    this.TerritoryStyle = XGuildTerritoryDocument.GuildTerritoryStyle.NONE;
                    XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("NOTICE_TERRITORY_STRING"), XStringDefineProxy.GetString("NOTICE_TERRITORY_STRING_GO"), XStringDefineProxy.GetString("NOTICE_TERRITORY_STRING_ENSURE"), new ButtonClickEventHandler(this.OnInformClick));
                    break;
                case XGuildTerritoryDocument.GuildTerritoryStyle.ACTIVITY:
                    DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>.OnAnimationOver)null);
                    break;
            }
        }

        private bool OnInformClick(IXUIButton btn)
        {
            XSingleton<UiUtility>.singleton.CloseModalDlg();
            DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>.OnAnimationOver)null);
            return false;
        }

        public List<GuildTerrChallInfo> GuildTerrChallList => this.mGuildTerrChall;

        public List<CityData> CityDataList => this.mCityDataList;

        public List<GuildTerritoryAllianceInfo> GuildTerrAllianceInfos => this.mGuildTerritoryAllianceList;

        public bool TryTerritoryAlliance(uint terriroryID, out int messageID)
        {
            bool flag = false;
            messageID = 0;
            if ((int)terriroryID == (int)this.SelfGuildTerritoryID)
            {
                messageID = 4;
            }
            else
            {
                uint targetTerrioryType1 = this.GetTargetTerrioryType(terriroryID);
                uint targetTerrioryType2 = this.GetTargetTerrioryType(this.SelfGuildTerritoryID);
                if (targetTerrioryType1 == 0U)
                    messageID = 0;
                int num = (int)targetTerrioryType1 - (int)targetTerrioryType2;
                if (num > 1)
                {
                    if (targetTerrioryType1 == 3U)
                        messageID = 2;
                    else if (targetTerrioryType1 == 2U)
                        messageID = 1;
                }
                else if (num < 1)
                    messageID = targetTerrioryType2 != 3U ? 3 : 5;
                else
                    flag = true;
            }
            return flag;
        }

        public uint GetTargetTerrioryType(uint cityID)
        {
            uint num = 0;
            if (cityID > 0U)
            {
                TerritoryBattle.RowData byId = XGuildTerritoryDocument.mGuildTerritoryList.GetByID(cityID);
                if (byId != null)
                    num = byId.territorylevel;
            }
            return num;
        }

        public bool TryGetCityData(uint cityID, out CityData data) => this.mCityDataDic.TryGetValue(cityID, out data);

        public void SendGuildTerritoryCityInfo() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_ReqGuildTerrCityInfo());

        public void ReceiveGuildTerritoryCityInfo(ReqGuildTerrCityInfo res)
        {
            XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
            this.CurrentType = res.type;
            this.SelfTargetTerritoryID = res.targetid;
            this.SelfGuildTerritoryID = 0U;
            this.SelfAllianceID = res.allianceId;
            this.mCityDataList.Clear();
            XSingleton<XDebug>.singleton.AddGreenLog("ReceiveGuildTerritoryCityInfo:", this.CurrentType.ToString(), res.targetid.ToString(), res.cityinfo.Count.ToString());
            int index = 0;
            for (int count = res.cityinfo.Count; index < count; ++index)
            {
                if (this.mCityDataDic.ContainsKey(res.cityinfo[index].id))
                    this.mCityDataDic[res.cityinfo[index].id] = res.cityinfo[index];
                else
                    this.mCityDataDic.Add(res.cityinfo[index].id, res.cityinfo[index]);
                if (res.cityinfo[index].guildid > 0UL)
                    this.mCityDataList.Add(res.cityinfo[index]);
                if ((long)specificDocument.BasicData.uid == (long)res.cityinfo[index].guildid)
                    this.SelfGuildTerritoryID = res.cityinfo[index].id;
            }
            this.mCityDataList.Sort(new Comparison<CityData>(this.CompareCityData));
            if (!DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>.singleton.IsVisible())
                return;
            DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>.singleton.RefreshData();
        }

        public void SetGuildTerritoryCityInfo(uint cityID, ulong guildID) => this.RefreshGuildTerritoryInfo();

        private int CompareCityData(CityData city1, CityData city2) => (int)city2.id - (int)city1.id;

        public void RefreshGuildTerritoryInfo()
        {
            if (DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>.singleton.IsVisible())
                this.SendGuildTerritoryCityInfo();
            if (!DlgBase<GuildTerritoryDeclareDlg, GuildTerritoryDeclareBehaviour>.singleton.IsVisible())
                return;
            this.SendGuildTerritoryChallInfo(this.CurrentTerritoryID);
        }

        public void SendGuildTerritoryChallInfo(uint uid)
        {
            if (uid == 0U)
                return;
            RpcC2M_ReqGuildTerrChallInfo guildTerrChallInfo = new RpcC2M_ReqGuildTerrChallInfo();
            guildTerrChallInfo.oArg.id = uid;
            this.CurrentTerritoryID = uid;
            XSingleton<XClientNetwork>.singleton.Send((Rpc)guildTerrChallInfo);
        }

        public void ReceiveGuildTerritoryChallInfo(
          ReqGuildTerrChallInfoArg arg,
          ReqGuildTerrChallInfoRes res)
        {
            XSingleton<XDebug>.singleton.AddGreenLog("ReceiveGuildTerritoryChallInfo:", res.challinfo.Count.ToString());
            this.mGuildTerrChall.Clear();
            this.mGuildTerrChall.AddRange((IEnumerable<GuildTerrChallInfo>)res.challinfo);
            this.mGuildTerritoryAllianceList.Clear();
            this.EnterBattleTime = res.cdtime;
            Dictionary<ulong, GuildTerritoryAllianceInfo> dictionary = new Dictionary<ulong, GuildTerritoryAllianceInfo>();
            int index = 0;
            for (int count = res.challinfo.Count; index < count; ++index)
            {
                if (dictionary.ContainsKey(res.challinfo[index].allianceid))
                    dictionary[res.challinfo[index].allianceid].Add(res.challinfo[index]);
                else if (!dictionary.ContainsKey(res.challinfo[index].guildid))
                {
                    GuildTerritoryAllianceInfo territoryAllianceInfo = new GuildTerritoryAllianceInfo();
                    territoryAllianceInfo.Set(res.challinfo[index]);
                    dictionary.Add(res.challinfo[index].guildid, territoryAllianceInfo);
                }
            }
            this.mGuildTerritoryAllianceList.AddRange((IEnumerable<GuildTerritoryAllianceInfo>)dictionary.Values);
            if (this.CurrentTerritoryID <= 0U)
                return;
            if (DlgBase<GuildTerritoryDeclareDlg, GuildTerritoryDeclareBehaviour>.singleton.IsVisible())
                DlgBase<GuildTerritoryDeclareDlg, GuildTerritoryDeclareBehaviour>.singleton.RefreshWhenShow();
            else
                DlgBase<GuildTerritoryDeclareDlg, GuildTerritoryDeclareBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<GuildTerritoryDeclareDlg, GuildTerritoryDeclareBehaviour>.OnAnimationOver)null);
        }

        public void SendReceiveTerritroyInfo() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_ReqGuildTerrIntellInfo());

        public void ReceiveTerritoryInterllInfo(ReqGuildTerrIntellInfoRes oRes)
        {
            if (!DlgBase<GuildTerritoryMessageDlg, GuildTerritoryMessageBehaviour>.singleton.IsVisible())
                return;
            DlgBase<GuildTerritoryMessageDlg, GuildTerritoryMessageBehaviour>.singleton.SetNewInfo(oRes.intellInfo);
        }

        public bool TryGetTerritoryGuildName(ulong guildid, out string guildName)
        {
            guildName = string.Empty;
            int index = 0;
            for (int count = this.mGuildTerrChall.Count; index < count; ++index)
            {
                if ((long)this.mGuildTerrChall[index].guildid == (long)guildid)
                {
                    guildName = this.mGuildTerrChall[index].guildname;
                    return true;
                }
            }
            return false;
        }

        public void SendGuildTerrAllianceInfo() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_ReqGuildTerrAllianceInfo());

        public void ReceiveGuildTerrAllianceInfo(ReqGuildTerrAllianceInfoRes res)
        {
            this.Allianceid = res.allianceid;
            this.guildAllianceInfos = res.allianceinfo;
            DlgBase<GuildTerritoryLeagueDlg, GuildTerritoryLeagueBehaviour>.singleton.RefreshData();
        }

        public void SendAllianceGuildTerr(uint territoryID)
        {
            XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
            if (specificDocument.Position == GuildPosition.GPOS_LEADER || specificDocument.Position == GuildPosition.GPOS_VICELEADER)
                XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_AllianceGuildTerr()
                {
                    oArg = {
            id = territoryID
          }
                });
            else
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_TB_DECLEAR_NO_PERMISSON"), "fece00");
        }

        public void ReceiveAllianceGuildTerr(AllianceGuildTerrArg arg, AllianceGuildTerrRes res)
        {
            if ((uint)res.errorcod > 0U)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorcod);
                if (res.errorcod != ErrorCode.ERR_DECLAREWAR_OUT_TIME)
                    return;
                this.RefreshGuildTerritoryInfo();
            }
            else
                this.RefreshGuildTerritoryInfo();
        }

        public void SendTryAlliance(ulong guildID)
        {
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(SendTryAlliance), guildID.ToString());
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_TryAlliance()
            {
                oArg = {
          guild = guildID
        }
            });
        }

        public void ReceiveTryAlliance(TryAllianceArg arg, TryAlliance res)
        {
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(ReceiveTryAlliance));
            if ((uint)res.errorcode > 0U)
                XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorcode);
            else
                this.SendGuildTerritoryChallInfo(this.CurrentTerritoryID);
        }

        public void SendRecAlliance(ulong guildID) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_RecAlliance()
        {
            oArg = {
        guildid = guildID
      }
        });

        public void ReceiveRecAlliance(RecAllianceArg arg, RecAllianceRes res)
        {
            if ((uint)res.errorcode > 0U)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorcode);
            }
            else
            {
                this.bHavaTerritoryRecCount = 0U;
                DlgBase<GuildTerritoryLeagueDlg, GuildTerritoryLeagueBehaviour>.singleton.SetVisibleWithAnimation(false, (DlgBase<GuildTerritoryLeagueDlg, GuildTerritoryLeagueBehaviour>.OnAnimationOver)null);
            }
        }

        public void SendClearGuildTerrAlliance() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_ClearGuildTerrAlliance());

        public void ReceiveClearGuildTerrAlliance(ClearGuildTerrAllianceRes res)
        {
            if ((uint)res.errorcode > 0U)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorcode);
            }
            else
            {
                this.bHavaTerritoryRecCount = 0U;
                DlgBase<GuildTerritoryLeagueDlg, GuildTerritoryLeagueBehaviour>.singleton.SetVisibleWithAnimation(false, (DlgBase<GuildTerritoryLeagueDlg, GuildTerritoryLeagueBehaviour>.OnAnimationOver)null);
            }
        }

        public enum GuildTerritoryStyle
        {
            NONE,
            INFORM,
            ACTIVITY,
        }
    }
}
