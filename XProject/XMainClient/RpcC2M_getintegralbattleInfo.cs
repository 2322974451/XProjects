using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_getintegralbattleInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 27825U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<getintegralbattleInfoarg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<getintegralbattleInfores>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_getintegralbattleInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_getintegralbattleInfo.OnTimeout(this.oArg);
		}

		public getintegralbattleInfoarg oArg = new getintegralbattleInfoarg();

		public getintegralbattleInfores oRes = null;
	}
}
