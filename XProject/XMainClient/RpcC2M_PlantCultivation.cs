using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012DC RID: 4828
	internal class RpcC2M_PlantCultivation : Rpc
	{
		// Token: 0x0600E054 RID: 57428 RVA: 0x00335DBC File Offset: 0x00333FBC
		public override uint GetRpcType()
		{
			return 61295U;
		}

		// Token: 0x0600E055 RID: 57429 RVA: 0x00335DD3 File Offset: 0x00333FD3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlantCultivationArg>(stream, this.oArg);
		}

		// Token: 0x0600E056 RID: 57430 RVA: 0x00335DE3 File Offset: 0x00333FE3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PlantCultivationRes>(stream);
		}

		// Token: 0x0600E057 RID: 57431 RVA: 0x00335DF2 File Offset: 0x00333FF2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_PlantCultivation.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E058 RID: 57432 RVA: 0x00335E0E File Offset: 0x0033400E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_PlantCultivation.OnTimeout(this.oArg);
		}

		// Token: 0x04006354 RID: 25428
		public PlantCultivationArg oArg = new PlantCultivationArg();

		// Token: 0x04006355 RID: 25429
		public PlantCultivationRes oRes = null;
	}
}
