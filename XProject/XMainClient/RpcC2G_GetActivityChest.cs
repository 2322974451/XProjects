using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000EC2 RID: 3778
	internal class RpcC2G_GetActivityChest : Rpc
	{
		// Token: 0x0600C89E RID: 51358 RVA: 0x002CED9C File Offset: 0x002CCF9C
		public override uint GetRpcType()
		{
			return 34363U;
		}

		// Token: 0x0600C89F RID: 51359 RVA: 0x002CEDB3 File Offset: 0x002CCFB3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetActivityChestArg>(stream, this.oArg);
		}

		// Token: 0x0600C8A0 RID: 51360 RVA: 0x002CEDC3 File Offset: 0x002CCFC3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetActivityChestRes>(stream);
		}

		// Token: 0x0600C8A1 RID: 51361 RVA: 0x002CEDD2 File Offset: 0x002CCFD2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetActivityChest.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600C8A2 RID: 51362 RVA: 0x002CEDEE File Offset: 0x002CCFEE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetActivityChest.OnTimeout(this.oArg);
		}

		// Token: 0x040058BB RID: 22715
		public GetActivityChestArg oArg = new GetActivityChestArg();

		// Token: 0x040058BC RID: 22716
		public GetActivityChestRes oRes = new GetActivityChestRes();
	}
}
