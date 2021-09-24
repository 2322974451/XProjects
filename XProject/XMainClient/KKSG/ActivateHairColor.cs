using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ActivateHairColor")]
	[Serializable]
	public class ActivateHairColor : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "hair_id", DataFormat = DataFormat.TwosComplement)]
		public uint hair_id
		{
			get
			{
				return this._hair_id ?? 0U;
			}
			set
			{
				this._hair_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hair_idSpecified
		{
			get
			{
				return this._hair_id != null;
			}
			set
			{
				bool flag = value == (this._hair_id == null);
				if (flag)
				{
					this._hair_id = (value ? new uint?(this.hair_id) : null);
				}
			}
		}

		private bool ShouldSerializehair_id()
		{
			return this.hair_idSpecified;
		}

		private void Resethair_id()
		{
			this.hair_idSpecified = false;
		}

		[ProtoMember(2, Name = "hair_color_id", DataFormat = DataFormat.TwosComplement)]
		public List<uint> hair_color_id
		{
			get
			{
				return this._hair_color_id;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _hair_id;

		private readonly List<uint> _hair_color_id = new List<uint>();

		private IExtension extensionObject;
	}
}
