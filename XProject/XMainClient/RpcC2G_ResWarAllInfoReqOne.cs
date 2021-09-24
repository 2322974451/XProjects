using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ResWarAllInfoReqOne : Rpc
	{

		public override uint GetRpcType()
		{
			return 8828U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResWarRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ResWarAllInfoReqOne.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ResWarAllInfoReqOne.OnTimeout(this.oArg);
		}

		public ResWarArg oArg = new ResWarArg();

		public ResWarRes oRes = new ResWarRes();
	}
}
