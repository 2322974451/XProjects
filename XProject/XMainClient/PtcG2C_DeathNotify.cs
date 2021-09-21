using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001008 RID: 4104
	internal class PtcG2C_DeathNotify : Protocol
	{
		// Token: 0x0600D4C9 RID: 54473 RVA: 0x0032217C File Offset: 0x0032037C
		public override uint GetProtoType()
		{
			return 2319U;
		}

		// Token: 0x0600D4CA RID: 54474 RVA: 0x00322193 File Offset: 0x00320393
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DeathInfo>(stream, this.Data);
		}

		// Token: 0x0600D4CB RID: 54475 RVA: 0x003221A3 File Offset: 0x003203A3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DeathInfo>(stream);
		}

		// Token: 0x0600D4CC RID: 54476 RVA: 0x003221B2 File Offset: 0x003203B2
		public override void Process()
		{
			Process_PtcG2C_DeathNotify.Process(this);
		}

		// Token: 0x04006102 RID: 24834
		public DeathInfo Data = new DeathInfo();
	}
}
