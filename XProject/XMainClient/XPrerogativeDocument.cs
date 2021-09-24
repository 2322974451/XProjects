using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPrerogativeDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XPrerogativeDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XPrerogativeDocument.AsyncLoader.AddTask("Table/PrerogativeContent", XPrerogativeDocument._prerogativeContent, false);
			XPrerogativeDocument.AsyncLoader.Execute(callback);
		}

		public static uint GetDefaultPreID(uint type)
		{
			return XPrerogativeDocument.DefaultContent.ContainsKey(type) ? XPrerogativeDocument.DefaultContent[type] : 0U;
		}

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

		public static string ConvertTypeToPreContent(PrerogativeType type, uint pid = 0U)
		{
			uint type2 = (uint)XFastEnumIntEqualityComparer<PrerogativeType>.ToInt(type);
			return XPrerogativeDocument.ConvertTypeToPreContent(type2, pid);
		}

		public static string ConvertTypeToPreContent(PrerogativeType type, List<uint> ids = null)
		{
			uint type2 = (uint)XFastEnumIntEqualityComparer<PrerogativeType>.ToInt(type);
			return XPrerogativeDocument.ConvertTypeToPreContent(type2, ids);
		}

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

		public static PrerogativeContent.RowData ConvertTypeToPre(uint type, List<uint> ids = null)
		{
			uint key = XPrerogativeDocument.ConvertTypeToPreId(type, ids);
			return XPrerogativeDocument._prerogativeContent.GetByID(key);
		}

		public static PrerogativeContent.RowData GetPrerogativeByID(uint id)
		{
			return XPrerogativeDocument._prerogativeContent.GetByID(id);
		}

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

		public void Initialize(List<uint> preIDs, List<uint> activeIDs)
		{
			this._caches = preIDs;
			this._activeIds = activeIDs;
		}

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

		public List<uint> PlayerSetid
		{
			get
			{
				return this._caches;
			}
		}

		public string GetPreContent(PrerogativeType type)
		{
			uint type2 = (uint)XFastEnumIntEqualityComparer<PrerogativeType>.ToInt(type);
			return this.GetPreContent(type2);
		}

		public string GetPreContent(uint type)
		{
			return XPrerogativeDocument.ConvertTypeToPreContent(type, this._caches);
		}

		public PrerogativeContent.RowData GetPreContentData(uint type)
		{
			return XPrerogativeDocument.ConvertTypeToPre(type, this._caches);
		}

		public uint GetPreContentID(uint type)
		{
			return XPrerogativeDocument.ConvertTypeToPreId(type, this._caches);
		}

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

		public bool IsActived(uint id)
		{
			bool flag = this._activeIds == null;
			return !flag && this._activeIds.Contains(id);
		}

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

		public void HidePreCache(uint type)
		{
			uint num = XPrerogativeDocument.DefaultContent.ContainsKey(type) ? XPrerogativeDocument.DefaultContent[type] : 0U;
			bool flag = num > 0U;
			if (flag)
			{
				this.TrySendPreCache(num);
			}
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PrerogativeDocument");

		private static PrerogativeContent _prerogativeContent = new PrerogativeContent();

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static Dictionary<uint, uint> DefaultContent = new Dictionary<uint, uint>();

		public PrerogativeDlg View = null;

		private List<uint> _caches;

		private List<uint> _activeIds;

		private uint _cacheActiveId;

		private bool _RedPoint = false;
	}
}
