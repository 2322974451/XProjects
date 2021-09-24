using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetMobaBattleGameRecord : Rpc
	{

		public override uint GetRpcType()
		{
			return 9583U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMobaBattleGameRecordArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMobaBattleGameRecordRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMobaBattleGameRecord.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMobaBattleGameRecord.OnTimeout(this.oArg);
		}

		public GetMobaBattleGameRecordArg oArg = new GetMobaBattleGameRecordArg();

		public GetMobaBattleGameRecordRes oRes = null;
	}
}
