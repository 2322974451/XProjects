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
	// Token: 0x02000C78 RID: 3192
	internal class BiochemicalHellDogFrameHandler : DlgHandlerBase
	{
		// Token: 0x0600B46A RID: 46186 RVA: 0x00233C98 File Offset: 0x00231E98
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<BiochemicalHellDogDocument>(BiochemicalHellDogDocument.uuID);
			Transform transform = base.transform.Find("Bg");
			this.m_Time = (transform.Find("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_Help = (transform.Find("Time/Help").GetComponent("XUISprite") as IXUISprite);
			this.m_HelpReward = (transform.Find("RewardBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_HelpRewardRedPoint = transform.Find("RewardBtn/RedPoint");
			this.RewardPos = transform.Find("RewardPos");
			this.RankPos = transform.Find("RankPos");
			Transform transform2 = transform.Find("Panel/MonsterTpl");
			this.m_MonsterPool.SetupPool(null, transform2.gameObject, (uint)this.doc.sceneID.Length, false);
			Transform transform3 = transform.Find("Panel/ItemTpl");
			this.m_ItemPool.SetupPool(null, transform3.gameObject, (uint)(this.doc.sceneID.Length * (int)BiochemicalHellDogDocument.REWARD_MAX), false);
			this.InitShow();
		}

		// Token: 0x170031F2 RID: 12786
		// (get) Token: 0x0600B46B RID: 46187 RVA: 0x00233DC8 File Offset: 0x00231FC8
		protected override string FileName
		{
			get
			{
				return "GameSystem/ThemeActivity/BiochemicalHellDogFrame";
			}
		}

		// Token: 0x0600B46C RID: 46188 RVA: 0x00233DDF File Offset: 0x00231FDF
		public override void RegisterEvent()
		{
			this.m_HelpReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpRewardOpenClick));
			this.m_Help.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x0600B46D RID: 46189 RVA: 0x00233E12 File Offset: 0x00232012
		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
		}

		// Token: 0x0600B46E RID: 46190 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void StackRefresh()
		{
		}

		// Token: 0x0600B46F RID: 46191 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B470 RID: 46192 RVA: 0x00233E23 File Offset: 0x00232023
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<ActivityHelpRewardHandler>(ref this.m_HelpRewardHandler);
			base.OnUnload();
		}

		// Token: 0x0600B471 RID: 46193 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void InitShow()
		{
		}

		// Token: 0x0600B472 RID: 46194 RVA: 0x00233E3C File Offset: 0x0023203C
		public void Refresh()
		{
			SuperActivityTime.RowData actInfo = this.doc.ActInfo;
			bool flag = actInfo == null;
			if (!flag)
			{
				bool flag2 = (int)actInfo.timestage.count != this.doc.sceneID.Length;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("actInfo.timestage.count!= sceneID.Length", null, null, null, null, null);
				}
				else
				{
					List<uint> activityCompleteScene = XTempActivityDocument.Doc.GetActivityCompleteScene(this.doc.ActInfo.actid);
					List<ItemBrief> list = new List<ItemBrief>();
					this.m_MonsterPool.FakeReturnAll();
					this.m_ItemPool.FakeReturnAll();
					for (int i = 0; i < this.doc.sceneID.Length; i++)
					{
						GameObject gameObject = this.m_MonsterPool.FetchGameObject(false);
						gameObject.transform.localPosition = new Vector3((float)(i * this.m_MonsterPool.TplWidth), 0f, 0f) + this.m_MonsterPool.TplPos;
						IXUIButton ixuibutton = gameObject.transform.FindChild("RankBtn").GetComponent("XUIButton") as IXUIButton;
						ixuibutton.gameObject.SetActive(i + 1 == this.doc.sceneID.Length);
						ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankOpenClick));
						SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(uint.Parse(this.doc.sceneID[i]));
						bool flag3 = sceneData == null;
						if (flag3)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("SceneTable sceneID:" + this.doc.sceneID[i] + "No Find", null, null, null, null, null);
						}
						else
						{
							IXUILabel ixuilabel = gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
							ixuilabel.SetText(sceneData.Comment);
							IXUITexture ixuitexture = gameObject.transform.FindChild("Tex").GetComponent("XUITexture") as IXUITexture;
							ixuitexture.SetTexturePath(string.Format("atlas/UI/GameSystem/ThemeActivity/{0}", this.doc.tex[i]));
							bool flag4 = false;
							for (int j = 0; j < activityCompleteScene.Count; j++)
							{
								bool flag5 = activityCompleteScene[j] == uint.Parse(this.doc.sceneID[i]);
								if (flag5)
								{
									flag4 = true;
								}
							}
							bool flag6 = sceneData.FirstDownDrop != null;
							if (flag6)
							{
								Transform transform = gameObject.transform.FindChild("Grid");
								list.Clear();
								int num = 0;
								while (num < sceneData.FirstDownDrop.Length && list.Count < 3)
								{
									ItemBrief itemBrief = new ItemBrief();
									int num2;
									int num3;
									CVSReader.GetRowDataListByField<DropList.RowData, int>(XBagDocument.DropTable.Table, sceneData.FirstDownDrop[num], out num2, out num3, XBagDocument.comp);
									bool flag7 = num2 < 0;
									if (!flag7)
									{
										itemBrief.itemID = (uint)XBagDocument.DropTable.Table[num2].ItemID;
										itemBrief.itemCount = (uint)XBagDocument.DropTable.Table[num2].ItemCount;
										itemBrief.isbind = XBagDocument.DropTable.Table[num2].ItemBind;
										list.Add(itemBrief);
									}
									num++;
								}
								for (int k = 0; k < list.Count; k++)
								{
									GameObject gameObject2 = this.m_ItemPool.FetchGameObject(false);
									XSingleton<UiUtility>.singleton.AddChild(transform.gameObject, gameObject2);
									gameObject2.transform.localPosition = new Vector3(((float)k + 0.5f - (float)list.Count / 2f) * (float)this.m_ItemPool.TplWidth, 0f);
									ItemList.RowData itemConf = XBagDocument.GetItemConf((int)list[k].itemID);
									XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, itemConf, (int)list[k].itemCount, false);
									XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject2, (int)list[k].itemID);
									gameObject2.SetActive(!flag4);
								}
							}
							Transform transform2 = gameObject.transform.FindChild("FetchEnd");
							transform2.gameObject.SetActive(flag4);
							IXUILabel ixuilabel2 = gameObject.transform.FindChild("StartLeftTime").GetComponent("XUILabel") as IXUILabel;
							IXUIButton ixuibutton2 = gameObject.transform.FindChild("Join").GetComponent("XUIButton") as IXUIButton;
							IXUILabel ixuilabel3 = gameObject.transform.FindChild("EndLeftTime").GetComponent("XUILabel") as IXUILabel;
							Transform transform3 = gameObject.transform.FindChild("End");
							int num4 = 0;
							int num5 = 0;
							BiochemicalHellDogDocument.Stage stage;
							this.doc.GetTime(i, out stage, out num4, out num5);
							ixuilabel2.gameObject.SetActive(stage == BiochemicalHellDogDocument.Stage.Ready);
							bool flag8 = this.doc.curTime < num4;
							if (flag8)
							{
								int num6 = (num4 - this.doc.curTime) / 24;
								int num7 = (num4 - this.doc.curTime) % 24;
								ixuilabel2.SetText(string.Format(XStringDefineProxy.GetString("ACTIVITY_START_LEFTTIME"), num6, num7));
							}
							ixuibutton2.gameObject.SetActive(stage == BiochemicalHellDogDocument.Stage.Processing);
							ixuilabel3.gameObject.SetActive(stage == BiochemicalHellDogDocument.Stage.Processing);
							bool flag9 = stage == BiochemicalHellDogDocument.Stage.Processing;
							if (flag9)
							{
								int num8 = (num5 - this.doc.curTime) / 24;
								int num9 = (num5 - this.doc.curTime) % 24;
								ixuilabel3.SetText(string.Format(XStringDefineProxy.GetString("ACTIVITY_END_LEFTTIME"), num8, num9));
								ixuibutton2.ID = ulong.Parse(this.doc.sceneID[i]);
								ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClick));
							}
							transform3.gameObject.SetActive(stage == BiochemicalHellDogDocument.Stage.End);
						}
					}
					this.m_ItemPool.ActualReturnAll(false);
					this.m_MonsterPool.ActualReturnAll(false);
					DateTime endTime = XTempActivityDocument.Doc.GetEndTime(actInfo, -1);
					string arg = string.Format(XStringDefineProxy.GetString("CAREER_GROWTH_PROCESS_TIME"), actInfo.starttime / 10000U, actInfo.starttime % 10000U / 100U, actInfo.starttime % 100U);
					string arg2 = string.Format(XStringDefineProxy.GetString("CAREER_GROWTH_PROCESS_TIME"), endTime.Year, endTime.Month, endTime.Day);
					this.m_Time.SetText(string.Format("{0}~{1}", arg, arg2));
					this.RefreshRedPoint();
				}
			}
		}

		// Token: 0x0600B473 RID: 46195 RVA: 0x00234535 File Offset: 0x00232735
		public void RefreshRedPoint()
		{
			this.m_HelpRewardRedPoint.gameObject.SetActive(this.doc.GetRedPoint());
		}

		// Token: 0x0600B474 RID: 46196 RVA: 0x00234554 File Offset: 0x00232754
		private void OnHelpClicked(IXUISprite btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_ThemeActivity_HellDog);
		}

		// Token: 0x0600B475 RID: 46197 RVA: 0x00234568 File Offset: 0x00232768
		private bool OnJoinClick(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddGreenLog(btn.ID.ToString(), null, null, null, null, null);
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			int expIDBySceneID = specificDocument.GetExpIDBySceneID((uint)btn.ID);
			specificDocument2.SetAndMatch(expIDBySceneID);
			return true;
		}

		// Token: 0x0600B476 RID: 46198 RVA: 0x002345C8 File Offset: 0x002327C8
		private bool OnHelpRewardOpenClick(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<ActivityHelpRewardHandler>(ref this.m_HelpRewardHandler, this.RewardPos, true, this);
			List<ActivityHelpReward> rewardData = this.doc.GetRewardData();
			this.m_HelpRewardHandler.SetData(rewardData);
			this.m_HelpRewardHandler.SetEndTime(this.doc.ActInfo.actid);
			return true;
		}

		// Token: 0x0600B477 RID: 46199 RVA: 0x00234624 File Offset: 0x00232824
		private bool OnRankOpenClick(IXUIButton btn)
		{
			DlgBase<BiochemicalHellDogRankView, BiochemicalHellDogRankBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x04004600 RID: 17920
		private BiochemicalHellDogDocument doc = null;

		// Token: 0x04004601 RID: 17921
		public ActivityHelpRewardHandler m_HelpRewardHandler;

		// Token: 0x04004602 RID: 17922
		private IXUILabel m_Time;

		// Token: 0x04004603 RID: 17923
		private IXUISprite m_Help;

		// Token: 0x04004604 RID: 17924
		private IXUIButton m_HelpReward;

		// Token: 0x04004605 RID: 17925
		private Transform m_HelpRewardRedPoint;

		// Token: 0x04004606 RID: 17926
		private Transform RewardPos;

		// Token: 0x04004607 RID: 17927
		private Transform RankPos;

		// Token: 0x04004608 RID: 17928
		private XUIPool m_MonsterPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004609 RID: 17929
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
