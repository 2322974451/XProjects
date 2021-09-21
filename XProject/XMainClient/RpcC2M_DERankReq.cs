using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001253 RID: 4691
	internal class RpcC2M_DERankReq : Rpc
	{
		// Token: 0x0600DE1F RID: 56863 RVA: 0x00332DB8 File Offset: 0x00330FB8
		public override uint GetRpcType()
		{
			return 16406U;
		}

		// Token: 0x0600DE20 RID: 56864 RVA: 0x00332DCF File Offset: 0x00330FCF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DERankArg>(stream, this.oArg);
		}

		// Token: 0x0600DE21 RID: 56865 RVA: 0x00332DDF File Offset: 0x00330FDF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DERankRes>(stream);
		}

		// Token: 0x0600DE22 RID: 56866 RVA: 0x00332DEE File Offset: 0x00330FEE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DERankReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DE23 RID: 56867 RVA: 0x00332E0A File Offset: 0x0033100A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DERankReq.OnTimeout(this.oArg);
		}

		// Token: 0x040062E6 RID: 25318
		public DERankArg oArg = new DERankArg();

		// Token: 0x040062E7 RID: 25319
		public DERankRes oRes = null;
	}
}
