using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001397 RID: 5015
	internal class PtcM2C_HallIconMNtf : Protocol
	{
		// Token: 0x0600E357 RID: 58199 RVA: 0x0033A3BC File Offset: 0x003385BC
		public override uint GetProtoType()
		{
			return 51500U;
		}

		// Token: 0x0600E358 RID: 58200 RVA: 0x0033A3D3 File Offset: 0x003385D3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HallIconPara>(stream, this.Data);
		}

		// Token: 0x0600E359 RID: 58201 RVA: 0x0033A3E3 File Offset: 0x003385E3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HallIconPara>(stream);
		}

		// Token: 0x0600E35A RID: 58202 RVA: 0x0033A3F2 File Offset: 0x003385F2
		public override void Process()
		{
			Process_PtcM2C_HallIconMNtf.Process(this);
		}

		// Token: 0x040063EA RID: 25578
		public HallIconPara Data = new HallIconPara();
	}
}
