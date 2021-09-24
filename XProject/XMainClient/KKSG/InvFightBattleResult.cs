using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InvFightBattleResult")]
	[Serializable]
	public class InvFightBattleResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "resulttype", DataFormat = DataFormat.TwosComplement)]
		public PkResultType resulttype
		{
			get
			{
				return this._resulttype ?? PkResultType.PkResult_Win;
			}
			set
			{
				this._resulttype = new PkResultType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resulttypeSpecified
		{
			get
			{
				return this._resulttype != null;
			}
			set
			{
				bool flag = value == (this._resulttype == null);
				if (flag)
				{
					this._resulttype = (value ? new PkResultType?(this.resulttype) : null);
				}
			}
		}

		private bool ShouldSerializeresulttype()
		{
			return this.resulttypeSpecified;
		}

		private void Resetresulttype()
		{
			this.resulttypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "opname", DataFormat = DataFormat.Default)]
		public string opname
		{
			get
			{
				return this._opname ?? "";
			}
			set
			{
				this._opname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opnameSpecified
		{
			get
			{
				return this._opname != null;
			}
			set
			{
				bool flag = value == (this._opname == null);
				if (flag)
				{
					this._opname = (value ? this.opname : null);
				}
			}
		}

		private bool ShouldSerializeopname()
		{
			return this.opnameSpecified;
		}

		private void Resetopname()
		{
			this.opnameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PkResultType? _resulttype;

		private string _opname;

		private IExtension extensionObject;
	}
}
