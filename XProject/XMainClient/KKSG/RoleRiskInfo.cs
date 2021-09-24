using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleRiskInfo")]
	[Serializable]
	public class RoleRiskInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "mapID", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "gridType", DataFormat = DataFormat.TwosComplement)]
		public int gridType
		{
			get
			{
				return this._gridType ?? 0;
			}
			set
			{
				this._gridType = new int?(value);
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
					this._gridType = (value ? new int?(this.gridType) : null);
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

		[ProtoMember(3, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public int sceneID
		{
			get
			{
				return this._sceneID ?? 0;
			}
			set
			{
				this._sceneID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new int?(this.sceneID) : null);
				}
			}
		}

		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "canBuy", DataFormat = DataFormat.Default)]
		public bool canBuy
		{
			get
			{
				return this._canBuy ?? false;
			}
			set
			{
				this._canBuy = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canBuySpecified
		{
			get
			{
				return this._canBuy != null;
			}
			set
			{
				bool flag = value == (this._canBuy == null);
				if (flag)
				{
					this._canBuy = (value ? new bool?(this.canBuy) : null);
				}
			}
		}

		private bool ShouldSerializecanBuy()
		{
			return this.canBuySpecified;
		}

		private void ResetcanBuy()
		{
			this.canBuySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _mapID;

		private int? _gridType;

		private int? _sceneID;

		private bool? _canBuy;

		private IExtension extensionObject;
	}
}
