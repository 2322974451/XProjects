using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000482 RID: 1154
	[ProtoContract(Name = "WeddingOperatorArg")]
	[Serializable]
	public class WeddingOperatorArg : IExtensible
	{
		// Token: 0x1700127F RID: 4735
		// (get) Token: 0x06003C4C RID: 15436 RVA: 0x000732FC File Offset: 0x000714FC
		// (set) Token: 0x06003C4D RID: 15437 RVA: 0x00073328 File Offset: 0x00071528
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingOperType type
		{
			get
			{
				return this._type ?? WeddingOperType.WeddingOper_Flower;
			}
			set
			{
				this._type = new WeddingOperType?(value);
			}
		}

		// Token: 0x17001280 RID: 4736
		// (get) Token: 0x06003C4E RID: 15438 RVA: 0x00073338 File Offset: 0x00071538
		// (set) Token: 0x06003C4F RID: 15439 RVA: 0x00073358 File Offset: 0x00071558
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
					this._type = (value ? new WeddingOperType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003C50 RID: 15440 RVA: 0x0007339C File Offset: 0x0007159C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003C51 RID: 15441 RVA: 0x000733B4 File Offset: 0x000715B4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06003C52 RID: 15442 RVA: 0x000733C0 File Offset: 0x000715C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F04 RID: 3844
		private WeddingOperType? _type;

		// Token: 0x04000F05 RID: 3845
		private IExtension extensionObject;
	}
}
