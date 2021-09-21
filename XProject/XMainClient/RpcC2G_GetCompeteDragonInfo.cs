using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015FD RID: 5629
	internal class RpcC2G_GetCompeteDragonInfo : Rpc
	{
		// Token: 0x0600ED24 RID: 60708 RVA: 0x00347F70 File Offset: 0x00346170
		public override uint GetRpcType()
		{
			return 65362U;
		}

		// Token: 0x0600ED25 RID: 60709 RVA: 0x00347F87 File Offset: 0x00346187
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetCompeteDragonInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600ED26 RID: 60710 RVA: 0x00347F97 File Offset: 0x00346197
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetCompeteDragonInfoRes>(stream);
		}

		// Token: 0x0600ED27 RID: 60711 RVA: 0x00347FA6 File Offset: 0x003461A6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetCompeteDragonInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED28 RID: 60712 RVA: 0x00347FC2 File Offset: 0x003461C2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetCompeteDragonInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040065CE RID: 26062
		public GetCompeteDragonInfoArg oArg = new GetCompeteDragonInfoArg();

		// Token: 0x040065CF RID: 26063
		public GetCompeteDragonInfoRes oRes = null;
	}
}
