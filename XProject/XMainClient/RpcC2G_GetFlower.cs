using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200112B RID: 4395
	internal class RpcC2G_GetFlower : Rpc
	{
		// Token: 0x0600D96E RID: 55662 RVA: 0x0032B1A0 File Offset: 0x003293A0
		public override uint GetRpcType()
		{
			return 11473U;
		}

		// Token: 0x0600D96F RID: 55663 RVA: 0x0032B1B7 File Offset: 0x003293B7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetFlowerArg>(stream, this.oArg);
		}

		// Token: 0x0600D970 RID: 55664 RVA: 0x0032B1C7 File Offset: 0x003293C7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetFlowerRes>(stream);
		}

		// Token: 0x0600D971 RID: 55665 RVA: 0x0032B1D6 File Offset: 0x003293D6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetFlower.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D972 RID: 55666 RVA: 0x0032B1F2 File Offset: 0x003293F2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetFlower.OnTimeout(this.oArg);
		}

		// Token: 0x04006204 RID: 25092
		public GetFlowerArg oArg = new GetFlowerArg();

		// Token: 0x04006205 RID: 25093
		public GetFlowerRes oRes = new GetFlowerRes();
	}
}
