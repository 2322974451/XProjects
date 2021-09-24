using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{

	internal class XSystemRewardData : IComparable<XSystemRewardData>
	{

		public XSystemRewardState state
		{
			get
			{
				return this._state;
			}
		}

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

		public ulong uid;

		public List<ItemBrief> itemList = new List<ItemBrief>();

		public uint type;

		public string[] param;

		public string serverName = "";

		public string serverContent = "";

		public uint sortType;

		private XSystemRewardState _state;
	}
}
