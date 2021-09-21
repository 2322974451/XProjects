using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200069D RID: 1693
	[ProtoContract(Name = "PayAileenInfo")]
	[Serializable]
	public class PayAileenInfo : IExtensible
	{
		// Token: 0x170022DA RID: 8922
		// (get) Token: 0x06006E1E RID: 28190 RVA: 0x000D2B54 File Offset: 0x000D0D54
		// (set) Token: 0x06006E1F RID: 28191 RVA: 0x000D2B75 File Offset: 0x000D0D75
		[ProtoMember(1, IsRequired = false, Name = "paramID", DataFormat = DataFormat.Default)]
		public string paramID
		{
			get
			{
				return this._paramID ?? "";
			}
			set
			{
				this._paramID = value;
			}
		}

		// Token: 0x170022DB RID: 8923
		// (get) Token: 0x06006E20 RID: 28192 RVA: 0x000D2B80 File Offset: 0x000D0D80
		// (set) Token: 0x06006E21 RID: 28193 RVA: 0x000D2B9C File Offset: 0x000D0D9C
		[XmlIgnore]
		[Browsable(false)]
		public bool paramIDSpecified
		{
			get
			{
				return this._paramID != null;
			}
			set
			{
				bool flag = value == (this._paramID == null);
				if (flag)
				{
					this._paramID = (value ? this.paramID : null);
				}
			}
		}

		// Token: 0x06006E22 RID: 28194 RVA: 0x000D2BCC File Offset: 0x000D0DCC
		private bool ShouldSerializeparamID()
		{
			return this.paramIDSpecified;
		}

		// Token: 0x06006E23 RID: 28195 RVA: 0x000D2BE4 File Offset: 0x000D0DE4
		private void ResetparamID()
		{
			this.paramIDSpecified = false;
		}

		// Token: 0x170022DC RID: 8924
		// (get) Token: 0x06006E24 RID: 28196 RVA: 0x000D2BF0 File Offset: 0x000D0DF0
		// (set) Token: 0x06006E25 RID: 28197 RVA: 0x000D2C1C File Offset: 0x000D0E1C
		[ProtoMember(2, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public int itemID
		{
			get
			{
				return this._itemID ?? 0;
			}
			set
			{
				this._itemID = new int?(value);
			}
		}

		// Token: 0x170022DD RID: 8925
		// (get) Token: 0x06006E26 RID: 28198 RVA: 0x000D2C2C File Offset: 0x000D0E2C
		// (set) Token: 0x06006E27 RID: 28199 RVA: 0x000D2C4C File Offset: 0x000D0E4C
		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new int?(this.itemID) : null);
				}
			}
		}

		// Token: 0x06006E28 RID: 28200 RVA: 0x000D2C90 File Offset: 0x000D0E90
		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		// Token: 0x06006E29 RID: 28201 RVA: 0x000D2CA8 File Offset: 0x000D0EA8
		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		// Token: 0x170022DE RID: 8926
		// (get) Token: 0x06006E2A RID: 28202 RVA: 0x000D2CB4 File Offset: 0x000D0EB4
		// (set) Token: 0x06006E2B RID: 28203 RVA: 0x000D2CE0 File Offset: 0x000D0EE0
		[ProtoMember(3, IsRequired = false, Name = "isBuy", DataFormat = DataFormat.Default)]
		public bool isBuy
		{
			get
			{
				return this._isBuy ?? false;
			}
			set
			{
				this._isBuy = new bool?(value);
			}
		}

		// Token: 0x170022DF RID: 8927
		// (get) Token: 0x06006E2C RID: 28204 RVA: 0x000D2CF0 File Offset: 0x000D0EF0
		// (set) Token: 0x06006E2D RID: 28205 RVA: 0x000D2D10 File Offset: 0x000D0F10
		[XmlIgnore]
		[Browsable(false)]
		public bool isBuySpecified
		{
			get
			{
				return this._isBuy != null;
			}
			set
			{
				bool flag = value == (this._isBuy == null);
				if (flag)
				{
					this._isBuy = (value ? new bool?(this.isBuy) : null);
				}
			}
		}

		// Token: 0x06006E2E RID: 28206 RVA: 0x000D2D54 File Offset: 0x000D0F54
		private bool ShouldSerializeisBuy()
		{
			return this.isBuySpecified;
		}

		// Token: 0x06006E2F RID: 28207 RVA: 0x000D2D6C File Offset: 0x000D0F6C
		private void ResetisBuy()
		{
			this.isBuySpecified = false;
		}

		// Token: 0x06006E30 RID: 28208 RVA: 0x000D2D78 File Offset: 0x000D0F78
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A5E RID: 6750
		private string _paramID;

		// Token: 0x04001A5F RID: 6751
		private int? _itemID;

		// Token: 0x04001A60 RID: 6752
		private bool? _isBuy;

		// Token: 0x04001A61 RID: 6753
		private IExtension extensionObject;
	}
}
