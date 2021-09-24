using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReportBattleArg")]
	[Serializable]
	public class ReportBattleArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "battledata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BattleData battledata
		{
			get
			{
				return this._battledata;
			}
			set
			{
				this._battledata = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private BattleData _battledata = null;

		private IExtension extensionObject;
	}
}
