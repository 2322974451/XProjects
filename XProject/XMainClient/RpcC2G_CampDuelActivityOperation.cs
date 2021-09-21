using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001680 RID: 5760
	internal class RpcC2G_CampDuelActivityOperation : Rpc
	{
		// Token: 0x0600EF4F RID: 61263 RVA: 0x0034B198 File Offset: 0x00349398
		public override uint GetRpcType()
		{
			return 1361U;
		}

		// Token: 0x0600EF50 RID: 61264 RVA: 0x0034B1AF File Offset: 0x003493AF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CampDuelActivityOperationArg>(stream, this.oArg);
		}

		// Token: 0x0600EF51 RID: 61265 RVA: 0x0034B1BF File Offset: 0x003493BF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CampDuelActivityOperationRes>(stream);
		}

		// Token: 0x0600EF52 RID: 61266 RVA: 0x0034B1CE File Offset: 0x003493CE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_CampDuelActivityOperation.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF53 RID: 61267 RVA: 0x0034B1EA File Offset: 0x003493EA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_CampDuelActivityOperation.OnTimeout(this.oArg);
		}

		// Token: 0x04006646 RID: 26182
		public CampDuelActivityOperationArg oArg = new CampDuelActivityOperationArg();

		// Token: 0x04006647 RID: 26183
		public CampDuelActivityOperationRes oRes = null;
	}
}
