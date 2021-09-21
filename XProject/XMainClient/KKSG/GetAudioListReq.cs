using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200014E RID: 334
	[ProtoContract(Name = "GetAudioListReq")]
	[Serializable]
	public class GetAudioListReq : IExtensible
	{
		// Token: 0x17000678 RID: 1656
		// (get) Token: 0x06001454 RID: 5204 RVA: 0x00028FD8 File Offset: 0x000271D8
		[ProtoMember(1, Name = "audioUidList", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> audioUidList
		{
			get
			{
				return this._audioUidList;
			}
		}

		// Token: 0x17000679 RID: 1657
		// (get) Token: 0x06001455 RID: 5205 RVA: 0x00028FF0 File Offset: 0x000271F0
		// (set) Token: 0x06001456 RID: 5206 RVA: 0x0002901C File Offset: 0x0002721C
		[ProtoMember(2, IsRequired = false, Name = "rpcid", DataFormat = DataFormat.TwosComplement)]
		public uint rpcid
		{
			get
			{
				return this._rpcid ?? 0U;
			}
			set
			{
				this._rpcid = new uint?(value);
			}
		}

		// Token: 0x1700067A RID: 1658
		// (get) Token: 0x06001457 RID: 5207 RVA: 0x0002902C File Offset: 0x0002722C
		// (set) Token: 0x06001458 RID: 5208 RVA: 0x0002904C File Offset: 0x0002724C
		[XmlIgnore]
		[Browsable(false)]
		public bool rpcidSpecified
		{
			get
			{
				return this._rpcid != null;
			}
			set
			{
				bool flag = value == (this._rpcid == null);
				if (flag)
				{
					this._rpcid = (value ? new uint?(this.rpcid) : null);
				}
			}
		}

		// Token: 0x06001459 RID: 5209 RVA: 0x00029090 File Offset: 0x00027290
		private bool ShouldSerializerpcid()
		{
			return this.rpcidSpecified;
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x000290A8 File Offset: 0x000272A8
		private void Resetrpcid()
		{
			this.rpcidSpecified = false;
		}

		// Token: 0x0600145B RID: 5211 RVA: 0x000290B4 File Offset: 0x000272B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000511 RID: 1297
		private readonly List<ulong> _audioUidList = new List<ulong>();

		// Token: 0x04000512 RID: 1298
		private uint? _rpcid;

		// Token: 0x04000513 RID: 1299
		private IExtension extensionObject;
	}
}
