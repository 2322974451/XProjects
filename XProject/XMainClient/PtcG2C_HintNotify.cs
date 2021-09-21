using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200109E RID: 4254
	internal class PtcG2C_HintNotify : Protocol
	{
		// Token: 0x0600D73A RID: 55098 RVA: 0x003274C4 File Offset: 0x003256C4
		public override uint GetProtoType()
		{
			return 23114U;
		}

		// Token: 0x0600D73B RID: 55099 RVA: 0x003274DB File Offset: 0x003256DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HintNotify>(stream, this.Data);
		}

		// Token: 0x0600D73C RID: 55100 RVA: 0x003274EB File Offset: 0x003256EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HintNotify>(stream);
		}

		// Token: 0x0600D73D RID: 55101 RVA: 0x003274FA File Offset: 0x003256FA
		public override void Process()
		{
			Process_PtcG2C_HintNotify.Process(this);
		}

		// Token: 0x0400619F RID: 24991
		public HintNotify Data = new HintNotify();
	}
}
