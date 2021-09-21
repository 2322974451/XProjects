using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001309 RID: 4873
	internal class RpcC2M_GetQADataReq : Rpc
	{
		// Token: 0x0600E10D RID: 57613 RVA: 0x00336EAC File Offset: 0x003350AC
		public override uint GetRpcType()
		{
			return 26871U;
		}

		// Token: 0x0600E10E RID: 57614 RVA: 0x00336EC3 File Offset: 0x003350C3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetQADataReq>(stream, this.oArg);
		}

		// Token: 0x0600E10F RID: 57615 RVA: 0x00336ED3 File Offset: 0x003350D3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetQADataRes>(stream);
		}

		// Token: 0x0600E110 RID: 57616 RVA: 0x00336EE2 File Offset: 0x003350E2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetQADataReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E111 RID: 57617 RVA: 0x00336EFE File Offset: 0x003350FE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetQADataReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006377 RID: 25463
		public GetQADataReq oArg = new GetQADataReq();

		// Token: 0x04006378 RID: 25464
		public GetQADataRes oRes = null;
	}
}
