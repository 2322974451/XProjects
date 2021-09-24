using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildArenaHistory")]
	[Serializable]
	public class GuildArenaHistory : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "first", DataFormat = DataFormat.Default)]
		public string first
		{
			get
			{
				return this._first ?? "";
			}
			set
			{
				this._first = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool firstSpecified
		{
			get
			{
				return this._first != null;
			}
			set
			{
				bool flag = value == (this._first == null);
				if (flag)
				{
					this._first = (value ? this.first : null);
				}
			}
		}

		private bool ShouldSerializefirst()
		{
			return this.firstSpecified;
		}

		private void Resetfirst()
		{
			this.firstSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "second", DataFormat = DataFormat.Default)]
		public string second
		{
			get
			{
				return this._second ?? "";
			}
			set
			{
				this._second = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool secondSpecified
		{
			get
			{
				return this._second != null;
			}
			set
			{
				bool flag = value == (this._second == null);
				if (flag)
				{
					this._second = (value ? this.second : null);
				}
			}
		}

		private bool ShouldSerializesecond()
		{
			return this.secondSpecified;
		}

		private void Resetsecond()
		{
			this.secondSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _first;

		private string _second;

		private IExtension extensionObject;
	}
}
