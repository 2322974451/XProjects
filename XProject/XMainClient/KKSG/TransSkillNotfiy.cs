using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TransSkillNotfiy")]
	[Serializable]
	public class TransSkillNotfiy : IExtensible
	{

		[ProtoMember(1, Name = "skillhash", DataFormat = DataFormat.TwosComplement)]
		public List<uint> skillhash
		{
			get
			{
				return this._skillhash;
			}
		}

		[ProtoMember(2, Name = "skilllevel", DataFormat = DataFormat.TwosComplement)]
		public List<uint> skilllevel
		{
			get
			{
				return this._skilllevel;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "isincreasing", DataFormat = DataFormat.Default)]
		public bool isincreasing
		{
			get
			{
				return this._isincreasing ?? false;
			}
			set
			{
				this._isincreasing = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isincreasingSpecified
		{
			get
			{
				return this._isincreasing != null;
			}
			set
			{
				bool flag = value == (this._isincreasing == null);
				if (flag)
				{
					this._isincreasing = (value ? new bool?(this.isincreasing) : null);
				}
			}
		}

		private bool ShouldSerializeisincreasing()
		{
			return this.isincreasingSpecified;
		}

		private void Resetisincreasing()
		{
			this.isincreasingSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _skillhash = new List<uint>();

		private readonly List<uint> _skilllevel = new List<uint>();

		private bool? _isincreasing;

		private IExtension extensionObject;
	}
}
