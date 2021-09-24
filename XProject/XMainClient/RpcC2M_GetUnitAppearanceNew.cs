using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetUnitAppearanceNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 40593U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetUnitAppearanceArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetUnitAppearanceRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetUnitAppearanceNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetUnitAppearanceNew.OnTimeout(this.oArg);
		}

		public GetUnitAppearanceArg oArg = new GetUnitAppearanceArg();

		public GetUnitAppearanceRes oRes = null;
	}
}
