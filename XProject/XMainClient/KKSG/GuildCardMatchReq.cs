using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000248 RID: 584
	[ProtoContract(Name = "GuildCardMatchReq")]
	[Serializable]
	public class GuildCardMatchReq : IExtensible
	{
		// Token: 0x17000A17 RID: 2583
		// (get) Token: 0x06002060 RID: 8288 RVA: 0x0003F680 File Offset: 0x0003D880
		// (set) Token: 0x06002061 RID: 8289 RVA: 0x0003F6AC File Offset: 0x0003D8AC
		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public CardMatchOp op
		{
			get
			{
				return this._op ?? CardMatchOp.CardMatch_Begin;
			}
			set
			{
				this._op = new CardMatchOp?(value);
			}
		}

		// Token: 0x17000A18 RID: 2584
		// (get) Token: 0x06002062 RID: 8290 RVA: 0x0003F6BC File Offset: 0x0003D8BC
		// (set) Token: 0x06002063 RID: 8291 RVA: 0x0003F6DC File Offset: 0x0003D8DC
		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new CardMatchOp?(this.op) : null);
				}
			}
		}

		// Token: 0x06002064 RID: 8292 RVA: 0x0003F720 File Offset: 0x0003D920
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x06002065 RID: 8293 RVA: 0x0003F738 File Offset: 0x0003D938
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x17000A19 RID: 2585
		// (get) Token: 0x06002066 RID: 8294 RVA: 0x0003F744 File Offset: 0x0003D944
		// (set) Token: 0x06002067 RID: 8295 RVA: 0x0003F770 File Offset: 0x0003D970
		[ProtoMember(2, IsRequired = false, Name = "card", DataFormat = DataFormat.TwosComplement)]
		public uint card
		{
			get
			{
				return this._card ?? 0U;
			}
			set
			{
				this._card = new uint?(value);
			}
		}

		// Token: 0x17000A1A RID: 2586
		// (get) Token: 0x06002068 RID: 8296 RVA: 0x0003F780 File Offset: 0x0003D980
		// (set) Token: 0x06002069 RID: 8297 RVA: 0x0003F7A0 File Offset: 0x0003D9A0
		[XmlIgnore]
		[Browsable(false)]
		public bool cardSpecified
		{
			get
			{
				return this._card != null;
			}
			set
			{
				bool flag = value == (this._card == null);
				if (flag)
				{
					this._card = (value ? new uint?(this.card) : null);
				}
			}
		}

		// Token: 0x0600206A RID: 8298 RVA: 0x0003F7E4 File Offset: 0x0003D9E4
		private bool ShouldSerializecard()
		{
			return this.cardSpecified;
		}

		// Token: 0x0600206B RID: 8299 RVA: 0x0003F7FC File Offset: 0x0003D9FC
		private void Resetcard()
		{
			this.cardSpecified = false;
		}

		// Token: 0x0600206C RID: 8300 RVA: 0x0003F808 File Offset: 0x0003DA08
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000815 RID: 2069
		private CardMatchOp? _op;

		// Token: 0x04000816 RID: 2070
		private uint? _card;

		// Token: 0x04000817 RID: 2071
		private IExtension extensionObject;
	}
}
