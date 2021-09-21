using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011FC RID: 4604
	internal class PtcG2C_AIDebugInfo : Protocol
	{
		// Token: 0x0600DCB5 RID: 56501 RVA: 0x00330B80 File Offset: 0x0032ED80
		public override uint GetProtoType()
		{
			return 60081U;
		}

		// Token: 0x0600DCB6 RID: 56502 RVA: 0x00330B97 File Offset: 0x0032ED97
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AIDebugMsg>(stream, this.Data);
		}

		// Token: 0x0600DCB7 RID: 56503 RVA: 0x00330BA7 File Offset: 0x0032EDA7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AIDebugMsg>(stream);
		}

		// Token: 0x0600DCB8 RID: 56504 RVA: 0x00330BB6 File Offset: 0x0032EDB6
		public override void Process()
		{
			Process_PtcG2C_AIDebugInfo.Process(this);
		}

		// Token: 0x0400629E RID: 25246
		public AIDebugMsg Data = new AIDebugMsg();
	}
}
