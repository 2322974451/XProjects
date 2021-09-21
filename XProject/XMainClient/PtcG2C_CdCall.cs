using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013B0 RID: 5040
	internal class PtcG2C_CdCall : Protocol
	{
		// Token: 0x0600E3BE RID: 58302 RVA: 0x0033ABC8 File Offset: 0x00338DC8
		public override uint GetProtoType()
		{
			return 34744U;
		}

		// Token: 0x0600E3BF RID: 58303 RVA: 0x0033ABDF File Offset: 0x00338DDF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CallData>(stream, this.Data);
		}

		// Token: 0x0600E3C0 RID: 58304 RVA: 0x0033ABEF File Offset: 0x00338DEF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CallData>(stream);
		}

		// Token: 0x0600E3C1 RID: 58305 RVA: 0x0033ABFE File Offset: 0x00338DFE
		public override void Process()
		{
			Process_PtcG2C_CdCall.Process(this);
		}

		// Token: 0x040063FE RID: 25598
		public CallData Data = new CallData();
	}
}
