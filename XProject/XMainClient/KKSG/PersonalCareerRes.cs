using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PersonalCareerRes")]
	[Serializable]
	public class PersonalCareerRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "home_page", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PersonalHomePage home_page
		{
			get
			{
				return this._home_page;
			}
			set
			{
				this._home_page = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "pvp_info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PVPInformation pvp_info
		{
			get
			{
				return this._pvp_info;
			}
			set
			{
				this._pvp_info = value;
			}
		}

		[ProtoMember(4, Name = "system_status", DataFormat = DataFormat.Default)]
		public List<bool> system_status
		{
			get
			{
				return this._system_status;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "trophy_data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public StageTrophy trophy_data
		{
			get
			{
				return this._trophy_data;
			}
			set
			{
				this._trophy_data = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private PersonalHomePage _home_page = null;

		private PVPInformation _pvp_info = null;

		private readonly List<bool> _system_status = new List<bool>();

		private StageTrophy _trophy_data = null;

		private IExtension extensionObject;
	}
}
