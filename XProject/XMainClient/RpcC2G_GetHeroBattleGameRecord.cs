using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetHeroBattleGameRecord : Rpc
	{

		public override uint GetRpcType()
		{
			return 41057U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetHeroBattleGameRecordArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetHeroBattleGameRecordRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetHeroBattleGameRecord.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetHeroBattleGameRecord.OnTimeout(this.oArg);
		}

		public GetHeroBattleGameRecordArg oArg = new GetHeroBattleGameRecordArg();

		public GetHeroBattleGameRecordRes oRes = null;
	}
}
