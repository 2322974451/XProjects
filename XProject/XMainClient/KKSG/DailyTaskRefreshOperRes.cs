using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DailyTaskRefreshOperRes")]
	[Serializable]
	public class DailyTaskRefreshOperRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "oldscore", DataFormat = DataFormat.TwosComplement)]
		public uint oldscore
		{
			get
			{
				return this._oldscore ?? 0U;
			}
			set
			{
				this._oldscore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool oldscoreSpecified
		{
			get
			{
				return this._oldscore != null;
			}
			set
			{
				bool flag = value == (this._oldscore == null);
				if (flag)
				{
					this._oldscore = (value ? new uint?(this.oldscore) : null);
				}
			}
		}

		private bool ShouldSerializeoldscore()
		{
			return this.oldscoreSpecified;
		}

		private void Resetoldscore()
		{
			this.oldscoreSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _score;

		private uint? _oldscore;

		private IExtension extensionObject;
	}
}
