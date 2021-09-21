using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015D7 RID: 5591
	internal class PtcG2C_BackFlowOpenNtf : Protocol
	{
		// Token: 0x0600EC86 RID: 60550 RVA: 0x00347310 File Offset: 0x00345510
		public override uint GetProtoType()
		{
			return 27749U;
		}

		// Token: 0x0600EC87 RID: 60551 RVA: 0x00347327 File Offset: 0x00345527
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BackFlowOpenNtf>(stream, this.Data);
		}

		// Token: 0x0600EC88 RID: 60552 RVA: 0x00347337 File Offset: 0x00345537
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BackFlowOpenNtf>(stream);
		}

		// Token: 0x0600EC89 RID: 60553 RVA: 0x00347346 File Offset: 0x00345546
		public override void Process()
		{
			Process_PtcG2C_BackFlowOpenNtf.Process(this);
		}

		// Token: 0x040065AF RID: 26031
		public BackFlowOpenNtf Data = new BackFlowOpenNtf();
	}
}
