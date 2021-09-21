using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200117A RID: 4474
	internal class PtcG2C_WorldChannelLeftTimesNtf : Protocol
	{
		// Token: 0x0600DABA RID: 55994 RVA: 0x0032E0AC File Offset: 0x0032C2AC
		public override uint GetProtoType()
		{
			return 37503U;
		}

		// Token: 0x0600DABB RID: 55995 RVA: 0x0032E0C3 File Offset: 0x0032C2C3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldChannelLeftTimesNtf>(stream, this.Data);
		}

		// Token: 0x0600DABC RID: 55996 RVA: 0x0032E0D3 File Offset: 0x0032C2D3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WorldChannelLeftTimesNtf>(stream);
		}

		// Token: 0x0600DABD RID: 55997 RVA: 0x0032E0E2 File Offset: 0x0032C2E2
		public override void Process()
		{
			Process_PtcG2C_WorldChannelLeftTimesNtf.Process(this);
		}

		// Token: 0x04006246 RID: 25158
		public WorldChannelLeftTimesNtf Data = new WorldChannelLeftTimesNtf();
	}
}
