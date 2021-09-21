using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015ED RID: 5613
	internal class PtcG2C_BattleFieldReadyInfoNtf : Protocol
	{
		// Token: 0x0600ECE2 RID: 60642 RVA: 0x00347A24 File Offset: 0x00345C24
		public override uint GetProtoType()
		{
			return 40392U;
		}

		// Token: 0x0600ECE3 RID: 60643 RVA: 0x00347A3B File Offset: 0x00345C3B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleFieldReadyInfo>(stream, this.Data);
		}

		// Token: 0x0600ECE4 RID: 60644 RVA: 0x00347A4B File Offset: 0x00345C4B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BattleFieldReadyInfo>(stream);
		}

		// Token: 0x0600ECE5 RID: 60645 RVA: 0x00347A5A File Offset: 0x00345C5A
		public override void Process()
		{
			Process_PtcG2C_BattleFieldReadyInfoNtf.Process(this);
		}

		// Token: 0x040065C1 RID: 26049
		public BattleFieldReadyInfo Data = new BattleFieldReadyInfo();
	}
}
