using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildFatigueRes")]
	[Serializable]
	public class GuildFatigueRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "totalsend", DataFormat = DataFormat.TwosComplement)]
		public int totalsend
		{
			get
			{
				return this._totalsend ?? 0;
			}
			set
			{
				this._totalsend = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalsendSpecified
		{
			get
			{
				return this._totalsend != null;
			}
			set
			{
				bool flag = value == (this._totalsend == null);
				if (flag)
				{
					this._totalsend = (value ? new int?(this.totalsend) : null);
				}
			}
		}

		private bool ShouldSerializetotalsend()
		{
			return this.totalsendSpecified;
		}

		private void Resettotalsend()
		{
			this.totalsendSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "totalrecv", DataFormat = DataFormat.TwosComplement)]
		public int totalrecv
		{
			get
			{
				return this._totalrecv ?? 0;
			}
			set
			{
				this._totalrecv = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalrecvSpecified
		{
			get
			{
				return this._totalrecv != null;
			}
			set
			{
				bool flag = value == (this._totalrecv == null);
				if (flag)
				{
					this._totalrecv = (value ? new int?(this.totalrecv) : null);
				}
			}
		}

		private bool ShouldSerializetotalrecv()
		{
			return this.totalrecvSpecified;
		}

		private void Resettotalrecv()
		{
			this.totalrecvSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private int? _totalsend;

		private int? _totalrecv;

		private IExtension extensionObject;
	}
}
