using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x020009F6 RID: 2550
	internal class XSystemRewardData : IComparable<XSystemRewardData>
	{
		// Token: 0x17002E5C RID: 11868
		// (get) Token: 0x06009C1C RID: 39964 RVA: 0x00191E5C File Offset: 0x0019005C
		public XSystemRewardState state
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x06009C1D RID: 39965 RVA: 0x00191E74 File Offset: 0x00190074
		public void SetState(uint s)
		{
			switch (s)
			{
			case 0U:
				this._state = XSystemRewardState.SRS_CANNOT_FETCH;
				break;
			case 1U:
				this._state = XSystemRewardState.SRS_CAN_FETCH;
				break;
			case 2U:
				this._state = XSystemRewardState.SRS_FETCHED;
				break;
			default:
				this._state = XSystemRewardState.SRS_CANNOT_FETCH;
				break;
			}
		}

		// Token: 0x06009C1E RID: 39966 RVA: 0x00191EBC File Offset: 0x001900BC
		public int CompareTo(XSystemRewardData other)
		{
			int num = this.state.CompareTo(other.state);
			bool flag = num != 0;
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = this.sortType.CompareTo(other.sortType);
			}
			return result;
		}

		// Token: 0x040036A3 RID: 13987
		public ulong uid;

		// Token: 0x040036A4 RID: 13988
		public List<ItemBrief> itemList = new List<ItemBrief>();

		// Token: 0x040036A5 RID: 13989
		public uint type;

		// Token: 0x040036A6 RID: 13990
		public string[] param;

		// Token: 0x040036A7 RID: 13991
		public string serverName = "";

		// Token: 0x040036A8 RID: 13992
		public string serverContent = "";

		// Token: 0x040036A9 RID: 13993
		public uint sortType;

		// Token: 0x040036AA RID: 13994
		private XSystemRewardState _state;
	}
}
