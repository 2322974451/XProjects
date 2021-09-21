using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200006C RID: 108
	[ProtoContract(Name = "EnterSceneCoolDownNotify")]
	[Serializable]
	public class EnterSceneCoolDownNotify : IExtensible
	{
		// Token: 0x1700024E RID: 590
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x000104D8 File Offset: 0x0000E6D8
		[ProtoMember(1, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> groupid
		{
			get
			{
				return this._groupid;
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x000104F0 File Offset: 0x0000E6F0
		[ProtoMember(2, Name = "cooldown", DataFormat = DataFormat.TwosComplement)]
		public List<uint> cooldown
		{
			get
			{
				return this._cooldown;
			}
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x00010508 File Offset: 0x0000E708
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001CD RID: 461
		private readonly List<uint> _groupid = new List<uint>();

		// Token: 0x040001CE RID: 462
		private readonly List<uint> _cooldown = new List<uint>();

		// Token: 0x040001CF RID: 463
		private IExtension extensionObject;
	}
}
