using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000568 RID: 1384
	[ProtoContract(Name = "AttributeInfo")]
	[Serializable]
	public class AttributeInfo : IExtensible
	{
		// Token: 0x170015D1 RID: 5585
		// (get) Token: 0x06004745 RID: 18245 RVA: 0x000876CC File Offset: 0x000858CC
		// (set) Token: 0x06004746 RID: 18246 RVA: 0x000876F8 File Offset: 0x000858F8
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x170015D2 RID: 5586
		// (get) Token: 0x06004747 RID: 18247 RVA: 0x00087708 File Offset: 0x00085908
		// (set) Token: 0x06004748 RID: 18248 RVA: 0x00087728 File Offset: 0x00085928
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06004749 RID: 18249 RVA: 0x0008776C File Offset: 0x0008596C
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x0600474A RID: 18250 RVA: 0x00087784 File Offset: 0x00085984
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x170015D3 RID: 5587
		// (get) Token: 0x0600474B RID: 18251 RVA: 0x00087790 File Offset: 0x00085990
		// (set) Token: 0x0600474C RID: 18252 RVA: 0x000877BC File Offset: 0x000859BC
		[ProtoMember(2, IsRequired = false, Name = "value", DataFormat = DataFormat.TwosComplement)]
		public uint value
		{
			get
			{
				return this._value ?? 0U;
			}
			set
			{
				this._value = new uint?(value);
			}
		}

		// Token: 0x170015D4 RID: 5588
		// (get) Token: 0x0600474D RID: 18253 RVA: 0x000877CC File Offset: 0x000859CC
		// (set) Token: 0x0600474E RID: 18254 RVA: 0x000877EC File Offset: 0x000859EC
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
					this._value = (value ? new uint?(this.value) : null);
				}
			}
		}

		// Token: 0x0600474F RID: 18255 RVA: 0x00087830 File Offset: 0x00085A30
		private bool ShouldSerializevalue()
		{
			return this.valueSpecified;
		}

		// Token: 0x06004750 RID: 18256 RVA: 0x00087848 File Offset: 0x00085A48
		private void Resetvalue()
		{
			this.valueSpecified = false;
		}

		// Token: 0x06004751 RID: 18257 RVA: 0x00087854 File Offset: 0x00085A54
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011CC RID: 4556
		private uint? _id;

		// Token: 0x040011CD RID: 4557
		private uint? _value;

		// Token: 0x040011CE RID: 4558
		private IExtension extensionObject;
	}
}
