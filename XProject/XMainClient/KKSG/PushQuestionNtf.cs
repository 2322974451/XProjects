using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PushQuestionNtf")]
	[Serializable]
	public class PushQuestionNtf : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "serialNum", DataFormat = DataFormat.TwosComplement)]
		public uint serialNum
		{
			get
			{
				return this._serialNum ?? 0U;
			}
			set
			{
				this._serialNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool serialNumSpecified
		{
			get
			{
				return this._serialNum != null;
			}
			set
			{
				bool flag = value == (this._serialNum == null);
				if (flag)
				{
					this._serialNum = (value ? new uint?(this.serialNum) : null);
				}
			}
		}

		private bool ShouldSerializeserialNum()
		{
			return this.serialNumSpecified;
		}

		private void ResetserialNum()
		{
			this.serialNumSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _qid;

		private uint? _serialNum;

		private IExtension extensionObject;
	}
}
