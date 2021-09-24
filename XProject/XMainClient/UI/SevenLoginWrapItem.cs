using System;
using KKSG;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class SevenLoginWrapItem
	{

		public Transform transform
		{
			get
			{
				return this.m_transform;
			}
		}

		public void Init(Transform tf)
		{
			this.m_transform = tf;
			this.RewardParent = tf.FindChild("AwardList");
			this.m_DayLabel = (tf.FindChild("DayLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_GetButton = (tf.FindChild("Response/GetButton").GetComponent("XUIButton") as IXUIButton);
			this.m_HadGetSprite = tf.FindChild("Response/HadGet");
			this.m_UnGetLabel = tf.FindChild("Response/UnGet");
		}

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

		public Transform m_transform;

		public Transform RewardParent;

		public IXUILabel m_DayLabel;

		public Transform m_UnGetLabel;

		public Transform m_HadGetSprite;

		public IXUIButton m_GetButton;

		private LoginReward m_LoginReward;
	}
}
