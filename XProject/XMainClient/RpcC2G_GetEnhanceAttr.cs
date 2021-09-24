using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetEnhanceAttr : Rpc
	{

		public override uint GetRpcType()
		{
			return 23396U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetEnhanceAttrArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetEnhanceAttrRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetEnhanceAttr.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetEnhanceAttr.OnTimeout(this.oArg);
		}

		public GetEnhanceAttrArg oArg = new GetEnhanceAttrArg();

		public GetEnhanceAttrRes oRes = null;
	}
}
