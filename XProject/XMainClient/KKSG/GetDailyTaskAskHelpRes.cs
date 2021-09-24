using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDailyTaskAskHelpRes")]
	[Serializable]
	public class GetDailyTaskAskHelpRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "help_num", DataFormat = DataFormat.TwosComplement)]
		public uint help_num
		{
			get
			{
				return this._help_num ?? 0U;
			}
			set
			{
				this._help_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool help_numSpecified
		{
			get
			{
				return this._help_num != null;
			}
			set
			{
				bool flag = value == (this._help_num == null);
				if (flag)
				{
					this._help_num = (value ? new uint?(this.help_num) : null);
				}
			}
		}

		private bool ShouldSerializehelp_num()
		{
			return this.help_numSpecified;
		}

		private void Resethelp_num()
		{
			this.help_numSpecified = false;
		}

		[ProtoMember(3, Name = "askinfos", DataFormat = DataFormat.Default)]
		public List<DailyTaskRefreshRoleInfo> askinfos
		{
			get
			{
				return this._askinfos;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "luck", DataFormat = DataFormat.TwosComplement)]
		public uint luck
		{
			get
			{
				return this._luck ?? 0U;
			}
			set
			{
				this._luck = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool luckSpecified
		{
			get
			{
				return this._luck != null;
			}
			set
			{
				bool flag = value == (this._luck == null);
				if (flag)
				{
					this._luck = (value ? new uint?(this.luck) : null);
				}
			}
		}

		private bool ShouldSerializeluck()
		{
			return this.luckSpecified;
		}

		private void Resetluck()
		{
			this.luckSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _help_num;

		private readonly List<DailyTaskRefreshRoleInfo> _askinfos = new List<DailyTaskRefreshRoleInfo>();

		private uint? _luck;

		private IExtension extensionObject;
	}
}
