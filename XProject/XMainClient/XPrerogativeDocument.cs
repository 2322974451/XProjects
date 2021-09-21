using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000963 RID: 2403
	internal class XPrerogativeDocument : XDocComponent
	{
		// Token: 0x17002C50 RID: 11344
		// (get) Token: 0x060090B8 RID: 37048 RVA: 0x0014A278 File Offset: 0x00148478
		public override uint ID
		{
			get
			{
				return XPrerogativeDocument.uuID;
			}
		}

		// Token: 0x060090B9 RID: 37049 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x060090BA RID: 37050 RVA: 0x0014A28F File Offset: 0x0014848F
		public static void Execute(OnLoadedCallback callback = null)
		{
			XPrerogativeDocument.AsyncLoader.AddTask("Table/PrerogativeContent", XPrerogativeDocument._prerogativeContent, false);
			XPrerogativeDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060090BB RID: 37051 RVA: 0x0014A2B4 File Offset: 0x001484B4
		public static uint GetDefaultPreID(uint type)
		{
			return XPrerogativeDocument.DefaultContent.ContainsKey(type) ? XPrerogativeDocument.DefaultContent[type] : 0U;
		}

		// Token: 0x060090BC RID: 37052 RVA: 0x0014A2E4 File Offset: 0x001484E4
		public static void OnTableLoaded()
		{
			XPrerogativeDocument.DefaultContent.Clear();
			int i = 0;
			int num = XPrerogativeDocument._prerogativeContent.Table.Length;
			while (i < num)
			{
				PrerogativeContent.RowData rowData = XPrerogativeDocument._prerogativeContent.Table[i];
				bool flag = (ulong)rowData.Normal == (ulong)((long)XFastEnumIntEqualityComparer<PrerogativeNormalType>.ToInt(PrerogativeNormalType.PreDefault)) && !XPrerogativeDocument.DefaultContent.ContainsKey(rowData.Type);
				if (flag)
				{
					XPrerogativeDocument.DefaultContent.Add(rowData.Type, rowData.ID);
				}
				i++;
			}
		}

		// Token: 0x060090BD RID: 37053 RVA: 0x0014A36C File Offset: 0x0014856C
		public static uint ConvertTypeToPreId(uint type, List<uint> ids)
		{
			bool flag = ids != null;
			if (flag)
			{
				int i = 0;
				int count = ids.Count;
				while (i < count)
				{
					bool flag2 = XPrerogativeDocument.ConvertPreIdToType(ids[i]) == type;
					if (flag2)
					{
						return ids[i];
					}
					i++;
				}
			}
			return XPrerogativeDocument.DefaultContent[type];
		}

		// Token: 0x060090BE RID: 37054 RVA: 0x0014A3D0 File Offset: 0x001485D0
		public static uint ConvertTypeToPreId(uint type, uint id)
		{
			bool flag = id > 0U;
			if (flag)
			{
				bool flag2 = XPrerogativeDocument.ConvertPreIdToType(id) == type;
				if (flag2)
				{
					return id;
				}
			}
			return XPrerogativeDocument.DefaultContent[type];
		}

		// Token: 0x060090BF RID: 37055 RVA: 0x0014A408 File Offset: 0x00148608
		public static string ConvertTypeToPreContent(PrerogativeType type, uint pid = 0U)
		{
			uint type2 = (uint)XFastEnumIntEqualityComparer<PrerogativeType>.ToInt(type);
			return XPrerogativeDocument.ConvertTypeToPreContent(type2, pid);
		}

		// Token: 0x060090C0 RID: 37056 RVA: 0x0014A428 File Offset: 0x00148628
		public static string ConvertTypeToPreContent(PrerogativeType type, List<uint> ids = null)
		{
			uint type2 = (uint)XFastEnumIntEqualityComparer<PrerogativeType>.ToInt(type);
			return XPrerogativeDocument.ConvertTypeToPreContent(type2, ids);
		}

		// Token: 0x060090C1 RID: 37057 RVA: 0x0014A448 File Offset: 0x00148648
		public static string ConvertTypeToPreContent(uint type, uint pid = 0U)
		{
			bool flag = type == 0U;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				uint key = XPrerogativeDocument.ConvertTypeToPreId(type, pid);
				PrerogativeContent.RowData byID = XPrerogativeDocument._prerogativeContent.GetByID(key);
				result = ((byID != null) ? byID.Content : string.Empty);
			}
			return result;
		}

		// Token: 0x060090C2 RID: 37058 RVA: 0x0014A490 File Offset: 0x00148690
		public static string ConvertTypeToPreContent(uint type, List<uint> ids = null)
		{
			bool flag = type == 0U;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				uint key = XPrerogativeDocument.ConvertTypeToPreId(type, ids);
				PrerogativeContent.RowData byID = XPrerogativeDocument._prerogativeContent.GetByID(key);
				result = ((byID != null) ? byID.Content : string.Empty);
			}
			return result;
		}

		// Token: 0x060090C3 RID: 37059 RVA: 0x0014A4D8 File Offset: 0x001486D8
		public static PrerogativeContent.RowData ConvertTypeToPre(uint type, List<uint> ids = null)
		{
			uint key = XPrerogativeDocument.ConvertTypeToPreId(type, ids);
			return XPrerogativeDocument._prerogativeContent.GetByID(key);
		}

		// Token: 0x060090C4 RID: 37060 RVA: 0x0014A500 File Offset: 0x00148700
		public static PrerogativeContent.RowData GetPrerogativeByID(uint id)
		{
			return XPrerogativeDocument._prerogativeContent.GetByID(id);
		}

		// Token: 0x060090C5 RID: 37061 RVA: 0x0014A520 File Offset: 0x00148720
		private static uint ConvertPreIdToType(uint id)
		{
			PrerogativeContent.RowData byID = XPrerogativeDocument._prerogativeContent.GetByID(id);
			bool flag = byID != null;
			uint result;
			if (flag)
			{
				result = byID.Type;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		// Token: 0x060090C6 RID: 37062 RVA: 0x0014A550 File Offset: 0x00148750
		public void Initialize(List<uint> preIDs, List<uint> activeIDs)
		{
			this._caches = preIDs;
			this._activeIds = activeIDs;
		}

		// Token: 0x17002C51 RID: 11345
		// (get) Token: 0x060090C7 RID: 37063 RVA: 0x0014A564 File Offset: 0x00148764
		// (set) Token: 0x060090C8 RID: 37064 RVA: 0x0014A57C File Offset: 0x0014877C
		public bool RedPoint
		{
			get
			{
				return this._RedPoint;
			}
			set
			{
				bool flag = this._RedPoint != value;
				if (flag)
				{
					this._RedPoint = value;
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Prerogative, true);
				}
			}
		}

		// Token: 0x17002C52 RID: 11346
		// (get) Token: 0x060090C9 RID: 37065 RVA: 0x0014A5B4 File Offset: 0x001487B4
		public List<uint> PlayerSetid
		{
			get
			{
				return this._caches;
			}
		}

		// Token: 0x060090CA RID: 37066 RVA: 0x0014A5CC File Offset: 0x001487CC
		public string GetPreContent(PrerogativeType type)
		{
			uint type2 = (uint)XFastEnumIntEqualityComparer<PrerogativeType>.ToInt(type);
			return this.GetPreContent(type2);
		}

		// Token: 0x060090CB RID: 37067 RVA: 0x0014A5EC File Offset: 0x001487EC
		public string GetPreContent(uint type)
		{
			return XPrerogativeDocument.ConvertTypeToPreContent(type, this._caches);
		}

		// Token: 0x060090CC RID: 37068 RVA: 0x0014A60C File Offset: 0x0014880C
		public PrerogativeContent.RowData GetPreContentData(uint type)
		{
			return XPrerogativeDocument.ConvertTypeToPre(type, this._caches);
		}

		// Token: 0x060090CD RID: 37069 RVA: 0x0014A62C File Offset: 0x0014882C
		public uint GetPreContentID(uint type)
		{
			return XPrerogativeDocument.ConvertTypeToPreId(type, this._caches);
		}

		// Token: 0x060090CE RID: 37070 RVA: 0x0014A64C File Offset: 0x0014884C
		public bool TryGetContentByType(ref List<PrerogativeContent.RowData> list, uint type)
		{
			bool flag = list == null;
			if (flag)
			{
				list = new List<PrerogativeContent.RowData>();
			}
			list.Clear();
			int i = 0;
			int num = XPrerogativeDocument._prerogativeContent.Table.Length;
			while (i < num)
			{
				bool flag2 = XPrerogativeDocument._prerogativeContent.Table[i].Type == type && XPrerogativeDocument._prerogativeContent.Table[i].Normal != 2U;
				if (flag2)
				{
					list.Add(XPrerogativeDocument._prerogativeContent.Table[i]);
				}
				i++;
			}
			return true;
		}

		// Token: 0x060090CF RID: 37071 RVA: 0x0014A6E4 File Offset: 0x001488E4
		public bool IsActived(uint id)
		{
			bool flag = this._activeIds == null;
			return !flag && this._activeIds.Contains(id);
		}

		// Token: 0x060090D0 RID: 37072 RVA: 0x0014A714 File Offset: 0x00148914
		private bool CachePreValue(uint type, uint value)
		{
			bool flag = this._caches != null;
			if (flag)
			{
				int i = 0;
				int count = this._caches.Count;
				while (i < count)
				{
					bool flag2 = XPrerogativeDocument.ConvertPreIdToType(this._caches[i]) == type;
					if (flag2)
					{
						bool flag3 = this._caches[i] == value;
						if (flag3)
						{
							return false;
						}
						this._caches.RemoveAt(i);
						break;
					}
					else
					{
						i++;
					}
				}
			}
			else
			{
				this._caches = new List<uint>();
			}
			this._caches.Add(value);
			return true;
		}

		// Token: 0x060090D1 RID: 37073 RVA: 0x0014A7B8 File Offset: 0x001489B8
		public bool TrySendPreCache(uint value)
		{
			PrerogativeContent.RowData byID = XPrerogativeDocument._prerogativeContent.GetByID(value);
			bool flag = byID != null && this.CachePreValue(byID.Type, value);
			bool result;
			if (flag)
			{
				RpcC2G_SetPreShow rpcC2G_SetPreShow = new RpcC2G_SetPreShow();
				rpcC2G_SetPreShow.oArg.showid.AddRange(this._caches);
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SetPreShow);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060090D2 RID: 37074 RVA: 0x0014A81C File Offset: 0x00148A1C
		public void HidePreCache(uint type)
		{
			uint num = XPrerogativeDocument.DefaultContent.ContainsKey(type) ? XPrerogativeDocument.DefaultContent[type] : 0U;
			bool flag = num > 0U;
			if (flag)
			{
				this.TrySendPreCache(num);
			}
		}

		// Token: 0x060090D3 RID: 37075 RVA: 0x0014A858 File Offset: 0x00148A58
		public void ReceivePreCache(SetPreShowArg oArg, SetPreShowRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				this._caches = oArg.showid;
				this.Dispatch();
			}
		}

		// Token: 0x060090D4 RID: 37076 RVA: 0x0014A8A0 File Offset: 0x00148AA0
		public void TrySendActivePre(uint value)
		{
			PrerogativeContent.RowData byID = XPrerogativeDocument._prerogativeContent.GetByID(value);
			bool flag = byID != null;
			if (flag)
			{
				RpcC2G_ActivatePreShow rpcC2G_ActivatePreShow = new RpcC2G_ActivatePreShow();
				rpcC2G_ActivatePreShow.oArg.id = value;
				this._cacheActiveId = value;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ActivatePreShow);
			}
		}

		// Token: 0x060090D5 RID: 37077 RVA: 0x0014A8EC File Offset: 0x00148AEC
		public void ReceiveActiveReply(ActivatePreShowArg oArg, ActivatePreShowRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("Prerogative_ActiveSuccess"), "fece00");
				bool flag2 = !this._activeIds.Contains(this._cacheActiveId);
				if (flag2)
				{
					this._activeIds.Add(this._cacheActiveId);
				}
				this.Dispatch();
			}
		}

		// Token: 0x060090D6 RID: 37078 RVA: 0x0014A96C File Offset: 0x00148B6C
		private void Dispatch()
		{
			XPrerogativeChangeArgs @event = XEventPool<XPrerogativeChangeArgs>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			bool flag = DlgBase<PrerogativeDlg, PrerogativeDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<PrerogativeDlg, PrerogativeDlgBehaviour>.singleton.Refresh();
			}
			bool flag2 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetHeadIcon();
			}
		}

		// Token: 0x04002FF7 RID: 12279
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PrerogativeDocument");

		// Token: 0x04002FF8 RID: 12280
		private static PrerogativeContent _prerogativeContent = new PrerogativeContent();

		// Token: 0x04002FF9 RID: 12281
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002FFA RID: 12282
		private static Dictionary<uint, uint> DefaultContent = new Dictionary<uint, uint>();

		// Token: 0x04002FFB RID: 12283
		public PrerogativeDlg View = null;

		// Token: 0x04002FFC RID: 12284
		private List<uint> _caches;

		// Token: 0x04002FFD RID: 12285
		private List<uint> _activeIds;

		// Token: 0x04002FFE RID: 12286
		private uint _cacheActiveId;

		// Token: 0x04002FFF RID: 12287
		private bool _RedPoint = false;
	}
}
