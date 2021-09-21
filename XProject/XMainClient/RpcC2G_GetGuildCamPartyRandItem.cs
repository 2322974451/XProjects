using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014EE RID: 5358
	internal class RpcC2G_GetGuildCamPartyRandItem : Rpc
	{
		// Token: 0x0600E8CB RID: 59595 RVA: 0x00341BC8 File Offset: 0x0033FDC8
		public override uint GetRpcType()
		{
			return 53025U;
		}

		// Token: 0x0600E8CC RID: 59596 RVA: 0x00341BDF File Offset: 0x0033FDDF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildCamPartyRandItemArg>(stream, this.oArg);
		}

		// Token: 0x0600E8CD RID: 59597 RVA: 0x00341BEF File Offset: 0x0033FDEF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildCamPartyRandItemRes>(stream);
		}

		// Token: 0x0600E8CE RID: 59598 RVA: 0x00341BFE File Offset: 0x0033FDFE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildCamPartyRandItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E8CF RID: 59599 RVA: 0x00341C1A File Offset: 0x0033FE1A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildCamPartyRandItem.OnTimeout(this.oArg);
		}

		// Token: 0x040064F1 RID: 25841
		public GetGuildCamPartyRandItemArg oArg = new GetGuildCamPartyRandItemArg();

		// Token: 0x040064F2 RID: 25842
		public GetGuildCamPartyRandItemRes oRes = null;
	}
}
