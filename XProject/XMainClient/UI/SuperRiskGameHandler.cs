using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SuperRiskGameHandler : DlgHandlerBase
	{

		public string ScrollEffectPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_scrollEffectPath);
				if (flag)
				{
					this.m_scrollEffectPath = XSingleton<XGlobalConfig>.singleton.GetValue("RiskScrollEffectPath");
				}
				return this.m_scrollEffectPath;
			}
		}

		public string DungeonEffectPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_dungeonEffectPath);
				if (flag)
				{
					this.m_dungeonEffectPath = XSingleton<XGlobalConfig>.singleton.GetValue("RiskDungeonEffectPath");
				}
				return this.m_dungeonEffectPath;
			}
		}

		public string BoxEffectPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_boxEffectPath);
				if (flag)
				{
					this.m_boxEffectPath = XSingleton<XGlobalConfig>.singleton.GetValue("RiskBoxEffectPath");
				}
				return this.m_boxEffectPath;
			}
		}

		protected override string FileName
		{
			get
			{
				return "GameSystem/SuperRisk/GameHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XSuperRiskDocument.uuID) as XSuperRiskDocument);
			this._doc.GameViewHandler = this;
			this._welfareDoc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			this.PlayerAvatar = (base.PanelObject.transform.Find("PlayerAvatar/Me").GetComponent("XUISprite") as IXUISprite);
			this.PlayerTween = (base.PanelObject.transform.Find("PlayerAvatar").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.PlayerAvatar.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetSuperRiskAvatar(XSingleton<XEntityMgr>.singleton.Player.BasicTypeID);
			this.ResetTween = (base.PanelObject.transform.Find("again/again").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.ResetTween.SetTweenGroup(0);
			this.ResetTween.gameObject.SetActive(false);
			this.m_Close = (base.PanelObject.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.PanelObject.transform.Find("Dynamic/Item");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 20U, false);
			this.m_LeftTime = (base.PanelObject.transform.Find("Panel/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_RecoverTime = (base.PanelObject.transform.Find("Panel/Time/Recover").GetComponent("XUILabel") as IXUILabel);
			this.m_RecoverFullLab = (base.PanelObject.transform.Find("Panel/Time/Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_PrerogativeSpr = (base.PanelObject.transform.FindChild("Panel/Time/tq").GetComponent("XUISprite") as IXUISprite);
			this.m_PrerogativeLab = (base.PanelObject.transform.FindChild("Panel/Time/tq/t").GetComponent("XUILabel") as IXUILabel);
			this.m_PrerogativeBg = (base.PanelObject.transform.FindChild("Panel/Time/tq/p").GetComponent("XUISprite") as IXUISprite);
			this.m_rollBtn = (base.PanelObject.transform.FindChild("Roll/Rollbutton").GetComponent("XUISprite") as IXUISprite);
			this.m_rollTween = (base.PanelObject.transform.FindChild("Roll/Rollbutton").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_rollFx = base.PanelObject.transform.FindChild("Roll/Rollbutton/FX");
			this.m_rollBarGo = base.PanelObject.transform.FindChild("Roll/k").gameObject;
			this.m_rollBarGo.SetActive(false);
			this.m_DiceDummyPoint = base.PanelObject.transform.FindChild("Roll/DicePoint");
			transform = base.PanelObject.transform.Find("BoxSlot/BoxTpl");
			this.SlotBoxPool.SetupPool(transform.parent.gameObject, transform.gameObject, SuperRiskGameHandler.total_slot_box, false);
			this.m_BoxSlotTween = (base.PanelObject.transform.Find("BoxSlot").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_GetBoxFrame = base.PanelObject.transform.Find("Getbox").gameObject;
			this.m_GetBoxTween = (this.m_GetBoxFrame.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_GetBoxFrame.SetActive(false);
			this.m_mapTexture = (base.PanelObject.transform.FindChild("GameMap").GetComponent("XUITexture") as IXUITexture);
			this.m_mapTittleLab = (base.PanelObject.transform.FindChild("GameMap/T").GetComponent("XUILabel") as IXUILabel);
			this.m_OpenBoxFrame = base.PanelObject.transform.FindChild("Openbox").gameObject;
			DlgHandlerBase.EnsureCreate<SuperRiskOpenboxHandler>(ref this.m_OpenBoxHandler, this.m_OpenBoxFrame, null, false);
			this.m_OnlineBoxFrame = base.PanelObject.transform.FindChild("Openlihe").gameObject;
			DlgHandlerBase.EnsureCreate<SuperRiskOnlineBoxHandler>(ref this.m_OnlineBoxHandler, this.m_OnlineBoxFrame, null, false);
			this.m_theEndTra = base.PanelObject.transform.FindChild("Dynamic/TheEnd");
			this.m_NoticeFrame = base.PanelObject.transform.FindChild("Notice").gameObject;
			this.m_NoticeYes = (base.PanelObject.transform.FindChild("Notice/Buy").GetComponent("XUIButton") as IXUIButton);
			this.m_NoticeFrame.SetActive(false);
		}

		public override void OnUnload()
		{
			this._doc.GameViewHandler = null;
			bool flag = this.m_scrollFx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_scrollFx, true);
				this.m_scrollFx = null;
			}
			for (int i = 0; i < this.m_dungeonFxs.Count; i++)
			{
				bool flag2 = this.m_dungeonFxs[i] != null;
				if (flag2)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this.m_dungeonFxs[i], true);
					this.m_dungeonFxs[i] = null;
				}
			}
			for (int j = 0; j < this.m_boxFxs.Length; j++)
			{
				bool flag3 = this.m_boxFxs[j] != null;
				if (flag3)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this.m_boxFxs[j], true);
					this.m_boxFxs[j] = null;
				}
			}
			DlgHandlerBase.EnsureUnload<SuperRiskOpenboxHandler>(ref this.m_OpenBoxHandler);
			DlgHandlerBase.EnsureUnload<SuperRiskOnlineBoxHandler>(ref this.m_OnlineBoxHandler);
			bool flag4 = this._doc.GameState == SuperRiskState.SuperRiskMoving;
			if (flag4)
			{
				this._doc.NoticeMoveOver();
			}
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			this.m_NoticeYes.RegisterClickEventHandler(new ButtonClickEventHandler(this._NoticeYesClick));
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this.m_PrerogativeBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMemberPrivilegeClicked));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_SuperRisk);
			return true;
		}

		protected override void OnShow()
		{
			this.InitMapBaseInfo();
			this._doc.ReqMapDynamicInfo(this._doc.CurrentMapID, false, false);
		}

		public override void LeaveStackTop()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("LeaveStackTop!", null, null, null, null, null);
			this.Clear();
			base.LeaveStackTop();
		}

		public void RefreshUi()
		{
			this.RefreshMap();
			this.SetDiceLeftTime();
			this.SetupSlotBoxes();
			this.ShowCatchedOnlineBox();
		}

		protected override void OnHide()
		{
			this.Clear();
			base.OnHide();
		}

		private void Clear()
		{
			bool flag = this.m_DiceTimer > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.m_DiceTimer);
				this.m_DiceTimer = 0U;
			}
			bool flag2 = this.m_DiceDummy != null;
			if (flag2)
			{
				XSingleton<XEntityMgr>.singleton.DestroyEntity(this.m_DiceDummy);
				this.m_DiceDummy = null;
			}
			this.m_controller = null;
			this.m_bIsPlayingResetAnimation = false;
			bool flag3 = this.m_GetBoxTween != null && this.m_GetBoxTween.gameObject.activeSelf;
			if (flag3)
			{
				this.m_GetBoxTween.StopTweenByGroup(0);
				this.m_GetBoxTween.ResetTween(true);
				this.m_GetBoxFrame.SetActive(false);
			}
			bool flag4 = this.m_rollTween != null && this.m_rollTween.gameObject.activeSelf;
			if (flag4)
			{
				this.m_rollTween.StopTweenByGroup(0);
				this.m_rollTween.ResetTweenByGroup(true, 0);
			}
			bool flag5 = this.ResetTween != null && this.ResetTween.gameObject.activeSelf;
			if (flag5)
			{
				this.ResetTween.StopTweenByGroup(0);
				this.ResetTween.ResetTweenByGroup(true, 0);
				this.ResetTween.gameObject.SetActive(false);
			}
			bool flag6 = this.PlayerTween != null && this.PlayerTween.gameObject.activeSelf;
			if (flag6)
			{
				this.PlayerTween.StopTweenByGroup(0);
				this.PlayerTween.ResetTweenByGroup(true, 0);
			}
			bool flag7 = this.m_OpenBoxHandler != null && this.m_OpenBoxHandler.IsVisible();
			if (flag7)
			{
				this.m_OpenBoxHandler.SetVisible(false);
			}
			bool flag8 = this.m_OnlineBoxHandler != null && this.m_OnlineBoxHandler.IsVisible();
			if (flag8)
			{
				this.m_OnlineBoxHandler.SetVisible(false);
			}
			this.DestoryTex();
			bool flag9 = this.m_OpenBoxFrame != null;
			if (flag9)
			{
				this.m_OpenBoxHandler.ClearCatchTex();
			}
			bool flag10 = this._doc != null;
			if (flag10)
			{
				bool flag11 = this._doc.GameState == SuperRiskState.SuperRiskDicing || this._doc.GameState == SuperRiskState.SuperRiskMoving;
				if (flag11)
				{
					this._doc.NoticeMoveOver();
				}
				this._doc.StopStep();
			}
			bool flag12 = this.m_scrollFx != null;
			if (flag12)
			{
				this.m_scrollFx.Stop();
				this.m_scrollFx.SetActive(false);
			}
			for (int i = 0; i < this.m_dungeonFxs.Count; i++)
			{
				bool flag13 = this.m_dungeonFxs[i] != null;
				if (flag13)
				{
					this.m_dungeonFxs[i].Stop();
					this.m_dungeonFxs[i].SetActive(false);
				}
			}
			for (int j = 0; j < this.m_boxFxs.Length; j++)
			{
				bool flag14 = this.m_boxFxs[j] != null;
				if (flag14)
				{
					this.m_boxFxs[j].Stop();
					this.m_boxFxs[j].SetActive(false);
				}
			}
		}

		private void DestoryTex()
		{
			this.m_mapTexture.SetTexturePath("");
		}

		public override void StackRefresh()
		{
			this.InitMapBaseInfo();
			this._doc.ReqMapDynamicInfo(this._doc.CurrentMapID, false, false);
		}

		public void RefreshMap()
		{
			this.PlayerAvatar.gameObject.SetActive(true);
			this.PlayerAvatar.gameObject.transform.parent.localPosition = this._doc.GetPlayerAvatarPos();
			this.m_ItemPool.FakeReturnAll();
			this.m_MapItems.Clear();
			RiskMapFile.RowData currentMapData = this._doc.GetCurrentMapData();
			int num = 0;
			for (int i = 0; i < this._doc.CurrentDynamicInfo.Count; i++)
			{
				RiskGridInfo riskGridInfo = this._doc.CurrentDynamicInfo[i];
				bool flag = riskGridInfo == null;
				if (!flag)
				{
					Vector2 gridPos = this._doc.GetGridPos(riskGridInfo.x, riskGridInfo.y);
					char c;
					XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.GetNodeGroup(new Coordinate(riskGridInfo.x, riskGridInfo.y), out c);
					bool flag2 = c == 'T';
					if (flag2)
					{
						this.m_theEndTra.gameObject.SetActive(true);
						this.m_theEndTra.localPosition = gridPos;
					}
					GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Di").GetComponent("XUISprite") as IXUISprite;
					bool flag3 = currentMapData != null;
					if (flag3)
					{
						ixuisprite.SetSprite(currentMapData.MapGridBg);
					}
					ixuisprite.spriteDepth = 15 + riskGridInfo.y * 2;
					ixuisprite = (gameObject.transform.FindChild("Card").GetComponent("XUISprite") as IXUISprite);
					ixuisprite.spriteDepth = 16 + riskGridInfo.y * 2;
					switch (riskGridInfo.gridType)
					{
					case RiskGridType.RISK_GRID_EMPTY:
						ixuisprite.SetVisible(false);
						break;
					case RiskGridType.RISK_GRID_NORMALREWARD:
					{
						ixuisprite.SetVisible(true);
						bool flag4 = riskGridInfo.boxState != RiskBoxState.RISK_BOX_UNLOCKED;
						ixuisprite.SetEnabled(flag4);
						bool flag5 = !flag4;
						if (flag5)
						{
							ixuisprite.SetColor(this.GreyColor);
						}
						else
						{
							ixuisprite.SetColor(this.NormalColor);
						}
						ixuisprite.SetSprite("dmxkuang_0");
						break;
					}
					case RiskGridType.RISK_GRID_REWARDBOX:
					{
						ixuisprite.SetVisible(true);
						bool flag4 = riskGridInfo.boxState != RiskBoxState.RISK_BOX_UNLOCKED;
						ixuisprite.SetEnabled(flag4);
						bool flag6 = !flag4;
						if (flag6)
						{
							ixuisprite.SetColor(this.GreyColor);
						}
						else
						{
							ixuisprite.SetColor(this.NormalColor);
						}
						ixuisprite.SetSprite(this.GetBoxSprNameByState(riskGridInfo.rewardItem.itemID));
						break;
					}
					case RiskGridType.RISK_GRID_ADVENTURE:
					{
						ixuisprite.SetVisible(true);
						bool flag4 = riskGridInfo.boxState != RiskBoxState.RISK_BOX_UNLOCKED;
						ixuisprite.SetEnabled(flag4);
						bool flag7 = !flag4;
						if (flag7)
						{
							ixuisprite.SetColor(this.GreyColor);
						}
						else
						{
							ixuisprite.SetColor(this.NormalColor);
						}
						ixuisprite.SetSprite("dmxkuang_4");
						bool flag8 = this.m_dungeonFxs.Count <= num;
						if (flag8)
						{
							XFx item = XSingleton<XFxMgr>.singleton.CreateFx(this.DungeonEffectPath, null, true);
							this.m_dungeonFxs.Add(item);
						}
						else
						{
							this.m_dungeonFxs[num].SetActive(true);
						}
						bool flag9 = flag4;
						if (flag9)
						{
							this.m_dungeonFxs[num].Play(ixuisprite.gameObject.transform, Vector3.zero, Vector3.one, 1f, true, false);
						}
						else
						{
							this.m_dungeonFxs[num].SetActive(false);
							this.m_dungeonFxs[num].Stop();
						}
						num++;
						break;
					}
					case RiskGridType.RISK_GRID_DICE:
					{
						ixuisprite.SetVisible(true);
						bool flag4 = riskGridInfo.boxState != RiskBoxState.RISK_BOX_UNLOCKED;
						ixuisprite.SetEnabled(flag4);
						bool flag10 = !flag4;
						if (flag10)
						{
							ixuisprite.SetColor(this.GreyColor);
						}
						else
						{
							ixuisprite.SetColor(this.NormalColor);
						}
						ixuisprite.SetSprite("dmxkuang_5");
						break;
					}
					}
					IXUISprite ixuisprite2 = gameObject.transform.FindChild("Di").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = (ulong)((long)XFastEnumIntEqualityComparer<RiskGridType>.ToInt(riskGridInfo.gridType));
					bool flag11 = i != 0;
					if (flag11)
					{
						ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnShowItemTips));
					}
					else
					{
						ixuisprite2.RegisterSpriteClickEventHandler(null);
						ixuisprite.SetSprite("SuperBegin");
						ixuisprite.SetEnabled(true);
						ixuisprite.SetVisible(true);
					}
					gameObject.transform.localPosition = gridPos;
					this.m_MapItems.Add(riskGridInfo, gameObject);
				}
			}
			bool flag12 = this.m_dungeonFxs.Count > num;
			if (flag12)
			{
				for (int j = num; j < this.m_dungeonFxs.Count; j++)
				{
					bool flag13 = this.m_dungeonFxs[j] != null;
					if (flag13)
					{
						this.m_dungeonFxs[j].SetActive(false);
						this.m_dungeonFxs[j].Stop();
					}
				}
			}
			this.m_ItemPool.ActualReturnAll(false);
		}

		private void OnShowItemTips(IXUISprite spr)
		{
			switch ((int)spr.ID)
			{
			case 1:
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SuperRiskEmpty"), "fece00");
				break;
			case 2:
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SuperRiskHandBook"), "fece00");
				break;
			case 3:
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SuperRiskBox"), "fece00");
				break;
			case 4:
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SuperRiskAdvance"), "fece00");
				break;
			case 5:
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SuperRiskDice"), "fece00");
				break;
			}
		}

		private void InitMapBaseInfo()
		{
			RiskMapFile.RowData currentMapData = this._doc.GetCurrentMapData();
			bool flag = currentMapData != null;
			if (flag)
			{
				this.m_mapTexture.SetTexturePath("atlas/UI/GameSystem/SuperRisk/" + currentMapData.MapBgName);
				this.m_mapTittleLab.SetText(string.Format("[b]{0}[-]", currentMapData.MapTittleName));
			}
			this.PlayerAvatar.gameObject.SetActive(false);
			this.m_theEndTra.gameObject.SetActive(false);
			this.HideDice();
			this.m_PrerogativeSpr.SetGrey(this._welfareDoc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce));
			this.m_PrerogativeSpr.SetSprite(this._welfareDoc.GetMemberPrivilegeIcon(MemberPrivilege.KingdomPrivilege_Commerce));
			this.m_PrerogativeLab.SetEnabled(this._welfareDoc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce));
		}

		private void OnMemberPrivilegeClicked(IXUISprite btn)
		{
			bool flag = this._doc.GameState == SuperRiskState.SuperRiskSendingRollMes || this._doc.GameState == SuperRiskState.SuperRiskRolling || this._doc.GameState == SuperRiskState.SuperRiskDicing || this._doc.GameState == SuperRiskState.SuperRiskMoving || this._doc.GameState == SuperRiskState.SuperRiskEvent || this._doc.GameState == SuperRiskState.SuperRiskRefreshMap;
			if (!flag)
			{
				DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce);
			}
		}

		public void HideDice()
		{
			bool flag = this.m_DiceDummy != null;
			if (flag)
			{
				this.m_DiceDummy.EngineObject.SetActive(false, "");
			}
		}

		public void OnMapItemFetched(Coordinate c)
		{
			RiskGridInfo gridDynamicInfo = this._doc.GetGridDynamicInfo(c);
			bool flag = gridDynamicInfo == null;
			if (!flag)
			{
				bool flag2 = !this.m_MapItems.ContainsKey(gridDynamicInfo);
				if (!flag2)
				{
					IXUISprite ixuisprite = this.m_MapItems[gridDynamicInfo].transform.FindChild("Card").GetComponent("XUISprite") as IXUISprite;
					switch (gridDynamicInfo.gridType)
					{
					case RiskGridType.RISK_GRID_NORMALREWARD:
					{
						ixuisprite.SetEnabled(false);
						ixuisprite.SetColor(this.GreyColor);
						bool flag3 = gridDynamicInfo.rewardItem.itemID > 0U;
						if (flag3)
						{
							this.HideDice();
							DlgBase<RewdAnimDlg, RewdAnimBehaviour>.singleton.Show(new List<ItemBrief>
							{
								gridDynamicInfo.rewardItem
							}, new Action(this._doc.RewdAnimCallBack));
						}
						else
						{
							bool isHadOnlineBoxCache = this._doc.IsHadOnlineBoxCache;
							if (isHadOnlineBoxCache)
							{
								this._doc.IsHadOnlineBoxCache = false;
								this.HideDice();
								this.ShowOnlineBox();
							}
						}
						break;
					}
					case RiskGridType.RISK_GRID_REWARDBOX:
						ixuisprite.SetEnabled(false);
						ixuisprite.SetColor(this.GreyColor);
						break;
					case RiskGridType.RISK_GRID_ADVENTURE:
					{
						ixuisprite.SetEnabled(false);
						ixuisprite.SetColor(this.GreyColor);
						bool flag4 = ixuisprite.gameObject.transform.childCount > 0;
						if (flag4)
						{
							ixuisprite.gameObject.transform.GetChild(0).gameObject.SetActive(false);
						}
						break;
					}
					case RiskGridType.RISK_GRID_DICE:
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AddDiceTips"), "fece00");
						ixuisprite.SetEnabled(false);
						ixuisprite.SetColor(this.GreyColor);
						break;
					}
				}
			}
		}

		public string GetBoxSprNameByState(uint itemID)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemID);
			bool flag = itemConf == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				result = XSingleton<XCommon>.singleton.StringCombine("Boxicon_", ((int)(itemConf.ItemQuality - 1)).ToString());
			}
			return result;
		}

		public string GetHandbookSprName(int itemId)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(itemId);
			bool flag = itemConf == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				switch (itemConf.ItemQuality)
				{
				case 1:
					result = "tujicon_0";
					break;
				case 2:
					result = "tujicon_3";
					break;
				case 3:
					result = "tujicon_2";
					break;
				case 4:
					result = "tujicon_1";
					break;
				case 5:
					result = "tujicon_4";
					break;
				default:
					result = "tujicon_0";
					break;
				}
			}
			return result;
		}

		public string GetBoxPicByState(uint itemID, RiskBoxState state)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemID);
			bool flag = itemConf != null;
			string result;
			if (flag)
			{
				string text = string.Format("atlas/UI/GameSystem/SuperRisk/bx{0}", (int)(itemConf.ItemQuality - 1));
				bool flag2 = state == RiskBoxState.RISK_BOX_UNLOCKED;
				if (flag2)
				{
					text += "_1";
				}
				result = text;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public void SetDiceLeftTime()
		{
			bool flag = this._doc.LeftDiceTime <= 0;
			string arg;
			if (flag)
			{
				arg = "[ff0000]" + this._doc.LeftDiceTime + "[-]";
				this.m_rollBtn.SetGrey(false);
				this.m_rollBtn.RegisterSpritePressEventHandler(null);
				this.m_rollBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnRollClick));
			}
			else
			{
				arg = this._doc.LeftDiceTime.ToString();
				this.m_rollBtn.SetGrey(true);
				this.m_rollBtn.RegisterSpritePressEventHandler(new SpritePressEventHandler(this._OnRollPress));
				this.m_rollBtn.RegisterSpriteClickEventHandler(null);
			}
			int num = 0;
			PayMemberTable.RowData memberPrivilegeConfig = this._welfareDoc.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Commerce);
			bool flag2 = memberPrivilegeConfig != null;
			if (flag2)
			{
				num = memberPrivilegeConfig.SuperRiskCount;
			}
			bool flag3 = this._welfareDoc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce);
			if (flag3)
			{
				int num2 = 0;
				bool flag4 = this._welfareDoc.PayMemberPrivilege != null;
				if (flag4)
				{
					num2 = this._welfareDoc.PayMemberPrivilege.usedSuperRiskCount;
				}
				int num3 = (num > num2) ? (num - num2) : 0;
				this.m_PrerogativeLab.SetText(string.Format("{0}{1}/{2}", XStringDefineProxy.GetString("Prerogative_Superrisk"), num3, num));
				this.m_LeftTime.SetText(string.Format("[b]{0}/{1}[/b]", this._doc.LeftDiceTime - num3, XSingleton<XGlobalConfig>.singleton.GetValue("RiskDiceMaxNum")));
			}
			else
			{
				this.m_PrerogativeLab.SetText(string.Format("{0}{1}/{2}", XStringDefineProxy.GetString("Prerogative_Superrisk"), num, num));
				this.m_LeftTime.SetText(string.Format("[b]{0}/{1}[/b]", arg, XSingleton<XGlobalConfig>.singleton.GetValue("RiskDiceMaxNum")));
			}
			bool flag5 = this._doc.RefreshDiceTime == -1f;
			if (flag5)
			{
				this.m_RecoverFullLab.gameObject.SetActive(true);
				this.m_RecoverFullLab.SetText(XStringDefineProxy.GetString("ReplyDiceFullTips"));
				this.m_RecoverTime.gameObject.SetActive(false);
			}
			else
			{
				this.m_RecoverTime.gameObject.SetActive(true);
				this.m_RecoverTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)this._doc.RefreshDiceTime, 2, 3, 4, false, true));
				this.m_RecoverFullLab.gameObject.SetActive(false);
			}
		}

		public void SetupSlotBoxes()
		{
			this.SlotBoxPool.FakeReturnAll();
			for (int i = 0; i < 3; i++)
			{
				GameObject gameObject = this.SlotBoxPool.FetchGameObject(false);
				gameObject.name = XSingleton<XCommon>.singleton.StringCombine("slot", i.ToString());
				gameObject.transform.localPosition = this.SlotBoxPool.TplPos + new Vector3((float)(i * this.SlotBoxPool.TplWidth), 0f);
				this.m_CachedBoxSlotTimeLabel[i] = (gameObject.transform.Find("State/Time").GetComponent("XUILabel") as IXUILabel);
				this.m_CachedBoxCostLabel[i] = (gameObject.transform.FindChild("State/Time/SpeedBtn/Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
				bool flag = this._doc.SlotBoxInfo.ContainsKey(i);
				if (flag)
				{
					this.SetupSlotBox(gameObject, this._doc.SlotBoxInfo[i], i);
				}
				else
				{
					this.SetupSlotBox(gameObject, null, i);
				}
			}
			this.SlotBoxPool.ActualReturnAll(false);
		}

		private void ShowCatchedOnlineBox()
		{
			RiskGridInfo gridDynamicInfo = this._doc.GetGridDynamicInfo(XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.PlayerCoord);
			bool flag = gridDynamicInfo == null;
			if (!flag)
			{
				bool flag2 = gridDynamicInfo.gridType != RiskGridType.RISK_GRID_ADVENTURE;
				if (!flag2)
				{
					bool isHadOnlineBoxCache = this._doc.IsHadOnlineBoxCache;
					if (isHadOnlineBoxCache)
					{
						this._doc.IsHadOnlineBoxCache = false;
						this.HideDice();
						this.ShowOnlineBox();
					}
				}
			}
		}

		protected void SetupSlotBox(GameObject go, ClientBoxInfo info, int slot)
		{
			IXUISprite ixuisprite = go.GetComponent("XUISprite") as IXUISprite;
			IXUITexture ixuitexture = go.transform.Find("Box").GetComponent("XUITexture") as IXUITexture;
			IXUISprite ixuisprite2 = ixuitexture.gameObject.transform.FindChild("Closed").GetComponent("XUISprite") as IXUISprite;
			GameObject gameObject = go.transform.Find("State").gameObject;
			bool flag = info == null;
			if (flag)
			{
				ixuitexture.gameObject.SetActive(false);
				gameObject.SetActive(false);
			}
			else
			{
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickDiscardBox));
				ixuisprite2.ID = (ulong)slot;
				bool flag2 = info.state == RiskBoxState.RISK_BOX_CANGETREWARD;
				if (flag2)
				{
					ixuisprite2.SetVisible(false);
				}
				else
				{
					ixuisprite2.SetVisible(true);
				}
				ixuitexture.gameObject.SetActive(true);
				gameObject.SetActive(true);
				ixuitexture.SetTexturePath(this.GetBoxPicByState(info.itemID, RiskBoxState.RISK_BOX_LOCKED));
				Transform transform = go.transform.Find("State/Time");
				Transform transform2 = go.transform.Find("State/unlock");
				Transform transform3 = go.transform.Find("State/open");
				transform.gameObject.SetActive(false);
				transform2.gameObject.SetActive(false);
				transform3.gameObject.SetActive(false);
				switch (info.state)
				{
				case RiskBoxState.RISK_BOX_LOCKED:
					transform2.gameObject.SetActive(true);
					this.m_BoxSlotTween.SetTargetGameObject(ixuitexture.gameObject);
					this.m_BoxSlotTween.ResetTween(true);
					break;
				case RiskBoxState.RISK_BOX_UNLOCKED:
					transform.gameObject.SetActive(true);
					this.m_BoxSlotTween.SetTargetGameObject(ixuitexture.gameObject);
					this.m_BoxSlotTween.ResetTween(true);
					break;
				case RiskBoxState.RISK_BOX_CANGETREWARD:
				{
					transform3.gameObject.SetActive(true);
					bool flag3 = this.m_boxFxs[slot] == null;
					if (flag3)
					{
						this.m_boxFxs[slot] = XSingleton<XFxMgr>.singleton.CreateFx(this.BoxEffectPath, null, true);
					}
					else
					{
						this.m_boxFxs[slot].SetActive(true);
					}
					this.m_boxFxs[slot].Play(transform3, Vector3.zero, Vector3.one, 1f, true, false);
					this.m_BoxSlotTween.SetTargetGameObject(ixuitexture.gameObject);
					this.m_BoxSlotTween.PlayTween(true, -1f);
					break;
				}
				}
				ixuisprite.ID = (ulong)((long)slot);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnBoxSlotClicked));
			}
		}

		protected void OnBoxSlotClicked(IXUISprite sp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			if (!flag)
			{
				int num = (int)sp.ID;
				bool flag2 = this._doc.SlotBoxInfo.ContainsKey(num);
				if (flag2)
				{
					ClientBoxInfo clientBoxInfo = this._doc.SlotBoxInfo[num];
					bool flag3 = clientBoxInfo != null;
					if (flag3)
					{
						bool flag4 = clientBoxInfo.state == RiskBoxState.RISK_BOX_LOCKED || clientBoxInfo.state == RiskBoxState.RISK_BOX_UNLOCKED;
						if (flag4)
						{
							this.HideDice();
							this.m_OpenBoxHandler.ShowBox(num);
						}
						else
						{
							this._doc.ChangeBoxState(num, RiskBoxState.RISK_BOX_GETREWARD);
						}
					}
				}
			}
		}

		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		public void MoveStep(Vector2 targetPos)
		{
			XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_Anim_DiceGame_CharacterMove", true, AudioChannel.Action);
			this.PlayerTween.SetPositionTweenPos(0, this.PlayerAvatar.gameObject.transform.parent.localPosition, targetPos);
			this.PlayerTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnMoveStepOver));
			this.PlayerTween.PlayTween(true, -1f);
		}

		protected void OnMoveStepOver(IXUITweenTool tween)
		{
			XSingleton<XAudioMgr>.singleton.StopUISound();
			this._doc.OnGoStepOver();
		}

		public void ResetMapAni()
		{
			this.m_bIsPlayingResetAnimation = true;
			this.ResetTween.gameObject.SetActive(true);
			this.ResetTween.SetTweenGroup(0);
			this.ResetTween.ResetTweenByGroup(true, 0);
			this.ResetTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnResetMapOver));
			this.ResetTween.PlayTween(true, -1f);
		}

		protected void OnResetMapOver(IXUITweenTool tween)
		{
			this.m_bIsPlayingResetAnimation = false;
		}

		private void _OnRollClick(IXUISprite uiSprite)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NoDice"), "fece00");
		}

		private bool _OnRollPress(IXUISprite uiSprite, bool isPressed)
		{
			if (isPressed)
			{
				bool flag = this._doc.StartRoll() && !this.m_bIsPlayingResetAnimation;
				if (flag)
				{
					this.m_rollBarGo.SetActive(true);
					bool flag2 = this.m_scrollFx == null;
					if (flag2)
					{
						this.m_scrollFx = XSingleton<XFxMgr>.singleton.CreateFx(this.ScrollEffectPath, null, true);
					}
					else
					{
						this.m_scrollFx.SetActive(true);
					}
					this.m_scrollFx.Play(this.m_rollFx.FindChild("FX"), Vector3.one, Vector3.one, 1f, true, false);
					this.HideDice();
					this.m_rollTween.SetTweenGroup(10);
					this.m_rollTween.PlayTween(true, -1f);
					this.m_rollTween.SetTweenGroup(4);
					this.m_rollTween.PlayTween(true, -1f);
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_Button_Dice", true, AudioChannel.Behit);
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_Loop_Dice", true, AudioChannel.Action);
				}
			}
			else
			{
				bool flag3 = this._doc.GameState == SuperRiskState.SuperRiskRolling;
				if (flag3)
				{
					this.m_rollBarGo.SetActive(false);
					bool flag4 = this.m_scrollFx != null;
					if (flag4)
					{
						this.m_scrollFx.SetActive(false);
						this.m_scrollFx.Stop();
					}
					this.m_rollTween.ResetTweenByGroup(true, 10);
					this.m_rollTween.StopTweenByGroup(4);
					float z = this.m_rollFx.localRotation.eulerAngles.z;
					int rollResult = this.GetRollResult(z);
					XSingleton<XAudioMgr>.singleton.StopUISound();
					this._doc.GameState = SuperRiskState.SuperRiskSendingRollMes;
					this._doc.RequestDicing(rollResult);
				}
			}
			return true;
		}

		protected int GetRollResult(float pos)
		{
			float num = 75f;
			float num2 = 0f;
			float num3 = (num - pos) / (num - num2);
			bool flag = (double)num3 <= 0.333;
			int result;
			if (flag)
			{
				result = 2;
			}
			else
			{
				bool flag2 = num3 <= 0.667f;
				if (flag2)
				{
					result = 4;
				}
				else
				{
					result = 6;
				}
			}
			return result;
		}

		private static void _PlayDice(XGameObject gameObject, object o, int commandID)
		{
			SuperRiskGameHandler superRiskGameHandler = o as SuperRiskGameHandler;
			bool flag = superRiskGameHandler != null;
			if (flag)
			{
				bool flag2 = superRiskGameHandler.m_controller == null;
				if (flag2)
				{
					Transform transform = gameObject.Find("");
					bool flag3 = transform != null;
					if (flag3)
					{
						superRiskGameHandler.m_controller = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
					}
				}
				bool flag4 = superRiskGameHandler.m_controller != null;
				if (flag4)
				{
					superRiskGameHandler.m_controller.localRotation = superRiskGameHandler.ValueToQuaternion(superRiskGameHandler.m_DiceAnimValue);
				}
				int num = XSingleton<XCommon>.singleton.RandomInt(0, 5);
				string animationGetLength = (num > 0) ? (superRiskGameHandler.m_DiceDummy.Present.PresentLib.Idle + "_0" + num.ToString()) : superRiskGameHandler.m_DiceDummy.Present.PresentLib.Idle;
				SuperRiskGameHandler.DiceAnimationTime = superRiskGameHandler.m_DiceDummy.SetAnimationGetLength(animationGetLength);
				bool flag5 = superRiskGameHandler.m_DiceDummy.Ator != null;
				if (flag5)
				{
					superRiskGameHandler.m_DiceDummy.Ator.RealPlay();
				}
				superRiskGameHandler.m_DiceTimer = XSingleton<XTimerMgr>.singleton.SetTimer(SuperRiskGameHandler.DiceAnimationTime, new XTimerMgr.ElapsedEventHandler(superRiskGameHandler.OnDiceAnimationOver), superRiskGameHandler.m_DiceAnimValue);
			}
		}

		public void PlayDiceAnimation(int value)
		{
			bool flag = this.m_DiceDummy == null;
			if (flag)
			{
				this.m_DiceDummy = XSingleton<XEntityMgr>.singleton.CreateDummy(5102U, 0U, null, false, false, true);
			}
			XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_Anim_Dice", true, AudioChannel.Action);
			this.m_DiceDummy.EngineObject.SetActive(true, "");
			this.m_DiceDummy.EngineObject.SetParentTrans(this.m_DiceDummyPoint);
			this.m_DiceDummy.EngineObject.SetLocalPRS(Vector3.zero, true, Quaternion.identity, false, new Vector3(320f, 320f, 320f), true);
			this.m_DiceAnimValue = value;
			this.m_DiceDummy.EngineObject.CallCommand(SuperRiskGameHandler._playDiceCb, this, -1, false);
		}

		protected Quaternion ValueToQuaternion(int value)
		{
			Quaternion result;
			switch (value)
			{
			case 1:
				result = Quaternion.Euler(180f, 0f, 0f);
				break;
			case 2:
				result = Quaternion.Euler(0f, 90f, 0f);
				break;
			case 3:
				result = Quaternion.Euler(90f, 0f, 0f);
				break;
			case 4:
				result = Quaternion.Euler(0f, 270f, 0f);
				break;
			case 5:
				result = Quaternion.Euler(270f, 0f, 0f);
				break;
			case 6:
				result = Quaternion.Euler(0f, 0f, 0f);
				break;
			default:
				result = Quaternion.identity;
				break;
			}
			return result;
		}

		protected void OnDiceAnimationOver(object o)
		{
			XSingleton<XAudioMgr>.singleton.StopUISound();
			int num = (int)o;
			XSingleton<XDebug>.singleton.AddLog("go" + num, null, null, null, null, null, XDebugColor.XDebug_None);
			this._doc.Go(num);
		}

		public void PlayGetBoxAnimation(uint itemID, int slot)
		{
			this.HideDice();
			XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_Anim_DiceGame_ChestDrop", true, AudioChannel.Action);
			this.m_GetBoxFrame.SetActive(true);
			this.m_CacheItemID = itemID;
			this.m_CacheSlot = slot;
			IXUITexture ixuitexture = this.m_GetBoxFrame.transform.Find("Box").GetComponent("XUITexture") as IXUITexture;
			ixuitexture.SetTexturePath(this.GetBoxPicByState(itemID, RiskBoxState.RISK_BOX_LOCKED));
			GameObject gameObject = this.m_GetBoxFrame.transform.Find("FX").gameObject;
			this.m_GetBoxTween.SetTargetGameObject(gameObject);
			this.m_GetBoxTween.SetTweenGroup(0);
			this.m_GetBoxTween.PlayTween(true, -1f);
			this.m_GetBoxTween.SetTargetGameObject(ixuitexture.gameObject);
			this.m_GetBoxTween.SetTweenGroup(0);
			this.m_GetBoxTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.BoxFlyInOver));
			this.m_GetBoxTween.PlayTween(true, -1f);
		}

		protected void BoxFlyInOver(IXUITweenTool tween)
		{
			GameObject gameObject = this.m_GetBoxFrame.transform.Find("Box").gameObject;
			List<GameObject> list = ListPool<GameObject>.Get();
			this.SlotBoxPool.GetActiveList(list);
			Transform transform = list[this.m_CacheSlot].transform;
			ListPool<GameObject>.Release(list);
			Vector3 vector = gameObject.transform.parent.InverseTransformPoint(transform.position);
			this.m_GetBoxTween.SetTargetGameObject(gameObject);
			XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_Anim_DiceGame_ChestDrop", true, AudioChannel.Action);
			this.m_GetBoxTween.SetPositionTweenPos(2, new Vector3(0f, -128f), vector + new Vector3(0f, -34f));
			this.m_GetBoxTween.SetTweenGroup(2);
			this.m_GetBoxTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.ShowBoxOver));
			this.m_GetBoxTween.PlayTween(true, -1f);
		}

		protected void ShowBoxOver(IXUITweenTool tween)
		{
			this.m_GetBoxFrame.SetActive(false);
			IXUITexture ixuitexture = this.m_GetBoxFrame.transform.Find("Box").GetComponent("XUITexture") as IXUITexture;
			ixuitexture.SetTexturePath("");
			this.UpdateSlotBox(this.m_CacheSlot);
			XSingleton<XAudioMgr>.singleton.StopUISound();
			this._doc.OnGetBoxAnimationOver();
		}

		public void UpdateSlotBox(int slot)
		{
			Transform transform = base.PanelObject.transform.Find("BoxSlot/slot" + slot);
			bool flag = transform == null;
			if (!flag)
			{
				GameObject gameObject = transform.gameObject;
				bool flag2 = this._doc.SlotBoxInfo.ContainsKey(slot);
				if (flag2)
				{
					ClientBoxInfo info = this._doc.SlotBoxInfo[slot];
					this.SetupSlotBox(gameObject, info, slot);
				}
				else
				{
					this.SetupSlotBox(gameObject, null, slot);
				}
				bool flag3 = this.m_OpenBoxHandler != null && this.m_OpenBoxHandler.IsVisible();
				if (flag3)
				{
					this.m_OpenBoxHandler.BoxStateChange(slot);
				}
			}
		}

		public void ShowOnlineBox()
		{
			bool flag = !this.m_OnlineBoxHandler.IsVisible();
			if (flag)
			{
				this.m_OnlineBoxHandler.SetVisible(true);
			}
		}

		public void CloseOnlineBox()
		{
			bool flag = this.m_OnlineBoxHandler.IsVisible();
			if (flag)
			{
				this.m_OnlineBoxHandler.SetVisible(false);
			}
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._doc == null;
			if (!flag)
			{
				bool flag2 = this._doc.RefreshDiceTime < 0f;
				if (flag2)
				{
					this.m_RecoverFullLab.gameObject.SetActive(true);
					this.m_RecoverFullLab.SetText(XStringDefineProxy.GetString("ReplyDiceFullTips"));
					this.m_RecoverTime.gameObject.SetActive(false);
				}
				else
				{
					this.m_RecoverTime.gameObject.SetActive(true);
					this.m_RecoverTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)this._doc.RefreshDiceTime, 2, 3, 4, false, true));
					this.m_RecoverFullLab.gameObject.SetActive(false);
				}
				int num = 0;
				while ((long)num < (long)((ulong)SuperRiskGameHandler.total_slot_box))
				{
					bool flag3 = this._doc.SlotBoxInfo.ContainsKey(num);
					if (flag3)
					{
						bool flag4 = this._doc.SlotBoxInfo[num] != null && this._doc.SlotBoxInfo[num].state == RiskBoxState.RISK_BOX_UNLOCKED;
						if (flag4)
						{
							float leftTime = this._doc.SlotBoxInfo[num].leftTime;
							bool flag5 = this.m_CachedBoxSlotTimeLabel[num] != null;
							if (flag5)
							{
								this.m_CachedBoxSlotTimeLabel[num].SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)leftTime, 2, 3, 4, false, true));
								this.SetCost(this._doc.SlotBoxInfo[num], this.m_CachedBoxCostLabel[num]);
							}
						}
					}
					num++;
				}
				bool flag6 = this.m_OpenBoxHandler != null;
				if (flag6)
				{
					this.m_OpenBoxHandler.OnUpdate();
				}
			}
		}

		private void SetCost(ClientBoxInfo data, IXUILabelSymbol lab)
		{
			bool flag = data == null;
			if (flag)
			{
				lab.InputText = XLabelSymbolHelper.FormatCostWithIcon(0, (ItemEnum)0);
			}
			else
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)data.itemID);
				bool flag2 = itemConf == null;
				if (flag2)
				{
					lab.InputText = XLabelSymbolHelper.FormatCostWithIcon(0, (ItemEnum)0);
				}
				else
				{
					int itemQuality = (int)itemConf.ItemQuality;
					SuperRiskSpeedCost speedCost = this._doc.GetSpeedCost(itemQuality);
					bool flag3 = (int)data.leftTime % speedCost.time == 0;
					int cost;
					if (flag3)
					{
						cost = (int)data.leftTime / speedCost.time * speedCost.itemCount;
					}
					else
					{
						cost = ((int)data.leftTime / speedCost.time + 1) * speedCost.itemCount;
					}
					lab.InputText = XLabelSymbolHelper.FormatCostWithIcon(cost, (ItemEnum)speedCost.itemID);
				}
			}
		}

		public void ShowNoticeFrame()
		{
			this.HideDice();
			this.m_NoticeFrame.SetActive(true);
		}

		protected bool _NoticeYesClick(IXUIButton sp)
		{
			this.m_NoticeFrame.SetActive(false);
			return true;
		}

		protected bool _NoticeNoClick(IXUIButton sp)
		{
			this.m_NoticeFrame.SetActive(false);
			this._doc.NoticeMoveOver();
			return true;
		}

		private void OnClickDiscardBox(IXUISprite sp)
		{
			this.m_discardBoxId = (int)sp.ID;
			ClientBoxInfo clientBoxInfo = this._doc.SlotBoxInfo[this.m_discardBoxId];
			bool flag = clientBoxInfo == null;
			if (!flag)
			{
				bool flag2 = clientBoxInfo.state == RiskBoxState.RISK_BOX_CANGETREWARD;
				if (!flag2)
				{
					string @string = XStringDefineProxy.GetString("DiscardSuperriskBox");
					XSingleton<UiUtility>.singleton.ShowModalDialog(@string, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.SendDiscardBoxMes));
				}
			}
		}

		private bool SendDiscardBoxMes(IXUIButton btn)
		{
			this._doc.ChangeBoxState(this.m_discardBoxId, RiskBoxState.RISK_BOX_DELETE);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private bool OnCloseClick(IXUIButton go)
		{
			bool flag = this._doc.GameState == SuperRiskState.SuperRiskSendingRollMes || this._doc.GameState == SuperRiskState.SuperRiskRolling || this._doc.GameState == SuperRiskState.SuperRiskDicing || this._doc.GameState == SuperRiskState.SuperRiskMoving || this._doc.GameState == SuperRiskState.SuperRiskEvent || this._doc.GameState == SuperRiskState.SuperRiskRefreshMap;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._doc.GameState = SuperRiskState.SuperRiskReadyToMove;
				bool flag2 = DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.ShowSelectMap();
				}
				result = true;
			}
			return result;
		}

		private readonly Color GreyColor = new Color(0.3019608f, 0.3019608f, 0.3019608f, 1f);

		private readonly Color NormalColor = new Color(1f, 1f, 1f, 1f);

		private XSuperRiskDocument _doc;

		private XWelfareDocument _welfareDoc;

		private IXUISprite PlayerAvatar = null;

		private IXUITweenTool PlayerTween = null;

		private IXUITweenTool ResetTween = null;

		public static uint total_slot_box = 3U;

		private IXUIButton m_Close;

		private IXUIButton m_Help;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUISprite m_rollBtn;

		private IXUITweenTool m_rollTween;

		private Transform m_rollFx;

		private GameObject m_rollBarGo;

		private Dictionary<RiskGridInfo, GameObject> m_MapItems = new Dictionary<RiskGridInfo, GameObject>();

		private Transform m_DiceDummyPoint;

		private XDummy m_DiceDummy;

		private Transform m_controller;

		private int m_DiceAnimValue = 0;

		private static float DiceAnimationTime = 2f;

		private uint m_DiceTimer;

		private IXUILabel m_LeftTime;

		private IXUILabel m_RecoverTime;

		private IXUILabel m_mapTittleLab;

		private IXUILabel m_RecoverFullLab;

		private IXUISprite m_PrerogativeSpr;

		private IXUILabel m_PrerogativeLab;

		private IXUISprite m_PrerogativeBg;

		private XUIPool SlotBoxPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUILabel[] m_CachedBoxSlotTimeLabel = new IXUILabel[3];

		private IXUILabelSymbol[] m_CachedBoxCostLabel = new IXUILabelSymbol[3];

		private IXUITweenTool m_BoxSlotTween;

		private GameObject m_GetBoxFrame;

		private IXUITweenTool m_GetBoxTween;

		private uint m_CacheItemID;

		private int m_CacheSlot;

		private Transform m_theEndTra;

		private IXUITexture m_mapTexture;

		public GameObject m_OpenBoxFrame;

		private GameObject m_OnlineBoxFrame;

		private SuperRiskOpenboxHandler m_OpenBoxHandler;

		private SuperRiskOnlineBoxHandler m_OnlineBoxHandler;

		private bool m_bIsPlayingResetAnimation = false;

		public GameObject m_NoticeFrame;

		public IXUIButton m_NoticeYes;

		private float m_fCoolTime = 0.7f;

		private float m_fLastClickBtnTime = 0f;

		private static CommandCallback _playDiceCb = new CommandCallback(SuperRiskGameHandler._PlayDice);

		private XFx m_scrollFx;

		private List<XFx> m_dungeonFxs = new List<XFx>();

		private XFx[] m_boxFxs = new XFx[3];

		private string m_scrollEffectPath = string.Empty;

		private string m_dungeonEffectPath = string.Empty;

		private string m_boxEffectPath = string.Empty;

		private int m_discardBoxId = 0;
	}
}
