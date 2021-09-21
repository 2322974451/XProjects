using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000C1 RID: 193
	[ProtoContract(Name = "GuildBestCardsNtf")]
	[Serializable]
	public class GuildBestCardsNtf : IExtensible
	{
		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06000CE2 RID: 3298 RVA: 0x0001B13C File Offset: 0x0001933C
		// (set) Token: 0x06000CE3 RID: 3299 RVA: 0x0001B168 File Offset: 0x00019368
		[ProtoMember(1, IsRequired = false, Name = "bestresult", DataFormat = DataFormat.TwosComplement)]
		public uint bestresult
		{
			get
			{
				return this._bestresult ?? 0U;
			}
			set
			{
				this._bestresult = new uint?(value);
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06000CE4 RID: 3300 RVA: 0x0001B178 File Offset: 0x00019378
		// (set) Token: 0x06000CE5 RID: 3301 RVA: 0x0001B198 File Offset: 0x00019398
		[XmlIgnore]
		[Browsable(false)]
		public bool bestresultSpecified
		{
			get
			{
				return this._bestresult != null;
			}
			set
			{
				bool flag = value == (this._bestresult == null);
				if (flag)
				{
					this._bestresult = (value ? new uint?(this.bestresult) : null);
				}
			}
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x0001B1DC File Offset: 0x000193DC
		private bool ShouldSerializebestresult()
		{
			return this.bestresultSpecified;
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x0001B1F4 File Offset: 0x000193F4
		private void Resetbestresult()
		{
			this.bestresultSpecified = false;
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06000CE8 RID: 3304 RVA: 0x0001B200 File Offset: 0x00019400
		[ProtoMember(2, Name = "bestcards", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bestcards
		{
			get
			{
				return this._bestcards;
			}
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x0001B218 File Offset: 0x00019418
		// (set) Token: 0x06000CEA RID: 3306 RVA: 0x0001B239 File Offset: 0x00019439
		[ProtoMember(3, IsRequired = false, Name = "bestrole", DataFormat = DataFormat.Default)]
		public string bestrole
		{
			get
			{
				return this._bestrole ?? "";
			}
			set
			{
				this._bestrole = value;
			}
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06000CEB RID: 3307 RVA: 0x0001B244 File Offset: 0x00019444
		// (set) Token: 0x06000CEC RID: 3308 RVA: 0x0001B260 File Offset: 0x00019460
		[XmlIgnore]
		[Browsable(false)]
		public bool bestroleSpecified
		{
			get
			{
				return this._bestrole != null;
			}
			set
			{
				bool flag = value == (this._bestrole == null);
				if (flag)
				{
					this._bestrole = (value ? this.bestrole : null);
				}
			}
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x0001B290 File Offset: 0x00019490
		private bool ShouldSerializebestrole()
		{
			return this.bestroleSpecified;
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x0001B2A8 File Offset: 0x000194A8
		private void Resetbestrole()
		{
			this.bestroleSpecified = false;
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06000CEF RID: 3311 RVA: 0x0001B2B4 File Offset: 0x000194B4
		// (set) Token: 0x06000CF0 RID: 3312 RVA: 0x0001B2E0 File Offset: 0x000194E0
		[ProtoMember(4, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06000CF1 RID: 3313 RVA: 0x0001B2F0 File Offset: 0x000194F0
		// (set) Token: 0x06000CF2 RID: 3314 RVA: 0x0001B310 File Offset: 0x00019510
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x0001B354 File Offset: 0x00019554
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x0001B36C File Offset: 0x0001956C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06000CF5 RID: 3317 RVA: 0x0001B378 File Offset: 0x00019578
		// (set) Token: 0x06000CF6 RID: 3318 RVA: 0x0001B3A4 File Offset: 0x000195A4
		[ProtoMember(5, IsRequired = false, Name = "match_type", DataFormat = DataFormat.TwosComplement)]
		public uint match_type
		{
			get
			{
				return this._match_type ?? 0U;
			}
			set
			{
				this._match_type = new uint?(value);
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x0001B3B4 File Offset: 0x000195B4
		// (set) Token: 0x06000CF8 RID: 3320 RVA: 0x0001B3D4 File Offset: 0x000195D4
		[XmlIgnore]
		[Browsable(false)]
		public bool match_typeSpecified
		{
			get
			{
				return this._match_type != null;
			}
			set
			{
				bool flag = value == (this._match_type == null);
				if (flag)
				{
					this._match_type = (value ? new uint?(this.match_type) : null);
				}
			}
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x0001B418 File Offset: 0x00019618
		private bool ShouldSerializematch_type()
		{
			return this.match_typeSpecified;
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x0001B430 File Offset: 0x00019630
		private void Resetmatch_type()
		{
			this.match_typeSpecified = false;
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x0001B43C File Offset: 0x0001963C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000339 RID: 825
		private uint? _bestresult;

		// Token: 0x0400033A RID: 826
		private readonly List<uint> _bestcards = new List<uint>();

		// Token: 0x0400033B RID: 827
		private string _bestrole;

		// Token: 0x0400033C RID: 828
		private uint? _type;

		// Token: 0x0400033D RID: 829
		private uint? _match_type;

		// Token: 0x0400033E RID: 830
		private IExtension extensionObject;
	}
}
