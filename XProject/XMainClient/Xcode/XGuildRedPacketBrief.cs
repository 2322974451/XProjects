using System;
using KKSG;
using UnityEngine;

namespace XMainClient
{

	internal class XGuildRedPacketBrief : IComparable<XGuildRedPacketBrief>
	{

		public void SetData(GuildBonusAppear data)
		{
			this.uid = (ulong)data.bonusID;
			this.itemid = (int)data.bonusType;
			this.senderName = data.sourceName;
			this.fetchedCount = data.alreadyGetPeopleNum;
			this.maxCount = data.maxPeopleNum;
			this.iconUrl = data.iconUrl;
			this.sourceID = data.sourceID;
			this.sourceName = data.sourceName;
			bool flag = data.bonusStatus == 0U;
			if (flag)
			{
				this.fetchState = FetchState.FS_CAN_FETCH;
			}
			else
			{
				bool flag2 = data.bonusStatus == 1U;
				if (flag2)
				{
					this.fetchState = FetchState.FS_CANNOT_FETCH;
				}
				else
				{
					bool flag3 = data.bonusStatus == 2U;
					if (flag3)
					{
						this.fetchState = FetchState.FS_ALREADY_FETCH;
					}
					else
					{
						this.fetchState = FetchState.FS_FETCHED;
					}
				}
			}
			this.endTime = Time.time + data.leftOpenTime;
		}

		public int CompareTo(XGuildRedPacketBrief other)
		{
			bool flag = this.fetchState == other.fetchState;
			int result;
			if (flag)
			{
				result = this.endTime.CompareTo(other.endTime);
			}
			else
			{
				result = this.fetchState.CompareTo(other.fetchState);
			}
			return result;
		}

		public uint typeid;

		public ulong uid;

		public int itemid;

		public string senderName;

		public uint fetchedCount;

		public uint maxCount;

		public float endTime;

		public string iconUrl;

		public ulong sourceID;

		public string sourceName;

		public FetchState fetchState;
	}
}
