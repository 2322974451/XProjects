using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000254 RID: 596
	[ProtoContract(Name = "SkyCityRes")]
	[Serializable]
	public class SkyCityRes : IExtensible
	{
		// Token: 0x17000A66 RID: 2662
		// (get) Token: 0x0600215B RID: 8539 RVA: 0x00041510 File Offset: 0x0003F710
		// (set) Token: 0x0600215C RID: 8540 RVA: 0x00041528 File Offset: 0x0003F728
		[ProtoMember(1, IsRequired = false, Name = "baseinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkyCityAllTeamBaseInfo baseinfo
		{
			get
			{
				return this._baseinfo;
			}
			set
			{
				this._baseinfo = value;
			}
		}

		// Token: 0x17000A67 RID: 2663
		// (get) Token: 0x0600215D RID: 8541 RVA: 0x00041534 File Offset: 0x0003F734
		// (set) Token: 0x0600215E RID: 8542 RVA: 0x0004154C File Offset: 0x0003F74C
		[ProtoMember(2, IsRequired = false, Name = "allinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkyCityAllInfo allinfo
		{
			get
			{
				return this._allinfo;
			}
			set
			{
				this._allinfo = value;
			}
		}

		// Token: 0x0600215F RID: 8543 RVA: 0x00041558 File Offset: 0x0003F758
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400084B RID: 2123
		private SkyCityAllTeamBaseInfo _baseinfo = null;

		// Token: 0x0400084C RID: 2124
		private SkyCityAllInfo _allinfo = null;

		// Token: 0x0400084D RID: 2125
		private IExtension extensionObject;
	}
}
