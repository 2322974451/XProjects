using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Festival520Data")]
	[Serializable]
	public class Festival520Data : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "loveValue", DataFormat = DataFormat.TwosComplement)]
		public uint loveValue
		{
			get
			{
				return this._loveValue ?? 0U;
			}
			set
			{
				this._loveValue = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool loveValueSpecified
		{
			get
			{
				return this._loveValue != null;
			}
			set
			{
				bool flag = value == (this._loveValue == null);
				if (flag)
				{
					this._loveValue = (value ? new uint?(this.loveValue) : null);
				}
			}
		}

		private bool ShouldSerializeloveValue()
		{
			return this.loveValueSpecified;
		}

		private void ResetloveValue()
		{
			this.loveValueSpecified = false;
		}

		[ProtoMember(2, Name = "alreadyGet", DataFormat = DataFormat.Default)]
		public List<bool> alreadyGet
		{
			get
			{
				return this._alreadyGet;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _loveValue;

		private readonly List<bool> _alreadyGet = new List<bool>();

		private IExtension extensionObject;
	}
}
