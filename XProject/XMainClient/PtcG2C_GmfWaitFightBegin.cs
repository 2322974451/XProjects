using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011BB RID: 4539
	internal class PtcG2C_GmfWaitFightBegin : Protocol
	{
		// Token: 0x0600DBB2 RID: 56242 RVA: 0x0032F62C File Offset: 0x0032D82C
		public override uint GetProtoType()
		{
			return 59721U;
		}

		// Token: 0x0600DBB3 RID: 56243 RVA: 0x0032F643 File Offset: 0x0032D843
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfWaitFightArg>(stream, this.Data);
		}

		// Token: 0x0600DBB4 RID: 56244 RVA: 0x0032F653 File Offset: 0x0032D853
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfWaitFightArg>(stream);
		}

		// Token: 0x0600DBB5 RID: 56245 RVA: 0x0032F662 File Offset: 0x0032D862
		public override void Process()
		{
			Process_PtcG2C_GmfWaitFightBegin.Process(this);
		}

		// Token: 0x0400626F RID: 25199
		public GmfWaitFightArg Data = new GmfWaitFightArg();
	}
}
