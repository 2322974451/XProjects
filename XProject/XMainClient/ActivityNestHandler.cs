using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ActivityNestHandler : DlgHandlerBase
	{

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

		public override void OnUnload()
		{
			this._doc.NestView = null;
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_addFatigue.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddFatigueClick));
		}

		public bool OnAddFatigueClick(IXUIButton sp)
		{
			DlgBase<XBuyCountView, XBuyCountBehaviour>.singleton.ActiveShow(TeamLevelType.TeamLevelNest);
			return true;
		}

		protected override void OnShow()
		{
			this.ShowNestFrame();
		}

		protected override void OnHide()
		{
			this.m_nestPool.ReturnAll(false);
			base.OnHide();
		}

		public void SetSpirit(int cur, int total)
		{
			this.m_ValueTween.SetNumberWithTween((ulong)((long)cur), "/" + total, false, true);
		}

		public void RefreshSpirit()
		{
			int dayCount = this._doc.GetDayCount(TeamLevelType.TeamLevelNest, null);
			int dayMaxCount = this._doc.GetDayMaxCount(TeamLevelType.TeamLevelNest, null);
			this.SetSpirit(dayCount, dayMaxCount);
		}

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

		protected void OnNestClicked(IXUISprite sp)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch((int)sp.ID);
		}

		protected bool OnNestClicked(IXUIButton button)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch((int)button.ID);
			return true;
		}

		public static int GetDayLeftCount()
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			return specificDocument.GetDayCount(TeamLevelType.TeamLevelNest, null);
		}

		private XExpeditionDocument _doc;

		public XUIPool m_nestPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel _value;

		public XNumberTween m_ValueTween;

		public IXUIButton m_addFatigue;

		public IXUILabel m_lbMyPPT;
	}
}
