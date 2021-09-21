using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200006A RID: 106
	[ProtoContract(Name = "FatigueRecoverTimeInfo")]
	[Serializable]
	public class FatigueRecoverTimeInfo : IExtensible
	{
		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x00010358 File Offset: 0x0000E558
		[ProtoMember(1, Name = "fatigueID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> fatigueID
		{
			get
			{
				return this._fatigueID;
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000712 RID: 1810 RVA: 0x00010370 File Offset: 0x0000E570
		[ProtoMember(2, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public List<uint> timeleft
		{
			get
			{
				return this._timeleft;
			}
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00010388 File Offset: 0x0000E588
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001C7 RID: 455
		private readonly List<uint> _fatigueID = new List<uint>();

		// Token: 0x040001C8 RID: 456
		private readonly List<uint> _timeleft = new List<uint>();

		// Token: 0x040001C9 RID: 457
		private IExtension extensionObject;
	}
}
