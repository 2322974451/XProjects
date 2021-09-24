using System;
using KKSG;

namespace XMainClient
{

	internal class XGVGCombatGroupData
	{

		public uint RoomID
		{
			get
			{
				return this._roomID;
			}
		}

		public ulong GuildOneID
		{
			get
			{
				return this._guildOneID;
			}
		}

		public ulong GuildTwoID
		{
			get
			{
				return this._guildTwoID;
			}
		}

		public ulong WinnerID
		{
			get
			{
				return this._winerID;
			}
		}

		public uint WatchID
		{
			get
			{
				return this._roomWatchID;
			}
		}

		public CrossGvgRoomState RoomState
		{
			get
			{
				return this._roomState;
			}
		}

		public XGuildBasicData GuildOne
		{
			get
			{
				return this._GuildOne;
			}
		}

		public XGuildBasicData GuildTwo
		{
			get
			{
				return this._GuildTwo;
			}
		}

		public XGuildBasicData Winner
		{
			get
			{
				return this._Winner;
			}
		}

		public void Convert(CrossGvgRoomInfo info)
		{
			this._roomID = info.roomid;
			this._guildOneID = info.guild1;
			this._guildTwoID = info.guild2;
			this._winerID = info.winguildid;
			this._roomWatchID = info.liveid;
			this._roomState = info.state;
			XCrossGVGDocument specificDocument = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			this._GuildOne = specificDocument.GetGVGGuildInfo(info.guild1);
			this._GuildTwo = specificDocument.GetGVGGuildInfo(info.guild2);
			this._Winner = specificDocument.GetGVGGuildInfo(info.winguildid);
		}

		public bool InCombatGroup(ulong guildID)
		{
			return this._guildOneID == guildID || this._guildTwoID == guildID;
		}

		private uint _roomID;

		private ulong _guildOneID;

		private ulong _guildTwoID;

		private ulong _winerID;

		private CrossGvgRoomState _roomState;

		private uint _roomWatchID;

		private XGuildBasicData _GuildOne = null;

		private XGuildBasicData _GuildTwo = null;

		private XGuildBasicData _Winner = null;
	}
}
