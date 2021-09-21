using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011DE RID: 4574
	internal class RpcC2M_FetchTeamListC2M : Rpc
	{
		// Token: 0x0600DC41 RID: 56385 RVA: 0x00330158 File Offset: 0x0032E358
		public override uint GetRpcType()
		{
			return 3930U;
		}

		// Token: 0x0600DC42 RID: 56386 RVA: 0x0033016F File Offset: 0x0032E36F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchTeamListArg>(stream, this.oArg);
		}

		// Token: 0x0600DC43 RID: 56387 RVA: 0x0033017F File Offset: 0x0032E37F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchTeamListRes>(stream);
		}

		// Token: 0x0600DC44 RID: 56388 RVA: 0x0033018E File Offset: 0x0032E38E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchTeamListC2M.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DC45 RID: 56389 RVA: 0x003301AA File Offset: 0x0032E3AA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchTeamListC2M.OnTimeout(this.oArg);
		}

		// Token: 0x0400628A RID: 25226
		public FetchTeamListArg oArg = new FetchTeamListArg();

		// Token: 0x0400628B RID: 25227
		public FetchTeamListRes oRes = null;
	}
}
