using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014C1 RID: 5313
	internal class PtcM2C_ModifyGuildNameNtf : Protocol
	{
		// Token: 0x0600E80D RID: 59405 RVA: 0x00340D6C File Offset: 0x0033EF6C
		public override uint GetProtoType()
		{
			return 18518U;
		}

		// Token: 0x0600E80E RID: 59406 RVA: 0x00340D83 File Offset: 0x0033EF83
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ModifyArg>(stream, this.Data);
		}

		// Token: 0x0600E80F RID: 59407 RVA: 0x00340D93 File Offset: 0x0033EF93
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ModifyArg>(stream);
		}

		// Token: 0x0600E810 RID: 59408 RVA: 0x00340DA2 File Offset: 0x0033EFA2
		public override void Process()
		{
			Process_PtcM2C_ModifyGuildNameNtf.Process(this);
		}

		// Token: 0x040064CB RID: 25803
		public ModifyArg Data = new ModifyArg();
	}
}
