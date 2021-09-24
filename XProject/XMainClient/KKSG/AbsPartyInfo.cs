using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AbsPartyInfo")]
	[Serializable]
	public class AbsPartyInfo : IExtensible
	{

		[ProtoMember(1, Name = "aby", DataFormat = DataFormat.Default)]
		public List<AbsPartyBase> aby
		{
			get
			{
				return this._aby;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "abyssmailtime", DataFormat = DataFormat.TwosComplement)]
		public uint abyssmailtime
		{
			get
			{
				return this._abyssmailtime ?? 0U;
			}
			set
			{
				this._abyssmailtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool abyssmailtimeSpecified
		{
			get
			{
				return this._abyssmailtime != null;
			}
			set
			{
				bool flag = value == (this._abyssmailtime == null);
				if (flag)
				{
					this._abyssmailtime = (value ? new uint?(this.abyssmailtime) : null);
				}
			}
		}

		private bool ShouldSerializeabyssmailtime()
		{
			return this.abyssmailtimeSpecified;
		}

		private void Resetabyssmailtime()
		{
			this.abyssmailtimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<AbsPartyBase> _aby = new List<AbsPartyBase>();

		private uint? _abyssmailtime;

		private IExtension extensionObject;
	}
}
