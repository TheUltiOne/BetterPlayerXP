using System;
using System.IO;
using Exiled.API.Features;
using PlayerXP.API;
using CommandSystem;

namespace PlayerXP
{
	public class PlayerXP : Plugin<Config>
	{
		public static PlayerXP instance;
		private EventHandler ev;
		public static string XPPath = Path.Combine(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EXILED"), "Plugins"), "PlayerXP");

		public override string Name => "PlayerXp";
		public override string Author { get; } = "Formerly by Cyanox, updated by AtomSnow (and DentyTxR for a Partial Update)";
        	public override Version RequiredExiledVersion { get; } = new Version(3, 0, 5);
        	public override string Prefix { get; } = "pxp";
        	public override Version Version { get; } = new Version(0, 2, 0);

		public override void OnEnabled()
		{
			base.OnEnabled();
			Log.Info("[BetterPlayerXP] - THIS RELEASE HAS ISSUES SUCH AS COMMANDS NOT WORKING, IF ANY BUG APPEARS PLEASE MAKE BUG REPORT ON GITHUB.");
			Log.Info("[BetterPlayerXP] - This version was made/compiled for EXILED 3.0.5, while there is newer, this plugin might not work.");

			if (!Config.IsEnabled) return;

			if (!Directory.Exists(XPPath)) Directory.CreateDirectory(XPPath);

			instance = this;
			ev = new EventHandler();
			PXP.singleton = ev;

			Exiled.Events.Handlers.Server.WaitingForPlayers += ev.OnWaitingForPlayers;
			Exiled.Events.Handlers.Server.RoundStarted += ev.OnRoundStart;
			Exiled.Events.Handlers.Server.RestartingRound += ev.OnRoundRestart;
			Exiled.Events.Handlers.Server.RoundEnded += ev.OnRoundEnd;
			Exiled.Events.Handlers.Player.Verified += ev.OnVerified;
			Exiled.Events.Handlers.Player.Dying += ev.OnPlayerDying;
			Exiled.Events.Handlers.Player.FailingEscapePocketDimension += ev.OnPocketDimensionDie;
			Exiled.Events.Handlers.Scp049.FinishingRecall += ev.OnRecallZombie;
			Exiled.Events.Handlers.Player.Escaping += ev.OnCheckEscape;
			Exiled.Events.Handlers.Player.Handcuffing += ev.OnHandcuff;
			Exiled.Events.Handlers.Player.RemovingHandcuffs += ev.OnRemovingHandcuff;
		}

		public override void OnDisabled() 
		{
			base.OnDisabled();

			Exiled.Events.Handlers.Server.WaitingForPlayers -= ev.OnWaitingForPlayers;
			Exiled.Events.Handlers.Server.RoundStarted -= ev.OnRoundStart;
			Exiled.Events.Handlers.Server.RestartingRound -= ev.OnRoundRestart;
			Exiled.Events.Handlers.Server.RoundEnded -= ev.OnRoundEnd;
			Exiled.Events.Handlers.Player.Verified -= ev.OnVerified;
			Exiled.Events.Handlers.Player.Dying -= ev.OnPlayerDying;
			Exiled.Events.Handlers.Player.FailingEscapePocketDimension -= ev.OnPocketDimensionDie;
			Exiled.Events.Handlers.Scp049.FinishingRecall -= ev.OnRecallZombie;
			Exiled.Events.Handlers.Player.Escaping -= ev.OnCheckEscape;
			Exiled.Events.Handlers.Player.Handcuffing -= ev.OnHandcuff;
			Exiled.Events.Handlers.Player.RemovingHandcuffs -= ev.OnRemovingHandcuff;

			ev = null;
		}

	}
}
