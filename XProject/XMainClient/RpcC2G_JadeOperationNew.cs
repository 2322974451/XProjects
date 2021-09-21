using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016A7 RID: 5799
	internal class RpcC2G_JadeOperationNew : Rpc
	{
		// Token: 0x0600EFF3 RID: 61427 RVA: 0x0034C164 File Offset: 0x0034A364
		public override uint GetRpcType()
		{
			return 40839U;
		}

		// Token: 0x0600EFF4 RID: 61428 RVA: 0x0034C17B File Offset: 0x0034A37B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JadeOperationNewArg>(stream, this.oArg);
		}

		// Token: 0x0600EFF5 RID: 61429 RVA: 0x0034C18B File Offset: 0x0034A38B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JadeOperationNewRes>(stream);
		}

		// Token: 0x0600EFF6 RID: 61430 RVA: 0x0034C19A File Offset: 0x0034A39A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_JadeOperationNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EFF7 RID: 61431 RVA: 0x0034C1B6 File Offset: 0x0034A3B6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_JadeOperationNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006667 RID: 26215
		public JadeOperationNewArg oArg = new JadeOperationNewArg();

		// Token: 0x04006668 RID: 26216
		public JadeOperationNewRes oRes = null;
	}
}
