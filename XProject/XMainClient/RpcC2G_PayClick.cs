using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011D6 RID: 4566
	internal class RpcC2G_PayClick : Rpc
	{
		// Token: 0x0600DC1F RID: 56351 RVA: 0x0032FE4C File Offset: 0x0032E04C
		public override uint GetRpcType()
		{
			return 20376U;
		}

		// Token: 0x0600DC20 RID: 56352 RVA: 0x0032FE63 File Offset: 0x0032E063
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayClickArg>(stream, this.oArg);
		}

		// Token: 0x0600DC21 RID: 56353 RVA: 0x0032FE73 File Offset: 0x0032E073
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PayClickRes>(stream);
		}

		// Token: 0x0600DC22 RID: 56354 RVA: 0x0032FE82 File Offset: 0x0032E082
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PayClick.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DC23 RID: 56355 RVA: 0x0032FE9E File Offset: 0x0032E09E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PayClick.OnTimeout(this.oArg);
		}

		// Token: 0x04006283 RID: 25219
		public PayClickArg oArg = new PayClickArg();

		// Token: 0x04006284 RID: 25220
		public PayClickRes oRes = new PayClickRes();
	}
}
