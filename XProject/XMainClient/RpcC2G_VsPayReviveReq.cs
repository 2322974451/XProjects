using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016A0 RID: 5792
	internal class RpcC2G_VsPayReviveReq : Rpc
	{
		// Token: 0x0600EFD5 RID: 61397 RVA: 0x0034BF78 File Offset: 0x0034A178
		public override uint GetRpcType()
		{
			return 54530U;
		}

		// Token: 0x0600EFD6 RID: 61398 RVA: 0x0034BF8F File Offset: 0x0034A18F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<VsPayRevivePara>(stream, this.oArg);
		}

		// Token: 0x0600EFD7 RID: 61399 RVA: 0x0034BF9F File Offset: 0x0034A19F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<VsPayReviveRes>(stream);
		}

		// Token: 0x0600EFD8 RID: 61400 RVA: 0x0034BFAE File Offset: 0x0034A1AE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_VsPayReviveReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EFD9 RID: 61401 RVA: 0x0034BFCA File Offset: 0x0034A1CA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_VsPayReviveReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006661 RID: 26209
		public VsPayRevivePara oArg = new VsPayRevivePara();

		// Token: 0x04006662 RID: 26210
		public VsPayReviveRes oRes = null;
	}
}
