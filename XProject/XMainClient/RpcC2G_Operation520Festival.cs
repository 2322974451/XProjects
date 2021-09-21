using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016B1 RID: 5809
	internal class RpcC2G_Operation520Festival : Rpc
	{
		// Token: 0x0600F01E RID: 61470 RVA: 0x0034C3B8 File Offset: 0x0034A5B8
		public override uint GetRpcType()
		{
			return 17971U;
		}

		// Token: 0x0600F01F RID: 61471 RVA: 0x0034C3CF File Offset: 0x0034A5CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<Operation520FestivalArg>(stream, this.oArg);
		}

		// Token: 0x0600F020 RID: 61472 RVA: 0x0034C3DF File Offset: 0x0034A5DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<Operation520FestivalRes>(stream);
		}

		// Token: 0x0600F021 RID: 61473 RVA: 0x0034C3EE File Offset: 0x0034A5EE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_Operation520Festival.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600F022 RID: 61474 RVA: 0x0034C40A File Offset: 0x0034A60A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_Operation520Festival.OnTimeout(this.oArg);
		}

		// Token: 0x04006670 RID: 26224
		public Operation520FestivalArg oArg = new Operation520FestivalArg();

		// Token: 0x04006671 RID: 26225
		public Operation520FestivalRes oRes = null;
	}
}
