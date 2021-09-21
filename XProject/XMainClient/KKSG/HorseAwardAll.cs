using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002FE RID: 766
	[ProtoContract(Name = "HorseAwardAll")]
	[Serializable]
	public class HorseAwardAll : IExtensible
	{
		// Token: 0x17000D03 RID: 3331
		// (get) Token: 0x060029F7 RID: 10743 RVA: 0x0005161C File Offset: 0x0004F81C
		[ProtoMember(1, Name = "award", DataFormat = DataFormat.Default)]
		public List<HorseAward> award
		{
			get
			{
				return this._award;
			}
		}

		// Token: 0x060029F8 RID: 10744 RVA: 0x00051634 File Offset: 0x0004F834
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A6C RID: 2668
		private readonly List<HorseAward> _award = new List<HorseAward>();

		// Token: 0x04000A6D RID: 2669
		private IExtension extensionObject;
	}
}
