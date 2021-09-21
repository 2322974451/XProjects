using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011E6 RID: 4582
	internal class PtcM2C_MSErrorNotify : Protocol
	{
		// Token: 0x0600DC5F RID: 56415 RVA: 0x003303B8 File Offset: 0x0032E5B8
		public override uint GetProtoType()
		{
			return 48740U;
		}

		// Token: 0x0600DC60 RID: 56416 RVA: 0x003303CF File Offset: 0x0032E5CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ErrorInfo>(stream, this.Data);
		}

		// Token: 0x0600DC61 RID: 56417 RVA: 0x003303DF File Offset: 0x0032E5DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ErrorInfo>(stream);
		}

		// Token: 0x0600DC62 RID: 56418 RVA: 0x003303EE File Offset: 0x0032E5EE
		public override void Process()
		{
			Process_PtcM2C_MSErrorNotify.Process(this);
		}

		// Token: 0x0400628F RID: 25231
		public ErrorInfo Data = new ErrorInfo();
	}
}
