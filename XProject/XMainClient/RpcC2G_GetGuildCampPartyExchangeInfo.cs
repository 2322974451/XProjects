using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014F4 RID: 5364
	internal class RpcC2G_GetGuildCampPartyExchangeInfo : Rpc
	{
		// Token: 0x0600E8E4 RID: 59620 RVA: 0x00341E80 File Offset: 0x00340080
		public override uint GetRpcType()
		{
			return 44443U;
		}

		// Token: 0x0600E8E5 RID: 59621 RVA: 0x00341E97 File Offset: 0x00340097
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildCampPartyExchangeInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E8E6 RID: 59622 RVA: 0x00341EA7 File Offset: 0x003400A7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildCampPartyExchangeInfoRes>(stream);
		}

		// Token: 0x0600E8E7 RID: 59623 RVA: 0x00341EB6 File Offset: 0x003400B6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildCampPartyExchangeInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E8E8 RID: 59624 RVA: 0x00341ED2 File Offset: 0x003400D2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildCampPartyExchangeInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040064F6 RID: 25846
		public GetGuildCampPartyExchangeInfoArg oArg = new GetGuildCampPartyExchangeInfoArg();

		// Token: 0x040064F7 RID: 25847
		public GetGuildCampPartyExchangeInfoRes oRes = null;
	}
}
