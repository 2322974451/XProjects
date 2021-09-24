using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlayDiceOverRes")]
	[Serializable]
	public class PlayDiceOverRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "mapID", DataFormat = DataFormat.TwosComplement)]
		public int mapID
		{
			get
			{
				return this._mapID ?? 0;
			}
			set
			{
				this._mapID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mapIDSpecified
		{
			get
			{
				return this._mapID != null;
			}
			set
			{
				bool flag = value == (this._mapID == null);
				if (flag)
				{
					this._mapID = (value ? new int?(this.mapID) : null);
				}
			}
		}

		private bool ShouldSerializemapID()
		{
			return this.mapIDSpecified;
		}

		private void ResetmapID()
		{
			this.mapIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "addBoxInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RiskBoxInfo addBoxInfo
		{
			get
			{
				return this._addBoxInfo;
			}
			set
			{
				this._addBoxInfo = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "hasTriggerBuy", DataFormat = DataFormat.Default)]
		public bool hasTriggerBuy
		{
			get
			{
				return this._hasTriggerBuy ?? false;
			}
			set
			{
				this._hasTriggerBuy = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasTriggerBuySpecified
		{
			get
			{
				return this._hasTriggerBuy != null;
			}
			set
			{
				bool flag = value == (this._hasTriggerBuy == null);
				if (flag)
				{
					this._hasTriggerBuy = (value ? new bool?(this.hasTriggerBuy) : null);
				}
			}
		}

		private bool ShouldSerializehasTriggerBuy()
		{
			return this.hasTriggerBuySpecified;
		}

		private void ResethasTriggerBuy()
		{
			this.hasTriggerBuySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private int? _mapID;

		private RiskBoxInfo _addBoxInfo = null;

		private bool? _hasTriggerBuy;

		private IExtension extensionObject;
	}
}
