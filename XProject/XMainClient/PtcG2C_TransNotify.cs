using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015DD RID: 5597
	internal class PtcG2C_TransNotify : Protocol
	{
		// Token: 0x0600EC9D RID: 60573 RVA: 0x003474EC File Offset: 0x003456EC
		public override uint GetProtoType()
		{
			return 15935U;
		}

		// Token: 0x0600EC9E RID: 60574 RVA: 0x00347503 File Offset: 0x00345703
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TransNotify>(stream, this.Data);
		}

		// Token: 0x0600EC9F RID: 60575 RVA: 0x00347513 File Offset: 0x00345713
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TransNotify>(stream);
		}

		// Token: 0x0600ECA0 RID: 60576 RVA: 0x00347522 File Offset: 0x00345722
		public override void Process()
		{
			Process_PtcG2C_TransNotify.Process(this);
		}

		// Token: 0x040065B3 RID: 26035
		public TransNotify Data = new TransNotify();
	}
}
