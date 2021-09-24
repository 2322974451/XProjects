using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildCamPartyRandItemArg")]
	[Serializable]
	public class GetGuildCamPartyRandItemArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "query_type", DataFormat = DataFormat.TwosComplement)]
		public uint query_type
		{
			get
			{
				return this._query_type ?? 0U;
			}
			set
			{
				this._query_type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool query_typeSpecified
		{
			get
			{
				return this._query_type != null;
			}
			set
			{
				bool flag = value == (this._query_type == null);
				if (flag)
				{
					this._query_type = (value ? new uint?(this.query_type) : null);
				}
			}
		}

		private bool ShouldSerializequery_type()
		{
			return this.query_typeSpecified;
		}

		private void Resetquery_type()
		{
			this.query_typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "npc_id", DataFormat = DataFormat.TwosComplement)]
		public uint npc_id
		{
			get
			{
				return this._npc_id ?? 0U;
			}
			set
			{
				this._npc_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool npc_idSpecified
		{
			get
			{
				return this._npc_id != null;
			}
			set
			{
				bool flag = value == (this._npc_id == null);
				if (flag)
				{
					this._npc_id = (value ? new uint?(this.npc_id) : null);
				}
			}
		}

		private bool ShouldSerializenpc_id()
		{
			return this.npc_idSpecified;
		}

		private void Resetnpc_id()
		{
			this.npc_idSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "sprite_id", DataFormat = DataFormat.TwosComplement)]
		public uint sprite_id
		{
			get
			{
				return this._sprite_id ?? 0U;
			}
			set
			{
				this._sprite_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sprite_idSpecified
		{
			get
			{
				return this._sprite_id != null;
			}
			set
			{
				bool flag = value == (this._sprite_id == null);
				if (flag)
				{
					this._sprite_id = (value ? new uint?(this.sprite_id) : null);
				}
			}
		}

		private bool ShouldSerializesprite_id()
		{
			return this.sprite_idSpecified;
		}

		private void Resetsprite_id()
		{
			this.sprite_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _query_type;

		private uint? _npc_id;

		private uint? _sprite_id;

		private IExtension extensionObject;
	}
}
