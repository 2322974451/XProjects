using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayGiftNtfData")]
	[Serializable]
	public class PayGiftNtfData : IExtensible
	{

		[ProtoMember(1, Name = "gift", DataFormat = DataFormat.Default)]
		public List<PayGiftRecord> gift
		{
			get
			{
				return this._gift;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "isShowDetail", DataFormat = DataFormat.Default)]
		public bool isShowDetail
		{
			get
			{
				return this._isShowDetail ?? false;
			}
			set
			{
				this._isShowDetail = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isShowDetailSpecified
		{
			get
			{
				return this._isShowDetail != null;
			}
			set
			{
				bool flag = value == (this._isShowDetail == null);
				if (flag)
				{
					this._isShowDetail = (value ? new bool?(this.isShowDetail) : null);
				}
			}
		}

		private bool ShouldSerializeisShowDetail()
		{
			return this.isShowDetailSpecified;
		}

		private void ResetisShowDetail()
		{
			this.isShowDetailSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<PayGiftRecord> _gift = new List<PayGiftRecord>();

		private bool? _isShowDetail;

		private IExtension extensionObject;
	}
}
