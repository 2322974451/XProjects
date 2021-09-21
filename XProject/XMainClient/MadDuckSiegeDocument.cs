using System;
using System.Collections.Generic;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C76 RID: 3190
	internal class MadDuckSiegeDocument : XDocComponent
	{
		// Token: 0x170031EB RID: 12779
		// (get) Token: 0x0600B453 RID: 46163 RVA: 0x00233600 File Offset: 0x00231800
		public override uint ID
		{
			get
			{
				return MadDuckSiegeDocument.uuID;
			}
		}

		// Token: 0x170031EC RID: 12780
		// (get) Token: 0x0600B454 RID: 46164 RVA: 0x00233618 File Offset: 0x00231818
		public static MadDuckSiegeDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(MadDuckSiegeDocument.uuID) as MadDuckSiegeDocument;
			}
		}

		// Token: 0x170031ED RID: 12781
		// (get) Token: 0x0600B455 RID: 46165 RVA: 0x00233644 File Offset: 0x00231844
		public XThemeActivityDocument ActDoc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XThemeActivityDocument.uuID) as XThemeActivityDocument;
			}
		}

		// Token: 0x170031EE RID: 12782
		// (get) Token: 0x0600B456 RID: 46166 RVA: 0x00233670 File Offset: 0x00231870
		public int systemID
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.sys);
			}
		}

		// Token: 0x170031EF RID: 12783
		// (get) Token: 0x0600B457 RID: 46167 RVA: 0x00233690 File Offset: 0x00231890
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

		// Token: 0x170031F0 RID: 12784
		// (get) Token: 0x0600B458 RID: 46168 RVA: 0x00233714 File Offset: 0x00231914
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

		// Token: 0x0600B459 RID: 46169 RVA: 0x00233756 File Offset: 0x00231956
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ActivityTaskUpdate, new XComponent.XEventHandler(this.OnTaskChange));
		}

		// Token: 0x0600B45A RID: 46170 RVA: 0x00233778 File Offset: 0x00231978
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

		// Token: 0x0600B45B RID: 46171 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600B45C RID: 46172 RVA: 0x002337FC File Offset: 0x002319FC
		public bool GetRedPoint()
		{
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(int.Parse(this.cost[0]));
			return itemCount >= ulong.Parse(this.cost[1]);
		}

		// Token: 0x040045F1 RID: 17905
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MadDuckSiegeDocument");

		// Token: 0x040045F2 RID: 17906
		public uint sceneID = uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MadDuckSceneID"));

		// Token: 0x040045F3 RID: 17907
		public XSysDefine sys = XSysDefine.XSys_ThemeActivity_MadDuck;

		// Token: 0x040045F4 RID: 17908
		private SuperActivityTime.RowData _actInfo = null;

		// Token: 0x040045F5 RID: 17909
		public string[] cost = XSingleton<XGlobalConfig>.singleton.GetValue("DuckTickets").Split(new char[]
		{
			'='
		});

		// Token: 0x040045F6 RID: 17910
		private List<SuperActivityTask.RowData> _ActTask = null;
	}
}
