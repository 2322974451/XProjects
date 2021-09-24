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

	internal class BiochemicalHellDogFrameHandler : DlgHandlerBase
	{

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

		protected override string FileName
		{
			get
			{
				return "GameSystem/ThemeActivity/BiochemicalHellDogFrame";
			}
		}

		public override void RegisterEvent()
		{
			this.m_HelpReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpRewardOpenClick));
			this.m_Help.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
		}

		public override void StackRefresh()
		{
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<ActivityHelpRewardHandler>(ref this.m_HelpRewardHandler);
			base.OnUnload();
		}

		private void InitShow()
		{
		}

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

		public void RefreshRedPoint()
		{
			this.m_HelpRewardRedPoint.gameObject.SetActive(this.doc.GetRedPoint());
		}

		private void OnHelpClicked(IXUISprite btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_ThemeActivity_HellDog);
		}

		private bool OnJoinClick(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddGreenLog(btn.ID.ToString(), null, null, null, null, null);
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			int expIDBySceneID = specificDocument.GetExpIDBySceneID((uint)btn.ID);
			specificDocument2.SetAndMatch(expIDBySceneID);
			return true;
		}

		private bool OnHelpRewardOpenClick(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<ActivityHelpRewardHandler>(ref this.m_HelpRewardHandler, this.RewardPos, true, this);
			List<ActivityHelpReward> rewardData = this.doc.GetRewardData();
			this.m_HelpRewardHandler.SetData(rewardData);
			this.m_HelpRewardHandler.SetEndTime(this.doc.ActInfo.actid);
			return true;
		}

		private bool OnRankOpenClick(IXUIButton btn)
		{
			DlgBase<BiochemicalHellDogRankView, BiochemicalHellDogRankBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private BiochemicalHellDogDocument doc = null;

		public ActivityHelpRewardHandler m_HelpRewardHandler;

		private IXUILabel m_Time;

		private IXUISprite m_Help;

		private IXUIButton m_HelpReward;

		private Transform m_HelpRewardRedPoint;

		private Transform RewardPos;

		private Transform RankPos;

		private XUIPool m_MonsterPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
