using System;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildRedPackageSendBrief : IComparable<XGuildRedPackageSendBrief>
	{

		public void SendData(GuildBonusAppear data)
		{
			this.typeID = data.bonusContentType;
			this.uid = (ulong)data.bonusID;
			this.itemid = data.bonusType;
			this.senderName = data.sourceName;
			this.fetchedCount = data.alreadyGetPeopleNum;
			this.maxCount = data.maxPeopleNum;
			this.endTime = Time.time + data.leftOpenTime;
			this.bonusInfo = XGuildRedPacketDocument.GetRedPacketConfig(this.typeID);
			this.senderType = ((XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID == data.sourceID) ? BonusSender.Bonus_Self : BonusSender.Bonus_Other);
		}

		public int CompareTo(XGuildRedPackageSendBrief other)
		{
			bool flag = this.senderType == other.senderType;
			int result;
			if (flag)
			{
				result = this.endTime.CompareTo(other.endTime);
			}
			else
			{
				result = this.senderType.CompareTo(other.senderType);
			}
			return result;
		}

		public uint typeID;

		public ulong uid;

		public uint itemid;

		public string senderName;

		public uint fetchedCount;

		public uint maxCount;

		public float endTime;

		public BonusSender senderType;

		public GuildBonusTable.RowData bonusInfo;
	}
}
