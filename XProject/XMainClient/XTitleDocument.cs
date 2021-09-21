using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A05 RID: 2565
	internal class XTitleDocument : XDocComponent
	{
		// Token: 0x17002E83 RID: 11907
		// (get) Token: 0x06009D1F RID: 40223 RVA: 0x00198C58 File Offset: 0x00196E58
		// (set) Token: 0x06009D1E RID: 40222 RVA: 0x00198C4F File Offset: 0x00196E4F
		public TitleDlg TitleView { get; set; }

		// Token: 0x17002E84 RID: 11908
		// (get) Token: 0x06009D20 RID: 40224 RVA: 0x00198C60 File Offset: 0x00196E60
		// (set) Token: 0x06009D21 RID: 40225 RVA: 0x00198C67 File Offset: 0x00196E67
		public static uint TitleMaxLevel { get; private set; }

		// Token: 0x06009D22 RID: 40226 RVA: 0x00198C70 File Offset: 0x00196E70
		public static string GetTitleWithFormat(uint titleID, string name)
		{
			string text = name;
			bool flag = titleID > 0U;
			if (flag)
			{
				TitleTable.RowData title = XTitleDocument.GetTitle(titleID);
				bool flag2 = title != null;
				if (flag2)
				{
					text = XSingleton<XCommon>.singleton.StringCombine(XLabelSymbolHelper.FormatAnimation(title.RankAtlas, title.RankIcon, 10), text);
				}
			}
			return text;
		}

		// Token: 0x17002E85 RID: 11909
		// (get) Token: 0x06009D23 RID: 40227 RVA: 0x00198CC4 File Offset: 0x00196EC4
		// (set) Token: 0x06009D24 RID: 40228 RVA: 0x00198CDC File Offset: 0x00196EDC
		public bool bEnableTitleLevelUp
		{
			get
			{
				return this.m_enableTitleLevelUp;
			}
			set
			{
				this.m_enableTitleLevelUp = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Title, true);
			}
		}

		// Token: 0x17002E86 RID: 11910
		// (get) Token: 0x06009D25 RID: 40229 RVA: 0x00198CF4 File Offset: 0x00196EF4
		public bool bAvaibleTitleIcon
		{
			get
			{
				return XSingleton<XGameSysMgr>.singleton.IsSystemOpen(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Title));
			}
		}

		// Token: 0x17002E87 RID: 11911
		// (get) Token: 0x06009D26 RID: 40230 RVA: 0x00198D18 File Offset: 0x00196F18
		public override uint ID
		{
			get
			{
				return XTitleDocument.uuID;
			}
		}

		// Token: 0x17002E88 RID: 11912
		// (get) Token: 0x06009D27 RID: 40231 RVA: 0x00198D30 File Offset: 0x00196F30
		public uint CurrentTitleID
		{
			get
			{
				return XSingleton<XAttributeMgr>.singleton.XPlayerData.TitleID;
			}
		}

		// Token: 0x06009D28 RID: 40232 RVA: 0x00198D54 File Offset: 0x00196F54
		public static TitleTable.RowData GetTitle(uint titleID)
		{
			Dictionary<uint, TitleTable.RowData> dictionary;
			bool flag = XTitleDocument.m_cacheTitles.TryGetValue(XItemDrawerParam.DefaultProfession, out dictionary);
			if (flag)
			{
				TitleTable.RowData result;
				bool flag2 = dictionary.TryGetValue(titleID, out result);
				if (flag2)
				{
					return result;
				}
			}
			return null;
		}

		// Token: 0x06009D29 RID: 40233 RVA: 0x00198D94 File Offset: 0x00196F94
		public bool TryGetTitle(uint titleID, out TitleTable.RowData rowData)
		{
			rowData = XTitleDocument.GetTitle(titleID);
			return rowData != null;
		}

		// Token: 0x17002E89 RID: 11913
		// (get) Token: 0x06009D2A RID: 40234 RVA: 0x00198DB4 File Offset: 0x00196FB4
		public TitleTable.RowData CurrentTitle
		{
			get
			{
				return XTitleDocument.GetTitle(this.CurrentTitleID);
			}
		}

		// Token: 0x17002E8A RID: 11914
		// (get) Token: 0x06009D2B RID: 40235 RVA: 0x00198DD4 File Offset: 0x00196FD4
		public bool IsMax
		{
			get
			{
				return XTitleDocument.TitleMaxLevel <= this.CurrentTitleID;
			}
		}

		// Token: 0x17002E8B RID: 11915
		// (get) Token: 0x06009D2C RID: 40236 RVA: 0x00198DF8 File Offset: 0x00196FF8
		public TitleTable.RowData NextTitle
		{
			get
			{
				bool flag = this.CurrentTitleID >= XTitleDocument.TitleMaxLevel;
				TitleTable.RowData result;
				if (flag)
				{
					result = null;
				}
				else
				{
					result = XTitleDocument.GetTitle(this.CurrentTitleID + 1U);
				}
				return result;
			}
		}

		// Token: 0x06009D2D RID: 40237 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009D2E RID: 40238 RVA: 0x00198E2F File Offset: 0x0019702F
		public static void Execute(OnLoadedCallback callback = null)
		{
			XTitleDocument.AsyncLoader.AddTask("Table/TitleTable", XTitleDocument.m_TitleTable, false);
			XTitleDocument.AsyncLoader.Execute(callback);
			XTitleDocument.m_cacheTitles.Clear();
		}

		// Token: 0x06009D2F RID: 40239 RVA: 0x00198E60 File Offset: 0x00197060
		public static void OnTableLoaded()
		{
			int i = 0;
			int num = XTitleDocument.m_TitleTable.Table.Length;
			while (i < num)
			{
				Dictionary<uint, TitleTable.RowData> dictionary;
				bool flag = !XTitleDocument.m_cacheTitles.TryGetValue(XTitleDocument.m_TitleTable.Table[i].BasicProfession, out dictionary);
				if (flag)
				{
					dictionary = new Dictionary<uint, TitleTable.RowData>();
					XTitleDocument.m_cacheTitles.Add(XTitleDocument.m_TitleTable.Table[i].BasicProfession, dictionary);
				}
				dictionary.Add(XTitleDocument.m_TitleTable.Table[i].RankID, XTitleDocument.m_TitleTable.Table[i]);
				XTitleDocument.TitleMaxLevel = Math.Max(XTitleDocument.m_TitleTable.Table[i].RankID, XTitleDocument.TitleMaxLevel);
				i++;
			}
		}

		// Token: 0x06009D30 RID: 40240 RVA: 0x00198F24 File Offset: 0x00197124
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_AttributeChange, new XComponent.XEventHandler(this.OnAttributeChange));
		}

		// Token: 0x06009D31 RID: 40241 RVA: 0x00198F78 File Offset: 0x00197178
		private bool OnAttributeChange(XEventArgs e)
		{
			bool flag = !this.bAvaibleTitleIcon;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XAttrChangeEventArgs xattrChangeEventArgs = e as XAttrChangeEventArgs;
				bool flag2 = xattrChangeEventArgs.AttrKey == XAttributeDefine.XAttr_POWER_POINT_Basic;
				if (flag2)
				{
					this.RefreshTitleLevelUp();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06009D32 RID: 40242 RVA: 0x00198FBC File Offset: 0x001971BC
		private bool OnVirtualItemChanged(XEventArgs args)
		{
			bool flag = !this.bAvaibleTitleIcon;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.RefreshTitleLevelUp();
				result = true;
			}
			return result;
		}

		// Token: 0x06009D33 RID: 40243 RVA: 0x00198FE8 File Offset: 0x001971E8
		public void RefreshTitleLevelUp()
		{
			TitleTable.RowData nextTitle = this.NextTitle;
			bool bEnableTitleLevelUp = true;
			bool flag = nextTitle == null || nextTitle.NeedPowerPoint > XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
			if (flag)
			{
				bEnableTitleLevelUp = false;
			}
			else
			{
				int i = 0;
				int count = nextTitle.NeedItem.Count;
				while (i < count)
				{
					int num = (int)XBagDocument.BagDoc.GetItemCount((int)nextTitle.NeedItem[i, 0]);
					bool flag2 = (long)num < (long)((ulong)nextTitle.NeedItem[i, 1]);
					if (flag2)
					{
						bEnableTitleLevelUp = false;
						break;
					}
					i++;
				}
			}
			this.bEnableTitleLevelUp = bEnableTitleLevelUp;
			bool flag3 = this.TitleView != null && this.TitleView.IsVisible();
			if (flag3)
			{
				this.TitleView.Refresh();
			}
		}

		// Token: 0x06009D34 RID: 40244 RVA: 0x001990BC File Offset: 0x001972BC
		public void GetTitleLevelUp()
		{
			bool flag = !this.bEnableTitleLevelUp;
			if (!flag)
			{
				RpcC2G_TitleLevelUp rpc = new RpcC2G_TitleLevelUp();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
			}
		}

		// Token: 0x06009D35 RID: 40245 RVA: 0x001990EC File Offset: 0x001972EC
		public void OnGetTitleLevelUp(TitleLevelUpRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XSingleton<XAttributeMgr>.singleton.XPlayerData.TitleID = oRes.titleID;
				XTitleInfoChange @event = XEventPool<XTitleInfoChange>.GetEvent();
				@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				this.RefreshTitleLevelUp();
				bool flag2 = oRes.titleID > 0U && !DlgBase<TitleShareDlg, TitleShareBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<TitleShareDlg, TitleShareBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				}
			}
		}

		// Token: 0x06009D36 RID: 40246 RVA: 0x0019918C File Offset: 0x0019738C
		public void TitleLevelChange(uint titleID)
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData.TitleID != titleID;
			if (flag)
			{
				XSingleton<XAttributeMgr>.singleton.XPlayerData.TitleID = titleID;
				XTitleInfoChange @event = XEventPool<XTitleInfoChange>.GetEvent();
				@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				this.RefreshTitleLevelUp();
				bool flag2 = titleID > 0U && !DlgBase<TitleShareDlg, TitleShareBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<TitleShareDlg, TitleShareBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				}
			}
		}

		// Token: 0x04003747 RID: 14151
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XTitleDocument");

		// Token: 0x04003748 RID: 14152
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003749 RID: 14153
		private static TitleTable m_TitleTable = new TitleTable();

		// Token: 0x0400374A RID: 14154
		public static int TITLE_FRAME_RATE = 10;

		// Token: 0x0400374B RID: 14155
		private static Dictionary<uint, Dictionary<uint, TitleTable.RowData>> m_cacheTitles = new Dictionary<uint, Dictionary<uint, TitleTable.RowData>>();

		// Token: 0x0400374C RID: 14156
		private bool m_enableTitleLevelUp = false;
	}
}
