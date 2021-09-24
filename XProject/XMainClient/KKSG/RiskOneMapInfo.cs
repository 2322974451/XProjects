using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiskOneMapInfo")]
	[Serializable]
	public class RiskOneMapInfo : IExtensible
	{

		[ProtoMember(1, Name = "grids", DataFormat = DataFormat.Default)]
		public List<RiskGridInfo> grids
		{
			get
			{
				return this._grids;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "curX", DataFormat = DataFormat.TwosComplement)]
		public int curX
		{
			get
			{
				return this._curX ?? 0;
			}
			set
			{
				this._curX = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curXSpecified
		{
			get
			{
				return this._curX != null;
			}
			set
			{
				bool flag = value == (this._curX == null);
				if (flag)
				{
					this._curX = (value ? new int?(this.curX) : null);
				}
			}
		}

		private bool ShouldSerializecurX()
		{
			return this.curXSpecified;
		}

		private void ResetcurX()
		{
			this.curXSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "curY", DataFormat = DataFormat.TwosComplement)]
		public int curY
		{
			get
			{
				return this._curY ?? 0;
			}
			set
			{
				this._curY = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curYSpecified
		{
			get
			{
				return this._curY != null;
			}
			set
			{
				bool flag = value == (this._curY == null);
				if (flag)
				{
					this._curY = (value ? new int?(this.curY) : null);
				}
			}
		}

		private bool ShouldSerializecurY()
		{
			return this.curYSpecified;
		}

		private void ResetcurY()
		{
			this.curYSpecified = false;
		}

		[ProtoMember(4, Name = "boxInfos", DataFormat = DataFormat.Default)]
		public List<RiskBoxInfo> boxInfos
		{
			get
			{
				return this._boxInfos;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "mapid", DataFormat = DataFormat.TwosComplement)]
		public int mapid
		{
			get
			{
				return this._mapid ?? 0;
			}
			set
			{
				this._mapid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mapidSpecified
		{
			get
			{
				return this._mapid != null;
			}
			set
			{
				bool flag = value == (this._mapid == null);
				if (flag)
				{
					this._mapid = (value ? new int?(this.mapid) : null);
				}
			}
		}

		private bool ShouldSerializemapid()
		{
			return this.mapidSpecified;
		}

		private void Resetmapid()
		{
			this.mapidSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "moveDirection", DataFormat = DataFormat.TwosComplement)]
		public int moveDirection
		{
			get
			{
				return this._moveDirection ?? 0;
			}
			set
			{
				this._moveDirection = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool moveDirectionSpecified
		{
			get
			{
				return this._moveDirection != null;
			}
			set
			{
				bool flag = value == (this._moveDirection == null);
				if (flag)
				{
					this._moveDirection = (value ? new int?(this.moveDirection) : null);
				}
			}
		}

		private bool ShouldSerializemoveDirection()
		{
			return this.moveDirectionSpecified;
		}

		private void ResetmoveDirection()
		{
			this.moveDirectionSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<RiskGridInfo> _grids = new List<RiskGridInfo>();

		private int? _curX;

		private int? _curY;

		private readonly List<RiskBoxInfo> _boxInfos = new List<RiskBoxInfo>();

		private int? _mapid;

		private int? _moveDirection;

		private IExtension extensionObject;
	}
}
