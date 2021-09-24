using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BackFlowActivityOperationRes")]
	[Serializable]
	public class BackFlowActivityOperationRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		[ProtoMember(3, Name = "alreadyGet", DataFormat = DataFormat.TwosComplement)]
		public List<uint> alreadyGet
		{
			get
			{
				return this._alreadyGet;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "shop", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BackFlowShopData shop
		{
			get
			{
				return this._shop;
			}
			set
			{
				this._shop = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "shopLeftTime", DataFormat = DataFormat.TwosComplement)]
		public uint shopLeftTime
		{
			get
			{
				return this._shopLeftTime ?? 0U;
			}
			set
			{
				this._shopLeftTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool shopLeftTimeSpecified
		{
			get
			{
				return this._shopLeftTime != null;
			}
			set
			{
				bool flag = value == (this._shopLeftTime == null);
				if (flag)
				{
					this._shopLeftTime = (value ? new uint?(this.shopLeftTime) : null);
				}
			}
		}

		private bool ShouldSerializeshopLeftTime()
		{
			return this.shopLeftTimeSpecified;
		}

		private void ResetshopLeftTime()
		{
			this.shopLeftTimeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "activityLeftTime", DataFormat = DataFormat.TwosComplement)]
		public uint activityLeftTime
		{
			get
			{
				return this._activityLeftTime ?? 0U;
			}
			set
			{
				this._activityLeftTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool activityLeftTimeSpecified
		{
			get
			{
				return this._activityLeftTime != null;
			}
			set
			{
				bool flag = value == (this._activityLeftTime == null);
				if (flag)
				{
					this._activityLeftTime = (value ? new uint?(this.activityLeftTime) : null);
				}
			}
		}

		private bool ShouldSerializeactivityLeftTime()
		{
			return this.activityLeftTimeSpecified;
		}

		private void ResetactivityLeftTime()
		{
			this.activityLeftTimeSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "leftSmallDragonCount", DataFormat = DataFormat.TwosComplement)]
		public uint leftSmallDragonCount
		{
			get
			{
				return this._leftSmallDragonCount ?? 0U;
			}
			set
			{
				this._leftSmallDragonCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftSmallDragonCountSpecified
		{
			get
			{
				return this._leftSmallDragonCount != null;
			}
			set
			{
				bool flag = value == (this._leftSmallDragonCount == null);
				if (flag)
				{
					this._leftSmallDragonCount = (value ? new uint?(this.leftSmallDragonCount) : null);
				}
			}
		}

		private bool ShouldSerializeleftSmallDragonCount()
		{
			return this.leftSmallDragonCountSpecified;
		}

		private void ResetleftSmallDragonCount()
		{
			this.leftSmallDragonCountSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "leftNestCount", DataFormat = DataFormat.TwosComplement)]
		public uint leftNestCount
		{
			get
			{
				return this._leftNestCount ?? 0U;
			}
			set
			{
				this._leftNestCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftNestCountSpecified
		{
			get
			{
				return this._leftNestCount != null;
			}
			set
			{
				bool flag = value == (this._leftNestCount == null);
				if (flag)
				{
					this._leftNestCount = (value ? new uint?(this.leftNestCount) : null);
				}
			}
		}

		private bool ShouldSerializeleftNestCount()
		{
			return this.leftNestCountSpecified;
		}

		private void ResetleftNestCount()
		{
			this.leftNestCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _point;

		private readonly List<uint> _alreadyGet = new List<uint>();

		private BackFlowShopData _shop = null;

		private uint? _shopLeftTime;

		private uint? _activityLeftTime;

		private uint? _leftSmallDragonCount;

		private uint? _leftNestCount;

		private IExtension extensionObject;
	}
}
