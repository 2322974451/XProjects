using System;
using KKSG;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x02001853 RID: 6227
	internal class SevenLoginWrapItem
	{
		// Token: 0x17003972 RID: 14706
		// (get) Token: 0x06010317 RID: 66327 RVA: 0x003E40AC File Offset: 0x003E22AC
		public Transform transform
		{
			get
			{
				return this.m_transform;
			}
		}

		// Token: 0x06010318 RID: 66328 RVA: 0x003E40C4 File Offset: 0x003E22C4
		public void Init(Transform tf)
		{
			this.m_transform = tf;
			this.RewardParent = tf.FindChild("AwardList");
			this.m_DayLabel = (tf.FindChild("DayLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_GetButton = (tf.FindChild("Response/GetButton").GetComponent("XUIButton") as IXUIButton);
			this.m_HadGetSprite = tf.FindChild("Response/HadGet");
			this.m_UnGetLabel = tf.FindChild("Response/UnGet");
		}

		// Token: 0x06010319 RID: 66329 RVA: 0x003E414C File Offset: 0x003E234C
		public void Set(LoginReward reward)
		{
			bool flag = reward == null;
			if (flag)
			{
				this.m_transform.gameObject.SetActive(false);
			}
			else
			{
				this.m_transform.gameObject.SetActive(true);
				this.m_LoginReward = reward;
				this.m_DayLabel.SetText(this.m_LoginReward.day.ToString());
				this.m_GetButton.ID = (ulong)((long)reward.day);
				this.m_GetButton.gameObject.SetActive(reward.state == LoginRewardState.LOGINRS_HAVEHOT);
				this.m_GetButton.SetEnable(true, false);
				this.m_HadGetSprite.gameObject.SetActive(reward.state == LoginRewardState.LOGINRS_HAVE);
				this.m_UnGetLabel.gameObject.SetActive(reward.state == LoginRewardState.LOGINRS_CANNOT);
			}
		}

		// Token: 0x040073FA RID: 29690
		public Transform m_transform;

		// Token: 0x040073FB RID: 29691
		public Transform RewardParent;

		// Token: 0x040073FC RID: 29692
		public IXUILabel m_DayLabel;

		// Token: 0x040073FD RID: 29693
		public Transform m_UnGetLabel;

		// Token: 0x040073FE RID: 29694
		public Transform m_HadGetSprite;

		// Token: 0x040073FF RID: 29695
		public IXUIButton m_GetButton;

		// Token: 0x04007400 RID: 29696
		private LoginReward m_LoginReward;
	}
}
