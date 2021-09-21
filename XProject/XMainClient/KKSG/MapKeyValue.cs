using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000601 RID: 1537
	[ProtoContract(Name = "MapKeyValue")]
	[Serializable]
	public class MapKeyValue : IExtensible
	{
		// Token: 0x17001CCA RID: 7370
		// (get) Token: 0x06005BF2 RID: 23538 RVA: 0x000AF230 File Offset: 0x000AD430
		// (set) Token: 0x06005BF3 RID: 23539 RVA: 0x000AF25D File Offset: 0x000AD45D
		[ProtoMember(1, IsRequired = false, Name = "key", DataFormat = DataFormat.TwosComplement)]
		public ulong key
		{
			get
			{
				return this._key ?? 0UL;
			}
			set
			{
				this._key = new ulong?(value);
			}
		}

		// Token: 0x17001CCB RID: 7371
		// (get) Token: 0x06005BF4 RID: 23540 RVA: 0x000AF26C File Offset: 0x000AD46C
		// (set) Token: 0x06005BF5 RID: 23541 RVA: 0x000AF28C File Offset: 0x000AD48C
		[XmlIgnore]
		[Browsable(false)]
		public bool keySpecified
		{
			get
			{
				return this._key != null;
			}
			set
			{
				bool flag = value == (this._key == null);
				if (flag)
				{
					this._key = (value ? new ulong?(this.key) : null);
				}
			}
		}

		// Token: 0x06005BF6 RID: 23542 RVA: 0x000AF2D0 File Offset: 0x000AD4D0
		private bool ShouldSerializekey()
		{
			return this.keySpecified;
		}

		// Token: 0x06005BF7 RID: 23543 RVA: 0x000AF2E8 File Offset: 0x000AD4E8
		private void Resetkey()
		{
			this.keySpecified = false;
		}

		// Token: 0x17001CCC RID: 7372
		// (get) Token: 0x06005BF8 RID: 23544 RVA: 0x000AF2F4 File Offset: 0x000AD4F4
		// (set) Token: 0x06005BF9 RID: 23545 RVA: 0x000AF321 File Offset: 0x000AD521
		[ProtoMember(2, IsRequired = false, Name = "value", DataFormat = DataFormat.TwosComplement)]
		public ulong value
		{
			get
			{
				return this._value ?? 0UL;
			}
			set
			{
				this._value = new ulong?(value);
			}
		}

		// Token: 0x17001CCD RID: 7373
		// (get) Token: 0x06005BFA RID: 23546 RVA: 0x000AF330 File Offset: 0x000AD530
		// (set) Token: 0x06005BFB RID: 23547 RVA: 0x000AF350 File Offset: 0x000AD550
		[XmlIgnore]
		[Browsable(false)]
		public bool valueSpecified
		{
			get
			{
				return this._value != null;
			}
			set
			{
				bool flag = value == (this._value == null);
				if (flag)
				{
					this._value = (value ? new ulong?(this.value) : null);
				}
			}
		}

		// Token: 0x06005BFC RID: 23548 RVA: 0x000AF394 File Offset: 0x000AD594
		private bool ShouldSerializevalue()
		{
			return this.valueSpecified;
		}

		// Token: 0x06005BFD RID: 23549 RVA: 0x000AF3AC File Offset: 0x000AD5AC
		private void Resetvalue()
		{
			this.valueSpecified = false;
		}

		// Token: 0x06005BFE RID: 23550 RVA: 0x000AF3B8 File Offset: 0x000AD5B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400165F RID: 5727
		private ulong? _key;

		// Token: 0x04001660 RID: 5728
		private ulong? _value;

		// Token: 0x04001661 RID: 5729
		private IExtension extensionObject;
	}
}
