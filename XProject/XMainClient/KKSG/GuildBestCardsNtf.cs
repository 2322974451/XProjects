using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildBestCardsNtf")]
	[Serializable]
	public class GuildBestCardsNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "bestresult", DataFormat = DataFormat.TwosComplement)]
		public uint bestresult
		{
			get
			{
				return this._bestresult ?? 0U;
			}
			set
			{
				this._bestresult = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bestresultSpecified
		{
			get
			{
				return this._bestresult != null;
			}
			set
			{
				bool flag = value == (this._bestresult == null);
				if (flag)
				{
					this._bestresult = (value ? new uint?(this.bestresult) : null);
				}
			}
		}

		private bool ShouldSerializebestresult()
		{
			return this.bestresultSpecified;
		}

		private void Resetbestresult()
		{
			this.bestresultSpecified = false;
		}

		[ProtoMember(2, Name = "bestcards", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bestcards
		{
			get
			{
				return this._bestcards;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "bestrole", DataFormat = DataFormat.Default)]
		public string bestrole
		{
			get
			{
				return this._bestrole ?? "";
			}
			set
			{
				this._bestrole = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bestroleSpecified
		{
			get
			{
				return this._bestrole != null;
			}
			set
			{
				bool flag = value == (this._bestrole == null);
				if (flag)
				{
					this._bestrole = (value ? this.bestrole : null);
				}
			}
		}

		private bool ShouldSerializebestrole()
		{
			return this.bestroleSpecified;
		}

		private void Resetbestrole()
		{
			this.bestroleSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
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
					this._type = (value ? new uint?(this.type) : null);
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

		[ProtoMember(5, IsRequired = false, Name = "match_type", DataFormat = DataFormat.TwosComplement)]
		public uint match_type
		{
			get
			{
				return this._match_type ?? 0U;
			}
			set
			{
				this._match_type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool match_typeSpecified
		{
			get
			{
				return this._match_type != null;
			}
			set
			{
				bool flag = value == (this._match_type == null);
				if (flag)
				{
					this._match_type = (value ? new uint?(this.match_type) : null);
				}
			}
		}

		private bool ShouldSerializematch_type()
		{
			return this.match_typeSpecified;
		}

		private void Resetmatch_type()
		{
			this.match_typeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _bestresult;

		private readonly List<uint> _bestcards = new List<uint>();

		private string _bestrole;

		private uint? _type;

		private uint? _match_type;

		private IExtension extensionObject;
	}
}
