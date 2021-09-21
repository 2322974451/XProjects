using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200148F RID: 5263
	internal class RpcC2M_GetLeagueBattleRecord : Rpc
	{
		// Token: 0x0600E741 RID: 59201 RVA: 0x0033FBC0 File Offset: 0x0033DDC0
		public override uint GetRpcType()
		{
			return 51407U;
		}

		// Token: 0x0600E742 RID: 59202 RVA: 0x0033FBD7 File Offset: 0x0033DDD7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLeagueBattleRecordArg>(stream, this.oArg);
		}

		// Token: 0x0600E743 RID: 59203 RVA: 0x0033FBE7 File Offset: 0x0033DDE7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLeagueBattleRecordRes>(stream);
		}

		// Token: 0x0600E744 RID: 59204 RVA: 0x0033FBF6 File Offset: 0x0033DDF6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetLeagueBattleRecord.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E745 RID: 59205 RVA: 0x0033FC12 File Offset: 0x0033DE12
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetLeagueBattleRecord.OnTimeout(this.oArg);
		}

		// Token: 0x040064A5 RID: 25765
		public GetLeagueBattleRecordArg oArg = new GetLeagueBattleRecordArg();

		// Token: 0x040064A6 RID: 25766
		public GetLeagueBattleRecordRes oRes = null;
	}
}
