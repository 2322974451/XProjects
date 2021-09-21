using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200026D RID: 621
	[ProtoContract(Name = "SpActivityOffsetDay")]
	[Serializable]
	public class SpActivityOffsetDay : IExtensible
	{
		// Token: 0x17000AC8 RID: 2760
		// (get) Token: 0x060022A9 RID: 8873 RVA: 0x00043BA0 File Offset: 0x00041DA0
		[ProtoMember(1, Name = "actid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> actid
		{
			get
			{
				return this._actid;
			}
		}

		// Token: 0x17000AC9 RID: 2761
		// (get) Token: 0x060022AA RID: 8874 RVA: 0x00043BB8 File Offset: 0x00041DB8
		[ProtoMember(2, Name = "offsetday", DataFormat = DataFormat.TwosComplement)]
		public List<int> offsetday
		{
			get
			{
				return this._offsetday;
			}
		}

		// Token: 0x17000ACA RID: 2762
		// (get) Token: 0x060022AB RID: 8875 RVA: 0x00043BD0 File Offset: 0x00041DD0
		[ProtoMember(3, Name = "offsettime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> offsettime
		{
			get
			{
				return this._offsettime;
			}
		}

		// Token: 0x060022AC RID: 8876 RVA: 0x00043BE8 File Offset: 0x00041DE8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000898 RID: 2200
		private readonly List<uint> _actid = new List<uint>();

		// Token: 0x04000899 RID: 2201
		private readonly List<int> _offsetday = new List<int>();

		// Token: 0x0400089A RID: 2202
		private readonly List<uint> _offsettime = new List<uint>();

		// Token: 0x0400089B RID: 2203
		private IExtension extensionObject;
	}
}
