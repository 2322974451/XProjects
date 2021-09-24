using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardGerenalHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardGerenalFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

		private void InitUI()
		{
			this.m_star_frame = base.PanelObject.transform.Find("Bg/Stars");
			for (int i = 0; i < 3; i++)
			{
				this.m_level_req[i] = (base.PanelObject.transform.Find(string.Format("Bg/StarsReq/Req{0}/Tip", i + 1)).GetComponent("XUILabel") as IXUILabel);
				this.m_level_req_done[i] = (base.PanelObject.transform.Find(string.Format("Bg/StarsReq/Req{0}/Done", i + 1)).GetComponent("XUISprite") as IXUISprite);
				this.m_stars[i] = base.PanelObject.transform.Find(string.Format("Bg/Stars/Star{0}", i + 1));
				this.m_star_fx[i] = base.PanelObject.transform.Find(string.Format("Bg/Stars/Star{0}/Fx", i + 1));
			}
			this.m_star_tween = (base.PanelObject.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_left_time = (base.PanelObject.transform.Find("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_exp_bar = (base.PanelObject.transform.Find("Bg/ExpBar").GetComponent("XUISlider") as IXUISlider);
			this.m_exp_bar_level = (base.PanelObject.transform.Find("Bg/ExpBar/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_exp_bar_percent = (base.PanelObject.transform.Find("Bg/ExpBar/Percent").GetComponent("XUILabel") as IXUILabel);
			this.m_guild_exp_buff = (base.PanelObject.transform.Find("Bg/ExpBar/ExpBuff").GetComponent("XUILabel") as IXUILabel);
			this.m_item_list = base.PanelObject.transform.Find("Bg/ItemList");
			Transform transform = base.PanelObject.transform.Find("Bg/ItemList/ScrollView/Item");
			this.m_item_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			this.m_watch = (base.PanelObject.transform.Find("Watch").GetComponent("XUILabel") as IXUILabel);
			this.m_like = (base.PanelObject.transform.Find("Like").GetComponent("XUILabel") as IXUILabel);
			this.m_score = (base.PanelObject.transform.Find("Bg/Score").GetComponent("XUILabel") as IXUILabel);
			this.m_return = (base.PanelObject.transform.Find("Bg/Return").GetComponent("XUISprite") as IXUISprite);
			this.m_return_label = (base.PanelObject.transform.Find("Bg/Return/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_guild_exp = (base.PanelObject.transform.Find("Bg/GuildExp").GetComponent("XUILabel") as IXUILabel);
			this.m_goldGroupReward = base.PanelObject.transform.Find("Bg/RewardHunt").gameObject;
			this.m_help_tip = base.PanelObject.transform.Find("Bg/HelperTip");
			this.m_noneReward_tip = base.PanelObject.transform.Find("Bg/NoneRewardTip");
			this.m_seal_tip = base.PanelObject.transform.Find("Bg/SealTip");
			this.m_QQVipTip = (base.PanelObject.transform.FindChild("Bg/QQVIPTS").GetComponent("XUILabel") as IXUILabel);
			this.m_QQVipIcon = base.PanelObject.transform.FindChild("Bg/QQVIPTS/QQVIP").gameObject;
			this.m_QQSVipIcon = base.PanelObject.transform.FindChild("Bg/QQVIPTS/QQSVIP").gameObject;
			this.m_QQGameCenter = base.PanelObject.transform.FindChild("Bg/QQ").gameObject;
			this.m_WXGameCenter = base.PanelObject.transform.FindChild("Bg/Wechat").gameObject;
			this.m_snapshot = (base.PanelObject.transform.Find("Bg/Snapshot/Snapshot").GetComponent("UIDummy") as IUIDummy);
		}

		protected override void OnShow()
		{
			base.OnShow();
			SceneType currentStage = this.doc.CurrentStage;
			if (currentStage <= SceneType.SCENE_DRAGON)
			{
				if (currentStage <= SceneType.SCENE_NEST)
				{
					if (currentStage != SceneType.SCENE_BATTLE)
					{
						if (currentStage != SceneType.SCENE_NEST)
						{
							goto IL_7A;
						}
						goto IL_71;
					}
				}
				else if (currentStage != SceneType.SCENE_ABYSSS)
				{
					if (currentStage != SceneType.SCENE_DRAGON)
					{
						goto IL_7A;
					}
					goto IL_71;
				}
			}
			else if (currentStage <= SceneType.SCENE_ENDLESSABYSS)
			{
				if (currentStage != SceneType.SCENE_GODDESS && currentStage != SceneType.SCENE_ENDLESSABYSS)
				{
					goto IL_7A;
				}
			}
			else if (currentStage != SceneType.SCENE_GUILD_CAMP)
			{
				switch (currentStage)
				{
				case SceneType.SCENE_ACTIVITY_ONE:
				case SceneType.SCENE_ACTIVITY_THREE:
					break;
				case SceneType.SCENE_ACTIVITY_TWO:
					goto IL_71;
				default:
					goto IL_7A;
				}
			}
			this.OnShowWithStarReq();
			goto IL_83;
			IL_71:
			this.OnShowWithPoint();
			goto IL_83;
			IL_7A:
			this.OnShowWithNothing();
			IL_83:
			this._show_exp_bar = false;
			this._time_token = XSingleton<XTimerMgr>.singleton.SetTimer((float)XSingleton<XGlobalConfig>.singleton.GetInt("LevelFinishShowExpBarTime") / 10f, new XTimerMgr.ElapsedEventHandler(this.ShowExpTween), null);
			this.RefreshPlatformAbilityInfo(this.doc.CurrentStage);
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			base.OnHide();
		}

		public override void OnUnload()
		{
			XSingleton<X3DAvatarMgr>.singleton.OnUIUnloadMainDummy(this.m_snapshot);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._time_token);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_shareTimeToken);
			this.m_shareTimeToken = 0U;
			base.OnUnload();
		}

		private void ShowExpTween(object o)
		{
			this._show_exp_bar = true;
		}

		private void OnShowWithStarReq()
		{
			this.ShowGerenalUI();
			this.ShowStarReq();
		}

		private void OnShowWithPoint()
		{
			this.ShowGerenalUI();
			this.ShowScore();
		}

		private void OnShowWithNothing()
		{
			this.ShowGerenalUI();
		}

		private void OnReturnClicked(IXUISprite sp)
		{
			this.doc.SendLeaveScene();
		}

		private void ShowStarReq()
		{
			int num = 0;
			for (int i = 0; i < XLevelRewardDocument.Table.Table.Length; i++)
			{
				bool flag = XLevelRewardDocument.Table.Table[i].scendid == this.doc.CurrentScene;
				if (flag)
				{
					num = i;
					break;
				}
			}
			this.m_level_req[0].SetVisible(true);
			this.m_level_req[1].SetVisible(true);
			this.m_level_req[2].SetVisible(true);
			this.m_level_req[1].SetText(LevelRewardGerenalHandler.GetReqText(XLevelRewardDocument.Table.Table[num], 1));
			this.m_level_req[2].SetText(LevelRewardGerenalHandler.GetReqText(XLevelRewardDocument.Table.Table[num], 2));
			int num2 = 0;
			while (num2 < this.doc.GerenalBattleData.Stars.Count && num2 < 3)
			{
				bool flag2 = this.doc.GerenalBattleData.Stars[num2] == 1U;
				if (flag2)
				{
					this.m_level_req_done[num2].SetVisible(true);
				}
				else
				{
					this.m_level_req_done[num2].SetVisible(false);
				}
				num2++;
			}
		}

		public static string GetReqText(StageRankTable.RowData rowData, int index)
		{
			uint num = (index == 1) ? rowData.star2[0] : rowData.star3[0];
			uint key = (index == 1) ? rowData.star2[1] : rowData.star3[1];
			uint num2 = (index == 1) ? rowData.star2[2] : rowData.star3[2];
			string result;
			switch (num)
			{
			case 1U:
			{
				bool flag = num2 == 0U;
				if (flag)
				{
					result = XStringDefineProxy.GetString("LEVEL_FINISH_NO_TIME_LIMIT");
				}
				else
				{
					bool flag2 = num2 % 60U == 0U;
					string text;
					if (flag2)
					{
						text = string.Format("{0}{1}", num2 / 60U, XStringDefineProxy.GetString("MINUTE_DUARATION"));
					}
					else
					{
						text = string.Format("{0}{1}{2}{3}", new object[]
						{
							num2 / 60U,
							XStringDefineProxy.GetString("MINUTE_TIME"),
							num2 % 60U,
							XStringDefineProxy.GetString("SECOND_DUARATION")
						});
					}
					result = XStringDefineProxy.GetString("LEVEL_FINISH_TIME_LIMIT", new object[]
					{
						text
					});
				}
				break;
			}
			case 2U:
			{
				bool flag3 = num2 == 0U;
				if (flag3)
				{
					result = XStringDefineProxy.GetString("LEVEL_FINISH_NO_HP_LIMIT");
				}
				else
				{
					result = string.Format("{0}{1}%", XStringDefineProxy.GetString("LEVEL_FINISH_HP_LIMIT"), num2);
				}
				break;
			}
			case 3U:
			{
				bool flag4 = num2 == 0U;
				if (flag4)
				{
					result = XStringDefineProxy.GetString("LEVEL_FINISH_NO_FOUND");
				}
				else
				{
					result = XStringDefineProxy.GetString("LEVEL_FINISH_FOUND_LIMIT", new object[]
					{
						num2
					});
				}
				break;
			}
			case 4U:
			{
				bool flag5 = num2 == 0U;
				if (flag5)
				{
					result = XStringDefineProxy.GetString("LEVEL_FINISH_NO_BEHIT");
				}
				else
				{
					result = XStringDefineProxy.GetString("LEVEL_FINISH_BEHIT_LIMIT", new object[]
					{
						num2
					});
				}
				break;
			}
			case 5U:
			{
				XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(key);
				bool flag6 = byID == null;
				if (flag6)
				{
					result = string.Empty;
				}
				else
				{
					bool flag7 = num2 == 100U;
					if (flag7)
					{
						result = XStringDefineProxy.GetString("LEVEL_FINISH_NPC_NO_HURT", new object[]
						{
							byID.Name
						});
					}
					else
					{
						result = XStringDefineProxy.GetString("LEVEL_FINISH_NPC_HURT_LIMIT", new object[]
						{
							byID.Name,
							num2
						});
					}
				}
				break;
			}
			case 6U:
			{
				bool flag8 = num2 == 0U;
				if (flag8)
				{
					result = XStringDefineProxy.GetString("LEVEL_FINISH_NO_COMBO");
				}
				else
				{
					result = XStringDefineProxy.GetString("LEVEL_FINISH_COMBO_LIMIT", new object[]
					{
						num2
					});
				}
				break;
			}
			case 7U:
				result = XStringDefineProxy.GetString("LEVEL_FINISH_POINT", new object[]
				{
					num2
				});
				break;
			case 8U:
				result = XStringDefineProxy.GetString("LEVEL_FINISH_SURVIVE", new object[]
				{
					num2
				});
				break;
			case 9U:
				result = XStringDefineProxy.GetString("LEVEL_FINISH_TEAM", new object[]
				{
					num2
				});
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		private void ShowScore()
		{
			this.m_score.SetVisible(true);
			this.m_score.SetText(XStringDefineProxy.GetString("LEVEL_FINISH_SCORE", new object[]
			{
				this.doc.GerenalBattleData.Score
			}));
		}

		private void ShowGerenalUI()
		{
			uint rank = this.doc.GerenalBattleData.Rank;
			for (int i = 0; i < 3; i++)
			{
				bool flag = (long)i < (long)((ulong)rank);
				if (flag)
				{
					this.m_stars[i].gameObject.SetActive(true);
					this.m_star_tween.SetTweenGroup(i + 1);
					this.m_star_tween.PlayTween(true, -1f);
					this.m_star_fx[i].gameObject.SetActive((long)i == (long)((ulong)(rank - 1U)));
				}
				else
				{
					this.m_stars[i].gameObject.SetActive(false);
					this.m_star_fx[i].gameObject.SetActive(false);
				}
			}
			this.m_star_frame.localPosition -= new Vector3(this.m_stars[0].localPosition.x * (3U - rank) / 2f, 0f);
			for (int j = 0; j < 3; j++)
			{
				this.m_level_req[j].SetVisible(false);
				this.m_level_req_done[j].SetVisible(false);
			}
			this.m_left_time.SetText(string.Format("{0} {1}", XStringDefineProxy.GetString("LEVEL_FINISH_TIME"), XSingleton<UiUtility>.singleton.TimeFormatString((int)this.doc.GerenalBattleData.LevelFinishTime, 2, 3, 4, false, true)));
			this.m_score.SetVisible(false);
			this.m_exp_bar_level.SetText(string.Format("Lv.{0}", this.doc.GerenalBattleData.StartLevel));
			this.m_exp_bar.Value = this.doc.GerenalBattleData.StartPercent;
			this.m_exp_bar_percent.SetText("");
			bool flag2 = this.doc.GerenalBattleData.GuildBuff != 0f;
			if (flag2)
			{
				this.m_guild_exp_buff.SetText(XStringDefineProxy.GetString("LEVEL_FINISH_GUILD_BUFF", new object[]
				{
					this.doc.GerenalBattleData.GuildBuff.ToString("0")
				}));
			}
			else
			{
				this.m_guild_exp_buff.SetText("");
			}
			int num = (this.doc.GerenalBattleData.GuildDragonCoin == 0U) ? 0 : 1;
			this.m_item_pool.ReturnAll(false);
			float num2 = this.m_item_pool.TplPos.x;
			for (int k = 0; k < this.doc.GerenalBattleData.Items.Count; k++)
			{
				GameObject gameObject = this.m_item_pool.FetchGameObject(true);
				IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = gameObject.transform.Find("Tip").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("Guild").GetComponent("XUILabel") as IXUILabel;
				XItemDrawerMgr.Param.bBinding = this.doc.Items[k].isbind;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)this.doc.Items[k].itemID, (int)this.doc.Items[k].itemCount, false);
				gameObject.transform.localPosition = new Vector3(num2, this.m_item_pool.TplPos.y);
				num2 += (float)this.m_item_pool.TplWidth;
				ixuisprite.ID = (ulong)this.doc.Items[k].itemID;
				bool isbind = this.doc.Items[k].isbind;
				if (isbind)
				{
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnBindItemClick));
				}
				else
				{
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
				ixuilabel.SetVisible(false);
				ixuilabel2.SetVisible(false);
			}
			bool flag3 = num != 0;
			if (flag3)
			{
				GameObject gameObject2 = this.m_item_pool.FetchGameObject(false);
				IXUISprite ixuisprite2 = gameObject2.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel3 = gameObject2.transform.Find("Tip").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = gameObject2.transform.Find("Guild").GetComponent("XUILabel") as IXUILabel;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DRAGON_COIN), (int)this.doc.GerenalBattleData.GuildDragonCoin, false);
				gameObject2.transform.localPosition = new Vector3(num2, this.m_item_pool.TplPos.y);
				num2 += (float)this.m_item_pool.TplWidth;
				ixuisprite2.ID = (ulong)((long)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DRAGON_COIN));
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				ixuilabel3.SetVisible(false);
				ixuilabel4.SetVisible(true);
			}
			bool flag4 = XSpectateSceneDocument.WhetherWathchNumShow((int)this.doc.WatchCount, (int)this.doc.LikeCount, (int)this.doc.CurrentStage);
			if (flag4)
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
			string text = "";
			bool flag5 = this.doc.GerenalBattleData.GuildExp > 0U;
			if (flag5)
			{
				text = string.Format("{0}{1}\n", text, XStringDefineProxy.GetString("LEVEL_FINISH_GUILD_EXP", new object[]
				{
					this.doc.GerenalBattleData.GuildExp
				}));
			}
			bool flag6 = this.doc.GerenalBattleData.GuildContribution > 0U;
			if (flag6)
			{
				text = string.Format("{0}{1}", text, XStringDefineProxy.GetString("LEVEL_FINISH_GUILD_ITEM", new object[]
				{
					this.doc.GerenalBattleData.GuildContribution
				}));
			}
			bool flag7 = string.IsNullOrEmpty(text);
			if (flag7)
			{
				this.m_guild_exp.SetVisible(false);
			}
			else
			{
				this.m_guild_exp.SetVisible(true);
				this.m_guild_exp.SetText(text);
			}
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this.doc.CurrentScene);
			bool canDrawBox = sceneData.CanDrawBox;
			if (canDrawBox)
			{
				this.m_return_label.SetText(XStringDefineProxy.GetString("LEVEL_FINISH_ENTER_CHEST"));
				this.m_return.RegisterSpriteClickEventHandler(null);
				XSingleton<XTimerMgr>.singleton.SetTimer((float)XSingleton<XGlobalConfig>.singleton.GetInt("LevelFinishSelectChestWaitTime"), new XTimerMgr.ElapsedEventHandler(this.ShowSelectChestFrame), null);
			}
			else
			{
				this.m_return_label.SetText(XStringDefineProxy.GetString("LEVEL_FINISH_LEAVE_SCENE"));
				this.m_return.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturnClicked));
				this.m_shareTimeToken = XSingleton<XTimerMgr>.singleton.SetTimer(4.3f, new XTimerMgr.ElapsedEventHandler(this.TryToShowShareView), null);
			}
			bool flag8 = this.doc.GerenalBattleData.GoldGroupReward == null;
			if (flag8)
			{
				this.m_goldGroupReward.SetActive(false);
			}
			else
			{
				this.m_goldGroupReward.SetActive(true);
				IXUISprite ixuisprite3 = this.m_goldGroupReward.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel5 = this.m_goldGroupReward.transform.Find("Count").GetComponent("XUILabel") as IXUILabel;
				ixuisprite3.SetSprite(XBagDocument.GetItemSmallIcon((int)this.doc.GerenalBattleData.GoldGroupReward.itemID, 0U));
				ixuilabel5.SetText(this.doc.GerenalBattleData.GoldGroupReward.itemCount.ToString());
			}
			this.m_item_list.gameObject.SetActive(!this.doc.GerenalBattleData.isHelper && !this.doc.GerenalBattleData.noneReward);
			this.m_help_tip.gameObject.SetActive(this.doc.GerenalBattleData.isHelper);
			this.m_noneReward_tip.gameObject.SetActive(!this.doc.GerenalBattleData.isHelper && this.doc.GerenalBattleData.noneReward);
			this.m_exp_bar.SetVisible(!this.doc.GerenalBattleData.isSeal);
			this.m_seal_tip.gameObject.SetActive(this.doc.GerenalBattleData.isSeal);
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, this.m_snapshot);
			float interval = XSingleton<X3DAvatarMgr>.singleton.SetMainAnimationGetLength(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.Disappear);
			this.m_show_time_token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.KillDummyTimer), null);
		}

		private void TryToShowShareView(object param)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_shareTimeToken);
			this.m_shareTimeToken = 0U;
			this.doc.ShowFirstPassShareView();
		}

		private void KillDummyTimer(object sender)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.AttackIdle);
		}

		private void ShowSelectChestFrame(object o)
		{
			this.doc.ShowSelectChestFrame();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.doc.GerenalBattleData.TotalExpPercent > 0f && this._show_exp_bar;
			if (flag)
			{
				XLevelRewardDocument xlevelRewardDocument = this.doc;
				xlevelRewardDocument.GerenalBattleData.TotalExpPercent = xlevelRewardDocument.GerenalBattleData.TotalExpPercent - this.doc.GerenalBattleData.GrowExpPercent;
				bool flag2 = this.doc.GerenalBattleData.CurrentExpPercent + this.doc.GerenalBattleData.GrowExpPercent > 1f;
				if (flag2)
				{
					this.doc.GerenalBattleData.CurrentExpPercent = this.doc.GerenalBattleData.CurrentExpPercent + this.doc.GerenalBattleData.GrowExpPercent - 1f;
					XLevelRewardDocument xlevelRewardDocument2 = this.doc;
					xlevelRewardDocument2.GerenalBattleData.StartLevel = xlevelRewardDocument2.GerenalBattleData.StartLevel + 1U;
				}
				else
				{
					this.doc.GerenalBattleData.CurrentExpPercent = this.doc.GerenalBattleData.CurrentExpPercent + this.doc.GerenalBattleData.GrowExpPercent;
				}
				bool flag3 = this.doc.GerenalBattleData.TotalExpPercent <= 0f;
				if (flag3)
				{
					XLevelUpStatusDocument specificDocument = XDocuments.GetSpecificDocument<XLevelUpStatusDocument>(XLevelUpStatusDocument.uuID);
					specificDocument.LevelRewardShowLevelUp();
					int powerpoint = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.SetPowerpoint(powerpoint);
				}
				this.m_exp_bar.Value = this.doc.GerenalBattleData.CurrentExpPercent;
				this.m_exp_bar_level.SetText(string.Format("Lv.{0}", this.doc.GerenalBattleData.StartLevel));
				this._exp_percent = this.doc.GerenalBattleData.TotalExp * Mathf.Min(1f, 1f - this.doc.GerenalBattleData.TotalExpPercent);
				this.m_exp_bar_percent.SetText(string.Format("+{0}", this._exp_percent.ToString("0")));
			}
		}

		private void RefreshPlatformAbilityInfo(SceneType type)
		{
			this.RefreshQQVipInfo(type);
			this.RefreshQQWXGameCenterInfo(type);
		}

		public void RefreshQQVipInfo(SceneType type)
		{
			bool flag = type != SceneType.SCENE_BATTLE && type != SceneType.SCENE_ABYSSS;
			if (flag)
			{
				this.m_QQVipTip.SetVisible(false);
				this.m_QQVipIcon.SetActive(false);
				this.m_QQSVipIcon.SetActive(false);
			}
			else
			{
				QQVipInfoClient qqvipInfo = XPlatformAbilityDocument.Doc.QQVipInfo;
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_QQVIP) && qqvipInfo != null;
				if (flag2)
				{
					this.m_QQVipTip.SetVisible(qqvipInfo.is_svip || qqvipInfo.is_vip);
					SeqList<int> seqList = qqvipInfo.is_svip ? XSingleton<XGlobalConfig>.singleton.GetSequenceList("QQSVipLevelReward", true) : XSingleton<XGlobalConfig>.singleton.GetSequenceList("QQVipLevelReward", true);
					bool flag3 = seqList.Count > 0;
					if (flag3)
					{
						int itemID = seqList[0, 0];
						int num = seqList[0, 1];
						string @string = XStringDefineProxy.GetString(qqvipInfo.is_svip ? "QQVIP_GAMEEND_SVIP_TIP" : "QQVIP_GAMEEND_VIP_TIP", new object[]
						{
							num,
							XSingleton<UiUtility>.singleton.ChooseProfString(XBagDocument.GetItemConf(itemID).ItemName, 0U)
						});
						this.m_QQVipTip.SetText(@string);
					}
					this.m_QQVipIcon.SetActive(qqvipInfo.is_vip && !qqvipInfo.is_svip);
					this.m_QQSVipIcon.SetActive(qqvipInfo.is_svip);
				}
				else
				{
					this.m_QQVipTip.SetVisible(false);
					this.m_QQVipIcon.SetActive(false);
					this.m_QQSVipIcon.SetActive(false);
				}
			}
		}

		private void RefreshQQWXGameCenterInfo(SceneType type)
		{
			bool flag = type != SceneType.SCENE_BATTLE;
			if (flag)
			{
				this.m_QQGameCenter.SetActive(false);
				this.m_WXGameCenter.SetActive(false);
			}
			else
			{
				StartUpType launchTypeServerInfo = XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo();
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Platform_StartPrivilege) && launchTypeServerInfo == StartUpType.StartUp_QQ;
				if (flag2)
				{
					string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("QQGameCenterLevelReward", XGlobalConfig.SequenceSeparator);
					IXUILabel ixuilabel = this.m_QQGameCenter.transform.FindChild("T").GetComponent("XUILabel") as IXUILabel;
					bool flag3 = andSeparateValue.Length == 2;
					if (flag3)
					{
						ixuilabel.SetText(XStringDefineProxy.GetString("GAMECENTER_GAME_END_QQ", new object[]
						{
							XSingleton<UiUtility>.singleton.ChooseProfString(XBagDocument.GetItemConf(int.Parse(andSeparateValue[0])).ItemName, 0U),
							andSeparateValue[1]
						}));
					}
					this.m_QQGameCenter.SetActive(true);
				}
				else
				{
					this.m_QQGameCenter.SetActive(false);
				}
				bool flag4 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Platform_StartPrivilege) && launchTypeServerInfo == StartUpType.StartUp_WX;
				if (flag4)
				{
					string[] andSeparateValue2 = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("WXGameCenterLevelReward", XGlobalConfig.SequenceSeparator);
					IXUILabel ixuilabel2 = this.m_WXGameCenter.transform.FindChild("T").GetComponent("XUILabel") as IXUILabel;
					bool flag5 = andSeparateValue2.Length == 2;
					if (flag5)
					{
						ixuilabel2.SetText(XStringDefineProxy.GetString("GAMECENTER_GAME_END_WX", new object[]
						{
							XSingleton<UiUtility>.singleton.ChooseProfString(XBagDocument.GetItemConf(int.Parse(andSeparateValue2[0])).ItemName, 0U),
							andSeparateValue2[1]
						}));
					}
					this.m_WXGameCenter.SetActive(true);
				}
				else
				{
					this.m_WXGameCenter.SetActive(false);
				}
			}
		}

		private XLevelRewardDocument doc = null;

		private IXUILabel[] m_level_req = new IXUILabel[3];

		private IXUISprite[] m_level_req_done = new IXUISprite[3];

		private IXUILabel m_left_time;

		private Transform m_star_frame;

		private Transform[] m_stars = new Transform[3];

		private IXUITweenTool m_star_tween;

		private Transform[] m_star_fx = new Transform[3];

		private IXUISlider m_exp_bar;

		private IXUILabel m_exp_bar_level;

		private IXUILabel m_exp_bar_percent;

		private IXUILabel m_guild_exp_buff;

		private Transform m_item_list;

		public XUIPool m_item_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_watch;

		public IXUILabel m_like;

		public IXUILabel m_score;

		public IXUISprite m_return;

		public IXUILabel m_return_label;

		private IXUILabel m_guild_exp;

		private GameObject m_goldGroupReward;

		private Transform m_help_tip;

		private Transform m_noneReward_tip;

		private Transform m_seal_tip;

		private float _exp_percent = 0f;

		private bool _show_exp_bar = false;

		private uint _time_token = 0U;

		private IXUILabel m_QQVipTip;

		private GameObject m_QQVipIcon;

		private GameObject m_QQSVipIcon;

		private GameObject m_QQGameCenter;

		private GameObject m_WXGameCenter;

		private IUIDummy m_snapshot;

		private uint m_show_time_token = 0U;

		private uint m_shareTimeToken = 0U;
	}
}
