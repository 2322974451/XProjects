using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001150 RID: 4432
	internal class RpcC2G_IdentifyEmblem : Rpc
	{
		// Token: 0x0600DA07 RID: 55815 RVA: 0x0032C868 File Offset: 0x0032AA68
		public override uint GetRpcType()
		{
			return 43787U;
		}

		// Token: 0x0600DA08 RID: 55816 RVA: 0x0032C87F File Offset: 0x0032AA7F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IdentifyEmblemArg>(stream, this.oArg);
		}

		// Token: 0x0600DA09 RID: 55817 RVA: 0x0032C88F File Offset: 0x0032AA8F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<IdentifyEmblemRes>(stream);
		}

		// Token: 0x0600DA0A RID: 55818 RVA: 0x0032C89E File Offset: 0x0032AA9E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_IdentifyEmblem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA0B RID: 55819 RVA: 0x0032C8BA File Offset: 0x0032AABA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_IdentifyEmblem.OnTimeout(this.oArg);
		}

		// Token: 0x04006221 RID: 25121
		public IdentifyEmblemArg oArg = new IdentifyEmblemArg();

		// Token: 0x04006222 RID: 25122
		public IdentifyEmblemRes oRes = new IdentifyEmblemRes();
	}
}
