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

	internal class ActivityExpeditionHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.Find("Panel/ExpediTpl");
			this.m_ExpediPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this._doc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this._doc.ExpeditionView = this;
			this._TeamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowExpediFrame();
		}

		protected override void OnHide()
		{
			this.m_ExpediPool.ReturnAll(false);
			base.OnHide();
		}

		public override void OnUnload()
		{
			this._doc.ExpeditionView = null;
			base.OnUnload();
		}

		public void ShowExpediFrame()
		{
			this.m_ExpediPool.ReturnAll(false);
			Vector3 localPosition = this.m_ExpediPool._tpl.transform.localPosition;
			float num = (float)this.m_ExpediPool.TplWidth;
			List<ExpeditionTable.RowData> expeditionList = this._doc.GetExpeditionList(TeamLevelType.TeamLevelExpdition);
			XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
			uint level = player.Attributes.Level;
			int num2 = 0;
			foreach (ExpeditionTable.RowData rowData in expeditionList)
			{
				GameObject gameObject = this.m_ExpediPool.FetchGameObject(false);
				gameObject.transform.localPosition = localPosition + new Vector3(num * (float)num2++, 0f, 0f);
				IXUILabel ixuilabel = gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUITexture ixuitexture = gameObject.transform.FindChild("ExpediBg").GetComponent("XUITexture") as IXUITexture;
				IXUIButton ixuibutton = gameObject.transform.FindChild("Do").GetComponent("XUIButton") as IXUIButton;
				IXUILabel ixuilabel2 = ixuibutton.gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
				ixuibutton.ID = (ulong)((long)rowData.DNExpeditionID);
				IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = ixuibutton.ID;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnExpediBgClicked));
				ixuilabel.SetText(rowData.DNExpeditionName);
				bool flag = rowData.ViewableDropList != null;
				if (flag)
				{
					for (int i = 0; i < 2; i++)
					{
						GameObject gameObject2 = gameObject.transform.FindChild("Item" + (i + 1)).gameObject;
						bool flag2 = i >= rowData.ViewableDropList.Length;
						if (flag2)
						{
							XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, 0, 0, false);
						}
						else
						{
							IXUISprite ixuisprite2 = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
							ixuisprite2.ID = (ulong)rowData.ViewableDropList[i];
							XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)ixuisprite2.ID, 0, false);
							ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
						}
					}
				}
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDoClicked));
				bool flag3 = this._TeamDoc.MyTeam != null && (ulong)this._TeamDoc.MyTeam.teamBrief.dungeonID == (ulong)((long)rowData.DNExpeditionID);
				if (flag3)
				{
					ixuilabel2.SetText(XStringDefineProxy.GetString("TEAM_LEAVE"));
				}
				else
				{
					ixuilabel2.SetText(XStringDefineProxy.GetString("TEAM_ENTER"));
				}
				bool flag4 = (ulong)level >= (ulong)((long)rowData.RequiredLevel);
				if (flag4)
				{
					ixuibutton.SetEnable(true, false);
				}
				else
				{
					ixuibutton.SetEnable(false, false);
					ixuilabel2.SetText(XStringDefineProxy.GetString("EXPEDITION_REQUIRED_LEVEL", new object[]
					{
						rowData.RequiredLevel
					}));
				}
			}
		}

		protected void OnExpediBgClicked(IXUISprite sp)
		{
			this.ShowTeamView((uint)sp.ID);
		}

		protected bool OnDoClicked(IXUIButton btn)
		{
			bool flag = this._TeamDoc.MyTeam != null && (ulong)this._TeamDoc.MyTeam.teamBrief.dungeonID == btn.ID;
			bool result;
			if (flag)
			{
				this._TeamDoc.ReqTeamOp(TeamOperate.TEAM_LEAVE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
				result = true;
			}
			else
			{
				this.ShowTeamView((uint)btn.ID);
				result = true;
			}
			return result;
		}

		protected void ShowTeamView(uint id)
		{
			this._TeamDoc.TryChangeToExpID((int)id);
			DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
		}

		public static int GetDayLeftCount()
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			return specificDocument.GetDayCount(TeamLevelType.TeamLevelExpdition, null);
		}

		public XUIPool m_ExpediPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XExpeditionDocument _doc;

		private XTeamDocument _TeamDoc;
	}
}
