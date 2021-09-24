using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ExpFindBackInfo")]
	[Serializable]
	public class ExpFindBackInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ExpBackType type
		{
			get
			{
				return this._type ?? ExpBackType.EXPBACK_ABYSSS;
			}
			set
			{
				this._type = new ExpBackType?(value);
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
					this._type = (value ? new ExpBackType?(this.type) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "usedCount", DataFormat = DataFormat.TwosComplement)]
		public int usedCount
		{
			get
			{
				return this._usedCount ?? 0;
			}
			set
			{
				this._usedCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool usedCountSpecified
		{
			get
			{
				return this._usedCount != null;
			}
			set
			{
				bool flag = value == (this._usedCount == null);
				if (flag)
				{
					this._usedCount = (value ? new int?(this.usedCount) : null);
				}
			}
		}

		private bool ShouldSerializeusedCount()
		{
			return this.usedCountSpecified;
		}

		private void ResetusedCount()
		{
			this.usedCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ExpBackType? _type;

		private int? _usedCount;

		private IExtension extensionObject;
	}
}
