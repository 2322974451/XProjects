using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_AddTempAttr : Rpc
	{

		public override uint GetRpcType()
		{
			return 22021U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AddTempAttrArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AddTempAttrRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_AddTempAttr.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_AddTempAttr.OnTimeout(this.oArg);
		}

		public AddTempAttrArg oArg = new AddTempAttrArg();

		public AddTempAttrRes oRes = new AddTempAttrRes();
	}
}
