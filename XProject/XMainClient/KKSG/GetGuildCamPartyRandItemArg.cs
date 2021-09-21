using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003EC RID: 1004
	[ProtoContract(Name = "GetGuildCamPartyRandItemArg")]
	[Serializable]
	public class GetGuildCamPartyRandItemArg : IExtensible
	{
		// Token: 0x17001067 RID: 4199
		// (get) Token: 0x06003554 RID: 13652 RVA: 0x00066340 File Offset: 0x00064540
		// (set) Token: 0x06003555 RID: 13653 RVA: 0x0006636C File Offset: 0x0006456C
		[ProtoMember(1, IsRequired = false, Name = "query_type", DataFormat = DataFormat.TwosComplement)]
		public uint query_type
		{
			get
			{
				return this._query_type ?? 0U;
			}
			set
			{
				this._query_type = new uint?(value);
			}
		}

		// Token: 0x17001068 RID: 4200
		// (get) Token: 0x06003556 RID: 13654 RVA: 0x0006637C File Offset: 0x0006457C
		// (set) Token: 0x06003557 RID: 13655 RVA: 0x0006639C File Offset: 0x0006459C
		[XmlIgnore]
		[Browsable(false)]
		public bool query_typeSpecified
		{
			get
			{
				return this._query_type != null;
			}
			set
			{
				bool flag = value == (this._query_type == null);
				if (flag)
				{
					this._query_type = (value ? new uint?(this.query_type) : null);
				}
			}
		}

		// Token: 0x06003558 RID: 13656 RVA: 0x000663E0 File Offset: 0x000645E0
		private bool ShouldSerializequery_type()
		{
			return this.query_typeSpecified;
		}

		// Token: 0x06003559 RID: 13657 RVA: 0x000663F8 File Offset: 0x000645F8
		private void Resetquery_type()
		{
			this.query_typeSpecified = false;
		}

		// Token: 0x17001069 RID: 4201
		// (get) Token: 0x0600355A RID: 13658 RVA: 0x00066404 File Offset: 0x00064604
		// (set) Token: 0x0600355B RID: 13659 RVA: 0x00066430 File Offset: 0x00064630
		[ProtoMember(2, IsRequired = false, Name = "npc_id", DataFormat = DataFormat.TwosComplement)]
		public uint npc_id
		{
			get
			{
				return this._npc_id ?? 0U;
			}
			set
			{
				this._npc_id = new uint?(value);
			}
		}

		// Token: 0x1700106A RID: 4202
		// (get) Token: 0x0600355C RID: 13660 RVA: 0x00066440 File Offset: 0x00064640
		// (set) Token: 0x0600355D RID: 13661 RVA: 0x00066460 File Offset: 0x00064660
		[XmlIgnore]
		[Browsable(false)]
		public bool npc_idSpecified
		{
			get
			{
				return this._npc_id != null;
			}
			set
			{
				bool flag = value == (this._npc_id == null);
				if (flag)
				{
					this._npc_id = (value ? new uint?(this.npc_id) : null);
				}
			}
		}

		// Token: 0x0600355E RID: 13662 RVA: 0x000664A4 File Offset: 0x000646A4
		private bool ShouldSerializenpc_id()
		{
			return this.npc_idSpecified;
		}

		// Token: 0x0600355F RID: 13663 RVA: 0x000664BC File Offset: 0x000646BC
		private void Resetnpc_id()
		{
			this.npc_idSpecified = false;
		}

		// Token: 0x1700106B RID: 4203
		// (get) Token: 0x06003560 RID: 13664 RVA: 0x000664C8 File Offset: 0x000646C8
		// (set) Token: 0x06003561 RID: 13665 RVA: 0x000664F4 File Offset: 0x000646F4
		[ProtoMember(3, IsRequired = false, Name = "sprite_id", DataFormat = DataFormat.TwosComplement)]
		public uint sprite_id
		{
			get
			{
				return this._sprite_id ?? 0U;
			}
			set
			{
				this._sprite_id = new uint?(value);
			}
		}

		// Token: 0x1700106C RID: 4204
		// (get) Token: 0x06003562 RID: 13666 RVA: 0x00066504 File Offset: 0x00064704
		// (set) Token: 0x06003563 RID: 13667 RVA: 0x00066524 File Offset: 0x00064724
		[XmlIgnore]
		[Browsable(false)]
		public bool sprite_idSpecified
		{
			get
			{
				return this._sprite_id != null;
			}
			set
			{
				bool flag = value == (this._sprite_id == null);
				if (flag)
				{
					this._sprite_id = (value ? new uint?(this.sprite_id) : null);
				}
			}
		}

		// Token: 0x06003564 RID: 13668 RVA: 0x00066568 File Offset: 0x00064768
		private bool ShouldSerializesprite_id()
		{
			return this.sprite_idSpecified;
		}

		// Token: 0x06003565 RID: 13669 RVA: 0x00066580 File Offset: 0x00064780
		private void Resetsprite_id()
		{
			this.sprite_idSpecified = false;
		}

		// Token: 0x06003566 RID: 13670 RVA: 0x0006658C File Offset: 0x0006478C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D3F RID: 3391
		private uint? _query_type;

		// Token: 0x04000D40 RID: 3392
		private uint? _npc_id;

		// Token: 0x04000D41 RID: 3393
		private uint? _sprite_id;

		// Token: 0x04000D42 RID: 3394
		private IExtension extensionObject;
	}
}
