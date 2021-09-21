using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BA9 RID: 2985
	internal class LevelRewardSelectChestHandler : DlgHandlerBase
	{
		// Token: 0x1700304D RID: 12365
		// (get) Token: 0x0600AB23 RID: 43811 RVA: 0x001F0FCC File Offset: 0x001EF1CC
		public LevelRewardSelectChestHandler.SelectChestStatus CurrentStatus
		{
			get
			{
				return this._select_chest_status;
			}
		}

		// Token: 0x1700304E RID: 12366
		// (get) Token: 0x0600AB24 RID: 43812 RVA: 0x001F0FE4 File Offset: 0x001EF1E4
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardSelectChestFrame";
			}
		}

		// Token: 0x0600AB25 RID: 43813 RVA: 0x001F0FFB File Offset: 0x001EF1FB
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

		// Token: 0x0600AB26 RID: 43814 RVA: 0x001F101C File Offset: 0x001EF21C
		private void InitUI()
		{
			this.m_button_frame = base.PanelObject.transform.Find("Bg/Button");
			this.m_battle_data_button = (base.PanelObject.transform.Find("Bg/Button/BattleData").GetComponent("XUIButton") as IXUIButton);
			this.m_reStartBtn = (base.PanelObject.transform.Find("Bg/Button/ReStart").GetComponent("XUIButton") as IXUIButton);
			this.m_return_button = (base.PanelObject.transform.Find("Bg/Button/Return").GetComponent("XUIButton") as IXUIButton);
			this.m_return_label = (base.PanelObject.transform.Find("Bg/Button/Return/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_player_tween = (base.PanelObject.transform.Find("Bg/Player").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_team_tween = (base.PanelObject.transform.Find("Bg/TeamPanel").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_player_avatar = (base.PanelObject.transform.Find("Bg/Player/Detail/Avatar").GetComponent("XUISprite") as IXUISprite);
			this.m_player_name = (base.PanelObject.transform.Find("Bg/Player/Detail/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_player_level = (base.PanelObject.transform.Find("Bg/Player/Detail/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_player_leader = (base.PanelObject.transform.Find("Bg/Player/Detail/Leader").GetComponent("XUISprite") as IXUISprite);
			this.m_player_helper = base.PanelObject.transform.Find("Bg/Player/Detail/Helper");
			for (int i = 0; i < 3; i++)
			{
				this.m_player_stars[i] = base.PanelObject.transform.Find(string.Format("Bg/Player/Detail/Stars/Star{0}", i + 1));
			}
			this.m_player_chest_list = base.PanelObject.transform.Find("Bg/Player/ItemList");
			Transform transform = base.PanelObject.transform.Find("Bg/Player/ItemList/BoxTpl");
			this.m_player_chest_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			transform = base.PanelObject.transform.Find("Bg/TeamPanel/OtherPlayer");
			this.m_others_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			this.m_watch = (base.PanelObject.transform.Find("Watch").GetComponent("XUILabel") as IXUILabel);
			this.m_like = (base.PanelObject.transform.Find("Like").GetComponent("XUILabel") as IXUILabel);
			this.m_left_time = (base.PanelObject.transform.Find("Bg/Player/LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.m_select_chest_tip = (base.PanelObject.transform.Find("Bg/Player/ItemList/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_helper_tip = base.PanelObject.transform.Find("Bg/Player/HelperTip");
			this.m_noneReward_tip = base.PanelObject.transform.Find("Bg/Player/NoneRewardTip");
		}

		// Token: 0x0600AB27 RID: 43815 RVA: 0x001F13A4 File Offset: 0x001EF5A4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_battle_data_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleDataButtonClicked));
			this.m_reStartBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReStartCkicked));
			this.m_return_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
		}

		// Token: 0x0600AB28 RID: 43816 RVA: 0x001F1404 File Offset: 0x001EF604
		private bool OnBattleDataButtonClicked(IXUIButton button)
		{
			DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowBattleDataFrame();
			return true;
		}

		// Token: 0x0600AB29 RID: 43817 RVA: 0x001F1424 File Offset: 0x001EF624
		private bool OnReStartCkicked(IXUIButton btn)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.ReqTeamOp(TeamOperate.TEAM_BATTLE_CONTINUE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
			return true;
		}

		// Token: 0x0600AB2A RID: 43818 RVA: 0x001F1450 File Offset: 0x001EF650
		private bool OnReturnButtonClicked(IXUIButton button)
		{
			bool flag = this.doc.CurrentStage == SceneType.SCENE_DRAGON && !this.doc.IsEndLevel;
			if (flag)
			{
				base.SetVisible(false);
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisiblePure(true);
				}
				string sceneBGM = XSingleton<XSceneMgr>.singleton.GetSceneBGM(XSingleton<XScene>.singleton.SceneID);
				XSingleton<XAudioMgr>.singleton.PlayBGM(sceneBGM);
			}
			else
			{
				this.doc.SendLeaveScene();
			}
			return true;
		}

		// Token: 0x0600AB2B RID: 43819 RVA: 0x001F14DC File Offset: 0x001EF6DC
		protected override void OnShow()
		{
			base.OnShow();
			this._select_chest_status = LevelRewardSelectChestHandler.SelectChestStatus.Begin;
			this._has_show_others = false;
			this.ShowPlayerChest();
			bool flag = XSpectateSceneDocument.WhetherWathchNumShow((int)this.doc.WatchCount, (int)this.doc.LikeCount, (int)this.doc.CurrentStage);
			if (flag)
			{
				this.m_watch.SetVisible(true);
				this.m_like.SetVisible(true);
				this.m_watch.SetText(this.doc.WatchCount.ToString());
				this.m_like.SetText(this.doc.LikeCount.ToString());
			}
			else
			{
				this.m_watch.SetVisible(false);
				this.m_like.SetVisible(false);
			}
			bool flag2 = this.doc.CurrentStage == SceneType.SCENE_DRAGON && !this.doc.IsEndLevel;
			if (flag2)
			{
				this.m_return_label.SetText(XStringDefineProxy.GetString("LEVEL_FINISH_CONTINUE"));
			}
			else
			{
				this.m_return_label.SetText(XStringDefineProxy.GetString("LEVEL_FINISH_LEAVE_SCENE"));
			}
			this._target_time = Time.time + (float)this.doc.SelectChestFrameData.SelectLeftTime;
			this.m_button_frame.gameObject.SetActive(false);
		}

		// Token: 0x0600AB2C RID: 43820 RVA: 0x001F1630 File Offset: 0x001EF830
		private void ClearTexture(string path)
		{
			for (int i = 0; i < 4; i++)
			{
				Transform transform = base.PanelObject.transform.Find(string.Format(string.Format("{0}{1}", path, "/Box{0}/Box"), i + 1));
				bool flag = transform == null;
				if (!flag)
				{
					IXUITexture ixuitexture = transform.GetComponent("XUITexture") as IXUITexture;
					bool flag2 = ixuitexture != null;
					if (flag2)
					{
						ixuitexture.SetTexturePath("");
					}
				}
			}
		}

		// Token: 0x0600AB2D RID: 43821 RVA: 0x001F16B8 File Offset: 0x001EF8B8
		public override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._show_item_token);
			this.ClearTexture("Bg/Player/ItemList");
			for (int i = 0; i < this.doc.SelectChestFrameData.Others.Count; i++)
			{
				this.ClearTexture(string.Format("Bg/TeamPanel/{0}/ItemList", this.doc.SelectChestFrameData.Others[i].uid));
			}
			base.OnUnload();
		}

		// Token: 0x0600AB2E RID: 43822 RVA: 0x001F1754 File Offset: 0x001EF954
		public void ShowAllChest()
		{
			bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				this._select_chest_status = LevelRewardSelectChestHandler.SelectChestStatus.SelectFinish;
				XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_ClearBox_Cursor_Select", true, AudioChannel.Action);
				this.ShowPlayerChestGlow(this.doc.SelectChestFrameData.Player.BoxID);
				this.SetupChestList(this.doc.SelectChestFrameData.Player.chestList, this.doc.SelectChestFrameData.Player.BoxID, "Bg/Player/ItemList");
				for (int i = 0; i < this.doc.SelectChestFrameData.Others.Count; i++)
				{
					bool flag2 = this.doc.SelectChestFrameData.Others[i].BoxID == 0;
					if (flag2)
					{
						this.ShowOthersChestGlow(this.doc.SelectChestFrameData.Others[i].uid, 1);
					}
					this.SetupChestList(this.doc.SelectChestFrameData.Others[i].chestList, this.doc.SelectChestFrameData.Others[i].BoxID, string.Format("Bg/TeamPanel/{0}/ItemList", this.doc.SelectChestFrameData.Others[i].uid));
				}
				this.RefreshSelectChest();
				this._show_item_token = XSingleton<XTimerMgr>.singleton.SetTimer(2f, new XTimerMgr.ElapsedEventHandler(this.ShowAllItem), null);
			}
		}

		// Token: 0x0600AB2F RID: 43823 RVA: 0x001F18E8 File Offset: 0x001EFAE8
		private void SetupChestList(List<BattleRewardChest> list, int boxid, string path)
		{
			boxid = ((boxid == 0) ? 1 : boxid);
			for (int i = 0; i < list.Count; i++)
			{
				Transform transform = base.PanelObject.transform.Find(string.Format(string.Format("{0}{1}", path, "/Box{0}/Box"), i + 1));
				bool flag = transform == null;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddGreenLog(string.Format("{0} not found!!!", path), null, null, null, null, null);
				}
				else
				{
					IXUITexture ixuitexture = transform.GetComponent("XUITexture") as IXUITexture;
					transform = base.PanelObject.transform.Find(string.Format(string.Format("{0}{1}", path, "/Box{0}/Light"), i + 1));
					bool flag2 = transform == null;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddGreenLog(string.Format("{0} not found!!!", path), null, null, null, null, null);
					}
					else
					{
						IXUITweenTool ixuitweenTool = transform.GetComponent("XUIPlayTween") as IXUITweenTool;
						ixuitweenTool.PlayTween(true, -1f);
						IXUISprite ixuisprite = base.PanelObject.transform.Find(string.Format("Bg/Player/ItemList/Box{0}/Magnifier", i + 1)).GetComponent("XUISprite") as IXUISprite;
						ixuisprite.SetVisible(false);
						string texturePath = string.Format("atlas/UI/Battle/bx_{0}", 5 - list[i].chestType);
						bool flag3 = list[i].chestType == 0;
						if (flag3)
						{
							texturePath = "";
						}
						ixuitexture.SetTexturePath(texturePath);
					}
				}
			}
		}

		// Token: 0x0600AB30 RID: 43824 RVA: 0x001F1A8C File Offset: 0x001EFC8C
		private void ShowAllItem(object o = null)
		{
			bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_ClearBox_Open", true, AudioChannel.Action);
				this._target_time = 0f;
				this.SetupChestItem(this.doc.SelectChestFrameData.Player.chestList, this.doc.SelectChestFrameData.Player.BoxID, "Bg/Player/ItemList");
				for (int i = 0; i < this.doc.SelectChestFrameData.Others.Count; i++)
				{
					this.SetupChestItem(this.doc.SelectChestFrameData.Others[i].chestList, this.doc.SelectChestFrameData.Others[i].BoxID, string.Format("Bg/TeamPanel/{0}/ItemList", this.doc.SelectChestFrameData.Others[i].uid));
				}
				this.m_button_frame.gameObject.SetActive(true);
				this.doc.ShowFirstPassShareView();
				bool flag2 = this.doc.CurrentStage == SceneType.SCENE_GODDESS || this.doc.CurrentStage == SceneType.SCENE_ENDLESSABYSS;
				if (flag2)
				{
					this.m_battle_data_button.gameObject.SetActive(false);
					XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
					bool flag3 = !specificDocument.bIsLeader;
					if (flag3)
					{
						this.m_reStartBtn.gameObject.SetActive(false);
					}
					else
					{
						XExpeditionDocument specificDocument2 = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
						int num = 0;
						bool flag4 = this.doc.CurrentStage == SceneType.SCENE_GODDESS;
						if (flag4)
						{
							num = specificDocument2.GetDayCount(TeamLevelType.TeamLevelGoddessTrial, null);
						}
						else
						{
							bool flag5 = this.doc.CurrentStage == SceneType.SCENE_ENDLESSABYSS;
							if (flag5)
							{
								num = specificDocument2.GetDayCount(TeamLevelType.TeamLevelEndlessAbyss, null);
							}
						}
						bool flag6 = num - 1 <= 0;
						if (flag6)
						{
							this.m_reStartBtn.gameObject.SetActive(false);
						}
						else
						{
							this.m_reStartBtn.gameObject.SetActive(true);
						}
					}
				}
				else
				{
					this.m_battle_data_button.gameObject.SetActive(true);
					this.m_reStartBtn.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0600AB31 RID: 43825 RVA: 0x001F1CD4 File Offset: 0x001EFED4
		private void SetupChestItem(List<BattleRewardChest> list, int boxid, string path)
		{
			boxid = ((boxid == 0) ? 1 : boxid);
			for (int i = 0; i < list.Count; i++)
			{
				Transform transform = base.PanelObject.transform.Find(string.Format(string.Format("{0}{1}", path, "/Box{0}/Box"), i + 1));
				bool flag = transform == null;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddGreenLog(string.Format("{0} not found!!!", path), null, null, null, null, null);
				}
				else
				{
					IXUITexture ixuitexture = transform.GetComponent("XUITexture") as IXUITexture;
					transform = base.PanelObject.transform.Find(string.Format(string.Format("{0}{1}", path, "/Box{0}/Item"), i + 1));
					bool flag2 = transform == null;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddGreenLog(string.Format("{0} not found!!!", path), null, null, null, null, null);
					}
					else
					{
						GameObject gameObject = transform.gameObject;
						transform = gameObject.transform.Find("Icon");
						bool flag3 = transform == null;
						if (flag3)
						{
							XSingleton<XDebug>.singleton.AddGreenLog(string.Format("{0} not found!!!", path), null, null, null, null, null);
						}
						else
						{
							IXUISprite ixuisprite = transform.GetComponent("XUISprite") as IXUISprite;
							gameObject.SetActive(true);
							XItemDrawerMgr.Param.bBinding = list[i].isbind;
							XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, list[i].itemID, list[i].itemCount, false);
							ixuisprite.ID = (ulong)((long)list[i].itemID);
							ixuitexture.SetVisible(false);
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
						}
					}
				}
			}
		}

		// Token: 0x0600AB32 RID: 43826 RVA: 0x001F1EA8 File Offset: 0x001F00A8
		private void OnChestClicked(IXUISprite sp)
		{
			bool flag = this.doc.SelectChestFrameData.Player.BoxID != 0;
			if (!flag)
			{
				this.doc.SendSelectChest((uint)sp.ID);
				XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_ClearBox_Cursor_On", true, AudioChannel.Action);
			}
		}

		// Token: 0x0600AB33 RID: 43827 RVA: 0x001F1EF9 File Offset: 0x001F00F9
		private void OnMagnifierClicked(IXUISprite sp)
		{
			this.doc.SendPeerChest((uint)sp.ID);
		}

		// Token: 0x0600AB34 RID: 43828 RVA: 0x001EA11D File Offset: 0x001E831D
		private void OnAddFriendClick(IXUISprite sp)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(sp.ID);
		}

		// Token: 0x0600AB35 RID: 43829 RVA: 0x001EA131 File Offset: 0x001E8331
		private void OnAddOtherServerFriendClick(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ADD_OTHER_SERVER_FRIEND"), "fece00");
		}

		// Token: 0x0600AB36 RID: 43830 RVA: 0x001F1F10 File Offset: 0x001F0110
		public void RefreshSelectChest()
		{
			bool flag = false;
			this.ShowPlayerChestGlow(this.doc.SelectChestFrameData.Player.BoxID);
			bool flag2 = this.doc.SelectChestFrameData.Player.BoxID == 0;
			if (flag2)
			{
				flag = true;
			}
			for (int i = 0; i < this.doc.SelectChestFrameData.Others.Count; i++)
			{
				this.ShowOthersChestGlow(this.doc.SelectChestFrameData.Others[i].uid, this.doc.SelectChestFrameData.Others[i].BoxID);
				bool flag3 = this.doc.SelectChestFrameData.Others[i].BoxID == 0;
				if (flag3)
				{
					flag = true;
				}
			}
			bool flag4 = !flag && this._select_chest_status != LevelRewardSelectChestHandler.SelectChestStatus.SelectFinish;
			if (flag4)
			{
				this.doc.SendQueryBoxs(false);
			}
			this._token = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.ShowOthersChest), null);
		}

		// Token: 0x0600AB37 RID: 43831 RVA: 0x001F2030 File Offset: 0x001F0230
		private void ShowPlayerChest()
		{
			this.m_player_name.SetText(this.doc.SelectChestFrameData.Player.Name);
			this.m_player_level.SetText(this.doc.SelectChestFrameData.Player.Level.ToString());
			this.m_player_avatar.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(this.doc.SelectChestFrameData.Player.ProfID));
			this.m_player_leader.SetVisible(this.doc.SelectChestFrameData.Player.isLeader);
			this.m_player_helper.gameObject.SetActive(this.doc.SelectChestFrameData.Player.isHelper);
			for (int i = 0; i < 3; i++)
			{
				this.m_player_stars[i].gameObject.SetActive((long)i < (long)((ulong)this.doc.SelectChestFrameData.Player.Rank));
			}
			this.m_player_chest_pool.ReturnAll(false);
			float num = this.m_player_chest_pool.TplPos.x;
			for (int j = 0; j < 4; j++)
			{
				GameObject gameObject = this.m_player_chest_pool.FetchGameObject(false);
				IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
				Transform transform = gameObject.transform.Find("glow");
				GameObject gameObject2 = gameObject.transform.Find("Item").gameObject;
				GameObject gameObject3 = gameObject.transform.Find("Light").gameObject;
				IXUISprite ixuisprite2 = gameObject.transform.Find("Magnifier").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = gameObject.transform.Find("Magnifier/Num").GetComponent("XUILabel") as IXUILabel;
				ixuisprite.ID = (ulong)((long)j + 1L);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChestClicked));
				transform.gameObject.SetActive(false);
				gameObject.name = string.Format("Box{0}", j + 1);
				gameObject.transform.localPosition = new Vector3(num, this.m_player_chest_pool.TplPos.y);
				num += (float)this.m_player_chest_pool.TplWidth;
				gameObject2.SetActive(false);
				gameObject3.SetActive(false);
				ixuisprite2.SetVisible(this.doc.CanPeerBox);
				ixuisprite2.ID = (ulong)((long)j + 1L);
				ixuilabel.SetText(this.doc.PeerBoxCost.ToString());
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMagnifierClicked));
			}
			bool flag = this._target_time - Time.time > 0f;
			if (flag)
			{
				this.m_left_time.SetText(XStringDefineProxy.GetString("SELECT_CHEST_LEFT_TIME", new object[]
				{
					(this._target_time - Time.time).ToString("0")
				}));
			}
			else
			{
				this.m_left_time.SetText("");
			}
			this.m_select_chest_tip.SetText(XStringDefineProxy.GetString("SELECT_CHEST_TIP"));
			this.m_player_chest_list.gameObject.SetActive(!this.doc.SelectChestFrameData.Player.isHelper && !this.doc.SelectChestFrameData.Player.noneReward);
			this.m_left_time.SetVisible(true);
			this.m_helper_tip.gameObject.SetActive(this.doc.SelectChestFrameData.Player.isHelper);
			this.m_noneReward_tip.gameObject.SetActive(!this.doc.SelectChestFrameData.Player.isHelper && this.doc.SelectChestFrameData.Player.noneReward);
			bool isHelper = this.doc.SelectChestFrameData.Player.isHelper;
			if (isHelper)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
				this._token = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.ShowOthersChest), null);
			}
		}

		// Token: 0x0600AB38 RID: 43832 RVA: 0x001F2478 File Offset: 0x001F0678
		private void ShowOthersChest(object o = null)
		{
			bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				bool has_show_others = this._has_show_others;
				if (!has_show_others)
				{
					this._has_show_others = true;
					this.m_select_chest_tip.SetVisible(false);
					this.m_player_tween.PlayTween(true, -1f);
					this.m_team_tween.PlayTween(true, -1f);
					this.m_others_pool.ReturnAll(false);
					for (int i = 0; i < this.doc.SelectChestFrameData.Others.Count; i++)
					{
						GameObject gameObject = this.m_others_pool.FetchGameObject(false);
						IXUISprite ixuisprite = gameObject.transform.Find("Detail/Avatar").GetComponent("XUISprite") as IXUISprite;
						IXUILabel ixuilabel = gameObject.transform.Find("Detail/Name").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel2 = gameObject.transform.Find("Detail/Level").GetComponent("XUILabel") as IXUILabel;
						IXUISprite ixuisprite2 = gameObject.transform.Find("Detail/Leader").GetComponent("XUISprite") as IXUISprite;
						Transform transform = gameObject.transform.Find("Detail/Helper");
						IXUISprite ixuisprite3 = gameObject.transform.Find("AddFriend").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(this.doc.SelectChestFrameData.Others[i].ProfID));
						ixuilabel.SetText(this.doc.SelectChestFrameData.Others[i].Name);
						IXUILabel ixuilabel3 = ixuilabel2;
						XLevelRewardDocument.LevelRewardRoleData levelRewardRoleData = this.doc.SelectChestFrameData.Others[i];
						ixuilabel3.SetText(levelRewardRoleData.Level.ToString());
						ixuisprite2.SetVisible(this.doc.SelectChestFrameData.Others[i].isLeader);
						transform.gameObject.SetActive(this.doc.SelectChestFrameData.Others[i].isHelper);
						Transform[] array = new Transform[3];
						for (int j = 0; j < 3; j++)
						{
							array[j] = gameObject.transform.Find(string.Format("Detail/Stars/Star{0}", j + 1));
							array[j].gameObject.SetActive((long)j < (long)((ulong)this.doc.SelectChestFrameData.Others[i].Rank));
						}
						XUIPool xuipool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
						Transform transform2 = gameObject.transform.Find("ItemList/BoxTpl");
						xuipool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 4U, false);
						xuipool.ReturnAll(false);
						float num = xuipool.TplPos.x;
						for (int k = 0; k < 4; k++)
						{
							GameObject gameObject2 = xuipool.FetchGameObject(false);
							IXUISprite ixuisprite4 = gameObject2.GetComponent("XUISprite") as IXUISprite;
							Transform transform3 = gameObject2.transform.Find("glow");
							GameObject gameObject3 = gameObject2.transform.Find("Item").gameObject;
							GameObject gameObject4 = gameObject2.transform.Find("Light").gameObject;
							gameObject2.name = string.Format("Box{0}", k + 1);
							gameObject2.transform.localPosition = new Vector3(num, xuipool.TplPos.y);
							transform3.gameObject.SetActive(k + 1 == this.doc.SelectChestFrameData.Others[i].BoxID);
							num += (float)xuipool.TplWidth;
							gameObject3.SetActive(false);
							gameObject4.SetActive(false);
						}
						ixuisprite3.ID = this.doc.SelectChestFrameData.Others[i].uid;
						ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddFriendClick));
						bool flag2 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(ixuisprite3.ID) || XAttributes.GetCategory(ixuisprite3.ID) == EntityCategory.Category_DummyRole;
						if (flag2)
						{
							ixuisprite3.SetVisible(false);
						}
						else
						{
							bool flag3 = XSingleton<XClientNetwork>.singleton.ServerID == this.doc.SelectChestFrameData.Others[i].ServerID;
							if (flag3)
							{
								ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddFriendClick));
							}
							else
							{
								ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddOtherServerFriendClick));
							}
						}
						UnityEngine.Object @object = gameObject;
						levelRewardRoleData = this.doc.SelectChestFrameData.Others[i];
						@object.name = levelRewardRoleData.uid.ToString();
						float num2 = this.m_others_pool.TplPos.y - (float)(i % 3 * this.m_others_pool.TplHeight);
						num = this.m_others_pool.TplPos.x + (float)(i / 3 * this.m_others_pool.TplWidth);
						gameObject.transform.localPosition = new Vector3(num, num2);
						Transform transform4 = gameObject.transform.Find("ItemList");
						Transform transform5 = gameObject.transform.Find("HelperTip");
						Transform transform6 = gameObject.transform.Find("NoneRewardTip");
						transform4.gameObject.SetActive(!this.doc.SelectChestFrameData.Others[i].isHelper && !this.doc.SelectChestFrameData.Others[i].noneReward);
						transform5.gameObject.SetActive(this.doc.SelectChestFrameData.Others[i].isHelper);
						transform6.gameObject.SetActive(!this.doc.SelectChestFrameData.Others[i].isHelper && this.doc.SelectChestFrameData.Others[i].noneReward);
					}
				}
			}
		}

		// Token: 0x0600AB39 RID: 43833 RVA: 0x001F2AC0 File Offset: 0x001F0CC0
		public void ShowPlayerChestGlow(int index)
		{
			Transform transform = base.PanelObject.transform.Find(string.Format("Bg/Player/ItemList/Box{0}/glow", index));
			bool flag = transform != null;
			if (flag)
			{
				transform.gameObject.SetActive(true);
				this.HideMagnifier();
			}
		}

		// Token: 0x0600AB3A RID: 43834 RVA: 0x001F2B10 File Offset: 0x001F0D10
		public void ShowOthersChestGlow(ulong roleid, int index)
		{
			Transform transform = base.PanelObject.transform.Find(string.Format("Bg/TeamPanel/{0}/ItemList/Box{1}/glow", roleid, index));
			bool flag = transform != null;
			if (flag)
			{
				transform.gameObject.SetActive(true);
			}
		}

		// Token: 0x0600AB3B RID: 43835 RVA: 0x001F2B60 File Offset: 0x001F0D60
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._target_time - Time.time > 0f;
			if (flag)
			{
				this.m_left_time.SetText(XStringDefineProxy.GetString("SELECT_CHEST_LEFT_TIME", new object[]
				{
					(this._target_time - Time.time).ToString("0")
				}));
				this.doc.SendQueryBoxs(false);
			}
			else
			{
				bool flag2 = this.doc.SelectChestFrameData.SelectLeftTime != 0;
				if (flag2)
				{
					this.doc.SendQueryBoxs(true);
				}
				this.m_left_time.SetText("");
			}
		}

		// Token: 0x0600AB3C RID: 43836 RVA: 0x001F2C0C File Offset: 0x001F0E0C
		public void RefreshLeftTime()
		{
			this._target_time = Time.time + (float)this.doc.SelectChestFrameData.SelectLeftTime;
		}

		// Token: 0x0600AB3D RID: 43837 RVA: 0x001F2C2C File Offset: 0x001F0E2C
		public void SetPeerResult()
		{
			this.HideMagnifier();
			for (int i = 0; i < 4; i++)
			{
				bool flag = this.doc.SelectChestFrameData.Player.chestList[i].chestType != 0;
				if (flag)
				{
					IXUITexture ixuitexture = base.PanelObject.transform.Find(string.Format("Bg/Player/ItemList/Box{0}/Box", i + 1)).GetComponent("XUITexture") as IXUITexture;
					string texturePath = string.Format("atlas/UI/Battle/bx_{0}", 5 - this.doc.SelectChestFrameData.Player.chestList[i].chestType);
					bool flag2 = this.doc.SelectChestFrameData.Player.chestList[i].chestType == 0;
					if (flag2)
					{
						texturePath = "";
					}
					ixuitexture.SetTexturePath(texturePath);
				}
			}
		}

		// Token: 0x0600AB3E RID: 43838 RVA: 0x001F2D24 File Offset: 0x001F0F24
		private void HideMagnifier()
		{
			for (int i = 0; i < 4; i++)
			{
				IXUISprite ixuisprite = base.PanelObject.transform.Find(string.Format("Bg/Player/ItemList/Box{0}/Magnifier", i + 1)).GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetVisible(false);
			}
		}

		// Token: 0x04003FEB RID: 16363
		private XLevelRewardDocument doc = null;

		// Token: 0x04003FEC RID: 16364
		private Transform m_button_frame;

		// Token: 0x04003FED RID: 16365
		private IXUIButton m_battle_data_button;

		// Token: 0x04003FEE RID: 16366
		private IXUIButton m_reStartBtn;

		// Token: 0x04003FEF RID: 16367
		private IXUIButton m_return_button;

		// Token: 0x04003FF0 RID: 16368
		private IXUILabel m_return_label;

		// Token: 0x04003FF1 RID: 16369
		private IXUITweenTool m_player_tween;

		// Token: 0x04003FF2 RID: 16370
		private IXUITweenTool m_team_tween;

		// Token: 0x04003FF3 RID: 16371
		private IXUISprite m_player_avatar;

		// Token: 0x04003FF4 RID: 16372
		private IXUILabel m_player_name;

		// Token: 0x04003FF5 RID: 16373
		private IXUILabel m_player_level;

		// Token: 0x04003FF6 RID: 16374
		private IXUISprite m_player_leader;

		// Token: 0x04003FF7 RID: 16375
		private Transform m_player_helper;

		// Token: 0x04003FF8 RID: 16376
		private Transform[] m_player_stars = new Transform[3];

		// Token: 0x04003FF9 RID: 16377
		private Transform m_player_chest_list;

		// Token: 0x04003FFA RID: 16378
		private XUIPool m_player_chest_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003FFB RID: 16379
		private IXUILabel m_left_time;

		// Token: 0x04003FFC RID: 16380
		private IXUILabel m_select_chest_tip;

		// Token: 0x04003FFD RID: 16381
		private Transform m_helper_tip;

		// Token: 0x04003FFE RID: 16382
		private Transform m_noneReward_tip;

		// Token: 0x04003FFF RID: 16383
		private XUIPool m_others_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004000 RID: 16384
		private IXUILabel m_watch;

		// Token: 0x04004001 RID: 16385
		private IXUILabel m_like;

		// Token: 0x04004002 RID: 16386
		private uint _token = 0U;

		// Token: 0x04004003 RID: 16387
		private uint _show_item_token = 0U;

		// Token: 0x04004004 RID: 16388
		private float _target_time = 0f;

		// Token: 0x04004005 RID: 16389
		private bool _has_show_others = false;

		// Token: 0x04004006 RID: 16390
		private LevelRewardSelectChestHandler.SelectChestStatus _select_chest_status = LevelRewardSelectChestHandler.SelectChestStatus.Begin;

		// Token: 0x0200199D RID: 6557
		public enum SelectChestStatus
		{
			// Token: 0x04007F45 RID: 32581
			Begin,
			// Token: 0x04007F46 RID: 32582
			SelectFinish
		}
	}
}
