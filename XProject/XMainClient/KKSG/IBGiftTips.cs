using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003D3 RID: 979
	[ProtoContract(Name = "IBGiftTips")]
	[Serializable]
	public class IBGiftTips : IExtensible
	{
		// Token: 0x1700100A RID: 4106
		// (get) Token: 0x0600341C RID: 13340 RVA: 0x00063FA0 File Offset: 0x000621A0
		// (set) Token: 0x0600341D RID: 13341 RVA: 0x00063FC1 File Offset: 0x000621C1
		[ProtoMember(1, IsRequired = false, Name = "orderid", DataFormat = DataFormat.Default)]
		public string orderid
		{
			get
			{
				return this._orderid ?? "";
			}
			set
			{
				this._orderid = value;
			}
		}

		// Token: 0x1700100B RID: 4107
		// (get) Token: 0x0600341E RID: 13342 RVA: 0x00063FCC File Offset: 0x000621CC
		// (set) Token: 0x0600341F RID: 13343 RVA: 0x00063FE8 File Offset: 0x000621E8
		[XmlIgnore]
		[Browsable(false)]
		public bool orderidSpecified
		{
			get
			{
				return this._orderid != null;
			}
			set
			{
				bool flag = value == (this._orderid == null);
				if (flag)
				{
					this._orderid = (value ? this.orderid : null);
				}
			}
		}

		// Token: 0x06003420 RID: 13344 RVA: 0x00064018 File Offset: 0x00062218
		private bool ShouldSerializeorderid()
		{
			return this.orderidSpecified;
		}

		// Token: 0x06003421 RID: 13345 RVA: 0x00064030 File Offset: 0x00062230
		private void Resetorderid()
		{
			this.orderidSpecified = false;
		}

		// Token: 0x06003422 RID: 13346 RVA: 0x0006403C File Offset: 0x0006223C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CF2 RID: 3314
		private string _orderid;

		// Token: 0x04000CF3 RID: 3315
		private IExtension extensionObject;
	}
}
