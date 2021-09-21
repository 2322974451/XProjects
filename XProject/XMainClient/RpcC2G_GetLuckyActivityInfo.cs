using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001609 RID: 5641
	internal class RpcC2G_GetLuckyActivityInfo : Rpc
	{
		// Token: 0x0600ED56 RID: 60758 RVA: 0x003482F0 File Offset: 0x003464F0
		public override uint GetRpcType()
		{
			return 384U;
		}

		// Token: 0x0600ED57 RID: 60759 RVA: 0x00348307 File Offset: 0x00346507
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLuckyActivityInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600ED58 RID: 60760 RVA: 0x00348317 File Offset: 0x00346517
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLuckyActivityInfoRes>(stream);
		}

		// Token: 0x0600ED59 RID: 60761 RVA: 0x00348326 File Offset: 0x00346526
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetLuckyActivityInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED5A RID: 60762 RVA: 0x00348342 File Offset: 0x00346542
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetLuckyActivityInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040065D8 RID: 26072
		public GetLuckyActivityInfoArg oArg = new GetLuckyActivityInfoArg();

		// Token: 0x040065D9 RID: 26073
		public GetLuckyActivityInfoRes oRes = null;
	}
}
