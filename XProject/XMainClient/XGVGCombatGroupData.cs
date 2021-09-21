using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020008FC RID: 2300
	internal class XGVGCombatGroupData
	{
		// Token: 0x17002B2B RID: 11051
		// (get) Token: 0x06008AFD RID: 35581 RVA: 0x001287EC File Offset: 0x001269EC
		public uint RoomID
		{
			get
			{
				return this._roomID;
			}
		}

		// Token: 0x17002B2C RID: 11052
		// (get) Token: 0x06008AFE RID: 35582 RVA: 0x00128804 File Offset: 0x00126A04
		public ulong GuildOneID
		{
			get
			{
				return this._guildOneID;
			}
		}

		// Token: 0x17002B2D RID: 11053
		// (get) Token: 0x06008AFF RID: 35583 RVA: 0x0012881C File Offset: 0x00126A1C
		public ulong GuildTwoID
		{
			get
			{
				return this._guildTwoID;
			}
		}

		// Token: 0x17002B2E RID: 11054
		// (get) Token: 0x06008B00 RID: 35584 RVA: 0x00128834 File Offset: 0x00126A34
		public ulong WinnerID
		{
			get
			{
				return this._winerID;
			}
		}

		// Token: 0x17002B2F RID: 11055
		// (get) Token: 0x06008B01 RID: 35585 RVA: 0x0012884C File Offset: 0x00126A4C
		public uint WatchID
		{
			get
			{
				return this._roomWatchID;
			}
		}

		// Token: 0x17002B30 RID: 11056
		// (get) Token: 0x06008B02 RID: 35586 RVA: 0x00128864 File Offset: 0x00126A64
		public CrossGvgRoomState RoomState
		{
			get
			{
				return this._roomState;
			}
		}

		// Token: 0x17002B31 RID: 11057
		// (get) Token: 0x06008B03 RID: 35587 RVA: 0x0012887C File Offset: 0x00126A7C
		public XGuildBasicData GuildOne
		{
			get
			{
				return this._GuildOne;
			}
		}

		// Token: 0x17002B32 RID: 11058
		// (get) Token: 0x06008B04 RID: 35588 RVA: 0x00128894 File Offset: 0x00126A94
		public XGuildBasicData GuildTwo
		{
			get
			{
				return this._GuildTwo;
			}
		}

		// Token: 0x17002B33 RID: 11059
		// (get) Token: 0x06008B05 RID: 35589 RVA: 0x001288AC File Offset: 0x00126AAC
		public XGuildBasicData Winner
		{
			get
			{
				return this._Winner;
			}
		}

		// Token: 0x06008B06 RID: 35590 RVA: 0x001288C4 File Offset: 0x00126AC4
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

		// Token: 0x06008B07 RID: 35591 RVA: 0x0012895C File Offset: 0x00126B5C
		public bool InCombatGroup(ulong guildID)
		{
			return this._guildOneID == guildID || this._guildTwoID == guildID;
		}

		// Token: 0x04002C66 RID: 11366
		private uint _roomID;

		// Token: 0x04002C67 RID: 11367
		private ulong _guildOneID;

		// Token: 0x04002C68 RID: 11368
		private ulong _guildTwoID;

		// Token: 0x04002C69 RID: 11369
		private ulong _winerID;

		// Token: 0x04002C6A RID: 11370
		private CrossGvgRoomState _roomState;

		// Token: 0x04002C6B RID: 11371
		private uint _roomWatchID;

		// Token: 0x04002C6C RID: 11372
		private XGuildBasicData _GuildOne = null;

		// Token: 0x04002C6D RID: 11373
		private XGuildBasicData _GuildTwo = null;

		// Token: 0x04002C6E RID: 11374
		private XGuildBasicData _Winner = null;
	}
}
