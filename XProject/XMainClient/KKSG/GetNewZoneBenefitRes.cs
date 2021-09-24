using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetNewZoneBenefitRes")]
	[Serializable]
	public class GetNewZoneBenefitRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "is_open", DataFormat = DataFormat.Default)]
		public bool is_open
		{
			get
			{
				return this._is_open ?? false;
			}
			set
			{
				this._is_open = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_openSpecified
		{
			get
			{
				return this._is_open != null;
			}
			set
			{
				bool flag = value == (this._is_open == null);
				if (flag)
				{
					this._is_open = (value ? new bool?(this.is_open) : null);
				}
			}
		}

		private bool ShouldSerializeis_open()
		{
			return this.is_openSpecified;
		}

		private void Resetis_open()
		{
			this.is_openSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "has_select", DataFormat = DataFormat.Default)]
		public bool has_select
		{
			get
			{
				return this._has_select ?? false;
			}
			set
			{
				this._has_select = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool has_selectSpecified
		{
			get
			{
				return this._has_select != null;
			}
			set
			{
				bool flag = value == (this._has_select == null);
				if (flag)
				{
					this._has_select = (value ? new bool?(this.has_select) : null);
				}
			}
		}

		private bool ShouldSerializehas_select()
		{
			return this.has_selectSpecified;
		}

		private void Resethas_select()
		{
			this.has_selectSpecified = false;
		}

		[ProtoMember(4, Name = "roles", DataFormat = DataFormat.Default)]
		public List<ZoneRoleInfo> roles
		{
			get
			{
				return this._roles;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "select_roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong select_roleid
		{
			get
			{
				return this._select_roleid ?? 0UL;
			}
			set
			{
				this._select_roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool select_roleidSpecified
		{
			get
			{
				return this._select_roleid != null;
			}
			set
			{
				bool flag = value == (this._select_roleid == null);
				if (flag)
				{
					this._select_roleid = (value ? new ulong?(this.select_roleid) : null);
				}
			}
		}

		private bool ShouldSerializeselect_roleid()
		{
			return this.select_roleidSpecified;
		}

		private void Resetselect_roleid()
		{
			this.select_roleidSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "total_paycnt", DataFormat = DataFormat.TwosComplement)]
		public uint total_paycnt
		{
			get
			{
				return this._total_paycnt ?? 0U;
			}
			set
			{
				this._total_paycnt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool total_paycntSpecified
		{
			get
			{
				return this._total_paycnt != null;
			}
			set
			{
				bool flag = value == (this._total_paycnt == null);
				if (flag)
				{
					this._total_paycnt = (value ? new uint?(this.total_paycnt) : null);
				}
			}
		}

		private bool ShouldSerializetotal_paycnt()
		{
			return this.total_paycntSpecified;
		}

		private void Resettotal_paycnt()
		{
			this.total_paycntSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private bool? _is_open;

		private bool? _has_select;

		private readonly List<ZoneRoleInfo> _roles = new List<ZoneRoleInfo>();

		private ulong? _select_roleid;

		private uint? _total_paycnt;

		private IExtension extensionObject;
	}
}
