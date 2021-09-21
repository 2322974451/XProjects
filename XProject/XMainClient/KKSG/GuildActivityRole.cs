using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006B6 RID: 1718
	[ProtoContract(Name = "GuildActivityRole")]
	[Serializable]
	public class GuildActivityRole : IExtensible
	{
		// Token: 0x170023B1 RID: 9137
		// (get) Token: 0x060070C1 RID: 28865 RVA: 0x000D7C84 File Offset: 0x000D5E84
		// (set) Token: 0x060070C2 RID: 28866 RVA: 0x000D7CB1 File Offset: 0x000D5EB1
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x170023B2 RID: 9138
		// (get) Token: 0x060070C3 RID: 28867 RVA: 0x000D7CC0 File Offset: 0x000D5EC0
		// (set) Token: 0x060070C4 RID: 28868 RVA: 0x000D7CE0 File Offset: 0x000D5EE0
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x060070C5 RID: 28869 RVA: 0x000D7D24 File Offset: 0x000D5F24
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x060070C6 RID: 28870 RVA: 0x000D7D3C File Offset: 0x000D5F3C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170023B3 RID: 9139
		// (get) Token: 0x060070C7 RID: 28871 RVA: 0x000D7D48 File Offset: 0x000D5F48
		// (set) Token: 0x060070C8 RID: 28872 RVA: 0x000D7D69 File Offset: 0x000D5F69
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x170023B4 RID: 9140
		// (get) Token: 0x060070C9 RID: 28873 RVA: 0x000D7D74 File Offset: 0x000D5F74
		// (set) Token: 0x060070CA RID: 28874 RVA: 0x000D7D90 File Offset: 0x000D5F90
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

		// Token: 0x060070CB RID: 28875 RVA: 0x000D7DC0 File Offset: 0x000D5FC0
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060070CC RID: 28876 RVA: 0x000D7DD8 File Offset: 0x000D5FD8
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170023B5 RID: 9141
		// (get) Token: 0x060070CD RID: 28877 RVA: 0x000D7DE4 File Offset: 0x000D5FE4
		// (set) Token: 0x060070CE RID: 28878 RVA: 0x000D7E10 File Offset: 0x000D6010
		[ProtoMember(3, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x170023B6 RID: 9142
		// (get) Token: 0x060070CF RID: 28879 RVA: 0x000D7E20 File Offset: 0x000D6020
		// (set) Token: 0x060070D0 RID: 28880 RVA: 0x000D7E40 File Offset: 0x000D6040
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x060070D1 RID: 28881 RVA: 0x000D7E84 File Offset: 0x000D6084
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x060070D2 RID: 28882 RVA: 0x000D7E9C File Offset: 0x000D609C
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x060070D3 RID: 28883 RVA: 0x000D7EA8 File Offset: 0x000D60A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AE9 RID: 6889
		private ulong? _roleid;

		// Token: 0x04001AEA RID: 6890
		private string _name;

		// Token: 0x04001AEB RID: 6891
		private uint? _score;

		// Token: 0x04001AEC RID: 6892
		private IExtension extensionObject;
	}
}
