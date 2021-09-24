using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LuckyActivity")]
	[Serializable]
	public class LuckyActivity : IExtensible
	{

		[ProtoMember(1, Name = "itemrecord", DataFormat = DataFormat.Default)]
		public List<ItemRecord> itemrecord
		{
			get
			{
				return this._itemrecord;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
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
					this._state = (value ? new uint?(this.state) : null);
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

		[ProtoMember(3, IsRequired = false, Name = "ispay", DataFormat = DataFormat.Default)]
		public bool ispay
		{
			get
			{
				return this._ispay ?? false;
			}
			set
			{
				this._ispay = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ispaySpecified
		{
			get
			{
				return this._ispay != null;
			}
			set
			{
				bool flag = value == (this._ispay == null);
				if (flag)
				{
					this._ispay = (value ? new bool?(this.ispay) : null);
				}
			}
		}

		private bool ShouldSerializeispay()
		{
			return this.ispaySpecified;
		}

		private void Resetispay()
		{
			this.ispaySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ItemRecord> _itemrecord = new List<ItemRecord>();

		private uint? _state;

		private bool? _ispay;

		private IExtension extensionObject;
	}
}
