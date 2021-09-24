using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTitleDocument : XDocComponent
	{

		public TitleDlg TitleView { get; set; }

		public static uint TitleMaxLevel { get; private set; }

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

		public bool bAvaibleTitleIcon
		{
			get
			{
				return XSingleton<XGameSysMgr>.singleton.IsSystemOpen(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Title));
			}
		}

		public override uint ID
		{
			get
			{
				return XTitleDocument.uuID;
			}
		}

		public uint CurrentTitleID
		{
			get
			{
				return XSingleton<XAttributeMgr>.singleton.XPlayerData.TitleID;
			}
		}

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

		public bool TryGetTitle(uint titleID, out TitleTable.RowData rowData)
		{
			rowData = XTitleDocument.GetTitle(titleID);
			return rowData != null;
		}

		public TitleTable.RowData CurrentTitle
		{
			get
			{
				return XTitleDocument.GetTitle(this.CurrentTitleID);
			}
		}

		public bool IsMax
		{
			get
			{
				return XTitleDocument.TitleMaxLevel <= this.CurrentTitleID;
			}
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XTitleDocument.AsyncLoader.AddTask("Table/TitleTable", XTitleDocument.m_TitleTable, false);
			XTitleDocument.AsyncLoader.Execute(callback);
			XTitleDocument.m_cacheTitles.Clear();
		}

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

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_AttributeChange, new XComponent.XEventHandler(this.OnAttributeChange));
		}

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

		public void GetTitleLevelUp()
		{
			bool flag = !this.bEnableTitleLevelUp;
			if (!flag)
			{
				RpcC2G_TitleLevelUp rpc = new RpcC2G_TitleLevelUp();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
			}
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XTitleDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static TitleTable m_TitleTable = new TitleTable();

		public static int TITLE_FRAME_RATE = 10;

		private static Dictionary<uint, Dictionary<uint, TitleTable.RowData>> m_cacheTitles = new Dictionary<uint, Dictionary<uint, TitleTable.RowData>>();

		private bool m_enableTitleLevelUp = false;
	}
}
