using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UpdateVoipRoomMemberNtf")]
	[Serializable]
	public class UpdateVoipRoomMemberNtf : IExtensible
	{

		[ProtoMember(1, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<VoipRoomMember> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<VoipRoomMember> _dataList = new List<VoipRoomMember>();

		private IExtension extensionObject;
	}
}
