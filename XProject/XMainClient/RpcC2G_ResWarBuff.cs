using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ResWarBuff : Rpc
	{

		public override uint GetRpcType()
		{
			return 17670U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarBuffArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResWarBuffRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ResWarBuff.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ResWarBuff.OnTimeout(this.oArg);
		}

		public ResWarBuffArg oArg = new ResWarBuffArg();

		public ResWarBuffRes oRes = null;
	}
}
