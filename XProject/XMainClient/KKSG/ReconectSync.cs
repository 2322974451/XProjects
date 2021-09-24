using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReconectSync")]
	[Serializable]
	public class ReconectSync : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "self", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleAllInfo self
		{
			get
			{
				return this._self;
			}
			set
			{
				this._self = value;
			}
		}

		[ProtoMember(2, Name = "units", DataFormat = DataFormat.Default)]
		public List<UnitAppearance> units
		{
			get
			{
				return this._units;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "selfAppearance", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = false, Name = "deathinfo", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = false, Name = "isautofight", DataFormat = DataFormat.Default)]
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

		[ProtoMember(6, IsRequired = false, Name = "scene", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ReconnectScene scene
		{
			get
			{
				return this._scene;
			}
			set
			{
				this._scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RoleAllInfo _self = null;

		private readonly List<UnitAppearance> _units = new List<UnitAppearance>();

		private UnitAppearance _selfAppearance = null;

		private DeathInfo _deathinfo = null;

		private bool? _isautofight;

		private ReconnectScene _scene = null;

		private IExtension extensionObject;
	}
}
