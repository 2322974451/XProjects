using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200142B RID: 5163
	internal class RpcC2M_RecAlliance : Rpc
	{
		// Token: 0x0600E5B2 RID: 58802 RVA: 0x0033D4D4 File Offset: 0x0033B6D4
		public override uint GetRpcType()
		{
			return 31937U;
		}

		// Token: 0x0600E5B3 RID: 58803 RVA: 0x0033D4EB File Offset: 0x0033B6EB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RecAllianceArg>(stream, this.oArg);
		}

		// Token: 0x0600E5B4 RID: 58804 RVA: 0x0033D4FB File Offset: 0x0033B6FB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RecAllianceRes>(stream);
		}

		// Token: 0x0600E5B5 RID: 58805 RVA: 0x0033D50A File Offset: 0x0033B70A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_RecAlliance.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E5B6 RID: 58806 RVA: 0x0033D526 File Offset: 0x0033B726
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_RecAlliance.OnTimeout(this.oArg);
		}

		// Token: 0x0400645C RID: 25692
		public RecAllianceArg oArg = new RecAllianceArg();

		// Token: 0x0400645D RID: 25693
		public RecAllianceRes oRes = null;
	}
}
