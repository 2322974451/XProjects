using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InvFightAgainPara")]
	[Serializable]
	public class InvFightAgainPara : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CreateCrossBattleSceneArg data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private CreateCrossBattleSceneArg _data = null;

		private IExtension extensionObject;
	}
}
