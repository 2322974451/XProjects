using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000714 RID: 1812
	[ProtoContract(Name = "PartyExchangeItemInfo")]
	[Serializable]
	public class PartyExchangeItemInfo : IExtensible
	{
		// Token: 0x17002702 RID: 9986
		// (get) Token: 0x06007B15 RID: 31509 RVA: 0x000EB430 File Offset: 0x000E9630
		// (set) Token: 0x06007B16 RID: 31510 RVA: 0x000EB45D File Offset: 0x000E965D
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

		// Token: 0x17002703 RID: 9987
		// (get) Token: 0x06007B17 RID: 31511 RVA: 0x000EB46C File Offset: 0x000E966C
		// (set) Token: 0x06007B18 RID: 31512 RVA: 0x000EB48C File Offset: 0x000E968C
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

		// Token: 0x06007B19 RID: 31513 RVA: 0x000EB4D0 File Offset: 0x000E96D0
		private bool ShouldSerializerole_id()
		{
			return this.role_idSpecified;
		}

		// Token: 0x06007B1A RID: 31514 RVA: 0x000EB4E8 File Offset: 0x000E96E8
		private void Resetrole_id()
		{
			this.role_idSpecified = false;
		}

		// Token: 0x17002704 RID: 9988
		// (get) Token: 0x06007B1B RID: 31515 RVA: 0x000EB4F4 File Offset: 0x000E96F4
		// (set) Token: 0x06007B1C RID: 31516 RVA: 0x000EB520 File Offset: 0x000E9720
		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x17002705 RID: 9989
		// (get) Token: 0x06007B1D RID: 31517 RVA: 0x000EB530 File Offset: 0x000E9730
		// (set) Token: 0x06007B1E RID: 31518 RVA: 0x000EB550 File Offset: 0x000E9750
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x06007B1F RID: 31519 RVA: 0x000EB594 File Offset: 0x000E9794
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06007B20 RID: 31520 RVA: 0x000EB5AC File Offset: 0x000E97AC
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x17002706 RID: 9990
		// (get) Token: 0x06007B21 RID: 31521 RVA: 0x000EB5B8 File Offset: 0x000E97B8
		// (set) Token: 0x06007B22 RID: 31522 RVA: 0x000EB5E4 File Offset: 0x000E97E4
		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x17002707 RID: 9991
		// (get) Token: 0x06007B23 RID: 31523 RVA: 0x000EB5F4 File Offset: 0x000E97F4
		// (set) Token: 0x06007B24 RID: 31524 RVA: 0x000EB614 File Offset: 0x000E9814
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06007B25 RID: 31525 RVA: 0x000EB658 File Offset: 0x000E9858
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06007B26 RID: 31526 RVA: 0x000EB670 File Offset: 0x000E9870
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17002708 RID: 9992
		// (get) Token: 0x06007B27 RID: 31527 RVA: 0x000EB67C File Offset: 0x000E987C
		// (set) Token: 0x06007B28 RID: 31528 RVA: 0x000EB69D File Offset: 0x000E989D
		[ProtoMember(4, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17002709 RID: 9993
		// (get) Token: 0x06007B29 RID: 31529 RVA: 0x000EB6A8 File Offset: 0x000E98A8
		// (set) Token: 0x06007B2A RID: 31530 RVA: 0x000EB6C4 File Offset: 0x000E98C4
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06007B2B RID: 31531 RVA: 0x000EB6F4 File Offset: 0x000E98F4
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007B2C RID: 31532 RVA: 0x000EB70C File Offset: 0x000E990C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700270A RID: 9994
		// (get) Token: 0x06007B2D RID: 31533 RVA: 0x000EB718 File Offset: 0x000E9918
		// (set) Token: 0x06007B2E RID: 31534 RVA: 0x000EB744 File Offset: 0x000E9944
		[ProtoMember(5, IsRequired = false, Name = "profession_id", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700270B RID: 9995
		// (get) Token: 0x06007B2F RID: 31535 RVA: 0x000EB754 File Offset: 0x000E9954
		// (set) Token: 0x06007B30 RID: 31536 RVA: 0x000EB774 File Offset: 0x000E9974
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

		// Token: 0x06007B31 RID: 31537 RVA: 0x000EB7B8 File Offset: 0x000E99B8
		private bool ShouldSerializeprofession_id()
		{
			return this.profession_idSpecified;
		}

		// Token: 0x06007B32 RID: 31538 RVA: 0x000EB7D0 File Offset: 0x000E99D0
		private void Resetprofession_id()
		{
			this.profession_idSpecified = false;
		}

		// Token: 0x06007B33 RID: 31539 RVA: 0x000EB7DC File Offset: 0x000E99DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D0F RID: 7439
		private ulong? _role_id;

		// Token: 0x04001D10 RID: 7440
		private uint? _time;

		// Token: 0x04001D11 RID: 7441
		private uint? _level;

		// Token: 0x04001D12 RID: 7442
		private string _name;

		// Token: 0x04001D13 RID: 7443
		private uint? _profession_id;

		// Token: 0x04001D14 RID: 7444
		private IExtension extensionObject;
	}
}
