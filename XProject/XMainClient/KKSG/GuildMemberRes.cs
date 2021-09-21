using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200009A RID: 154
	[ProtoContract(Name = "GuildMemberRes")]
	[Serializable]
	public class GuildMemberRes : IExtensible
	{
		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000A97 RID: 2711 RVA: 0x00016D24 File Offset: 0x00014F24
		// (set) Token: 0x06000A98 RID: 2712 RVA: 0x00016D50 File Offset: 0x00014F50
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

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000A99 RID: 2713 RVA: 0x00016D60 File Offset: 0x00014F60
		// (set) Token: 0x06000A9A RID: 2714 RVA: 0x00016D80 File Offset: 0x00014F80
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

		// Token: 0x06000A9B RID: 2715 RVA: 0x00016DC4 File Offset: 0x00014FC4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x00016DDC File Offset: 0x00014FDC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x00016DE8 File Offset: 0x00014FE8
		[ProtoMember(2, Name = "members", DataFormat = DataFormat.Default)]
		public List<GuildMemberData> members
		{
			get
			{
				return this._members;
			}
		}

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06000A9E RID: 2718 RVA: 0x00016E00 File Offset: 0x00015000
		// (set) Token: 0x06000A9F RID: 2719 RVA: 0x00016E2C File Offset: 0x0001502C
		[ProtoMember(3, IsRequired = false, Name = "recvFatigue", DataFormat = DataFormat.TwosComplement)]
		public uint recvFatigue
		{
			get
			{
				return this._recvFatigue ?? 0U;
			}
			set
			{
				this._recvFatigue = new uint?(value);
			}
		}

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000AA0 RID: 2720 RVA: 0x00016E3C File Offset: 0x0001503C
		// (set) Token: 0x06000AA1 RID: 2721 RVA: 0x00016E5C File Offset: 0x0001505C
		[XmlIgnore]
		[Browsable(false)]
		public bool recvFatigueSpecified
		{
			get
			{
				return this._recvFatigue != null;
			}
			set
			{
				bool flag = value == (this._recvFatigue == null);
				if (flag)
				{
					this._recvFatigue = (value ? new uint?(this.recvFatigue) : null);
				}
			}
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x00016EA0 File Offset: 0x000150A0
		private bool ShouldSerializerecvFatigue()
		{
			return this.recvFatigueSpecified;
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x00016EB8 File Offset: 0x000150B8
		private void ResetrecvFatigue()
		{
			this.recvFatigueSpecified = false;
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000AA4 RID: 2724 RVA: 0x00016EC4 File Offset: 0x000150C4
		// (set) Token: 0x06000AA5 RID: 2725 RVA: 0x00016EF0 File Offset: 0x000150F0
		[ProtoMember(4, IsRequired = false, Name = "FatigueMax", DataFormat = DataFormat.TwosComplement)]
		public uint FatigueMax
		{
			get
			{
				return this._FatigueMax ?? 0U;
			}
			set
			{
				this._FatigueMax = new uint?(value);
			}
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000AA6 RID: 2726 RVA: 0x00016F00 File Offset: 0x00015100
		// (set) Token: 0x06000AA7 RID: 2727 RVA: 0x00016F20 File Offset: 0x00015120
		[XmlIgnore]
		[Browsable(false)]
		public bool FatigueMaxSpecified
		{
			get
			{
				return this._FatigueMax != null;
			}
			set
			{
				bool flag = value == (this._FatigueMax == null);
				if (flag)
				{
					this._FatigueMax = (value ? new uint?(this.FatigueMax) : null);
				}
			}
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x00016F64 File Offset: 0x00015164
		private bool ShouldSerializeFatigueMax()
		{
			return this.FatigueMaxSpecified;
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x00016F7C File Offset: 0x0001517C
		private void ResetFatigueMax()
		{
			this.FatigueMaxSpecified = false;
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000AAA RID: 2730 RVA: 0x00016F88 File Offset: 0x00015188
		[ProtoMember(5, Name = "guildinheritid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> guildinheritid
		{
			get
			{
				return this._guildinheritid;
			}
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x00016FA0 File Offset: 0x000151A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002AB RID: 683
		private ErrorCode? _result;

		// Token: 0x040002AC RID: 684
		private readonly List<GuildMemberData> _members = new List<GuildMemberData>();

		// Token: 0x040002AD RID: 685
		private uint? _recvFatigue;

		// Token: 0x040002AE RID: 686
		private uint? _FatigueMax;

		// Token: 0x040002AF RID: 687
		private readonly List<ulong> _guildinheritid = new List<ulong>();

		// Token: 0x040002B0 RID: 688
		private IExtension extensionObject;
	}
}
