using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001333 RID: 4915
	internal class RpcC2M_ActiveCookbook : Rpc
	{
		// Token: 0x0600E1BA RID: 57786 RVA: 0x00337FAC File Offset: 0x003361AC
		public override uint GetRpcType()
		{
			return 31076U;
		}

		// Token: 0x0600E1BB RID: 57787 RVA: 0x00337FC3 File Offset: 0x003361C3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ActiveCookbookArg>(stream, this.oArg);
		}

		// Token: 0x0600E1BC RID: 57788 RVA: 0x00337FD3 File Offset: 0x003361D3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ActiveCookbookRes>(stream);
		}

		// Token: 0x0600E1BD RID: 57789 RVA: 0x00337FE2 File Offset: 0x003361E2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ActiveCookbook.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E1BE RID: 57790 RVA: 0x00337FFE File Offset: 0x003361FE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ActiveCookbook.OnTimeout(this.oArg);
		}

		// Token: 0x04006399 RID: 25497
		public ActiveCookbookArg oArg = new ActiveCookbookArg();

		// Token: 0x0400639A RID: 25498
		public ActiveCookbookRes oRes = null;
	}
}
