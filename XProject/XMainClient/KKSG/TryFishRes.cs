using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000260 RID: 608
	[ProtoContract(Name = "TryFishRes")]
	[Serializable]
	public class TryFishRes : IExtensible
	{
		// Token: 0x17000A9F RID: 2719
		// (get) Token: 0x0600221A RID: 8730 RVA: 0x00042B28 File Offset: 0x00040D28
		// (set) Token: 0x0600221B RID: 8731 RVA: 0x00042B54 File Offset: 0x00040D54
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

		// Token: 0x17000AA0 RID: 2720
		// (get) Token: 0x0600221C RID: 8732 RVA: 0x00042B64 File Offset: 0x00040D64
		// (set) Token: 0x0600221D RID: 8733 RVA: 0x00042B84 File Offset: 0x00040D84
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

		// Token: 0x0600221E RID: 8734 RVA: 0x00042BC8 File Offset: 0x00040DC8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x00042BE0 File Offset: 0x00040DE0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000AA1 RID: 2721
		// (get) Token: 0x06002220 RID: 8736 RVA: 0x00042BEC File Offset: 0x00040DEC
		[ProtoMember(2, Name = "item", DataFormat = DataFormat.Default)]
		public List<ItemBrief> item
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x17000AA2 RID: 2722
		// (get) Token: 0x06002221 RID: 8737 RVA: 0x00042C04 File Offset: 0x00040E04
		// (set) Token: 0x06002222 RID: 8738 RVA: 0x00042C30 File Offset: 0x00040E30
		[ProtoMember(3, IsRequired = false, Name = "fish_level", DataFormat = DataFormat.TwosComplement)]
		public uint fish_level
		{
			get
			{
				return this._fish_level ?? 0U;
			}
			set
			{
				this._fish_level = new uint?(value);
			}
		}

		// Token: 0x17000AA3 RID: 2723
		// (get) Token: 0x06002223 RID: 8739 RVA: 0x00042C40 File Offset: 0x00040E40
		// (set) Token: 0x06002224 RID: 8740 RVA: 0x00042C60 File Offset: 0x00040E60
		[XmlIgnore]
		[Browsable(false)]
		public bool fish_levelSpecified
		{
			get
			{
				return this._fish_level != null;
			}
			set
			{
				bool flag = value == (this._fish_level == null);
				if (flag)
				{
					this._fish_level = (value ? new uint?(this.fish_level) : null);
				}
			}
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x00042CA4 File Offset: 0x00040EA4
		private bool ShouldSerializefish_level()
		{
			return this.fish_levelSpecified;
		}

		// Token: 0x06002226 RID: 8742 RVA: 0x00042CBC File Offset: 0x00040EBC
		private void Resetfish_level()
		{
			this.fish_levelSpecified = false;
		}

		// Token: 0x17000AA4 RID: 2724
		// (get) Token: 0x06002227 RID: 8743 RVA: 0x00042CC8 File Offset: 0x00040EC8
		// (set) Token: 0x06002228 RID: 8744 RVA: 0x00042CF4 File Offset: 0x00040EF4
		[ProtoMember(4, IsRequired = false, Name = "experiences", DataFormat = DataFormat.TwosComplement)]
		public uint experiences
		{
			get
			{
				return this._experiences ?? 0U;
			}
			set
			{
				this._experiences = new uint?(value);
			}
		}

		// Token: 0x17000AA5 RID: 2725
		// (get) Token: 0x06002229 RID: 8745 RVA: 0x00042D04 File Offset: 0x00040F04
		// (set) Token: 0x0600222A RID: 8746 RVA: 0x00042D24 File Offset: 0x00040F24
		[XmlIgnore]
		[Browsable(false)]
		public bool experiencesSpecified
		{
			get
			{
				return this._experiences != null;
			}
			set
			{
				bool flag = value == (this._experiences == null);
				if (flag)
				{
					this._experiences = (value ? new uint?(this.experiences) : null);
				}
			}
		}

		// Token: 0x0600222B RID: 8747 RVA: 0x00042D68 File Offset: 0x00040F68
		private bool ShouldSerializeexperiences()
		{
			return this.experiencesSpecified;
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x00042D80 File Offset: 0x00040F80
		private void Resetexperiences()
		{
			this.experiencesSpecified = false;
		}

		// Token: 0x0600222D RID: 8749 RVA: 0x00042D8C File Offset: 0x00040F8C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000875 RID: 2165
		private ErrorCode? _result;

		// Token: 0x04000876 RID: 2166
		private readonly List<ItemBrief> _item = new List<ItemBrief>();

		// Token: 0x04000877 RID: 2167
		private uint? _fish_level;

		// Token: 0x04000878 RID: 2168
		private uint? _experiences;

		// Token: 0x04000879 RID: 2169
		private IExtension extensionObject;
	}
}
