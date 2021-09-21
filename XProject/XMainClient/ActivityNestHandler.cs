using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EF4 RID: 3828
	internal class ActivityNestHandler : DlgHandlerBase
	{
		// Token: 0x0600CB2A RID: 52010 RVA: 0x002E3BF8 File Offset: 0x002E1DF8
		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.Find("Panel/NestTpl");
			this.m_nestPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this._value = (base.PanelObject.transform.FindChild("Fatigue/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_ValueTween = XNumberTween.Create(this._value);
			this.m_addFatigue = (base.PanelObject.transform.FindChild("Fatigue").GetComponent("XUIButton") as IXUIButton);
			this.m_lbMyPPT = (base.PanelObject.transform.Find("MyPPT").GetComponent("XUILabel") as IXUILabel);
			this._doc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this._doc.NestView = this;
		}

		// Token: 0x0600CB2B RID: 52011 RVA: 0x002E3CED File Offset: 0x002E1EED
		public override void OnUnload()
		{
			this._doc.NestView = null;
			base.OnUnload();
		}

		// Token: 0x0600CB2C RID: 52012 RVA: 0x002E3D03 File Offset: 0x002E1F03
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_addFatigue.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddFatigueClick));
		}

		// Token: 0x0600CB2D RID: 52013 RVA: 0x002E3D28 File Offset: 0x002E1F28
		public bool OnAddFatigueClick(IXUIButton sp)
		{
			DlgBase<XBuyCountView, XBuyCountBehaviour>.singleton.ActiveShow(TeamLevelType.TeamLevelNest);
			return true;
		}

		// Token: 0x0600CB2E RID: 52014 RVA: 0x002E3D47 File Offset: 0x002E1F47
		protected override void OnShow()
		{
			this.ShowNestFrame();
		}

		// Token: 0x0600CB2F RID: 52015 RVA: 0x002E3D51 File Offset: 0x002E1F51
		protected override void OnHide()
		{
			this.m_nestPool.ReturnAll(false);
			base.OnHide();
		}

		// Token: 0x0600CB30 RID: 52016 RVA: 0x002E3D68 File Offset: 0x002E1F68
		public void SetSpirit(int cur, int total)
		{
			this.m_ValueTween.SetNumberWithTween((ulong)((long)cur), "/" + total, false, true);
		}

		// Token: 0x0600CB31 RID: 52017 RVA: 0x002E3D8C File Offset: 0x002E1F8C
		public void RefreshSpirit()
		{
			int dayCount = this._doc.GetDayCount(TeamLevelType.TeamLevelNest, null);
			int dayMaxCount = this._doc.GetDayMaxCount(TeamLevelType.TeamLevelNest, null);
			this.SetSpirit(dayCount, dayMaxCount);
		}

		// Token: 0x0600CB32 RID: 52018 RVA: 0x002E3DC0 File Offset: 0x002E1FC0
		protected void ShowNestFrame()
		{
			base.PanelObject.SetActive(true);
			this.m_nestPool.ReturnAll(false);
			this.RefreshSpirit();
			XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
			int playerPPT = specificDocument.GetPlayerPPT();
			this.m_lbMyPPT.SetText(playerPPT.ToString());
			Vector3 localPosition = this.m_nestPool._tpl.transform.localPosition;
			float num = (float)this.m_nestPool.TplWidth;
			List<int> list = ListPool<int>.Get();
			XSingleton<XSceneMgr>.singleton.GetChapterList(XChapterType.SCENE_NEST, list);
			List<ExpeditionTable.RowData> expeditionList = this._doc.GetExpeditionList(TeamLevelType.TeamLevelNest);
			XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
			uint level = player.Attributes.Level;
			XExpeditionDocument specificDocument2 = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			for (int i = 0; i < expeditionList.Count; i++)
			{
				GameObject gameObject = this.m_nestPool.FetchGameObject(false);
				gameObject.name = "nest" + i;
				gameObject.transform.localPosition = localPosition + new Vector3(num * (float)i, 0f);
				IXUILabel ixuilabel = gameObject.transform.FindChild("NestName").GetComponent("XUILabel") as IXUILabel;
				IXUITexture ixuitexture = gameObject.transform.FindChild("NestBg").GetComponent("XUITexture") as IXUITexture;
				IXUIButton ixuibutton = gameObject.transform.FindChild("Do").GetComponent("XUIButton") as IXUIButton;
				IXUILabelSymbol ixuilabelSymbol = ixuibutton.gameObject.transform.FindChild("Text").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUILabel ixuilabel2 = gameObject.transform.Find("PPT").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject.transform.Find("Diff").GetComponent("XUILabel") as IXUILabel;
				ixuibutton.ID = (ulong)((long)expeditionList[i].DNExpeditionID);
				Transform transform = gameObject.transform.FindChild("NotOpen");
				IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)expeditionList[i].DNExpeditionID);
				uint sceneIDByExpID = specificDocument2.GetSceneIDByExpID(expeditionList[i].DNExpeditionID);
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneIDByExpID);
				bool flag = sceneData != null && sceneData.FatigueCost.Count > 0;
				string str;
				if (flag)
				{
					str = XLabelSymbolHelper.FormatCostWithIcon(sceneData.FatigueCost[0, 1], ItemEnum.FATIGUE);
				}
				else
				{
					str = string.Empty;
				}
				transform.gameObject.SetActive(false);
				XChapter.RowData chapter = XSingleton<XSceneMgr>.singleton.GetChapter(list[i]);
				ixuilabel.SetText(expeditionList[i].DNExpeditionName);
				ixuilabel2.SetText(sceneData.RecommendPower.ToString());
				ixuilabel3.SetText(XLevelDocument.GetDifficulty(playerPPT, sceneData.RecommendPower));
				ixuitexture.SetTexturePath("atlas/UI/GameSystem/Activity/" + chapter.Pic);
				for (int j = 0; j < 2; j++)
				{
					GameObject gameObject2 = gameObject.transform.FindChild("Item" + (j + 1)).gameObject;
					bool flag2 = j >= expeditionList[i].ViewableDropList.Length;
					if (flag2)
					{
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, 0, 0, false);
					}
					else
					{
						IXUISprite ixuisprite2 = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite2.ID = (ulong)expeditionList[i].ViewableDropList[j];
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)ixuisprite2.ID, 0, false);
						ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					}
				}
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnNestClicked));
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnNestClicked));
				bool flag3 = (ulong)level >= (ulong)((long)expeditionList[i].RequiredLevel);
				if (flag3)
				{
					ixuibutton.SetEnable(true, false);
					ixuilabelSymbol.InputText = str + "  " + XStringDefineProxy.GetString("TEAM_ENTER");
				}
				else
				{
					ixuibutton.SetEnable(false, false);
					ixuilabelSymbol.InputText = XStringDefineProxy.GetString("EXPEDITION_REQUIRED_LEVEL", new object[]
					{
						expeditionList[i].RequiredLevel
					});
				}
			}
			ListPool<int>.Release(list);
		}

		// Token: 0x0600CB33 RID: 52019 RVA: 0x002E4298 File Offset: 0x002E2498
		protected void OnNestClicked(IXUISprite sp)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch((int)sp.ID);
		}

		// Token: 0x0600CB34 RID: 52020 RVA: 0x002E42C0 File Offset: 0x002E24C0
		protected bool OnNestClicked(IXUIButton button)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch((int)button.ID);
			return true;
		}

		// Token: 0x0600CB35 RID: 52021 RVA: 0x002E42EC File Offset: 0x002E24EC
		public static int GetDayLeftCount()
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			return specificDocument.GetDayCount(TeamLevelType.TeamLevelNest, null);
		}

		// Token: 0x040059D2 RID: 22994
		private XExpeditionDocument _doc;

		// Token: 0x040059D3 RID: 22995
		public XUIPool m_nestPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040059D4 RID: 22996
		public IXUILabel _value;

		// Token: 0x040059D5 RID: 22997
		public XNumberTween m_ValueTween;

		// Token: 0x040059D6 RID: 22998
		public IXUIButton m_addFatigue;

		// Token: 0x040059D7 RID: 22999
		public IXUILabel m_lbMyPPT;
	}
}
