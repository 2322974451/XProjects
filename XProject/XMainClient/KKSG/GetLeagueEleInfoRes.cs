using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetLeagueEleInfoRes")]
	[Serializable]
	public class GetLeagueEleInfoRes : IExtensible
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

		[ProtoMember(2, Name = "rounds", DataFormat = DataFormat.Default)]
		public List<LBEleRoundInfo> rounds
		{
			get
			{
				return this._rounds;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "chamption", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueTeamDetail chamption
		{
			get
			{
				return this._chamption;
			}
			set
			{
				this._chamption = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<LBEleRoundInfo> _rounds = new List<LBEleRoundInfo>();

		private LeagueTeamDetail _chamption = null;

		private IExtension extensionObject;
	}
}
