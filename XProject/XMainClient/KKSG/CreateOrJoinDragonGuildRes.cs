using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CreateOrJoinDragonGuildRes")]
	[Serializable]
	public class CreateOrJoinDragonGuildRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "dgid", DataFormat = DataFormat.TwosComplement)]
		public ulong dgid
		{
			get
			{
				return this._dgid ?? 0UL;
			}
			set
			{
				this._dgid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dgidSpecified
		{
			get
			{
				return this._dgid != null;
			}
			set
			{
				bool flag = value == (this._dgid == null);
				if (flag)
				{
					this._dgid = (value ? new ulong?(this.dgid) : null);
				}
			}
		}

		private bool ShouldSerializedgid()
		{
			return this.dgidSpecified;
		}

		private void Resetdgid()
		{
			this.dgidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "cdtime", DataFormat = DataFormat.TwosComplement)]
		public uint cdtime
		{
			get
			{
				return this._cdtime ?? 0U;
			}
			set
			{
				this._cdtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cdtimeSpecified
		{
			get
			{
				return this._cdtime != null;
			}
			set
			{
				bool flag = value == (this._cdtime == null);
				if (flag)
				{
					this._cdtime = (value ? new uint?(this.cdtime) : null);
				}
			}
		}

		private bool ShouldSerializecdtime()
		{
			return this.cdtimeSpecified;
		}

		private void Resetcdtime()
		{
			this.cdtimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private ulong? _dgid;

		private string _name;

		private uint? _cdtime;

		private IExtension extensionObject;
	}
}
