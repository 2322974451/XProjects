using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_StartResWarPVE : Rpc
	{

		public override uint GetRpcType()
		{
			return 35398U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarPVEArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResWarPVERes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_StartResWarPVE.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_StartResWarPVE.OnTimeout(this.oArg);
		}

		public ResWarPVEArg oArg = new ResWarPVEArg();

		public ResWarPVERes oRes = null;
	}
}
