using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarBuffArg")]
	[Serializable]
	public class ResWarBuffArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "nParam", DataFormat = DataFormat.TwosComplement)]
		public uint nParam
		{
			get
			{
				return this._nParam ?? 0U;
			}
			set
			{
				this._nParam = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nParamSpecified
		{
			get
			{
				return this._nParam != null;
			}
			set
			{
				bool flag = value == (this._nParam == null);
				if (flag)
				{
					this._nParam = (value ? new uint?(this.nParam) : null);
				}
			}
		}

		private bool ShouldSerializenParam()
		{
			return this.nParamSpecified;
		}

		private void ResetnParam()
		{
			this.nParamSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _nParam;

		private IExtension extensionObject;
	}
}
