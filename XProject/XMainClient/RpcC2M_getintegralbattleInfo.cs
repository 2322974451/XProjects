using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200136A RID: 4970
	internal class RpcC2M_getintegralbattleInfo : Rpc
	{
		// Token: 0x0600E29D RID: 58013 RVA: 0x00339508 File Offset: 0x00337708
		public override uint GetRpcType()
		{
			return 27825U;
		}

		// Token: 0x0600E29E RID: 58014 RVA: 0x0033951F File Offset: 0x0033771F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<getintegralbattleInfoarg>(stream, this.oArg);
		}

		// Token: 0x0600E29F RID: 58015 RVA: 0x0033952F File Offset: 0x0033772F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<getintegralbattleInfores>(stream);
		}

		// Token: 0x0600E2A0 RID: 58016 RVA: 0x0033953E File Offset: 0x0033773E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_getintegralbattleInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E2A1 RID: 58017 RVA: 0x0033955A File Offset: 0x0033775A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_getintegralbattleInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040063C6 RID: 25542
		public getintegralbattleInfoarg oArg = new getintegralbattleInfoarg();

		// Token: 0x040063C7 RID: 25543
		public getintegralbattleInfores oRes = null;
	}
}
