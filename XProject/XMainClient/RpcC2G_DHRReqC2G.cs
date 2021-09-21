using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001545 RID: 5445
	internal class RpcC2G_DHRReqC2G : Rpc
	{
		// Token: 0x0600EA2B RID: 59947 RVA: 0x00343D14 File Offset: 0x00341F14
		public override uint GetRpcType()
		{
			return 12451U;
		}

		// Token: 0x0600EA2C RID: 59948 RVA: 0x00343D2B File Offset: 0x00341F2B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DHRArg>(stream, this.oArg);
		}

		// Token: 0x0600EA2D RID: 59949 RVA: 0x00343D3B File Offset: 0x00341F3B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DHRRes>(stream);
		}

		// Token: 0x0600EA2E RID: 59950 RVA: 0x00343D4A File Offset: 0x00341F4A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DHRReqC2G.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EA2F RID: 59951 RVA: 0x00343D66 File Offset: 0x00341F66
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DHRReqC2G.OnTimeout(this.oArg);
		}

		// Token: 0x04006534 RID: 25908
		public DHRArg oArg = new DHRArg();

		// Token: 0x04006535 RID: 25909
		public DHRRes oRes = null;
	}
}
