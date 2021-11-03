namespace PlayerXP
{
	public class PlayerInfo
	{
		public string name;
		public int level;
		public int xp;
		public float karma;

		public PlayerInfo(string name)
		{
			this.name = name;
			level = 1;
			xp = PlayerXP.instance.Config.XpInitial;
			karma = PlayerXP.instance.Config.KarmaInitial;
		}
	}
}
