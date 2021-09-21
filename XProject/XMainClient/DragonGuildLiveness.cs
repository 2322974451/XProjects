using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000901 RID: 2305
	internal class DragonGuildLiveness
	{
		// Token: 0x06008B7C RID: 35708 RVA: 0x0012AF19 File Offset: 0x00129119
		public DragonGuildLiveness(DragonGuildLivenessTable table)
		{
			this.m_table = table;
		}

		// Token: 0x17002B51 RID: 11089
		// (get) Token: 0x06008B7D RID: 35709 RVA: 0x0012AF44 File Offset: 0x00129144
		public List<DragonGuildLivenessRecord> RecordList
		{
			get
			{
				return this.m_recordList;
			}
		}

		// Token: 0x17002B52 RID: 11090
		// (get) Token: 0x06008B7E RID: 35710 RVA: 0x0012AF5C File Offset: 0x0012915C
		// (set) Token: 0x06008B7F RID: 35711 RVA: 0x0012AF74 File Offset: 0x00129174
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

		// Token: 0x17002B53 RID: 11091
		// (get) Token: 0x06008B80 RID: 35712 RVA: 0x0012AF80 File Offset: 0x00129180
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

		// Token: 0x06008B81 RID: 35713 RVA: 0x0012AFD0 File Offset: 0x001291D0
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

		// Token: 0x06008B82 RID: 35714 RVA: 0x0012B058 File Offset: 0x00129258
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

		// Token: 0x06008B83 RID: 35715 RVA: 0x0012B0E0 File Offset: 0x001292E0
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

		// Token: 0x06008B84 RID: 35716 RVA: 0x0012B10C File Offset: 0x0012930C
		public bool IsChestOpened(int index)
		{
			uint num = 1U << index;
			return (this.m_takeChest & num) > 0U;
		}

		// Token: 0x06008B85 RID: 35717 RVA: 0x0012B130 File Offset: 0x00129330
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

		// Token: 0x06008B86 RID: 35718 RVA: 0x0012B1A0 File Offset: 0x001293A0
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

		// Token: 0x06008B87 RID: 35719 RVA: 0x0012B20C File Offset: 0x0012940C
		public void ReqDragonGuildLivenessInfo()
		{
			RpcC2M_GetDragonGuildLiveness rpc = new RpcC2M_GetDragonGuildLiveness();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008B88 RID: 35720 RVA: 0x0012B22C File Offset: 0x0012942C
		public void ReqTakeDragonGuildChest(uint index)
		{
			RpcC2G_TakeDragonGuildChest rpcC2G_TakeDragonGuildChest = new RpcC2G_TakeDragonGuildChest();
			rpcC2G_TakeDragonGuildChest.oArg.index = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TakeDragonGuildChest);
		}

		// Token: 0x06008B89 RID: 35721 RVA: 0x0012B25C File Offset: 0x0012945C
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

		// Token: 0x06008B8A RID: 35722 RVA: 0x0012B384 File Offset: 0x00129584
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

		// Token: 0x04002C9A RID: 11418
		private DragonGuildLivenessTable m_table;

		// Token: 0x04002C9B RID: 11419
		private uint m_curExp = 0U;

		// Token: 0x04002C9C RID: 11420
		private uint m_takeChest = 0U;

		// Token: 0x04002C9D RID: 11421
		private List<DragonGuildLivenessRecord> m_recordList = new List<DragonGuildLivenessRecord>();

		// Token: 0x04002C9E RID: 11422
		public DragonGuildLivenessDlg View;
	}
}
