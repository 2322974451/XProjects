using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000029 RID: 41
	[ProtoContract(Name = "BingSkillArg")]
	[Serializable]
	public class BingSkillArg : IExtensible
	{
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00008344 File Offset: 0x00006544
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x00008370 File Offset: 0x00006570
		[ProtoMember(1, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public int slot
		{
			get
			{
				return this._slot ?? 0;
			}
			set
			{
				this._slot = new int?(value);
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x00008380 File Offset: 0x00006580
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x000083A0 File Offset: 0x000065A0
		[XmlIgnore]
		[Browsable(false)]
		public bool slotSpecified
		{
			get
			{
				return this._slot != null;
			}
			set
			{
				bool flag = value == (this._slot == null);
				if (flag)
				{
					this._slot = (value ? new int?(this.slot) : null);
				}
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x000083E4 File Offset: 0x000065E4
		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x000083FC File Offset: 0x000065FC
		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x00008408 File Offset: 0x00006608
		// (set) Token: 0x060002E7 RID: 743 RVA: 0x00008434 File Offset: 0x00006634
		[ProtoMember(2, IsRequired = false, Name = "skillhash", DataFormat = DataFormat.TwosComplement)]
		public uint skillhash
		{
			get
			{
				return this._skillhash ?? 0U;
			}
			set
			{
				this._skillhash = new uint?(value);
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x00008444 File Offset: 0x00006644
		// (set) Token: 0x060002E9 RID: 745 RVA: 0x00008464 File Offset: 0x00006664
		[XmlIgnore]
		[Browsable(false)]
		public bool skillhashSpecified
		{
			get
			{
				return this._skillhash != null;
			}
			set
			{
				bool flag = value == (this._skillhash == null);
				if (flag)
				{
					this._skillhash = (value ? new uint?(this.skillhash) : null);
				}
			}
		}

		// Token: 0x060002EA RID: 746 RVA: 0x000084A8 File Offset: 0x000066A8
		private bool ShouldSerializeskillhash()
		{
			return this.skillhashSpecified;
		}

		// Token: 0x060002EB RID: 747 RVA: 0x000084C0 File Offset: 0x000066C0
		private void Resetskillhash()
		{
			this.skillhashSpecified = false;
		}

		// Token: 0x060002EC RID: 748 RVA: 0x000084CC File Offset: 0x000066CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000C4 RID: 196
		private int? _slot;

		// Token: 0x040000C5 RID: 197
		private uint? _skillhash;

		// Token: 0x040000C6 RID: 198
		private IExtension extensionObject;
	}
}
