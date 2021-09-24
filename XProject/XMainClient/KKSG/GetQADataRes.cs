using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetQADataRes")]
	[Serializable]
	public class GetQADataRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "qid", DataFormat = DataFormat.TwosComplement)]
		public uint qid
		{
			get
			{
				return this._qid ?? 0U;
			}
			set
			{
				this._qid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool qidSpecified
		{
			get
			{
				return this._qid != null;
			}
			set
			{
				bool flag = value == (this._qid == null);
				if (flag)
				{
					this._qid = (value ? new uint?(this.qid) : null);
				}
			}
		}

		private bool ShouldSerializeqid()
		{
			return this.qidSpecified;
		}

		private void Resetqid()
		{
			this.qidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "serialnum", DataFormat = DataFormat.TwosComplement)]
		public uint serialnum
		{
			get
			{
				return this._serialnum ?? 0U;
			}
			set
			{
				this._serialnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool serialnumSpecified
		{
			get
			{
				return this._serialnum != null;
			}
			set
			{
				bool flag = value == (this._serialnum == null);
				if (flag)
				{
					this._serialnum = (value ? new uint?(this.serialnum) : null);
				}
			}
		}

		private bool ShouldSerializeserialnum()
		{
			return this.serialnumSpecified;
		}

		private void Resetserialnum()
		{
			this.serialnumSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public uint leftTime
		{
			get
			{
				return this._leftTime ?? 0U;
			}
			set
			{
				this._leftTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new uint?(this.leftTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
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

		private uint? _qid;

		private uint? _serialnum;

		private uint? _leftTime;

		private ErrorCode? _result;

		private IExtension extensionObject;
	}
}
