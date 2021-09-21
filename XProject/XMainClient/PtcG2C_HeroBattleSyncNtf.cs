using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200141C RID: 5148
	internal class PtcG2C_HeroBattleSyncNtf : Protocol
	{
		// Token: 0x0600E578 RID: 58744 RVA: 0x0033D0C4 File Offset: 0x0033B2C4
		public override uint GetProtoType()
		{
			return 33024U;
		}

		// Token: 0x0600E579 RID: 58745 RVA: 0x0033D0DB File Offset: 0x0033B2DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleSyncData>(stream, this.Data);
		}

		// Token: 0x0600E57A RID: 58746 RVA: 0x0033D0EB File Offset: 0x0033B2EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleSyncData>(stream);
		}

		// Token: 0x0600E57B RID: 58747 RVA: 0x0033D0FA File Offset: 0x0033B2FA
		public override void Process()
		{
			Process_PtcG2C_HeroBattleSyncNtf.Process(this);
		}

		// Token: 0x04006453 RID: 25683
		public HeroBattleSyncData Data = new HeroBattleSyncData();
	}
}
