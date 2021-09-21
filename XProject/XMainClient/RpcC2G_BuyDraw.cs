using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200160B RID: 5643
	internal class RpcC2G_BuyDraw : Rpc
	{
		// Token: 0x0600ED5F RID: 60767 RVA: 0x003483B8 File Offset: 0x003465B8
		public override uint GetRpcType()
		{
			return 51925U;
		}

		// Token: 0x0600ED60 RID: 60768 RVA: 0x003483CF File Offset: 0x003465CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyDrawReq>(stream, this.oArg);
		}

		// Token: 0x0600ED61 RID: 60769 RVA: 0x003483DF File Offset: 0x003465DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyDrawRes>(stream);
		}

		// Token: 0x0600ED62 RID: 60770 RVA: 0x003483EE File Offset: 0x003465EE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyDraw.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED63 RID: 60771 RVA: 0x0034840A File Offset: 0x0034660A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyDraw.OnTimeout(this.oArg);
		}

		// Token: 0x040065DA RID: 26074
		public BuyDrawReq oArg = new BuyDrawReq();

		// Token: 0x040065DB RID: 26075
		public BuyDrawRes oRes = null;
	}
}
