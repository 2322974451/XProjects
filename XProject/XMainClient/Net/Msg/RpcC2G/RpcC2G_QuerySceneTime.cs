using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_QuerySceneTime : Rpc
	{

		public override uint GetRpcType()
		{
			return 39595U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QuerySceneTimeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QuerySceneTimeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QuerySceneTime.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QuerySceneTime.OnTimeout(this.oArg);
		}

		public QuerySceneTimeArg oArg = new QuerySceneTimeArg();

		public QuerySceneTimeRes oRes = new QuerySceneTimeRes();
	}
}
