using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000D8D RID: 3469
	internal class RpcC2G_GetGuildBonusList : Rpc
	{
		// Token: 0x0600BD27 RID: 48423 RVA: 0x002708F4 File Offset: 0x0026EAF4
		public override uint GetRpcType()
		{
			return 43440U;
		}

		// Token: 0x0600BD28 RID: 48424 RVA: 0x0027090B File Offset: 0x0026EB0B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildBonusListArg>(stream, this.oArg);
		}

		// Token: 0x0600BD29 RID: 48425 RVA: 0x0027091B File Offset: 0x0026EB1B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildBonusListResult>(stream);
		}

		// Token: 0x0600BD2A RID: 48426 RVA: 0x0027092A File Offset: 0x0026EB2A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildBonusList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600BD2B RID: 48427 RVA: 0x00270946 File Offset: 0x0026EB46
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildBonusList.OnTimeout(this.oArg);
		}

		// Token: 0x04004D06 RID: 19718
		public GetGuildBonusListArg oArg = new GetGuildBonusListArg();

		// Token: 0x04004D07 RID: 19719
		public GetGuildBonusListResult oRes = new GetGuildBonusListResult();
	}
}
