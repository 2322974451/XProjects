using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200110E RID: 4366
	internal class RpcC2G_FiveDayRewardReq : Rpc
	{
		// Token: 0x0600D8F7 RID: 55543 RVA: 0x0032A4B8 File Offset: 0x003286B8
		public override uint GetRpcType()
		{
			return 63999U;
		}

		// Token: 0x0600D8F8 RID: 55544 RVA: 0x0032A4CF File Offset: 0x003286CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FiveRewardRes>(stream, this.oArg);
		}

		// Token: 0x0600D8F9 RID: 55545 RVA: 0x0032A4DF File Offset: 0x003286DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FiveRewardRet>(stream);
		}

		// Token: 0x0600D8FA RID: 55546 RVA: 0x0032A4EE File Offset: 0x003286EE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FiveDayRewardReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D8FB RID: 55547 RVA: 0x0032A50A File Offset: 0x0032870A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FiveDayRewardReq.OnTimeout(this.oArg);
		}

		// Token: 0x040061ED RID: 25069
		public FiveRewardRes oArg = new FiveRewardRes();

		// Token: 0x040061EE RID: 25070
		public FiveRewardRet oRes = new FiveRewardRet();
	}
}
