using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CommitAnswerNtf")]
	[Serializable]
	public class CommitAnswerNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "audiouid", DataFormat = DataFormat.TwosComplement)]
		public ulong audiouid
		{
			get
			{
				return this._audiouid ?? 0UL;
			}
			set
			{
				this._audiouid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audiouidSpecified
		{
			get
			{
				return this._audiouid != null;
			}
			set
			{
				bool flag = value == (this._audiouid == null);
				if (flag)
				{
					this._audiouid = (value ? new ulong?(this.audiouid) : null);
				}
			}
		}

		private bool ShouldSerializeaudiouid()
		{
			return this.audiouidSpecified;
		}

		private void Resetaudiouid()
		{
			this.audiouidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "answer", DataFormat = DataFormat.Default)]
		public string answer
		{
			get
			{
				return this._answer ?? "";
			}
			set
			{
				this._answer = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool answerSpecified
		{
			get
			{
				return this._answer != null;
			}
			set
			{
				bool flag = value == (this._answer == null);
				if (flag)
				{
					this._answer = (value ? this.answer : null);
				}
			}
		}

		private bool ShouldSerializeanswer()
		{
			return this.answerSpecified;
		}

		private void Resetanswer()
		{
			this.answerSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "audiotime", DataFormat = DataFormat.TwosComplement)]
		public uint audiotime
		{
			get
			{
				return this._audiotime ?? 0U;
			}
			set
			{
				this._audiotime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audiotimeSpecified
		{
			get
			{
				return this._audiotime != null;
			}
			set
			{
				bool flag = value == (this._audiotime == null);
				if (flag)
				{
					this._audiotime = (value ? new uint?(this.audiotime) : null);
				}
			}
		}

		private bool ShouldSerializeaudiotime()
		{
			return this.audiotimeSpecified;
		}

		private void Resetaudiotime()
		{
			this.audiotimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "qid", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _audiouid;

		private string _answer;

		private uint? _audiotime;

		private uint? _qid;

		private IExtension extensionObject;
	}
}
