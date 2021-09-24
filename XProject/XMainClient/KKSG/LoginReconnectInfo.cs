using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginReconnectInfo")]
	[Serializable]
	public class LoginReconnectInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "scenetemplateid", DataFormat = DataFormat.TwosComplement)]
		public uint scenetemplateid
		{
			get
			{
				return this._scenetemplateid ?? 0U;
			}
			set
			{
				this._scenetemplateid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scenetemplateidSpecified
		{
			get
			{
				return this._scenetemplateid != null;
			}
			set
			{
				bool flag = value == (this._scenetemplateid == null);
				if (flag)
				{
					this._scenetemplateid = (value ? new uint?(this.scenetemplateid) : null);
				}
			}
		}

		private bool ShouldSerializescenetemplateid()
		{
			return this.scenetemplateidSpecified;
		}

		private void Resetscenetemplateid()
		{
			this.scenetemplateidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "scenetime", DataFormat = DataFormat.TwosComplement)]
		public uint scenetime
		{
			get
			{
				return this._scenetime ?? 0U;
			}
			set
			{
				this._scenetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scenetimeSpecified
		{
			get
			{
				return this._scenetime != null;
			}
			set
			{
				bool flag = value == (this._scenetime == null);
				if (flag)
				{
					this._scenetime = (value ? new uint?(this.scenetime) : null);
				}
			}
		}

		private bool ShouldSerializescenetime()
		{
			return this.scenetimeSpecified;
		}

		private void Resetscenetime()
		{
			this.scenetimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _scenetemplateid;

		private uint? _scenetime;

		private IExtension extensionObject;
	}
}
