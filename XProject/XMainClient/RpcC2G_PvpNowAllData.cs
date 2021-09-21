using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001139 RID: 4409
	internal class RpcC2G_PvpNowAllData : Rpc
	{
		// Token: 0x0600D9AB RID: 55723 RVA: 0x0032B6F4 File Offset: 0x003298F4
		public override uint GetRpcType()
		{
			return 58355U;
		}

		// Token: 0x0600D9AC RID: 55724 RVA: 0x0032B70B File Offset: 0x0032990B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<roArg>(stream, this.oArg);
		}

		// Token: 0x0600D9AD RID: 55725 RVA: 0x0032B71B File Offset: 0x0032991B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PvpNowGameData>(stream);
		}

		// Token: 0x0600D9AE RID: 55726 RVA: 0x0032B72A File Offset: 0x0032992A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PvpNowAllData.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D9AF RID: 55727 RVA: 0x0032B746 File Offset: 0x00329946
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PvpNowAllData.OnTimeout(this.oArg);
		}

		// Token: 0x04006210 RID: 25104
		public roArg oArg = new roArg();

		// Token: 0x04006211 RID: 25105
		public PvpNowGameData oRes = new PvpNowGameData();
	}
}
