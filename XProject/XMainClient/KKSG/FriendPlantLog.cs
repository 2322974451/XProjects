using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006B5 RID: 1717
	[ProtoContract(Name = "FriendPlantLog")]
	[Serializable]
	public class FriendPlantLog : IExtensible
	{
		// Token: 0x170023A3 RID: 9123
		// (get) Token: 0x06007095 RID: 28821 RVA: 0x000D7730 File Offset: 0x000D5930
		// (set) Token: 0x06007096 RID: 28822 RVA: 0x000D775D File Offset: 0x000D595D
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

		// Token: 0x170023A4 RID: 9124
		// (get) Token: 0x06007097 RID: 28823 RVA: 0x000D776C File Offset: 0x000D596C
		// (set) Token: 0x06007098 RID: 28824 RVA: 0x000D778C File Offset: 0x000D598C
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

		// Token: 0x06007099 RID: 28825 RVA: 0x000D77D0 File Offset: 0x000D59D0
		private bool ShouldSerializerole_id()
		{
			return this.role_idSpecified;
		}

		// Token: 0x0600709A RID: 28826 RVA: 0x000D77E8 File Offset: 0x000D59E8
		private void Resetrole_id()
		{
			this.role_idSpecified = false;
		}

		// Token: 0x170023A5 RID: 9125
		// (get) Token: 0x0600709B RID: 28827 RVA: 0x000D77F4 File Offset: 0x000D59F4
		// (set) Token: 0x0600709C RID: 28828 RVA: 0x000D7815 File Offset: 0x000D5A15
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

		// Token: 0x170023A6 RID: 9126
		// (get) Token: 0x0600709D RID: 28829 RVA: 0x000D7820 File Offset: 0x000D5A20
		// (set) Token: 0x0600709E RID: 28830 RVA: 0x000D783C File Offset: 0x000D5A3C
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

		// Token: 0x0600709F RID: 28831 RVA: 0x000D786C File Offset: 0x000D5A6C
		private bool ShouldSerializerole_name()
		{
			return this.role_nameSpecified;
		}

		// Token: 0x060070A0 RID: 28832 RVA: 0x000D7884 File Offset: 0x000D5A84
		private void Resetrole_name()
		{
			this.role_nameSpecified = false;
		}

		// Token: 0x170023A7 RID: 9127
		// (get) Token: 0x060070A1 RID: 28833 RVA: 0x000D7890 File Offset: 0x000D5A90
		// (set) Token: 0x060070A2 RID: 28834 RVA: 0x000D78BC File Offset: 0x000D5ABC
		[ProtoMember(3, IsRequired = false, Name = "profession_id", DataFormat = DataFormat.TwosComplement)]
		public uint profession_id
		{
			get
			{
				return this._profession_id ?? 0U;
			}
			set
			{
				this._profession_id = new uint?(value);
			}
		}

		// Token: 0x170023A8 RID: 9128
		// (get) Token: 0x060070A3 RID: 28835 RVA: 0x000D78CC File Offset: 0x000D5ACC
		// (set) Token: 0x060070A4 RID: 28836 RVA: 0x000D78EC File Offset: 0x000D5AEC
		[XmlIgnore]
		[Browsable(false)]
		public bool profession_idSpecified
		{
			get
			{
				return this._profession_id != null;
			}
			set
			{
				bool flag = value == (this._profession_id == null);
				if (flag)
				{
					this._profession_id = (value ? new uint?(this.profession_id) : null);
				}
			}
		}

		// Token: 0x060070A5 RID: 28837 RVA: 0x000D7930 File Offset: 0x000D5B30
		private bool ShouldSerializeprofession_id()
		{
			return this.profession_idSpecified;
		}

		// Token: 0x060070A6 RID: 28838 RVA: 0x000D7948 File Offset: 0x000D5B48
		private void Resetprofession_id()
		{
			this.profession_idSpecified = false;
		}

		// Token: 0x170023A9 RID: 9129
		// (get) Token: 0x060070A7 RID: 28839 RVA: 0x000D7954 File Offset: 0x000D5B54
		// (set) Token: 0x060070A8 RID: 28840 RVA: 0x000D7980 File Offset: 0x000D5B80
		[ProtoMember(4, IsRequired = false, Name = "exist_sprite", DataFormat = DataFormat.Default)]
		public bool exist_sprite
		{
			get
			{
				return this._exist_sprite ?? false;
			}
			set
			{
				this._exist_sprite = new bool?(value);
			}
		}

		// Token: 0x170023AA RID: 9130
		// (get) Token: 0x060070A9 RID: 28841 RVA: 0x000D7990 File Offset: 0x000D5B90
		// (set) Token: 0x060070AA RID: 28842 RVA: 0x000D79B0 File Offset: 0x000D5BB0
		[XmlIgnore]
		[Browsable(false)]
		public bool exist_spriteSpecified
		{
			get
			{
				return this._exist_sprite != null;
			}
			set
			{
				bool flag = value == (this._exist_sprite == null);
				if (flag)
				{
					this._exist_sprite = (value ? new bool?(this.exist_sprite) : null);
				}
			}
		}

		// Token: 0x060070AB RID: 28843 RVA: 0x000D79F4 File Offset: 0x000D5BF4
		private bool ShouldSerializeexist_sprite()
		{
			return this.exist_spriteSpecified;
		}

		// Token: 0x060070AC RID: 28844 RVA: 0x000D7A0C File Offset: 0x000D5C0C
		private void Resetexist_sprite()
		{
			this.exist_spriteSpecified = false;
		}

		// Token: 0x170023AB RID: 9131
		// (get) Token: 0x060070AD RID: 28845 RVA: 0x000D7A18 File Offset: 0x000D5C18
		// (set) Token: 0x060070AE RID: 28846 RVA: 0x000D7A44 File Offset: 0x000D5C44
		[ProtoMember(5, IsRequired = false, Name = "mature", DataFormat = DataFormat.Default)]
		public bool mature
		{
			get
			{
				return this._mature ?? false;
			}
			set
			{
				this._mature = new bool?(value);
			}
		}

		// Token: 0x170023AC RID: 9132
		// (get) Token: 0x060070AF RID: 28847 RVA: 0x000D7A54 File Offset: 0x000D5C54
		// (set) Token: 0x060070B0 RID: 28848 RVA: 0x000D7A74 File Offset: 0x000D5C74
		[XmlIgnore]
		[Browsable(false)]
		public bool matureSpecified
		{
			get
			{
				return this._mature != null;
			}
			set
			{
				bool flag = value == (this._mature == null);
				if (flag)
				{
					this._mature = (value ? new bool?(this.mature) : null);
				}
			}
		}

		// Token: 0x060070B1 RID: 28849 RVA: 0x000D7AB8 File Offset: 0x000D5CB8
		private bool ShouldSerializemature()
		{
			return this.matureSpecified;
		}

		// Token: 0x060070B2 RID: 28850 RVA: 0x000D7AD0 File Offset: 0x000D5CD0
		private void Resetmature()
		{
			this.matureSpecified = false;
		}

		// Token: 0x170023AD RID: 9133
		// (get) Token: 0x060070B3 RID: 28851 RVA: 0x000D7ADC File Offset: 0x000D5CDC
		// (set) Token: 0x060070B4 RID: 28852 RVA: 0x000D7B08 File Offset: 0x000D5D08
		[ProtoMember(6, IsRequired = false, Name = "abnormal_state", DataFormat = DataFormat.Default)]
		public bool abnormal_state
		{
			get
			{
				return this._abnormal_state ?? false;
			}
			set
			{
				this._abnormal_state = new bool?(value);
			}
		}

		// Token: 0x170023AE RID: 9134
		// (get) Token: 0x060070B5 RID: 28853 RVA: 0x000D7B18 File Offset: 0x000D5D18
		// (set) Token: 0x060070B6 RID: 28854 RVA: 0x000D7B38 File Offset: 0x000D5D38
		[XmlIgnore]
		[Browsable(false)]
		public bool abnormal_stateSpecified
		{
			get
			{
				return this._abnormal_state != null;
			}
			set
			{
				bool flag = value == (this._abnormal_state == null);
				if (flag)
				{
					this._abnormal_state = (value ? new bool?(this.abnormal_state) : null);
				}
			}
		}

		// Token: 0x060070B7 RID: 28855 RVA: 0x000D7B7C File Offset: 0x000D5D7C
		private bool ShouldSerializeabnormal_state()
		{
			return this.abnormal_stateSpecified;
		}

		// Token: 0x060070B8 RID: 28856 RVA: 0x000D7B94 File Offset: 0x000D5D94
		private void Resetabnormal_state()
		{
			this.abnormal_stateSpecified = false;
		}

		// Token: 0x170023AF RID: 9135
		// (get) Token: 0x060070B9 RID: 28857 RVA: 0x000D7BA0 File Offset: 0x000D5DA0
		// (set) Token: 0x060070BA RID: 28858 RVA: 0x000D7BCC File Offset: 0x000D5DCC
		[ProtoMember(7, IsRequired = false, Name = "help_times", DataFormat = DataFormat.TwosComplement)]
		public uint help_times
		{
			get
			{
				return this._help_times ?? 0U;
			}
			set
			{
				this._help_times = new uint?(value);
			}
		}

		// Token: 0x170023B0 RID: 9136
		// (get) Token: 0x060070BB RID: 28859 RVA: 0x000D7BDC File Offset: 0x000D5DDC
		// (set) Token: 0x060070BC RID: 28860 RVA: 0x000D7BFC File Offset: 0x000D5DFC
		[XmlIgnore]
		[Browsable(false)]
		public bool help_timesSpecified
		{
			get
			{
				return this._help_times != null;
			}
			set
			{
				bool flag = value == (this._help_times == null);
				if (flag)
				{
					this._help_times = (value ? new uint?(this.help_times) : null);
				}
			}
		}

		// Token: 0x060070BD RID: 28861 RVA: 0x000D7C40 File Offset: 0x000D5E40
		private bool ShouldSerializehelp_times()
		{
			return this.help_timesSpecified;
		}

		// Token: 0x060070BE RID: 28862 RVA: 0x000D7C58 File Offset: 0x000D5E58
		private void Resethelp_times()
		{
			this.help_timesSpecified = false;
		}

		// Token: 0x060070BF RID: 28863 RVA: 0x000D7C64 File Offset: 0x000D5E64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AE1 RID: 6881
		private ulong? _role_id;

		// Token: 0x04001AE2 RID: 6882
		private string _role_name;

		// Token: 0x04001AE3 RID: 6883
		private uint? _profession_id;

		// Token: 0x04001AE4 RID: 6884
		private bool? _exist_sprite;

		// Token: 0x04001AE5 RID: 6885
		private bool? _mature;

		// Token: 0x04001AE6 RID: 6886
		private bool? _abnormal_state;

		// Token: 0x04001AE7 RID: 6887
		private uint? _help_times;

		// Token: 0x04001AE8 RID: 6888
		private IExtension extensionObject;
	}
}
