using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001140 RID: 4416
	internal class RpcC2G_GetDragonTopInfo : Rpc
	{
		// Token: 0x0600D9C7 RID: 55751 RVA: 0x0032B920 File Offset: 0x00329B20
		public override uint GetRpcType()
		{
			return 7973U;
		}

		// Token: 0x0600D9C8 RID: 55752 RVA: 0x0032B937 File Offset: 0x00329B37
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDragonTopInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600D9C9 RID: 55753 RVA: 0x0032B947 File Offset: 0x00329B47
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDragonTopInfoRes>(stream);
		}

		// Token: 0x0600D9CA RID: 55754 RVA: 0x0032B956 File Offset: 0x00329B56
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetDragonTopInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D9CB RID: 55755 RVA: 0x0032B972 File Offset: 0x00329B72
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetDragonTopInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006215 RID: 25109
		public GetDragonTopInfoArg oArg = new GetDragonTopInfoArg();

		// Token: 0x04006216 RID: 25110
		public GetDragonTopInfoRes oRes = new GetDragonTopInfoRes();
	}
}
