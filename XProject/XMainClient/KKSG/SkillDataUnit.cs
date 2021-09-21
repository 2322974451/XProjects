using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000012 RID: 18
	[ProtoContract(Name = "SkillDataUnit")]
	[Serializable]
	public class SkillDataUnit : IExtensible
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600015F RID: 351 RVA: 0x0000547C File Offset: 0x0000367C
		// (set) Token: 0x06000160 RID: 352 RVA: 0x000054A8 File Offset: 0x000036A8
		[ProtoMember(1, IsRequired = false, Name = "SkillID", DataFormat = DataFormat.TwosComplement)]
		public uint SkillID
		{
			get
			{
				return this._SkillID ?? 0U;
			}
			set
			{
				this._SkillID = new uint?(value);
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000161 RID: 353 RVA: 0x000054B8 File Offset: 0x000036B8
		// (set) Token: 0x06000162 RID: 354 RVA: 0x000054D8 File Offset: 0x000036D8
		[XmlIgnore]
		[Browsable(false)]
		public bool SkillIDSpecified
		{
			get
			{
				return this._SkillID != null;
			}
			set
			{
				bool flag = value == (this._SkillID == null);
				if (flag)
				{
					this._SkillID = (value ? new uint?(this.SkillID) : null);
				}
			}
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000551C File Offset: 0x0000371C
		private bool ShouldSerializeSkillID()
		{
			return this.SkillIDSpecified;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00005534 File Offset: 0x00003734
		private void ResetSkillID()
		{
			this.SkillIDSpecified = false;
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00005540 File Offset: 0x00003740
		// (set) Token: 0x06000166 RID: 358 RVA: 0x0000556D File Offset: 0x0000376D
		[ProtoMember(2, IsRequired = false, Name = "Target", DataFormat = DataFormat.TwosComplement)]
		public ulong Target
		{
			get
			{
				return this._Target ?? 0UL;
			}
			set
			{
				this._Target = new ulong?(value);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000167 RID: 359 RVA: 0x0000557C File Offset: 0x0000377C
		// (set) Token: 0x06000168 RID: 360 RVA: 0x0000559C File Offset: 0x0000379C
		[XmlIgnore]
		[Browsable(false)]
		public bool TargetSpecified
		{
			get
			{
				return this._Target != null;
			}
			set
			{
				bool flag = value == (this._Target == null);
				if (flag)
				{
					this._Target = (value ? new ulong?(this.Target) : null);
				}
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000055E0 File Offset: 0x000037E0
		private bool ShouldSerializeTarget()
		{
			return this.TargetSpecified;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000055F8 File Offset: 0x000037F8
		private void ResetTarget()
		{
			this.TargetSpecified = false;
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00005604 File Offset: 0x00003804
		// (set) Token: 0x0600016C RID: 364 RVA: 0x00005630 File Offset: 0x00003830
		[ProtoMember(3, IsRequired = false, Name = "ManualFace", DataFormat = DataFormat.TwosComplement)]
		public int ManualFace
		{
			get
			{
				return this._ManualFace ?? 0;
			}
			set
			{
				this._ManualFace = new int?(value);
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00005640 File Offset: 0x00003840
		// (set) Token: 0x0600016E RID: 366 RVA: 0x00005660 File Offset: 0x00003860
		[XmlIgnore]
		[Browsable(false)]
		public bool ManualFaceSpecified
		{
			get
			{
				return this._ManualFace != null;
			}
			set
			{
				bool flag = value == (this._ManualFace == null);
				if (flag)
				{
					this._ManualFace = (value ? new int?(this.ManualFace) : null);
				}
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000056A4 File Offset: 0x000038A4
		private bool ShouldSerializeManualFace()
		{
			return this.ManualFaceSpecified;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000056BC File Offset: 0x000038BC
		private void ResetManualFace()
		{
			this.ManualFaceSpecified = false;
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000171 RID: 369 RVA: 0x000056C8 File Offset: 0x000038C8
		// (set) Token: 0x06000172 RID: 370 RVA: 0x000056F4 File Offset: 0x000038F4
		[ProtoMember(4, IsRequired = false, Name = "Slot", DataFormat = DataFormat.TwosComplement)]
		public int Slot
		{
			get
			{
				return this._Slot ?? 0;
			}
			set
			{
				this._Slot = new int?(value);
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000173 RID: 371 RVA: 0x00005704 File Offset: 0x00003904
		// (set) Token: 0x06000174 RID: 372 RVA: 0x00005724 File Offset: 0x00003924
		[XmlIgnore]
		[Browsable(false)]
		public bool SlotSpecified
		{
			get
			{
				return this._Slot != null;
			}
			set
			{
				bool flag = value == (this._Slot == null);
				if (flag)
				{
					this._Slot = (value ? new int?(this.Slot) : null);
				}
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00005768 File Offset: 0x00003968
		private bool ShouldSerializeSlot()
		{
			return this.SlotSpecified;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00005780 File Offset: 0x00003980
		private void ResetSlot()
		{
			this.SlotSpecified = false;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000578C File Offset: 0x0000398C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400005E RID: 94
		private uint? _SkillID;

		// Token: 0x0400005F RID: 95
		private ulong? _Target;

		// Token: 0x04000060 RID: 96
		private int? _ManualFace;

		// Token: 0x04000061 RID: 97
		private int? _Slot;

		// Token: 0x04000062 RID: 98
		private IExtension extensionObject;
	}
}
