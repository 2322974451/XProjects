using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ActivateHairColor : Rpc
	{

		public override uint GetRpcType()
		{
			return 52321U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ActivateHairColorArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ActivateHairColorRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ActivateHairColor.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ActivateHairColor.OnTimeout(this.oArg);
		}

		public ActivateHairColorArg oArg = new ActivateHairColorArg();

		public ActivateHairColorRes oRes = null;
	}
}
