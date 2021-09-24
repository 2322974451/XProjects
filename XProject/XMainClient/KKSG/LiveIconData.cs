using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LiveIconData")]
	[Serializable]
	public class LiveIconData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "liveType", DataFormat = DataFormat.TwosComplement)]
		public int liveType
		{
			get
			{
				return this._liveType ?? 0;
			}
			set
			{
				this._liveType = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool liveTypeSpecified
		{
			get
			{
				return this._liveType != null;
			}
			set
			{
				bool flag = value == (this._liveType == null);
				if (flag)
				{
					this._liveType = (value ? new int?(this.liveType) : null);
				}
			}
		}

		private bool ShouldSerializeliveType()
		{
			return this.liveTypeSpecified;
		}

		private void ResetliveType()
		{
			this.liveTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "liveID", DataFormat = DataFormat.TwosComplement)]
		public int liveID
		{
			get
			{
				return this._liveID ?? 0;
			}
			set
			{
				this._liveID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool liveIDSpecified
		{
			get
			{
				return this._liveID != null;
			}
			set
			{
				bool flag = value == (this._liveID == null);
				if (flag)
				{
					this._liveID = (value ? new int?(this.liveID) : null);
				}
			}
		}

		private bool ShouldSerializeliveID()
		{
			return this.liveIDSpecified;
		}

		private void ResetliveID()
		{
			this.liveIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "liveInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OneLiveRecordInfo liveInfo
		{
			get
			{
				return this._liveInfo;
			}
			set
			{
				this._liveInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _liveType;

		private int? _liveID;

		private OneLiveRecordInfo _liveInfo = null;

		private IExtension extensionObject;
	}
}
