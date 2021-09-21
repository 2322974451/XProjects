using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000D8C RID: 3468
	internal class RpcC2G_GetGuildBonusDetailInfo : Rpc
	{
		// Token: 0x0600BD21 RID: 48417 RVA: 0x00270870 File Offset: 0x0026EA70
		public override uint GetRpcType()
		{
			return 20027U;
		}

		// Token: 0x0600BD22 RID: 48418 RVA: 0x00270887 File Offset: 0x0026EA87
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildBonusDetailInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600BD23 RID: 48419 RVA: 0x00270897 File Offset: 0x0026EA97
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildBonusDetailInfoResult>(stream);
		}

		// Token: 0x0600BD24 RID: 48420 RVA: 0x002708A6 File Offset: 0x0026EAA6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildBonusDetailInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600BD25 RID: 48421 RVA: 0x002708C2 File Offset: 0x0026EAC2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildBonusDetailInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04004D04 RID: 19716
		public GetGuildBonusDetailInfoArg oArg = new GetGuildBonusDetailInfoArg();

		// Token: 0x04004D05 RID: 19717
		public GetGuildBonusDetailInfoResult oRes = new GetGuildBonusDetailInfoResult();
	}
}
