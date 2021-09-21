using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014B0 RID: 5296
	internal class PtcM2C_NoticeGuildTerrBattleWin : Protocol
	{
		// Token: 0x0600E7CC RID: 59340 RVA: 0x0034089C File Offset: 0x0033EA9C
		public override uint GetProtoType()
		{
			return 61655U;
		}

		// Token: 0x0600E7CD RID: 59341 RVA: 0x003408B3 File Offset: 0x0033EAB3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildTerrBattleWin>(stream, this.Data);
		}

		// Token: 0x0600E7CE RID: 59342 RVA: 0x003408C3 File Offset: 0x0033EAC3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildTerrBattleWin>(stream);
		}

		// Token: 0x0600E7CF RID: 59343 RVA: 0x003408D2 File Offset: 0x0033EAD2
		public override void Process()
		{
			Process_PtcM2C_NoticeGuildTerrBattleWin.Process(this);
		}

		// Token: 0x040064C0 RID: 25792
		public NoticeGuildTerrBattleWin Data = new NoticeGuildTerrBattleWin();
	}
}
