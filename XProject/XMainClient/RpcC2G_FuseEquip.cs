using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001605 RID: 5637
	internal class RpcC2G_FuseEquip : Rpc
	{
		// Token: 0x0600ED44 RID: 60740 RVA: 0x003481A4 File Offset: 0x003463A4
		public override uint GetRpcType()
		{
			return 56006U;
		}

		// Token: 0x0600ED45 RID: 60741 RVA: 0x003481BB File Offset: 0x003463BB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FuseEquipArg>(stream, this.oArg);
		}

		// Token: 0x0600ED46 RID: 60742 RVA: 0x003481CB File Offset: 0x003463CB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FuseEquipRes>(stream);
		}

		// Token: 0x0600ED47 RID: 60743 RVA: 0x003481DA File Offset: 0x003463DA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FuseEquip.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED48 RID: 60744 RVA: 0x003481F6 File Offset: 0x003463F6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FuseEquip.OnTimeout(this.oArg);
		}

		// Token: 0x040065D4 RID: 26068
		public FuseEquipArg oArg = new FuseEquipArg();

		// Token: 0x040065D5 RID: 26069
		public FuseEquipRes oRes = null;
	}
}
