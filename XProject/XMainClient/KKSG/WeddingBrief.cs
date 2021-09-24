using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeddingBrief")]
	[Serializable]
	public class WeddingBrief : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "weddingid", DataFormat = DataFormat.TwosComplement)]
		public ulong weddingid
		{
			get
			{
				return this._weddingid ?? 0UL;
			}
			set
			{
				this._weddingid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weddingidSpecified
		{
			get
			{
				return this._weddingid != null;
			}
			set
			{
				bool flag = value == (this._weddingid == null);
				if (flag)
				{
					this._weddingid = (value ? new ulong?(this.weddingid) : null);
				}
			}
		}

		private bool ShouldSerializeweddingid()
		{
			return this.weddingidSpecified;
		}

		private void Resetweddingid()
		{
			this.weddingidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingType type
		{
			get
			{
				return this._type ?? WeddingType.WeddingType_Normal;
			}
			set
			{
				this._type = new WeddingType?(value);
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
					this._type = (value ? new WeddingType?(this.type) : null);
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

		[ProtoMember(3, IsRequired = false, Name = "role1", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeddingRoleBrief role1
		{
			get
			{
				return this._role1;
			}
			set
			{
				this._role1 = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "role2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeddingRoleBrief role2
		{
			get
			{
				return this._role2;
			}
			set
			{
				this._role2 = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public WeddingState state
		{
			get
			{
				return this._state ?? WeddingState.WeddingState_Prepare;
			}
			set
			{
				this._state = new WeddingState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new WeddingState?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _weddingid;

		private WeddingType? _type;

		private WeddingRoleBrief _role1 = null;

		private WeddingRoleBrief _role2 = null;

		private WeddingState? _state;

		private uint? _lefttime;

		private IExtension extensionObject;
	}
}
