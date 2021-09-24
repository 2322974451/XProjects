using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SelectHeroAncientPower : Rpc
	{

		public override uint GetRpcType()
		{
			return 7667U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SelectHeroAncientPowerArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SelectHeroAncientPowerRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SelectHeroAncientPower.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SelectHeroAncientPower.OnTimeout(this.oArg);
		}

		public SelectHeroAncientPowerArg oArg = new SelectHeroAncientPowerArg();

		public SelectHeroAncientPowerRes oRes = null;
	}
}
