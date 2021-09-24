using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TssSdkAntiData")]
	[Serializable]
	public class TssSdkAntiData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "anti_data", DataFormat = DataFormat.Default)]
		public byte[] anti_data
		{
			get
			{
				return this._anti_data ?? null;
			}
			set
			{
				this._anti_data = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool anti_dataSpecified
		{
			get
			{
				return this._anti_data != null;
			}
			set
			{
				bool flag = value == (this._anti_data == null);
				if (flag)
				{
					this._anti_data = (value ? this.anti_data : null);
				}
			}
		}

		private bool ShouldSerializeanti_data()
		{
			return this.anti_dataSpecified;
		}

		private void Resetanti_data()
		{
			this.anti_dataSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "anti_data_len", DataFormat = DataFormat.TwosComplement)]
		public uint anti_data_len
		{
			get
			{
				return this._anti_data_len ?? 0U;
			}
			set
			{
				this._anti_data_len = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool anti_data_lenSpecified
		{
			get
			{
				return this._anti_data_len != null;
			}
			set
			{
				bool flag = value == (this._anti_data_len == null);
				if (flag)
				{
					this._anti_data_len = (value ? new uint?(this.anti_data_len) : null);
				}
			}
		}

		private bool ShouldSerializeanti_data_len()
		{
			return this.anti_data_lenSpecified;
		}

		private void Resetanti_data_len()
		{
			this.anti_data_lenSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private byte[] _anti_data;

		private uint? _anti_data_len;

		private IExtension extensionObject;
	}
}
