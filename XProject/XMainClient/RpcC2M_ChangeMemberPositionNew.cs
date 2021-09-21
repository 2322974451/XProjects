using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012B9 RID: 4793
	internal class RpcC2M_ChangeMemberPositionNew : Rpc
	{
		// Token: 0x0600DFC4 RID: 57284 RVA: 0x00335174 File Offset: 0x00333374
		public override uint GetRpcType()
		{
			return 13625U;
		}

		// Token: 0x0600DFC5 RID: 57285 RVA: 0x0033518B File Offset: 0x0033338B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeGuildPositionArg>(stream, this.oArg);
		}

		// Token: 0x0600DFC6 RID: 57286 RVA: 0x0033519B File Offset: 0x0033339B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeGuildPositionRes>(stream);
		}

		// Token: 0x0600DFC7 RID: 57287 RVA: 0x003351AA File Offset: 0x003333AA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ChangeMemberPositionNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DFC8 RID: 57288 RVA: 0x003351C6 File Offset: 0x003333C6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ChangeMemberPositionNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006338 RID: 25400
		public ChangeGuildPositionArg oArg = new ChangeGuildPositionArg();

		// Token: 0x04006339 RID: 25401
		public ChangeGuildPositionRes oRes = null;
	}
}
