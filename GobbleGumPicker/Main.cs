using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GobbleGumPicker.Properties;
using HtmlAgilityPack;

namespace GobbleGumPicker
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
			Init();
		}

		public class Gobblegum
		{
			public enum Color
			{
				None,
				Blue, // round-based
				Orange, // activates immediately
				Green, // time-based
				Purple // activated
			}

			public enum Rarity
			{
				None,
				Classic,
				Whimsical,
				Mega,
				RareMega,
				UltraRareMega
			}

			public string name = string.Empty;
			public string description = string.Empty;
			public Image image = Resources.Empty;
			public Color color = Color.None;
			public Rarity rarity = Rarity.None;

			public Gobblegum() { }

			public Gobblegum(string gobblegumName, Image gobblegumImage, Color gobblegumColor, Rarity gobblegumRarity, string gobblegumDescription)
			{
				name = gobblegumName;
				image = gobblegumImage;
				color = gobblegumColor;
				rarity = gobblegumRarity;
				description = gobblegumDescription;
			}
		}

		public class Recipe
		{
			public Gobblegum firstInput = new Gobblegum();
			public Gobblegum secondInput = new Gobblegum();
			public Gobblegum thirdInput = new Gobblegum();

			public Gobblegum output = new Gobblegum();

			public Recipe() { }

			public Recipe(Gobblegum recipeFirstInput, Gobblegum recipeOutput)
			{
				firstInput = recipeFirstInput;
				secondInput = null;
				thirdInput = null;

				output = recipeOutput;
			}

			public Recipe(Gobblegum recipeFirstInput, Gobblegum recipeSecondInput, Gobblegum recipeOutput)
			{
				firstInput = recipeFirstInput;
				secondInput = recipeSecondInput;
				thirdInput = null;

				output = recipeOutput;
			}

			public Recipe(Gobblegum recipeFirstInput, Gobblegum recipeSecondInput, Gobblegum recipeThirdInput, Gobblegum recipeOutput)
			{
				firstInput = recipeFirstInput;
				secondInput = recipeSecondInput;
				thirdInput = recipeThirdInput;

				output = recipeOutput;
			}
		}

		private static readonly List<Gobblegum> GobblegumDatabase = new List<Gobblegum>()
		{
			new Gobblegum("Always Done Swiftly", Resources.AlwaysDoneSwiftly, Gobblegum.Color.Blue, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 3 full rounds)\nWalk faster while aiming. Raise and lower your weapon to aim more quickly."),
			new Gobblegum("Arms Grace", Resources.ArmsGrace, Gobblegum.Color.Orange, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts until next respawn)\nRespawn with the guns you had when you bled out."),
			new Gobblegum("Coagulant", Resources.Coagulant, Gobblegum.Color.Green, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 20 minutes)\nLonger bleedout time."),
			new Gobblegum("In Plain Sight", Resources.InPlainSight, Gobblegum.Color.Purple, Gobblegum.Rarity.Classic, "Activated (2x Activations, 10 seconds each)\nYou are ignored by zombies for 10 seconds."),
			new Gobblegum("Stock Option", Resources.StockOption, Gobblegum.Color.Green, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 3 minutes)\nAmmo is taken from your stockpile instead of your weapon's magazine."),

			new Gobblegum("Impatient", Resources.Impatient, Gobblegum.Color.Orange, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts until bleedout)\nRespawn near the end of the current round instead of at the start of the next round."),
			new Gobblegum("Sword Flay", Resources.SwordFlay, Gobblegum.Color.Green, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 2.5 minutes)\nMelee attacks deal zombies 5x as much damage."),
			new Gobblegum("Anywhere But Here!", Resources.AnywhereButHere, Gobblegum.Color.Purple, Gobblegum.Rarity.Classic, "Activated (2x Activations)\nInstantly teleport to a random location. A concussive blast knocks away any nearby zombies, keeping you safe."),
			new Gobblegum("Danger Closest", Resources.DangerClosest, Gobblegum.Color.Blue, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 3 full rounds)\nZero explosive damage."),
			new Gobblegum("Armamental Accomplishment", Resources.ArmamentalAccomplishment, Gobblegum.Color.Blue, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 3 full rounds)\nSwitch weapons and recover from performing melee attacks faster. Reload and use items more quickly."),
			new Gobblegum("Firing On All Cylinders", Resources.FiringOnAllCylinders, Gobblegum.Color.Blue, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 3 full rounds)\nCan fire while sprinting."),
			new Gobblegum("Arsenal Accelerator", Resources.ArmamentalAccomplishment, Gobblegum.Color.Green, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 10 minutes)\nCharge your special weapon faster."),
			new Gobblegum("Lucky Crit", Resources.LuckyCrit, Gobblegum.Color.Blue, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 1 full round)\nImproves your chances of activating an Alternate Ammo Type."),
			new Gobblegum("Now You See Me", Resources.NowYouSeeMe, Gobblegum.Color.Purple, Gobblegum.Rarity.Classic, "Activated (2x Activations)\nAll zombies will chase you for 10 seconds."),
			new Gobblegum("Alchemical Antithesis", Resources.AlchemicalAntithesis, Gobblegum.Color.Purple, Gobblegum.Rarity.Classic, "Activated (2x Activations, 60 seconds each)\nEvery 10 points earned is instead awarded 1 ammo in the stock of the current weapon."),

			new Gobblegum("Eye Candy", Resources.EyeCandy, Gobblegum.Color.Purple, Gobblegum.Rarity.Whimsical, "Activated (4x Activations)\nOverrides the colors you see."),
			new Gobblegum("Tone Death", Resources.ToneDeath, Gobblegum.Color.Orange, Gobblegum.Rarity.Whimsical, "Auto-activates when killing a zombie (25x Activations)\nSilly sounds play when zombies are killed."),
			new Gobblegum("Projectile Vomiting", Resources.ProjectileVomiting, Gobblegum.Color.Blue, Gobblegum.Rarity.Whimsical, "Activates Immediately (Lasts 5 full rounds)\nZombies you kill with grenades and large projectiles vomit uncontrollably."),
			new Gobblegum("Newtonian Negation", Resources.NewtonianNegation, Gobblegum.Color.Green, Gobblegum.Rarity.Whimsical, "Activates Immediately (Lasts 25 minutes)\nZombies you kill fall straight up."),

			new Gobblegum("Aftertaste", Resources.Aftertaste, Gobblegum.Color.Blue, Gobblegum.Rarity.Mega, "Activates Immediately (Lasts 3 full rounds)\nKeep all perks after being revived."),
			new Gobblegum("Board Games", Resources.BoardGames, Gobblegum.Color.Blue, Gobblegum.Rarity.Mega, "Activates Immediately (Lasts 5 full rounds)\nRepairing a board immediately repairs all boards at that window."),
			new Gobblegum("Board To Death", Resources.BoardToDeath, Gobblegum.Color.Green, Gobblegum.Rarity.Mega, "Activates Immediately (Lasts for 5 minutes)\nRepairing a board will kill all nearby zombies."),
			new Gobblegum("Burned Out", Resources.BurnedOut, Gobblegum.Color.Orange, Gobblegum.Rarity.Mega, "Activates Immediately (Lasts two hits)\nThe next time you take melee damage, nearby zombies burst into fire."),
			new Gobblegum("Crawl Space", Resources.CrawlSpace, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (5x Activations)\nAll nearby zombies become crawlers."),
			new Gobblegum("Dead of Nuclear Winter", Resources.DeadOfNuclearWinter, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (2x Activations)\nSpawns a nuke power up."),
			new Gobblegum("Disorderly Combat", Resources.DisorderlyCombat, Gobblegum.Color.Green, Gobblegum.Rarity.Mega, "Activates Immediately (Lasts for 5 minutes)\nGives a random gun every 10 seconds."),
			new Gobblegum("Ephemeral Enhancement", Resources.EphemeralEnhancement, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (2x Activations, 60 seconds each)\nTurns the weapon in your hands into Pack-a-Punched weapon."),
			new Gobblegum("Fatal Contraption", Resources.FatalContraption, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (2x Activations)\nSpawn a Death Machine power up."),
			new Gobblegum("Flavor Hexed", Resources.FlavorHexed, Gobblegum.Color.Orange, Gobblegum.Rarity.Mega, "Activates Immediately (2x Activations)\nTransforms into a random Mega GobbleGum not in your Pack."),
			new Gobblegum("Idle Eyes", Resources.IdleEyes, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (3x Activations, 30 seconds each)\nAll zombies will ignore all players."),
			new Gobblegum("I'm Feeling Lucky", Resources.ImFeelingLucky, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (2x Activations)\nSpawn a random power up."),
			new Gobblegum("Immolation Liquidation", Resources.ImmolationLiquidation, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (3x Activations)\nSpawn a fire sale power up."),
			new Gobblegum("Licensed Contractor", Resources.LicensedContractor, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (3x Activations)\nSpawn a Carpenter power up."),
			new Gobblegum("Mind Blown", Resources.MindBlown, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (3x Activations)\nGib the heads of all zombies you can see, killing them."),
			new Gobblegum("Phoenix Up", Resources.PhoenixUp, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (1x Activation)\nRevives all teammates. Teammates keep all of their perks."),
			new Gobblegum("Pop Shocks", Resources.PopShocks, Gobblegum.Color.Orange, Gobblegum.Rarity.Mega, "Auto-activates when melee attacking zombies (5x Activations)\nMelee attacks trigger an electrostatic discharge, electrocuting nearby zombies."),
			new Gobblegum("Respin Cycle", Resources.RespinCycle, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (2x Activations)\nRe-spins the weapons in a magic box after it has been activated."),
			new Gobblegum("Slaughter Slide", Resources.SlaughterSlide, Gobblegum.Color.Orange, Gobblegum.Rarity.Mega, "Auto-activates when sliding (6x Activations)\nCreate 2 lethal explosions by sliding."),
			new Gobblegum("Unbearable", Resources.Unbearable, Gobblegum.Color.Orange, Gobblegum.Rarity.Mega, "Auto-activates when a teddy bear appears in the magic box.\nMagic box re-spins automatically. Magic box will not move for several uses."),
			new Gobblegum("Unquenchable", Resources.Unquenchable, Gobblegum.Color.Orange, Gobblegum.Rarity.Mega, "Auto-activates when you have maximum perks.\nCan buy an extra perk."),
			new Gobblegum("Who's Keeping Score?", Resources.WhosKeepingScore, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (2x Activations)\nSpawns a double points power up."),

			new Gobblegum("Bullet Boost", Resources.BulletBoost, Gobblegum.Color.Purple, Gobblegum.Rarity.RareMega, "Activated (2x Activations)\nRe-Pack your current Pack-a-Punched gun (if supported)."),
			new Gobblegum("Cache Back", Resources.CacheBack, Gobblegum.Color.Purple, Gobblegum.Rarity.RareMega, "Activated (1x Activation)\nSpawns a max ammo power up."),
			new Gobblegum("Crate Power", Resources.CratePower, Gobblegum.Color.Orange, Gobblegum.Rarity.RareMega, "Auto-activates next time you take a gun from the magic box\nThe next gun taken from the magic box comes Pack-a-Punched."),
			new Gobblegum("Extra Credit", Resources.ExtraCredit, Gobblegum.Color.Purple, Gobblegum.Rarity.RareMega, "Activated (4x Activations)\nSpawns a personal 1250 point power up."),
			new Gobblegum("Fear in Headlights", Resources.FearInHeadlights, Gobblegum.Color.Purple, Gobblegum.Rarity.RareMega, "Activated (1x Activation, 2 minutes)\nZombies seen by players will not move."),
			new Gobblegum("Kill Joy", Resources.KillJoy, Gobblegum.Color.Purple, Gobblegum.Rarity.RareMega, "Activated (2x Activations)\nSpawns an Instakill power up."),
			new Gobblegum("On the House", Resources.OnTheHouse, Gobblegum.Color.Purple, Gobblegum.Rarity.RareMega, "Activated (1x Activation)\nSpawns a free perk power up."),
			new Gobblegum("Soda Fountain", Resources.SodaFountain, Gobblegum.Color.Orange, Gobblegum.Rarity.RareMega, "Auto-activates when you buy a perk (5x Activations)\nCan buy an extra perk. Gives you a free perk after you buy one."),
			new Gobblegum("Temporal Gift", Resources.TemporalGift, Gobblegum.Color.Blue, Gobblegum.Rarity.RareMega, "Activates Immediately (Lasts 1 full round)\nPower ups last longer."),
			new Gobblegum("Undead Man Walking", Resources.UndeadManWalking, Gobblegum.Color.Green, Gobblegum.Rarity.RareMega, "Activates Immediately (Lasts 4 minutes)\nSlow down all zombies to shambling speed."),
			new Gobblegum("Wall Power", Resources.WallPower, Gobblegum.Color.Orange, Gobblegum.Rarity.RareMega, "Auto-activates on your next wall-buy gun purchase\nThe next gun bought off a wall comes Pack-a-Punched."),

			new Gobblegum("Head Drama", Resources.HeadDrama, Gobblegum.Color.Blue, Gobblegum.Rarity.UltraRareMega, "Activates Immediately (Lasts for the remainder of the round)\nAny bullet which hits a zombie will damage its head."),
			new Gobblegum("Killing Time", Resources.KillingTime, Gobblegum.Color.Purple, Gobblegum.Rarity.UltraRareMega, "Activated (1x Activation)\nAll zombies freeze in place for 20 seconds. If they are shot, they will be annihilated when the time is up."),
			new Gobblegum("Near Death Experience", Resources.NearDeathExperience, Gobblegum.Color.Blue, Gobblegum.Rarity.UltraRareMega, "Activates Immediately (Lasts 3 full rounds)\nRevive, or be revived, simply by being near other players. Revived players keep all of their perks."),
			new Gobblegum("Perkaholic", Resources.Perkaholic, Gobblegum.Color.Orange, Gobblegum.Rarity.UltraRareMega, "Activated Immediately\nGives you all perks in the map."),
			new Gobblegum("Power Vacuum", Resources.PowerVacuum, Gobblegum.Color.Blue, Gobblegum.Rarity.UltraRareMega, "Activates Immediately (Lasts for 4 full rounds)\nMore power ups can drop each round."),
			new Gobblegum("Profit Sharing", Resources.ProfitSharing, Gobblegum.Color.Green, Gobblegum.Rarity.UltraRareMega, "Activates Immediately (Lasts 10 minutes)\nPoints you earn are also received by nearby players, and vice versa."),
			new Gobblegum("Reign Drops", Resources.ReignDrops, Gobblegum.Color.Purple, Gobblegum.Rarity.UltraRareMega, "Activated (2x Activations)\nSpawns one of each of the nine core power ups."),
			new Gobblegum("Round Robbin'", Resources.RoundRobbin, Gobblegum.Color.Purple, Gobblegum.Rarity.UltraRareMega, "Activated (1x Activation)\nEnds the current round. All players gain 1600 points."),
			new Gobblegum("Secret Shopper", Resources.SecretShopper, Gobblegum.Color.Green, Gobblegum.Rarity.UltraRareMega, "Activates Immediately (Lasts 10 minutes)\nAny gun wall-buy can be used to buy ammo for any gun."),
			new Gobblegum("Self Medication", Resources.SelfMedication, Gobblegum.Color.Orange, Gobblegum.Rarity.UltraRareMega, "Auto-activates by getting a kill in last stand (3x Activations)\nAuto revive yourself. Keep all of your perks."),
			new Gobblegum("Shopping Free", Resources.ShoppingFree, Gobblegum.Color.Green, Gobblegum.Rarity.UltraRareMega, "Activates Immediately (Lasts 1 minute)\nAll purchases are free.")
		};

		private List<Gobblegum> CurrentGobblegumSet = new List<Gobblegum>();
		private List<Recipe> CurrentNewtonsCookbook = new List<Recipe>();

		private readonly int NewtonsCookbookRefreshIntervalInSeconds = 60;

		private bool NewtonsCookbookOpened = false;

		private bool EnableClassic = true;
		private bool EnableLeveled = true;
		private bool EnableWhimsical = true;

		private int NewtonsCookbookLastRefreshTime = -1;

		private void Init()
		{
			RefreshTooltips();
			RefreshGobblegumsDisplay();
			RefreshNewtonsCookbookDisplay();

			VersionLabel.Text = ProductVersion;
		}

		private void GobblegumMachineClick(object sender, EventArgs e)
		{
			TutorialLabel.Visible = false;

			GenerateGobblegumSet();

			RefreshGobblegumsDisplay();
			RefreshTooltips();
		}

		private void ClassicCheckedChanged(object sender, EventArgs e)
		{
			EnableClassic = ClassicCheckBox.Checked;
			RefreshTooltips();
		}

		private void LeveledCheckedChanged(object sender, EventArgs e)
		{
			EnableLeveled = LeveledCheckBox.Checked;
			RefreshTooltips();
		}

		private void WhimsicalCheckedChanged(object sender, EventArgs e)
		{
			EnableWhimsical = WhimsicalCheckBox.Checked;
			RefreshTooltips();
		}

		private void NewtonsCookbookOpenClick(object sender, EventArgs e)
		{
			NewtonsCookbookOpened = true;
			SetNewtonsCookbookStatus("Fetching recipes...");
			if (GetNewtonsCookbook())
			{
				SetNewtonsCookbookStatus(string.Empty);
			}
			else
			{
				SetNewtonsCookbookStatus("Failed to load Newton's Cookbook!");
			}
			RefreshNewtonsCookbookDisplay();
			RefreshTooltips();
		}

		private void NewtonsCookbookCloseClick(object sender, EventArgs e)
		{
			NewtonsCookbookOpened = false;
			RefreshNewtonsCookbookDisplay();
		}

		private void RefreshTooltips()
		{
			ToolTip.SetToolTip(ClassicCheckBox, (EnableClassic ? "Disable" : "Enable") + " rolling of five default GobbleGums (Always Done Swiftly, Arms Grace, etc.)");
			ToolTip.SetToolTip(LeveledCheckBox, (EnableLeveled ? "Disable" : "Enable") + " rolling of level-awarded GobbleGums (Impatient, Sword Flay, etc.)");
			ToolTip.SetToolTip(WhimsicalCheckBox, (EnableWhimsical ? "Disable" : "Enable") + " rolling of DLC GobbleGums (Eye Candy, Tone Death, etc.)");

			if (CurrentGobblegumSet.Count == 5)
			{
				ToolTip.SetToolTip(Gobblegum1Image, CurrentGobblegumSet[0].description);
				ToolTip.SetToolTip(Gobblegum2Image, CurrentGobblegumSet[1].description);
				ToolTip.SetToolTip(Gobblegum3Image, CurrentGobblegumSet[2].description);
				ToolTip.SetToolTip(Gobblegum4Image, CurrentGobblegumSet[3].description);
				ToolTip.SetToolTip(Gobblegum5Image, CurrentGobblegumSet[4].description);
			}
			else
			{
				ToolTip.SetToolTip(Gobblegum1Image, string.Empty);
				ToolTip.SetToolTip(Gobblegum2Image, string.Empty);
				ToolTip.SetToolTip(Gobblegum3Image, string.Empty);
				ToolTip.SetToolTip(Gobblegum4Image, string.Empty);
				ToolTip.SetToolTip(Gobblegum5Image, string.Empty);
			}

			if (CurrentNewtonsCookbook.Count == 3)
			{
				ToolTip.SetToolTip(NewtonsCookbookOutput1Image, CurrentNewtonsCookbook[0].output.description);

				ToolTip.SetToolTip(NewtonsCookbookInput1_1Image, CurrentNewtonsCookbook[0].firstInput.description);
				ToolTip.SetToolTip(NewtonsCookbookInput1_2Image, CurrentNewtonsCookbook[0].secondInput.description);
				ToolTip.SetToolTip(NewtonsCookbookInput1_3Image, CurrentNewtonsCookbook[0].thirdInput.description);

				ToolTip.SetToolTip(NewtonsCookbookOutput2Image, CurrentNewtonsCookbook[1].output.description);

				ToolTip.SetToolTip(NewtonsCookbookInput2_1Image, CurrentNewtonsCookbook[1].firstInput.description);
				ToolTip.SetToolTip(NewtonsCookbookInput2_2Image, CurrentNewtonsCookbook[1].secondInput.description);
				ToolTip.SetToolTip(NewtonsCookbookInput2_3Image, CurrentNewtonsCookbook[1].thirdInput.description);

				ToolTip.SetToolTip(NewtonsCookbookOutput3Image, CurrentNewtonsCookbook[2].output.description);

				ToolTip.SetToolTip(NewtonsCookbookInput3_1Image, CurrentNewtonsCookbook[2].firstInput.description);
				ToolTip.SetToolTip(NewtonsCookbookInput3_2Image, CurrentNewtonsCookbook[2].secondInput.description);
				ToolTip.SetToolTip(NewtonsCookbookInput3_3Image, CurrentNewtonsCookbook[2].thirdInput.description);
			}
			else
			{
				ToolTip.SetToolTip(NewtonsCookbookOutput1Image, string.Empty);

				ToolTip.SetToolTip(NewtonsCookbookInput1_1Image, string.Empty);
				ToolTip.SetToolTip(NewtonsCookbookInput1_2Image, string.Empty);
				ToolTip.SetToolTip(NewtonsCookbookInput1_3Image, string.Empty);

				ToolTip.SetToolTip(NewtonsCookbookOutput2Image, string.Empty);

				ToolTip.SetToolTip(NewtonsCookbookInput2_1Image, string.Empty);
				ToolTip.SetToolTip(NewtonsCookbookInput2_2Image, string.Empty);
				ToolTip.SetToolTip(NewtonsCookbookInput2_3Image, string.Empty);

				ToolTip.SetToolTip(NewtonsCookbookOutput3Image, string.Empty);

				ToolTip.SetToolTip(NewtonsCookbookInput3_1Image, string.Empty);
				ToolTip.SetToolTip(NewtonsCookbookInput3_2Image, string.Empty);
				ToolTip.SetToolTip(NewtonsCookbookInput3_3Image, string.Empty);
			}
		}

		private void RefreshGobblegumsDisplay()
		{
			if (CurrentGobblegumSet.Count == 5)
			{
				Gobblegum1Label.Text = CurrentGobblegumSet[0].name;
				Gobblegum1Image.Image = CurrentGobblegumSet[0].image;

				Gobblegum2Label.Text = CurrentGobblegumSet[1].name;
				Gobblegum2Image.Image = CurrentGobblegumSet[1].image;

				Gobblegum3Label.Text = CurrentGobblegumSet[2].name;
				Gobblegum3Image.Image = CurrentGobblegumSet[2].image;

				Gobblegum4Label.Text = CurrentGobblegumSet[3].name;
				Gobblegum4Image.Image = CurrentGobblegumSet[3].image;

				Gobblegum5Label.Text = CurrentGobblegumSet[4].name;
				Gobblegum5Image.Image = CurrentGobblegumSet[4].image;
			}
			else
			{
				Gobblegum1Label.Text = string.Empty;
				Gobblegum1Image.Image = null;

				Gobblegum2Label.Text = string.Empty;
				Gobblegum2Image.Image = null;

				Gobblegum3Label.Text = string.Empty;
				Gobblegum3Image.Image = null;

				Gobblegum4Label.Text = string.Empty;
				Gobblegum4Image.Image = null;

				Gobblegum5Label.Text = string.Empty;
				Gobblegum5Image.Image = null;
			}
		}

		private void RefreshNewtonsCookbookDisplay()
		{
			NewtonsCookbookBackground.Visible = NewtonsCookbookOpened;

			NewtonsCookbookStatusLabel.Visible = !string.IsNullOrWhiteSpace(NewtonsCookbookStatusLabel.Text) && NewtonsCookbookOpened;
			NewtonsCookbookCloseButton.BringToFront();

			NewtonsCookbookOnlineProviderLabel.Visible = NewtonsCookbookOpened;

			NewtonsCookbookCloseButton.Visible = NewtonsCookbookOpened;
			NewtonsCookbookCloseButton.BringToFront();

			NewtonsCookbookOutput1Image.Visible = NewtonsCookbookOpened;
			NewtonsCookbookOutput1Label.Visible = NewtonsCookbookOpened;

			NewtonsCookbookInput1_1Image.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput1_1Label.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput1_2Image.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput1_2Label.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput1_3Image.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput1_3Label.Visible = NewtonsCookbookOpened;

			NewtonsCookbookOutput2Image.Visible = NewtonsCookbookOpened;
			NewtonsCookbookOutput2Label.Visible = NewtonsCookbookOpened;

			NewtonsCookbookInput2_1Image.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput2_1Label.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput2_2Image.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput2_2Label.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput2_3Image.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput2_3Label.Visible = NewtonsCookbookOpened;

			NewtonsCookbookOutput3Image.Visible = NewtonsCookbookOpened;
			NewtonsCookbookOutput3Label.Visible = NewtonsCookbookOpened;

			NewtonsCookbookInput3_1Image.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput3_1Label.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput3_2Image.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput3_2Label.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput3_3Image.Visible = NewtonsCookbookOpened;
			NewtonsCookbookInput3_3Label.Visible = NewtonsCookbookOpened;

			if (CurrentNewtonsCookbook.Count == 3)
			{
				NewtonsCookbookOnlineProviderLabel.BringToFront();

				NewtonsCookbookOutput1Label.Text = CurrentNewtonsCookbook[0].output.name;
				NewtonsCookbookOutput1Label.BringToFront();

				NewtonsCookbookOutput1Image.Image = CurrentNewtonsCookbook[0].output.image;
				NewtonsCookbookOutput1Image.BringToFront();

				NewtonsCookbookInput1_1Label.Text = CurrentNewtonsCookbook[0].firstInput.name;
				NewtonsCookbookInput1_1Label.BringToFront();

				NewtonsCookbookInput1_1Image.Image = CurrentNewtonsCookbook[0].firstInput.image;
				NewtonsCookbookInput1_1Image.BringToFront();

				NewtonsCookbookInput1_2Label.Text = CurrentNewtonsCookbook[0].secondInput.name;
				NewtonsCookbookInput1_2Label.BringToFront();

				NewtonsCookbookInput1_2Image.Image = CurrentNewtonsCookbook[0].secondInput.image;
				NewtonsCookbookInput1_2Image.BringToFront();

				NewtonsCookbookInput1_3Label.Text = CurrentNewtonsCookbook[0].thirdInput.name;
				NewtonsCookbookInput1_3Label.BringToFront();

				NewtonsCookbookInput1_3Image.Image = CurrentNewtonsCookbook[0].thirdInput.image;
				NewtonsCookbookInput1_3Image.BringToFront();

				NewtonsCookbookOutput2Label.Text = CurrentNewtonsCookbook[1].output.name;
				NewtonsCookbookOutput2Label.BringToFront();

				NewtonsCookbookOutput2Image.Image = CurrentNewtonsCookbook[1].output.image;
				NewtonsCookbookOutput2Image.BringToFront();

				NewtonsCookbookInput2_1Label.Text = CurrentNewtonsCookbook[1].firstInput.name;
				NewtonsCookbookInput2_1Label.BringToFront();

				NewtonsCookbookInput2_1Image.Image = CurrentNewtonsCookbook[1].firstInput.image;
				NewtonsCookbookInput2_1Image.BringToFront();

				NewtonsCookbookInput2_2Label.Text = CurrentNewtonsCookbook[1].secondInput.name;
				NewtonsCookbookInput2_2Label.BringToFront();

				NewtonsCookbookInput2_2Image.Image = CurrentNewtonsCookbook[1].secondInput.image;
				NewtonsCookbookInput2_2Image.BringToFront();

				NewtonsCookbookInput2_3Label.Text = CurrentNewtonsCookbook[1].thirdInput.name;
				NewtonsCookbookInput2_3Label.BringToFront();

				NewtonsCookbookInput2_3Image.Image = CurrentNewtonsCookbook[1].thirdInput.image;
				NewtonsCookbookInput2_3Image.BringToFront();

				NewtonsCookbookOutput3Label.Text = CurrentNewtonsCookbook[2].output.name;
				NewtonsCookbookOutput3Label.BringToFront();

				NewtonsCookbookOutput3Image.Image = CurrentNewtonsCookbook[2].output.image;
				NewtonsCookbookOutput3Image.BringToFront();

				NewtonsCookbookInput3_1Label.Text = CurrentNewtonsCookbook[2].firstInput.name;
				NewtonsCookbookInput3_1Label.BringToFront();

				NewtonsCookbookInput3_1Image.Image = CurrentNewtonsCookbook[2].firstInput.image;
				NewtonsCookbookInput3_1Image.BringToFront();

				NewtonsCookbookInput3_2Label.Text = CurrentNewtonsCookbook[2].secondInput.name;
				NewtonsCookbookInput3_2Label.BringToFront();

				NewtonsCookbookInput3_2Image.Image = CurrentNewtonsCookbook[2].secondInput.image;
				NewtonsCookbookInput3_2Image.BringToFront();

				NewtonsCookbookInput3_3Label.Text = CurrentNewtonsCookbook[2].thirdInput.name;
				NewtonsCookbookInput3_3Label.BringToFront();

				NewtonsCookbookInput3_3Image.Image = CurrentNewtonsCookbook[2].thirdInput.image;
				NewtonsCookbookInput3_3Image.BringToFront();
			}
			else
			{
				NewtonsCookbookOutput1Image.Image = null;
				NewtonsCookbookOutput1Label.Text = string.Empty;

				NewtonsCookbookInput1_1Image.Image = null;
				NewtonsCookbookInput1_1Label.Text = string.Empty;
				NewtonsCookbookInput1_2Image.Image = null;
				NewtonsCookbookInput1_2Label.Text = string.Empty;
				NewtonsCookbookInput1_3Image.Image = null;
				NewtonsCookbookInput1_3Label.Text = string.Empty;

				NewtonsCookbookOutput2Image.Image = null;
				NewtonsCookbookOutput2Label.Text = string.Empty;

				NewtonsCookbookInput2_1Image.Image = null;
				NewtonsCookbookInput2_1Label.Text = string.Empty;
				NewtonsCookbookInput2_2Image.Image = null;
				NewtonsCookbookInput2_2Label.Text = string.Empty;
				NewtonsCookbookInput2_3Image.Image = null;
				NewtonsCookbookInput2_3Label.Text = string.Empty;

				NewtonsCookbookOutput3Image.Image = null;
				NewtonsCookbookOutput3Label.Text = string.Empty;

				NewtonsCookbookInput3_1Image.Image = null;
				NewtonsCookbookInput3_1Label.Text = string.Empty;
				NewtonsCookbookInput3_2Image.Image = null;
				NewtonsCookbookInput3_2Label.Text = string.Empty;
				NewtonsCookbookInput3_3Image.Image = null;
				NewtonsCookbookInput3_3Label.Text = string.Empty;
			}
		}

		private void GenerateGobblegumSet()
		{
			/*
			 * Don't initialize list like this - it causes
			 * duplicates to be created when generating Gobblegums
			 * 
				CurrentGobblegumSet = new List<Gobblegum>
				{
					GenerateGobblegum(),
					GenerateGobblegum(),
					GenerateGobblegum(),
					GenerateGobblegum(),
					GenerateGobblegum()
				};
			*/

			CurrentGobblegumSet = new List<Gobblegum>();

			CurrentGobblegumSet.Add(GenerateGobblegum());
			CurrentGobblegumSet.Add(GenerateGobblegum());
			CurrentGobblegumSet.Add(GenerateGobblegum());
			CurrentGobblegumSet.Add(GenerateGobblegum());
			CurrentGobblegumSet.Add(GenerateGobblegum());
		}

		private Gobblegum GenerateGobblegum()
		{
			List<Gobblegum> Gobblegums = new List<Gobblegum>(GobblegumDatabase);

			if (!EnableClassic)
			{
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Always Done Swiftly"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Arms Grace"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Coagulant"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "In Plain Sight"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Stock Option"));
			}

			if (!EnableLeveled)
			{
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Impatient"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Sword Flay"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Anywhere But Here!"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Danger Closest"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Armamental Accomplishment"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Firing On All Cylinders"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Arsenal Accelerator"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Lucky Crit"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Now You See Me"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Alchemical Antithesis"));
			}

			if (!EnableWhimsical)
			{
				Gobblegums.RemoveAll(gobblegum => gobblegum.rarity == Gobblegum.Rarity.Whimsical);
			}

			Gobblegum GeneratedGobblegum = Gobblegums[RandomProvider.GetThreadRandom().Next(0, Gobblegums.Count)];

			while (CurrentGobblegumSet.Contains(GeneratedGobblegum) && Gobblegums.Count >= 5)
			{
				GeneratedGobblegum = Gobblegums[RandomProvider.GetThreadRandom().Next(0, Gobblegums.Count)];
			}

			return GeneratedGobblegum;
		}

		private bool GetNewtonsCookbook()
		{
			if ((GetSecondsSinceStart() < NewtonsCookbookLastRefreshTime + NewtonsCookbookRefreshIntervalInSeconds) && CurrentNewtonsCookbook.Count > 0) return true;

			CurrentNewtonsCookbook = new List<Recipe>();

			var html = @"https://bo3.online/index.php#gums";
			try
			{
				HtmlWeb web = new HtmlWeb();
				var doc = web.Load(html);
				var gums = doc.GetElementbyId("gums");

				var htmlDoc = new HtmlAgilityPack.HtmlDocument();
				htmlDoc.LoadHtml(gums.OuterHtml);

				var nodes = htmlDoc.DocumentNode.SelectNodes("//img");

				foreach (var node in nodes)
				{
					Recipe recipe = new Recipe();

					List<string> inputNodes = Regex.Replace(node.Attributes["onclick"].Value.ToLower(), @"\bdrawin_dialog\b|[\(\)']", "").Split(',').ToList();

					recipe.output = GetNewtonsCookbookGobblegumByID(int.Parse(Regex.Replace(node.Attributes["src"].Value.ToLower(), @"img\/|.png", "")));

					int inputNodeID = 0;
					foreach (string inputNode in inputNodes)
					{
						if (!inputNode.StartsWith(".png") && inputNode.EndsWith(".png"))
						{
							switch (inputNodeID)
							{
								case 0:
									recipe.firstInput = GetNewtonsCookbookGobblegumByID(int.Parse(inputNode.Replace(".png", "")));
									break;
								case 1:
									recipe.secondInput = GetNewtonsCookbookGobblegumByID(int.Parse(inputNode.Replace(".png", "")));
									break;
								case 2:
									recipe.thirdInput = GetNewtonsCookbookGobblegumByID(int.Parse(inputNode.Replace(".png", "")));
									break;
							}
							inputNodeID++;
						}
					}

					CurrentNewtonsCookbook.Add(recipe);
				}
				NewtonsCookbookLastRefreshTime = GetSecondsSinceStart();
				return true;
			}
			catch (Exception)
			{
				CurrentNewtonsCookbook = new List<Recipe>();
				return false;
			}
		}

		private void SetNewtonsCookbookStatus(string status)
		{
			NewtonsCookbookStatusLabel.Text = status;
			NewtonsCookbookStatusLabel.Visible = !string.IsNullOrWhiteSpace(status);
		}

		private Gobblegum GetNewtonsCookbookGobblegumByID(int id)
		{
			switch (id)
			{
				case 1:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Aftertaste");
				case 2:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Board Games");
				case 3:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Bullet Boost");
				case 4:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Burned Out");
				case 5:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Cache Back");
				case 6:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Crate Power");
				case 7:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Crawl Space"); // potential id
				case 8:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Dead of Nuclear Winter");
				case 9:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Disorderly Combat");
				case 10:
				case 45:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Ephemeral Enhancement");
				case 11:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Fatal Contraption");
				case 12:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Fear in Headlights");
				case 13:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Flavor Hexed"); // potential id
				case 14:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Head Drama");
				case 15:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "I'm Feeling Lucky");
				case 16:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Idle Eyes");
				case 17:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Immolation Liquidation");
				case 18:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Kill Joy");
				case 19:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Killing Time");
				case 20:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Licensed Contractor");
				case 21:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Mind Blown");
				case 22:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Near Death Experience");
				case 23:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "On the House");
				case 24:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Perkaholic");
				case 25:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Phoenix Up");
				case 26:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Pop Shocks");
				case 27:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Power Vacuum");
				case 28:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Profit Sharing");
				case 29:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Reign Drops");
				case 30:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Respin Cycle");
				case 31:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Round Robbin'");
				case 32:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Secret Shopper");
				case 33:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Self Medication");
				case 34:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Shopping Free");
				case 35:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Slaughter Slide");
				case 36:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Temporal Gift");
				case 37:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Unbearable");
				case 38:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Undead Man Walking");
				case 39:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Unquenchable");
				case 40:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Wall Power");
				case 41:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Who's Keeping Score?");
				case 42:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Extra Credit");
				case 43:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Soda Fountain");
				case 44:
					return GobblegumDatabase.Find(gobblegum => gobblegum.name == "Board To Death");
				default:
					return new Gobblegum();
			}
		}

		private int GetSecondsSinceStart()
		{
			return (int)(DateTime.UtcNow - System.Diagnostics.Process.GetCurrentProcess().StartTime.ToUniversalTime()).TotalSeconds;
		}
	}
}
