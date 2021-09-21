using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001339 RID: 4921
	internal class RpcC2M_PayNotify : Rpc
	{
		// Token: 0x0600E1D3 RID: 57811 RVA: 0x003382B0 File Offset: 0x003364B0
		public override uint GetRpcType()
		{
			return 32125U;
		}

		// Token: 0x0600E1D4 RID: 57812 RVA: 0x003382C7 File Offset: 0x003364C7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayNotifyArg>(stream, this.oArg);
		}

		// Token: 0x0600E1D5 RID: 57813 RVA: 0x003382D7 File Offset: 0x003364D7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PayNotifyRes>(stream);
		}

		// Token: 0x0600E1D6 RID: 57814 RVA: 0x003382E6 File Offset: 0x003364E6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_PayNotify.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E1D7 RID: 57815 RVA: 0x00338302 File Offset: 0x00336502
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_PayNotify.OnTimeout(this.oArg);
		}

		// Token: 0x0400639E RID: 25502
		public PayNotifyArg oArg = new PayNotifyArg();

		// Token: 0x0400639F RID: 25503
		public PayNotifyRes oRes = null;
	}
}
