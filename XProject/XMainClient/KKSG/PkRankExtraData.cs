using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200058C RID: 1420
	[ProtoContract(Name = "PkRankExtraData")]
	[Serializable]
	public class PkRankExtraData : IExtensible
	{
		// Token: 0x17001719 RID: 5913
		// (get) Token: 0x06004B17 RID: 19223 RVA: 0x0008EC8C File Offset: 0x0008CE8C
		// (set) Token: 0x06004B18 RID: 19224 RVA: 0x0008ECB8 File Offset: 0x0008CEB8
		[ProtoMember(1, IsRequired = false, Name = "joincount", DataFormat = DataFormat.TwosComplement)]
		public uint joincount
		{
			get
			{
				return this._joincount ?? 0U;
			}
			set
			{
				this._joincount = new uint?(value);
			}
		}

		// Token: 0x1700171A RID: 5914
		// (get) Token: 0x06004B19 RID: 19225 RVA: 0x0008ECC8 File Offset: 0x0008CEC8
		// (set) Token: 0x06004B1A RID: 19226 RVA: 0x0008ECE8 File Offset: 0x0008CEE8
		[XmlIgnore]
		[Browsable(false)]
		public bool joincountSpecified
		{
			get
			{
				return this._joincount != null;
			}
			set
			{
				bool flag = value == (this._joincount == null);
				if (flag)
				{
					this._joincount = (value ? new uint?(this.joincount) : null);
				}
			}
		}

		// Token: 0x06004B1B RID: 19227 RVA: 0x0008ED2C File Offset: 0x0008CF2C
		private bool ShouldSerializejoincount()
		{
			return this.joincountSpecified;
		}

		// Token: 0x06004B1C RID: 19228 RVA: 0x0008ED44 File Offset: 0x0008CF44
		private void Resetjoincount()
		{
			this.joincountSpecified = false;
		}

		// Token: 0x1700171B RID: 5915
		// (get) Token: 0x06004B1D RID: 19229 RVA: 0x0008ED50 File Offset: 0x0008CF50
		// (set) Token: 0x06004B1E RID: 19230 RVA: 0x0008ED80 File Offset: 0x0008CF80
		[ProtoMember(2, IsRequired = false, Name = "winrate", DataFormat = DataFormat.FixedSize)]
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

		// Token: 0x1700171C RID: 5916
		// (get) Token: 0x06004B1F RID: 19231 RVA: 0x0008ED90 File Offset: 0x0008CF90
		// (set) Token: 0x06004B20 RID: 19232 RVA: 0x0008EDB0 File Offset: 0x0008CFB0
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

		// Token: 0x06004B21 RID: 19233 RVA: 0x0008EDF4 File Offset: 0x0008CFF4
		private bool ShouldSerializewinrate()
		{
			return this.winrateSpecified;
		}

		// Token: 0x06004B22 RID: 19234 RVA: 0x0008EE0C File Offset: 0x0008D00C
		private void Resetwinrate()
		{
			this.winrateSpecified = false;
		}

		// Token: 0x1700171D RID: 5917
		// (get) Token: 0x06004B23 RID: 19235 RVA: 0x0008EE18 File Offset: 0x0008D018
		// (set) Token: 0x06004B24 RID: 19236 RVA: 0x0008EE44 File Offset: 0x0008D044
		[ProtoMember(3, IsRequired = false, Name = "continuewin", DataFormat = DataFormat.TwosComplement)]
		public uint continuewin
		{
			get
			{
				return this._continuewin ?? 0U;
			}
			set
			{
				this._continuewin = new uint?(value);
			}
		}

		// Token: 0x1700171E RID: 5918
		// (get) Token: 0x06004B25 RID: 19237 RVA: 0x0008EE54 File Offset: 0x0008D054
		// (set) Token: 0x06004B26 RID: 19238 RVA: 0x0008EE74 File Offset: 0x0008D074
		[XmlIgnore]
		[Browsable(false)]
		public bool continuewinSpecified
		{
			get
			{
				return this._continuewin != null;
			}
			set
			{
				bool flag = value == (this._continuewin == null);
				if (flag)
				{
					this._continuewin = (value ? new uint?(this.continuewin) : null);
				}
			}
		}

		// Token: 0x06004B27 RID: 19239 RVA: 0x0008EEB8 File Offset: 0x0008D0B8
		private bool ShouldSerializecontinuewin()
		{
			return this.continuewinSpecified;
		}

		// Token: 0x06004B28 RID: 19240 RVA: 0x0008EED0 File Offset: 0x0008D0D0
		private void Resetcontinuewin()
		{
			this.continuewinSpecified = false;
		}

		// Token: 0x06004B29 RID: 19241 RVA: 0x0008EEDC File Offset: 0x0008D0DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012AD RID: 4781
		private uint? _joincount;

		// Token: 0x040012AE RID: 4782
		private float? _winrate;

		// Token: 0x040012AF RID: 4783
		private uint? _continuewin;

		// Token: 0x040012B0 RID: 4784
		private IExtension extensionObject;
	}
}
