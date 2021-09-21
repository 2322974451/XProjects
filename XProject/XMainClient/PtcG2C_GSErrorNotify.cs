using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001031 RID: 4145
	internal class PtcG2C_GSErrorNotify : Protocol
	{
		// Token: 0x0600D572 RID: 54642 RVA: 0x00324090 File Offset: 0x00322290
		public override uint GetProtoType()
		{
			return 2031U;
		}

		// Token: 0x0600D573 RID: 54643 RVA: 0x003240A7 File Offset: 0x003222A7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ErrorInfo>(stream, this.Data);
		}

		// Token: 0x0600D574 RID: 54644 RVA: 0x003240B7 File Offset: 0x003222B7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ErrorInfo>(stream);
		}

		// Token: 0x0600D575 RID: 54645 RVA: 0x003240C6 File Offset: 0x003222C6
		public override void Process()
		{
			Process_PtcG2C_GSErrorNotify.Process(this);
		}

		// Token: 0x04006123 RID: 24867
		public ErrorInfo Data = new ErrorInfo();
	}
}
