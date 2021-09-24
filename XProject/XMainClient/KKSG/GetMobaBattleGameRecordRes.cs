using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMobaBattleGameRecordRes")]
	[Serializable]
	public class GetMobaBattleGameRecordRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MobaBattleOneGame record
		{
			get
			{
				return this._record;
			}
			set
			{
				this._record = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private MobaBattleOneGame _record = null;

		private IExtension extensionObject;
	}
}
