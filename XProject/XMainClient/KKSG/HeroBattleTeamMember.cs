using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006EA RID: 1770
	[ProtoContract(Name = "HeroBattleTeamMember")]
	[Serializable]
	public class HeroBattleTeamMember : IExtensible
	{
		// Token: 0x17002582 RID: 9602
		// (get) Token: 0x06007677 RID: 30327 RVA: 0x000E2A78 File Offset: 0x000E0C78
		// (set) Token: 0x06007678 RID: 30328 RVA: 0x000E2AA5 File Offset: 0x000E0CA5
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x17002583 RID: 9603
		// (get) Token: 0x06007679 RID: 30329 RVA: 0x000E2AB4 File Offset: 0x000E0CB4
		// (set) Token: 0x0600767A RID: 30330 RVA: 0x000E2AD4 File Offset: 0x000E0CD4
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x0600767B RID: 30331 RVA: 0x000E2B18 File Offset: 0x000E0D18
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x0600767C RID: 30332 RVA: 0x000E2B30 File Offset: 0x000E0D30
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17002584 RID: 9604
		// (get) Token: 0x0600767D RID: 30333 RVA: 0x000E2B3C File Offset: 0x000E0D3C
		// (set) Token: 0x0600767E RID: 30334 RVA: 0x000E2B68 File Offset: 0x000E0D68
		[ProtoMember(2, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		// Token: 0x17002585 RID: 9605
		// (get) Token: 0x0600767F RID: 30335 RVA: 0x000E2B78 File Offset: 0x000E0D78
		// (set) Token: 0x06007680 RID: 30336 RVA: 0x000E2B98 File Offset: 0x000E0D98
		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		// Token: 0x06007681 RID: 30337 RVA: 0x000E2BDC File Offset: 0x000E0DDC
		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		// Token: 0x06007682 RID: 30338 RVA: 0x000E2BF4 File Offset: 0x000E0DF4
		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		// Token: 0x17002586 RID: 9606
		// (get) Token: 0x06007683 RID: 30339 RVA: 0x000E2C00 File Offset: 0x000E0E00
		// (set) Token: 0x06007684 RID: 30340 RVA: 0x000E2C21 File Offset: 0x000E0E21
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17002587 RID: 9607
		// (get) Token: 0x06007685 RID: 30341 RVA: 0x000E2C2C File Offset: 0x000E0E2C
		// (set) Token: 0x06007686 RID: 30342 RVA: 0x000E2C48 File Offset: 0x000E0E48
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

		// Token: 0x06007687 RID: 30343 RVA: 0x000E2C78 File Offset: 0x000E0E78
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007688 RID: 30344 RVA: 0x000E2C90 File Offset: 0x000E0E90
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002588 RID: 9608
		// (get) Token: 0x06007689 RID: 30345 RVA: 0x000E2C9C File Offset: 0x000E0E9C
		// (set) Token: 0x0600768A RID: 30346 RVA: 0x000E2CC8 File Offset: 0x000E0EC8
		[ProtoMember(4, IsRequired = false, Name = "killnum", DataFormat = DataFormat.TwosComplement)]
		public uint killnum
		{
			get
			{
				return this._killnum ?? 0U;
			}
			set
			{
				this._killnum = new uint?(value);
			}
		}

		// Token: 0x17002589 RID: 9609
		// (get) Token: 0x0600768B RID: 30347 RVA: 0x000E2CD8 File Offset: 0x000E0ED8
		// (set) Token: 0x0600768C RID: 30348 RVA: 0x000E2CF8 File Offset: 0x000E0EF8
		[XmlIgnore]
		[Browsable(false)]
		public bool killnumSpecified
		{
			get
			{
				return this._killnum != null;
			}
			set
			{
				bool flag = value == (this._killnum == null);
				if (flag)
				{
					this._killnum = (value ? new uint?(this.killnum) : null);
				}
			}
		}

		// Token: 0x0600768D RID: 30349 RVA: 0x000E2D3C File Offset: 0x000E0F3C
		private bool ShouldSerializekillnum()
		{
			return this.killnumSpecified;
		}

		// Token: 0x0600768E RID: 30350 RVA: 0x000E2D54 File Offset: 0x000E0F54
		private void Resetkillnum()
		{
			this.killnumSpecified = false;
		}

		// Token: 0x1700258A RID: 9610
		// (get) Token: 0x0600768F RID: 30351 RVA: 0x000E2D60 File Offset: 0x000E0F60
		// (set) Token: 0x06007690 RID: 30352 RVA: 0x000E2D8C File Offset: 0x000E0F8C
		[ProtoMember(5, IsRequired = false, Name = "deathnum", DataFormat = DataFormat.TwosComplement)]
		public uint deathnum
		{
			get
			{
				return this._deathnum ?? 0U;
			}
			set
			{
				this._deathnum = new uint?(value);
			}
		}

		// Token: 0x1700258B RID: 9611
		// (get) Token: 0x06007691 RID: 30353 RVA: 0x000E2D9C File Offset: 0x000E0F9C
		// (set) Token: 0x06007692 RID: 30354 RVA: 0x000E2DBC File Offset: 0x000E0FBC
		[XmlIgnore]
		[Browsable(false)]
		public bool deathnumSpecified
		{
			get
			{
				return this._deathnum != null;
			}
			set
			{
				bool flag = value == (this._deathnum == null);
				if (flag)
				{
					this._deathnum = (value ? new uint?(this.deathnum) : null);
				}
			}
		}

		// Token: 0x06007693 RID: 30355 RVA: 0x000E2E00 File Offset: 0x000E1000
		private bool ShouldSerializedeathnum()
		{
			return this.deathnumSpecified;
		}

		// Token: 0x06007694 RID: 30356 RVA: 0x000E2E18 File Offset: 0x000E1018
		private void Resetdeathnum()
		{
			this.deathnumSpecified = false;
		}

		// Token: 0x1700258C RID: 9612
		// (get) Token: 0x06007695 RID: 30357 RVA: 0x000E2E24 File Offset: 0x000E1024
		// (set) Token: 0x06007696 RID: 30358 RVA: 0x000E2E50 File Offset: 0x000E1050
		[ProtoMember(6, IsRequired = false, Name = "assitnum", DataFormat = DataFormat.TwosComplement)]
		public uint assitnum
		{
			get
			{
				return this._assitnum ?? 0U;
			}
			set
			{
				this._assitnum = new uint?(value);
			}
		}

		// Token: 0x1700258D RID: 9613
		// (get) Token: 0x06007697 RID: 30359 RVA: 0x000E2E60 File Offset: 0x000E1060
		// (set) Token: 0x06007698 RID: 30360 RVA: 0x000E2E80 File Offset: 0x000E1080
		[XmlIgnore]
		[Browsable(false)]
		public bool assitnumSpecified
		{
			get
			{
				return this._assitnum != null;
			}
			set
			{
				bool flag = value == (this._assitnum == null);
				if (flag)
				{
					this._assitnum = (value ? new uint?(this.assitnum) : null);
				}
			}
		}

		// Token: 0x06007699 RID: 30361 RVA: 0x000E2EC4 File Offset: 0x000E10C4
		private bool ShouldSerializeassitnum()
		{
			return this.assitnumSpecified;
		}

		// Token: 0x0600769A RID: 30362 RVA: 0x000E2EDC File Offset: 0x000E10DC
		private void Resetassitnum()
		{
			this.assitnumSpecified = false;
		}

		// Token: 0x0600769B RID: 30363 RVA: 0x000E2EE8 File Offset: 0x000E10E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C12 RID: 7186
		private ulong? _uid;

		// Token: 0x04001C13 RID: 7187
		private uint? _heroid;

		// Token: 0x04001C14 RID: 7188
		private string _name;

		// Token: 0x04001C15 RID: 7189
		private uint? _killnum;

		// Token: 0x04001C16 RID: 7190
		private uint? _deathnum;

		// Token: 0x04001C17 RID: 7191
		private uint? _assitnum;

		// Token: 0x04001C18 RID: 7192
		private IExtension extensionObject;
	}
}
