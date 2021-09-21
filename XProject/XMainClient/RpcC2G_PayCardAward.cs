using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011D2 RID: 4562
	internal class RpcC2G_PayCardAward : Rpc
	{
		// Token: 0x0600DC0F RID: 56335 RVA: 0x0032FD10 File Offset: 0x0032DF10
		public override uint GetRpcType()
		{
			return 20470U;
		}

		// Token: 0x0600DC10 RID: 56336 RVA: 0x0032FD27 File Offset: 0x0032DF27
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayCardAwardArg>(stream, this.oArg);
		}

		// Token: 0x0600DC11 RID: 56337 RVA: 0x0032FD37 File Offset: 0x0032DF37
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PayCardAwardRes>(stream);
		}

		// Token: 0x0600DC12 RID: 56338 RVA: 0x0032FD46 File Offset: 0x0032DF46
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PayCardAward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DC13 RID: 56339 RVA: 0x0032FD62 File Offset: 0x0032DF62
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PayCardAward.OnTimeout(this.oArg);
		}

		// Token: 0x04006280 RID: 25216
		public PayCardAwardArg oArg = new PayCardAwardArg();

		// Token: 0x04006281 RID: 25217
		public PayCardAwardRes oRes = new PayCardAwardRes();
	}
}
