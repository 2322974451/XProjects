using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlayDiceRequestArg")]
	[Serializable]
	public class PlayDiceRequestArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "mapid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "randValue", DataFormat = DataFormat.TwosComplement)]
		public int randValue
		{
			get
			{
				return this._randValue ?? 0;
			}
			set
			{
				this._randValue = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool randValueSpecified
		{
			get
			{
				return this._randValue != null;
			}
			set
			{
				bool flag = value == (this._randValue == null);
				if (flag)
				{
					this._randValue = (value ? new int?(this.randValue) : null);
				}
			}
		}

		private bool ShouldSerializerandValue()
		{
			return this.randValueSpecified;
		}

		private void ResetrandValue()
		{
			this.randValueSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _mapid;

		private int? _randValue;

		private IExtension extensionObject;
	}
}
