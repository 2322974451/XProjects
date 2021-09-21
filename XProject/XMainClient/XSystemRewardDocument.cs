using System;
using System.Collections.Generic;
using System.Text;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009F4 RID: 2548
	internal class XSystemRewardDocument : XDocComponent
	{
		// Token: 0x17002E5A RID: 11866
		// (get) Token: 0x06009C09 RID: 39945 RVA: 0x00191664 File Offset: 0x0018F864
		public override uint ID
		{
			get
			{
				return XSystemRewardDocument.uuID;
			}
		}

		// Token: 0x17002E5B RID: 11867
		// (get) Token: 0x06009C0A RID: 39946 RVA: 0x0019167C File Offset: 0x0018F87C
		public List<XSystemRewardData> DataList
		{
			get
			{
				return this._DataList;
			}
		}

		// Token: 0x06009C0B RID: 39947 RVA: 0x00191694 File Offset: 0x0018F894
		public static void Execute(OnLoadedCallback callback = null)
		{
			XSystemRewardDocument.AsyncLoader.AddTask("Table/SystemReward", XSystemRewardDocument._reader, false);
			XSystemRewardDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009C0C RID: 39948 RVA: 0x001916B9 File Offset: 0x0018F8B9
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._DataList.Clear();
			this._DataDic.Clear();
		}

		// Token: 0x06009C0D RID: 39949 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06009C0E RID: 39950 RVA: 0x001916DC File Offset: 0x0018F8DC
		public SystemRewardTable.RowData GetTableDataByType(uint type)
		{
			return XSystemRewardDocument._reader.GetByType(type);
		}

		// Token: 0x06009C0F RID: 39951 RVA: 0x001916FC File Offset: 0x0018F8FC
		public void Add(RewardInfo info)
		{
			SystemRewardTable.RowData tableDataByType = this.GetTableDataByType(info.Type);
			XSystemRewardData xsystemRewardData = null;
			bool flag = !this._DataDic.TryGetValue(info.UniqueId, out xsystemRewardData);
			if (flag)
			{
				xsystemRewardData = new XSystemRewardData();
				this._DataList.Add(xsystemRewardData);
				this._DataDic.Add(info.UniqueId, xsystemRewardData);
			}
			xsystemRewardData.uid = info.UniqueId;
			xsystemRewardData.type = info.Type;
			xsystemRewardData.SetState(info.State);
			xsystemRewardData.itemList = info.Item;
			xsystemRewardData.param = info.Param.ToArray();
			xsystemRewardData.sortType = ((tableDataByType == null) ? 0U : tableDataByType.Sort);
			xsystemRewardData.serverName = info.name;
			xsystemRewardData.serverContent = info.comment;
		}

		// Token: 0x06009C10 RID: 39952 RVA: 0x001917C8 File Offset: 0x0018F9C8
		public void Remove(ulong uid)
		{
			XSystemRewardData item = null;
			bool flag = this._DataDic.TryGetValue(uid, out item);
			if (flag)
			{
				this._DataDic.Remove(uid);
				this._DataList.Remove(item);
			}
		}

		// Token: 0x06009C11 RID: 39953 RVA: 0x00191808 File Offset: 0x0018FA08
		public void OnRewardChanged(RewardChanged data)
		{
			foreach (ulong uid in data.RemovedRewardUniqueId)
			{
				this.Remove(uid);
			}
			foreach (RewardInfo info in data.AddedRewardInfo)
			{
				this.Add(info);
			}
			this._DataList.Sort();
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_ReceiveEnergy, true);
			bool flag = DlgBase<XWelfareView, XWelfareBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XWelfareView, XWelfareBehaviour>.singleton.RefreshData();
				DlgBase<XWelfareView, XWelfareBehaviour>.singleton.RefreshRedpoint();
			}
		}

		// Token: 0x06009C12 RID: 39954 RVA: 0x001918EC File Offset: 0x0018FAEC
		public bool HasCanFetchReward()
		{
			for (int i = 0; i < this._DataList.Count; i++)
			{
				bool flag = this._DataList[i].state > XSystemRewardState.SRS_CAN_FETCH;
				if (flag)
				{
					break;
				}
				bool flag2 = this.IsExclusiveItem(this._DataList[i]);
				if (!flag2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06009C13 RID: 39955 RVA: 0x00191954 File Offset: 0x0018FB54
		public bool HasReceiveEnergyCanFetchReward()
		{
			for (int i = 0; i < this._DataList.Count; i++)
			{
				bool flag = this._DataList[i].state > XSystemRewardState.SRS_CAN_FETCH;
				if (flag)
				{
					break;
				}
				bool flag2 = this.IsExclusiveItem(this._DataList[i]);
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06009C14 RID: 39956 RVA: 0x001919BC File Offset: 0x0018FBBC
		public bool IsExclusiveItem(XSystemRewardData _data)
		{
			bool flag = _data != null;
			if (flag)
			{
				bool flag2 = _data.type == SystemRewardTypeMrg.GetTypeUInt(SystemRewardType.RewardDinner);
				if (flag2)
				{
					return true;
				}
				bool flag3 = _data.type == SystemRewardTypeMrg.GetTypeUInt(SystemRewardType.RewardSupper);
				if (flag3)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06009C15 RID: 39957 RVA: 0x00191A08 File Offset: 0x0018FC08
		public void ReqFetchReward(ulong id)
		{
			RpcC2G_GetSystemReward rpcC2G_GetSystemReward = new RpcC2G_GetSystemReward();
			rpcC2G_GetSystemReward.oArg.RewardUniqueId = id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetSystemReward);
		}

		// Token: 0x06009C16 RID: 39958 RVA: 0x00191A38 File Offset: 0x0018FC38
		public void OnFetchReward(GetSystemRewardRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
		}

		// Token: 0x06009C17 RID: 39959 RVA: 0x00191A6C File Offset: 0x0018FC6C
		public static string GetRewardDescription(SystemRewardTable.RowData tableData, XSystemRewardData data)
		{
			SystemRewardType type = (SystemRewardType)data.type;
			SystemRewardType systemRewardType = type;
			switch (systemRewardType)
			{
			case SystemRewardType.RewardDinner:
			case SystemRewardType.RewardSupper:
				return XSystemRewardDocument.GetMealDescription(tableData.Remark, type);
			case SystemRewardType.RewardArena:
			case SystemRewardType.RewardWorldBoss:
			case SystemRewardType.RewardGuildBoss:
			case SystemRewardType.RewardGuildBossRole:
			{
				bool flag = data.param.Length < 1;
				if (flag)
				{
					return "";
				}
				goto IL_16A;
			}
			case SystemRewardType.RewardChargeFirst:
				break;
			default:
				switch (systemRewardType)
				{
				case SystemRewardType.RewardVip:
				{
					bool flag2 = data.param.Length < 1;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("VIP reward param not enough: ", data.param.Length.ToString(), null, null, null, null);
						return "";
					}
					goto IL_16A;
				}
				case SystemRewardType.RewardMonthCard:
					break;
				case SystemRewardType.RewardMakeUp:
				{
					bool flag3 = data.param.Length < 1;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Makeup reward param not enough: ", data.param.Length.ToString(), null, null, null, null);
						return "";
					}
					int elapsedSeconds = int.Parse(data.param[0]);
					return string.Format(tableData.Remark, XSingleton<UiUtility>.singleton.TimeFormatSince1970(elapsedSeconds, XStringDefineProxy.GetString("TIME_FORMAT_MONTHDAY"), false));
				}
				default:
				{
					bool flag4 = data.param.Length < 1 && tableData.SubType == 1U;
					if (flag4)
					{
						return "";
					}
					goto IL_16A;
				}
				}
				break;
			}
			return tableData.Remark;
			IL_16A:
			string remark = tableData.Remark;
			object[] param = data.param;
			return string.Format(remark, param);
		}

		// Token: 0x06009C18 RID: 39960 RVA: 0x00191BFC File Offset: 0x0018FDFC
		private static string GetMealDescription(string format, SystemRewardType type)
		{
			bool flag = type != SystemRewardType.RewardDinner && type != SystemRewardType.RewardSupper;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				bool flag2 = type == SystemRewardType.RewardSupper;
				string key;
				string key2;
				if (flag2)
				{
					key = "SupperTime";
					key2 = "SupperReward";
				}
				else
				{
					key = "DinnerTime";
					key2 = "DinnerReward";
				}
				string[] array = XSingleton<XGlobalConfig>.singleton.GetValue(key).Split(XGlobalConfig.ListSeparator);
				bool flag3 = array.Length != 4;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Meal time count should be 4: ", array.Length.ToString(), null, null, null, null);
					result = "";
				}
				else
				{
					int elapsedSeconds = (int.Parse(array[0]) * 60 + int.Parse(array[1])) * 60;
					int elapsedSeconds2 = (int.Parse(array[2]) * 60 + int.Parse(array[3])) * 60;
					array = XSingleton<XGlobalConfig>.singleton.GetValue(key2).Split(XGlobalConfig.ListSeparator);
					bool flag4 = array.Length % 2 != 0;
					if (flag4)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Meal reward count should be even: ", array.Length.ToString(), null, null, null, null);
						result = "";
					}
					else
					{
						StringBuilder stringBuilder = new StringBuilder();
						for (int i = 0; i < array.Length; i += 2)
						{
							ItemList.RowData itemConf = XBagDocument.GetItemConf(int.Parse(array[i]));
							bool flag5 = itemConf == null;
							if (flag5)
							{
								XSingleton<XDebug>.singleton.AddErrorLog("Reward ID error: ", array[i], null, null, null, null);
							}
							else
							{
								bool flag6 = i != 0;
								if (flag6)
								{
									stringBuilder.Append(XStringDefineProxy.GetString("COMMA"));
								}
								stringBuilder.Append(array[i + 1]);
								stringBuilder.Append(XStringDefineProxy.GetString("POINT"));
								stringBuilder.Append(XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U));
							}
						}
						result = string.Format(format, XSingleton<UiUtility>.singleton.TimeFormatSince1970(elapsedSeconds, "HH:mm", false), XSingleton<UiUtility>.singleton.TimeFormatSince1970(elapsedSeconds2, "HH:mm", false), stringBuilder.ToString());
					}
				}
			}
			return result;
		}

		// Token: 0x06009C19 RID: 39961 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0400369A RID: 13978
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SystemRewardDocument");

		// Token: 0x0400369B RID: 13979
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400369C RID: 13980
		private static SystemRewardTable _reader = new SystemRewardTable();

		// Token: 0x0400369D RID: 13981
		private List<XSystemRewardData> _DataList = new List<XSystemRewardData>();

		// Token: 0x0400369E RID: 13982
		private Dictionary<ulong, XSystemRewardData> _DataDic = new Dictionary<ulong, XSystemRewardData>();
	}
}
