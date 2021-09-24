using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DeathInfo")]
	[Serializable]
	public class DeathInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "Killer", DataFormat = DataFormat.TwosComplement)]
		public ulong Killer
		{
			get
			{
				return this._Killer ?? 0UL;
			}
			set
			{
				this._Killer = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool KillerSpecified
		{
			get
			{
				return this._Killer != null;
			}
			set
			{
				bool flag = value == (this._Killer == null);
				if (flag)
				{
					this._Killer = (value ? new ulong?(this.Killer) : null);
				}
			}
		}

		private bool ShouldSerializeKiller()
		{
			return this.KillerSpecified;
		}

		private void ResetKiller()
		{
			this.KillerSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "uID", DataFormat = DataFormat.TwosComplement)]
		public ulong uID
		{
			get
			{
				return this._uID ?? 0UL;
			}
			set
			{
				this._uID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uIDSpecified
		{
			get
			{
				return this._uID != null;
			}
			set
			{
				bool flag = value == (this._uID == null);
				if (flag)
				{
					this._uID = (value ? new ulong?(this.uID) : null);
				}
			}
		}

		private bool ShouldSerializeuID()
		{
			return this.uIDSpecified;
		}

		private void ResetuID()
		{
			this.uIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "showSlowCamera", DataFormat = DataFormat.Default)]
		public bool showSlowCamera
		{
			get
			{
				return this._showSlowCamera ?? false;
			}
			set
			{
				this._showSlowCamera = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool showSlowCameraSpecified
		{
			get
			{
				return this._showSlowCamera != null;
			}
			set
			{
				bool flag = value == (this._showSlowCamera == null);
				if (flag)
				{
					this._showSlowCamera = (value ? new bool?(this.showSlowCamera) : null);
				}
			}
		}

		private bool ShouldSerializeshowSlowCamera()
		{
			return this.showSlowCameraSpecified;
		}

		private void ResetshowSlowCamera()
		{
			this.showSlowCameraSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ReviveType type
		{
			get
			{
				return this._type ?? ReviveType.ReviveNone;
			}
			set
			{
				this._type = new ReviveType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new ReviveType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "revivecount", DataFormat = DataFormat.TwosComplement)]
		public uint revivecount
		{
			get
			{
				return this._revivecount ?? 0U;
			}
			set
			{
				this._revivecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool revivecountSpecified
		{
			get
			{
				return this._revivecount != null;
			}
			set
			{
				bool flag = value == (this._revivecount == null);
				if (flag)
				{
					this._revivecount = (value ? new uint?(this.revivecount) : null);
				}
			}
		}

		private bool ShouldSerializerevivecount()
		{
			return this.revivecountSpecified;
		}

		private void Resetrevivecount()
		{
			this.revivecountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "costrevivecount", DataFormat = DataFormat.TwosComplement)]
		public uint costrevivecount
		{
			get
			{
				return this._costrevivecount ?? 0U;
			}
			set
			{
				this._costrevivecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool costrevivecountSpecified
		{
			get
			{
				return this._costrevivecount != null;
			}
			set
			{
				bool flag = value == (this._costrevivecount == null);
				if (flag)
				{
					this._costrevivecount = (value ? new uint?(this.costrevivecount) : null);
				}
			}
		}

		private bool ShouldSerializecostrevivecount()
		{
			return this.costrevivecountSpecified;
		}

		private void Resetcostrevivecount()
		{
			this.costrevivecountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _Killer;

		private ulong? _uID;

		private bool? _showSlowCamera;

		private ReviveType? _type;

		private uint? _revivecount;

		private uint? _costrevivecount;

		private IExtension extensionObject;
	}
}
