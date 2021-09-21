using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C67 RID: 3175
	internal class PartnerLiveness
	{
		// Token: 0x0600B3C8 RID: 46024 RVA: 0x00230854 File Offset: 0x0022EA54
		public PartnerLiveness(PartnerLivenessTable table)
		{
			this.m_table = table;
		}

		// Token: 0x170031CE RID: 12750
		// (get) Token: 0x0600B3C9 RID: 46025 RVA: 0x00230880 File Offset: 0x0022EA80
		public List<PartnerLivenessRecord> RecordList
		{
			get
			{
				return this.m_recordList;
			}
		}

		// Token: 0x170031CF RID: 12751
		// (get) Token: 0x0600B3CA RID: 46026 RVA: 0x00230898 File Offset: 0x0022EA98
		// (set) Token: 0x0600B3CB RID: 46027 RVA: 0x002308B0 File Offset: 0x0022EAB0
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

		// Token: 0x170031D0 RID: 12752
		// (get) Token: 0x0600B3CC RID: 46028 RVA: 0x002308BC File Offset: 0x0022EABC
		public uint MaxExp
		{
			get
			{
				List<PartnerLivenessTable.RowData> list = new List<PartnerLivenessTable.RowData>();
				this.GetPartnerLivenessRowsByLevel(XPartnerDocument.Doc.CurPartnerLevel, out list);
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

		// Token: 0x0600B3CD RID: 46029 RVA: 0x0023090C File Offset: 0x0022EB0C
		public PartnerLivenessTable.RowData GetPartnerLivenessRow(uint livenessId, int partnerLevel)
		{
			for (int i = 0; i < this.m_table.Table.Length; i++)
			{
				PartnerLivenessTable.RowData rowData = this.m_table.Table[i];
				bool flag = rowData.liveness == livenessId && (long)partnerLevel >= (long)((ulong)rowData.level[0]) && (long)partnerLevel <= (long)((ulong)rowData.level[1]);
				if (flag)
				{
					return this.m_table.Table[i];
				}
			}
			return null;
		}

		// Token: 0x0600B3CE RID: 46030 RVA: 0x00230994 File Offset: 0x0022EB94
		public void GetPartnerLivenessRowsByLevel(uint partnerLevel, out List<PartnerLivenessTable.RowData> lst)
		{
			lst = new List<PartnerLivenessTable.RowData>();
			for (int i = 0; i < this.m_table.Table.Length; i++)
			{
				PartnerLivenessTable.RowData rowData = this.m_table.Table[i];
				bool flag = partnerLevel >= rowData.level[0] && partnerLevel <= rowData.level[1];
				if (flag)
				{
					lst.Add(rowData);
				}
			}
			lst.Sort(new Comparison<PartnerLivenessTable.RowData>(this.Compare));
		}

		// Token: 0x0600B3CF RID: 46031 RVA: 0x00230A1C File Offset: 0x0022EC1C
		private int Compare(PartnerLivenessTable.RowData left, PartnerLivenessTable.RowData right)
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

		// Token: 0x0600B3D0 RID: 46032 RVA: 0x00230A48 File Offset: 0x0022EC48
		public bool IsChestOpened(int index)
		{
			uint num = 1U << index;
			return (this.m_takeChest & num) > 0U;
		}

		// Token: 0x0600B3D1 RID: 46033 RVA: 0x00230A6C File Offset: 0x0022EC6C
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
				List<PartnerLivenessTable.RowData> list;
				this.GetPartnerLivenessRowsByLevel(XPartnerDocument.Doc.CurPartnerLevel, out list);
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

		// Token: 0x0600B3D2 RID: 46034 RVA: 0x00230ADC File Offset: 0x0022ECDC
		public bool IsHadRedPoint()
		{
			List<PartnerLivenessTable.RowData> list;
			this.GetPartnerLivenessRowsByLevel(XPartnerDocument.Doc.CurPartnerLevel, out list);
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

		// Token: 0x0600B3D3 RID: 46035 RVA: 0x00230B48 File Offset: 0x0022ED48
		public void ReqPartnerLivenessInfo()
		{
			RpcC2M_GetPartnerLiveness rpc = new RpcC2M_GetPartnerLiveness();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B3D4 RID: 46036 RVA: 0x00230B68 File Offset: 0x0022ED68
		public void ReqTakePartnerChest(uint index)
		{
			RpcC2G_TakePartnerChest rpcC2G_TakePartnerChest = new RpcC2G_TakePartnerChest();
			rpcC2G_TakePartnerChest.oArg.index = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TakePartnerChest);
		}

		// Token: 0x0600B3D5 RID: 46037 RVA: 0x00230B98 File Offset: 0x0022ED98
		public void OnGetPartnerLivenessInfoBack(GetPartnerLivenessRes oRes)
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
							this.m_recordList.Add(new PartnerLivenessRecord(oRes.record[i]));
						}
						XPartnerDocument.Doc.IsHadLivenessRedPoint = this.IsHadRedPoint();
						bool flag4 = this.View != null && this.View.IsVisible();
						if (flag4)
						{
							this.View.FillContent();
						}
					}
				}
			}
		}

		// Token: 0x0600B3D6 RID: 46038 RVA: 0x00230CC0 File Offset: 0x0022EEC0
		public void OnTakePartnerChestBack(int index, TakePartnerChestRes oRes)
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
						XPartnerDocument.Doc.IsHadLivenessRedPoint = this.IsHadRedPoint();
						bool flag4 = this.View != null && this.View.IsVisible();
						if (flag4)
						{
							this.View.ResetBoxRedDot(index - 1);
						}
					}
				}
			}
		}

		// Token: 0x040045AD RID: 17837
		private PartnerLivenessTable m_table;

		// Token: 0x040045AE RID: 17838
		private uint m_curExp = 0U;

		// Token: 0x040045AF RID: 17839
		private uint m_takeChest = 0U;

		// Token: 0x040045B0 RID: 17840
		private List<PartnerLivenessRecord> m_recordList = new List<PartnerLivenessRecord>();

		// Token: 0x040045B1 RID: 17841
		public PartnerLivenessDlg View;
	}
}
