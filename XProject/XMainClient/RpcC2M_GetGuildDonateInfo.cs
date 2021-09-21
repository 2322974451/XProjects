using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001393 RID: 5011
	internal class RpcC2M_GetGuildDonateInfo : Rpc
	{
		// Token: 0x0600E345 RID: 58181 RVA: 0x0033A1E8 File Offset: 0x003383E8
		public override uint GetRpcType()
		{
			return 14656U;
		}

		// Token: 0x0600E346 RID: 58182 RVA: 0x0033A1FF File Offset: 0x003383FF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildDonateInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E347 RID: 58183 RVA: 0x0033A20F File Offset: 0x0033840F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildDonateInfoRes>(stream);
		}

		// Token: 0x0600E348 RID: 58184 RVA: 0x0033A21E File Offset: 0x0033841E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetGuildDonateInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E349 RID: 58185 RVA: 0x0033A23A File Offset: 0x0033843A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetGuildDonateInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040063E6 RID: 25574
		public GetGuildDonateInfoArg oArg = new GetGuildDonateInfoArg();

		// Token: 0x040063E7 RID: 25575
		public GetGuildDonateInfoRes oRes = null;
	}
}
