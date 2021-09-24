using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGrowthFundTimeRes")]
	[Serializable]
	public class GetGrowthFundTimeRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "err", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode err
		{
			get
			{
				return this._err ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._err = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errSpecified
		{
			get
			{
				return this._err != null;
			}
			set
			{
				bool flag = value == (this._err == null);
				if (flag)
				{
					this._err = (value ? new ErrorCode?(this.err) : null);
				}
			}
		}

		private bool ShouldSerializeerr()
		{
			return this.errSpecified;
		}

		private void Reseterr()
		{
			this.errSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _lefttime;

		private ErrorCode? _err;

		private IExtension extensionObject;
	}
}
