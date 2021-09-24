using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FetchAchiveRes")]
	[Serializable]
	public class FetchAchiveRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "Result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode Result
		{
			get
			{
				return this._Result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._Result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ResultSpecified
		{
			get
			{
				return this._Result != null;
			}
			set
			{
				bool flag = value == (this._Result == null);
				if (flag)
				{
					this._Result = (value ? new ErrorCode?(this.Result) : null);
				}
			}
		}

		private bool ShouldSerializeResult()
		{
			return this.ResultSpecified;
		}

		private void ResetResult()
		{
			this.ResultSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _Result;

		private IExtension extensionObject;
	}
}
