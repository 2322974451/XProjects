using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200116E RID: 4462
	internal class PtcG2C_UpdateGuildArenaState : Protocol
	{
		// Token: 0x0600DA8C RID: 55948 RVA: 0x0032DCE0 File Offset: 0x0032BEE0
		public override uint GetProtoType()
		{
			return 21909U;
		}

		// Token: 0x0600DA8D RID: 55949 RVA: 0x0032DCF7 File Offset: 0x0032BEF7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateGuildArenaState>(stream, this.Data);
		}

		// Token: 0x0600DA8E RID: 55950 RVA: 0x0032DD07 File Offset: 0x0032BF07
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateGuildArenaState>(stream);
		}

		// Token: 0x0600DA8F RID: 55951 RVA: 0x0032DD16 File Offset: 0x0032BF16
		public override void Process()
		{
			Process_PtcG2C_UpdateGuildArenaState.Process(this);
		}

		// Token: 0x0400623E RID: 25150
		public UpdateGuildArenaState Data = new UpdateGuildArenaState();
	}
}
