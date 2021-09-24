using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_getapplyguildlist : Rpc
	{

		public override uint GetRpcType()
		{
			return 31771U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<getapplyguildlistarg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<getapplyguildlistres>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_getapplyguildlist.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_getapplyguildlist.OnTimeout(this.oArg);
		}

		public getapplyguildlistarg oArg = new getapplyguildlistarg();

		public getapplyguildlistres oRes = null;
	}
}
