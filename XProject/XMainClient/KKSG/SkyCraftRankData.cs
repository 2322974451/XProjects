using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200058D RID: 1421
	[ProtoContract(Name = "SkyCraftRankData")]
	[Serializable]
	public class SkyCraftRankData : IExtensible
	{
		// Token: 0x1700171F RID: 5919
		// (get) Token: 0x06004B2B RID: 19243 RVA: 0x0008EEFC File Offset: 0x0008D0FC
		// (set) Token: 0x06004B2C RID: 19244 RVA: 0x0008EF29 File Offset: 0x0008D129
		[ProtoMember(1, IsRequired = false, Name = "stid", DataFormat = DataFormat.TwosComplement)]
		public ulong stid
		{
			get
			{
				return this._stid ?? 0UL;
			}
			set
			{
				this._stid = new ulong?(value);
			}
		}

		// Token: 0x17001720 RID: 5920
		// (get) Token: 0x06004B2D RID: 19245 RVA: 0x0008EF38 File Offset: 0x0008D138
		// (set) Token: 0x06004B2E RID: 19246 RVA: 0x0008EF58 File Offset: 0x0008D158
		[XmlIgnore]
		[Browsable(false)]
		public bool stidSpecified
		{
			get
			{
				return this._stid != null;
			}
			set
			{
				bool flag = value == (this._stid == null);
				if (flag)
				{
					this._stid = (value ? new ulong?(this.stid) : null);
				}
			}
		}

		// Token: 0x06004B2F RID: 19247 RVA: 0x0008EF9C File Offset: 0x0008D19C
		private bool ShouldSerializestid()
		{
			return this.stidSpecified;
		}

		// Token: 0x06004B30 RID: 19248 RVA: 0x0008EFB4 File Offset: 0x0008D1B4
		private void Resetstid()
		{
			this.stidSpecified = false;
		}

		// Token: 0x17001721 RID: 5921
		// (get) Token: 0x06004B31 RID: 19249 RVA: 0x0008EFC0 File Offset: 0x0008D1C0
		// (set) Token: 0x06004B32 RID: 19250 RVA: 0x0008EFE1 File Offset: 0x0008D1E1
		[ProtoMember(2, IsRequired = false, Name = "teamname", DataFormat = DataFormat.Default)]
		public string teamname
		{
			get
			{
				return this._teamname ?? "";
			}
			set
			{
				this._teamname = value;
			}
		}

		// Token: 0x17001722 RID: 5922
		// (get) Token: 0x06004B33 RID: 19251 RVA: 0x0008EFEC File Offset: 0x0008D1EC
		// (set) Token: 0x06004B34 RID: 19252 RVA: 0x0008F008 File Offset: 0x0008D208
		[XmlIgnore]
		[Browsable(false)]
		public bool teamnameSpecified
		{
			get
			{
				return this._teamname != null;
			}
			set
			{
				bool flag = value == (this._teamname == null);
				if (flag)
				{
					this._teamname = (value ? this.teamname : null);
				}
			}
		}

		// Token: 0x06004B35 RID: 19253 RVA: 0x0008F038 File Offset: 0x0008D238
		private bool ShouldSerializeteamname()
		{
			return this.teamnameSpecified;
		}

		// Token: 0x06004B36 RID: 19254 RVA: 0x0008F050 File Offset: 0x0008D250
		private void Resetteamname()
		{
			this.teamnameSpecified = false;
		}

		// Token: 0x17001723 RID: 5923
		// (get) Token: 0x06004B37 RID: 19255 RVA: 0x0008F05C File Offset: 0x0008D25C
		// (set) Token: 0x06004B38 RID: 19256 RVA: 0x0008F088 File Offset: 0x0008D288
		[ProtoMember(3, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x17001724 RID: 5924
		// (get) Token: 0x06004B39 RID: 19257 RVA: 0x0008F098 File Offset: 0x0008D298
		// (set) Token: 0x06004B3A RID: 19258 RVA: 0x0008F0B8 File Offset: 0x0008D2B8
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x06004B3B RID: 19259 RVA: 0x0008F0FC File Offset: 0x0008D2FC
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06004B3C RID: 19260 RVA: 0x0008F114 File Offset: 0x0008D314
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x17001725 RID: 5925
		// (get) Token: 0x06004B3D RID: 19261 RVA: 0x0008F120 File Offset: 0x0008D320
		// (set) Token: 0x06004B3E RID: 19262 RVA: 0x0008F14C File Offset: 0x0008D34C
		[ProtoMember(4, IsRequired = false, Name = "winnum", DataFormat = DataFormat.TwosComplement)]
		public uint winnum
		{
			get
			{
				return this._winnum ?? 0U;
			}
			set
			{
				this._winnum = new uint?(value);
			}
		}

		// Token: 0x17001726 RID: 5926
		// (get) Token: 0x06004B3F RID: 19263 RVA: 0x0008F15C File Offset: 0x0008D35C
		// (set) Token: 0x06004B40 RID: 19264 RVA: 0x0008F17C File Offset: 0x0008D37C
		[XmlIgnore]
		[Browsable(false)]
		public bool winnumSpecified
		{
			get
			{
				return this._winnum != null;
			}
			set
			{
				bool flag = value == (this._winnum == null);
				if (flag)
				{
					this._winnum = (value ? new uint?(this.winnum) : null);
				}
			}
		}

		// Token: 0x06004B41 RID: 19265 RVA: 0x0008F1C0 File Offset: 0x0008D3C0
		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		// Token: 0x06004B42 RID: 19266 RVA: 0x0008F1D8 File Offset: 0x0008D3D8
		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		// Token: 0x17001727 RID: 5927
		// (get) Token: 0x06004B43 RID: 19267 RVA: 0x0008F1E4 File Offset: 0x0008D3E4
		// (set) Token: 0x06004B44 RID: 19268 RVA: 0x0008F214 File Offset: 0x0008D414
		[ProtoMember(5, IsRequired = false, Name = "winrate", DataFormat = DataFormat.FixedSize)]
		public float winrate
		{
			get
			{
				return this._winrate ?? 0f;
			}
			set
			{
				this._winrate = new float?(value);
			}
		}

		// Token: 0x17001728 RID: 5928
		// (get) Token: 0x06004B45 RID: 19269 RVA: 0x0008F224 File Offset: 0x0008D424
		// (set) Token: 0x06004B46 RID: 19270 RVA: 0x0008F244 File Offset: 0x0008D444
		[XmlIgnore]
		[Browsable(false)]
		public bool winrateSpecified
		{
			get
			{
				return this._winrate != null;
			}
			set
			{
				bool flag = value == (this._winrate == null);
				if (flag)
				{
					this._winrate = (value ? new float?(this.winrate) : null);
				}
			}
		}

		// Token: 0x06004B47 RID: 19271 RVA: 0x0008F288 File Offset: 0x0008D488
		private bool ShouldSerializewinrate()
		{
			return this.winrateSpecified;
		}

		// Token: 0x06004B48 RID: 19272 RVA: 0x0008F2A0 File Offset: 0x0008D4A0
		private void Resetwinrate()
		{
			this.winrateSpecified = false;
		}

		// Token: 0x06004B49 RID: 19273 RVA: 0x0008F2AC File Offset: 0x0008D4AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012B1 RID: 4785
		private ulong? _stid;

		// Token: 0x040012B2 RID: 4786
		private string _teamname;

		// Token: 0x040012B3 RID: 4787
		private uint? _point;

		// Token: 0x040012B4 RID: 4788
		private uint? _winnum;

		// Token: 0x040012B5 RID: 4789
		private float? _winrate;

		// Token: 0x040012B6 RID: 4790
		private IExtension extensionObject;
	}
}
