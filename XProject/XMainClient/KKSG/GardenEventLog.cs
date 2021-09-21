using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006B3 RID: 1715
	[ProtoContract(Name = "GardenEventLog")]
	[Serializable]
	public class GardenEventLog : IExtensible
	{
		// Token: 0x17002391 RID: 9105
		// (get) Token: 0x0600705B RID: 28763 RVA: 0x000D702C File Offset: 0x000D522C
		// (set) Token: 0x0600705C RID: 28764 RVA: 0x000D7059 File Offset: 0x000D5259
		[ProtoMember(1, IsRequired = false, Name = "role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong role_id
		{
			get
			{
				return this._role_id ?? 0UL;
			}
			set
			{
				this._role_id = new ulong?(value);
			}
		}

		// Token: 0x17002392 RID: 9106
		// (get) Token: 0x0600705D RID: 28765 RVA: 0x000D7068 File Offset: 0x000D5268
		// (set) Token: 0x0600705E RID: 28766 RVA: 0x000D7088 File Offset: 0x000D5288
		[XmlIgnore]
		[Browsable(false)]
		public bool role_idSpecified
		{
			get
			{
				return this._role_id != null;
			}
			set
			{
				bool flag = value == (this._role_id == null);
				if (flag)
				{
					this._role_id = (value ? new ulong?(this.role_id) : null);
				}
			}
		}

		// Token: 0x0600705F RID: 28767 RVA: 0x000D70CC File Offset: 0x000D52CC
		private bool ShouldSerializerole_id()
		{
			return this.role_idSpecified;
		}

		// Token: 0x06007060 RID: 28768 RVA: 0x000D70E4 File Offset: 0x000D52E4
		private void Resetrole_id()
		{
			this.role_idSpecified = false;
		}

		// Token: 0x17002393 RID: 9107
		// (get) Token: 0x06007061 RID: 28769 RVA: 0x000D70F0 File Offset: 0x000D52F0
		// (set) Token: 0x06007062 RID: 28770 RVA: 0x000D7111 File Offset: 0x000D5311
		[ProtoMember(2, IsRequired = false, Name = "role_name", DataFormat = DataFormat.Default)]
		public string role_name
		{
			get
			{
				return this._role_name ?? "";
			}
			set
			{
				this._role_name = value;
			}
		}

		// Token: 0x17002394 RID: 9108
		// (get) Token: 0x06007063 RID: 28771 RVA: 0x000D711C File Offset: 0x000D531C
		// (set) Token: 0x06007064 RID: 28772 RVA: 0x000D7138 File Offset: 0x000D5338
		[XmlIgnore]
		[Browsable(false)]
		public bool role_nameSpecified
		{
			get
			{
				return this._role_name != null;
			}
			set
			{
				bool flag = value == (this._role_name == null);
				if (flag)
				{
					this._role_name = (value ? this.role_name : null);
				}
			}
		}

		// Token: 0x06007065 RID: 28773 RVA: 0x000D7168 File Offset: 0x000D5368
		private bool ShouldSerializerole_name()
		{
			return this.role_nameSpecified;
		}

		// Token: 0x06007066 RID: 28774 RVA: 0x000D7180 File Offset: 0x000D5380
		private void Resetrole_name()
		{
			this.role_nameSpecified = false;
		}

		// Token: 0x17002395 RID: 9109
		// (get) Token: 0x06007067 RID: 28775 RVA: 0x000D718C File Offset: 0x000D538C
		// (set) Token: 0x06007068 RID: 28776 RVA: 0x000D71B8 File Offset: 0x000D53B8
		[ProtoMember(3, IsRequired = false, Name = "occur_time", DataFormat = DataFormat.TwosComplement)]
		public uint occur_time
		{
			get
			{
				return this._occur_time ?? 0U;
			}
			set
			{
				this._occur_time = new uint?(value);
			}
		}

		// Token: 0x17002396 RID: 9110
		// (get) Token: 0x06007069 RID: 28777 RVA: 0x000D71C8 File Offset: 0x000D53C8
		// (set) Token: 0x0600706A RID: 28778 RVA: 0x000D71E8 File Offset: 0x000D53E8
		[XmlIgnore]
		[Browsable(false)]
		public bool occur_timeSpecified
		{
			get
			{
				return this._occur_time != null;
			}
			set
			{
				bool flag = value == (this._occur_time == null);
				if (flag)
				{
					this._occur_time = (value ? new uint?(this.occur_time) : null);
				}
			}
		}

		// Token: 0x0600706B RID: 28779 RVA: 0x000D722C File Offset: 0x000D542C
		private bool ShouldSerializeoccur_time()
		{
			return this.occur_timeSpecified;
		}

		// Token: 0x0600706C RID: 28780 RVA: 0x000D7244 File Offset: 0x000D5444
		private void Resetoccur_time()
		{
			this.occur_timeSpecified = false;
		}

		// Token: 0x17002397 RID: 9111
		// (get) Token: 0x0600706D RID: 28781 RVA: 0x000D7250 File Offset: 0x000D5450
		// (set) Token: 0x0600706E RID: 28782 RVA: 0x000D727C File Offset: 0x000D547C
		[ProtoMember(4, IsRequired = false, Name = "event_type", DataFormat = DataFormat.TwosComplement)]
		public uint event_type
		{
			get
			{
				return this._event_type ?? 0U;
			}
			set
			{
				this._event_type = new uint?(value);
			}
		}

		// Token: 0x17002398 RID: 9112
		// (get) Token: 0x0600706F RID: 28783 RVA: 0x000D728C File Offset: 0x000D548C
		// (set) Token: 0x06007070 RID: 28784 RVA: 0x000D72AC File Offset: 0x000D54AC
		[XmlIgnore]
		[Browsable(false)]
		public bool event_typeSpecified
		{
			get
			{
				return this._event_type != null;
			}
			set
			{
				bool flag = value == (this._event_type == null);
				if (flag)
				{
					this._event_type = (value ? new uint?(this.event_type) : null);
				}
			}
		}

		// Token: 0x06007071 RID: 28785 RVA: 0x000D72F0 File Offset: 0x000D54F0
		private bool ShouldSerializeevent_type()
		{
			return this.event_typeSpecified;
		}

		// Token: 0x06007072 RID: 28786 RVA: 0x000D7308 File Offset: 0x000D5508
		private void Resetevent_type()
		{
			this.event_typeSpecified = false;
		}

		// Token: 0x17002399 RID: 9113
		// (get) Token: 0x06007073 RID: 28787 RVA: 0x000D7314 File Offset: 0x000D5514
		// (set) Token: 0x06007074 RID: 28788 RVA: 0x000D7340 File Offset: 0x000D5540
		[ProtoMember(5, IsRequired = false, Name = "target", DataFormat = DataFormat.TwosComplement)]
		public uint target
		{
			get
			{
				return this._target ?? 0U;
			}
			set
			{
				this._target = new uint?(value);
			}
		}

		// Token: 0x1700239A RID: 9114
		// (get) Token: 0x06007075 RID: 28789 RVA: 0x000D7350 File Offset: 0x000D5550
		// (set) Token: 0x06007076 RID: 28790 RVA: 0x000D7370 File Offset: 0x000D5570
		[XmlIgnore]
		[Browsable(false)]
		public bool targetSpecified
		{
			get
			{
				return this._target != null;
			}
			set
			{
				bool flag = value == (this._target == null);
				if (flag)
				{
					this._target = (value ? new uint?(this.target) : null);
				}
			}
		}

		// Token: 0x06007077 RID: 28791 RVA: 0x000D73B4 File Offset: 0x000D55B4
		private bool ShouldSerializetarget()
		{
			return this.targetSpecified;
		}

		// Token: 0x06007078 RID: 28792 RVA: 0x000D73CC File Offset: 0x000D55CC
		private void Resettarget()
		{
			this.targetSpecified = false;
		}

		// Token: 0x1700239B RID: 9115
		// (get) Token: 0x06007079 RID: 28793 RVA: 0x000D73D8 File Offset: 0x000D55D8
		// (set) Token: 0x0600707A RID: 28794 RVA: 0x000D7404 File Offset: 0x000D5604
		[ProtoMember(6, IsRequired = false, Name = "result", DataFormat = DataFormat.Default)]
		public bool result
		{
			get
			{
				return this._result ?? false;
			}
			set
			{
				this._result = new bool?(value);
			}
		}

		// Token: 0x1700239C RID: 9116
		// (get) Token: 0x0600707B RID: 28795 RVA: 0x000D7414 File Offset: 0x000D5614
		// (set) Token: 0x0600707C RID: 28796 RVA: 0x000D7434 File Offset: 0x000D5634
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new bool?(this.result) : null);
				}
			}
		}

		// Token: 0x0600707D RID: 28797 RVA: 0x000D7478 File Offset: 0x000D5678
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600707E RID: 28798 RVA: 0x000D7490 File Offset: 0x000D5690
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600707F RID: 28799 RVA: 0x000D749C File Offset: 0x000D569C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AD6 RID: 6870
		private ulong? _role_id;

		// Token: 0x04001AD7 RID: 6871
		private string _role_name;

		// Token: 0x04001AD8 RID: 6872
		private uint? _occur_time;

		// Token: 0x04001AD9 RID: 6873
		private uint? _event_type;

		// Token: 0x04001ADA RID: 6874
		private uint? _target;

		// Token: 0x04001ADB RID: 6875
		private bool? _result;

		// Token: 0x04001ADC RID: 6876
		private IExtension extensionObject;
	}
}
