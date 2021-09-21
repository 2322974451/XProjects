using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000620 RID: 1568
	[ProtoContract(Name = "PayBaseInfo")]
	[Serializable]
	public class PayBaseInfo : IExtensible
	{
		// Token: 0x17001E2F RID: 7727
		// (get) Token: 0x06005FF0 RID: 24560 RVA: 0x000B6FC0 File Offset: 0x000B51C0
		// (set) Token: 0x06005FF1 RID: 24561 RVA: 0x000B6FE1 File Offset: 0x000B51E1
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

		// Token: 0x17001E30 RID: 7728
		// (get) Token: 0x06005FF2 RID: 24562 RVA: 0x000B6FEC File Offset: 0x000B51EC
		// (set) Token: 0x06005FF3 RID: 24563 RVA: 0x000B7008 File Offset: 0x000B5208
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

		// Token: 0x06005FF4 RID: 24564 RVA: 0x000B7038 File Offset: 0x000B5238
		private bool ShouldSerializeparamID()
		{
			return this.paramIDSpecified;
		}

		// Token: 0x06005FF5 RID: 24565 RVA: 0x000B7050 File Offset: 0x000B5250
		private void ResetparamID()
		{
			this.paramIDSpecified = false;
		}

		// Token: 0x17001E31 RID: 7729
		// (get) Token: 0x06005FF6 RID: 24566 RVA: 0x000B705C File Offset: 0x000B525C
		// (set) Token: 0x06005FF7 RID: 24567 RVA: 0x000B7088 File Offset: 0x000B5288
		[ProtoMember(2, IsRequired = false, Name = "isPay", DataFormat = DataFormat.Default)]
		public bool isPay
		{
			get
			{
				return this._isPay ?? false;
			}
			set
			{
				this._isPay = new bool?(value);
			}
		}

		// Token: 0x17001E32 RID: 7730
		// (get) Token: 0x06005FF8 RID: 24568 RVA: 0x000B7098 File Offset: 0x000B5298
		// (set) Token: 0x06005FF9 RID: 24569 RVA: 0x000B70B8 File Offset: 0x000B52B8
		[XmlIgnore]
		[Browsable(false)]
		public bool isPaySpecified
		{
			get
			{
				return this._isPay != null;
			}
			set
			{
				bool flag = value == (this._isPay == null);
				if (flag)
				{
					this._isPay = (value ? new bool?(this.isPay) : null);
				}
			}
		}

		// Token: 0x06005FFA RID: 24570 RVA: 0x000B70FC File Offset: 0x000B52FC
		private bool ShouldSerializeisPay()
		{
			return this.isPaySpecified;
		}

		// Token: 0x06005FFB RID: 24571 RVA: 0x000B7114 File Offset: 0x000B5314
		private void ResetisPay()
		{
			this.isPaySpecified = false;
		}

		// Token: 0x06005FFC RID: 24572 RVA: 0x000B7120 File Offset: 0x000B5320
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001750 RID: 5968
		private string _paramID;

		// Token: 0x04001751 RID: 5969
		private bool? _isPay;

		// Token: 0x04001752 RID: 5970
		private IExtension extensionObject;
	}
}
