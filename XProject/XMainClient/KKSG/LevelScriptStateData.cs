using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200036A RID: 874
	[ProtoContract(Name = "LevelScriptStateData")]
	[Serializable]
	public class LevelScriptStateData : IExtensible
	{
		// Token: 0x17000EB9 RID: 3769
		// (get) Token: 0x06002F92 RID: 12178 RVA: 0x0005BCC8 File Offset: 0x00059EC8
		[ProtoMember(1, Name = "doorStates", DataFormat = DataFormat.Default)]
		public List<DoorState> doorStates
		{
			get
			{
				return this._doorStates;
			}
		}

		// Token: 0x06002F93 RID: 12179 RVA: 0x0005BCE0 File Offset: 0x00059EE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BCD RID: 3021
		private readonly List<DoorState> _doorStates = new List<DoorState>();

		// Token: 0x04000BCE RID: 3022
		private IExtension extensionObject;
	}
}
