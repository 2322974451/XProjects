using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200134E RID: 4942
	internal class PtcG2C_GprOneBattleEndNtf : Protocol
	{
		// Token: 0x0600E22C RID: 57900 RVA: 0x00338A84 File Offset: 0x00336C84
		public override uint GetProtoType()
		{
			return 39421U;
		}

		// Token: 0x0600E22D RID: 57901 RVA: 0x00338A9B File Offset: 0x00336C9B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GprOneBattleEnd>(stream, this.Data);
		}

		// Token: 0x0600E22E RID: 57902 RVA: 0x00338AAB File Offset: 0x00336CAB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GprOneBattleEnd>(stream);
		}

		// Token: 0x0600E22F RID: 57903 RVA: 0x00338ABA File Offset: 0x00336CBA
		public override void Process()
		{
			Process_PtcG2C_GprOneBattleEndNtf.Process(this);
		}

		// Token: 0x040063B0 RID: 25520
		public GprOneBattleEnd Data = new GprOneBattleEnd();
	}
}
