using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SRoleMultiReward")]
	[Serializable]
	public class SRoleMultiReward : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "day", DataFormat = DataFormat.TwosComplement)]
		public uint day
		{
			get
			{
				return this._day ?? 0U;
			}
			set
			{
				this._day = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daySpecified
		{
			get
			{
				return this._day != null;
			}
			set
			{
				bool flag = value == (this._day == null);
				if (flag)
				{
					this._day = (value ? new uint?(this.day) : null);
				}
			}
		}

		private bool ShouldSerializeday()
		{
			return this.daySpecified;
		}

		private void Resetday()
		{
			this.daySpecified = false;
		}

		[ProtoMember(2, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public List<uint> id
		{
			get
			{
				return this._id;
			}
		}

		[ProtoMember(3, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public List<uint> count
		{
			get
			{
				return this._count;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _day;

		private readonly List<uint> _id = new List<uint>();

		private readonly List<uint> _count = new List<uint>();

		private IExtension extensionObject;
	}
}
