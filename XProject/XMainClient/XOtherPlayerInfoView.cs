// Decompiled with JetBrains decompiler
// Type: XMainClient.XOtherPlayerInfoView
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
    internal class XOtherPlayerInfoView : DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>
    {
        private XOtherPlayerInfoDocument _doc = (XOtherPlayerInfoDocument)null;
        private ArtifactBagDocument m_doc = (ArtifactBagDocument)null;
        private EquipFusionDocument m_equipfusionDoc;
        private ulong m_PlayerId;
        private string m_PlayerName;
        private uint m_PlayerProfession;
        private uint m_PowerPoint;
        private List<uint> m_setid = new List<uint>();
        private uint m_PlayerLevel;
        public const int FUNC_NUM = 8;
        public const int EQUIP_NUM = 10;
        public const int AVATAR_NUM = 10;
        public const int EMBLEM_NUM = 16;
        public const int ARTIFACT_NUM = 4;
        private XDummy _PlayerDummy = (XDummy)null;
        private XSpriteAvatarHandler[] _SpriteAvatarHandler = new XSpriteAvatarHandler[4];
        private ArtifactQuanlityFx[] m_fuseBreakFx = new ArtifactQuanlityFx[10];
        private XAttributes m_Attributes = (XAttributes)null;
        private float _EclipsedTime = 0.0f;
        public List<IXUICheckBox> m_InfoCheck = new List<IXUICheckBox>();
        private Dictionary<Player_Info, IXUISprite> m_InfoDic = new Dictionary<Player_Info, IXUISprite>();
        private Dictionary<int, XItem> m_ItemDic = new Dictionary<int, XItem>();
        private Dictionary<uint, uint> _skillLevel = new Dictionary<uint, uint>();
        private HashSet<uint> _bindsSkills = new HashSet<uint>();
        private ArtifactQuanlityFx[] m_artifactQuanlityFx = new ArtifactQuanlityFx[XBagDocument.ArtifactMax];
        private XBodyBag m_EquipBag = new XBodyBag(XBagDocument.EquipMax);
        private XBodyBag m_artifactBag = new XBodyBag(XBagDocument.ArtifactMax);
        private List<uint> m_FashionBag = new List<uint>();
        private XPetSkillHandler m_SkillHandler;
        private XCharacterAttrView<XAttrOtherFile> m_CharacterAttrHandler;
        private XEmbleAttrView<XAttrOtherFile> m_EmbleAttrHandler;
        private XArtifactAttrView<XAttrOtherFile> m_artifactAttrHandler;
        private uint[] allParts = new uint[10];
        private uint lastPetID = 0;
        private bool hasPetInfo = false;

        public override string fileName => "GameSystem/OtherPlayerInfo";

        public override int group => 1;

        public override bool autoload => true;

        protected override void Init()
        {
            this._doc = XDocuments.GetSpecificDocument<XOtherPlayerInfoDocument>(XOtherPlayerInfoDocument.uuID);
            this._doc.OtherPlayerInfoView = this;
            this.m_doc = ArtifactBagDocument.Doc;
            this.m_equipfusionDoc = EquipFusionDocument.Doc;
            (this.uiBehaviour.transform.FindChild("backclick").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClosePanel));
            (this.uiBehaviour.transform.FindChild("Bg/InfoPanel/backclick").GetComponent("XUIButton") as IXUIButton).RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClosePanel));
            this.m_InfoCheck.Clear();
            this.uiBehaviour.m_FunctionBtns.ReturnAll();
            string[] strArray = new string[8]
            {
        XStringDefineProxy.GetString("EQUIP"),
        XStringDefineProxy.GetString("SKILL"),
        XStringDefineProxy.GetString("FASHION"),
        XStringDefineProxy.GetString("EMBLEM"),
        XStringDefineProxy.GetString("CHAT_GUILD"),
        XStringDefineProxy.GetString("PET"),
        XStringDefineProxy.GetString("Sprite"),
        XStringDefineProxy.GetString("Artifact")
            };
            for (int index = 0; index < 8; ++index)
            {
                GameObject gameObject = this.uiBehaviour.m_FunctionBtns.FetchGameObject();
                gameObject.transform.localPosition = new Vector3(this.uiBehaviour.m_FunctionBtns.TplPos.x, this.uiBehaviour.m_FunctionBtns.TplPos.y - (float)(index * this.uiBehaviour.m_FunctionBtns.TplHeight), this.uiBehaviour.m_FunctionBtns.TplPos.z);
                IXUICheckBox component1 = gameObject.transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
                component1.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.ShowPlayerInfo));
                component1.ID = (ulong)(index + 1);
                this.m_InfoCheck.Add(component1);
                IXUILabel component2 = gameObject.transform.FindChild("name").GetComponent("XUILabel") as IXUILabel;
                IXUILabel component3 = gameObject.transform.FindChild("nameSelected").GetComponent("XUILabel") as IXUILabel;
                component2.SetText(strArray[index]);
                component3.SetText(strArray[index]);
            }
            for (int index = 0; index < XBagDocument.ArtifactMax; ++index)
                this.m_artifactQuanlityFx[index] = new ArtifactQuanlityFx();
            this.m_InfoDic[Player_Info.Avatar] = this.uiBehaviour.m_AvatarLayer;
            this.m_InfoDic[Player_Info.Equip] = this.uiBehaviour.m_EquipLayer;
            this.m_InfoDic[Player_Info.Emblem] = this.uiBehaviour.m_EmblemLayer;
            this.m_InfoDic[Player_Info.Guild] = this.uiBehaviour.m_GuildLayer;
            this.m_InfoDic[Player_Info.Pet] = this.uiBehaviour.m_PetLayer;
            this.m_InfoDic[Player_Info.Sprite] = this.uiBehaviour.m_SpriteLayer;
            this.m_InfoDic[Player_Info.Skill] = this.uiBehaviour.m_SkillLayer;
            this.m_InfoDic[Player_Info.Artifact] = this.uiBehaviour.m_artifactLayer;
            DlgHandlerBase.EnsureCreate<XPetSkillHandler>(ref this.m_SkillHandler, this.uiBehaviour.m_PetSkillFrame.gameObject);
            for (int index = 0; index < 4; ++index)
            {
                Transform parent = this.uiBehaviour.m_SpriteLayer.gameObject.transform.Find(string.Format("Avatar{0}", (object)index));
                DlgHandlerBase.EnsureCreate<XSpriteAvatarHandler>(ref this._SpriteAvatarHandler[index], parent, handlerMgr: ((IDlgHandlerMgr)this));
            }
            DlgHandlerBase.EnsureCreate<XCharacterAttrView<XAttrOtherFile>>(ref this.m_CharacterAttrHandler, this.uiBehaviour.m_EquipLayer.gameObject.transform.Find("AttrFrame"));
            DlgHandlerBase.EnsureCreate<XEmbleAttrView<XAttrOtherFile>>(ref this.m_EmbleAttrHandler, this.uiBehaviour.m_EmblemLayer.gameObject.transform.Find("AttrFrame"));
            DlgHandlerBase.EnsureCreate<XArtifactAttrView<XAttrOtherFile>>(ref this.m_artifactAttrHandler, this.uiBehaviour.m_artifactLayer.gameObject.transform.Find("AttrFrame"));
        }

        public override void RegisterEvent()
        {
        }

        protected override void OnShow()
        {
            base.OnShow();
            this.InitGuildInfo();
            this.InitEquipAndAvatar();
            this.Alloc3DAvatarPool(nameof(XOtherPlayerInfoView));
            this.SetSpriteAvatarHandlerVisible(true);
        }

        protected override void OnHide()
        {
            base.OnHide();
            this.Return3DAvatarPool();
            this._PlayerDummy = (XDummy)null;
            this.SetSpriteAvatarHandlerVisible(false);
            this.RestQuanlityFx();
            this.hasPetInfo = false;
        }

        private void SetSpriteAvatarHandlerVisible(bool visible)
        {
            for (int index = 0; index < this._SpriteAvatarHandler.Length; ++index)
            {
                this._SpriteAvatarHandler[index].SetVisible(visible);
                if (visible)
                    this._SpriteAvatarHandler[index].HideAvatar();
            }
        }

        protected override void OnUnload()
        {
            this.Return3DAvatarPool();
            this._doc = (XOtherPlayerInfoDocument)null;
            this.hasPetInfo = false;
            for (int index = 0; index < XBagDocument.ArtifactMax; ++index)
            {
                if (this.m_artifactQuanlityFx[index] != null)
                    this.m_artifactQuanlityFx[index].Reset();
            }
            for (int index = 0; index < 10; ++index)
            {
                if (this.m_fuseBreakFx[index] != null)
                {
                    this.m_fuseBreakFx[index].Reset();
                    this.m_fuseBreakFx[index] = (ArtifactQuanlityFx)null;
                }
            }
            DlgHandlerBase.EnsureUnload<XPetSkillHandler>(ref this.m_SkillHandler);
            for (int index = 0; index < this._SpriteAvatarHandler.Length; ++index)
                DlgHandlerBase.EnsureUnload<XSpriteAvatarHandler>(ref this._SpriteAvatarHandler[index]);
            DlgHandlerBase.EnsureUnload<XCharacterAttrView<XAttrOtherFile>>(ref this.m_CharacterAttrHandler);
            DlgHandlerBase.EnsureUnload<XEmbleAttrView<XAttrOtherFile>>(ref this.m_EmbleAttrHandler);
            DlgHandlerBase.EnsureUnload<XArtifactAttrView<XAttrOtherFile>>(ref this.m_artifactAttrHandler);
            base.OnUnload();
        }

        public override void StackRefresh()
        {
            base.StackRefresh();
            this.Alloc3DAvatarPool(nameof(XOtherPlayerInfoView));
        }

        public bool OnCloseClicked(IXUIButton sp)
        {
            this.SetVisible(false, true);
            return true;
        }

        public void SetPlayerInfo(
          ulong uid,
          string name,
          List<uint> setid,
          uint powerpoint = 0,
          uint profession = 1)
        {
            this.m_PlayerId = uid;
            this.m_PlayerName = name;
            this.m_setid = setid;
            this.m_PowerPoint = powerpoint;
            this.m_PlayerProfession = profession;
        }

        public void ShowMenuUI(
          ulong uid,
          string name,
          List<string> menuName,
          List<ButtonClickEventHandler> clickHandle,
          uint powerpoint = 0,
          uint profession = 1)
        {
            if (this.IsVisible() && (long)this.m_PlayerId == (long)uid)
                return;
            DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.OnAnimationOver)null);
            this.SetPlayerInfo(uid, name, new List<uint>(), powerpoint, profession);
            this.uiBehaviour.m_MenuPanel.SetVisible(true);
            this.uiBehaviour.m_InfoPanel.SetVisible(false);
            this.uiBehaviour.m_MenuPlayerName.SetText(name);
            this.uiBehaviour.m_MenuPool.ReturnAll();
            float x = this.uiBehaviour.m_MenuPool.TplPos.x;
            float y = this.uiBehaviour.m_MenuPool.TplPos.y;
            if (menuName.Count > 0)
                y += (float)((menuName.Count - 1) * this.uiBehaviour.m_MenuPool.TplHeight / 2);
            float z = this.uiBehaviour.m_MenuPool.TplPos.z;
            int num = this.uiBehaviour.m_MenuPool.TplHeight * menuName.Count + 10;
            for (int index = 0; index < menuName.Count; ++index)
            {
                GameObject gameObject = this.uiBehaviour.m_MenuPool.FetchGameObject();
                gameObject.transform.localPosition = new Vector3(x, y - (float)(this.uiBehaviour.m_MenuPool.TplHeight * index), z);
                IXUIButton component1 = gameObject.transform.FindChild("button").GetComponent("XUIButton") as IXUIButton;
                IXUILabel component2 = gameObject.transform.FindChild("button/name").GetComponent("XUILabel") as IXUILabel;
                component1.RegisterClickEventHandler(clickHandle[index]);
                component2.SetText(menuName[index]);
            }
            this.uiBehaviour.m_MenuPanel.spriteHeight = num;
        }

        public void InitMenuWithBasicInfo(ulong uid, string name, uint powerpoint = 0, uint professional = 1)
        {
            bool flag1 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(uid);
            bool flag2 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsBlock(uid);
            List<string> menuName = new List<string>();
            menuName.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_VIEW"));
            if (flag1)
                menuName.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_DELETEFRIEND"));
            else if (!flag2 && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Friends))
                menuName.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_ADDFRIEND"));
            if (!flag2)
            {
                menuName.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_PRIVATECHAT"));
                menuName.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_BLOCK"));
                menuName.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_SENDFLOWER"));
            }
            else
                menuName.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_UNBLOCK"));
            List<ButtonClickEventHandler> clickHandle = new List<ButtonClickEventHandler>();
            clickHandle.Add(new ButtonClickEventHandler(this.ShowDetailInfo));
            if (flag1)
                clickHandle.Add(new ButtonClickEventHandler(this.RemoveFriend));
            else if (!flag2 && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Friends))
                clickHandle.Add(new ButtonClickEventHandler(this.AddFriend));
            if (!flag2)
            {
                clickHandle.Add(new ButtonClickEventHandler(this.PrivateChat));
                clickHandle.Add(new ButtonClickEventHandler(this.Block));
                clickHandle.Add(new ButtonClickEventHandler(this.SendFlower));
            }
            else
                clickHandle.Add(new ButtonClickEventHandler(this.UnBlock));
            this.ShowMenuUI(uid, name, menuName, clickHandle, powerpoint, professional);
        }

        public void InitGuildMenu(ulong guildid, string guildname) => this.ShowMenuUI(guildid, guildname, new List<string>()
    {
      XStringDefineProxy.GetString("CHAT_LOOKUP_GUILD")
    }, new List<ButtonClickEventHandler>()
    {
      new ButtonClickEventHandler(DlgBase<XRankView, XRankBehaviour>.singleton.OnShowGuildInfo)
    });

        public void InitContentArea(Player_Info option, ulong param1 = 0, ulong param2 = 0)
        {
            float realtimeSinceStartup = Time.realtimeSinceStartup;
            if ((double)Mathf.Abs(realtimeSinceStartup - this._EclipsedTime) <= 0.1)
            {
                XSingleton<XDebug>.singleton.AddLog("Time too short");
            }
            else
            {
                this._EclipsedTime = realtimeSinceStartup;
                foreach (KeyValuePair<Player_Info, IXUISprite> keyValuePair in this.m_InfoDic)
                {
                    if (keyValuePair.Key == option)
                    {
                        keyValuePair.Value.SetVisible(true);
                        this.ShowOtherHandler(keyValuePair.Key);
                    }
                    else
                        keyValuePair.Value.SetVisible(false);
                }
                this.uiBehaviour.m_InfoPlayerName.SetText("Lv." + (object)this.m_PlayerLevel + " " + this.m_PlayerName);
                this.m_uiBehaviour.m_CurrentSnapshot = (IUIDummy)null;
                switch (option)
                {
                    case Player_Info.Equip:
                    case Player_Info.Avatar:
                        this.m_uiBehaviour.m_CurrentSnapshot = option == Player_Info.Avatar ? this.m_uiBehaviour.m_AvatarSnapshot : this.m_uiBehaviour.m_EquipSnapshot;
                        this.RequirePlayerInfo();
                        break;
                    case Player_Info.Skill:
                        this.SetupSkillFrame();
                        break;
                    case Player_Info.Emblem:
                        this.RefreshEmblemInfo(this._doc.m_Appearance);
                        break;
                    case Player_Info.Guild:
                        this.InitGuildInfo();
                        XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GetOtherGuildBriefNew()
                        {
                            oArg = {
                roleid = this.m_PlayerId
              }
                        });
                        break;
                    case Player_Info.Pet:
                        this.m_uiBehaviour.m_CurrentSnapshot = this.m_uiBehaviour.m_PetSnapshot;
                        this.RequirePetInfo(param1, param2);
                        break;
                    case Player_Info.Sprite:
                        for (int index = 0; index < 4; ++index)
                            this._SpriteAvatarHandler[index].HideAvatar();
                        this.uiBehaviour.m_SpriteLayer.gameObject.transform.Find("Empty").gameObject.SetActive(false);
                        this.RequireSpriteInfo();
                        break;
                    case Player_Info.Artifact:
                        this.RefreshArtifactInfo(this._doc.m_Appearance);
                        break;
                }
            }
        }

        private void ShowOtherHandler(Player_Info type)
        {
            switch (type)
            {
                case Player_Info.Emblem:
                    this.m_EmbleAttrHandler.SetBaseData(this._doc.GetOtherEmblemInfoList());
                    break;
                case Player_Info.Artifact:
                    this.m_artifactAttrHandler.SetBaseData(this._doc.GetOtherArtifactInfoList());
                    break;
            }
        }

        private void InitEquipAndAvatar()
        {
            for (int index = 0; index < 10; ++index)
                XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.uiBehaviour.transform.FindChild("Bg/InfoPanel/EquipLayer/EquipFrame/Part" + index.ToString()).gameObject, (ItemList.RowData)null);
            (this.uiBehaviour.transform.FindChild("Bg/InfoPanel/EquipLayer/CharacterInfoFrame/CharacterFrame/PowerPoint").GetComponent("XUILabel") as IXUILabel).SetText("0");
            this.uiBehaviour.m_InfoPlayerName.SetText("");
            for (int index = 0; index < 10; ++index)
                XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.uiBehaviour.transform.FindChild("Bg/InfoPanel/AvatarLayer/EquipFrame/Part" + (11 + index).ToString()).gameObject, (ItemList.RowData)null);
            for (int index = 0; index < 16; ++index)
            {
                GameObject go = this.uiBehaviour.m_EmblemBg[index];
                XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(go, (ItemList.RowData)null);
                go.SetActive(true);
            }
        }

        public XAttributes GetAttrByUnitAppearance(UnitAppearance data) => XSingleton<XAttributeMgr>.singleton.InitAttrFromServer(data.uID, data.nickid, data.unitType, data.unitName, data.attributes, data.fightgroup, data.isServerControl, data.skills, data.bindskills, new XOutLookAttr(data.outlook), data.level);

        private void _FillCharacterInfoFrame(UnitAppearance data)
        {
            if (!this.IsVisible())
                return;
            this._FillInitEquip(data);
            this._FillInitInfos(data);
            this._FillInitAvatar(data);
            this.RefreshEmblemInfo(data);
            this._FillRoleDummy(data);
            this._FillInitSkillData(data);
            this.RefreshArtifactInfo(data);
        }

        private void _FillInitEquip(UnitAppearance data)
        {
            foreach (XDataBase xdataBase in this.m_ItemDic.Values)
                xdataBase.Recycle();
            this.m_ItemDic.Clear();
            for (int index = 0; index < 10 && index < data.equip.Count; ++index)
            {
                XItem xitem = XBagDocument.MakeXItem(data.equip[index]);
                this.m_EquipBag[index] = xitem;
                this.m_ItemDic[xitem.itemID] = xitem;
                GameObject gameObject = this.uiBehaviour.transform.FindChild("Bg/InfoPanel/EquipLayer/EquipFrame/Part" + index.ToString()).gameObject;
                IXUISprite component = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
                if (xitem != null && xitem.itemID > 0)
                {
                    component.ID = (ulong)xitem.itemID;
                    component.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemBg));
                    XEquipItem xequipItem = xitem as XEquipItem;
                    this.SetEquipEffect(gameObject, xequipItem.fuseInfo.BreakNum, index);
                }
                else
                    this.SetEquipEffect(gameObject, 0U, index);
                XItemDrawerMgr.Param.bHideBinding = true;
                XItemDrawerMgr.Param.Profession = data.unitType % 10U;
                XSingleton<XItemDrawerMgr>.singleton.DrawItem(gameObject, xitem);
            }
            if (data.equip.Count <= 10)
                return;
            for (int count = data.equip.Count; count < 10; ++count)
                this.SetEquipEffect(this.uiBehaviour.transform.FindChild("Bg/InfoPanel/EquipLayer/EquipFrame/Part" + count.ToString()).gameObject, 0U, count);
        }

        private void SetEquipEffect(GameObject go, uint breakLevel, int slot)
        {
            if (slot >= this.m_fuseBreakFx.Length || (UnityEngine.Object)go == (UnityEngine.Object)null)
                return;
            ArtifactQuanlityFx artifactQuanlityFx = this.m_fuseBreakFx[slot];
            if (artifactQuanlityFx == null)
            {
                artifactQuanlityFx = new ArtifactQuanlityFx();
                this.m_fuseBreakFx[slot] = artifactQuanlityFx;
            }
            string path;
            if (!this.m_equipfusionDoc.GetEffectPath(breakLevel, out path))
            {
                artifactQuanlityFx.Reset();
            }
            else
            {
                if (artifactQuanlityFx.IsCanReuse((ulong)breakLevel))
                    return;
                artifactQuanlityFx.SetData((ulong)breakLevel, go.transform.FindChild("Icon/Icon/Effects"), path);
            }
        }

        private void RestQuanlityFx()
        {
            for (int index = 0; index < 10; ++index)
            {
                if (this.m_fuseBreakFx[index] != null)
                    this.m_fuseBreakFx[index].Reset();
            }
        }

        private void _FillInitInfos(UnitAppearance data)
        {
            this.m_PlayerProfession = data.unitType;
            (this.uiBehaviour.transform.FindChild("Bg/InfoPanel/EquipLayer/CharacterInfoFrame/CharacterFrame/PowerPoint").GetComponent("XUILabel") as IXUILabel).SetText(data.PowerPoint.ToString());
            this.m_PlayerLevel = data.level;
            this.uiBehaviour.m_InfoPlayerName.SetText("Lv." + (object)this.m_PlayerLevel + " " + this.m_PlayerName);
            (this.uiBehaviour.transform.FindChild("Bg/InfoPanel/AvatarLayer/CharacterInfoFrame/CharacterFrame/PowerPoint").GetComponent("XUILabel") as IXUILabel).SetText(data.PowerPoint.ToString());
            this.m_Attributes = this.GetAttrByUnitAppearance(data);
            this.m_CharacterAttrHandler.SetAttributes(this.m_Attributes);
        }

        private void _FillInitAvatar(UnitAppearance data)
        {
            int index1 = 0;
            for (int length = this.allParts.Length; index1 < length; ++index1)
                this.allParts[index1] = 0U;
            if (data.outlook != null && data.outlook.display_fashion != null)
            {
                int index2 = 0;
                for (int count = data.outlook.display_fashion.display_fashions.Count; index2 < count; ++index2)
                {
                    uint displayFashion = data.outlook.display_fashion.display_fashions[index2];
                    FashionList.RowData fashionConf = XBagDocument.GetFashionConf((int)displayFashion);
                    if (fashionConf != null && (int)fashionConf.EquipPos < this.allParts.Length)
                        this.allParts[(int)fashionConf.EquipPos] = displayFashion;
                }
            }
            for (int index3 = 0; index3 < 10 && index3 < this.allParts.Length; ++index3)
            {
                uint allPart = this.allParts[index3];
                GameObject gameObject = this.uiBehaviour.transform.FindChild("Bg/InfoPanel/AvatarLayer/EquipFrame/Part" + (11 + index3).ToString()).gameObject;
                IXUISprite component = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
                component.ID = (ulong)allPart;
                component.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickOutLookBg));
                XItemDrawerMgr.Param.bHideBinding = true;
                XItemDrawerMgr.Param.Profession = data.unitType % 10U;
                XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)allPart);
            }
        }

        private void OnClickOutLookBg(IXUISprite sprite)
        {
            int id = (int)sprite.ID;
            if (id == 0)
                return;
            XSingleton<UiUtility>.singleton.ShowTooltipDialog(id, profession: (this.m_PlayerProfession % 10U));
        }

        private void _FillInitSkillData(UnitAppearance data)
        {
            this._bindsSkills.Clear();
            this._skillLevel.Clear();
            for (int index = 0; index < data.bindskills.Count; ++index)
                this._bindsSkills.Add(data.bindskills[index]);
            for (int index = 0; index < data.skills.Count; ++index)
                this._skillLevel[data.skills[index].skillHash] = data.skills[index].skillLevel;
        }

        private void _FillRoleDummy(UnitAppearance data)
        {
            if (data.uID <= 0UL)
                return;
            this._PlayerDummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonRoleDummy(this.m_dummPool, data.uID, data.unitType, data.outlook, this.m_uiBehaviour.m_CurrentSnapshot, this._PlayerDummy);
        }

        private void RefreshEmblemInfo(UnitAppearance data)
        {
            if (data == null)
                return;
            for (int index = 0; index < 16; ++index)
            {
                GameObject go = this.uiBehaviour.m_EmblemBg[index];
                if (data.emblem.Count > index)
                {
                    Item KKSGItem = data.emblem[index];
                    if (KKSGItem.ItemID > 0U)
                    {
                        XItem xitem = XBagDocument.MakeXItem(KKSGItem);
                        this.m_ItemDic[xitem.itemID] = xitem;
                        XItemDrawerMgr.Param.bHideBinding = true;
                        XItemDrawerMgr.Param.Profession = data.unitType % 10U;
                        XSingleton<XItemDrawerMgr>.singleton.DrawItem(go, xitem);
                        go.SetActive(true);
                        IXUISprite component = go.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
                        if (xitem != null)
                        {
                            component.ID = (ulong)xitem.itemID;
                            component.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemBg));
                        }
                    }
                    else
                        go.SetActive(false);
                }
                else
                    go.SetActive(false);
            }
        }

        private void RefreshArtifactInfo(UnitAppearance data)
        {
            if (data == null)
                return;
            for (int index = 0; index < 4; ++index)
            {
                GameObject go = this.uiBehaviour.m_artifactGo[index];
                if (data.artifact.Count > index)
                {
                    Item KKSGItem = data.artifact[index];
                    XItem xitem = XBagDocument.MakeXItem(KKSGItem);
                    this.m_artifactBag[index] = xitem;
                    if (KKSGItem.ItemID > 0U)
                    {
                        this.m_ItemDic[xitem.itemID] = xitem;
                        XItemDrawerMgr.Param.bHideBinding = true;
                        XSingleton<XItemDrawerMgr>.singleton.DrawItem(go, xitem);
                        if (xitem != null && xitem.itemConf != null)
                            this.SetArtifactEffect(go, xitem.itemID, index);
                        go.SetActive(true);
                        go.transform.FindChild("Icon/RedPoint").gameObject.SetActive(false);
                        IXUISprite component = go.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
                        if (xitem != null)
                        {
                            component.ID = (ulong)xitem.itemID;
                            component.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemBg));
                        }
                    }
                    else
                        go.SetActive(false);
                }
                else
                    go.SetActive(false);
            }
        }

        private void SetArtifactEffect(GameObject go, int itemId, int slot)
        {
            if (slot >= this.m_artifactQuanlityFx.Length || (UnityEngine.Object)go == (UnityEngine.Object)null)
                return;
            ItemList.RowData itemConf = XBagDocument.GetItemConf(itemId);
            if (itemConf == null)
                return;
            ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)itemId);
            if (artifactListRowData == null)
                return;
            ArtifactQuanlityFx artifactQuanlityFx = this.m_artifactQuanlityFx[slot];
            if (artifactQuanlityFx == null)
            {
                artifactQuanlityFx = new ArtifactQuanlityFx();
                this.m_artifactQuanlityFx[slot] = artifactQuanlityFx;
            }
            ulong key = this.m_doc.MakeKey((uint)itemConf.ItemQuality, artifactListRowData.AttrType);
            string path;
            if (!this.m_doc.GetArtifactEffectPath(key, out path))
            {
                artifactQuanlityFx.Reset();
            }
            else
            {
                if (artifactQuanlityFx.IsCanReuse(key))
                    return;
                artifactQuanlityFx.SetData(key, go.transform.FindChild("Icon/Icon/Effects"), path);
            }
        }

        public void InitGuildInfo()
        {
            this.uiBehaviour.m_GuildLogo.SetSprite("");
            this.uiBehaviour.m_GuildName.SetText("");
            this.uiBehaviour.m_GuildMasterName.SetText("");
            this.uiBehaviour.m_GuildLevel.SetText("0");
            this.uiBehaviour.m_GuildNumber.SetText("0/0");
            this.uiBehaviour.m_GuildContent.SetText("");
            this.uiBehaviour.m_GuildLogo.SetVisible(false);
        }

        public void RefreshGuildInfo(GetOtherGuildBriefRes res)
        {
            if (res.icon == 0U)
            {
                this.uiBehaviour.m_GuildLogo.SetSprite("");
                this.uiBehaviour.m_GuildLogo.SetVisible(false);
            }
            else
            {
                this.uiBehaviour.m_GuildLogo.SetSprite(XGuildDocument.GetPortraitName((int)res.icon));
                this.uiBehaviour.m_GuildLogo.SetVisible(true);
            }
            this.uiBehaviour.m_GuildName.SetText(res.guildname);
            this.uiBehaviour.m_GuildMasterName.SetText(res.leadername);
            IXUILabel guildLevel = this.uiBehaviour.m_GuildLevel;
            uint num = res.guildlevel;
            string strText1 = num.ToString();
            guildLevel.SetText(strText1);
            IXUILabel guildNumber = this.uiBehaviour.m_GuildNumber;
            num = res.currentcount;
            string str1 = num.ToString();
            num = res.allcount;
            string str2 = num.ToString();
            string strText2 = str1 + "/" + str2;
            guildNumber.SetText(strText2);
            this.uiBehaviour.m_GuildContent.SetText(res.announcement);
        }

        public void RefreshPetInfo(UnitAppearance data)
        {
            if (!this.IsVisible() || (UnityEngine.Object)this.uiBehaviour == (UnityEngine.Object)null || this.uiBehaviour.m_PetLayer == null || !this.uiBehaviour.m_PetLayer.IsVisible())
                return;
            this.m_PlayerLevel = data.level;
            if (this.uiBehaviour.m_InfoPlayerName != null)
                this.uiBehaviour.m_InfoPlayerName.SetText("Lv." + (object)this.m_PlayerLevel + " " + this.m_PlayerName);
            if (data.pet == null)
            {
                if ((UnityEngine.Object)this.uiBehaviour.m_PetInfo != (UnityEngine.Object)null)
                    this.uiBehaviour.m_PetInfo.gameObject.SetActive(false);
                if (!((UnityEngine.Object)this.uiBehaviour.m_PetEmpty != (UnityEngine.Object)null))
                    return;
                this.uiBehaviour.m_PetEmpty.gameObject.SetActive(true);
            }
            else
            {
                XPet pet = new XPet();
                pet.Init(data.pet);
                if ((UnityEngine.Object)this.uiBehaviour.m_PetInfo != (UnityEngine.Object)null)
                    this.uiBehaviour.m_PetInfo.gameObject.SetActive(true);
                if ((UnityEngine.Object)this.uiBehaviour.m_PetEmpty != (UnityEngine.Object)null)
                    this.uiBehaviour.m_PetEmpty.gameObject.SetActive(false);
                this.m_SkillHandler.Refresh(pet);
                this.RefreshPetDummy(pet.ID);
                this.RefreshAttribute(pet);
            }
        }

        private void RefreshAttribute(XPet pet)
        {
            if (pet == null)
                return;
            PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(pet.ID);
            BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)petInfo.SpeedBuff, 1);
            if (buffData == null || 1201 != (int)buffData.BuffChangeAttribute[0, 0])
                XSingleton<XDebug>.singleton.AddErrorLog("Buff No Find XAttr_RUN_SPEED_Percent.\nSp BuffId:" + (object)petInfo.SpeedBuff);
            else
                this.uiBehaviour.m_SpeedUp.SetText(string.Format("{0}%", (object)(buffData.BuffChangeAttribute[0, 1] + 100f).ToString()));
            DlgBase<XPetMainView, XPetMainBehaviour>.singleton.SetPetSex(this.uiBehaviour.m_PetSex, pet.Sex);
            this.uiBehaviour.m_PetName.SetText(pet.Name);
            this.uiBehaviour.m_PetPPT.SetText(pet.PPT.ToString());
            this.uiBehaviour.m_PetLevel.SetText(string.Format("(Lv.{0})", (object)pet.showLevel.ToString()));
            PetLevelTable.RowData petLevel1 = XPetDocument.GetPetLevel(pet);
            PetLevelTable.RowData petLevel2 = XPetDocument.GetPetLevel(pet.ID, pet.Level + 1);
            this.uiBehaviour.m_AttributePool.ReturnAll();
            for (int index = 0; (long)index < (long)XPetMainView.ATTRIBUTE_NUM_MAX; ++index)
            {
                if (index < petLevel1.PetsAttributes.Count)
                {
                    GameObject gameObject = this.uiBehaviour.m_AttributePool.FetchGameObject();
                    int spriteHeight = (gameObject.transform.GetComponent("XUISprite") as IXUISprite).spriteHeight;
                    IXUILabel component1 = gameObject.transform.Find("AttributeName").GetComponent("XUILabel") as IXUILabel;
                    IXUILabel component2 = gameObject.transform.Find("AttributeName/AttributeVal").GetComponent("XUILabel") as IXUILabel;
                    IXUILabel component3 = gameObject.transform.Find("AttributeName/GrowUp").GetComponent("XUILabel") as IXUILabel;
                    gameObject.transform.localPosition = new Vector3(0.0f, (float)(-spriteHeight * index), 0.0f);
                    string attrStr = XAttributeCommon.GetAttrStr((int)petLevel1.PetsAttributes[index, 0]);
                    component1.SetText(attrStr);
                    uint attrValue = 0;
                    for (int level = 1; level <= pet.Level; ++level)
                    {
                        PetLevelTable.RowData petLevel3 = XPetDocument.GetPetLevel(pet.ID, level);
                        attrValue += petLevel3.PetsAttributes[index, 1];
                    }
                    component2.SetText(XAttributeCommon.GetAttrValueStr(petLevel1.PetsAttributes[index, 0], attrValue, false));
                    if (petLevel2 != null)
                        component3.SetText(string.Format("+{0}", (object)petLevel2.PetsAttributes[index, 1].ToString()));
                    else
                        component3.SetText("");
                }
            }
        }

        public void RefreshPetDummy(uint petID)
        {
            if (petID > 0U)
                this.lastPetID = petID;
            this._PlayerDummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, XPetDocument.GetPresentID(this.lastPetID), this.m_uiBehaviour.m_CurrentSnapshot, this._PlayerDummy);
            DlgBase<XPetMainView, XPetMainBehaviour>.singleton.PetActionChange(XPetActionFile.IDLE, this.lastPetID, this._PlayerDummy);
        }

        public void RefreshPlayerInfo(UnitAppearance data) => this._FillCharacterInfoFrame(data);

        public void RefreshSpriteInfo(uint level, List<SpriteInfo> list, UnitAppearance data)
        {
            if (!this.IsVisible() || !this.uiBehaviour.m_SpriteLayer.IsVisible())
                return;
            this.m_PlayerLevel = level;
            this.uiBehaviour.m_InfoPlayerName.SetText("Lv." + (object)this.m_PlayerLevel + " " + this.m_PlayerName);
            if (list.Count != 4)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Get OtherPlayerInfo 's SpriteInfo 's cout is not 4.");
            }
            else
            {
                bool flag = false;
                for (int index = 0; index < 4; ++index)
                {
                    if (list[index] == null || list[index].SpriteID == 0U)
                    {
                        this._SpriteAvatarHandler[index].SetSpriteInfo((SpriteInfo)null, (XAttributes)null, 0);
                        this._SpriteAvatarHandler[index].HideAvatar();
                    }
                    else
                    {
                        flag = true;
                        XAttributes byUnitAppearance = this.GetAttrByUnitAppearance(data);
                        this._SpriteAvatarHandler[index].SetSpriteInfo(list[index], byUnitAppearance, index + 7, true);
                    }
                }
                this.uiBehaviour.m_SpriteLayer.gameObject.transform.Find("Empty").gameObject.SetActive(!flag);
            }
        }

        public void ShowTab(Player_Info type, ulong param1 = 0, ulong param2 = 0)
        {
            this.uiBehaviour.m_MenuPanel.SetVisible(false);
            this.uiBehaviour.m_InfoPanel.SetVisible(true);
            int index = XFastEnumIntEqualityComparer<Player_Info>.ToInt(type) - 1;
            if (index >= this.m_InfoCheck.Count)
                return;
            this.m_InfoCheck[index].bChecked = true;
            this.InitContentArea(type, param1, param2);
        }

        public bool ShowDetailInfo(IXUIButton sp)
        {
            this.ShowTab(Player_Info.Equip);
            return true;
        }

        public bool AddFriend(IXUIButton sp)
        {
            this.uiBehaviour.m_MenuPanel.SetVisible(false);
            DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, (DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.OnAnimationOver)null);
            DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(this.m_PlayerId);
            return true;
        }

        public bool RemoveFriend(IXUIButton sp)
        {
            this.uiBehaviour.m_MenuPanel.SetVisible(false);
            DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, (DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.OnAnimationOver)null);
            DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RemoveFriend(this.m_PlayerId);
            return true;
        }

        public bool SendFlower(IXUIButton sp)
        {
            this.uiBehaviour.m_MenuPanel.SetVisible(false);
            DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, (DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.OnAnimationOver)null);
            DlgBase<XFlowerSendView, XFlowerSendBehaviour>.singleton.ShowBoard(this.m_PlayerId, this.m_PlayerName);
            return true;
        }

        public bool PrivateChat(IXUIButton sp)
        {
            if (sp != null)
            {
                this.uiBehaviour.m_MenuPanel.SetVisible(false);
                DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, (DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.OnAnimationOver)null);
            }
            if (DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsBlock(this.m_PlayerId))
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_BLOCK_2"), "fece00");
            }
            else
            {
                ChatFriendData data = new ChatFriendData();
                data.name = this.m_PlayerName;
                data.roleid = this.m_PlayerId;
                data.powerpoint = this.m_PowerPoint;
                data.profession = this.m_PlayerProfession;
                data.isfriend = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(this.m_PlayerId);
                data.msgtime = DateTime.Now;
                data.viplevel = 0U;
                data.setid = this.m_setid;
                XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(this.m_PlayerId);
                if (entity != null)
                {
                    XRoleAttributes attributes = (XRoleAttributes)entity.Attributes;
                    data.profession = (uint)attributes.Profession;
                }
                DlgBase<XChatView, XChatBehaviour>.singleton.PrivateChatTo(data);
            }
            return true;
        }

        public void OnClickItemBg(IXUISprite sp)
        {
            int id = (int)sp.ID;
            XItem mainItem = (XItem)null;
            this.m_ItemDic.TryGetValue(id, out mainItem);
            if (mainItem == null)
                return;
            switch (mainItem.Type)
            {
                case ItemType.EQUIP:
                    XSingleton<TooltipParam>.singleton.BodyBag = this.m_EquipBag;
                    break;
                case ItemType.FASHION:
                    XSingleton<TooltipParam>.singleton.FashionOnBody = this.m_FashionBag;
                    break;
                case ItemType.ARTIFACT:
                    XSingleton<TooltipParam>.singleton.BodyBag = this.m_artifactBag;
                    break;
            }
            XSingleton<TooltipParam>.singleton.mainAttributes = this.m_Attributes;
            XSingleton<UiUtility>.singleton.ShowTooltipDialog(mainItem, (XItem)null, sp, false, this.m_PlayerProfession % 10U);
        }

        public bool Block(IXUIButton sp)
        {
            this.uiBehaviour.m_MenuPanel.SetVisible(false);
            DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddBlockFriend(this.m_PlayerId);
            DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, (DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.OnAnimationOver)null);
            return true;
        }

        public bool UnBlock(IXUIButton sp)
        {
            this.uiBehaviour.m_MenuPanel.SetVisible(false);
            DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RemoveBlockFriend(this.m_PlayerId);
            DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, (DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.OnAnimationOver)null);
            return true;
        }

        public void RequirePlayerInfo()
        {
            if (this.m_PlayerId == 0UL)
                return;
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GetUnitAppearanceNew()
            {
                oArg = {
          roleid = this.m_PlayerId,
          mask = 558063,
          type = 2U
        }
            });
        }

        public void RequireSpriteInfo()
        {
            if (this.m_PlayerId == 0UL)
                return;
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GetUnitAppearanceNew()
            {
                oArg = {
          roleid = this.m_PlayerId,
          mask = 17335023,
          type = 5U
        }
            });
        }

        public void RequirePetInfo(ulong playerId, ulong petUID)
        {
            if (this.m_PlayerId == 0UL)
                return;
            if (this.hasPetInfo)
            {
                this.RefreshPetDummy(0U);
            }
            else
            {
                this.hasPetInfo = true;
                if (playerId == 0UL)
                    playerId = this.m_PlayerId;
                XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GetUnitAppearanceNew()
                {
                    oArg = {
            roleid = playerId,
            mask = XFastEnumIntEqualityComparer<UnitAppearanceField>.ToInt(UnitAppearanceField.UNIT_PETS),
            type = 6U,
            petId = petUID
          }
                });
            }
        }

        public bool ShowPlayerInfo(IXUICheckBox iXUICheckBox)
        {
            Player_Info id = (Player_Info)iXUICheckBox.ID;
            if (iXUICheckBox.bChecked)
                this.InitContentArea(id);
            return true;
        }

        public bool ClickClosePanel(IXUIButton sp)
        {
            this.SetPlayerInfo(0UL, "", new List<uint>());
            this.SetVisible(false, true);
            return true;
        }

        private void SetupSkillFrame()
        {
            int num1 = 10;
            IXUICheckBox xuiCheckBox = (IXUICheckBox)null;
            this.uiBehaviour.m_SkillTabs.ReturnAll();
            Vector3 tplPos = this.uiBehaviour.m_SkillTabs.TplPos;
            int num2 = 0;
            int playerProfession = (int)this.m_PlayerProfession;
            while ((uint)playerProfession > 0U)
            {
                playerProfession /= 10;
                ++num2;
            }
            for (int index = 0; index < num2; ++index)
            {
                int profID = (int)this.m_PlayerProfession % num1;
                GameObject gameObject = this.uiBehaviour.m_SkillTabs.FetchGameObject();
                gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(index * this.uiBehaviour.m_SkillTabs.TplHeight));
                (gameObject.transform.Find("TextLabel").GetComponent("XUILabel") as IXUILabel).SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName(profID));
                (gameObject.transform.Find("SelectedTextLabel").GetComponent("XUILabel") as IXUILabel).SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName(profID));
                IXUICheckBox component = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
                component.ForceSetFlag(false);
                component.ID = (ulong)index;
                component.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSkillTabsClick));
                if (index == 0)
                    xuiCheckBox = component;
                num1 *= 10;
            }
            xuiCheckBox.bChecked = true;
            this.SetupSkillTree(0);
        }

        private bool OnSkillTabsClick(IXUICheckBox icb)
        {
            if (!icb.bChecked)
                return true;
            this.SetupSkillTree((int)icb.ID);
            return true;
        }

        private void SetupSkillTree(int promote)
        {
            this.uiBehaviour.m_SkillScrollView.SetPosition(0.0f);
            this.uiBehaviour.m_Skills.ReturnAll();
            this.uiBehaviour.m_SkillArrow.ReturnAll();
            int num1 = 10;
            for (int index = 0; index < promote; ++index)
                num1 *= 10;
            List<uint> profSkillId = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID((int)this.m_PlayerProfession % num1);
            int num2 = 0;
            for (int index = 0; index < profSkillId.Count; ++index)
            {
                GameObject go = this.uiBehaviour.m_Skills.FetchGameObject();
                go.name = string.Format("Skill{0}", (object)++num2);
                this.SetupSkill(go, profSkillId[index]);
            }
        }

        private void SetupSkill(GameObject go, uint skillID)
        {
            uint skillLevel = 0;
            this._skillLevel.TryGetValue(skillID, out skillLevel);
            SkillList.RowData skillConfig1 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillID, skillLevel);
            SkillList.RowData skillConfig2 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(XSingleton<XSkillEffectMgr>.singleton.GetSkillID(skillConfig1.PreSkill), 0U);
            int skillMaxLevel = XSingleton<XSkillEffectMgr>.singleton.GetSkillMaxLevel(skillID);
            SkillTypeEnum skillType = (SkillTypeEnum)skillConfig1.SkillType;
            IXUISprite component1 = go.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
            IXUISprite component2 = go.transform.Find("Icon/P").GetComponent("XUISprite") as IXUISprite;
            IXUILabel component3 = go.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
            (go.transform.FindChild("Tip").GetComponent("XUISprite") as IXUISprite).SetVisible(this._bindsSkills.Contains(skillID));
            go.transform.localPosition = new Vector3(this.uiBehaviour.m_Skills.TplPos.x + (float)(((int)skillConfig1.XPostion - 1) * this.uiBehaviour.m_Skills.TplWidth), (float)skillConfig1.YPostion);
            component1.SetSprite(skillConfig1.Icon, skillConfig1.Atlas);
            component3.SetText(skillLevel.ToString() + "/" + (object)skillMaxLevel);
            switch (skillType)
            {
                case SkillTypeEnum.Skill_Big:
                    component2.SetSprite("JN_dk_0");
                    break;
                case SkillTypeEnum.Skill_Buff:
                    component2.SetSprite("JN_dk_buff");
                    break;
                default:
                    component2.SetSprite("JN_dk");
                    break;
            }
            if (skillConfig2 != null)
            {
                Vector3 localPosition = go.transform.localPosition;
                Vector3 vector3_1 = new Vector3(this.uiBehaviour.m_Skills.TplPos.x + (float)(((int)skillConfig2.XPostion - 1) * this.uiBehaviour.m_Skills.TplWidth), (float)skillConfig2.YPostion);
                Vector3 vector3_2 = (localPosition + vector3_1) / 2f;
                GameObject gameObject = this.uiBehaviour.m_SkillArrow.FetchGameObject();
                IXUISprite component4 = gameObject.GetComponent("XUISprite") as IXUISprite;
                if ((int)skillConfig1.XPostion == (int)skillConfig2.XPostion || (int)skillConfig1.YPostion == (int)skillConfig2.YPostion)
                {
                    if ((int)skillConfig1.XPostion == (int)skillConfig2.XPostion)
                    {
                        component4.SetSprite("SkillTree_3");
                        component4.spriteHeight = (int)((double)((int)skillConfig2.YPostion - (int)skillConfig1.YPostion) - (double)component1.spriteHeight * 1.5);
                        component4.spriteWidth = this.uiBehaviour.m_SkillArrow.TplWidth;
                        gameObject.transform.localPosition = vector3_2;
                        gameObject.transform.localScale = new Vector3(1f, 1f);
                        gameObject.transform.localRotation = Quaternion.identity;
                    }
                    else
                    {
                        component4.SetSprite("SkillTree_3");
                        int num = (int)skillConfig1.XPostion < (int)skillConfig2.XPostion ? 1 : -1;
                        component4.spriteHeight = (int)((double)(((int)skillConfig2.XPostion - (int)skillConfig1.XPostion) * (num * this.uiBehaviour.m_Skills.TplWidth)) - (double)component1.spriteWidth * 1.5);
                        component4.spriteWidth = this.uiBehaviour.m_SkillArrow.TplWidth;
                        gameObject.transform.localPosition = vector3_2;
                        gameObject.transform.localScale = new Vector3(1f, 1f);
                        gameObject.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, (float)(-num * 90));
                    }
                }
                else
                {
                    component4.SetSprite("SkillTree_4");
                    component4.spriteHeight = (int)Math.Abs(localPosition.y - vector3_1.y) - component1.spriteHeight / 2;
                    component4.spriteWidth = (int)Math.Abs(localPosition.x - vector3_1.x) - component1.spriteWidth / 2;
                    int num = (int)skillConfig1.XPostion < (int)skillConfig2.XPostion ? 1 : -1;
                    gameObject.transform.localPosition = vector3_2 + new Vector3((float)(component1.spriteWidth / 2 * -num), (float)(component1.spriteHeight / 2));
                    gameObject.transform.localScale = new Vector3((float)num, 1f);
                    gameObject.transform.localRotation = Quaternion.identity;
                }
            }
            component1.SetEnabled(skillLevel > 0U);
            component2.SetEnabled(skillLevel > 0U);
        }
    }
}
