using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010EB RID: 4331
	internal class RpcC2G_GetDesignationReq : Rpc
	{
		// Token: 0x0600D865 RID: 55397 RVA: 0x00329780 File Offset: 0x00327980
		public override uint GetRpcType()
		{
			return 44412U;
		}

		// Token: 0x0600D866 RID: 55398 RVA: 0x00329797 File Offset: 0x00327997
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDesignationReq>(stream, this.oArg);
		}

		// Token: 0x0600D867 RID: 55399 RVA: 0x003297A7 File Offset: 0x003279A7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDesignationRes>(stream);
		}

		// Token: 0x0600D868 RID: 55400 RVA: 0x003297B6 File Offset: 0x003279B6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetDesignationReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D869 RID: 55401 RVA: 0x003297D2 File Offset: 0x003279D2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetDesignationReq.OnTimeout(this.oArg);
		}

		// Token: 0x040061D1 RID: 25041
		public GetDesignationReq oArg = new GetDesignationReq();

		// Token: 0x040061D2 RID: 25042
		public GetDesignationRes oRes = new GetDesignationRes();
	}
}
