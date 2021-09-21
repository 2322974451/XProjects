using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002B6 RID: 694
	[ProtoContract(Name = "getintegralbattleInfores")]
	[Serializable]
	public class getintegralbattleInfores : IExtensible
	{
		// Token: 0x17000BFA RID: 3066
		// (get) Token: 0x06002683 RID: 9859 RVA: 0x0004AEF0 File Offset: 0x000490F0
		[ProtoMember(1, Name = "battleinfo", DataFormat = DataFormat.Default)]
		public List<IntegralBattle> battleinfo
		{
			get
			{
				return this._battleinfo;
			}
		}

		// Token: 0x17000BFB RID: 3067
		// (get) Token: 0x06002684 RID: 9860 RVA: 0x0004AF08 File Offset: 0x00049108
		[ProtoMember(2, Name = "battleTime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> battleTime
		{
			get
			{
				return this._battleTime;
			}
		}

		// Token: 0x06002685 RID: 9861 RVA: 0x0004AF20 File Offset: 0x00049120
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000991 RID: 2449
		private readonly List<IntegralBattle> _battleinfo = new List<IntegralBattle>();

		// Token: 0x04000992 RID: 2450
		private readonly List<uint> _battleTime = new List<uint>();

		// Token: 0x04000993 RID: 2451
		private IExtension extensionObject;
	}
}
