using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginReconnectEnterSceneData")]
	[Serializable]
	public class LoginReconnectEnterSceneData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "selfAppearance", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearance selfAppearance
		{
			get
			{
				return this._selfAppearance;
			}
			set
			{
				this._selfAppearance = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "deathinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DeathInfo deathinfo
		{
			get
			{
				return this._deathinfo;
			}
			set
			{
				this._deathinfo = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "isautofight", DataFormat = DataFormat.Default)]
		public bool isautofight
		{
			get
			{
				return this._isautofight ?? false;
			}
			set
			{
				this._isautofight = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isautofightSpecified
		{
			get
			{
				return this._isautofight != null;
			}
			set
			{
				bool flag = value == (this._isautofight == null);
				if (flag)
				{
					this._isautofight = (value ? new bool?(this.isautofight) : null);
				}
			}
		}

		private bool ShouldSerializeisautofight()
		{
			return this.isautofightSpecified;
		}

		private void Resetisautofight()
		{
			this.isautofightSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private UnitAppearance _selfAppearance = null;

		private DeathInfo _deathinfo = null;

		private bool? _isautofight;

		private IExtension extensionObject;
	}
}
