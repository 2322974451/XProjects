using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010EF RID: 4335
	internal class RpcC2G_GetClassifyDesignationReq : Rpc
	{
		// Token: 0x0600D877 RID: 55415 RVA: 0x003299C0 File Offset: 0x00327BC0
		public override uint GetRpcType()
		{
			return 40256U;
		}

		// Token: 0x0600D878 RID: 55416 RVA: 0x003299D7 File Offset: 0x00327BD7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetClassifyDesignationReq>(stream, this.oArg);
		}

		// Token: 0x0600D879 RID: 55417 RVA: 0x003299E7 File Offset: 0x00327BE7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetClassifyDesignationRes>(stream);
		}

		// Token: 0x0600D87A RID: 55418 RVA: 0x003299F6 File Offset: 0x00327BF6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetClassifyDesignationReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D87B RID: 55419 RVA: 0x00329A12 File Offset: 0x00327C12
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetClassifyDesignationReq.OnTimeout(this.oArg);
		}

		// Token: 0x040061D5 RID: 25045
		public GetClassifyDesignationReq oArg = new GetClassifyDesignationReq();

		// Token: 0x040061D6 RID: 25046
		public GetClassifyDesignationRes oRes = new GetClassifyDesignationRes();
	}
}
