using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001094 RID: 4244
	internal class PtcG2C_OnlineRewardNtf : Protocol
	{
		// Token: 0x0600D710 RID: 55056 RVA: 0x00327190 File Offset: 0x00325390
		public override uint GetProtoType()
		{
			return 1895U;
		}

		// Token: 0x0600D711 RID: 55057 RVA: 0x003271A7 File Offset: 0x003253A7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OnlineRewardNtf>(stream, this.Data);
		}

		// Token: 0x0600D712 RID: 55058 RVA: 0x003271B7 File Offset: 0x003253B7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OnlineRewardNtf>(stream);
		}

		// Token: 0x0600D713 RID: 55059 RVA: 0x003271C6 File Offset: 0x003253C6
		public override void Process()
		{
			Process_PtcG2C_OnlineRewardNtf.Process(this);
		}

		// Token: 0x04006197 RID: 24983
		public OnlineRewardNtf Data = new OnlineRewardNtf();
	}
}
