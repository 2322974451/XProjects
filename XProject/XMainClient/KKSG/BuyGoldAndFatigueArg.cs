using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuyGoldAndFatigueArg")]
	[Serializable]
	public class BuyGoldAndFatigueArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public buyextype type
		{
			get
			{
				return this._type ?? buyextype.DIAMONE_BUY_DRAGONCOIN;
			}
			set
			{
				this._type = new buyextype?(value);
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
					this._type = (value ? new buyextype?(this.type) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "fatigueID", DataFormat = DataFormat.TwosComplement)]
		public uint fatigueID
		{
			get
			{
				return this._fatigueID ?? 0U;
			}
			set
			{
				this._fatigueID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fatigueIDSpecified
		{
			get
			{
				return this._fatigueID != null;
			}
			set
			{
				bool flag = value == (this._fatigueID == null);
				if (flag)
				{
					this._fatigueID = (value ? new uint?(this.fatigueID) : null);
				}
			}
		}

		private bool ShouldSerializefatigueID()
		{
			return this.fatigueIDSpecified;
		}

		private void ResetfatigueID()
		{
			this.fatigueIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		private void Resetcount()
		{
			this.countSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private buyextype? _type;

		private uint? _fatigueID;

		private uint? _count;

		private IExtension extensionObject;
	}
}
