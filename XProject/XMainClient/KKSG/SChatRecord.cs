using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SChatRecord")]
	[Serializable]
	public class SChatRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "lastupdatetime", DataFormat = DataFormat.TwosComplement)]
		public uint lastupdatetime
		{
			get
			{
				return this._lastupdatetime ?? 0U;
			}
			set
			{
				this._lastupdatetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastupdatetimeSpecified
		{
			get
			{
				return this._lastupdatetime != null;
			}
			set
			{
				bool flag = value == (this._lastupdatetime == null);
				if (flag)
				{
					this._lastupdatetime = (value ? new uint?(this.lastupdatetime) : null);
				}
			}
		}

		private bool ShouldSerializelastupdatetime()
		{
			return this.lastupdatetimeSpecified;
		}

		private void Resetlastupdatetime()
		{
			this.lastupdatetimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "worldchattimes", DataFormat = DataFormat.TwosComplement)]
		public uint worldchattimes
		{
			get
			{
				return this._worldchattimes ?? 0U;
			}
			set
			{
				this._worldchattimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool worldchattimesSpecified
		{
			get
			{
				return this._worldchattimes != null;
			}
			set
			{
				bool flag = value == (this._worldchattimes == null);
				if (flag)
				{
					this._worldchattimes = (value ? new uint?(this.worldchattimes) : null);
				}
			}
		}

		private bool ShouldSerializeworldchattimes()
		{
			return this.worldchattimesSpecified;
		}

		private void Resetworldchattimes()
		{
			this.worldchattimesSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _lastupdatetime;

		private uint? _worldchattimes;

		private IExtension extensionObject;
	}
}
