using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000275 RID: 629
	[ProtoContract(Name = "SpriteState")]
	[Serializable]
	public class SpriteState : IExtensible
	{
		// Token: 0x17000ADE RID: 2782
		// (get) Token: 0x060022F3 RID: 8947 RVA: 0x000443FC File Offset: 0x000425FC
		// (set) Token: 0x060022F4 RID: 8948 RVA: 0x00044428 File Offset: 0x00042628
		[ProtoMember(1, IsRequired = false, Name = "sprite_id", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000ADF RID: 2783
		// (get) Token: 0x060022F5 RID: 8949 RVA: 0x00044438 File Offset: 0x00042638
		// (set) Token: 0x060022F6 RID: 8950 RVA: 0x00044458 File Offset: 0x00042658
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

		// Token: 0x060022F7 RID: 8951 RVA: 0x0004449C File Offset: 0x0004269C
		private bool ShouldSerializesprite_id()
		{
			return this.sprite_idSpecified;
		}

		// Token: 0x060022F8 RID: 8952 RVA: 0x000444B4 File Offset: 0x000426B4
		private void Resetsprite_id()
		{
			this.sprite_idSpecified = false;
		}

		// Token: 0x17000AE0 RID: 2784
		// (get) Token: 0x060022F9 RID: 8953 RVA: 0x000444C0 File Offset: 0x000426C0
		// (set) Token: 0x060022FA RID: 8954 RVA: 0x000444EC File Offset: 0x000426EC
		[ProtoMember(2, IsRequired = false, Name = "state", DataFormat = DataFormat.Default)]
		public bool state
		{
			get
			{
				return this._state ?? false;
			}
			set
			{
				this._state = new bool?(value);
			}
		}

		// Token: 0x17000AE1 RID: 2785
		// (get) Token: 0x060022FB RID: 8955 RVA: 0x000444FC File Offset: 0x000426FC
		// (set) Token: 0x060022FC RID: 8956 RVA: 0x0004451C File Offset: 0x0004271C
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new bool?(this.state) : null);
				}
			}
		}

		// Token: 0x060022FD RID: 8957 RVA: 0x00044560 File Offset: 0x00042760
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060022FE RID: 8958 RVA: 0x00044578 File Offset: 0x00042778
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x060022FF RID: 8959 RVA: 0x00044584 File Offset: 0x00042784
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008AD RID: 2221
		private uint? _sprite_id;

		// Token: 0x040008AE RID: 2222
		private bool? _state;

		// Token: 0x040008AF RID: 2223
		private IExtension extensionObject;
	}
}
