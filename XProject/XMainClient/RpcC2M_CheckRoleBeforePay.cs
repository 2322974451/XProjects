using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015C7 RID: 5575
	internal class RpcC2M_CheckRoleBeforePay : Rpc
	{
		// Token: 0x0600EC43 RID: 60483 RVA: 0x00346D68 File Offset: 0x00344F68
		public override uint GetRpcType()
		{
			return 56255U;
		}

		// Token: 0x0600EC44 RID: 60484 RVA: 0x00346D7F File Offset: 0x00344F7F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CheckRoleBeforePayArg>(stream, this.oArg);
		}

		// Token: 0x0600EC45 RID: 60485 RVA: 0x00346D8F File Offset: 0x00344F8F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CheckRoleBeforePayRes>(stream);
		}

		// Token: 0x0600EC46 RID: 60486 RVA: 0x00346D9E File Offset: 0x00344F9E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CheckRoleBeforePay.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EC47 RID: 60487 RVA: 0x00346DBA File Offset: 0x00344FBA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CheckRoleBeforePay.OnTimeout(this.oArg);
		}

		// Token: 0x040065A2 RID: 26018
		public CheckRoleBeforePayArg oArg = new CheckRoleBeforePayArg();

		// Token: 0x040065A3 RID: 26019
		public CheckRoleBeforePayRes oRes = null;
	}
}
