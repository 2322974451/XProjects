using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginExtraData")]
	[Serializable]
	public class LoginExtraData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "is_backflow_server", DataFormat = DataFormat.Default)]
		public bool is_backflow_server
		{
			get
			{
				return this._is_backflow_server ?? false;
			}
			set
			{
				this._is_backflow_server = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_backflow_serverSpecified
		{
			get
			{
				return this._is_backflow_server != null;
			}
			set
			{
				bool flag = value == (this._is_backflow_server == null);
				if (flag)
				{
					this._is_backflow_server = (value ? new bool?(this.is_backflow_server) : null);
				}
			}
		}

		private bool ShouldSerializeis_backflow_server()
		{
			return this.is_backflow_serverSpecified;
		}

		private void Resetis_backflow_server()
		{
			this.is_backflow_serverSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "backflow_level", DataFormat = DataFormat.TwosComplement)]
		public uint backflow_level
		{
			get
			{
				return this._backflow_level ?? 0U;
			}
			set
			{
				this._backflow_level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool backflow_levelSpecified
		{
			get
			{
				return this._backflow_level != null;
			}
			set
			{
				bool flag = value == (this._backflow_level == null);
				if (flag)
				{
					this._backflow_level = (value ? new uint?(this.backflow_level) : null);
				}
			}
		}

		private bool ShouldSerializebackflow_level()
		{
			return this.backflow_levelSpecified;
		}

		private void Resetbackflow_level()
		{
			this.backflow_levelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _is_backflow_server;

		private uint? _backflow_level;

		private IExtension extensionObject;
	}
}
