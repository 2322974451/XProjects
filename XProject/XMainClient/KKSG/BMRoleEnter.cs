using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000720 RID: 1824
	[ProtoContract(Name = "BMRoleEnter")]
	[Serializable]
	public class BMRoleEnter : IExtensible
	{
		// Token: 0x1700279A RID: 10138
		// (get) Token: 0x06007CED RID: 31981 RVA: 0x000EEDEC File Offset: 0x000ECFEC
		// (set) Token: 0x06007CEE RID: 31982 RVA: 0x000EEE19 File Offset: 0x000ED019
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

		// Token: 0x1700279B RID: 10139
		// (get) Token: 0x06007CEF RID: 31983 RVA: 0x000EEE28 File Offset: 0x000ED028
		// (set) Token: 0x06007CF0 RID: 31984 RVA: 0x000EEE48 File Offset: 0x000ED048
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

		// Token: 0x06007CF1 RID: 31985 RVA: 0x000EEE8C File Offset: 0x000ED08C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007CF2 RID: 31986 RVA: 0x000EEEA4 File Offset: 0x000ED0A4
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700279C RID: 10140
		// (get) Token: 0x06007CF3 RID: 31987 RVA: 0x000EEEB0 File Offset: 0x000ED0B0
		// (set) Token: 0x06007CF4 RID: 31988 RVA: 0x000EEED1 File Offset: 0x000ED0D1
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

		// Token: 0x1700279D RID: 10141
		// (get) Token: 0x06007CF5 RID: 31989 RVA: 0x000EEEDC File Offset: 0x000ED0DC
		// (set) Token: 0x06007CF6 RID: 31990 RVA: 0x000EEEF8 File Offset: 0x000ED0F8
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

		// Token: 0x06007CF7 RID: 31991 RVA: 0x000EEF28 File Offset: 0x000ED128
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007CF8 RID: 31992 RVA: 0x000EEF40 File Offset: 0x000ED140
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700279E RID: 10142
		// (get) Token: 0x06007CF9 RID: 31993 RVA: 0x000EEF4C File Offset: 0x000ED14C
		// (set) Token: 0x06007CFA RID: 31994 RVA: 0x000EEF78 File Offset: 0x000ED178
		[ProtoMember(3, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		// Token: 0x1700279F RID: 10143
		// (get) Token: 0x06007CFB RID: 31995 RVA: 0x000EEF88 File Offset: 0x000ED188
		// (set) Token: 0x06007CFC RID: 31996 RVA: 0x000EEFA8 File Offset: 0x000ED1A8
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		// Token: 0x06007CFD RID: 31997 RVA: 0x000EEFEC File Offset: 0x000ED1EC
		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		// Token: 0x06007CFE RID: 31998 RVA: 0x000EF004 File Offset: 0x000ED204
		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		// Token: 0x170027A0 RID: 10144
		// (get) Token: 0x06007CFF RID: 31999 RVA: 0x000EF010 File Offset: 0x000ED210
		// (set) Token: 0x06007D00 RID: 32000 RVA: 0x000EF03C File Offset: 0x000ED23C
		[ProtoMember(4, IsRequired = false, Name = "gsline", DataFormat = DataFormat.TwosComplement)]
		public uint gsline
		{
			get
			{
				return this._gsline ?? 0U;
			}
			set
			{
				this._gsline = new uint?(value);
			}
		}

		// Token: 0x170027A1 RID: 10145
		// (get) Token: 0x06007D01 RID: 32001 RVA: 0x000EF04C File Offset: 0x000ED24C
		// (set) Token: 0x06007D02 RID: 32002 RVA: 0x000EF06C File Offset: 0x000ED26C
		[XmlIgnore]
		[Browsable(false)]
		public bool gslineSpecified
		{
			get
			{
				return this._gsline != null;
			}
			set
			{
				bool flag = value == (this._gsline == null);
				if (flag)
				{
					this._gsline = (value ? new uint?(this.gsline) : null);
				}
			}
		}

		// Token: 0x06007D03 RID: 32003 RVA: 0x000EF0B0 File Offset: 0x000ED2B0
		private bool ShouldSerializegsline()
		{
			return this.gslineSpecified;
		}

		// Token: 0x06007D04 RID: 32004 RVA: 0x000EF0C8 File Offset: 0x000ED2C8
		private void Resetgsline()
		{
			this.gslineSpecified = false;
		}

		// Token: 0x170027A2 RID: 10146
		// (get) Token: 0x06007D05 RID: 32005 RVA: 0x000EF0D4 File Offset: 0x000ED2D4
		// (set) Token: 0x06007D06 RID: 32006 RVA: 0x000EF100 File Offset: 0x000ED300
		[ProtoMember(5, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170027A3 RID: 10147
		// (get) Token: 0x06007D07 RID: 32007 RVA: 0x000EF110 File Offset: 0x000ED310
		// (set) Token: 0x06007D08 RID: 32008 RVA: 0x000EF130 File Offset: 0x000ED330
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

		// Token: 0x06007D09 RID: 32009 RVA: 0x000EF174 File Offset: 0x000ED374
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06007D0A RID: 32010 RVA: 0x000EF18C File Offset: 0x000ED38C
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170027A4 RID: 10148
		// (get) Token: 0x06007D0B RID: 32011 RVA: 0x000EF198 File Offset: 0x000ED398
		// (set) Token: 0x06007D0C RID: 32012 RVA: 0x000EF1C4 File Offset: 0x000ED3C4
		[ProtoMember(6, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170027A5 RID: 10149
		// (get) Token: 0x06007D0D RID: 32013 RVA: 0x000EF1D4 File Offset: 0x000ED3D4
		// (set) Token: 0x06007D0E RID: 32014 RVA: 0x000EF1F4 File Offset: 0x000ED3F4
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

		// Token: 0x06007D0F RID: 32015 RVA: 0x000EF238 File Offset: 0x000ED438
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06007D10 RID: 32016 RVA: 0x000EF250 File Offset: 0x000ED450
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x06007D11 RID: 32017 RVA: 0x000EF25C File Offset: 0x000ED45C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D69 RID: 7529
		private ulong? _roleid;

		// Token: 0x04001D6A RID: 7530
		private string _name;

		// Token: 0x04001D6B RID: 7531
		private uint? _sceneid;

		// Token: 0x04001D6C RID: 7532
		private uint? _gsline;

		// Token: 0x04001D6D RID: 7533
		private uint? _level;

		// Token: 0x04001D6E RID: 7534
		private uint? _score;

		// Token: 0x04001D6F RID: 7535
		private IExtension extensionObject;
	}
}
