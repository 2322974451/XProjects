using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDailyTaskRewardRes")]
	[Serializable]
	public class GetDailyTaskRewardRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "code", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode code
		{
			get
			{
				return this._code ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._code = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool codeSpecified
		{
			get
			{
				return this._code != null;
			}
			set
			{
				bool flag = value == (this._code == null);
				if (flag)
				{
					this._code = (value ? new ErrorCode?(this.code) : null);
				}
			}
		}

		private bool ShouldSerializecode()
		{
			return this.codeSpecified;
		}

		private void Resetcode()
		{
			this.codeSpecified = false;
		}

		[ProtoMember(2, Name = "task", DataFormat = DataFormat.Default)]
		public List<DailyTaskInfo> task
		{
			get
			{
				return this._task;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _code;

		private readonly List<DailyTaskInfo> _task = new List<DailyTaskInfo>();

		private IExtension extensionObject;
	}
}
