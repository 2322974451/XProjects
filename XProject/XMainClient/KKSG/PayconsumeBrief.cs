using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayconsumeBrief")]
	[Serializable]
	public class PayconsumeBrief : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ts", DataFormat = DataFormat.TwosComplement)]
		public uint ts
		{
			get
			{
				return this._ts ?? 0U;
			}
			set
			{
				this._ts = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tsSpecified
		{
			get
			{
				return this._ts != null;
			}
			set
			{
				bool flag = value == (this._ts == null);
				if (flag)
				{
					this._ts = (value ? new uint?(this.ts) : null);
				}
			}
		}

		private bool ShouldSerializets()
		{
			return this.tsSpecified;
		}

		private void Resetts()
		{
			this.tsSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "billno", DataFormat = DataFormat.Default)]
		public string billno
		{
			get
			{
				return this._billno ?? "";
			}
			set
			{
				this._billno = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool billnoSpecified
		{
			get
			{
				return this._billno != null;
			}
			set
			{
				bool flag = value == (this._billno == null);
				if (flag)
				{
					this._billno = (value ? this.billno : null);
				}
			}
		}

		private bool ShouldSerializebillno()
		{
			return this.billnoSpecified;
		}

		private void Resetbillno()
		{
			this.billnoSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _ts;

		private string _billno;

		private IExtension extensionObject;
	}
}
