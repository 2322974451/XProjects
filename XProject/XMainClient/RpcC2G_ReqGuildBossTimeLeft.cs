using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012F6 RID: 4854
	internal class RpcC2G_ReqGuildBossTimeLeft : Rpc
	{
		// Token: 0x0600E0C2 RID: 57538 RVA: 0x00336958 File Offset: 0x00334B58
		public override uint GetRpcType()
		{
			return 24494U;
		}

		// Token: 0x0600E0C3 RID: 57539 RVA: 0x0033696F File Offset: 0x00334B6F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<getguildbosstimeleftArg>(stream, this.oArg);
		}

		// Token: 0x0600E0C4 RID: 57540 RVA: 0x0033697F File Offset: 0x00334B7F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<getguildbosstimeleftRes>(stream);
		}

		// Token: 0x0600E0C5 RID: 57541 RVA: 0x0033698E File Offset: 0x00334B8E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReqGuildBossTimeLeft.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E0C6 RID: 57542 RVA: 0x003369AA File Offset: 0x00334BAA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReqGuildBossTimeLeft.OnTimeout(this.oArg);
		}

		// Token: 0x0400636A RID: 25450
		public getguildbosstimeleftArg oArg = new getguildbosstimeleftArg();

		// Token: 0x0400636B RID: 25451
		public getguildbosstimeleftRes oRes = new getguildbosstimeleftRes();
	}
}
