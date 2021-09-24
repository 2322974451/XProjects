using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CrossGvgOperArg")]
	[Serializable]
	public class CrossGvgOperArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public CrossGvgOperType type
		{
			get
			{
				return this._type ?? CrossGvgOperType.CGOT_EnterPointRace;
			}
			set
			{
				this._type = new CrossGvgOperType?(value);
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
					this._type = (value ? new CrossGvgOperType?(this.type) : null);
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

		[ProtoMember(2, Name = "support_guildid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> support_guildid
		{
			get
			{
				return this._support_guildid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private CrossGvgOperType? _type;

		private readonly List<ulong> _support_guildid = new List<ulong>();

		private IExtension extensionObject;
	}
}
