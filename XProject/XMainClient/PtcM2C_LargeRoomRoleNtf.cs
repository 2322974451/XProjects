using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013B5 RID: 5045
	internal class PtcM2C_LargeRoomRoleNtf : Protocol
	{
		// Token: 0x0600E3D3 RID: 58323 RVA: 0x0033AE2C File Offset: 0x0033902C
		public override uint GetProtoType()
		{
			return 36333U;
		}

		// Token: 0x0600E3D4 RID: 58324 RVA: 0x0033AE43 File Offset: 0x00339043
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LargeRoomRoleParam>(stream, this.Data);
		}

		// Token: 0x0600E3D5 RID: 58325 RVA: 0x0033AE53 File Offset: 0x00339053
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LargeRoomRoleParam>(stream);
		}

		// Token: 0x0600E3D6 RID: 58326 RVA: 0x0033AE62 File Offset: 0x00339062
		public override void Process()
		{
			Process_PtcM2C_LargeRoomRoleNtf.Process(this);
		}

		// Token: 0x04006402 RID: 25602
		public LargeRoomRoleParam Data = new LargeRoomRoleParam();
	}
}
