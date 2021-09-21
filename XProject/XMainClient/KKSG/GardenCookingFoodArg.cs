using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200026A RID: 618
	[ProtoContract(Name = "GardenCookingFoodArg")]
	[Serializable]
	public class GardenCookingFoodArg : IExtensible
	{
		// Token: 0x17000AB7 RID: 2743
		// (get) Token: 0x06002272 RID: 8818 RVA: 0x000434C8 File Offset: 0x000416C8
		// (set) Token: 0x06002273 RID: 8819 RVA: 0x000434F4 File Offset: 0x000416F4
		[ProtoMember(1, IsRequired = false, Name = "food_id", DataFormat = DataFormat.TwosComplement)]
		public uint food_id
		{
			get
			{
				return this._food_id ?? 0U;
			}
			set
			{
				this._food_id = new uint?(value);
			}
		}

		// Token: 0x17000AB8 RID: 2744
		// (get) Token: 0x06002274 RID: 8820 RVA: 0x00043504 File Offset: 0x00041704
		// (set) Token: 0x06002275 RID: 8821 RVA: 0x00043524 File Offset: 0x00041724
		[XmlIgnore]
		[Browsable(false)]
		public bool food_idSpecified
		{
			get
			{
				return this._food_id != null;
			}
			set
			{
				bool flag = value == (this._food_id == null);
				if (flag)
				{
					this._food_id = (value ? new uint?(this.food_id) : null);
				}
			}
		}

		// Token: 0x06002276 RID: 8822 RVA: 0x00043568 File Offset: 0x00041768
		private bool ShouldSerializefood_id()
		{
			return this.food_idSpecified;
		}

		// Token: 0x06002277 RID: 8823 RVA: 0x00043580 File Offset: 0x00041780
		private void Resetfood_id()
		{
			this.food_idSpecified = false;
		}

		// Token: 0x06002278 RID: 8824 RVA: 0x0004358C File Offset: 0x0004178C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400088C RID: 2188
		private uint? _food_id;

		// Token: 0x0400088D RID: 2189
		private IExtension extensionObject;
	}
}
