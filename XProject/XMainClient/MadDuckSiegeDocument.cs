using System;
using System.Collections.Generic;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class MadDuckSiegeDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return MadDuckSiegeDocument.uuID;
			}
		}

		public static MadDuckSiegeDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(MadDuckSiegeDocument.uuID) as MadDuckSiegeDocument;
			}
		}

		public XThemeActivityDocument ActDoc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XThemeActivityDocument.uuID) as XThemeActivityDocument;
			}
		}

		public int systemID
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.sys);
			}
		}

		public SuperActivityTime.RowData ActInfo
		{
			get
			{
				bool flag = this._actInfo != null;
				SuperActivityTime.RowData actInfo;
				if (flag)
				{
					actInfo = this._actInfo;
				}
				else
				{
					XTempActivityDocument specificDocument = XDocuments.GetSpecificDocument<XTempActivityDocument>(XTempActivityDocument.uuID);
					this._actInfo = specificDocument.GetDataBySystemID((uint)this.systemID);
					bool flag2 = this._actInfo == null;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("SuperActivityTime SystemID:" + this.systemID + "No Find", null, null, null, null, null);
					}
					actInfo = this._actInfo;
				}
				return actInfo;
			}
		}

		public List<SuperActivityTask.RowData> ActTask
		{
			get
			{
				bool flag = this._ActTask == null;
				if (flag)
				{
					this._ActTask = XTempActivityDocument.Doc.GetDataByActivityType(this.ActInfo.actid);
				}
				return this._ActTask;
			}
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ActivityTaskUpdate, new XComponent.XEventHandler(this.OnTaskChange));
		}

		private bool OnTaskChange(XEventArgs e)
		{
			XActivityTaskUpdatedArgs xactivityTaskUpdatedArgs = e as XActivityTaskUpdatedArgs;
			bool flag = xactivityTaskUpdatedArgs.xActID == this.ActInfo.actid;
			if (flag)
			{
				bool flag2 = DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.m_MadDuckHandler != null && DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.m_MadDuckHandler.m_ActivityExchangeRewardHandler != null && DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.m_MadDuckHandler.m_ActivityExchangeRewardHandler.IsVisible();
				if (flag2)
				{
					DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.m_MadDuckHandler.m_ActivityExchangeRewardHandler.RefreshList(false);
				}
			}
			return true;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public bool GetRedPoint()
		{
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(int.Parse(this.cost[0]));
			return itemCount >= ulong.Parse(this.cost[1]);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MadDuckSiegeDocument");

		public uint sceneID = uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MadDuckSceneID"));

		public XSysDefine sys = XSysDefine.XSys_ThemeActivity_MadDuck;

		private SuperActivityTime.RowData _actInfo = null;

		public string[] cost = XSingleton<XGlobalConfig>.singleton.GetValue("DuckTickets").Split(new char[]
		{
			'='
		});

		private List<SuperActivityTask.RowData> _ActTask = null;
	}
}
