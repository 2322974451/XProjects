using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetRiskMapInfosArg")]
	[Serializable]
	public class GetRiskMapInfosArg : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "isRefresh", DataFormat = DataFormat.Default)]
		public bool isRefresh
		{
			get
			{
				return this._isRefresh ?? false;
			}
			set
			{
				this._isRefresh = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isRefreshSpecified
		{
			get
			{
				return this._isRefresh != null;
			}
			set
			{
				bool flag = value == (this._isRefresh == null);
				if (flag)
				{
					this._isRefresh = (value ? new bool?(this.isRefresh) : null);
				}
			}
		}

		private bool ShouldSerializeisRefresh()
		{
			return this.isRefreshSpecified;
		}

		private void ResetisRefresh()
		{
			this.isRefreshSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "onlyCountInfo", DataFormat = DataFormat.Default)]
		public bool onlyCountInfo
		{
			get
			{
				return this._onlyCountInfo ?? false;
			}
			set
			{
				this._onlyCountInfo = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool onlyCountInfoSpecified
		{
			get
			{
				return this._onlyCountInfo != null;
			}
			set
			{
				bool flag = value == (this._onlyCountInfo == null);
				if (flag)
				{
					this._onlyCountInfo = (value ? new bool?(this.onlyCountInfo) : null);
				}
			}
		}

		private bool ShouldSerializeonlyCountInfo()
		{
			return this.onlyCountInfoSpecified;
		}

		private void ResetonlyCountInfo()
		{
			this.onlyCountInfoSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _mapID;

		private bool? _isRefresh;

		private bool? _onlyCountInfo;

		private IExtension extensionObject;
	}
}
