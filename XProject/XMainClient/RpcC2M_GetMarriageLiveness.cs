using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015C3 RID: 5571
	internal class RpcC2M_GetMarriageLiveness : Rpc
	{
		// Token: 0x0600EC31 RID: 60465 RVA: 0x00346B90 File Offset: 0x00344D90
		public override uint GetRpcType()
		{
			return 30055U;
		}

		// Token: 0x0600EC32 RID: 60466 RVA: 0x00346BA7 File Offset: 0x00344DA7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMarriageLivenessArg>(stream, this.oArg);
		}

		// Token: 0x0600EC33 RID: 60467 RVA: 0x00346BB7 File Offset: 0x00344DB7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMarriageLivenessRes>(stream);
		}

		// Token: 0x0600EC34 RID: 60468 RVA: 0x00346BC6 File Offset: 0x00344DC6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMarriageLiveness.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EC35 RID: 60469 RVA: 0x00346BE2 File Offset: 0x00344DE2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMarriageLiveness.OnTimeout(this.oArg);
		}

		// Token: 0x0400659E RID: 26014
		public GetMarriageLivenessArg oArg = new GetMarriageLivenessArg();

		// Token: 0x0400659F RID: 26015
		public GetMarriageLivenessRes oRes = null;
	}
}
