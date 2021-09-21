using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014C7 RID: 5319
	internal class RpcC2G_ArgentaActivity : Rpc
	{
		// Token: 0x0600E824 RID: 59428 RVA: 0x00340F5C File Offset: 0x0033F15C
		public override uint GetRpcType()
		{
			return 838U;
		}

		// Token: 0x0600E825 RID: 59429 RVA: 0x00340F73 File Offset: 0x0033F173
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ArgentaActivityArg>(stream, this.oArg);
		}

		// Token: 0x0600E826 RID: 59430 RVA: 0x00340F83 File Offset: 0x0033F183
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ArgentaActivityRes>(stream);
		}

		// Token: 0x0600E827 RID: 59431 RVA: 0x00340F92 File Offset: 0x0033F192
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ArgentaActivity.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E828 RID: 59432 RVA: 0x00340FAE File Offset: 0x0033F1AE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ArgentaActivity.OnTimeout(this.oArg);
		}

		// Token: 0x040064CF RID: 25807
		public ArgentaActivityArg oArg = new ArgentaActivityArg();

		// Token: 0x040064D0 RID: 25808
		public ArgentaActivityRes oRes = null;
	}
}
