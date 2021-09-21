// Decompiled with JetBrains decompiler
// Type: XMainClient.XBillboardComponent
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal sealed class XBillboardComponent : XComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Character_Billboard");
        public static string HPBAR_TEMPLATE = "UI/Billboard/Billboard";
        private static readonly string BOSS_ICON_ATLAS = "common/Billboard";
        private static readonly string BOSS_ICON_SPRITE = "BOSSicon";
        private static readonly string ELITE_ICON_ATLAS = "common/Billboard";
        private static readonly string ELITE_ICON_SPRITE = "BOSSicon";
        private static readonly string GUILD_ICON_ATLAS = "common/Billboard";
        private static readonly string DESIGNATION_ATLAS = "common/Title";
        private static readonly string MILITARY_ATLAS = "common/Billboard";
        private static readonly string NPCFAVOR_ICON_SPRITE = "Blessing";
        private static readonly string POINT_ATLAS = "common/Billboard";
        private Transform _billboard = (Transform)null;
        private float _heroHeight = 10f;
        private float f = 1f;
        private IUIDummy _uiDummy = (IUIDummy)null;
        private static float k = 1f / 1000f;
        private static float[] fscale;
        private float _heroRidingHeight = 0.5f;
        private IXUIProgress _bloodBar = (IXUIProgress)null;
        private IXUIProgress _indureBar;
        public IXUIBillBoardCompRef _compRef;
        public IXUISpecLabelSymbol _desiSpcSymbol;
        public IXUISpecLabelSymbol _guildSpcSymbol;
        public IXUISpecLabelSymbol _nameSpcSymbol;
        private bool InitByMaster = false;
        private string _nameColor = "";
        private float _viewDistance = 0.0f;
        private bool _alwaysShow = false;
        private int _alwaysHide = 0;
        private BillboardUsage _secondbar_usage = BillboardUsage.Indure;
        private bool _bHitFlag = false;
        private uint _timer = 0;
        private uint _hideTimer = 0;
        private bool _onFreezeBuff = false;
        private UIBuffInfo _freezeBuffInfo;
        public static readonly Color billboard_red = (Color)new Color32(byte.MaxValue, (byte)61, (byte)35, byte.MaxValue);
        public static readonly Color billboard_yellow = (Color)new Color32(byte.MaxValue, byte.MaxValue, (byte)0, byte.MaxValue);
        public static readonly Color billboard_gold = (Color)new Color32(byte.MaxValue, (byte)153, (byte)0, byte.MaxValue);
        public static readonly Color billboard_sgreen = (Color)new Color32((byte)123, byte.MaxValue, (byte)128, byte.MaxValue);
        public static readonly Color billboard_green = (Color)new Color32((byte)92, byte.MaxValue, (byte)0, byte.MaxValue);
        public static readonly Color billboard_blue = (Color)new Color32((byte)0, (byte)189, byte.MaxValue, byte.MaxValue);
        public static readonly Color billboard_white = (Color)new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
        public static readonly Color billboard_ally_hp = (Color)new Color32(byte.MaxValue, (byte)236, (byte)0, byte.MaxValue);
        public static readonly Color billboard_favor = (Color)new Color32(byte.MaxValue, (byte)145, (byte)69, byte.MaxValue);
        public static readonly Color nullColor = (Color)new Color32((byte)0, (byte)0, (byte)0, (byte)0);
        public static readonly string billboardString_red = "[ff3d23]";
        public static readonly string billboardString_syellow = "[ffeb04]";
        public static readonly string billboardString_blue = "[00bdff]";
        public static readonly string billboardString_gold = "[ff9900]";
        public static readonly string billboardString_white = "[ffffff]";
        public bool _bHpbarVisible = false;
        public bool _bIndurebarVisible = false;
        private XTimerMgr.ElapsedEventHandler _resetOnHitCb = (XTimerMgr.ElapsedEventHandler)null;
        private bool _inited = false;
        private bool _active = false;
        private List<IXUILabel> TextDepthMgr = new List<IXUILabel>();
        private List<IXUISprite> SpriteDepthMgr = new List<IXUISprite>();
        private List<IXUISprite> BoardDepthMgr = new List<IXUISprite>();
        private int pointType = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("BigMeleePointType"));

        public override uint ID => XBillboardComponent.uuID;

        public XBillboardComponent() => this._resetOnHitCb = new XTimerMgr.ElapsedEventHandler(this.ResetOnHit);

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            GameObject billboard = XBillBoardDocument.GetBillboard(this._entity.EngineObject.Position, this._entity.EngineObject.Rotation);
            if ((Object)billboard != (Object)null)
            {
                billboard.name = this._entity.ID.ToString() + "_billb";
                this._billboard = billboard.transform;
            }
            this._uiDummy = this._billboard.GetComponent("UIDummy") as IUIDummy;
            if (this._entity.IsNpc)
                XSingleton<UiUtility>.singleton.AddChild(XSingleton<XGameUI>.singleton.NpcHpbarRoot.UIComponent as IUIRect, billboard, XSingleton<XGameUI>.singleton.NpcHpbarRoot);
            else
                XSingleton<UiUtility>.singleton.AddChild(XSingleton<XGameUI>.singleton.HpbarRoot.UIComponent as IUIRect, billboard, XSingleton<XGameUI>.singleton.HpbarRoot);
            if (XBillboardComponent.fscale != null)
                return;
            XSingleton<XGlobalConfig>.singleton.GetFloatList("BillboardScaleConfig", ref XBillboardComponent.fscale);
        }

        protected override void EventSubscribe()
        {
            this.RegisterEvent(XEventDefine.XEvent_HUDAdd, new XComponent.XEventHandler(this.OnHit));
            this.RegisterEvent(XEventDefine.XEvent_GuildInfoChange, new XComponent.XEventHandler(this.OnGuildInfoChange));
            this.RegisterEvent(XEventDefine.XEvent_DesignationInfoChange, new XComponent.XEventHandler(this.OnDesignationInfoChange));
            this.RegisterEvent(XEventDefine.XEvent_TitleChange, new XComponent.XEventHandler(this.OnTitleNameChange));
            this.RegisterEvent(XEventDefine.XEvent_BillboardHide, new XComponent.XEventHandler(this.OnHideSelf));
            this.RegisterEvent(XEventDefine.XEvent_BillboardShowCtrl, new XComponent.XEventHandler(this.OnShowCtrl));
            this.RegisterEvent(XEventDefine.XEvent_FightGroupChanged, new XComponent.XEventHandler(this.OnFightGroupChange));
            this.RegisterEvent(XEventDefine.XEvent_BigMeleePointChange, new XComponent.XEventHandler(this.OnBigMeleePointChange));
            this.RegisterEvent(XEventDefine.XEvent_BigMeleeEnemyChange, new XComponent.XEventHandler(this.OnBigMeleeEnemyChange));
        }

        private bool OnHit(XEventArgs e)
        {
            this._bHitFlag = true;
            if (this._timer > 0U)
                XSingleton<XTimerMgr>.singleton.KillTimer(this._timer);
            this._timer = XSingleton<XTimerMgr>.singleton.SetTimer(2f, this._resetOnHitCb, (object)null);
            return true;
        }

        private void ResetOnHit(object o) => this._bHitFlag = false;

        private bool OnFightGroupChange(XEventArgs e)
        {
            this.Refresh();
            return true;
        }

        public void Refresh() => this.Attached();

        public float viewDistance => this._viewDistance;

        public bool alwaysShow => this._alwaysShow;

        public override void Attached()
        {
            base.Attached();
            this._inited = true;
            this._compRef = this._billboard.GetComponent("XUIBillBoardCompRef") as IXUIBillBoardCompRef;
            this._bloodBar = this._compRef.BloodBar;
            this._indureBar = this._compRef.IndureBar;
            this._desiSpcSymbol = this._compRef.DesiSpecLabelSymbol;
            this._guildSpcSymbol = this._compRef.GuildSpecLabelSymbol;
            this._nameSpcSymbol = this._compRef.NameSpecLabelSymbol;
            this._active = this._billboard.gameObject.activeInHierarchy;
            if (!this._active)
                return;
            this._desiSpcSymbol.SetVisible(false);
            this.UpdateDesignationPos();
            XEntityStatistics.RowData byId1 = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
            this._alwaysShow = !this._entity.IsRole && byId1 != null && byId1.AlwaysHpBar;
            if (XSingleton<XSceneMgr>.singleton.IsPVEScene())
            {
                if (XSingleton<XScene>.singleton.bSpectator && (XSingleton<XEntityMgr>.singleton.Player == null || XSingleton<XEntityMgr>.singleton.Player.WatchTo == null))
                {
                    this._inited = false;
                    return;
                }
                bool flag = XSingleton<XScene>.singleton.bSpectator ? XSingleton<XEntityMgr>.singleton.IsOpponent((XEntity)XSingleton<XEntityMgr>.singleton.Player.WatchTo, this._entity) : XSingleton<XEntityMgr>.singleton.IsOpponent((XEntity)XSingleton<XEntityMgr>.singleton.Player, this._entity);
                this._viewDistance = XSingleton<XProfessionSkillMgr>.singleton.GetVisibleDistance();
                if (this._entity.IsPlayer)
                {
                    this.SetupInfo(false, false, this._alwaysShow, false, "", XBillboardComponent.nullColor, XBillboardComponent.nullColor, XBillboardComponent.nullColor);
                    this.f = XBillboardComponent.fscale[0];
                }
                else if (flag)
                {
                    if (this._entity.IsBoss)
                    {
                        this._viewDistance = 30f;
                        this.SetupInfo(true, false, this._alwaysShow, false, XBillboardComponent.billboardString_red, XBillboardComponent.nullColor, XBillboardComponent.nullColor, XBillboardComponent.nullColor);
                        XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr(XBillboardComponent.BOSS_ICON_ATLAS, XBillboardComponent.BOSS_ICON_SPRITE), this.GetStr("", this._nameColor + this._entity.Attributes.Name), this.GetStr(XBillboardComponent.BOSS_ICON_ATLAS, XBillboardComponent.BOSS_ICON_SPRITE));
                        this.f = XBillboardComponent.fscale[1];
                    }
                    else if (this._entity.IsElite)
                    {
                        this.SetupInfo(true, false, true, true, XBillboardComponent.billboardString_gold, XBillboardComponent.nullColor, XBillboardComponent.billboard_red, XBillboardComponent.billboard_yellow);
                        XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr(XBillboardComponent.ELITE_ICON_ATLAS, XBillboardComponent.ELITE_ICON_SPRITE), this.GetStr("", this._nameColor + this._entity.Attributes.Name), this.GetStr(XBillboardComponent.ELITE_ICON_ATLAS, XBillboardComponent.ELITE_ICON_SPRITE));
                        this._alwaysShow = true;
                        this._bHpbarVisible = true;
                        this._bIndurebarVisible = true;
                        this._secondbar_usage = BillboardUsage.Indure;
                        this.f = XBillboardComponent.fscale[2];
                    }
                    else if (this._entity.IsOpposer)
                    {
                        if (this._entity.Prefab == "Empty_monster_trap")
                        {
                            this.SetupInfo(false, false, false, false, "", XBillboardComponent.nullColor, XBillboardComponent.billboard_red, XBillboardComponent.nullColor);
                            this._bHpbarVisible = false;
                        }
                        else
                        {
                            this.SetupInfo(false, false, true, false, "", XBillboardComponent.nullColor, XBillboardComponent.billboard_red, XBillboardComponent.nullColor);
                            this._bHpbarVisible = true;
                        }
                        this.f = XBillboardComponent.fscale[3];
                    }
                    else if (this._entity.IsRole)
                    {
                        this.SetupInfo(true, true, true, false, XBillboardComponent.billboardString_red, XBillboardComponent.billboard_red, XBillboardComponent.billboard_red, XBillboardComponent.nullColor);
                        this._alwaysShow = true;
                        this._bHpbarVisible = true;
                        this._bIndurebarVisible = false;
                        this.SetupGuildInfo();
                        this.f = XBillboardComponent.fscale[4];
                    }
                }
                else
                {
                    this._viewDistance = 10f;
                    if (!this._entity.IsPuppet && !this._entity.IsSubstance)
                    {
                        XEntityStatistics.RowData byId2 = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
                        if (!this._entity.IsRole && byId2 != null)
                            this.SetupInfo(!byId2.HideName, false, this._alwaysShow, false, XBillboardComponent.billboardString_blue, XBillboardComponent.billboard_blue, XBillboardComponent.billboard_ally_hp, XBillboardComponent.nullColor);
                        else
                            this.SetupInfo(true, false, this._alwaysShow, false, XBillboardComponent.billboardString_blue, XBillboardComponent.billboard_blue, XBillboardComponent.billboard_ally_hp, XBillboardComponent.nullColor);
                        this._bHpbarVisible = this._alwaysShow;
                        this.SetupGuildInfo();
                        this.f = !this._entity.IsRole ? XBillboardComponent.fscale[6] : XBillboardComponent.fscale[4];
                    }
                }
            }
            else if (XSingleton<XSceneMgr>.singleton.IsPVPScene())
            {
                this._viewDistance = 10f;
                this._bHpbarVisible = true;
                this._bIndurebarVisible = true;
                this.f = !this._entity.IsPlayer ? XBillboardComponent.fscale[4] : XBillboardComponent.fscale[0];
                if ((this._entity.IsRole || this._entity.Attributes != null && this._entity.Attributes.HostID != 0UL) && XSingleton<XScene>.singleton.bSpectator)
                {
                    if (this._entity.IsPlayer)
                    {
                        this._bHpbarVisible = false;
                        this._bIndurebarVisible = false;
                        this.SetupInfo(false, false, false, false, XBillboardComponent.billboardString_blue, XBillboardComponent.billboard_blue, XBillboardComponent.billboard_green, XBillboardComponent.billboard_blue);
                    }
                    else if (this._entity.IsRole)
                    {
                        bool isBlueTeam;
                        if (!XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID).TryGetEntityIsBlueTeam(this._entity, out isBlueTeam))
                        {
                            this._bHpbarVisible = false;
                            this._bIndurebarVisible = false;
                            this.SetupInfo(false, false, false, false, XBillboardComponent.billboardString_blue, XBillboardComponent.billboard_blue, XBillboardComponent.billboard_green, XBillboardComponent.billboard_blue);
                        }
                        else
                        {
                            if (isBlueTeam)
                                this.SetupInfo(true, true, true, true, XBillboardComponent.billboardString_blue, XBillboardComponent.billboard_green, XBillboardComponent.billboard_green, XBillboardComponent.billboard_blue);
                            else
                                this.SetupInfo(true, true, true, true, XBillboardComponent.billboardString_red, XBillboardComponent.billboard_green, XBillboardComponent.billboard_red, XBillboardComponent.billboard_blue);
                            this._alwaysShow = true;
                            this._secondbar_usage = BillboardUsage.MP;
                            this.SetupGuildInfo();
                        }
                        this.DealWithTitleNameChange(0U, (this._entity.Attributes as XRoleAttributes).MilitaryRank);
                    }
                    else if (this._entity.Attributes != null && this._entity.Attributes.HostID > 0UL)
                    {
                        bool isBlueTeam;
                        if (!XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID).TryGetSummonedIsBlueTeam(this._entity, out isBlueTeam))
                        {
                            this._bHpbarVisible = false;
                            this._bIndurebarVisible = false;
                            this.SetupInfo(false, false, false, false, XBillboardComponent.billboardString_blue, XBillboardComponent.billboard_blue, XBillboardComponent.billboard_green, XBillboardComponent.billboard_blue);
                        }
                        else
                        {
                            string nameColor = isBlueTeam ? XBillboardComponent.billboardString_blue : XBillboardComponent.billboardString_red;
                            Color bloodColor = isBlueTeam ? XBillboardComponent.billboard_green : XBillboardComponent.billboard_red;
                            this._bIndurebarVisible = false;
                            XEntityStatistics.RowData byId3 = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
                            this.SetupInfo(byId3 == null || !byId3.HideName, false, true, false, nameColor, XBillboardComponent.billboard_green, bloodColor, XBillboardComponent.billboard_blue);
                            this._bHpbarVisible = this._alwaysShow;
                            this._secondbar_usage = BillboardUsage.MP;
                        }
                    }
                }
                else if (!this._entity.IsPlayer && XSingleton<XEntityMgr>.singleton.IsOpponent((XEntity)XSingleton<XEntityMgr>.singleton.Player, this._entity))
                {
                    if (!this._entity.IsRole)
                    {
                        this._bIndurebarVisible = false;
                        XEntityStatistics.RowData byId4 = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
                        if (byId4 != null)
                            this.SetupInfo(!byId4.HideName, false, true, false, XBillboardComponent.billboardString_red, XBillboardComponent.billboard_red, XBillboardComponent.billboard_red, XBillboardComponent.nullColor);
                        else
                            this.SetupInfo(true, true, true, true, XBillboardComponent.billboardString_red, XBillboardComponent.billboard_red, XBillboardComponent.billboard_red, XBillboardComponent.billboard_blue);
                        this.SetupGuildInfo();
                        this._bHpbarVisible = this._alwaysShow;
                    }
                    else
                    {
                        this.SetupInfo(true, true, true, true, XBillboardComponent.billboardString_red, XBillboardComponent.billboard_red, XBillboardComponent.billboard_red, XBillboardComponent.billboard_blue);
                        this.SetupGuildInfo();
                        this.DealWithTitleNameChange(0U, (this._entity.Attributes as XRoleAttributes).MilitaryRank);
                    }
                    this._secondbar_usage = BillboardUsage.MP;
                }
                else
                {
                    if (!this._entity.IsPlayer && !this._entity.IsRole)
                    {
                        this._bIndurebarVisible = false;
                        XEntityStatistics.RowData byId5 = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
                        if (byId5 != null)
                            this.SetupInfo(!byId5.HideName, false, true, false, XBillboardComponent.billboardString_blue, XBillboardComponent.billboard_blue, XBillboardComponent.billboard_green, XBillboardComponent.nullColor);
                        else
                            this.SetupInfo(true, true, true, true, XBillboardComponent.billboardString_blue, XBillboardComponent.billboard_blue, XBillboardComponent.billboard_green, XBillboardComponent.billboard_blue);
                        this.SetupGuildInfo();
                        this._bHpbarVisible = this._alwaysShow;
                    }
                    else
                    {
                        if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_FIGHT)
                            this.SetupInfo(true, true, true, true, XBillboardComponent.billboardString_blue, XBillboardComponent.billboard_white, XBillboardComponent.billboard_green, XBillboardComponent.billboard_blue);
                        else
                            this.SetupInfo(true, true, true, true, XBillboardComponent.billboardString_blue, XBillboardComponent.billboard_blue, XBillboardComponent.billboard_green, XBillboardComponent.billboard_blue);
                        this.SetupGuildInfo();
                        if (this._entity.IsPlayer)
                            this.DealWithTitleNameChange(XSingleton<XAttributeMgr>.singleton.XPlayerData.TitleID, XSingleton<XAttributeMgr>.singleton.XPlayerData.MilitaryRank);
                        else
                            this.DealWithTitleNameChange(0U, (this._entity.Attributes as XRoleAttributes).MilitaryRank);
                    }
                    this._secondbar_usage = BillboardUsage.MP;
                }
            }
            else if (this._entity.IsPlayer)
            {
                this.SetupInfo(true, true, false, false, XBillboardComponent.billboardString_blue, XBillboardComponent.billboard_sgreen, XBillboardComponent.nullColor, XBillboardComponent.nullColor);
                this.SetupGuildInfo();
                XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
                this.DealWithDesignation(specificDocument.CoverDesignationID, specificDocument.SpecialDesignation);
                this.DealWithTitleNameChange(XSingleton<XAttributeMgr>.singleton.XPlayerData.TitleID, XSingleton<XAttributeMgr>.singleton.XPlayerData.MilitaryRank);
                this.f = XBillboardComponent.fscale[0];
            }
            else if (XSingleton<XEntityMgr>.singleton.IsAlly(this._entity))
            {
                this._viewDistance = Mathf.Sqrt(XQualitySetting._FadeDistance);
                if (this._entity.IsRole)
                {
                    this.SetupInfo(true, true, false, false, XBillboardComponent.billboardString_white, XBillboardComponent.billboard_sgreen, XBillboardComponent.nullColor, XBillboardComponent.nullColor);
                    this.SetupGuildInfo();
                    XRoleAttributes attributes = this._entity.Attributes as XRoleAttributes;
                    this.DealWithDesignation(attributes.DesignationID, attributes.SpecialDesignation);
                    this.DealWithTitleNameChange(this._entity.Attributes.TitleID, attributes.MilitaryRank);
                    this.f = XBillboardComponent.fscale[4];
                }
                else
                {
                    this.SetupInfo(true, false, this._alwaysShow, false, XBillboardComponent.billboardString_white, XBillboardComponent.billboard_white, XBillboardComponent.nullColor, XBillboardComponent.nullColor);
                    this.f = XBillboardComponent.fscale[6];
                }
            }
            else if (this._entity.IsNpc)
            {
                if (XSingleton<XEntityMgr>.singleton.NpcInfo.GetByNPCID(this._entity.TypeID).NPCType == 2U)
                {
                    this._nameSpcSymbol.SetVisible(false);
                }
                else
                {
                    if (XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID).IsShowNPCFavoritePlayer(this._entity.TypeID))
                    {
                        this.SetupInfo(true, true, this._alwaysShow, false, XBillboardComponent.billboardString_syellow, XBillboardComponent.billboard_favor, XBillboardComponent.nullColor, XBillboardComponent.nullColor);
                        this.SetupNpcFavorInfo();
                    }
                    else
                        this.SetupInfo(true, false, this._alwaysShow, false, XBillboardComponent.billboardString_syellow, XBillboardComponent.nullColor, XBillboardComponent.nullColor, XBillboardComponent.nullColor);
                    this._viewDistance = 10f;
                    this.f = XBillboardComponent.fscale[5];
                }
            }
            this.DrawStr(this._nameSpcSymbol);
            if (this._entity.IsPlayer)
                this.SetBillBoardDepth(true);
            else
                this.KeepAllDepth();
            this._billboard.transform.localScale = new Vector3(XBillboardComponent.k * this.f, XBillboardComponent.k * this.f, XBillboardComponent.k * this.f);
            this._uiDummy.alpha = 0.0f;
        }

        private void SetupNpcFavorInfo()
        {
            if (XSingleton<XSceneMgr>.singleton.IsPVEScene() || XSingleton<XSceneMgr>.singleton.IsPVPScene() || !this._entity.IsNpc)
            {
                this._guildSpcSymbol.SetVisible(false);
            }
            else
            {
                string favoritePlayerName = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID).GetFavoritePlayerName(this._entity.TypeID);
                XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr(XBillboardComponent.GUILD_ICON_ATLAS, XBillboardComponent.NPCFAVOR_ICON_SPRITE), this.GetStr("", string.Format("{0}", (object)favoritePlayerName)));
                this.DrawStr(this._guildSpcSymbol);
                XSingleton<UiUtility>.singleton.ComSpriteStr.Clear();
                XSingleton<UiUtility>.singleton.ComSpriteStr.Add(this.GetStr("", this._nameColor + this._entity.Attributes.Name));
            }
        }

        private void SetBillBoardSameByMaster()
        {
            if (!XEntity.ValideEntity(this._entity.MobbedBy))
                return;
            XBillboardComponent billBoard = this._entity.MobbedBy.BillBoard;
            this._bHpbarVisible = billBoard._bHpbarVisible;
            this._bIndurebarVisible = billBoard._bIndurebarVisible;
            this._indureBar.SetForegroundColor(XBillboardComponent.billboard_blue);
            this._desiSpcSymbol.Copy(billBoard._desiSpcSymbol);
            this._guildSpcSymbol.Copy(billBoard._guildSpcSymbol);
            this._nameSpcSymbol.Copy(billBoard._nameSpcSymbol);
        }

        private bool OnGuildInfoChange(XEventArgs e)
        {
            this.SetupGuildInfo();
            this.UpdateDesignationPos();
            this.KeepAllDepth();
            return true;
        }

        private void UpdateDesignationPos()
        {
            if (this._entity.IsPlayer)
            {
                if (!XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).bInGuild)
                    this._desiSpcSymbol.gameObject.transform.localPosition = new Vector3(0.0f, 65f, 0.0f);
                else
                    this._desiSpcSymbol.gameObject.transform.localPosition = new Vector3(0.0f, 96f, 0.0f);
            }
            else
            {
                if (!this._entity.IsRole || !(this._entity.Attributes is XRoleAttributes attributes2))
                    return;
                if (string.IsNullOrEmpty(attributes2.GuildName) && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_BIGMELEE_FIGHT)
                    this._desiSpcSymbol.gameObject.transform.localPosition = new Vector3(0.0f, 65f, 0.0f);
                else
                    this._desiSpcSymbol.gameObject.transform.localPosition = new Vector3(0.0f, 96f, 0.0f);
            }
        }

        private bool isTerritoryFight => XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_FIGHT || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_WAIT;

        public void OnFightDesignationInfoChange(uint id)
        {
            if (!this.isTerritoryFight || !this._entity.IsRole)
                return;
            FightDesignation.RowData designation = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID).GetDesignation(id);
            this._desiSpcSymbol.SetVisible(id != 0U && designation != null);
            if (id != 0U && designation != null)
            {
                if (string.IsNullOrEmpty(designation.Effect))
                {
                    this._desiSpcSymbol.Board.SetVisible(true);
                    XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr("", designation.Color + designation.Designation));
                    this.DrawStr(this._desiSpcSymbol);
                }
                else
                {
                    this._desiSpcSymbol.Board.SetVisible(false);
                    XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr(XBillboardComponent.DESIGNATION_ATLAS, designation.Effect));
                    this.DrawStr(this._desiSpcSymbol);
                }
            }
        }

        private void DealWithDesignation(uint id, string specDesi)
        {
            if (this.isTerritoryFight)
                return;
            DesignationTable.RowData byId = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID)._DesignationTable.GetByID((int)id);
            if (byId == null)
                id = 0U;
            this._desiSpcSymbol.SetVisible(id > 0U);
            if (id <= 0U)
                return;
            if (byId.Effect == "")
            {
                this._desiSpcSymbol.Board.SetVisible(true);
                if (byId.Special)
                    XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr("", byId.Color + specDesi));
                else
                    XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr("", byId.Color + byId.Designation));
                this.DrawStr(this._desiSpcSymbol);
            }
            else
            {
                this._desiSpcSymbol.Board.SetVisible(false);
                XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr(byId.Atlas, byId.Effect));
                this.DrawStr(this._desiSpcSymbol);
            }
        }

        public bool OnDesignationInfoChange(XEventArgs e = null)
        {
            if (XSingleton<XSceneMgr>.singleton.IsPVEScene() || XSingleton<XSceneMgr>.singleton.IsPVPScene())
                return true;
            if (this._entity.IsPlayer)
            {
                XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
                this.DealWithDesignation(specificDocument.CoverDesignationID, specificDocument.SpecialDesignation);
            }
            else if (this._entity.IsRole)
            {
                XRoleAttributes attributes = this._entity.Attributes as XRoleAttributes;
                this.DealWithDesignation(attributes.DesignationID, attributes.SpecialDesignation);
            }
            this.KeepAllDepth();
            return true;
        }

        private void DealWithTitleNameChange(uint titleId, uint level)
        {
            XSingleton<UiUtility>.singleton.ComSpriteStr.Clear();
            if (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PVP || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GPR || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_WAIT || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_FIGHT)
            {
                MilitaryRankByExploit.RowData byMilitaryRank = XMilitaryRankDocument._militaryReader.GetByMilitaryRank(level);
                if (byMilitaryRank != null)
                    XSingleton<UiUtility>.singleton.ComSpriteStr.Add(this.GetStr(XBillboardComponent.MILITARY_ATLAS, byMilitaryRank.Icon));
            }
            if (!XSingleton<XSceneMgr>.singleton.IsPVPScene() && titleId > 0U)
            {
                TitleTable.RowData title = XTitleDocument.GetTitle(titleId);
                if (title != null)
                    XSingleton<UiUtility>.singleton.ComSpriteStr.Add(this.GetStr(title.RankAtlas, title.RankIcon, true));
            }
            XSingleton<UiUtility>.singleton.ComSpriteStr.Add(this.GetStr("", this._nameColor + this._entity.Attributes.Name));
        }

        public bool OnTitleNameChange(XEventArgs e = null)
        {
            if (XSingleton<XSceneMgr>.singleton.IsPVEScene())
                return true;
            if (this._entity.IsPlayer)
                this.DealWithTitleNameChange(XSingleton<XAttributeMgr>.singleton.XPlayerData.TitleID, XSingleton<XAttributeMgr>.singleton.XPlayerData.MilitaryRank);
            else if (this._entity.IsRole)
                this.DealWithTitleNameChange(this._entity.Attributes.TitleID, (this._entity.Attributes as XRoleAttributes).MilitaryRank);
            this.DrawStr(this._nameSpcSymbol);
            this.KeepAllDepth();
            return true;
        }

        public void OnGuildCollectNpcNameChange(string name)
        {
            XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr("", this._nameColor + name));
            this.DrawStr(this._nameSpcSymbol);
        }

        private void SetupInfo(
          bool nameState,
          bool guildState,
          bool bloodBarState,
          bool indureBarState,
          string nameColor,
          Color guildColor,
          Color bloodColor,
          Color indureColor)
        {
            if (bloodBarState)
            {
                this._bloodBar.gameObject.SetActive(true);
                this._bloodBar.SetForegroundColor(bloodColor);
            }
            else
                this._bloodBar.gameObject.SetActive(false);
            if (nameState)
            {
                this._nameSpcSymbol.SetVisible(true);
                XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr("", nameColor + this._entity.Attributes.Name));
                this._nameColor = nameColor;
            }
            else
                this._nameSpcSymbol.SetVisible(false);
            if (guildState)
            {
                this._guildSpcSymbol.SetVisible(true);
                this._guildSpcSymbol.SetColor(guildColor);
            }
            else
                this._guildSpcSymbol.SetVisible(false);
            if (indureBarState)
            {
                this._indureBar.gameObject.SetActive(true);
                this._indureBar.SetForegroundColor(indureColor);
            }
            else
                this._indureBar.gameObject.SetActive(false);
        }

        private void SetupGuildInfo()
        {
            if (XSingleton<XSceneMgr>.singleton.IsPVEScene() || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BATTLEFIELD_FIGHT || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_FIGHT)
                this._guildSpcSymbol.SetVisible(false);
            else if (this._entity.IsPlayer)
            {
                XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
                if (specificDocument.bInGuild)
                {
                    this._guildSpcSymbol.SetVisible(true);
                    XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr(XBillboardComponent.GUILD_ICON_ATLAS, XGuildDocument.GetPortraitName(specificDocument.BasicData.portraitIndex)), this.GetStr("", string.Format("<{0}>", (object)specificDocument.BasicData.guildName)));
                    this.DrawStr(this._guildSpcSymbol);
                }
                else
                    this._guildSpcSymbol.SetVisible(false);
            }
            else if (this._entity.IsRole)
            {
                if (!(this._entity.Attributes is XRoleAttributes attributes4))
                    return;
                if (string.IsNullOrEmpty(attributes4.GuildName))
                {
                    this._guildSpcSymbol.SetVisible(false);
                }
                else
                {
                    this._guildSpcSymbol.SetVisible(true);
                    XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr(XBillboardComponent.GUILD_ICON_ATLAS, XGuildDocument.GetPortraitName((int)attributes4.GuildPortrait)), this.GetStr("", string.Format("<{0}>", (object)attributes4.GuildName)));
                    this.DrawStr(this._guildSpcSymbol);
                }
            }
            else
            {
                if (!this._entity.IsBoss)
                    return;
                this._guildSpcSymbol.SetVisible(false);
            }
        }

        public override void OnDetachFromHost()
        {
            if (this._timer > 0U)
                XSingleton<XTimerMgr>.singleton.KillTimer(this._timer);
            if (this._hideTimer > 0U)
                XSingleton<XTimerMgr>.singleton.KillTimer(this._hideTimer);
            this._alwaysHide = 0;
            this._alwaysShow = false;
            this.DestroyGameObjects();
            this._entity.BillBoard = (XBillboardComponent)null;
            base.OnDetachFromHost();
        }

        private void DestroyGameObjects()
        {
            if (!((Object)this._billboard != (Object)null))
                return;
            this.ClearRef(this._desiSpcSymbol);
            this.ClearRef(this._guildSpcSymbol);
            this.ClearRef(this._nameSpcSymbol);
            XBillBoardDocument.ReturnBillboard(this._billboard.gameObject);
            this._billboard = (Transform)null;
        }

        private void ClearRef(IXUISpecLabelSymbol symbol)
        {
            if (symbol == null)
                return;
            for (int index = 0; index < symbol.SpriteList.Length; ++index)
            {
                symbol.SpriteList[index].spriteName = "";
                symbol.SetSpriteVisibleFalse(index);
            }
        }

        private bool OnHideSelf(XEventArgs e)
        {
            this._alwaysHide |= 1 << XFastEnumIntEqualityComparer<BillBoardHideType>.ToInt(BillBoardHideType.LevelScript);
            XBillboardHideEventArgs xbillboardHideEventArgs = e as XBillboardHideEventArgs;
            if (this._hideTimer > 0U)
                XSingleton<XTimerMgr>.singleton.KillTimer(this._hideTimer);
            this._hideTimer = XSingleton<XTimerMgr>.singleton.SetTimer(xbillboardHideEventArgs.hidetime, new XTimerMgr.ElapsedEventHandler(this.ReShow), (object)null);
            return true;
        }

        private void ReShow(object o) => this._alwaysHide &= ~(1 << XFastEnumIntEqualityComparer<BillBoardHideType>.ToInt(BillBoardHideType.LevelScript));

        private bool OnShowCtrl(XEventArgs e)
        {
            XBillboardShowCtrlEventArgs showCtrlEventArgs = e as XBillboardShowCtrlEventArgs;
            if (showCtrlEventArgs.type == BillBoardHideType.Invalid)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("undefine billboard hide type. check code or contect pyc.");
                return false;
            }
            if (showCtrlEventArgs.show)
                this._alwaysHide &= ~(1 << XFastEnumIntEqualityComparer<BillBoardHideType>.ToInt(showCtrlEventArgs.type));
            else
                this._alwaysHide |= 1 << XFastEnumIntEqualityComparer<BillBoardHideType>.ToInt(showCtrlEventArgs.type);
            return true;
        }

        public override void PostUpdate(float fDeltaT)
        {
            if (!(this._host is XEntity host))
                return;
            if (!this._entity.IsDummy && !this._active && (Object)this._billboard != (Object)null)
            {
                if (!this._billboard.gameObject.activeInHierarchy)
                    return;
                this.Attached();
            }
            if (!this.InitByMaster && this._entity.MobbedBy != null)
            {
                this.InitByMaster = true;
                if ((this._entity.Attributes as XOthersAttributes).SameBillBoardByMaster)
                    this.SetBillBoardSameByMaster();
            }
            if (!this.InitByMaster && this._entity.Attributes != null && this._entity.Attributes.HostID > 0UL)
            {
                this.InitByMaster = true;
                this.Refresh();
            }
            if (this._entity.IsDummy)
                this.UpdateDummyBillboard();
            else if (!XEntity.ValideEntity(host))
                this._uiDummy.alpha = 0.0f;
            else if ((uint)this._alwaysHide > 0U)
            {
                this._uiDummy.alpha = 0.0f;
            }
            else
            {
                XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
                if (player == null || player.EngineObject == null)
                    this.DestroyGameObjects();
                else if ((double)Vector3.Distance(host.EngineObject.Position, player.EngineObject.Position) > (double)this._viewDistance && !this._bHitFlag && (Object)this._billboard != (Object)null && !this._alwaysShow)
                {
                    this._uiDummy.alpha = 0.0f;
                }
                else
                {
                    if (!((Object)this._billboard != (Object)null))
                        return;
                    this.UpdateHpBar();
                }
            }
        }

        private void UpdateHpBar()
        {
            if (!this._inited && XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.WatchTo != null)
                this.Attached();
            if ((double)this._uiDummy.alpha == 0.0)
                this._uiDummy.alpha = 1f;
            float num1 = 0.2f;
            if (!this._bloodBar.gameObject.activeSelf)
                num1 -= 0.05f;
            if (!this._indureBar.gameObject.activeSelf)
                num1 -= 0.05f;
            this._heroHeight = this._entity.Transformer == null || !XEntity.ValideEntity(this._entity.Transformer) ? this._entity.Height : this._entity.Transformer.Height;
            Vector3 vector3 = new Vector3(this._entity.EngineObject.Position.x, this._entity.EngineObject.Position.y + (this._entity.Attributes == null || this._entity.Attributes.Outlook == null || this._entity.Attributes.Outlook.state == null || !this._entity.Attributes.Outlook.state.bMounted ? this._heroHeight : this._heroRidingHeight) + num1, this._entity.EngineObject.Position.z);
            if (this._entity.Prefab == "Empty_monster" && this._entity.Skill.IsCasting() && this._entity.Skill.CurrentSkill.Target != null)
                vector3 = new Vector3(this._entity.Skill.CurrentSkill.Target.MoveObj.Position.x, this._entity.Skill.CurrentSkill.Target.MoveObj.Position.y + this._heroHeight + num1, this._entity.Skill.CurrentSkill.Target.EngineObject.Position.z);
            this._billboard.position = vector3;
            this._billboard.rotation = XSingleton<XScene>.singleton.GameCamera.Rotaton;
            if (XSingleton<XEntityMgr>.singleton.Player != null)
            {
                float k = XBillboardComponent.k;
                float num2 = 6.27f;
                float dis = Vector3.Distance(XSingleton<XScene>.singleton.GameCamera.UnityCamera.transform.position, this._billboard.position);
                if (!this._entity.IsPlayer && Time.frameCount % 15 == 0)
                    this.SetBillBoardDepth(false, dis);
                float num3 = k * this.f * dis / num2;
                this._billboard.localScale = new Vector3(num3, num3, num3);
            }
            this._bloodBar.gameObject.SetActive(this._bHpbarVisible && !this._entity.Present.IsShowUp);
            this._indureBar.gameObject.SetActive(this._bIndurebarVisible && !this._entity.Present.IsShowUp);
            if (this._entity.Attributes == null)
                return;
            if (this._onFreezeBuff)
            {
                if (this._freezeBuffInfo == null)
                {
                    this._onFreezeBuff = false;
                }
                else
                {
                    this._bloodBar.gameObject.SetActive(true);
                    this._indureBar.gameObject.SetActive(false);
                    this._bloodBar.value = (float)(this._freezeBuffInfo.HP / this._freezeBuffInfo.maxHP);
                    this._billboard.localScale *= 1.4f;
                    return;
                }
            }
            double attr1 = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
            double num4 = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
            if (num4 < 0.0)
                num4 = 0.0;
            this._bloodBar.value = (float)(num4 / attr1);
            if (this._indureBar.gameObject.activeInHierarchy)
            {
                if (this._secondbar_usage == BillboardUsage.Indure)
                {
                    double attr2 = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxSuperArmor_Total);
                    double attr3 = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentSuperArmor_Total);
                    if (attr2 > 0.0)
                    {
                        this._indureBar.gameObject.SetActive(true);
                        this._indureBar.value = attr3 >= attr2 ? 1f : (float)(attr3 / attr2);
                    }
                    else
                        this._indureBar.gameObject.SetActive(false);
                }
                else if (this._secondbar_usage == BillboardUsage.MP)
                {
                    double attr4 = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxMP_Total);
                    double attr5 = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentMP_Basic);
                    this._indureBar.value = attr5 >= attr4 ? 1f : (float)(attr5 / attr4);
                }
            }
        }

        public void SetFreezeBuffState(UIBuffInfo buff)
        {
            if (buff == null)
            {
                this._onFreezeBuff = false;
                this._freezeBuffInfo = (UIBuffInfo)null;
                if (!XEntity.ValideEntity(this._entity))
                    return;
                this.Attached();
            }
            else
            {
                this._onFreezeBuff = true;
                this._freezeBuffInfo = buff;
                this._nameSpcSymbol.SetVisible(true);
                BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)buff.buffID, (int)buff.buffLevel);
                XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr("", XBillboardComponent.billboardString_red + buffData.BuffName));
                this.DrawStr(this._nameSpcSymbol);
                this._bloodBar.SetForegroundColor(XBillboardComponent.billboard_red);
            }
        }

        public void HideBillboard() => this._uiDummy.alpha = 0.0f;

        public void AttachDummyBillboard(string name, int level, int prof)
        {
            this._heroHeight = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.SelectChar ? 1f : XSingleton<XProfessionSkillMgr>.singleton.GetSelectCharDummyHeight((uint)prof);
            float num = 3f / 1000f;
            this._billboard.localScale = new Vector3(num, num, num);
            this._uiDummy.alpha = 1f;
            this._compRef = this._billboard.GetComponent("XUIBillBoardCompRef") as IXUIBillBoardCompRef;
            this._bloodBar = this._compRef.BloodBar;
            this._indureBar = this._compRef.IndureBar;
            this._guildSpcSymbol = this._compRef.GuildSpecLabelSymbol;
            this._desiSpcSymbol = this._compRef.DesiSpecLabelSymbol;
            this._nameSpcSymbol = this._compRef.NameSpecLabelSymbol;
            this._bloodBar.SetVisible(false);
            this._indureBar.SetVisible(false);
            this._guildSpcSymbol.SetVisible(false);
            this._desiSpcSymbol.SetVisible(false);
            this._nameSpcSymbol.SetVisible(true);
            XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr("", "Lv." + (object)level + " " + name));
            this.DrawStr(this._nameSpcSymbol);
        }

        public float GetExitTitleHeight()
        {
            float a = 0.0f;
            if ((Object)this._billboard != (Object)null)
            {
                for (int index = 0; index < this._billboard.childCount; ++index)
                {
                    Transform child = this._billboard.GetChild(index);
                    if (child.gameObject.activeSelf)
                        a = Mathf.Max(a, child.localPosition.y);
                }
            }
            return a;
        }

        public bool AttachChild(Transform child, bool updatePos = false, float childHeight = 60f)
        {
            if (!((Object)this._billboard != (Object)null))
                return false;
            child.parent = this._billboard;
            child.transform.localRotation = Quaternion.identity;
            child.transform.localScale = Vector3.one;
            if (updatePos)
            {
                float exitTitleHeight = this.GetExitTitleHeight();
                child.transform.localPosition = new Vector3(0.0f, exitTitleHeight + childHeight, 0.0f);
            }
            else
                child.transform.localPosition = Vector3.zero;
            return true;
        }

        public bool UnAttachChild(Transform child)
        {
            if ((Object)this._billboard != (Object)null)
            {
                for (int index = 0; index < this._billboard.childCount; ++index)
                {
                    if ((Object)this._billboard.GetChild(index) == (Object)child)
                    {
                        child.parent = (Transform)null;
                        return true;
                    }
                }
            }
            return false;
        }

        private void UpdateDummyBillboard()
        {
            this._billboard.position = new Vector3(this._entity.EngineObject.Position.x, this._entity.EngineObject.Position.y + this._heroHeight, this._entity.EngineObject.Position.z) + XSingleton<XCommon>.singleton.Horizontal(XSingleton<XScene>.singleton.GameCamera.CameraTrans.position - this._entity.EngineObject.Position) * 0.5f;
            this._billboard.rotation = XSingleton<XScene>.singleton.GameCamera.Rotaton;
        }

        public void SetSelectCharStageScale() => this._billboard.localScale = this._billboard.localScale / 3f * 2f;

        private void KeepAllDepth()
        {
            this.TextDepthMgr.Clear();
            this.SpriteDepthMgr.Clear();
            this.BoardDepthMgr.Clear();
            this.KeepDepth(this._desiSpcSymbol);
            this.KeepDepth(this._guildSpcSymbol);
            this.KeepDepth(this._nameSpcSymbol);
            if (!this._entity.IsPlayer)
                return;
            this.SetBillBoardDepth(true);
        }

        private void KeepDepth(IXUISpecLabelSymbol symbol)
        {
            if (!symbol.IsVisible())
                return;
            if (symbol.Label.IsVisible())
                this.TextDepthMgr.Add(symbol.Label);
            if (symbol.Board.IsVisible())
                this.BoardDepthMgr.Add(symbol.Board);
            for (int index = 0; index < symbol.SpriteList.Length; ++index)
            {
                if (symbol.SpriteList[index].IsVisible())
                    this.SpriteDepthMgr.Add(symbol.SpriteList[index]);
            }
        }

        private void SetBillBoardDepth(bool isMy, float dis = 0.0f)
        {
            if (!this._billboard.gameObject.activeInHierarchy)
                return;
            int num = isMy ? 10 : -(int)((double)dis * 100.0);
            for (int index = 0; index < this.TextDepthMgr.Count; ++index)
                this.TextDepthMgr[index].spriteDepth = num;
            for (int index = 0; index < this.SpriteDepthMgr.Count; ++index)
            {
                if (this.SpriteDepthMgr[index].spriteName != null)
                    this.SpriteDepthMgr[index].spriteDepth = num;
            }
            for (int index = 0; index < this.BoardDepthMgr.Count; ++index)
            {
                if (this.BoardDepthMgr[index].spriteName != null)
                    this.BoardDepthMgr[index].spriteDepth = num - 1;
            }
        }

        private void DrawStr(IXUISpecLabelSymbol symbol) => symbol.SetInputText(XSingleton<UiUtility>.singleton.ComSpriteStr);

        private string GetStr(string atlas, string sprite, bool isAnimation = false) => isAnimation ? string.Format("{0}|{1}|1", (object)atlas, (object)sprite) : string.Format("{0}|{1}|0", (object)atlas, (object)sprite);

        private bool OnBigMeleePointChange(XEventArgs e)
        {
            this.SetBigMeleePointInfo(XBigMeleeBattleDocument.Doc.userIdToRole[this._entity.ID].point, (long)DlgBase<BattleContiDlg, BattleContiBehaviour>.singleton.CurEnemy == (long)this._entity.ID);
            return true;
        }

        private bool OnBigMeleeEnemyChange(XEventArgs e)
        {
            this.SetBigMeleePointInfo(XBigMeleeBattleDocument.Doc.userIdToRole[this._entity.ID].point, (e as XBigMeleeEnemyChange).isEnemy);
            return true;
        }

        private void SetBigMeleePointInfo(uint point, bool isEnemy)
        {
            if (this.pointType == 1)
            {
                int num1 = 1;
                int num2 = 1;
                for (int index = (int)point; index >= 10; index /= 10)
                {
                    ++num1;
                    num2 *= 10;
                }
                int num3 = (int)point;
                int num4 = 0;
                string[] strArray1;
                if (isEnemy)
                {
                    strArray1 = new string[num1 + 2];
                    strArray1[num4++] = this.GetStr(XBillboardComponent.POINT_ATLAS, "icon_cr");
                }
                else
                    strArray1 = new string[num1 + 1];
                string[] strArray2 = strArray1;
                int index1 = num4;
                int num5 = index1 + 1;
                string str = this.GetStr(XBillboardComponent.POINT_ATLAS, "NmFight_jf");
                strArray2[index1] = str;
                for (int index2 = num5; index2 < num5 + num1; ++index2)
                {
                    strArray1[index2] = this.GetStr(XBillboardComponent.POINT_ATLAS, string.Format("NmFight_{0}", (object)(num3 / num2)));
                    num3 %= num2;
                    num2 /= 10;
                }
                XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(strArray1);
            }
            else if (isEnemy)
                XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr(XBillboardComponent.POINT_ATLAS, "icon_cr"), this.GetStr("", string.Format("{0}:{1}", (object)XStringDefineProxy.GetString("POINT"), (object)point)));
            else
                XSingleton<UiUtility>.singleton.BillBoardCommonSetSpriteStr(this.GetStr("", string.Format("{0}:{1}", (object)XStringDefineProxy.GetString("POINT"), (object)point)));
            this._guildSpcSymbol.SetVisible(true);
            this.DrawStr(this._guildSpcSymbol);
            XSingleton<UiUtility>.singleton.ComSpriteStr.Clear();
        }
    }
}
