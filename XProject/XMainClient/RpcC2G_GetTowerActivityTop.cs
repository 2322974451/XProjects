using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010E7 RID: 4327
	internal class RpcC2G_GetTowerActivityTop : Rpc
	{
		// Token: 0x0600D855 RID: 55381 RVA: 0x0032964C File Offset: 0x0032784C
		public override uint GetRpcType()
		{
			return 5168U;
		}

		// Token: 0x0600D856 RID: 55382 RVA: 0x00329663 File Offset: 0x00327863
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetTowerActivityTopArg>(stream, this.oArg);
		}

		// Token: 0x0600D857 RID: 55383 RVA: 0x00329673 File Offset: 0x00327873
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetTowerActivityTopRes>(stream);
		}

		// Token: 0x0600D858 RID: 55384 RVA: 0x00329682 File Offset: 0x00327882
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetTowerActivityTop.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D859 RID: 55385 RVA: 0x0032969E File Offset: 0x0032789E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetTowerActivityTop.OnTimeout(this.oArg);
		}

		// Token: 0x040061CE RID: 25038
		public GetTowerActivityTopArg oArg = new GetTowerActivityTopArg();

		// Token: 0x040061CF RID: 25039
		public GetTowerActivityTopRes oRes = new GetTowerActivityTopRes();
	}
}
