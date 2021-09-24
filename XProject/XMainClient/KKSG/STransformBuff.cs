using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "STransformBuff")]
	[Serializable]
	public class STransformBuff : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ispassive", DataFormat = DataFormat.Default)]
		public bool ispassive
		{
			get
			{
				return this._ispassive ?? false;
			}
			set
			{
				this._ispassive = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ispassiveSpecified
		{
			get
			{
				return this._ispassive != null;
			}
			set
			{
				bool flag = value == (this._ispassive == null);
				if (flag)
				{
					this._ispassive = (value ? new bool?(this.ispassive) : null);
				}
			}
		}

		private bool ShouldSerializeispassive()
		{
			return this.ispassiveSpecified;
		}

		private void Resetispassive()
		{
			this.ispassiveSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "iseffecting", DataFormat = DataFormat.Default)]
		public bool iseffecting
		{
			get
			{
				return this._iseffecting ?? false;
			}
			set
			{
				this._iseffecting = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iseffectingSpecified
		{
			get
			{
				return this._iseffecting != null;
			}
			set
			{
				bool flag = value == (this._iseffecting == null);
				if (flag)
				{
					this._iseffecting = (value ? new bool?(this.iseffecting) : null);
				}
			}
		}

		private bool ShouldSerializeiseffecting()
		{
			return this.iseffectingSpecified;
		}

		private void Resetiseffecting()
		{
			this.iseffectingSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "buff", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Buff buff
		{
			get
			{
				return this._buff;
			}
			set
			{
				this._buff = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _ispassive;

		private bool? _iseffecting;

		private Buff _buff = null;

		private IExtension extensionObject;
	}
}
