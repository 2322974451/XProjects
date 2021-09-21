using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000FB RID: 251
	[ProtoContract(Name = "PetOperationArg")]
	[Serializable]
	public class PetOperationArg : IExtensible
	{
		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x06001015 RID: 4117 RVA: 0x000210D4 File Offset: 0x0001F2D4
		// (set) Token: 0x06001016 RID: 4118 RVA: 0x00021100 File Offset: 0x0001F300
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public PetOP type
		{
			get
			{
				return this._type ?? PetOP.PetFellow;
			}
			set
			{
				this._type = new PetOP?(value);
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06001017 RID: 4119 RVA: 0x00021110 File Offset: 0x0001F310
		// (set) Token: 0x06001018 RID: 4120 RVA: 0x00021130 File Offset: 0x0001F330
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
					this._type = (value ? new PetOP?(this.type) : null);
				}
			}
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x00021174 File Offset: 0x0001F374
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x0002118C File Offset: 0x0001F38C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x0600101B RID: 4123 RVA: 0x00021198 File Offset: 0x0001F398
		// (set) Token: 0x0600101C RID: 4124 RVA: 0x000211C5 File Offset: 0x0001F3C5
		[ProtoMember(2, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x0600101D RID: 4125 RVA: 0x000211D4 File Offset: 0x0001F3D4
		// (set) Token: 0x0600101E RID: 4126 RVA: 0x000211F4 File Offset: 0x0001F3F4
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

		// Token: 0x0600101F RID: 4127 RVA: 0x00021238 File Offset: 0x0001F438
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x00021250 File Offset: 0x0001F450
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x06001021 RID: 4129 RVA: 0x0002125C File Offset: 0x0001F45C
		// (set) Token: 0x06001022 RID: 4130 RVA: 0x00021274 File Offset: 0x0001F474
		[ProtoMember(3, IsRequired = false, Name = "food", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief food
		{
			get
			{
				return this._food;
			}
			set
			{
				this._food = value;
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06001023 RID: 4131 RVA: 0x00021280 File Offset: 0x0001F480
		// (set) Token: 0x06001024 RID: 4132 RVA: 0x000212AD File Offset: 0x0001F4AD
		[ProtoMember(4, IsRequired = false, Name = "destpet_id", DataFormat = DataFormat.TwosComplement)]
		public ulong destpet_id
		{
			get
			{
				return this._destpet_id ?? 0UL;
			}
			set
			{
				this._destpet_id = new ulong?(value);
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06001025 RID: 4133 RVA: 0x000212BC File Offset: 0x0001F4BC
		// (set) Token: 0x06001026 RID: 4134 RVA: 0x000212DC File Offset: 0x0001F4DC
		[XmlIgnore]
		[Browsable(false)]
		public bool destpet_idSpecified
		{
			get
			{
				return this._destpet_id != null;
			}
			set
			{
				bool flag = value == (this._destpet_id == null);
				if (flag)
				{
					this._destpet_id = (value ? new ulong?(this.destpet_id) : null);
				}
			}
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x00021320 File Offset: 0x0001F520
		private bool ShouldSerializedestpet_id()
		{
			return this.destpet_idSpecified;
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x00021338 File Offset: 0x0001F538
		private void Resetdestpet_id()
		{
			this.destpet_idSpecified = false;
		}

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06001029 RID: 4137 RVA: 0x00021344 File Offset: 0x0001F544
		// (set) Token: 0x0600102A RID: 4138 RVA: 0x00021370 File Offset: 0x0001F570
		[ProtoMember(5, IsRequired = false, Name = "setpairride", DataFormat = DataFormat.Default)]
		public bool setpairride
		{
			get
			{
				return this._setpairride ?? false;
			}
			set
			{
				this._setpairride = new bool?(value);
			}
		}

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x0600102B RID: 4139 RVA: 0x00021380 File Offset: 0x0001F580
		// (set) Token: 0x0600102C RID: 4140 RVA: 0x000213A0 File Offset: 0x0001F5A0
		[XmlIgnore]
		[Browsable(false)]
		public bool setpairrideSpecified
		{
			get
			{
				return this._setpairride != null;
			}
			set
			{
				bool flag = value == (this._setpairride == null);
				if (flag)
				{
					this._setpairride = (value ? new bool?(this.setpairride) : null);
				}
			}
		}

		// Token: 0x0600102D RID: 4141 RVA: 0x000213E4 File Offset: 0x0001F5E4
		private bool ShouldSerializesetpairride()
		{
			return this.setpairrideSpecified;
		}

		// Token: 0x0600102E RID: 4142 RVA: 0x000213FC File Offset: 0x0001F5FC
		private void Resetsetpairride()
		{
			this.setpairrideSpecified = false;
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x00021408 File Offset: 0x0001F608
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000403 RID: 1027
		private PetOP? _type;

		// Token: 0x04000404 RID: 1028
		private ulong? _uid;

		// Token: 0x04000405 RID: 1029
		private ItemBrief _food = null;

		// Token: 0x04000406 RID: 1030
		private ulong? _destpet_id;

		// Token: 0x04000407 RID: 1031
		private bool? _setpairride;

		// Token: 0x04000408 RID: 1032
		private IExtension extensionObject;
	}
}
