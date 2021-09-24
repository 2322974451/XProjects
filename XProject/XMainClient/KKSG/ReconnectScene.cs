using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReconnectScene")]
	[Serializable]
	public class ReconnectScene : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "isready", DataFormat = DataFormat.Default)]
		public bool isready
		{
			get
			{
				return this._isready ?? false;
			}
			set
			{
				this._isready = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isreadySpecified
		{
			get
			{
				return this._isready != null;
			}
			set
			{
				bool flag = value == (this._isready == null);
				if (flag)
				{
					this._isready = (value ? new bool?(this.isready) : null);
				}
			}
		}

		private bool ShouldSerializeisready()
		{
			return this.isreadySpecified;
		}

		private void Resetisready()
		{
			this.isreadySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _sceneid;

		private bool? _isready;

		private IExtension extensionObject;
	}
}
