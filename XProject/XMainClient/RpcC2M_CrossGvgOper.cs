using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_CrossGvgOper : Rpc
	{

		public override uint GetRpcType()
		{
			return 46062U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CrossGvgOperArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CrossGvgOperRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CrossGvgOper.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CrossGvgOper.OnTimeout(this.oArg);
		}

		public CrossGvgOperArg oArg = new CrossGvgOperArg();

		public CrossGvgOperRes oRes = null;
	}
}
