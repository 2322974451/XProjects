using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiskGridInfo")]
	[Serializable]
	public class RiskGridInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "x", DataFormat = DataFormat.TwosComplement)]
		public int x
		{
			get
			{
				return this._x ?? 0;
			}
			set
			{
				this._x = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool xSpecified
		{
			get
			{
				return this._x != null;
			}
			set
			{
				bool flag = value == (this._x == null);
				if (flag)
				{
					this._x = (value ? new int?(this.x) : null);
				}
			}
		}

		private bool ShouldSerializex()
		{
			return this.xSpecified;
		}

		private void Resetx()
		{
			this.xSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "y", DataFormat = DataFormat.TwosComplement)]
		public int y
		{
			get
			{
				return this._y ?? 0;
			}
			set
			{
				this._y = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ySpecified
		{
			get
			{
				return this._y != null;
			}
			set
			{
				bool flag = value == (this._y == null);
				if (flag)
				{
					this._y = (value ? new int?(this.y) : null);
				}
			}
		}

		private bool ShouldSerializey()
		{
			return this.ySpecified;
		}

		private void Resety()
		{
			this.ySpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "gridType", DataFormat = DataFormat.TwosComplement)]
		public RiskGridType gridType
		{
			get
			{
				return this._gridType ?? RiskGridType.RISK_GRID_EMPTY;
			}
			set
			{
				this._gridType = new RiskGridType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gridTypeSpecified
		{
			get
			{
				return this._gridType != null;
			}
			set
			{
				bool flag = value == (this._gridType == null);
				if (flag)
				{
					this._gridType = (value ? new RiskGridType?(this.gridType) : null);
				}
			}
		}

		private bool ShouldSerializegridType()
		{
			return this.gridTypeSpecified;
		}

		private void ResetgridType()
		{
			this.gridTypeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "rewardItem", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief rewardItem
		{
			get
			{
				return this._rewardItem;
			}
			set
			{
				this._rewardItem = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "boxState", DataFormat = DataFormat.TwosComplement)]
		public RiskBoxState boxState
		{
			get
			{
				return this._boxState ?? RiskBoxState.RISK_BOX_LOCKED;
			}
			set
			{
				this._boxState = new RiskBoxState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool boxStateSpecified
		{
			get
			{
				return this._boxState != null;
			}
			set
			{
				bool flag = value == (this._boxState == null);
				if (flag)
				{
					this._boxState = (value ? new RiskBoxState?(this.boxState) : null);
				}
			}
		}

		private bool ShouldSerializeboxState()
		{
			return this.boxStateSpecified;
		}

		private void ResetboxState()
		{
			this.boxStateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _x;

		private int? _y;

		private RiskGridType? _gridType;

		private ItemBrief _rewardItem = null;

		private RiskBoxState? _boxState;

		private IExtension extensionObject;
	}
}
