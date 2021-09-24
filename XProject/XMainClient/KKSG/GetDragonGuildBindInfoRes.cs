using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDragonGuildBindInfoRes")]
	[Serializable]
	public class GetDragonGuildBindInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "bind_status", DataFormat = DataFormat.TwosComplement)]
		public GuildBindStatus bind_status
		{
			get
			{
				return this._bind_status ?? GuildBindStatus.GBS_NotBind;
			}
			set
			{
				this._bind_status = new GuildBindStatus?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bind_statusSpecified
		{
			get
			{
				return this._bind_status != null;
			}
			set
			{
				bool flag = value == (this._bind_status == null);
				if (flag)
				{
					this._bind_status = (value ? new GuildBindStatus?(this.bind_status) : null);
				}
			}
		}

		private bool ShouldSerializebind_status()
		{
			return this.bind_statusSpecified;
		}

		private void Resetbind_status()
		{
			this.bind_statusSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "group_name", DataFormat = DataFormat.Default)]
		public string group_name
		{
			get
			{
				return this._group_name ?? "";
			}
			set
			{
				this._group_name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool group_nameSpecified
		{
			get
			{
				return this._group_name != null;
			}
			set
			{
				bool flag = value == (this._group_name == null);
				if (flag)
				{
					this._group_name = (value ? this.group_name : null);
				}
			}
		}

		private bool ShouldSerializegroup_name()
		{
			return this.group_nameSpecified;
		}

		private void Resetgroup_name()
		{
			this.group_nameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GuildBindStatus? _bind_status;

		private string _group_name;

		private ErrorCode? _result;

		private IExtension extensionObject;
	}
}
