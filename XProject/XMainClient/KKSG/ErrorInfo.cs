using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ErrorInfo")]
	[Serializable]
	public class ErrorInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorno", DataFormat = DataFormat.TwosComplement)]
		public uint errorno
		{
			get
			{
				return this._errorno ?? 0U;
			}
			set
			{
				this._errorno = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errornoSpecified
		{
			get
			{
				return this._errorno != null;
			}
			set
			{
				bool flag = value == (this._errorno == null);
				if (flag)
				{
					this._errorno = (value ? new uint?(this.errorno) : null);
				}
			}
		}

		private bool ShouldSerializeerrorno()
		{
			return this.errornoSpecified;
		}

		private void Reseterrorno()
		{
			this.errornoSpecified = false;
		}

		[ProtoMember(2, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public List<uint> param
		{
			get
			{
				return this._param;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "param64", DataFormat = DataFormat.TwosComplement)]
		public ulong param64
		{
			get
			{
				return this._param64 ?? 0UL;
			}
			set
			{
				this._param64 = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool param64Specified
		{
			get
			{
				return this._param64 != null;
			}
			set
			{
				bool flag = value == (this._param64 == null);
				if (flag)
				{
					this._param64 = (value ? new ulong?(this.param64) : null);
				}
			}
		}

		private bool ShouldSerializeparam64()
		{
			return this.param64Specified;
		}

		private void Resetparam64()
		{
			this.param64Specified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "istip", DataFormat = DataFormat.Default)]
		public bool istip
		{
			get
			{
				return this._istip ?? false;
			}
			set
			{
				this._istip = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool istipSpecified
		{
			get
			{
				return this._istip != null;
			}
			set
			{
				bool flag = value == (this._istip == null);
				if (flag)
				{
					this._istip = (value ? new bool?(this.istip) : null);
				}
			}
		}

		private bool ShouldSerializeistip()
		{
			return this.istipSpecified;
		}

		private void Resetistip()
		{
			this.istipSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _errorno;

		private readonly List<uint> _param = new List<uint>();

		private ulong? _param64;

		private bool? _istip;

		private IExtension extensionObject;
	}
}
