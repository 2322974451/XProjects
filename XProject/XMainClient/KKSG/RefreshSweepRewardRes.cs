using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RefreshSweepRewardRes")]
	[Serializable]
	public class RefreshSweepRewardRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "refreshResult", DataFormat = DataFormat.TwosComplement)]
		public int refreshResult
		{
			get
			{
				return this._refreshResult ?? 0;
			}
			set
			{
				this._refreshResult = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool refreshResultSpecified
		{
			get
			{
				return this._refreshResult != null;
			}
			set
			{
				bool flag = value == (this._refreshResult == null);
				if (flag)
				{
					this._refreshResult = (value ? new int?(this.refreshResult) : null);
				}
			}
		}

		private bool ShouldSerializerefreshResult()
		{
			return this.refreshResultSpecified;
		}

		private void ResetrefreshResult()
		{
			this.refreshResultSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private int? _refreshResult;

		private IExtension extensionObject;
	}
}
