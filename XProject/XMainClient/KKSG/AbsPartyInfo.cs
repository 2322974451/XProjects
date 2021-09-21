using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003FB RID: 1019
	[ProtoContract(Name = "AbsPartyInfo")]
	[Serializable]
	public class AbsPartyInfo : IExtensible
	{
		// Token: 0x17001096 RID: 4246
		// (get) Token: 0x060035F5 RID: 13813 RVA: 0x000675CC File Offset: 0x000657CC
		[ProtoMember(1, Name = "aby", DataFormat = DataFormat.Default)]
		public List<AbsPartyBase> aby
		{
			get
			{
				return this._aby;
			}
		}

		// Token: 0x17001097 RID: 4247
		// (get) Token: 0x060035F6 RID: 13814 RVA: 0x000675E4 File Offset: 0x000657E4
		// (set) Token: 0x060035F7 RID: 13815 RVA: 0x00067610 File Offset: 0x00065810
		[ProtoMember(2, IsRequired = false, Name = "abyssmailtime", DataFormat = DataFormat.TwosComplement)]
		public uint abyssmailtime
		{
			get
			{
				return this._abyssmailtime ?? 0U;
			}
			set
			{
				this._abyssmailtime = new uint?(value);
			}
		}

		// Token: 0x17001098 RID: 4248
		// (get) Token: 0x060035F8 RID: 13816 RVA: 0x00067620 File Offset: 0x00065820
		// (set) Token: 0x060035F9 RID: 13817 RVA: 0x00067640 File Offset: 0x00065840
		[XmlIgnore]
		[Browsable(false)]
		public bool abyssmailtimeSpecified
		{
			get
			{
				return this._abyssmailtime != null;
			}
			set
			{
				bool flag = value == (this._abyssmailtime == null);
				if (flag)
				{
					this._abyssmailtime = (value ? new uint?(this.abyssmailtime) : null);
				}
			}
		}

		// Token: 0x060035FA RID: 13818 RVA: 0x00067684 File Offset: 0x00065884
		private bool ShouldSerializeabyssmailtime()
		{
			return this.abyssmailtimeSpecified;
		}

		// Token: 0x060035FB RID: 13819 RVA: 0x0006769C File Offset: 0x0006589C
		private void Resetabyssmailtime()
		{
			this.abyssmailtimeSpecified = false;
		}

		// Token: 0x060035FC RID: 13820 RVA: 0x000676A8 File Offset: 0x000658A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D68 RID: 3432
		private readonly List<AbsPartyBase> _aby = new List<AbsPartyBase>();

		// Token: 0x04000D69 RID: 3433
		private uint? _abyssmailtime;

		// Token: 0x04000D6A RID: 3434
		private IExtension extensionObject;
	}
}
