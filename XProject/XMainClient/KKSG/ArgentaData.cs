using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000645 RID: 1605
	[ProtoContract(Name = "ArgentaData")]
	[Serializable]
	public class ArgentaData : IExtensible
	{
		// Token: 0x17001F73 RID: 8051
		// (get) Token: 0x060063C0 RID: 25536 RVA: 0x000BE5D8 File Offset: 0x000BC7D8
		// (set) Token: 0x060063C1 RID: 25537 RVA: 0x000BE604 File Offset: 0x000BC804
		[ProtoMember(1, IsRequired = false, Name = "argentaStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint argentaStartTime
		{
			get
			{
				return this._argentaStartTime ?? 0U;
			}
			set
			{
				this._argentaStartTime = new uint?(value);
			}
		}

		// Token: 0x17001F74 RID: 8052
		// (get) Token: 0x060063C2 RID: 25538 RVA: 0x000BE614 File Offset: 0x000BC814
		// (set) Token: 0x060063C3 RID: 25539 RVA: 0x000BE634 File Offset: 0x000BC834
		[XmlIgnore]
		[Browsable(false)]
		public bool argentaStartTimeSpecified
		{
			get
			{
				return this._argentaStartTime != null;
			}
			set
			{
				bool flag = value == (this._argentaStartTime == null);
				if (flag)
				{
					this._argentaStartTime = (value ? new uint?(this.argentaStartTime) : null);
				}
			}
		}

		// Token: 0x060063C4 RID: 25540 RVA: 0x000BE678 File Offset: 0x000BC878
		private bool ShouldSerializeargentaStartTime()
		{
			return this.argentaStartTimeSpecified;
		}

		// Token: 0x060063C5 RID: 25541 RVA: 0x000BE690 File Offset: 0x000BC890
		private void ResetargentaStartTime()
		{
			this.argentaStartTimeSpecified = false;
		}

		// Token: 0x17001F75 RID: 8053
		// (get) Token: 0x060063C6 RID: 25542 RVA: 0x000BE69C File Offset: 0x000BC89C
		// (set) Token: 0x060063C7 RID: 25543 RVA: 0x000BE6C8 File Offset: 0x000BC8C8
		[ProtoMember(2, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x17001F76 RID: 8054
		// (get) Token: 0x060063C8 RID: 25544 RVA: 0x000BE6D8 File Offset: 0x000BC8D8
		// (set) Token: 0x060063C9 RID: 25545 RVA: 0x000BE6F8 File Offset: 0x000BC8F8
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x060063CA RID: 25546 RVA: 0x000BE73C File Offset: 0x000BC93C
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x060063CB RID: 25547 RVA: 0x000BE754 File Offset: 0x000BC954
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17001F77 RID: 8055
		// (get) Token: 0x060063CC RID: 25548 RVA: 0x000BE760 File Offset: 0x000BC960
		// (set) Token: 0x060063CD RID: 25549 RVA: 0x000BE78C File Offset: 0x000BC98C
		[ProtoMember(3, IsRequired = false, Name = "lastUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastUpdateTime
		{
			get
			{
				return this._lastUpdateTime ?? 0U;
			}
			set
			{
				this._lastUpdateTime = new uint?(value);
			}
		}

		// Token: 0x17001F78 RID: 8056
		// (get) Token: 0x060063CE RID: 25550 RVA: 0x000BE79C File Offset: 0x000BC99C
		// (set) Token: 0x060063CF RID: 25551 RVA: 0x000BE7BC File Offset: 0x000BC9BC
		[XmlIgnore]
		[Browsable(false)]
		public bool lastUpdateTimeSpecified
		{
			get
			{
				return this._lastUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._lastUpdateTime == null);
				if (flag)
				{
					this._lastUpdateTime = (value ? new uint?(this.lastUpdateTime) : null);
				}
			}
		}

		// Token: 0x060063D0 RID: 25552 RVA: 0x000BE800 File Offset: 0x000BCA00
		private bool ShouldSerializelastUpdateTime()
		{
			return this.lastUpdateTimeSpecified;
		}

		// Token: 0x060063D1 RID: 25553 RVA: 0x000BE818 File Offset: 0x000BCA18
		private void ResetlastUpdateTime()
		{
			this.lastUpdateTimeSpecified = false;
		}

		// Token: 0x17001F79 RID: 8057
		// (get) Token: 0x060063D2 RID: 25554 RVA: 0x000BE824 File Offset: 0x000BCA24
		[ProtoMember(4, Name = "getDailyRewards", DataFormat = DataFormat.TwosComplement)]
		public List<uint> getDailyRewards
		{
			get
			{
				return this._getDailyRewards;
			}
		}

		// Token: 0x060063D3 RID: 25555 RVA: 0x000BE83C File Offset: 0x000BCA3C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400182D RID: 6189
		private uint? _argentaStartTime;

		// Token: 0x0400182E RID: 6190
		private uint? _level;

		// Token: 0x0400182F RID: 6191
		private uint? _lastUpdateTime;

		// Token: 0x04001830 RID: 6192
		private readonly List<uint> _getDailyRewards = new List<uint>();

		// Token: 0x04001831 RID: 6193
		private IExtension extensionObject;
	}
}
