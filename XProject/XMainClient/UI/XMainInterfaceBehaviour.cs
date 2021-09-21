using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200190A RID: 6410
	internal class XMainInterfaceBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010C1E RID: 68638 RVA: 0x00432504 File Offset: 0x00430704
		private void Awake()
		{
			this.m_Canvas = base.transform.FindChild("_canvas");
			Transform transform = base.transform.FindChild("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH1");
			this.m_SysListH1 = (transform.GetComponent("XUIList") as IXUIList);
			this.m_SysListH1Tween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			transform = base.transform.FindChild("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH0");
			this.m_SysListH0 = (transform.GetComponent("XUIList") as IXUIList);
			this.m_SysListH0Tween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			transform = base.transform.FindChild("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridGuildH1");
			this.m_SysListH2 = (transform.GetComponent("XUIList") as IXUIList);
			this.m_SysListH2Tween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			transform = base.transform.FindChild("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH3");
			this.m_SysListH3 = (transform.GetComponent("XUIList") as IXUIList);
			this.m_SysListH3Tween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			transform = base.transform.FindChild("_canvas/MainMenuFrame/MainMenu/MenuSwitchBtn");
			this.m_MenuSwitchBtn = (transform.GetComponent("XUISprite") as IXUISprite);
			this.m_MenuSwitchBtnTween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			transform = base.transform.FindChild("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridGuildH1");
			this.m_SysListGuildH1 = (transform.GetComponent("XUIList") as IXUIList);
			transform = base.transform.FindChild("_canvas/MainMenuFrame/MainMenu/Panel2/SysGridGuildV1");
			this.m_SysListGuildV1 = (transform.GetComponent("XUIList") as IXUIList);
			transform = base.transform.FindChild("_canvas/SecondMenuFrame/SysGridGuildH2");
			this.m_SysListGuildH2 = (transform.GetComponent("XUIList") as IXUIList);
			transform = base.transform.FindChild("_canvas/MainMenuFrame/MainMenu/Panel2/SysGridV1");
			this.m_SysListV1 = (transform.GetComponent("XUIList") as IXUIList);
			transform = base.transform.FindChild("_canvas/SecondMenuFrame/SecondMenu/SysGridV2");
			this.m_SysListV2 = (transform.GetComponent("XUIList") as IXUIList);
			transform = base.transform.FindChild("_canvas/MainMenuFrame/MainMenu/Panel5/SysGridV3");
			this.m_SysListV3 = (transform.GetComponent("XUIList") as IXUIList);
			transform = base.transform.FindChild("_canvas/MainMenuFrame/MainMenu/Panel5/V3SwitchBtn");
			this.m_V3SwitchBtn = (transform.GetComponent("XUISprite") as IXUISprite);
			this.m_V3SwitchTween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			transform = base.transform.FindChild("_canvas/MainMenuFrame/MainMenu/Panel5/SysGridV3");
			this.m_V3ListTween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			transform = base.transform.FindChild("_canvas/SecondMenuFrame/SecondMenu/H2SwitchBtn");
			this.m_H2SwitchBtn = (transform.GetComponent("XUISprite") as IXUISprite);
			this.m_H2SwitchTween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			transform = base.transform.FindChild("_canvas/SecondMenuFrame/SecondMenu/H2");
			this.m_H2ListTween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			transform = base.transform.FindChild("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_1");
			this.m_SysListH2_1 = (transform.GetComponent("XUIList") as IXUIList);
			transform = base.transform.FindChild("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_2");
			this.m_SysListH2_2 = (transform.GetComponent("XUIList") as IXUIList);
			transform = base.transform.FindChild("_canvas/MainMenuFrame/MainMenu");
			this.m_MainMenuGo = transform.gameObject;
			this.m_SecondMenu = base.transform.FindChild("_canvas/SecondMenuFrame/SecondMenu").gameObject;
			transform = base.transform.FindChild("_canvas/ThirdMenuFrame/ThirdMenu");
			this.m_ExitGuild = (base.transform.FindChild("_canvas/SecondMenuFrame/BtnExitGuild").GetComponent("XUIButton") as IXUIButton);
			this.m_RecoverTime = (base.transform.FindChild("_canvas/RecoverTime").GetComponent("XUISprite") as IXUISprite);
			List<string> list = new List<string>();
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH1/SysAItem");
			this.m_ListSys.Add(XSysDefine.XSys_Item);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH1/SysBSkill");
			this.m_ListSys.Add(XSysDefine.XSys_Skill);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH1/SysCSprite");
			this.m_ListSys.Add(XSysDefine.XSys_SpriteSystem);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH1/SysDEquipCreate");
			this.m_ListSys.Add(XSysDefine.XSys_EquipCreate);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH1/SysEHorse");
			this.m_ListSys.Add(XSysDefine.XSys_Horse);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH0/SysA_Friends");
			this.m_ListSys.Add(XSysDefine.XSys_Friends);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH0/SysB_Home");
			this.m_ListSys.Add(XSysDefine.XSys_Home);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH0/SysC_Rank");
			this.m_ListSys.Add(XSysDefine.XSys_Rank);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH0/SysD_CardCollect");
			this.m_ListSys.Add(XSysDefine.XSys_CardCollect);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH0/SysE_NPCFavor");
			this.m_ListSys.Add(XSysDefine.XSys_NPCFavor);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH3/SysA_HomeMain");
			this.m_ListSys.Add(XSysDefine.XSys_Home_Plant);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH3/SysB_HomeShop");
			this.m_ListSys.Add(XSysDefine.XSys_Mall_Home);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridH3/SysC_HomeCooking");
			this.m_ListSys.Add(XSysDefine.XSys_Home_Cooking);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel2/SysGridV1/SysAActivity");
			this.m_ListSys.Add(XSysDefine.XSys_DailyAcitivity);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel2/SysGridV1/SysCGuild");
			this.m_ListSys.Add(XSysDefine.XSys_Guild);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel2/SysGridV1/SysEPVP");
			this.m_ListSys.Add(XSysDefine.XSys_MobaAcitivity);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_1/SysAGameMall");
			this.m_ListSys.Add(XSysDefine.XSys_GameMall);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_1/SysCAuction");
			this.m_ListSys.Add(XSysDefine.XSys_Auction);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_1/SysEReward");
			this.m_ListSys.Add(XSysDefine.XSys_Reward);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_1/SysGWelfare");
			this.m_ListSys.Add(XSysDefine.XSys_Welfare);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_1/SysIBq");
			this.m_ListSys.Add(XSysDefine.XSys_Strong);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_1/SysXThemeActivity");
			this.m_ListSys.Add(XSysDefine.XSys_ThemeActivity);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_2/SysACarnival");
			this.m_ListSys.Add(XSysDefine.XSys_Carnival);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_2/SysCFirstRecharge");
			this.m_ListSys.Add(XSysDefine.XSys_Welfare_FirstRechange);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_2/SysEOperatingActivity");
			this.m_ListSys.Add(XSysDefine.XSys_OperatingActivity);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_2/SysG_Live");
			this.m_ListSys.Add(XSysDefine.XSys_Spectate);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_2/SysISevenActivity");
			this.m_ListSys.Add(XSysDefine.XSys_SevenActivity);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/SysGridV2/SysAGameCom");
			this.m_ListSys.Add(XSysDefine.XSys_GameCommunity);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/SysGridV2/SysBBroadcast");
			this.m_ListSys.Add(XSysDefine.XSys_Broadcast);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/SysGridV2/SysBFriendCir");
			this.m_ListSys.Add(XSysDefine.XSys_FriendCircle);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/SysGridV2/SysCQQVIP");
			this.m_ListSys.Add(XSysDefine.XSys_QQVIP);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/SysGridV2/SysDJC");
			this.m_ListSys.Add(XSysDefine.XSys_Platform_StartPrivilege);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/SysGridV2/SysEAnnounceNew");
			this.m_ListSys.Add(XSysDefine.XSys_SystemAnnounce);
			this.CreateV3ListBtns(list, this.m_ListSys);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridGuildH1/SysAGuildHall");
			this.m_ListSys.Add(XSysDefine.XSys_GuildHall);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridGuildH1/SysBGuildRelax");
			this.m_ListSys.Add(XSysDefine.XSys_GuildRelax);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel1/SysGridGuildH1/SysCrossGVG");
			this.m_ListSys.Add(XSysDefine.XSys_CrossGVG);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel2/SysGridGuildV1/SysHGuildMine");
			this.m_ListSys.Add(XSysDefine.XSys_GuildMine);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel2/SysGridGuildV1/SysIGuildTerritory");
			this.m_ListSys.Add(XSysDefine.XSys_GuildTerritory);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel2/SysGridGuildV1/SysCGuildDragon");
			this.m_ListSys.Add(XSysDefine.XSys_GuildDragon);
			list.Add("_canvas/MainMenuFrame/MainMenu/Panel2/SysGridGuildV1/SysBGuildPvp");
			this.m_ListSys.Add(XSysDefine.XSys_GuildPvp);
			list.Add("_canvas/SecondMenuFrame/SysGridGuildH2/SysGuildCollect");
			this.m_ListSys.Add(XSysDefine.XSys_GuildCollect);
			this.m_GuildCollectLeftTime = (base.transform.Find("_canvas/SecondMenuFrame/SysGridGuildH2/SysGuildCollect/Time").GetComponent("XUILabel") as IXUILabel);
			list.Add("_canvas/SecondMenuFrame/SysGridGuildH2/SysGuildSummon");
			this.m_ListSys.Add(XSysDefine.XSys_GuildCollectSummon);
			this.m_GuildCollectSummonTime = (base.transform.Find("_canvas/SecondMenuFrame/SysGridGuildH2/SysGuildSummon/Time").GetComponent("XUILabel") as IXUILabel);
			list.Add("_canvas/ThirdMenuFrame/PING/SysWifi");
			this.m_ListSys.Add(XSysDefine.XSys_Wifi);
			list.Add("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_2/SysKBackflow");
			this.m_ListSys.Add(XSysDefine.Xsys_Backflow);
			this.m_SysGrid = base.transform.Find("_canvas/MainMenuFrame/MainMenu/Panel3/SysGrid").gameObject;
			for (int i = 0; i < this.m_ListSys.Count; i++)
			{
				XSysDefine xsysDefine = this.m_ListSys[i];
				transform = base.transform.FindChild(list[i]);
				bool flag = transform == null;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("btn:" + list[i], null, null, null, null, null);
				}
				else
				{
					IXUIButton ixuibutton = transform.GetComponent("XUIButton") as IXUIButton;
					ixuibutton.ID = (ulong)((long)xsysDefine);
					this.m_SysButtonsMapping[(int)(checked((IntPtr)ixuibutton.ID))] = ixuibutton;
				}
			}
			this.m_HomeGo = base.transform.FindChild("_canvas/Home").gameObject;
			this.m_AvatarFrame = base.transform.FindChild("_canvas/ThirdMenuFrame/AvatarBG").gameObject;
			this.m_PlayerAvatar = (base.transform.FindChild("_canvas/ThirdMenuFrame/AvatarBG/Avatar").GetComponent("XUISprite") as IXUISprite);
			this.m_sprFrame = (base.transform.FindChild("_canvas/ThirdMenuFrame/AvatarBG/AvatarFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_txtAvatar = (base.transform.FindChild("_canvas/ThirdMenuFrame/AvatarBG/HeadPanel/Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_sliderBattery = (base.transform.FindChild("_canvas/ThirdMenuFrame/PING/Battery").GetComponent("XUISlider") as IXUISlider);
			this.m_lblTime = (base.transform.FindChild("_canvas/ThirdMenuFrame/PING/TIME").GetComponent("XUILabel") as IXUILabel);
			this.m_lblFree = (base.transform.FindChild("_canvas/ThirdMenuFrame/PING/T2").GetComponent("XUILabel") as IXUILabel);
			this.m_Level = (this.m_AvatarFrame.transform.Find("CoverPanel/SwitchPanel/BaseInfo/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_PlayerPPT = this.m_AvatarFrame.transform.Find("BattlePointBG").gameObject;
			this.m_PING = base.transform.FindChild("_canvas/ThirdMenuFrame/PING").gameObject;
			Transform transform2 = this.m_AvatarFrame.transform.Find("MoneyInfo");
			for (int j = 0; j < transform2.childCount; j++)
			{
				Transform child = transform2.GetChild(j);
				int itemid = 0;
				bool flag2 = child.name.StartsWith("Info") && int.TryParse(child.name.Substring(child.name.Length - 1, 1), out itemid);
				if (flag2)
				{
					XTitanItem xtitanItem = new XTitanItem();
					xtitanItem.Set(itemid, child.gameObject);
					this.m_MoneyList.Add(xtitanItem);
				}
			}
			this.m_CurFatige = (base.transform.FindChild("_canvas/RecoverTime/curfatige").GetComponent("XUILabel") as IXUILabel);
			this.m_AllCoverTime = (base.transform.FindChild("_canvas/RecoverTime/allcovertime").GetComponent("XUILabel") as IXUILabel);
			this.m_CoverOneTime = (base.transform.FindChild("_canvas/RecoverTime/coveronetime").GetComponent("XUILabel") as IXUILabel);
			this.m_HeadMenuTweenGameObject = base.transform.FindChild("_canvas/ThirdMenuFrame/AvatarBG/CoverPanel/SwitchPanel").gameObject;
			this.m_HeadMenuTween = (this.m_HeadMenuTweenGameObject.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_FakeShowSelfTween = (base.transform.FindChild("_canvas").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_FxFirework = base.transform.FindChild("_canvas/FxFirework").gameObject;
			this.m_RemoveSealTip = (base.transform.FindChild("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_2/SysEOperatingActivity/Message").GetComponent("XUILabel") as IXUILabel);
			this.m_SevenLoginMessage = (base.transform.FindChild("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_2/SysISevenActivity/Message").GetComponent("XUILabel") as IXUILabel);
			this.m_SevenLoginSprite = (base.transform.FindChild("_canvas/SecondMenuFrame/SecondMenu/H2/SysGridH2_2/SysISevenActivity/P").GetComponent("XUISprite") as IXUISprite);
			this.m_LiveTips = this.GetSysButton(XSysDefine.XSys_Spectate).gameObject.transform.Find("Member").gameObject;
			this.m_LiveCount = (this.m_LiveTips.gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel);
			this.m_LiveTips.SetActive(false);
			this.m_MulActTips = (this.GetSysButton(XSysDefine.XSys_DailyAcitivity).gameObject.transform.Find("Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_TaskNaviFrame = base.transform.FindChild("_canvas/TaskNaviPanel").gameObject;
			Transform transform3 = base.transform.Find("_canvas/ExpMgr");
			for (int k = 0; k < 4; k++)
			{
				IXUITweenTool ixuitweenTool = transform3.GetChild(k).GetComponent("XUIPlayTween") as IXUITweenTool;
				IXUILabel item = ixuitweenTool.gameObject.GetComponent("XUILabel") as IXUILabel;
				this.m_ExpAnimationMgr.Add(ixuitweenTool);
				this.m_ExpValueMgr.Add(item);
			}
			this.m_DanceMotion = base.transform.Find("_canvas/MainMenuFrame/MainMenu/DanceMotionFrame").gameObject;
		}

		// Token: 0x06010C1F RID: 68639 RVA: 0x00433378 File Offset: 0x00431578
		private void CreateV3ListBtns(List<string> btnList, List<XSysDefine> ListSys)
		{
			btnList.Add("_canvas/MainMenuFrame/MainMenu/Panel5/SysGridV3/SysEPhoto");
			this.m_ListSys.Add(XSysDefine.XSys_Photo);
			btnList.Add("_canvas/MainMenuFrame/MainMenu/Panel5/SysGridV3/SysAHorseRide");
			this.m_ListSys.Add(XSysDefine.XSys_QuickRide);
			btnList.Add("_canvas/MainMenuFrame/MainMenu/Panel5/SysGridV3/SysAChange");
			this.m_ListSys.Add(XSysDefine.XSys_Transform);
			GameObject gameObject = base.transform.Find("_canvas/MainMenuFrame/MainMenu/Panel5/SysGridV3").gameObject;
			for (int i = 0; i < gameObject.gameObject.transform.childCount; i++)
			{
				Transform child = gameObject.gameObject.transform.GetChild(i);
				GameObject gameObject2 = child.FindChild("Select").gameObject;
				bool flag = gameObject2 != null;
				if (flag)
				{
					gameObject2.SetActive(false);
				}
			}
			IXUILabel label = base.transform.Find("_canvas/MainMenuFrame/MainMenu/Panel5/SysGridV3/SysAChange/Time").GetComponent("XUILabel") as IXUILabel;
			this.m_TransformLeftTime = new XLeftTimeCounter(label, true);
			this.m_MotionDance = (base.transform.Find("_canvas/MainMenuFrame/MainMenu/Panel5/SysGridV3/SysCDance").GetComponent("XUIButton") as IXUIButton);
			this.m_MotionLover = (base.transform.Find("_canvas/MainMenuFrame/MainMenu/Panel5/SysGridV3/SysBLoverDance").GetComponent("XUIButton") as IXUIButton);
			this.m_MotionDance.ID = 1UL;
			this.m_MotionLover.ID = 2UL;
		}

		// Token: 0x06010C20 RID: 68640 RVA: 0x004334E4 File Offset: 0x004316E4
		public IXUIButton GetSysButton(XSysDefine sys)
		{
			bool flag = sys < XSysDefine.XSys_Num;
			IXUIButton result;
			if (flag)
			{
				result = this.m_SysButtonsMapping[(int)sys];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x04007A76 RID: 31350
		public Transform m_Canvas;

		// Token: 0x04007A77 RID: 31351
		public GameObject m_SecondMenu;

		// Token: 0x04007A78 RID: 31352
		public GameObject m_MainMenuGo;

		// Token: 0x04007A79 RID: 31353
		public IXUIList m_SysListH1;

		// Token: 0x04007A7A RID: 31354
		public IXUIList m_SysListH0;

		// Token: 0x04007A7B RID: 31355
		public IXUIList m_SysListH2;

		// Token: 0x04007A7C RID: 31356
		public IXUIList m_SysListH3;

		// Token: 0x04007A7D RID: 31357
		public IXUISprite m_MenuSwitchBtn;

		// Token: 0x04007A7E RID: 31358
		public IXUITweenTool m_SysListH1Tween;

		// Token: 0x04007A7F RID: 31359
		public IXUITweenTool m_SysListH0Tween;

		// Token: 0x04007A80 RID: 31360
		public IXUITweenTool m_SysListH2Tween;

		// Token: 0x04007A81 RID: 31361
		public IXUITweenTool m_SysListH3Tween;

		// Token: 0x04007A82 RID: 31362
		public IXUITweenTool m_MenuSwitchBtnTween;

		// Token: 0x04007A83 RID: 31363
		public IXUIList m_SysListV1;

		// Token: 0x04007A84 RID: 31364
		public IXUIList m_SysListV2;

		// Token: 0x04007A85 RID: 31365
		public IXUIList m_SysListV3;

		// Token: 0x04007A86 RID: 31366
		public IXUISprite m_V3SwitchBtn;

		// Token: 0x04007A87 RID: 31367
		public IXUIList m_SysListH2_1;

		// Token: 0x04007A88 RID: 31368
		public IXUIList m_SysListH2_2;

		// Token: 0x04007A89 RID: 31369
		public IXUISprite m_H2SwitchBtn;

		// Token: 0x04007A8A RID: 31370
		public IXUITweenTool m_H2ListTween;

		// Token: 0x04007A8B RID: 31371
		public IXUITweenTool m_H2SwitchTween;

		// Token: 0x04007A8C RID: 31372
		public IXUIList m_SysListGuildH1;

		// Token: 0x04007A8D RID: 31373
		public IXUIList m_SysListGuildV1;

		// Token: 0x04007A8E RID: 31374
		public IXUIList m_SysListGuildH2;

		// Token: 0x04007A8F RID: 31375
		public IXUITweenTool m_V3SwitchTween;

		// Token: 0x04007A90 RID: 31376
		public IXUITweenTool m_V3ListTween;

		// Token: 0x04007A91 RID: 31377
		public IXUIButton m_MotionDance;

		// Token: 0x04007A92 RID: 31378
		public IXUIButton m_MotionLover;

		// Token: 0x04007A93 RID: 31379
		public GameObject m_DanceMotion;

		// Token: 0x04007A94 RID: 31380
		public GameObject m_SysGrid;

		// Token: 0x04007A95 RID: 31381
		public IXUIButton m_ExitGuild;

		// Token: 0x04007A96 RID: 31382
		public IXUITweenTool m_HeadMenuTween;

		// Token: 0x04007A97 RID: 31383
		public GameObject m_HeadMenuTweenGameObject;

		// Token: 0x04007A98 RID: 31384
		public IXUISlider m_sliderBattery;

		// Token: 0x04007A99 RID: 31385
		public IXUILabel m_lblTime;

		// Token: 0x04007A9A RID: 31386
		public IXUILabel m_lblFree;

		// Token: 0x04007A9B RID: 31387
		public GameObject m_AvatarFrame;

		// Token: 0x04007A9C RID: 31388
		public IXUISprite m_PlayerAvatar;

		// Token: 0x04007A9D RID: 31389
		public IXUISprite m_sprFrame;

		// Token: 0x04007A9E RID: 31390
		public IXUITexture m_txtAvatar;

		// Token: 0x04007A9F RID: 31391
		public GameObject m_PlayerPPT;

		// Token: 0x04007AA0 RID: 31392
		public IXUILabel m_Level;

		// Token: 0x04007AA1 RID: 31393
		public GameObject m_PING;

		// Token: 0x04007AA2 RID: 31394
		public IXUILabel m_GuildCollectLeftTime;

		// Token: 0x04007AA3 RID: 31395
		public IXUILabel m_GuildCollectSummonTime;

		// Token: 0x04007AA4 RID: 31396
		public XLeftTimeCounter m_TransformLeftTime;

		// Token: 0x04007AA5 RID: 31397
		public List<XTitanItem> m_MoneyList = new List<XTitanItem>();

		// Token: 0x04007AA6 RID: 31398
		public GameObject m_TaskNaviFrame;

		// Token: 0x04007AA7 RID: 31399
		public IXUITweenTool m_FakeShowSelfTween;

		// Token: 0x04007AA8 RID: 31400
		public IXUISprite m_RecoverTime;

		// Token: 0x04007AA9 RID: 31401
		public IXUILabel m_CurFatige;

		// Token: 0x04007AAA RID: 31402
		public IXUILabel m_AllCoverTime;

		// Token: 0x04007AAB RID: 31403
		public IXUILabel m_CoverOneTime;

		// Token: 0x04007AAC RID: 31404
		public GameObject m_HomeGo;

		// Token: 0x04007AAD RID: 31405
		public GameObject m_FxFirework;

		// Token: 0x04007AAE RID: 31406
		public IXUILabel m_RemoveSealTip;

		// Token: 0x04007AAF RID: 31407
		public GameObject m_LiveTips;

		// Token: 0x04007AB0 RID: 31408
		public IXUILabel m_LiveCount;

		// Token: 0x04007AB1 RID: 31409
		public IXUILabel m_MulActTips;

		// Token: 0x04007AB2 RID: 31410
		public IXUILabel m_SevenLoginMessage;

		// Token: 0x04007AB3 RID: 31411
		public IXUISprite m_SevenLoginSprite;

		// Token: 0x04007AB4 RID: 31412
		public List<IXUITweenTool> m_ExpAnimationMgr = new List<IXUITweenTool>();

		// Token: 0x04007AB5 RID: 31413
		public List<IXUILabel> m_ExpValueMgr = new List<IXUILabel>();

		// Token: 0x04007AB6 RID: 31414
		public IXUIButton[] m_SysButtonsMapping = new IXUIButton[1024];

		// Token: 0x04007AB7 RID: 31415
		public List<XSysDefine> m_ListSys = new List<XSysDefine>();

		// Token: 0x04007AB8 RID: 31416
		public XSysDefine[] m_SysGuild = new XSysDefine[]
		{
			XSysDefine.XSys_GuildHall,
			XSysDefine.XSys_GuildRelax,
			XSysDefine.XSys_CrossGVG,
			XSysDefine.XSys_GuildDragon,
			XSysDefine.XSys_GuildPvp,
			XSysDefine.XSys_GuildMine,
			XSysDefine.XSys_GuildTerritory
		};

		// Token: 0x04007AB9 RID: 31417
		public HashSet<XSysDefine> m_SysGuildNormal = new HashSet<XSysDefine>(default(XFastEnumIntEqualityComparer<XSysDefine>))
		{
			XSysDefine.XSys_GuildCollect,
			XSysDefine.XSys_GuildCollectSummon
		};

		// Token: 0x04007ABA RID: 31418
		public XSysDefine[] m_SysChar = new XSysDefine[]
		{
			XSysDefine.XSys_Char,
			XSysDefine.XSys_Bag
		};

		// Token: 0x04007ABB RID: 31419
		public XSysDefine[] m_SysH4 = new XSysDefine[]
		{
			XSysDefine.XSys_Chat,
			XSysDefine.XSys_Setting,
			XSysDefine.XSys_Mail
		};

		// Token: 0x04007ABC RID: 31420
		public HashSet<XSysDefine> m_SysH1 = new HashSet<XSysDefine>(default(XFastEnumIntEqualityComparer<XSysDefine>))
		{
			XSysDefine.XSys_Item,
			XSysDefine.XSys_Skill,
			XSysDefine.XSys_SpriteSystem,
			XSysDefine.XSys_Horse,
			XSysDefine.XSys_EquipCreate
		};

		// Token: 0x04007ABD RID: 31421
		public HashSet<XSysDefine> m_SysV3 = new HashSet<XSysDefine>(default(XFastEnumIntEqualityComparer<XSysDefine>))
		{
			XSysDefine.XSys_QuickRide,
			XSysDefine.XSys_Photo
		};
	}
}
