using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class DragonGuildLiveness
	{

		public DragonGuildLiveness(DragonGuildLivenessTable table)
		{
			this.m_table = table;
		}

		public List<DragonGuildLivenessRecord> RecordList
		{
			get
			{
				return this.m_recordList;
			}
		}

		public uint CurExp
		{
			get
			{
				return this.m_curExp;
			}
			set
			{
				this.m_curExp = value;
			}
		}

		public uint MaxExp
		{
			get
			{
				List<DragonGuildLivenessTable.RowData> list = new List<DragonGuildLivenessTable.RowData>();
				this.GetDragonGuildLivenessRowsByLevel(XPartnerDocument.Doc.CurPartnerLevel, out list);
				bool flag = list.Count != 0;
				uint result;
				if (flag)
				{
					result = list[list.Count - 1].liveness;
				}
				else
				{
					result = 0U;
				}
				return result;
			}
		}

		public DragonGuildLivenessTable.RowData GetPartnerLivenessRow(uint livenessId, int partnerLevel)
		{
			for (int i = 0; i < this.m_table.Table.Length; i++)
			{
				DragonGuildLivenessTable.RowData rowData = this.m_table.Table[i];
				bool flag = rowData.liveness == livenessId && (long)partnerLevel >= (long)((ulong)rowData.level[0]) && (long)partnerLevel <= (long)((ulong)rowData.level[1]);
				if (flag)
				{
					return this.m_table.Table[i];
				}
			}
			return null;
		}

		public void GetDragonGuildLivenessRowsByLevel(uint partnerLevel, out List<DragonGuildLivenessTable.RowData> lst)
		{
			lst = new List<DragonGuildLivenessTable.RowData>();
			for (int i = 0; i < this.m_table.Table.Length; i++)
			{
				DragonGuildLivenessTable.RowData rowData = this.m_table.Table[i];
				bool flag = partnerLevel >= rowData.level[0] && partnerLevel <= rowData.level[1];
				if (flag)
				{
					lst.Add(rowData);
				}
			}
			lst.Sort(new Comparison<DragonGuildLivenessTable.RowData>(this.Compare));
		}

		private int Compare(DragonGuildLivenessTable.RowData left, DragonGuildLivenessTable.RowData right)
		{
			bool flag = left.liveness < right.liveness;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		public bool IsChestOpened(int index)
		{
			uint num = 1U << index;
			return (this.m_takeChest & num) > 0U;
		}

		public int FindNeedShowReward()
		{
			bool flag = this.CurExp >= this.MaxExp;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				List<DragonGuildLivenessTable.RowData> list;
				this.GetDragonGuildLivenessRowsByLevel(XPartnerDocument.Doc.CurPartnerLevel, out list);
				for (int i = 0; i < list.Count; i++)
				{
					bool flag2 = !this.IsChestOpened(i + 1);
					if (flag2)
					{
						return i;
					}
				}
				result = 0;
			}
			return result;
		}

		public bool IsHadRedPoint()
		{
			List<DragonGuildLivenessTable.RowData> list;
			this.GetDragonGuildLivenessRowsByLevel(XPartnerDocument.Doc.CurPartnerLevel, out list);
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = !this.IsChestOpened(i + 1) && this.m_curExp >= list[i].liveness;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public void ReqDragonGuildLivenessInfo()
		{
			RpcC2M_GetDragonGuildLiveness rpc = new RpcC2M_GetDragonGuildLiveness();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqTakeDragonGuildChest(uint index)
		{
			RpcC2G_TakeDragonGuildChest rpcC2G_TakeDragonGuildChest = new RpcC2G_TakeDragonGuildChest();
			rpcC2G_TakeDragonGuildChest.oArg.index = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TakeDragonGuildChest);
		}

		public void OnGetDragonGuildLivenessInfoBack(GetPartnerLivenessRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
					else
					{
						this.m_curExp = oRes.liveness;
						this.m_takeChest = oRes.takedchest;
						this.m_recordList.Clear();
						for (int i = 0; i < oRes.record.Count; i++)
						{
							this.m_recordList.Add(new DragonGuildLivenessRecord(oRes.record[i]));
						}
						XDragonGuildDocument.Doc.IsHadLivenessRedPoint = this.IsHadRedPoint();
						bool flag4 = this.View != null && this.View.IsVisible();
						if (flag4)
						{
							this.View.FillContent();
						}
					}
				}
			}
		}

		public void OnTakeDragonGuildChestBack(TakePartnerChestArg oArg, TakePartnerChestRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
					else
					{
						this.m_takeChest = oRes.takedchest;
						XDragonGuildDocument.Doc.IsHadLivenessRedPoint = this.IsHadRedPoint();
						bool flag4 = this.View != null && this.View.IsVisible();
						if (flag4)
						{
							this.View.ResetBoxRedDot((int)(oArg.index - 1U));
						}
					}
				}
			}
		}

		private DragonGuildLivenessTable m_table;

		private uint m_curExp = 0U;

		private uint m_takeChest = 0U;

		private List<DragonGuildLivenessRecord> m_recordList = new List<DragonGuildLivenessRecord>();

		public DragonGuildLivenessDlg View;
	}
}
