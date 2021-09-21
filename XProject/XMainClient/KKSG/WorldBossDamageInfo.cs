using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006A8 RID: 1704
	[ProtoContract(Name = "WorldBossDamageInfo")]
	[Serializable]
	public class WorldBossDamageInfo : IExtensible
	{
		// Token: 0x1700232F RID: 9007
		// (get) Token: 0x06006F24 RID: 28452 RVA: 0x000D4AC8 File Offset: 0x000D2CC8
		// (set) Token: 0x06006F25 RID: 28453 RVA: 0x000D4AE9 File Offset: 0x000D2CE9
		[ProtoMember(1, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x17002330 RID: 9008
		// (get) Token: 0x06006F26 RID: 28454 RVA: 0x000D4AF4 File Offset: 0x000D2CF4
		// (set) Token: 0x06006F27 RID: 28455 RVA: 0x000D4B10 File Offset: 0x000D2D10
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x06006F28 RID: 28456 RVA: 0x000D4B40 File Offset: 0x000D2D40
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06006F29 RID: 28457 RVA: 0x000D4B58 File Offset: 0x000D2D58
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x17002331 RID: 9009
		// (get) Token: 0x06006F2A RID: 28458 RVA: 0x000D4B64 File Offset: 0x000D2D64
		// (set) Token: 0x06006F2B RID: 28459 RVA: 0x000D4B94 File Offset: 0x000D2D94
		[ProtoMember(2, IsRequired = false, Name = "damage", DataFormat = DataFormat.FixedSize)]
		public float damage
		{
			get
			{
				return this._damage ?? 0f;
			}
			set
			{
				this._damage = new float?(value);
			}
		}

		// Token: 0x17002332 RID: 9010
		// (get) Token: 0x06006F2C RID: 28460 RVA: 0x000D4BA4 File Offset: 0x000D2DA4
		// (set) Token: 0x06006F2D RID: 28461 RVA: 0x000D4BC4 File Offset: 0x000D2DC4
		[XmlIgnore]
		[Browsable(false)]
		public bool damageSpecified
		{
			get
			{
				return this._damage != null;
			}
			set
			{
				bool flag = value == (this._damage == null);
				if (flag)
				{
					this._damage = (value ? new float?(this.damage) : null);
				}
			}
		}

		// Token: 0x06006F2E RID: 28462 RVA: 0x000D4C08 File Offset: 0x000D2E08
		private bool ShouldSerializedamage()
		{
			return this.damageSpecified;
		}

		// Token: 0x06006F2F RID: 28463 RVA: 0x000D4C20 File Offset: 0x000D2E20
		private void Resetdamage()
		{
			this.damageSpecified = false;
		}

		// Token: 0x17002333 RID: 9011
		// (get) Token: 0x06006F30 RID: 28464 RVA: 0x000D4C2C File Offset: 0x000D2E2C
		// (set) Token: 0x06006F31 RID: 28465 RVA: 0x000D4C58 File Offset: 0x000D2E58
		[ProtoMember(3, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x17002334 RID: 9012
		// (get) Token: 0x06006F32 RID: 28466 RVA: 0x000D4C68 File Offset: 0x000D2E68
		// (set) Token: 0x06006F33 RID: 28467 RVA: 0x000D4C88 File Offset: 0x000D2E88
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x06006F34 RID: 28468 RVA: 0x000D4CCC File Offset: 0x000D2ECC
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06006F35 RID: 28469 RVA: 0x000D4CE4 File Offset: 0x000D2EE4
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x06006F36 RID: 28470 RVA: 0x000D4CF0 File Offset: 0x000D2EF0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A98 RID: 6808
		private string _rolename;

		// Token: 0x04001A99 RID: 6809
		private float? _damage;

		// Token: 0x04001A9A RID: 6810
		private uint? _rank;

		// Token: 0x04001A9B RID: 6811
		private IExtension extensionObject;
	}
}
