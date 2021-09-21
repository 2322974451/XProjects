using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016B7 RID: 5815
	internal class RpcC2G_InlayAllJade : Rpc
	{
		// Token: 0x0600F037 RID: 61495 RVA: 0x0034C50C File Offset: 0x0034A70C
		public override uint GetRpcType()
		{
			return 58864U;
		}

		// Token: 0x0600F038 RID: 61496 RVA: 0x0034C523 File Offset: 0x0034A723
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InlayAllJadeArg>(stream, this.oArg);
		}

		// Token: 0x0600F039 RID: 61497 RVA: 0x0034C533 File Offset: 0x0034A733
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<InlayAllJadeRes>(stream);
		}

		// Token: 0x0600F03A RID: 61498 RVA: 0x0034C542 File Offset: 0x0034A742
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_InlayAllJade.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600F03B RID: 61499 RVA: 0x0034C55E File Offset: 0x0034A75E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_InlayAllJade.OnTimeout(this.oArg);
		}

		// Token: 0x04006675 RID: 26229
		public InlayAllJadeArg oArg = new InlayAllJadeArg();

		// Token: 0x04006676 RID: 26230
		public InlayAllJadeRes oRes = null;
	}
}
