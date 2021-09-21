using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200130D RID: 4877
	internal class RpcC2M_GetGuildBindInfo : Rpc
	{
		// Token: 0x0600E11F RID: 57631 RVA: 0x003370E8 File Offset: 0x003352E8
		public override uint GetRpcType()
		{
			return 62512U;
		}

		// Token: 0x0600E120 RID: 57632 RVA: 0x003370FF File Offset: 0x003352FF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildBindInfoReq>(stream, this.oArg);
		}

		// Token: 0x0600E121 RID: 57633 RVA: 0x0033710F File Offset: 0x0033530F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildBindInfoRes>(stream);
		}

		// Token: 0x0600E122 RID: 57634 RVA: 0x0033711E File Offset: 0x0033531E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetGuildBindInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E123 RID: 57635 RVA: 0x0033713A File Offset: 0x0033533A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetGuildBindInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400637B RID: 25467
		public GetGuildBindInfoReq oArg = new GetGuildBindInfoReq();

		// Token: 0x0400637C RID: 25468
		public GetGuildBindInfoRes oRes = null;
	}
}
