using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006BA RID: 1722
	[ProtoContract(Name = "GmfCombat")]
	[Serializable]
	public class GmfCombat : IExtensible
	{
		// Token: 0x170023D8 RID: 9176
		// (get) Token: 0x06007138 RID: 28984 RVA: 0x000D89FC File Offset: 0x000D6BFC
		// (set) Token: 0x06007139 RID: 28985 RVA: 0x000D8A28 File Offset: 0x000D6C28
		[ProtoMember(1, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public uint killcount
		{
			get
			{
				return this._killcount ?? 0U;
			}
			set
			{
				this._killcount = new uint?(value);
			}
		}

		// Token: 0x170023D9 RID: 9177
		// (get) Token: 0x0600713A RID: 28986 RVA: 0x000D8A38 File Offset: 0x000D6C38
		// (set) Token: 0x0600713B RID: 28987 RVA: 0x000D8A58 File Offset: 0x000D6C58
		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new uint?(this.killcount) : null);
				}
			}
		}

		// Token: 0x0600713C RID: 28988 RVA: 0x000D8A9C File Offset: 0x000D6C9C
		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		// Token: 0x0600713D RID: 28989 RVA: 0x000D8AB4 File Offset: 0x000D6CB4
		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		// Token: 0x170023DA RID: 9178
		// (get) Token: 0x0600713E RID: 28990 RVA: 0x000D8AC0 File Offset: 0x000D6CC0
		// (set) Token: 0x0600713F RID: 28991 RVA: 0x000D8AF4 File Offset: 0x000D6CF4
		[ProtoMember(2, IsRequired = false, Name = "damage", DataFormat = DataFormat.TwosComplement)]
		public double damage
		{
			get
			{
				return this._damage ?? 0.0;
			}
			set
			{
				this._damage = new double?(value);
			}
		}

		// Token: 0x170023DB RID: 9179
		// (get) Token: 0x06007140 RID: 28992 RVA: 0x000D8B04 File Offset: 0x000D6D04
		// (set) Token: 0x06007141 RID: 28993 RVA: 0x000D8B24 File Offset: 0x000D6D24
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
					this._damage = (value ? new double?(this.damage) : null);
				}
			}
		}

		// Token: 0x06007142 RID: 28994 RVA: 0x000D8B68 File Offset: 0x000D6D68
		private bool ShouldSerializedamage()
		{
			return this.damageSpecified;
		}

		// Token: 0x06007143 RID: 28995 RVA: 0x000D8B80 File Offset: 0x000D6D80
		private void Resetdamage()
		{
			this.damageSpecified = false;
		}

		// Token: 0x170023DC RID: 9180
		// (get) Token: 0x06007144 RID: 28996 RVA: 0x000D8B8C File Offset: 0x000D6D8C
		// (set) Token: 0x06007145 RID: 28997 RVA: 0x000D8BB8 File Offset: 0x000D6DB8
		[ProtoMember(3, IsRequired = false, Name = "deadcount", DataFormat = DataFormat.TwosComplement)]
		public uint deadcount
		{
			get
			{
				return this._deadcount ?? 0U;
			}
			set
			{
				this._deadcount = new uint?(value);
			}
		}

		// Token: 0x170023DD RID: 9181
		// (get) Token: 0x06007146 RID: 28998 RVA: 0x000D8BC8 File Offset: 0x000D6DC8
		// (set) Token: 0x06007147 RID: 28999 RVA: 0x000D8BE8 File Offset: 0x000D6DE8
		[XmlIgnore]
		[Browsable(false)]
		public bool deadcountSpecified
		{
			get
			{
				return this._deadcount != null;
			}
			set
			{
				bool flag = value == (this._deadcount == null);
				if (flag)
				{
					this._deadcount = (value ? new uint?(this.deadcount) : null);
				}
			}
		}

		// Token: 0x06007148 RID: 29000 RVA: 0x000D8C2C File Offset: 0x000D6E2C
		private bool ShouldSerializedeadcount()
		{
			return this.deadcountSpecified;
		}

		// Token: 0x06007149 RID: 29001 RVA: 0x000D8C44 File Offset: 0x000D6E44
		private void Resetdeadcount()
		{
			this.deadcountSpecified = false;
		}

		// Token: 0x0600714A RID: 29002 RVA: 0x000D8C50 File Offset: 0x000D6E50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B03 RID: 6915
		private uint? _killcount;

		// Token: 0x04001B04 RID: 6916
		private double? _damage;

		// Token: 0x04001B05 RID: 6917
		private uint? _deadcount;

		// Token: 0x04001B06 RID: 6918
		private IExtension extensionObject;
	}
}
