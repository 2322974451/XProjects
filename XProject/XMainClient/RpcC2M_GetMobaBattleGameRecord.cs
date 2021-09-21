using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001547 RID: 5447
	internal class RpcC2M_GetMobaBattleGameRecord : Rpc
	{
		// Token: 0x0600EA34 RID: 59956 RVA: 0x00343E20 File Offset: 0x00342020
		public override uint GetRpcType()
		{
			return 9583U;
		}

		// Token: 0x0600EA35 RID: 59957 RVA: 0x00343E37 File Offset: 0x00342037
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMobaBattleGameRecordArg>(stream, this.oArg);
		}

		// Token: 0x0600EA36 RID: 59958 RVA: 0x00343E47 File Offset: 0x00342047
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMobaBattleGameRecordRes>(stream);
		}

		// Token: 0x0600EA37 RID: 59959 RVA: 0x00343E56 File Offset: 0x00342056
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMobaBattleGameRecord.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EA38 RID: 59960 RVA: 0x00343E72 File Offset: 0x00342072
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMobaBattleGameRecord.OnTimeout(this.oArg);
		}

		// Token: 0x04006536 RID: 25910
		public GetMobaBattleGameRecordArg oArg = new GetMobaBattleGameRecordArg();

		// Token: 0x04006537 RID: 25911
		public GetMobaBattleGameRecordRes oRes = null;
	}
}
