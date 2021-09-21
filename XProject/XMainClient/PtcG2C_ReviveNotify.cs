using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001058 RID: 4184
	internal class PtcG2C_ReviveNotify : Protocol
	{
		// Token: 0x0600D619 RID: 54809 RVA: 0x00325948 File Offset: 0x00323B48
		public override uint GetProtoType()
		{
			return 16213U;
		}

		// Token: 0x0600D61A RID: 54810 RVA: 0x0032595F File Offset: 0x00323B5F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReviveInfo>(stream, this.Data);
		}

		// Token: 0x0600D61B RID: 54811 RVA: 0x0032596F File Offset: 0x00323B6F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReviveInfo>(stream);
		}

		// Token: 0x0600D61C RID: 54812 RVA: 0x0032597E File Offset: 0x00323B7E
		public override void Process()
		{
			Process_PtcG2C_ReviveNotify.Process(this);
		}

		// Token: 0x04006169 RID: 24937
		public ReviveInfo Data = new ReviveInfo();
	}
}
