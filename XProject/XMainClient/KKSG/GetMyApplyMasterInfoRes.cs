using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMyApplyMasterInfoRes")]
	[Serializable]
	public class GetMyApplyMasterInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(2, Name = "canApplyMasters", DataFormat = DataFormat.Default)]
		public List<OneMentorApplyMasterShow> canApplyMasters
		{
			get
			{
				return this._canApplyMasters;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "leftRefreshTime", DataFormat = DataFormat.TwosComplement)]
		public int leftRefreshTime
		{
			get
			{
				return this._leftRefreshTime ?? 0;
			}
			set
			{
				this._leftRefreshTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftRefreshTimeSpecified
		{
			get
			{
				return this._leftRefreshTime != null;
			}
			set
			{
				bool flag = value == (this._leftRefreshTime == null);
				if (flag)
				{
					this._leftRefreshTime = (value ? new int?(this.leftRefreshTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftRefreshTime()
		{
			return this.leftRefreshTimeSpecified;
		}

		private void ResetleftRefreshTime()
		{
			this.leftRefreshTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private readonly List<OneMentorApplyMasterShow> _canApplyMasters = new List<OneMentorApplyMasterShow>();

		private int? _leftRefreshTime;

		private IExtension extensionObject;
	}
}
