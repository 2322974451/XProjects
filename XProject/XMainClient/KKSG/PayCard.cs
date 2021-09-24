using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayCard")]
	[Serializable]
	public class PayCard : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "remainedCount", DataFormat = DataFormat.TwosComplement)]
		public uint remainedCount
		{
			get
			{
				return this._remainedCount ?? 0U;
			}
			set
			{
				this._remainedCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool remainedCountSpecified
		{
			get
			{
				return this._remainedCount != null;
			}
			set
			{
				bool flag = value == (this._remainedCount == null);
				if (flag)
				{
					this._remainedCount = (value ? new uint?(this.remainedCount) : null);
				}
			}
		}

		private bool ShouldSerializeremainedCount()
		{
			return this.remainedCountSpecified;
		}

		private void ResetremainedCount()
		{
			this.remainedCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "isGet", DataFormat = DataFormat.Default)]
		public bool isGet
		{
			get
			{
				return this._isGet ?? false;
			}
			set
			{
				this._isGet = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isGetSpecified
		{
			get
			{
				return this._isGet != null;
			}
			set
			{
				bool flag = value == (this._isGet == null);
				if (flag)
				{
					this._isGet = (value ? new bool?(this.isGet) : null);
				}
			}
		}

		private bool ShouldSerializeisGet()
		{
			return this.isGetSpecified;
		}

		private void ResetisGet()
		{
			this.isGetSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _type;

		private uint? _remainedCount;

		private bool? _isGet;

		private IExtension extensionObject;
	}
}
