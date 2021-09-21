using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016B9 RID: 5817
	internal class RpcC2G_ShadowCatOperation : Rpc
	{
		// Token: 0x0600F040 RID: 61504 RVA: 0x0034C58C File Offset: 0x0034A78C
		public override uint GetRpcType()
		{
			return 7140U;
		}

		// Token: 0x0600F041 RID: 61505 RVA: 0x0034C5A3 File Offset: 0x0034A7A3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ShadowCatOperationArg>(stream, this.oArg);
		}

		// Token: 0x0600F042 RID: 61506 RVA: 0x0034C5B3 File Offset: 0x0034A7B3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ShadowCatOperationRes>(stream);
		}

		// Token: 0x0600F043 RID: 61507 RVA: 0x0034C5C2 File Offset: 0x0034A7C2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ShadowCatOperation.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600F044 RID: 61508 RVA: 0x0034C5DE File Offset: 0x0034A7DE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ShadowCatOperation.OnTimeout(this.oArg);
		}

		// Token: 0x04006677 RID: 26231
		public ShadowCatOperationArg oArg = new ShadowCatOperationArg();

		// Token: 0x04006678 RID: 26232
		public ShadowCatOperationRes oRes = null;
	}
}
